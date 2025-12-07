import { useContext, useEffect } from "react";
import Button from "@mui/material/Button";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";
import { MsgBoxResult, TMsgBox } from "../../types";
import "./msgbox.scss";
import msgbox_error from "./img/msgbox_error.png";
import msgbox_info from "./img/msgbox_info.png";
import msgbox_warning from "./img/msgbox_warning.png";
import msgbox_question from "./img/msgbox_question.png";
import msgbox_stop from "./img/msgbox_stop.png";
import { cntX } from "../../Menu/MenuMain";
import { parentCntX } from "../../Context/GlobalContext";

const msgImg = {
  error: msgbox_error,
  info: msgbox_info,
  warning: msgbox_warning,
  question: msgbox_question,
  stop: msgbox_stop,
};

export default function MsgBox({
  titre = "RH-P : Message",
  msg,
  typMsg = "info",
  typReply = "OkOnly",
  handleOk = async () => { },
  handleCancel = async () => { },
  handleNo = async () => { },
  handleYes = async () => { },
}: TMsgBox) {
  const { showMsgBox, setShowMsgBox } = useContext(parentCntX);
  function handleClose() {
    setShowMsgBox(false);
  }
  return (
    <Dialog
      open={showMsgBox}
      aria-labelledby="alert-dialog-title"
      aria-describedby="alert-dialog-description"
      className="msgbox"
    >
      <DialogTitle id="alert-dialog-description" className="msgboxTitle">
        {titre}
      </DialogTitle>
      <DialogContent>
        <div className="msgboxMessage">
          <div style={{ display: "flex", alignItems: "center" }}>{msg}</div>
          <img src={msgImg[typMsg]} alt="" />
        </div>
      </DialogContent>
      <DialogActions className="msgboxBtns">
        {(typReply === "OkOnly" || typReply === "OKCancel") && (
          <Button
            autoFocus={typReply === "OkOnly"}
            onClick={async () => {
              await handleOk();
              handleClose();
            }}
            className={`reponse ok ${typReply === "OkOnly" ? "autoFocus" : ""}`}
          >
            Ok
          </Button>
        )}
        {typReply === "YesNoCancel" && (
          <Button
            onClick={async () => {
              handleYes();
              handleClose();
            }}
            className="reponse yes"
          >
            Oui
          </Button>
        )}
        {typReply === "YesNoCancel" && (
          <Button
            onClick={() => {
              handleNo();
              handleClose();
            }}
            className="reponse no"
          >
            Non
          </Button>
        )}
        {(typReply === "OKCancel" || typReply === "YesNoCancel") && (
          <Button
            onClick={() => {
              handleCancel();
              handleClose();
            }}
            className="reponse cancel autoFocus"
          >
            Annuler
          </Button>
        )}
      </DialogActions>
    </Dialog>
  );
}
