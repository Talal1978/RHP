import { Fragment, lazy, useContext, useEffect, useRef, useState } from "react";
import { useParams } from "react-router-dom";
import { cntX } from "./MenuMain";
import { estPageAutorisee } from "../modules/module_menus";
import { FloatMenu } from "../components/FloatMenu/FloatMenu";
import Signature from "../Pages/Workflow/Signature";
import Org_Poste from "../Pages/Org_Poste/Org_Poste";
const Note_Frais = lazy(() => import("../Pages/Note_Frais/Note_Frais"));
const Demande_Avance = lazy(() => import("../Pages/Avance/Demande_Avance"));
const Demande_Pret = lazy(() => import("../Pages/Pret/Demande_Pret"));
const RH_Agent = lazy(() => import("../Pages/Rh_Agent/RH_Agent"));
const Note_Frais_Liste = lazy(
  () => import("../Pages/Note_Frais/Note_Frais_Liste")
);
const Demande_Avance_Liste = lazy(
  () => import("../Pages/Avance/Demande_Avance_Liste")
);
const Demande_Pret_Liste = lazy(
  () => import("../Pages/Pret/Demande_Pret_Liste")
);
const Parapheur = lazy(() => import("../Pages/Workflow/Parapheur"));
const RH_Bulletin_Liste = lazy(
  () => import("../Pages/Bulletin_Paie/RH_Bulletin_Liste")
);
const RH_Dossier_Maladie_Liste = lazy(
  () => import("../Pages/Maladie/RH_Dossier_Maladie_Liste")
);
const RH_Dossier_Maladie = lazy(
  () => import("../Pages/Maladie/RH_Dossier_Maladie")
);
const RH_Demande_Conge_Liste = lazy(
  () => import("../Pages/Conges/RH_Demande_Conge_Liste")
);
const Evaluation_Liste = lazy(
  () => import("../Pages/Evaluation/Evaluation_Liste")
);
const Evaluation = lazy(() => import("../Pages/Evaluation/Evaluation"));
const Formation_Evaluation = lazy(() => import("../Pages/Formation/Formation_Evaluation"));
const Formation_Evaluation_Liste = lazy(() => import("../Pages/Formation/Formation_Evaluation_Liste"));
const Formation = lazy(() => import("../Pages/Formation/Formation"));
const Formation_Liste = lazy(() => import("../Pages/Formation/Formation_Liste"));
const RH_Demande_Conge = lazy(() => import("../Pages/Conges/RH_Demande_Conge"));
const RH_Conge_Planning = lazy(() => import("../Pages/Conges/RH_Conge_Planning"));
const Organigramme = lazy(() => import("../Pages/Organigramme/Organigramme"));
const Recrutement_Demande = lazy(() => import("../Pages/Recrutement/Recrutement_Demande"));
const Recrutement_Demande_Liste = lazy(() => import("../Pages/Recrutement/Recrutement_Demande_Liste"));
const RH_Avancement_Timeline = lazy(() => import("../Pages/Avancement/RH_Avancement_Timeline"));
const RH_Discipline_Liste = lazy(() => import("../Pages/Discipline/RH_Discipline_Liste"));
const RH_Discipline = lazy(() => import("../Pages/Discipline/RH_Discipline"));
const DiverseEditions = lazy(() => import("../Pages/Editions/DiverseEditions"));
const Demande_Doc_Administratif_Liste = lazy(() => import("../Pages/Demande_Doc_Administratif/Demande_Doc_Administratif_Liste"));
const Demande_Doc_Administratif = lazy(() => import("../Pages/Demande_Doc_Administratif/Demande_Doc_Administratif"));
const RH_Declaration_AT = lazy(() => import("../Pages/Accident_Travail/RH_Declaration_AT"));
const RH_Declaration_AT_Liste = lazy(() => import("../Pages/Accident_Travail/RH_Declaration_AT_Liste"));
const Dashboard = lazy(() => import("../Pages/Dashboard/Dashboard"));
const Communication_Blogs_Liste = lazy(() => import("../Pages/Communication/Communication_Blogs_Liste"));
const Communication_Blog = lazy(() => import("../Pages/Communication/Communication_Blog"));
const Outillage_Mouvement_Liste = lazy(() => import("../Pages/Outillage/Outillage_Mouvement_Liste"));
const Outillage_Mouvement = lazy(() => import("../Pages/Outillage/Outillage_Mouvement"));
const DynamicPage = lazy(() => import("../Pages/Dynamic/DynamicPage"));
const DynamicPage_Liste = lazy(() => import("../Pages/Dynamic/DynamicPage_Liste"));
const PortalQuery = lazy(() => import("../Pages/Requete/PortalQuery"));

