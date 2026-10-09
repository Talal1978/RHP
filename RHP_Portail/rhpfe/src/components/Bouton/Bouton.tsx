import { Button, ButtonProps } from "@mui/material";
import { colorBase } from "../../modules/module_general";

interface myProps extends Omit<ButtonProps, "sx"> {
  label: string;
  iconOnly?: boolean;
  sx?: any;
  disabled?: boolean;
}

/** Accent danger du thème : orange colorBase03 (#f05a0a) — jamais la variable
 *  CSS --color-base-03 (#dae7ec, fond pâle des chips, illisible en bouton :
 *  texte blanc sur fond presque blanc = aspect « désactivé »). */
const COULEUR_DANGER = colorBase.colorBase03;

const Bouton = ({
  label,
  iconOnly = false,
  sx = {},
  disabled = false,
  ...props
}: myProps) => {
  return (
    <Button
      disabled={disabled}
      {...props}
      sx={{
        ...sx,
        minWidth: !iconOnly ? "64px" : "0",
        width: !iconOnly ? "auto" : "3.5em",
        height: !iconOnly ? "auto" : "3.5em",
        color:
          props.variant === "outlined"
            ? props.color === "error"
              ? COULEUR_DANGER
              : "var(--color-base-01)"
            : "#ffffff", // Keep white text for filled buttons

        border: `3px solid ${disabled
          ? "gray"
          : props.color === "error"
            ? COULEUR_DANGER
            : "var(--color-base-01)"
          }`,
        fontWeight: "bold",
        bgcolor:
          props.variant === "outlined"
            ? "transparent" // "var(--bg-color-base-01)" causing white box? Use transparent for outlined.
            : props.color === "error"
              ? COULEUR_DANGER
              : "var(--color-base-01)",
        padding: { xs: !iconOnly ? "0.2em" : "0em" },
        "& .MuiButton-startIcon .MuiSvgIcon-root, & .MuiButton-endIcon .MuiSvgIcon-root, & .MuiSvgIcon-root": {
          width: iconOnly ? "1.8em" : "1.3em",
          height: iconOnly ? "1.8em" : "1.3em",
          color: "inherit !important",
          fill: "currentColor",
        },
        "& span": { padding: !iconOnly ? "3px" : "0px" },
        "& .MuiButton-startIcon": {
          marginRight: !iconOnly ? "8px" : "0",
          marginLeft: !iconOnly ? "-4px" : "0",
        },
        "&:hover": {
          bgcolor:
            props.variant === "outlined"
              ? "var(--bg-color-base-01)"
              : props.color === "error"
                ? COULEUR_DANGER
                : "var(--color-base-02)",
          border: `3px solid ${props.color === "error"
            ? COULEUR_DANGER
            : "var(--color-base-02)"
            }`,
          color:
            props.variant === "outlined"
              ? props.color === "error"
                ? COULEUR_DANGER
                : "var(--color-base-02)"
              : "#ffffff",
        },
      }}
    >
      {!iconOnly ? label : ""}
    </Button>
  );
};
export default Bouton;
