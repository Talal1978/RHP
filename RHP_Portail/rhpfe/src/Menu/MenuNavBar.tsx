import { useState, useEffect, useContext } from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import Badge from "@mui/material/Badge";
import MenuIcon from "@mui/icons-material/Menu";
import CloseIcon from "@mui/icons-material/Close";
import { PersonOutlineOutlined, Notifications } from "@mui/icons-material";
import { cntX } from "./MenuMain";
import { Avatar, Typography } from "@mui/material";
import MenuProfile from "./MenuProfile";
import { useParams } from "react-router-dom";
import "./mainmenu.scss";
import { socket } from "../socket";

export default function MenuNavBar() {
  const [nbSignature, setNbsignature] = useState(0);
  const { isOpen, setIsOpen } = useContext(cntX);
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const { titre } = useParams();
  useEffect(() => {
    socket.on("nbSignature", (nb: any) => {
      setNbsignature(nb);
    });
  }, []);
  return (
    <div className="menuNavBar">
      <AppBar position="static">
        <Toolbar id="entete" sx={{ minHeight: { xs: 0, sm: 0 } }}>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="open drawer"
            onClick={() => {
              setIsOpen((prevOpen: boolean) => {
                return !prevOpen;
              });
            }}
          >
            {isOpen ? <CloseIcon /> : <MenuIcon />}
          </IconButton>
          <Typography>{titre}</Typography>
          <Box sx={{ flexGrow: 1 }} />

          <Box sx={{ md: "flex" }}>
            <IconButton
              size="large"
              color="inherit"
              onClick={(event: React.MouseEvent<HTMLElement>) => {
                setAnchorEl(event.currentTarget);
              }}
            >
              {nbSignature > 0 ? (
                <Badge
                  badgeContent={nbSignature}
                  color="error"
                  sx={{ fontSize: "5em" }}
                >
                  <PersonOutlineOutlined />
                </Badge>
              ) : (
                <PersonOutlineOutlined />
              )}
            </IconButton>
            <MenuProfile
              anchorEl={anchorEl}
              setAnchorEl={setAnchorEl}
              nbSignature={nbSignature}
            />
          </Box>
          <Avatar
            alt="Remy Sharp"
            src={`${process.env.PUBLIC_URL}/logoRHPBlanc.png`}
            sx={{ ml: 2 }}
          />
        </Toolbar>
      </AppBar>
    </div>
  );
}
