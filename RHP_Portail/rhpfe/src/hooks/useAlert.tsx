import { useContext } from "react";
import { TAlert } from "../types";
import { cntX } from "../Menu/MenuMain";

const useAlert = () => {
  const { setShowAlert, setAlertProps } = useContext(cntX);
  return (props: TAlert) => {
    setAlertProps({ ...props });
    setShowAlert(true);
  };
};

export default useAlert;
