import React, { useContext } from "react";
import { parentCntX } from "../../Context/GlobalContext";
import { Sun, Moon } from "lucide-react";

export default function ThemeToggle() {
    const { themeMode, toggleTheme } = useContext(parentCntX);

    return (
        <button
            onClick={toggleTheme}
            className="btn-theme-toggle"
            style={{
                background: "transparent",
                border: "none",
                cursor: "pointer",
                display: "flex",
                alignItems: "center",
                justifyContent: "center",
                padding: "0.5rem",
                color: "inherit",
            }}
            title={`Switch to ${themeMode === "light" ? "Dark" : "Light"} Mode`}
        >
            {themeMode === "light" ? (
                <Sun size={24} color="#f39c12" />
            ) : (
                <Moon size={24} color="#f1c40f" />
            )}
        </button>
    );
}
