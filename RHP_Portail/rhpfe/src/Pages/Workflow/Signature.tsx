import {
  Avatar,
  Divider,
  List,
  ListItem,
  ListItemAvatar,
  Typography,
} from "@mui/material";
import React, { useCallback, useContext, useEffect, useState } from "react";
import { ObjetGenerique, TSignature } from "../../types";
import useAxiosGet from "../../hooks/useAxiosGet";
import {
  CheckCircleOutlined,
  ErrorOutline,
  KeyboardDoubleArrowDownOutlined,
} from "@mui/icons-material";
import { cntX } from "../../Menu/MenuMain";
import "./signature.scss";
import TextBox from "../../components/TextBox/TextBox";
import { formatDateFR } from "../../modules/module_formats";
import { Agent } from "../../modules/module_general";
import useAxiosPost from "../../hooks/useAxiosPost";

const Signature = (props: TSignature) => {
  const { setShowSignature } = useContext(cntX);
  const [signataires, setSignataires] = useState<ObjetGenerique[]>([]);
  const myAxios = useAxiosGet();
  useEffect(() => {
    myAxios({
      apiStr: "get_signataires",
      bdy: {
        Typ_Document: props.typ_document,
        Valeur_Index: props.valeur_index,
      },
    })
      .then((dt) => {
        if (dt.data.result) {
          setSignataires(dt.data.data);
        } else {
          setSignataires([]);
        }
      })
      .catch((err) => {
        console.log(err);
        setSignataires([]);
      });
  }, [props.typ_document, props.valeur_index]);
  const fermer = useCallback(
    (e: React.MouseEvent<HTMLDivElement>) => {
      setShowSignature(false);
    },
    [props.typ_document, props.valeur_index]
  );
  const stopPropagation = useCallback(
    (e: React.MouseEvent) => {
      e.stopPropagation();
    },
    [props.typ_document, props.valeur_index]
  );
  return (
    <div onClick={fermer} className="liste_signataires">
      {signataires.length > 0 ? (
        <List
          sx={{
            width: "100%",
            maxWidth: 460,
            bgcolor: "background.paper",
            borderRadius: "5px",
          }}
          onClick={stopPropagation}
        >
          {signataires.map((v, i) => {
            return (
              <React.Fragment key={i}>
                <ListItem alignItems="flex-start" className="signataire">
                  <ListItemAvatar>
                    <Avatar alt={v?.Nom} src={v?.Nom} />
                  </ListItemAvatar>
                  <div className="signature">
                    <React.Fragment>
                      <Typography
                        sx={{ display: "inline", fontWeight: "500" }}
                        component="span"
                        variant="body2"
                        color="#4e4a4a"
                      >
                        {v?.Nom}
                      </Typography>
                      {["RJ", "SG"].includes(v?.Decision) && (
                        <p
                          style={{
                            fontSize: "small",
                            fontStyle: "italic",
                            color: "rgb(146,146,146)",
                          }}
                        >
                          {v?.Commentaire}
                        </p>
                      )}
                    </React.Fragment>
                    {v?.Decision === "" &&
                    (String(v?.Signataire || "")?.toUpperCase() ===
                      (Agent?.Matricule || "").toUpperCase() ||
                      String(v?.Signataire || "")?.toUpperCase() ===
                        (Agent?.Login || "").toUpperCase()) ? (
                      <Btn_Signataires RowId={v?.RowId} />
                    ) : (
                      <Decision_Signataires v={v} />
                    )}
                  </div>
                </ListItem>
                {signataires.length - 1 > i && (
                  <>
                    <Divider
                      variant="inset"
                      component="li"
                      style={{ position: "relative", width: "80%" }}
                    >
                      <div className="signature_ordre">
                        {String(v?.Operande_Signature || "").toUpperCase() ===
                        "OU" ? (
                          "Ou"
                        ) : v?.Dans_Ordre ? (
                          <KeyboardDoubleArrowDownOutlined />
                        ) : (
                          "&"
                        )}
                      </div>
                    </Divider>
                  </>
                )}
              </React.Fragment>
            );
          })}
        </List>
      ) : (
        <div
          style={{
            width: "100%",
            height: "100%",
            maxHeight: "20vh",
            maxWidth: "60vw",
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            fontSize: "1.5em",
            backgroundColor: "white",
            padding: "1em",
          }}
        >
          Aucune règle de signature n'est configurée pour ce cas de type de
          document. {props.typ_document}
        </div>
      )}
    </div>
  );
};

export default Signature;

const Decision_Signataires = ({ v }: ObjetGenerique) => {
  return (
    <div className="decision_signatures">
      <div className={`decision`}>
        {v?.Decision === "SG" && <p className="accord">Signé</p>}
        {v?.Decision === "RJ" && <p className="rejet">Rejeté</p>}
        <span>{formatDateFR(v?.Dat_Signature, true)}</span>
      </div>
    </div>
  );
};
const Btn_Signataires = ({ RowId }: { RowId: number }) => {
  const { setShowSignature } = useContext(cntX);
  const myAxios = useAxiosPost();
  const [Commentaire, setCommentaire] = useState("");
  const decision = useCallback(
    (Decision: string) => {
      myAxios("signer", { RowId, Commentaire, Decision }).then((dt) => {
        if (dt?.data) setShowSignature(false);
      });
    },
    [RowId, Commentaire]
  );
  return (
    <div className="btn_signatures">
      <div className="btn_signature accord">
        <CheckCircleOutlined />
        <span onClick={() => decision("SG")}>Signer</span>
      </div>
      <div className="btn_signature rejet">
        <ErrorOutline />
        <span onClick={() => decision("RJ")}>Rejeter</span>
      </div>
      <TextBox
        className="commentaire"
        nomControle="Commentaire"
        label="Commentaire"
        autoComplete="off"
        valeur={Commentaire}
        onchange={(a, b) => setCommentaire(b)}
      />
    </div>
  );
};
