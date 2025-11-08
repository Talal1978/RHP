import { Dispatch, SetStateAction, createContext, useState } from "react";
import MenuNavBar from "./MenuNavBar";
import MenuSideBar from "./MenuSideBar";
import "./mainmenu.scss";
import Ecran from "./Ecran";
import { TAlert, TGed, TMenuBtn, TMsgBox, TSignature } from "../types";
import MsgBox from "../components/MsgBox/MsgBox";
import { Box, useMediaQuery, useTheme } from "@mui/material";
import Ged from "../Pages/GED/Ged";
import Loading from "../components/Loading/Loading";
import MyAlert from "../components/MyAlert/MyAlert";
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
  const isSmall = useMediaQuery("(max-width:1000px)");
  const theme = useTheme();
  const isXs = useMediaQuery(theme.breakpoints.down("sm"));
  const isSm = useMediaQuery(theme.breakpoints.between("sm", "md"));
  const isMd = useMediaQuery(theme.breakpoints.between("md", "lg"));
  const isLg = useMediaQuery(theme.breakpoints.between("lg", "xl"));
  const isXl = useMediaQuery(theme.breakpoints.up("xl"));
  return (
    <cntX.Provider
      value={{
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
      }}
    >
      <Box
        className="mainMenu"
        sx={{ fontSize: { xs: "0.7em", sm: "0.8em", md: "1em" } }}
      >
        <div>
          <MenuNavBar />
        </div>
        <div className="corps">
          <Ecran />
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
