import { Button, TextField } from "@mui/material";
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
import { useNavigate } from "react-router-dom";
import Bouton from "../../components/Bouton/Bouton";
import { setRubriques } from "../../modules/module_rubriques";
import { setSocket, socket } from "../../socket";
export const Login = () => {
  const navigate = useNavigate();
  const [errorMsg, setErrorMsg] = useState("");
  const [credention, setCredentials] = useState({ login: "", password: "" });
  const myAxiosGet = useAxiosGet();
  const authentification = useCallback(async () => {
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
      setRubriques((await myAxiosGet({ apiStr: "list_rubriques" }))?.data);
      setErrorMsg("");
      setAgent(rsl.data.data);
      setJwt(rsl.data.jwt);
      navigate("/myspace");
      await setSocket(rsl.data.jwt);
      // socket.on("connecte", (user: string) => {
      //   console.log(user, "connecté");
      // });
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
        <form className="txt" onKeyUp={(e) => keyUpEv(e)}>
          <TextField
            error={errorMsg != ""}
            id="login"
            label="Votre mail"
            variant="standard"
            className="textBox"
            autoComplete="username"
            helperText={errorMsg}
            value={credention.login}
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
            id="pwd"
            label="Votre mot de passe"
            variant="standard"
            className="textBox"
            type="password"
            autoComplete="current-password"
            value={credention.password}
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
            />
          )}
        </div>
        <span className="version">Version {Num_Version}</span>
      </div>
    </div>
  );
};
export default Login;