const Ecran = ({ style }: { style?: React.CSSProperties }) => {
  const { tbnMenu, settbnMenu, showSignature, signatureProps, signatureVersion } =
    useContext(cntX);
  const { ecran } = useParams<{ ecran: string }>();
  const [currentEcran, setEcran] = useState<React.ReactNode>();
  // Ref préservée lors des reveal Suspense/StrictMode : permet de ne vider
  // le menu flottant que lors d'un VRAI changement d'écran, et non quand
  // cet effet se rejoue après celui de la page (qui vient de poser ses boutons).
  const ecranRef = useRef<string | undefined>(undefined);

  useEffect(() => {
    if (ecranRef.current !== ecran) {
      settbnMenu([]);
    }
    ecranRef.current = ecran;
    // Garde de route par profil (pages standards référencées dans
    // Controle_Menu_Portail) : une page retirée au profil n'est pas affichée,
    // même saisie directement dans l'URL. Hors référentiel (documents,
    // pages dynamiques...) : libre côté client, les endpoints restent gardés
    // côté serveur (gardePage).
    if (ecran && !estPageAutorisee(ecran)) {
      setEcran(
        <div
          style={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            height: "100%",
            color: "var(--title-color)",
            fontSize: "1.1em",
            padding: "2em",
            textAlign: "center",
          }}
        >
          Vous n'êtes pas autorisé à accéder à cette page.
        </div>
      );
      return;
    }
    // Pages dynamiques du module SP_ (Designer) : SPPL_<Cod_Page> = liste,
    // SPP_<Cod_Page> = document. Pages-requêtes du requêteur (Param_Query
    // exposées) : SPQ_<Cod_Query> = consultation directe. Interprétées depuis
    // les métadonnées publiées.
    if (ecran?.startsWith("SPPL_")) {
      setEcran(<DynamicPage_Liste codPage={ecran.substring(5)} />);
      return;
    }
    if (ecran?.startsWith("SPQ_")) {
      setEcran(<PortalQuery codQuery={ecran.substring(4)} />);
      return;
    }
    if (ecran?.startsWith("SPP_")) {
      setEcran(<DynamicPage codPage={ecran.substring(4)} />);
      return;
    }
    switch (ecran) {
      case "RH_Agent":
        setEcran(<RH_Agent />);
        break;
      case "Note_Frais_Liste":
        setEcran(<Note_Frais_Liste />);
        break;
      case "Note_Frais":
        setEcran(<Note_Frais />);
        break;
      case "RH_Demande_Avance":
        setEcran(<Demande_Avance />);
        break;
      case "RH_Demande_Avance_Liste":
        setEcran(<Demande_Avance_Liste />);
        break;
      case "RH_Demande_Pret":
        setEcran(<Demande_Pret />);
        break;
      case "RH_Demande_Pret_Liste":
        setEcran(<Demande_Pret_Liste />);
        break;

      case "Parapheur":
        setEcran(<Parapheur />);
        break;
      case "RH_Bulletin_Liste":
        setEcran(<RH_Bulletin_Liste />);
        break;
      case "RH_Dossier_Maladie":
        setEcran(<RH_Dossier_Maladie />);
        break;
      case "RH_Dossier_Maladie_Liste":
        setEcran(<RH_Dossier_Maladie_Liste />);
        break;
      case "RH_Demande_Conge":
        setEcran(<RH_Demande_Conge />);
        break;
      case "RH_Demande_Conge_Liste":
        setEcran(<RH_Demande_Conge_Liste />);
        break;
      case "RH_Conge_Planning":
        setEcran(<RH_Conge_Planning />);
        break;
      case "Evaluation_Liste":
        setEcran(<Evaluation_Liste />);
        break;
      case "Evaluation":
        setEcran(<Evaluation />);
        break;
      case "Formation_Evaluation":
        setEcran(<Formation_Evaluation />);
        break;
      case "Formation_Evaluation_Liste":
        setEcran(<Formation_Evaluation_Liste />);
        break;
      case "Formation":
        setEcran(<Formation />);
        break;
      case "Formation_Liste":
        setEcran(<Formation_Liste />);
        break;
      case "Org_Organigramme":
        setEcran(<Organigramme />);
        break;
      case "Org_Poste":
        setEcran(<Org_Poste />);
        break;
      case "Recrutement_Demande":
        setEcran(<Recrutement_Demande />);
        break;
      case "Recrutement_Demande_Liste":
        setEcran(<Recrutement_Demande_Liste />);
        break;
      case "RH_Avancement_Timeline":
        setEcran(<RH_Avancement_Timeline />);
        break;
      case "RH_Discipline_Liste":
        setEcran(<RH_Discipline_Liste />);
        break;
      case "RH_Discipline":
        setEcran(<RH_Discipline />);
        break;
      case "DiverseEditions":
        setEcran(<DiverseEditions />);
        break;
      case "Demande_Doc_Administratif_Liste":
        setEcran(<Demande_Doc_Administratif_Liste />);
        break;
      case "Demande_Doc_Administratif":
        setEcran(<Demande_Doc_Administratif />);
        break;
      case "RH_Declaration_AT":
        setEcran(<RH_Declaration_AT />);
        break;
      case "RH_Declaration_AT_Liste":
        setEcran(<RH_Declaration_AT_Liste />);
        break;
      case "Dashboard":
        setEcran(<Dashboard />);
        break;
      case "Communication_Blogs_Liste":
        setEcran(<Communication_Blogs_Liste />);
        break;
      case "Communication_Blog":
        setEcran(<Communication_Blog />);
        break;
      case "Outillage_Mouvement_Liste":
        setEcran(<Outillage_Mouvement_Liste />);
        break;
      case "Outillage_Mouvement":
        setEcran(<Outillage_Mouvement />);
        break;
      default:
        setEcran(
          <div
            style={{
              height: "100dvh",
              width: "100dvw",
              position: "fixed",
              top: 0,
              left: 0,
              zIndex: 50,
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              backgroundColor: "var(--bg-home)",
            }}
          >
            <img
              src={`${import.meta.env.BASE_URL}logo.png`}
              alt="Rh-P"
              style={{ maxWidth: "50vw", height: "100%", objectFit: "contain" }}
            />
          </div>
        );
        break;
    }
  }, [ecran]);

  return (
    <div className="ecran" style={style}>
      {/* key=signatureVersion : après une signature, l'écran est re-monté
          pour recharger le document (libellé Signé / Rejeté à jour) */}
      <Fragment key={signatureVersion}>{currentEcran}</Fragment>
      <div className="Separateur" />
      {tbnMenu.length > 0 && <FloatMenu btnMenus={tbnMenu} />}
      {showSignature && <Signature {...signatureProps} />}
    </div>
  );
};

export default Ecran;
