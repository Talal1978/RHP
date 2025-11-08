import { Response, Request } from "express";
import { encrypt } from "../modules/module_encrypt";
import { lireSql } from "../modules/module_sqlRW";
import { NVarChar, VarBinary } from "mssql";
import { getToken } from "../modules/module_jwt";
import { envoiMail } from "../modules/module_sendMail";
import {
  VGLOBALES,
  initialisationGlobale,
} from "../modules/module_initialisation";
export const authentication = async (req: Request, res: Response) => {
  const { login, pwd } = req.query;
  const sqlStr = `declare @lg nvarchar(50)
    set @lg=upper('${login}')
    select top 1 -1 id_User,id_Societe,Matricule, ltrim(rtrim(isnull(Nom_Agent,'') + ' ' + isnull(Prenom_Agent,''))) as Nom,isnull(Cod_Entite,'') as Cod_Entite, isnull(Cod_Poste,'') as Cod_Poste, Mail Login_User,
    isnull(Droit_Paie,'false') as User_Actif, -1 as Cod_Profile, isnull(Droit_Paie,'false') as Profile_Actif , isnull(Mail,'') as Mail,convert(bit, case when estTeamLeader>0 then 'true' else 'false' end) as TeamLeader
    from Rh_Agent a
    outer apply (select count(*) as estTeamLeader from Sys_Org_Entite where Cod_Entite=isnull(a.Cod_Entite,'ui5465deu_è_è_çè') and Responsable=a.Matricule)o
    where HashBytes('SHA1',upper(Mail))=HashBytes('SHA1',@lg) and Pw='${encrypt(
    pwd
  )}'`;
  console.log(sqlStr);
  const rsl = await lireSql(sqlStr, [
    { param: "login", sqlType: NVarChar, valeur: login },
  ]);

  if (rsl.result && rsl.data.length > 0) {
    const myJwt = getToken(
      rsl.data[0].Cod_Profile,
      rsl.data[0].Login,
      rsl.data[0].Typ_Role,
      rsl.data[0].Cod_Poste,
      rsl.data[0].Cod_Entite,
      rsl.data[0].Matricule,
      rsl.data[0].Nom,
      rsl.data[0].Mail,
      rsl.data[0].id_Societe,
      rsl.data[0].TeamLeader,
      rsl.data[0].RacineHierarchique,
      rsl.data[0].id_User
    );
    await initialisationGlobale({
      codProfile: rsl.data[0].Cod_Profile,
      Login: rsl.data[0].Login,
      Typ_Role: rsl.data[0].Typ_Role,
      Cod_Entite: rsl.data[0].Cod_Entite,
      Cod_Poste: rsl.data[0].Cod_Poste,
      id_Societe: rsl.data[0].id_Societe,
      Mail: rsl.data[0].Mail,
      Matricule: rsl.data[0].Matricule,
      Nom: rsl.data[0].Nom,
      RacineHierarchique: rsl.data[0].RacineHierarchique,
      TeamLeader: rsl.data[0].TeamLeader,
      id_User: rsl.data[0].id_User,
    });
    await lireSql(
      `insert into Controle_Users_Process (Login_User, Nom_User, hostname, Process_Id, Dat)
          values ('${rsl.data[0].Login}','${rsl.data[0].nom + " " + rsl.data[0].prenom
      }','web','${req.params.processId}',getdate())`,
      []
    );
    return res.send({
      result: rsl.result,
      data: rsl.data[0],
      jwt: myJwt,
    });
  } else {
    return res.send({ result: false, data: [] });
  }
};
export const getNewPwd = async (req: Request, res: Response) => {
  try {
    const { login, db } = req.body;
    let sqlStr = `select top 1 ltrim(rtrim(isnull(Nom_User,'')+' '+ isnull(Prenom_User,''))) as Nom from RH_Agent where isnull(Mail,'')=@login`;
    const result = await lireSql(sqlStr, [
      { param: "login", sqlType: NVarChar, valeur: login },
    ]);
    const lowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
    const uppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    const digits = "0123456789";
    const characters = lowercaseLetters + uppercaseLetters + digits;
    let password = "";
    for (let i = 0; i < 8; i++) {
      const index = Math.floor(Math.random() * characters.length);
      password += characters[index];
    }
    interface userDataFormat {
      Nom: string;
      Mail: string;
    }
    let userData = result.data[0] as userDataFormat;
    sqlStr = `update RH_Agent set is_Temp ='true', PW='${encrypt(
      password
    )}' where Mail=@login`;
    await lireSql(sqlStr, [
      { param: "login", sqlType: NVarChar, valeur: login },
    ]);
    const mailOptions = {
      from: VGLOBALES.SMTP_USERNAME || "",
      to: userData.Mail,
      subject: "Nouveau mot de passe",
      text: "",
      html: `Bonjour ${userData.Nom}<BR/>Vous avez réinitialisé votre mot de passe<BR/>Ci-après votre nouveau mot de pass : <b>${password}</b>.`,
      headers: {},
    };
    let info = await envoiMail(mailOptions);
    return res.send({ result: info.accepted.length > 0, data: info.accepted });
  } catch (err) {
    return res.send({ result: false, data: err });
  }
};
export const setPwd = async (req: Request, res: Response) => {
  try {
    const { pwd } = req.body;
    const login = req.params.Login || "";
    const id_Societe = req.params.id_Societe || -1;
    const db = req.params.db || "";
    const sqlStr = `update RH_Agent set is_Temp='false',PW='${encrypt(
      pwd
    )}'  where Matricule=@login and id_Societe='${id_Societe}'`;
    const rsl = await lireSql(sqlStr, [
      { param: "login", sqlType: NVarChar, valeur: login },
    ]);
    return res.send({ result: rsl.result, data: [] });
  } catch (err) {
    return res.send({ result: false, data: err });
  }
};
