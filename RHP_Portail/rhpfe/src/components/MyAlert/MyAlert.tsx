import { Alert, AlertTitle, Collapse, IconButton } from "@mui/material";
import CloseIcon from "@mui/icons-material/Close";
import { useContext, useEffect } from "react";
import { TAlert } from "../../types";
import { parentCntX } from "../../Context/GlobalContext";
import "./myAlert.scss";
import {
  CheckCircleOutlined,
  ErrorOutline,
  InfoOutlined,
  WarningAmberOutlined,
} from "@mui/icons-material";
const MyAlert = ({ titre, msg, typMsg = "info", timeOut = -1 }: TAlert) => {
  const { showAlert, setShowAlert } = useContext(parentCntX);
  useEffect(() => {
    if (showAlert) {
      setTimeout(() => setShowAlert(false), 3000);
    }
    // return () => setShowAlert(false);
  }, [showAlert]);
  return (
    <div className={`myAlert ${typMsg} ${showAlert ? "show" : "hide"}`}>
      {titre && (
        <h4
          style={{
            marginBottom: "1em",
            display: "flex",
            alignItems: "center",
            gap: "1em",
          }}
        >
          {typMsg === "error" && <ErrorOutline />}
          {typMsg === "info" && <InfoOutlined />}
          {typMsg === "warning" && <WarningAmberOutlined />}
          {typMsg === "success" && <CheckCircleOutlined />}
          {titre}
        </h4>
      )}
      <div>{msg}</div>
      <IconButton
        aria-label="close"
        color="inherit"
        size="small"
        sx={{
          position: "absolute",
          right: "5px",
          top: "5px",
          marginLeft: "1em",
        }}
        onClick={() => {
          setShowAlert(false);
        }}
      >
        <CloseIcon fontSize="inherit" />
      </IconButton>
    </div>
  );
};

export default MyAlert;
