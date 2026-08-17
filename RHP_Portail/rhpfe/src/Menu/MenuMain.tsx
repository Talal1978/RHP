import { Dispatch, SetStateAction, createContext, useCallback, useEffect, useMemo, useState } from "react";
import MenuNavBar from "./MenuNavBar";
import MenuSideBar from "./MenuSideBar";
import "./mainmenu.scss";
import Ecran from "./Ecran";
import { TAlert, TGed, TMenuBtn, TMsgBox, TSignature } from "../types";
import { Box, useMediaQuery, useTheme } from "@mui/material";
import Ged from "../Pages/GED/Ged";
import Loading from "../components/Loading/Loading";
import MyAlert from "../components/MyAlert/MyAlert";
import useAxiosGet from "../hooks/useAxiosGet";
import { rubriques, setRubriques } from "../modules/module_rubriques";
import {
  filtrerMenusStatiques,
  fusionnerMenusDynamiques,
} from "../modules/module_menus";

export const cntX = createContext<{
  setShowLoading: Dispatch<SetStateAction<boolean>>;
  setShowGED: Dispatch<SetStateAction<boolean>>;
  GEDprops: TGed;
  setGEDprops: Dispatch<SetStateAction<TGed>>;
  isOpen: boolean;
  setIsOpen: Dispatch<SetStateAction<boolean>>;
  tbnMenu: TMenuBtn[];
  settbnMenu: Dispatch<SetStateAction<TMenuBtn[]>>;
  setAlertProps: Dispatch<SetStateAction<TAlert>>;
  setSignatureProps: Dispatch<SetStateAction<TSignature>>;
  signatureProps: TSignature;
  showAlert: boolean;
  showSignature: boolean;
  setShowAlert: Dispatch<SetStateAction<boolean>>;
  setShowSignature: Dispatch<SetStateAction<boolean>>;
  isSmall: boolean;
  isXs: boolean;
  isSm: boolean;
  isMd: boolean;
  isLg: boolean;
  isXl: boolean;
  signatureVersion: number;
  bumpSignatureVersion: () => void;
}>({
  setShowLoading: () => {},
  setShowGED: () => {},
  GEDprops: { name_ecran: "", valeur_index: "" },
  setGEDprops: () => {},
  isOpen: false,
  setIsOpen: () => {},
  tbnMenu: [],
  settbnMenu: () => {},
  signatureProps: { typ_document: "", valeur_index: "" },
  setAlertProps: () => {},
  setSignatureProps: () => {},
  setShowSignature: () => {},
  showAlert: false,
  showSignature: false,
  setShowAlert: () => {},
  isSmall: false,
  isXs: false,
  isSm: false,
  isLg: false,
  isMd: false,
  isXl: false,
  signatureVersion: 0,
  bumpSignatureVersion: () => {},
});

export const MenuMain = () => {
  const [isOpen, setIsOpen] = useState(false);
  const [showSignature, setShowSignature] = useState(false);
  const [showLoading, setShowLoading] = useState(false);
  const [showAlert, setShowAlert] = useState(false);
  const [tbnMenu, settbnMenu] = useState<TMenuBtn[]>([]);
  const [alertProps, setAlertProps] = useState<TAlert>({ msg: "" });
  const [signatureProps, setSignatureProps] = useState<TSignature>({
    typ_document: "",
    valeur_index: "",
  });
  const [showGED, setShowGED] = useState<boolean>(false);
  const [GEDprops, setGEDprops] = useState<TGed>({
    name_ecran: "",
    valeur_index: "",
  });

  // Les rubriques (findRubrique/listRubriques) ne sont chargées qu'au login.
  // Après une restauration de session (localStorage), elles sont vides :
  // il faut les recharger avant d'afficher l'écran (libellés des menus, ComboBox...).
  const myAxiosGet = useAxiosGet();
  const [rubriquesReady, setRubriquesReady] = useState(rubriques.length > 0);
  // Incrémenté après chargement des menus dynamiques (module SP_) : force le
  // re-rendu de la sidebar (controleMenus est un tableau module-level muable).
  const [menusDynVersion, setMenusDynVersion] = useState(0);
  useEffect(() => {
    // Pages dynamiques publiées (module SP_) : fusionnées au menu latéral
    // (section et rang déclarés dans le Designer Desktop). Les pages
    // STANDARDS (menus.json) sont filtrées selon les droits du profil
    // (pagesStandards / pagesControlees renvoyés par le même endpoint).
    myAxiosGet({ apiStr: "sp_menu_portail" })
      .then((r) => {
        if (r?.data?.result && Array.isArray(r.data.data)) {
          fusionnerMenusDynamiques(r.data.data);
          filtrerMenusStatiques(r.data.pagesStandards, r.data.pagesControlees);
          setMenusDynVersion((v) => v + 1);
        }
      })
      .catch(() => {});
    if (rubriques.length > 0) return;
    myAxiosGet({ apiStr: "list_rubriques" })
      .then((r) => {
        if (r?.data) setRubriques(r.data);
      })
      .catch(() => {})
      .finally(() => setRubriquesReady(true));
  }, [myAxiosGet]);
  void menusDynVersion;

  // Incrémenté après chaque signature effectuée depuis le panneau de signature :
  // Ecran re-monte la page courante pour recharger le document (statut Signé/Rejeté).
  const [signatureVersion, setSignatureVersion] = useState(0);
  const bumpSignatureVersion = useCallback(
    () => setSignatureVersion((v) => v + 1),
    []
  );

  const theme = useTheme();
  const isSmall = useMediaQuery("(max-width:1000px)");
  const isXs = useMediaQuery(theme.breakpoints.down("sm"));
  const isSm = useMediaQuery(theme.breakpoints.between("sm", "md"));
  const isMd = useMediaQuery(theme.breakpoints.between("md", "lg"));
  const isLg = useMediaQuery(theme.breakpoints.between("lg", "xl"));
  const isXl = useMediaQuery(theme.breakpoints.up("xl"));

  const contextValue = useMemo(
    () => ({
      setShowLoading,
      setShowGED,
      GEDprops,
      setGEDprops,
      setSignatureProps,
      isOpen,
      setIsOpen,
      tbnMenu,
      settbnMenu,
      showSignature,
      setShowSignature,
      signatureProps,
      showAlert,
      setShowAlert,
      setAlertProps,
      isSmall,
      isLg,
      isSm,
      isXs,
      isMd,
      isXl,
      signatureVersion,
      bumpSignatureVersion,
    }),
    [
      isOpen,
      showSignature,
      showLoading,
      showAlert,
      tbnMenu,
      alertProps,
      signatureProps,
      showGED,
      GEDprops,
      isSmall,
      isXs,
      isSm,
      isMd,
      isLg,
      isXl,
      signatureVersion,
      bumpSignatureVersion,
    ]
  );

  return (
    <cntX.Provider value={contextValue}>
      <Box className="mainMenu" sx={{ fontSize: { xs: "0.7em", sm: "0.8em", md: "1em" } }}>
        <div>
          <MenuNavBar />
        </div>
        <div className="corps">
          {rubriquesReady ? <Ecran /> : <Loading />}
          <MenuSideBar />
        </div>
      </Box>
      <MyAlert {...alertProps} />
      {showGED && <Ged {...GEDprops} />}
      {showLoading && <Loading />}
    </cntX.Provider>
  );
};

export default MenuMain;
