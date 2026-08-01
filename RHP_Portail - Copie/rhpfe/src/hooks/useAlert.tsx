import { useContext, useCallback } from "react";
import { TAlert } from "../types";
import { parentCntX } from "../Context/GlobalContext";

const useAlert = () => {
  const { setShowAlert, setAlertProps } = useContext(parentCntX);
  const showAlertFunc = useCallback(
    (props: TAlert) => {
      setAlertProps({ ...props });
      setShowAlert(true);
    },
    [setAlertProps, setShowAlert]
  );
  return showAlertFunc;
};

export default useAlert;
