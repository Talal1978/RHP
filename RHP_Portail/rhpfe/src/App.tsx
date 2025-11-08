import React, {
  Dispatch,
  SetStateAction,
  Suspense,
  createContext,
  lazy,
  useState,
} from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFnsV3";
import { fr } from "date-fns/locale/fr";
import Loading from "./components/Loading/Loading";
import { TMsgBox } from "./types";
import MsgBox from "./components/MsgBox/MsgBox";
export const parentCntX = createContext<{
  msgProps: TMsgBox;
  setMsgProps: Dispatch<SetStateAction<TMsgBox>>;
  showMsgBox: boolean;
  setShowMsgBox: Dispatch<SetStateAction<boolean>>;
}>({
  msgProps: { msg: "", open: false } as TMsgBox,
  setMsgProps: () => {},
  showMsgBox: false,
  setShowMsgBox: () => {},
});
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
  return (
    <parentCntX.Provider
      value={{ showMsgBox, setShowMsgBox, msgProps, setMsgProps }}
    >
      <LocalizationProvider dateAdapter={AdapterDateFns} adapterLocale={fr}>
        <BrowserRouter>
          <Suspense fallback={<Loading />}>
            <Routes>
              <Route path="/" element={<Login />} />
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
    </parentCntX.Provider>
  );
}

export default App;
