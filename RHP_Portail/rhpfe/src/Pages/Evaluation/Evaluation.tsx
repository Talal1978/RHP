import { useCallback, useContext, useEffect, useRef, useState } from 'react'
import { Typography, Paper, Grid, Box, Chip } from '@mui/material';
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
  typ_survey: "E";
  statut: string;
}

const Evaluation = () => {
  const myRef = useRef<ChildHandle>(null);
  const location = useLocation();
  const navigate = useNavigate();
  const alert = useAlert();
  const msgBox = useMsgBox();
  const myAxios = useAxiosPost();
  const { settbnMenu, setSignatureProps, setShowSignature } = useContext(cntX);

  const state = location.state as TState;
  const { cod_survey, cod_evaluation, lib_evaluation, cod_reply, evalue, nom_evalue, evaluateur, nom_evaluateur, typ_survey, statut } = state || {} as any;
  const evaluationKey = `${cod_evaluation}_${evalue}_${evaluateur}`;

  const [isAccessible, setAccessible] = useState<{
    canModify: boolean;
    Taken_By_User: string;
    Process_Id: string;
  }>({ canModify: true, Taken_By_User: "", Process_Id: "" });


  const isBusinessValid = (statut === "" || statut === "NSS" || statut === undefined) &&
    (evaluateur === Agent?.Matricule || evalue === Agent?.Matricule);

  const isValidForSave = isBusinessValid && isAccessible.canModify;

  useEffect(() => {
    if (!state) {
      navigate('/myspace/Evaluation_Liste/Consultation des évaluations');
      return;
    }

    if (isBusinessValid && evaluationKey) {
      myAxios("check_accessible", {
        nameEcran: "Evaluation",
        idEcran: evaluationKey,
      }).then((dt) => {
        if (dt?.data && typeof dt.data === "object") setAccessible(dt.data);
      });

      return () => {
        myAxios("release_accessible", {
          nameEcran: "Evaluation",
          idEcran: evaluationKey,
        });
      };
    }
  }, [navigate, evaluationKey, isBusinessValid]);

  const Enregistrer = useCallback(async () => {
    if (["SG", "RJ", "SP", "VA"].includes(statut || "")) {
      await msgBox({
        titre: "Enregistrer",
        msg: "Document traité. Modification impossible.",
        typMsg: "error",
        typReply: "OkOnly",
        async handleOk() {
          return;
        },
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

    if (evaluateur !== Agent?.Matricule && evalue !== Agent?.Matricule) {
      await msgBox({
        titre: "Enregistrer",
        msg: "Vous ne pouvez pas modifier cette évaluation.",
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

  const SoumettreEnSignature = useCallback(async () => {
    // Sécurité : ne jamais soumettre/signer une évaluation sans réponses en base.
    // 1. Si le document est modifiable (brouillon), on enregistre d'abord les
    //    réponses saisies (comme le fait l'application desktop : Saving("SS")).
    if (isValidForSave && myRef.current) {
      const rsl = await myRef.current.save();
      if (!rsl.result) {
        await msgBox({
          titre: "Signer",
          msg: "Enregistrement préalable impossible : " + (rsl.data && rsl.data.length > 0 ? (typeof rsl.data[0] === 'object' ? JSON.stringify(rsl.data[0]) : String(rsl.data[0])) : "erreur inconnue"),
          typMsg: "error",
          typReply: "OkOnly",
        });
        return;
      }
    }
    // 2. Bloquer si aucune réponse n'existe en base (évaluation vide).
    if (!myRef.current?.hasAnswers()) {
      await msgBox({
        titre: "Signer",
        msg: "Aucune réponse n'est enregistrée pour cette évaluation. Signature impossible.",
        typMsg: "error",
        typReply: "OkOnly",
      });
      return;
    }
    setSignatureProps({ typ_document: "EV", valeur_index: evaluationKey });
    setShowSignature(true);
  }, [setSignatureProps, setShowSignature, evaluationKey, isValidForSave, msgBox]);

  useEffect(() => {
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
  }, [settbnMenu, Enregistrer, Imprimer, SoumettreEnSignature, isAccessible, isValidForSave]);

  if (!state) return null;

  return (
    <div className="evaluation-container">
      <style>
        {`
          @media print {
            /* Force l'orientation portrait */
            @page {
              size: A4 portrait;
              margin: 10mm;
            }
            html, body {
              height: auto !important;
              overflow: visible !important;
            }
            body * {
              visibility: hidden;
            }
            .evaluation-container, .evaluation-container * {
              visibility: visible;
            }
            /* Neutralise les conteneurs à défilement (mainMenu/corps/ecran) qui
               tronquent l'impression à la première page */
            .mainMenu, .corps, .ecran {
              position: static !important;
              height: auto !important;
              min-height: 0 !important;
              max-height: none !important;
              overflow: visible !important;
              margin: 0 !important;
              padding: 0 !important;
              width: 100% !important;
              max-width: none !important;
              border-radius: 0 !important;
              box-shadow: none !important;
              background-color: white !important;
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
            .MuiDrawer-root, .MuiAppBar-root, header, nav, .menu-container, .sideMenuBarContainer, .floatMenu {
               display: none !important;
            }
          }
        `}
      </style>
      <Typography variant="h4" sx={{ textAlign: 'center', mb: 2, fontWeight: 'bold', color: colorBase.colorBase01 }}>
        Évaluation
        {(() => {
          let label = "";
          let color: "default" | "primary" | "secondary" | "error" | "info" | "success" | "warning" = "default";
          switch (statut) {
            case "VA":
              label = "Validé";
              color = "success";
              break;
            case "NSS":
              label = "Soumettre en signature";
              color = "default";
              break;
            case "SS":
              label = "Soumis en signature";
              color = "warning";
              break;
            case "SG":
              label = "Signé";
              color = "success";
              break;
            case "RJ":
              label = "Rejeté";
              color = "error";
              break;
            case "SP":
              label = "Signé partiellement";
              color = "info";
              break;
            default:
              label = statut || "Brouillon";
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
          <Grid xs={12} sm={6}>
            <Box>
              <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                Evaluation
              </Typography>
              <Typography variant="body1">
                {String(cod_evaluation)} {String(lib_evaluation)}
              </Typography>
            </Box>
          </Grid>
          <Grid xs={12} sm={6}>
            <Box>
              <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                Évaluateur
              </Typography>
              <Typography variant="body1">
                {String(evaluateur)} {String(nom_evaluateur)}
              </Typography>
            </Box>
          </Grid>
          <Grid xs={12} sm={6}>
            <Box>
              <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                Evalué
              </Typography>
              <Typography variant="body1">
                {String(evalue)} {String(nom_evalue)}
              </Typography>
            </Box>
          </Grid>
          <Grid xs={12} sm={6}>
            <Box>
              <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                Formulaire
              </Typography>
              <Typography variant="body1">
                {String(cod_survey)}
              </Typography>
            </Box>
          </Grid>
          <Grid xs={12}>
            <Box>
              <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                Réponses
              </Typography>
              <Typography variant="body1">
                {String(cod_reply)}
              </Typography>
            </Box>
          </Grid>
        </Grid>
      </Box>
      <Survey_Rendering refChild={myRef} ref_evaluation={cod_evaluation} cod_survey={cod_survey} cod_reply={cod_reply} evalue={evalue} evaluateur={evaluateur} typ_survey={typ_survey} readOnly={!isValidForSave} />
    </div>
  )
}

export default Evaluation
