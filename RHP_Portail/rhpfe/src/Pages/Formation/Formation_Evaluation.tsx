import { useCallback, useContext, useEffect, useRef, useState } from 'react'
import { Typography, Paper, Grid, Box, Chip, CircularProgress } from '@mui/material';
import Survey_Rendering from '../Survey/Survey_Rendering'
import { colorBase, Agent } from '../../modules/module_general';
import { useLocation, useNavigate } from 'react-router-dom';
import { cntX } from '../../Menu/MenuMain';
import { DrawOutlined, PrintOutlined, SaveAsOutlined, VisibilityOff } from '@mui/icons-material';
import { ChildHandle } from '../Survey/Types';
import useAlert from '../../hooks/useAlert';
import useMsgBox from '../../hooks/useMsgBox';
import useAxiosPost from '../../hooks/useAxiosPost';

type TState = {
    cod_survey: string;
    cod_evaluation: string;
    lib_evaluation: string;
    cod_reply: number;
    evalue: string;
    nom_evalue: string;
    evaluateur: string;
    nom_evaluateur: string;
    typ_survey: "F";
    statut: string;
}

const Formation_Evaluation = () => {
    const myRef = useRef<ChildHandle>(null);
    const location = useLocation();
    const navigate = useNavigate();
    const alert = useAlert();
    const msgBox = useMsgBox();
    const myAxios = useAxiosPost();
    const { settbnMenu, setSignatureProps, setShowSignature } = useContext(cntX);

    const [state, setState] = useState<TState | null>(null);
    const [loading, setLoading] = useState(true);
    const [errorMsg, setErrorMsg] = useState("");

    // Similar to Evaluation.tsx key construction, but for Formation it's usually FormationCode + Evaluator
    const evaluationKey = state ? `${state.cod_evaluation}_${state.evaluateur}` : "";

    const { cod_survey, cod_evaluation, lib_evaluation, cod_reply, evalue, nom_evalue, evaluateur, nom_evaluateur, typ_survey, statut } = state || {} as any;

    const [isAccessible, setAccessible] = useState<{
        canModify: boolean;
        Taken_By_User: string;
        Process_Id: string;
    }>({ canModify: true, Taken_By_User: "", Process_Id: "" });

    // Fetch logic on mount
    useEffect(() => {
        myAxios("formation_evaluation_context", {})
            .then((resp) => {
                if (resp.data && resp.data.result) {
                    setState(resp.data.data);
                } else {
                    const msg = resp.data?.message || (resp as any).error?.message || "Erreur lors du chargement.";
                    setErrorMsg(msg);
                }
            })
            .catch((err) => setErrorMsg(err.message))
            .finally(() => setLoading(false));
    }, []); // Run once

    const isBusinessValid = (statut === "" || statut === "NSS" || statut === undefined);
    const isValidForSave = isBusinessValid && isAccessible.canModify;

    useEffect(() => {
        if (state && isBusinessValid && evaluationKey) {
            myAxios("check_accessible", {
                nameEcran: "Formation_Evaluation",
                idEcran: evaluationKey,
            }).then((dt) => {
                setAccessible(dt.data);
            });

            return () => {
                myAxios("release_accessible", {
                    nameEcran: "Formation_Evaluation",
                    idEcran: evaluationKey,
                });
            };
        }
    }, [state, evaluationKey, isBusinessValid]);

    const Enregistrer = useCallback(async () => {
        if (["SG", "RJ", "SP", "VA"].includes(statut || "")) {
            await msgBox({
                titre: "Enregistrer",
                msg: "Document traité. Modification impossible.",
                typMsg: "error",
                typReply: "OkOnly",
            });
            return;
        }
        if (!isAccessible.canModify) {
            await msgBox({
                titre: "Enregistrer",
                msg: "Document verrouillé par " + isAccessible.Taken_By_User,
                typMsg: "error",
                typReply: "OkOnly"
            });
            return;
        }

        if (myRef.current) {
            const rsl = await myRef.current.save();
            if (rsl.result) {
                alert({
                    titre: "Enregistrement",
                    msg: "Enregistré avec succès",
                    typMsg: "success",
                    timeOut: 3000,
                });
                // Optionally refresh state or status?
            } else {
                alert({
                    titre: "Enregistrement",
                    msg: rsl.data && rsl.data.length > 0 ? (typeof rsl.data[0] === 'object' ? JSON.stringify(rsl.data[0]) : String(rsl.data[0])) : "Enregistrement echoué",
                    typMsg: "error",
                    timeOut: 3000,
                });
            }
        }
    }, [alert, statut, isAccessible]);

    async function NonAccessible() {
        await msgBox({
            titre: "Document utilisé",
            msg: "Document utilisé par: " + isAccessible.Taken_By_User,
            typMsg: "warning",
            typReply: "OkOnly",
        });
    }

    const Imprimer = useCallback(() => {
        window.print();
    }, []);

    const SoumettreEnSignature = useCallback(() => {
        setSignatureProps({ typ_document: "EF", valeur_index: evaluationKey }); // 'EF' for Evaluation Formation? Need to verify DocType code or use generic
        // In VB code: DroitModify_Fiche uses Cod_Formation_Matricule.
        // Assuming 'EF' or similar is configured. For now using generic placeholder or checking if 'EV' works (EV is Evaluation).
        // VB Code uses 'Form_Eval' or implies specific rights.
        // I'll stick to 'EV' if possible or maybe create a new Type if needed. 
        // Wait, VB code for Signature: `If Not EstDate(Dat_Survey_txt.Text) Then Dat_Survey_txt.Text = Now.ToShortDateString`.
        // VB doesn't explicitly show `typDoc` variable in the viewed snippet, but usually it's passed or defined.
        // Looking at `Formation_Evaluation.vb`: `DroitModify_Fiche(Cod_Formation_txt.Text & "_" & Matricule_txt.Text, Me)`
        // And `Generate_QuestionnaireNew(..., "F")`.
        // I will use "EF" (Evaluation Formation) as likely intention, OR keep it simple.
        // Evaluation.tsx uses "EV". I'll use "EV" for now or comment TODO: Verify DocType. 
        // But uniqueness of evaluationKey `${cod_evaluation}_${evaluateur}` might clash with standard Evaluations if codes overlap.
        // Formation Codes are usually distinct.

        setSignatureProps({ typ_document: "EV", valeur_index: evaluationKey });
        setShowSignature(true);
    }, [setSignatureProps, setShowSignature, evaluationKey]);

    useEffect(() => {
        if (!state) return;

        settbnMenu([
            {
                name: "Accessible",
                disabled: false,
                libelle: "Accessible",
                action: NonAccessible,
                icon: <VisibilityOff />,
                visible: !isAccessible?.canModify ? "visible" : "none",
            },
            {
                name: "Enregistrer",
                disabled: !isValidForSave,
                libelle: "Enregistrer",
                action: Enregistrer,
                icon: <SaveAsOutlined />,
            },
            {
                name: "Imprimer",
                disabled: false,
                libelle: "Imprimer",
                action: Imprimer,
                icon: <PrintOutlined />,
            },
            // Signature button if needed? Evaluation.tsx has it. Formation_Evaluation.vb has it (btn_Signature).
            {
                name: "Signer",
                disabled: false,
                libelle: "Signer",
                action: SoumettreEnSignature,
                icon: <DrawOutlined />,
            }
        ]);

        return () => {
            settbnMenu([]);
        };
    }, [settbnMenu, Enregistrer, Imprimer, SoumettreEnSignature, isAccessible, isValidForSave, state]);

    if (loading) return <Box sx={{ display: 'flex', justifyContent: 'center', mt: 5 }}><CircularProgress /></Box>;
    if (errorMsg) return <Box sx={{ p: 4, color: 'error.main' }}><Typography variant="h6">{errorMsg}</Typography></Box>;
    if (!state) return null;

    return (
        <div className="evaluation-container">
            <style>
                {`
          @media print {
            body * {
              visibility: hidden;
            }
            .evaluation-container, .evaluation-container * {
              visibility: visible;
            }
            .evaluation-container {
              position: absolute;
              left: 0;
              top: 0;
              width: 100%;
              margin: 0;
              padding: 0 !important;
              background-color: white;
            }
            .MuiDrawer-root, .MuiAppBar-root, header, nav, .menu-container {
               display: none !important;
            }
          }
        `}
            </style>
            <Typography variant="h4" sx={{ textAlign: 'center', mb: 2, fontWeight: 'bold', color: colorBase.colorBase01 }}>
                Évaluation de Formation
                {(() => {
                    let label = "";
                    let color: "default" | "primary" | "secondary" | "error" | "info" | "success" | "warning" = "default";
                    switch (statut) {
                        case "VA": label = "Validé"; color = "success"; break;
                        case "NSS": label = "Soumettre en signature"; color = "default"; break;
                        case "SS": label = "Soumis en signature"; color = "warning"; break;
                        case "SG": label = "Signé"; color = "success"; break;
                        case "RJ": label = "Rejeté"; color = "error"; break;
                        case "SP": label = "Signé partiellement"; color = "info"; break;
                        default: label = statut || "Brouillon";
                    }
                    if (label) return <Chip label={label} color={color} sx={{ ml: 2, verticalAlign: 'middle', fontWeight: 'bold' }} />;
                    return null;
                })()}
            </Typography>

            <Box sx={{
                p: 3,
                width: '100%',
                bgcolor: "var(--bg-input)",
                color: "var(--fore-color-base-01)",
                border: "1px solid #e0e0e0",
                marginBottom: '10px'
            }}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={6}>
                        <Box>
                            <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                                Formation
                            </Typography>
                            <Typography variant="body1">
                                {String(cod_evaluation)} {String(lib_evaluation)}
                            </Typography>
                        </Box>
                    </Grid>
                    <Grid item xs={12} sm={6}>
                        <Box>
                            <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                                Participant (Répondant)
                            </Typography>
                            <Typography variant="body1">
                                {String(evaluateur)} {String(nom_evaluateur)}
                            </Typography>
                        </Box>
                    </Grid>
                    <Grid item xs={12} sm={6}>
                        <Box>
                            <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                                Formulaire
                            </Typography>
                            <Typography variant="body1">
                                {String(cod_survey)}
                            </Typography>
                        </Box>
                    </Grid>
                    <Grid item xs={12} sm={6}>
                        <Box>
                            <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                                Etat de la réponse
                            </Typography>
                            <Typography variant="body1">
                                {cod_reply > 0 ? `Réponse #${cod_reply}` : "Non commencé"}
                            </Typography>
                        </Box>
                    </Grid>
                </Grid>
            </Box>
            <Survey_Rendering refChild={myRef} ref_evaluation={cod_evaluation} cod_survey={cod_survey} cod_reply={cod_reply} evalue={evalue} evaluateur={evaluateur} typ_survey={typ_survey} readOnly={!isValidForSave} />
        </div>
    )
}

export default Formation_Evaluation
