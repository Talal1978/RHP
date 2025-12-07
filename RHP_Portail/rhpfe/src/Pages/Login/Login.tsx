import { Button, TextField, Backdrop, CircularProgress } from "@mui/material";
import "./login.scss";
import {
  Agent,
  Num_Version,
  colorBase,
  myJwt,
  setAgent,
  setJwt,
} from "../../modules/module_general";
import { useCallback, useState } from "react";
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
  const [credention, setCredentials] = useState({ login: "talal.hamdaoui@gmail.com", password: "azer" });
  const [showChangePwd, setShowChangePwd] = useState(false);
  const myAxiosGet = useAxiosGet();
  const myAxiosPost = useAxiosPost();
  const showAlert = useAlert();
  const [isLoading, setIsLoading] = useState(false);

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
    const rsl = await myAxiosGet({
      apiStr: "auth",
      bdy: {
        login: credention.login,
        pwd: credention.password,
      },
    });
    setIsLoading(false);
    if (!rsl) {
      setErrorMsg("problème de connexion");
    } else if (!rsl.data.result) {
      setErrorMsg("Identifiants erronés");
    } else {
      setAgent(rsl.data.data);
      const { accessToken } = rsl.data.jwt;
      setJwt(accessToken);
      setSocket(accessToken);

      // Check if temporary password (handles string 'true', boolean true, or 1)
      const isTemp = rsl.data.data.is_Temp;
      if (isTemp === 'true' || isTemp === true || isTemp === 1) {
        setShowChangePwd(true);
      } else {
        setRubriques((await myAxiosGet({ apiStr: "list_rubriques" }))?.data);
        setErrorMsg("");
        navigate("/myspace");
      }
    }
  }, [credention]);

  const keyUpEv = useCallback(
    (e: React.KeyboardEvent) => {
      if (e.key === "Enter") authentification();
    },
    [authentification]
  );

  return (
    <div className="container">
      <div className="login">
        <img
          src={`${process.env.PUBLIC_URL}/logo.png`}
          width={"50%"}
          alt="Logo"
        />
        <span className="titre">
          De la gestion de la <span>paie</span> à la gestion des{" "}
          <span>talents</span>
        </span>
        <form className="txt" onKeyUp={(e) => keyUpEv(e)} autoComplete="off">
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
            type={credention.password ? "password" : "text"}
            autoComplete="new-password"
            value={credention.password}
            onFocus={(event) => {
              event.target.removeAttribute("readonly");
              (event.target as HTMLInputElement).type = "password";
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
        </form>
        <div className="btn">
          <Bouton
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
