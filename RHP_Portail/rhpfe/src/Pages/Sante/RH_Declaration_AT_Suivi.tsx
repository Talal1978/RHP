import { useContext, useEffect, useState } from "react";
import { Box } from "@mui/material";
import Grid from "@mui/material/Unstable_Grid2";
import GroupBox from "../../components/GroupBox/GroupBox";
import TextZoom from "../../components/TextZoom/TextZoom";
import ComboBox from "../../components/ComboBox/ComboBox";
import CalendarZoom from "../../components/Calendar/CalendarZoom";
import Bouton from "../../components/Bouton/Bouton";
import Grille from "../../components/Grille/Grille";
import useAxiosPost from "../../hooks/useAxiosPost";
import useMsgBox from "../../hooks/useMsgBox";
import useAlert from "../../hooks/useAlert";
import { cntX } from "../../Menu/MenuMain";
import { SaveAsOutlined, AccountTreeOutlined } from "@mui/icons-material";

/* Suivi reglementaire d'une declaration AT (satellites) : distinction
   travail/trajet, echeancier, transmissions. La declaration elle-meme reste
   geree par l'ecran historique (non modifie). */
const RH_Declaration_AT_Suivi = () => {
  const [numDeclaration, setNumDeclaration] = useState("");
  const [entete, setEntete] = useState<TEntete | null>(null);
  const [echeances, setEcheances] = useState<TEcheance[]>([]);
  const [transmissions, setTransmissions] = useState<TTransmission[]>([]);
  const myAxios = useAxiosPost();
  const msgBox = useMsgBox();
  const alert = useAlert();
  const { setShowLoading, isSmall } = useContext(cntX);

  const Request = (num?: string) => {
    const n = num ?? numDeclaration;
    if (!n) return;
    setShowLoading(true);
    myAxios("sante_at_suivi_get", { Num_Declaration: n }).then((dt) => {
      setShowLoading(false);
      if (dt.data && dt.data?.result && dt.data.entete) {
        setEntete(dt.data.entete);
        setEcheances(dt.data.echeances || []);
        setTransmissions(dt.data.transmissions || []);
      } else {
        setEntete(null);
        setEcheances([]);
        setTransmissions([]);
        alert({ titre: "Suivi AT", msg: dt.data?.message || "Déclaration introuvable ou accès non autorisé", typMsg: "error" });
      }
    });
  };

  const SaveTyp = async () => {
    if (!entete) return;
    const dt = await myAxios("save_sante_at_typ", { Num_Declaration: entete.Num_Declaration, Typ_Accident: entete.Typ_Accident });
    if (dt.data && dt.data?.result) {
      alert({ titre: "Enregistrer", msg: "Type d'accident enregistré", typMsg: "success", timeOut: -1 });
    } else {
      await msgBox({ titre: "Enregistrer", msg: dt.data?.message || "Erreur", typMsg: "error", typReply: "OkOnly" });
    }
  };

  const Generer = async () => {
    if (!entete) return;
    const dt = await myAxios("sante_at_generer_echeances", { Num_Declaration: entete.Num_Declaration });
    if (dt.data && dt.data?.result) {
      alert({ titre: "Échéancier", msg: "Échéancier généré", typMsg: "success", timeOut: -1 });
      Request();
    }
  };

  const SaveEcheance = async (e: TEcheance) => {
    if (e.Statut_Etape === "ANN" && !e.Commentaire) {
      await msgBox({ titre: "Étape", msg: "L'annulation d'une étape doit être motivée (commentaire).", typMsg: "warning", typReply: "OkOnly" });
      return;
    }
    const dt = await myAxios("save_sante_at_echeance", { entete: e });
    if (dt.data && dt.data?.result) {
      alert({ titre: "Étape", msg: "Étape enregistrée", typMsg: "success", timeOut: -1 });
      Request();
    }
  };

  const formatDate = (d: any) => {
    if (!d) return "";
    const dt = new Date(d);
    return isNaN(dt.getTime()) ? "" : dt.toLocaleDateString("fr-FR");
  };

  return (
    <Box sx={{ padding: { xs: "0.5em", sm: "1em" } }}>
      <GroupBox label="Déclaration d'accident" showBorders={!isSmall} showTitre={true}>
        <Grid container spacing={2}>
          <Grid xs={12} sm={6} lg={3}>
            <TextZoom
              numZoom="AT001" nomControle="Num_Declaration" label="N° déclaration" valeur={numDeclaration}
              onchange={(c: string, v: any) => { setNumDeclaration(v); if (v) Request(v); }}
              style={{ width: "100%" }}
            />
          </Grid>
          {entete && (
            <>
              <Grid xs={12} sm={6} lg={3}>
                <Box sx={{ paddingTop: "1.6em" }}>{entete.Matricule} — accident du {formatDate(entete.Dat_Accident)}</Box>
              </Grid>
              <Grid xs={12} sm={6} lg={3}>
                <ComboBox
                  rubrique="Typ_Accident" nomControle="Typ_Accident" label="Type d'accident" valeur={entete.Typ_Accident || "TRAVAIL"}
                  onchange={(c: string, v: any) => setEntete((e) => (e ? { ...e, Typ_Accident: v } : e))} style={{ width: "100%" }}
                />
              </Grid>
              <Grid xs={12} sm={6} lg={3}>
                <Bouton label="Enregistrer le type" startIcon={<SaveAsOutlined />} onClick={SaveTyp} sx={{ marginTop: "1.6em" }} />
              </Grid>
            </>
          )}
        </Grid>
      </GroupBox>

      {entete && (
        <>
          <GroupBox label="Échéancier réglementaire" showBorders={!isSmall} showTitre={true}>
            <Box sx={{ padding: "0.5em" }}>
              <Bouton label="Générer l'échéancier" startIcon={<AccountTreeOutlined />} onClick={Generer} />
            </Box>
            <Box sx={{ padding: "1em 5px", width: "100%", overflow: "scroll" }}>
              <Grille
                readonly={true}
                dataSource={echeances.map((e) => ({
                  Étape: e.Cod_Etape,
                  Départ: formatDate(e.Dat_Debut),
                  "Délai (j)": e.Delai_Jours,
                  Échéance: formatDate(e.Dat_Echeance),
                  Statut: e.Statut_Etape,
                  "Réalisée le": formatDate(e.Dat_Realisation),
                  "En retard": e.En_Retard === "true" ? "OUI" : "",
                }))}
                className="laGrille"
                sx={{ "& tr:has(td:last-child:not(:empty))": { backgroundColor: "#ffe4e1" } }}
              />
              {echeances.length === 0 && <Box sx={{ padding: "1em" }}>Aucune échéance — utilisez « Générer l'échéancier ».</Box>}
            </Box>
          </GroupBox>

          <GroupBox label="Transmissions aux destinataires" showBorders={!isSmall} showTitre={true}>
            <Box sx={{ padding: "1em 5px", width: "100%", overflow: "scroll" }}>
              <Grille
                readonly={true}
                dataSource={transmissions.map((t) => ({
                  Destinataire: t.Cod_Destinataire,
                  "Transmise le": formatDate(t.Dat_Transmission),
                  Mode: t.Mode_Transmission,
                  Référence: t.Reference || "",
                }))}
                className="laGrille"
              />
              {transmissions.length === 0 && <Box sx={{ padding: "1em" }}>Aucune transmission enregistrée (saisie via l'écran Desktop « Suivi réglementaire AT »).</Box>}
            </Box>
          </GroupBox>
        </>
      )}
    </Box>
  );
};

export default RH_Declaration_AT_Suivi;

type TEntete = {
  Num_Declaration: string;
  Matricule: string;
  Dat_Accident: string;
  Heure_Accident?: string;
  Lieu_Accident?: string;
  Typ_Accident: string;
  Statut?: string;
  Cloture?: boolean;
};
type TEcheance = {
  RowId: number;
  Cod_Etape: string;
  Dat_Debut?: string;
  Delai_Jours?: number;
  Dat_Echeance?: string;
  Statut_Etape: string;
  Dat_Realisation?: string;
  FD_Preuve?: number;
  Commentaire?: string;
  En_Retard?: string;
};
type TTransmission = {
  RowId: number;
  Cod_Destinataire: string;
  Dat_Transmission?: string;
  Mode_Transmission?: string;
  Reference?: string;
  FD_Preuve?: number;
  Commentaire?: string;
};
