import { lazy, useContext, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { cntX } from "./MenuMain";
import { FloatMenu } from "../components/FloatMenu/FloatMenu";
import Signature from "../Pages/Workflow/Signature";
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
const RH_Demande_Conge = lazy(() => import("../Pages/Conges/RH_Demande_Conge"));
const Ecran = ({ style }: { style?: React.CSSProperties }) => {
  const { tbnMenu, settbnMenu, showSignature, signatureProps } =
    useContext(cntX);
  const { ecran } = useParams<{ ecran: string }>();
  const [currentEcran, setEcran] = useState<React.ReactNode>();

  useEffect(() => {
    settbnMenu([]);
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
      case "Demande_Avance":
        setEcran(<Demande_Avance />);
        break;
      case "RH_Demande_Avance_Liste":
        setEcran(<Demande_Avance_Liste />);
        break;
      case "Demande_Pret":
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
      case "Evaluation_Liste":
        setEcran(<Evaluation_Liste />);
        break;
      case "Evaluation":
        setEcran(<Evaluation />);
        break;
      default:
        setEcran(
          <div
            style={{
              height: "80dvh",
              width: "100dvw",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              backgroundColor: "var(--bg-home)",
            }}
          >
            <img
              src={`${process.env.PUBLIC_URL}/logo.png`}
              alt="Rh-P"
              style={{ maxWidth: "50vw" }}
            />
          </div>
        );
        break;
    }
  }, [ecran]);

  return (
    <div className="ecran" style={style}>
      <br />
      {currentEcran}
      <div className="Separateur" />
      {tbnMenu.length > 0 && <FloatMenu btnMenus={tbnMenu} />}
      {showSignature && <Signature {...signatureProps} />}
    </div>
  );
};

export default Ecran;
