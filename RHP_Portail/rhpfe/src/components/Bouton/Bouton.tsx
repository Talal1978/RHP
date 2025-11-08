import { Button, ButtonProps } from "@mui/material";
import { colorBase } from "../../modules/module_general";

interface myProps extends Omit<ButtonProps, "sx"> {
  label: string;
  iconOnly?: boolean;
  sx?: any;
  disabled?: boolean;
}

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
        width: !iconOnly ? "auto" || sx.width : "3.5em",
        height: !iconOnly ? "auto" || sx.height : "3.5em",
        color:
          props.variant === "outlined"
            ? props.color === "error"
              ? colorBase.colorBase03
              : colorBase.colorBase01
            : "#ffffff",

        border: `3px solid ${
          disabled
            ? "gray"
            : props.color === "error"
            ? colorBase.colorBase03
            : colorBase.colorBase01
        }`,
        fontWeight: "bold",
        bgcolor:
          props.variant === "outlined"
            ? colorBase.bgColorBase01
            : props.color === "error"
            ? colorBase.colorBase03
            : colorBase.colorBase01,
        padding: { xs: !iconOnly ? "0.2em" : "0em" },
        "& svg": {
          width: iconOnly ? "1.8em" : "1.3em",
          height: iconOnly ? "1.8em" : "1.3em",
        },
        "& span": { padding: !iconOnly ? "3px" : "0px" },
        "& .css-1d6wzja-MuiButton-startIcon": {
          marginRight: !iconOnly ? "8px" : "0",
          marginLeft: !iconOnly ? "-4px" : "0",
        },
        "&:hover": {
          bgcolor:
            props.variant === "outlined"
              ? colorBase.bgColorBase01
              : props.color === "error"
              ? colorBase.colorBase03
              : colorBase.colorBase02,
          border: `3px solid ${
            props.color === "error"
              ? colorBase.colorBase03
              : colorBase.colorBase02
          }`,
          color:
            props.variant === "outlined" ? colorBase.colorBase02 : "#ffffff",
        },
      }}
    >
      {!iconOnly ? label : ""}
    </Button>
  );
};
export default Bouton;
