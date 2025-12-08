import { Dispatch, SetStateAction, createContext } from "react";
import { TAlert, TMsgBox } from "../types";

export type ThemeMode = 'light' | 'dark';

export const parentCntX = createContext<{
    msgProps: TMsgBox;
    setMsgProps: Dispatch<SetStateAction<TMsgBox>>;
    showMsgBox: boolean;
    setShowMsgBox: Dispatch<SetStateAction<boolean>>;
    alertProps: TAlert;
    setAlertProps: Dispatch<SetStateAction<TAlert>>;
    showAlert: boolean;
    setShowAlert: Dispatch<SetStateAction<boolean>>;
    themeMode: ThemeMode;
    toggleTheme: () => void;
}>({
    msgProps: { msg: "", open: false } as TMsgBox,
    setMsgProps: () => { },
    showMsgBox: false,
    setShowMsgBox: () => { },
    alertProps: { msg: "" },
    setAlertProps: () => { },
    showAlert: false,
    setShowAlert: () => { },
    themeMode: 'light',
    toggleTheme: () => { },
});
