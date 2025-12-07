import { useContext } from "react";
import { TAlert } from "../types";
import { parentCntX } from "../Context/GlobalContext";

const useAlert = () => {
  const { setShowAlert, setAlertProps } = useContext(parentCntX);
  return (props: TAlert) => {
    setAlertProps({ ...props });
    setShowAlert(true);
  };
};

export default useAlert;
