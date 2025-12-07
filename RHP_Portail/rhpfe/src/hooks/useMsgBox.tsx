import { useCallback, useContext, useEffect, useState } from "react";
import { TMsgBox, TMsgBoxResult } from "../types";
import { cntX } from "../Menu/MenuMain";
import { parentCntX } from "../Context/GlobalContext";

export default function useMsgBox() {
  const { setMsgProps, setShowMsgBox, showMsgBox } = useContext(parentCntX);
  const showModal = useCallback(
    (props: TMsgBox) => {
      return new Promise<TMsgBoxResult>((resolve) => {
        const handleOk = async () => {
          await props.handleOk?.();
          resolve("Ok");
          setShowMsgBox(false);
        };
        const handleCancel = async () => {
          await props.handleCancel?.();
          resolve("Cancel");
          setShowMsgBox(false);
        };
        const handleNo = async () => {
          await props.handleNo?.();
          resolve("No");
          setShowMsgBox(false);
        };
        const handleYes = async () => {
          await props.handleYes?.();
          resolve("Yes");
          setShowMsgBox(false);
        };
        setMsgProps({
          ...props,
          handleOk,
          handleCancel,
          handleNo,
          handleYes,
        });
        setShowMsgBox(true);
      });
    },
    [setMsgProps, setShowMsgBox]
  );
  return showModal;
}
