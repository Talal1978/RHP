import React, {
  Suspense,
  lazy,
  useMemo,
  useState,
} from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFnsV3";
import { fr } from "date-fns/locale/fr";
import Loading from "./components/Loading/Loading";
import { TAlert, TMsgBox } from "./types";
import MsgBox from "./components/MsgBox/MsgBox";
import Evaluation from "./Pages/Evaluation/Evaluation";
import { parentCntX } from "./Context/GlobalContext";
import MyAlert from "./components/MyAlert/MyAlert";

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

// Define a fallback component for Suspense
function App() {
  const [showMsgBox, setShowMsgBox] = useState(false);
  const [msgProps, setMsgProps] = useState<TMsgBox>({ msg: "" });
  const [showAlert, setShowAlert] = useState(false);
  const [alertProps, setAlertProps] = useState<TAlert>({ msg: "" });

  const contextValue = useMemo(() => ({
    showMsgBox,
    setShowMsgBox,
    msgProps,
    setMsgProps,
    showAlert,
    setShowAlert,
    alertProps,
    setAlertProps
  }), [showMsgBox, msgProps, showAlert, alertProps]);

  return (
    <parentCntX.Provider
      value={contextValue}
    >
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
      <MsgBox {...msgProps} />
      <MyAlert {...alertProps} />
    </parentCntX.Provider>
  );
}

export default App;
