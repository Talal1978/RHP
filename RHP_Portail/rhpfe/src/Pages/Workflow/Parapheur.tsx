import React, { useCallback, useContext, useEffect, useState } from "react";
import Grille, {
  TColonne,
  TColonneCollection,
} from "../../components/Grille/Grille";
import { useNavigate } from "react-router-dom";
import useAxiosGet from "../../hooks/useAxiosGet";
import { ObjetGenerique } from "../../types";
import { colorBase } from "../../modules/module_general";
import { Box } from "@mui/material";
import { cntX } from "../../Menu/MenuMain";
import { Loop } from "@mui/icons-material";

const Parapheur = () => {
  const { setShowSignature, setSignatureProps } = useContext(cntX);
  const navigate = useNavigate();
  const myAxios = useAxiosGet();
  const [data, setData] = useState<{
    ds: ObjetGenerique[];
    dsFields: ObjetGenerique;
  }>({ ds: [], dsFields: {} });
  const loadData = useCallback(() => {
    myAxios({ apiStr: "get_parapheur" }).then((dt) => {
      if (dt.data?.result) {
        const colonnes: TColonneCollection = {
          signature: {
            columnName: "signature",
            headerText: "Signature",
            dataType: "nvarhar",
            visible: true,
            typeColonne: "Image",
            sx: {
              textAlign: "center",
              "& img": { width: "1.5em", height: "1.5em" },
            },
          },
          ...dt.data.fields,
        };
        colonnes["Name_Ecran"].visible = false;
        colonnes["Index_Ecran"].visible = false;
        colonnes["Typ_Document"].visible = false;
        colonnes["Type de signature"].visible = false;
        colonnes["Opérande"].visible = false;
        const donnees = dt.data.data.map((dt: ObjetGenerique) => {
          return {
            signature: `${process.env.PUBLIC_URL}/signature.png`,
            ...dt,
          };
        });
        setData({
          ds: donnees,
          dsFields: colonnes,
        });
      } else {
        setData({ ds: [], dsFields: {} });
      }
    });
  }, []);
  useEffect(() => loadData(), []);
  return (
    <Box
      sx={{
        margin: "auto",
        padding: "2em 5px",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        gap: "1em",
        width: {
          xs: "90vw",
          sm: "90vw",
          md: "80vw",
        },
        overflow: "scroll",
        " ::-webkit-scrollbar": {
          display: "none",
        },
        msOverflowStyle: "none",
        scrollbarWidth: "none",
      }}
    >
      <div
        style={{
          width: "100%",
        }}
      >
        <div
          style={{
            display: "flex",
            alignItems: "center",
            cursor: "pointer",
            color: "rgb(146,146,146)",
            gap: "0.5em",
            userSelect: "none",
            width: "fit-content",
          }}
          onClick={loadData}
        >
          <Loop />
          Actualiser
        </div>
      </div>

      <Grille
        colonnesAFiltrer={[1, 2, 5]}
        readonly={true}
        dataSource={data.ds}
        Colonnes={data.dsFields}
        className="laGrille"
        onclick={({ colIndex, rowIndex, value }) => {
          if (rowIndex !== undefined && rowIndex != null && colIndex === 2) {
            navigate(
              `../myspace/${data.ds[rowIndex]["Name_Ecran"]}/${data.ds[rowIndex]["Type de documents"]}/${value}`
            );
            return;
          }
          if (rowIndex !== undefined && rowIndex != null && colIndex === 0) {
            setSignatureProps({
              typ_document: data.ds[rowIndex]["Typ_Document"],
              valeur_index: data.ds[rowIndex]["Référence"],
            });
            setShowSignature(true);
            return;
          }
        }}
        sx={{
          "& .cl0": {
            width: "40px !important",
            cursor: "pointer !important",
            "&:hover": {
              color: colorBase.colorBase02,
              fontStyle: "bold",
              textDecoration: "underline",
            },
          },
          "& .cl1": {
            width: "100px !important",
            cursor: "pointer !important",
            "&:hover": {
              color: colorBase.colorBase02,
              fontStyle: "bold",
              textDecoration: "underline",
            },
          },
        }}
      />
    </Box>
  );
};

export default Parapheur;
