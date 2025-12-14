import { DrawOutlined, HistoryEduOutlined, Logout, LockResetOutlined } from "@mui/icons-material";
import { Badge, ListItemIcon, Menu, MenuItem } from "@mui/material";
import { useCallback, useContext, useState, useMemo } from "react";
import { useNavigate } from "react-router-dom";
import ChangePasswordModal from "../Pages/Login/ChangePasswordModal";
import { parentCntX } from "../Context/GlobalContext";
import { Moon, Sun } from "lucide-react";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { setAgent, setJwt } from "../modules/module_general";

const MenuProfile = ({
  anchorEl,
  setAnchorEl,
  nbSignature = 0,
}: {
  anchorEl: any;
  setAnchorEl: any;
  nbSignature?: number;
}) => {
  const navigate = useNavigate();
  const { themeMode, toggleTheme } = useContext(parentCntX);
  const open = Boolean(anchorEl);

  const theme = useMemo(
    () =>
      createTheme({
        palette: {
          mode: themeMode,
        },
      }),
    [themeMode]
  );
  const [showChangePwd, setShowChangePwd] = useState(false);
  const handleClose = useCallback(() => {
    setAnchorEl(null);
  }, []);
  const openParapheur = useCallback(() => {
    handleClose();
    navigate(`/myspace/Parapheur/Mon parapheur`);
  }, []);

  const handleLogout = useCallback(() => {
    setAgent({
      codProfile: "",
      Login: "",
      Typ_Role: "",
      Cod_Poste: "",
      Cod_Entite: "",
      Matricule: "",
      Nom: "",
      Mail: "",
      id_Societe: "",
      TeamLeader: false,
      RacineHierarchique: "",
    });
    setJwt("");
    handleClose();
    navigate("/");
  }, [handleClose, navigate]);

  return (
    <div>
      <ThemeProvider theme={theme}>
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
              mt: 1.5,
              "& .MuiAvatar-root": {
                width: 32,
                height: 32,
                ml: -0.5,
                mr: 1,
              },
              "&::before": {
                content: '""',
                display: "block",
                position: "absolute",
                top: 0,
                right: 14,
                width: 10,
                height: 10,
                bgcolor: "background.paper",
                transform: "translateY(-50%) rotate(45deg)",
                zIndex: 0,
              },
            },
          }}
          transformOrigin={{ horizontal: "right", vertical: "top" }}
          anchorOrigin={{ horizontal: "right", vertical: "bottom" }}
        >
          <MenuItem onClick={openParapheur}>
            <ListItemIcon>
              {nbSignature > 0 ? (
                <Badge badgeContent={nbSignature} color="error">
                  <DrawOutlined fontSize="small" />
                </Badge>
              ) : (
                <DrawOutlined fontSize="small" />
              )}
            </ListItemIcon>
            Mon parapheur
          </MenuItem>
          <MenuItem onClick={handleClose}>
            <ListItemIcon>
              <HistoryEduOutlined fontSize="small" />
            </ListItemIcon>
            Déléguer ma signature
          </MenuItem>
          <MenuItem
            onClick={() => {
              setAnchorEl(null);
              setShowChangePwd(true);
            }}
          >
            <ListItemIcon>
              <LockResetOutlined fontSize="small" />
            </ListItemIcon>
            Changer mot de passe
          </MenuItem>
          <MenuItem
            onClick={() => {
              toggleTheme();
            }}
          >
            <ListItemIcon>
              {themeMode === 'light' ? <Moon size={20} /> : <Sun size={20} />}
            </ListItemIcon>
            Mode {themeMode === 'light' ? 'Sombre' : 'Clair'}
          </MenuItem>
          <MenuItem onClick={handleLogout}>
            <ListItemIcon>
              <Logout fontSize="small" />
            </ListItemIcon>
            Déconnexion
          </MenuItem>
        </Menu>
      </ThemeProvider>
      <ChangePasswordModal
        open={showChangePwd}
        onSuccess={() => setShowChangePwd(false)}
        onClose={() => setShowChangePwd(false)}
      />
    </div >
  );
};

export default MenuProfile;
