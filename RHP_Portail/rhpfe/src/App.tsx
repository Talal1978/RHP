import React, {
  Suspense,
  lazy,
  useMemo,
  useState,
} from "react";
import { BrowserRouter, Routes, Route, useParams } from "react-router-dom";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFnsV3";
import { fr } from "date-fns/locale/fr";
import Loading from "./components/Loading/Loading";
import { TAlert, TMsgBox } from "./types";
import MsgBox from "./components/MsgBox/MsgBox";
import Evaluation from "./Pages/Evaluation/Evaluation";
import { parentCntX } from "./Context/GlobalContext";
import MyAlert from "./components/MyAlert/MyAlert";
import { ThemeProvider, createTheme } from "@mui/material";
import { colorBase } from "./modules/module_general";

// Lazy load your components
const Login = lazy(() =>
  import("./Pages/Login/Login").then((module) => ({ default: module.Login }))
);
const MenuMain = lazy(() =>
  import("./Menu/MenuMain").then((module) => ({ default: module.MenuMain }))
);
const ReportViewer = lazy(() =>
  import("./Report/ReportViewer").then((module) => ({
    default: module.ReportViewer,
  }))
);
const Org_Poste = lazy(() =>
  import("./Pages/Org_Poste/Org_Poste").then((module) => ({
    default: module.default,
  }))
);

function App() {
  /* Theme Management */
  const [themeMode, setThemeMode] = useState<"light" | "dark">(() => {
    const savedTheme = localStorage.getItem("themeMode");
    return (savedTheme as "light" | "dark") || "light";
  });

  const theme = useMemo(() => createTheme({
    palette: {
      mode: themeMode,
    },
    components: {
      MuiChip: {
        styleOverrides: {
          root: ({ theme }) => ({
            fontWeight: "bold",
            ...(theme.palette.mode === "dark" ? {
              color: "#fff",
              borderColor: "rgba(255, 255, 255, 0.5)",
              backgroundColor: "rgba(255, 255, 255, 0.05)",
            } : {
              color: colorBase.colorBase01,
              borderColor: colorBase.colorBase01,
            })
          }),
          outlined: ({ theme }) => ({
            borderColor: theme.palette.mode === "dark" ? "rgba(255, 255, 255, 0.5)" : colorBase.colorBase01,
          })
        }
      }
    }
  }), [themeMode]);

  const [showMsgBox, setShowMsgBox] = useState(false);
  const [msgProps, setMsgProps] = useState<TMsgBox>({ msg: "" });
  const [showAlert, setShowAlert] = useState(false);
  const [alertProps, setAlertProps] = useState<TAlert>({ msg: "" });

  const toggleTheme = () => {
    setThemeMode((prev) => {
      const newMode = prev === "light" ? "dark" : "light";
      localStorage.setItem("themeMode", newMode);
      return newMode;
    });
  };

  useMemo(() => {
    if (themeMode === "dark") {
      document.body.classList.add("dark-mode");
    } else {
      document.body.classList.remove("dark-mode");
    }
  }, [themeMode]);

  const contextValue = useMemo(() => ({
    showMsgBox,
    setShowMsgBox,
    msgProps,
    setMsgProps,
    showAlert,
    setShowAlert,
    alertProps,
    setAlertProps,
    themeMode,
    toggleTheme
  }), [showMsgBox, msgProps, showAlert, alertProps, themeMode]);

  return (
    <parentCntX.Provider
      value={contextValue}
    >
      <ThemeProvider theme={theme}>
        <LocalizationProvider dateAdapter={AdapterDateFns} adapterLocale={fr}>
          <BrowserRouter>
            <Suspense fallback={<Loading />}>
              <Routes>
                <Route path="/" element={<Login />} />
                <Route path="/test" element={<Evaluation />} />
                <Route
                  path="/myspace/:ecran/:titre/:num?"
                  element={<MenuMain />}
                />
                <Route path="/myspace" element={<MenuMain />} />
                <Route path="viewer/:pdfURL?" element={<ReportViewer />} />
                <Route path="users/:id" element={<Login />} />
              </Routes>
            </Suspense>
          </BrowserRouter>
        </LocalizationProvider>
      </ThemeProvider>
      <MsgBox {...msgProps} />
      <MyAlert {...alertProps} />
    </parentCntX.Provider>
  );
}

export default App;
