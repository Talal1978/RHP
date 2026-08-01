import React, { Suspense, lazy, useMemo, useState, useEffect } from "react";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFnsV3";
import { fr } from "date-fns/locale/fr";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import Loading from "./components/Loading/Loading";
import { TAlert, TMsgBox } from "./types";
import MsgBox from "./components/MsgBox/MsgBox";
import Evaluation from "./Pages/Evaluation/Evaluation";
import { parentCntX } from "./Context/GlobalContext";
import MyAlert from "./components/MyAlert/MyAlert";
import { ThemeProvider, createTheme } from "@mui/material";
import { colorBase } from "./modules/module_general";
import { AuthProvider } from "./Context/AuthContext";
import ErrorBoundary from "./components/ErrorBoundary";

const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      staleTime: 5 * 60 * 1000,
      retry: 1,
      refetchOnWindowFocus: false,
    },
  },
});

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

function App() {
  const [themeMode, setThemeMode] = useState<"light" | "dark">(() => {
    const savedTheme = localStorage.getItem("themeMode");
    return (savedTheme as "light" | "dark") || "light";
  });

  const theme = useMemo(
    () =>
      createTheme({
        palette: { mode: themeMode },
        components: {
          MuiChip: {
            styleOverrides: {
              root: ({ theme }) => ({
                fontWeight: "bold",
                ...(theme.palette.mode === "dark"
                  ? {
                      color: "#fff",
                      borderColor: "rgba(255, 255, 255, 0.5)",
                      backgroundColor: "rgba(255, 255, 255, 0.05)",
                    }
                  : {
                      color: colorBase.colorBase01,
                      borderColor: colorBase.colorBase01,
                    }),
              }),
              outlined: ({ theme }) => ({
                borderColor:
                  theme.palette.mode === "dark"
                    ? "rgba(255, 255, 255, 0.5)"
                    : colorBase.colorBase01,
              }),
            },
          },
        },
      }),
    [themeMode]
  );

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

  useEffect(() => {
    if (themeMode === "dark") {
      document.body.classList.add("dark-mode");
    } else {
      document.body.classList.remove("dark-mode");
    }
  }, [themeMode]);

  const contextValue = useMemo(
    () => ({
      showMsgBox,
      setShowMsgBox,
      msgProps,
      setMsgProps,
      showAlert,
      setShowAlert,
      alertProps,
      setAlertProps,
      themeMode,
      toggleTheme,
    }),
    [showMsgBox, msgProps, showAlert, alertProps, themeMode]
  );

  return (
    <QueryClientProvider client={queryClient}>
      <AuthProvider>
        <parentCntX.Provider value={contextValue}>
          <ThemeProvider theme={theme}>
            <LocalizationProvider dateAdapter={AdapterDateFns} adapterLocale={fr}>
              <BrowserRouter>
                <ErrorBoundary>
                  <Suspense fallback={<Loading />}>
                    <Routes>
                      <Route path="/" element={<Login />} />
                      <Route path="/test" element={<Evaluation />} />
                      <Route path="/myspace/:ecran/:titre/:num?" element={<MenuMain />} />
                      <Route path="/myspace" element={<Navigate to="/myspace/Dashboard/Tableau de bord" replace />} />
                      <Route path="viewer/:pdfURL?" element={<ReportViewer />} />
                      <Route path="users/:id" element={<Login />} />
                    </Routes>
                  </Suspense>
                </ErrorBoundary>
              </BrowserRouter>
            </LocalizationProvider>
          </ThemeProvider>
          <MsgBox {...msgProps} />
          <MyAlert {...alertProps} />
        </parentCntX.Provider>
      </AuthProvider>
    </QueryClientProvider>
  );
}

export default App;
