import { Button, TextField, Backdrop, CircularProgress, FormControlLabel, Switch, InputAdornment, IconButton } from "@mui/material";
import Visibility from "@mui/icons-material/Visibility";
import VisibilityOff from "@mui/icons-material/VisibilityOff";
import "./login.scss";
import {
  Agent,
  Num_Version,
  colorBase,
  myJwt,
  setAgent,
  setJwt,
} from "../../modules/module_general";
import { useCallback, useEffect, useState } from "react";
import useAxiosGet from "../../hooks/useAxiosGet";
import useAxiosPost from "../../hooks/useAxiosPost";
import { useNavigate } from "react-router-dom";
import Bouton from "../../components/Bouton/Bouton";
import { setRubriques } from "../../modules/module_rubriques";
import { setSocket } from "../../socket";
import ChangePasswordModal from "./ChangePasswordModal";
import useAlert from "../../hooks/useAlert";

export const Login = () => {
  const navigate = useNavigate();
  const [errorMsg, setErrorMsg] = useState("");
  const [credention, setCredentials] = useState({ login: "", password: "" });
  const [showChangePwd, setShowChangePwd] = useState(false);
  const myAxiosGet = useAxiosGet();
  const myAxiosPost = useAxiosPost();
  const showAlert = useAlert();
  const [isLoading, setIsLoading] = useState(false);
  const [rememberMe, setRememberMe] = useState(false);
  const [showPassword, setShowPassword] = useState(false);

  useEffect(() => {
    const storedToken = localStorage.getItem("auth_token");
    const storedAgent = localStorage.getItem("auth_agent");
    const storedLogin = localStorage.getItem("remembered_login");

    if (storedLogin) {
        setCredentials(prev => ({ ...prev, login: storedLogin }));
        setRememberMe(true);
    }

    if (storedToken && storedAgent) {
      try {
        const parsedAgent = JSON.parse(storedAgent);

        // Validation structurale basique pour éviter les objets corrompus
        if (!parsedAgent || typeof parsedAgent !== 'object') {
            throw new Error("Données agent corrompues");
        }

        // La session stockée peut être invalidée côté serveur (redémarrage du
        // backend, qui efface les sessions en mémoire, ou expiration du jeton
        // de rafraîchissement) : on la VALIDE par un appel authentifié léger
        // avant de restaurer. En cas d'échec, la chaîne 403/refresh des hooks
        // déclenche forceLogout() (stockage nettoyé, retour à la connexion).
        setIsLoading(true);
        myAxiosGet({ apiStr: "sp_menu_portail" })
          .then((rsl) => {
            if (rsl && (rsl as any).status !== -1 && (rsl as any).data) {
              // Jeton éventuellement renouvelé par le refresh transparent du hook
              const tokenCourant = localStorage.getItem("auth_token") || storedToken;
              setJwt(tokenCourant);
              setAgent(parsedAgent);
              setSocket(tokenCourant);
              navigate("/myspace");
            }
          })
          .finally(() => setIsLoading(false));
      } catch (e) {
        console.error("Error restoring session (Corruption detected):", e);
        // Nettoyage complet en cas de corruption
        localStorage.removeItem("auth_token");
        localStorage.removeItem("auth_agent");
      }
    }
  }, [navigate, myAxiosGet]);

  const handleForgotPassword = useCallback(async () => {
    if (!credention.login) {
      showAlert({ msg: "Veuillez saisir votre email", typMsg: "warning" });
      document.getElementById("login")?.focus();
      return;
    }

    setIsLoading(true);
    // Optimistic UI or loading could be added here
    const rsl = await myAxiosPost("getNewPwd", {
      login: credention.login,
    });
    setIsLoading(false);
    console.log(rsl);

    if (rsl?.data?.result) {
      showAlert({
        titre: "Succès",
        msg: "Un nouveau mot de passe a été envoyé à votre adresse mail.",
        typMsg: "success",
      });
    } else {
      showAlert({
        titre: "Erreur",
        msg: "Erreur lors de l'envoi du mot de passe. Vérifiez votre email.",
        typMsg: "error",
      });
    }
  }, [credention.login, showAlert]);

  const authentification = useCallback(async () => {
    setIsLoading(true);
    try {
        // Version Check
        const verRsl = await myAxiosGet({ apiStr: "check_version" });
        if (verRsl && verRsl.data && verRsl.data.result && verRsl.data.data && verRsl.data.data.length > 0) {
            const serverVersion = verRsl.data.data[0].Valeur;
            const clientVersionClean = Num_Version.replace(/\./g, "");
            const serverVersionClean = String(serverVersion).replace(/\./g, "");
            
            if (parseInt(clientVersionClean) !== parseInt(serverVersionClean)) {
                showAlert({
                    titre: "Version incompatible",
                    msg: "La version installée sur votre serveur est différente de votre version.\nVeuillez contactez votre administrateur.",
                    typMsg: "warning" // Using warning to match "alerte en tenant compte du thème"
                });
                return; // Prevent login per Login.vb logic
            }
        }

        const rsl = await myAxiosGet({
            apiStr: "auth",
            bdy: {
                login: credention.login,
                pwd: credention.password,
            },
        });
        
        if (!rsl) {
            setErrorMsg("problème de connexion");
        } else if (!rsl.data.result) {
            setErrorMsg("Identifiants erronés");
        } else {
            setAgent(rsl.data.data);
            const { accessToken } = rsl.data.jwt;
            setJwt(accessToken);
            setSocket(accessToken);

            // Check if temporary password
            const isTemp = rsl.data.data.is_Temp;
            if (isTemp === 'true' || isTemp === true || isTemp === 1) {
                setShowChangePwd(true);
            } else {
                if (rememberMe) {
                    localStorage.setItem("auth_token", accessToken);
                    localStorage.setItem("auth_agent", JSON.stringify(rsl.data.data));
                    localStorage.setItem("remembered_login", credention.login);
                } else {
                    localStorage.removeItem("auth_token");
                    localStorage.removeItem("auth_agent");
                    localStorage.removeItem("remembered_login");
                }
                
                try {
                    const rubriques = await myAxiosGet({ apiStr: "list_rubriques" });
                    if(rubriques?.data) setRubriques(rubriques.data);
                } catch(e) {
                    console.warn("Failed to fetch rubriques", e);
                }
                
                setErrorMsg("");
                navigate("/myspace");
            }
        }
    } catch (e) {
        console.error("Auth error:", e);
        setErrorMsg("Erreur technique lors de la connexion");
    } finally {
        setIsLoading(false);
    }
  }, [credention, rememberMe, showAlert, myAxiosGet, navigate]);

  const keyUpEv = useCallback(
    (e: React.KeyboardEvent) => {
      if (e.key === "Enter") authentification();
    },
    [authentification]
  );

  return (
    <div className="login-page-container">
      <div className="login">
        <img
          src={`${import.meta.env.BASE_URL}logo.png`}
          width={"50%"}
          alt="Logo"
        />
        <span className="titre">
          De la gestion de la <span>paie</span> à la gestion des{" "}
          <span>talents</span>
        </span>
        <form className="txt" onKeyUp={(e) => keyUpEv(e)} onSubmit={(e) => e.preventDefault()} autoComplete="off">
          {/* Prevent browser autocomplete - Decoy Inputs */}
          <input type="text" style={{ display: "none" }} />
          <input type="password" style={{ display: "none" }} />

          <TextField
            error={errorMsg != ""}
            id="field_rnd_1"
            name="field_rnd_1"
            label="Votre mail"
            variant="standard"
            className="textBox"
            autoComplete="off"
            helperText={errorMsg}
            value={credention.login}
            onFocus={(event) => {
              event.target.removeAttribute("readonly");
            }}
            inputProps={{
              readOnly: true,
              autoComplete: 'off'
            }}
            onChange={(event) => {
              setCredentials((prevCredential) => ({
                ...prevCredential,
                login: event.target.value,
              }));
            }}
          />
          <TextField
            error={errorMsg != ""}
            helperText={errorMsg}
            id="field_rnd_2"
            name="field_rnd_2"
            label="Votre mot de passe"
            variant="standard"
            className="textBox"
            type={showPassword ? "text" : "password"}
            autoComplete="new-password"
            value={credention.password}
            onFocus={(event) => {
              event.target.removeAttribute("readonly");
            }}
            InputProps={{
              endAdornment: (
                <InputAdornment position="end">
                  <IconButton
                    aria-label={showPassword ? "Masquer le mot de passe" : "Afficher le mot de passe"}
                    onClick={() => setShowPassword((prev) => !prev)}
                    onMouseDown={(e) => e.preventDefault()}
                    edge="end"
                    sx={{ color: colorBase.foreColorBase01 }}
                  >
                    {showPassword ? <VisibilityOff /> : <Visibility />}
                  </IconButton>
                </InputAdornment>
              ),
            }}
            inputProps={{
              readOnly: true,
              autoComplete: "new-password",
            }}
            onChange={(event) => {
              setCredentials((prevCredential) => ({
                ...prevCredential,
                password: event.target.value,
              }));
            }}
          />
          <FormControlLabel
            control={
              <Switch
                checked={rememberMe}
                onChange={(e) => setRememberMe(e.target.checked)}
                name="rememberMe"
                color="primary"
              />
            }
            label="Se souvenir de moi"
            sx={{ width: "90%", color: colorBase.foreColorBase01 }}
          />
        </form>
        <div className="btn">
          <Bouton
            type="button"
            className="bouton"
            label="Accédez au portail"
            variant="contained"
            sx={{ backgroundColor: colorBase.colorBase01 }}
            onClick={authentification}
          />

          {errorMsg && (
            <Bouton
              variant="outlined"
              label="Mot de passe oublié"
              className="bouton"
              onClick={handleForgotPassword}
            />
          )}
        </div>
        <span className="version">Version {Num_Version}</span>
        <ChangePasswordModal
          open={showChangePwd}
          onSuccess={() => {
            setShowChangePwd(false);
            navigate("/myspace");
          }}
        />
      </div>
      <Backdrop
        sx={{ color: "#fff", zIndex: (theme) => theme.zIndex.drawer + 1 }}
        open={isLoading}
      >
        <CircularProgress color="inherit" />
      </Backdrop>
    </div>
  );
};
export default Login;
