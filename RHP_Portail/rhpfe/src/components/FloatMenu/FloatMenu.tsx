import { Widgets } from "@mui/icons-material";
import { Fab, ListItemIcon, Menu, MenuItem } from "@mui/material";
import React from "react";
import "./floatMenu.scss";
import { TMenuBtn } from "../../types";
export const FloatMenu = ({ btnMenus }: { btnMenus: TMenuBtn[] }) => {
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
  const open = Boolean(anchorEl);
  const handleClose = () => {
    setAnchorEl(null);
  };
  return (
    <div className="floatMenu">
      <Fab
        aria-label="btns"
        className="btns"
        onClick={(event: React.MouseEvent<HTMLElement>) => {
          setAnchorEl(event.currentTarget);
        }}
      >
        <Widgets />
      </Fab>
      <Menu
        anchorEl={anchorEl}
        id="account-menu"
        open={open}
        onClose={handleClose}
        onClick={handleClose}
        PaperProps={{
          elevation: 0,
          sx: {
            overflow: "visible",
            filter: "drop-shadow(0px 2px 8px rgba(0,0,0,0.32))",
            mt: -11,
            ml: -1,
            bgcolor: "var(--bg-input)",
            color: "var(--fore-color-base-01)",

            "&::after": {
              content: '""',
              display: "block",
              position: "absolute",
              top: "100%",
              right: 14,
              width: 10,
              height: 10,
              bgcolor: "var(--bg-input)",
              transform: "translateY(-50%) rotate(45deg)",
              zIndex: -1,
            },
          },
        }}
        transformOrigin={{ horizontal: "right", vertical: "top" }}
        anchorOrigin={{ horizontal: "right", vertical: "bottom" }}
      >
        {btnMenus
          .filter((btn) => btn?.visible !== "none")
          .map((btn, ind) => (
            <MenuItem onClick={btn.action} key={ind} disabled={btn.disabled} sx={{ color: btn.color }}>
              <ListItemIcon sx={{ color: btn.color }}>{btn.icon}</ListItemIcon>
              {btn.libelle}
            </MenuItem>
          ))}
      </Menu>
    </div>
  );
};
