import { Request, Response } from "express";
import { IsNull } from "./module_general";
import { lireSql } from "./module_sqlRW";
import { Int, NVarChar } from "mssql";
import { VGLOBALES } from "./module_initialisation";

export async function isPaieEncours(req: Request, res: Response) {
  const idSoc = Number(IsNull(req.params.id_Societe, "3068"));
  const sqlStr = `Select count(*) as nb from Controle_Access where Name_Ecran=@p_nameEcran and id_Societe=@p_idSoc`;
  const rsl = await lireSql(sqlStr, [
    { param: "p_nameEcran", sqlType: NVarChar, valeur: "RH_Preparation_Paie" },
    { param: "p_idSoc", sqlType: Int, valeur: idSoc },
  ]);
  if (rsl.result) {
    return res.send(rsl.data[0]["nb"] > 0);
  }
  return res.send(false);
}

export const isAccessible = async (
  nameEcran: string,
  idEcran: string,
  username: string,
  processId: string,
  id_Societe: string
) => {
  let sqlStr = `declare @nameEcran nvarchar(50)=@p_nameEcran,@equiv nvarchar(50), @idEcran nvarchar(50)=@p_idEcran,@login nvarchar(50)=@p_login, @processId int=@p_processId,@Taken_By_User nvarchar(50), @currentProcessId int,@idSoc int=@p_idSoc
    select top 1 @currentProcessId= Process_Id, @Taken_By_User= Taken_By_User
    from Controle_Access a
    where Name_Ecran=@nameEcran and [Value]=@idEcran 
    if (@currentProcessId is null and isnull(@idEcran,'')!='' and isnull(@idEcran,'')!='undefined')
    begin
    insert into Controle_Access ( Name_Ecran,id_Societe, Value, Taken_By_User, Taken_By_Machine, IP, Process_Id, Date_Deb)
    values (@nameEcran,@idSoc,@idEcran,@login,'portail','',@processId,getdate())
    select convert(bit,'true') as canModify, @login as Taken_By_User,@processId as Process_Id
    end
    else if (@Taken_By_User=@login)
    begin
        update Controle_Access set Process_Id=@processId, Date_Deb=getdate()
        where Name_Ecran=@nameEcran and [Value]=@idEcran and id_Societe=@idSoc
        select convert(bit,'true') as canModify, @login as Taken_By_User,@processId as Process_Id
    end
    else
    begin
    select convert(bit, case when @currentProcessId=@processId and @Taken_By_User=@login then 'true' when isnull(@idEcran,'')='' then 'true' else 'false' end) as canModify,@Taken_By_User as Taken_By_User,@currentProcessId as Process_Id
    end`;

  let rsl = await lireSql(sqlStr, [
    { param: "p_nameEcran", sqlType: NVarChar, valeur: nameEcran },
    { param: "p_idEcran", sqlType: NVarChar, valeur: IsNull(idEcran, "") },
    { param: "p_login", sqlType: NVarChar, valeur: username },
    { param: "p_processId", sqlType: NVarChar, valeur: processId },
    { param: "p_idSoc", sqlType: NVarChar, valeur: id_Societe },
  ]);
  return rsl.data[0];
};
export const releaseAccessible = async (
  nameEcran: string,
  idEcran: string,
  username: string,
  processId: string,
  id_Societe: string
) => {
  const validatedActiveSessions = VGLOBALES.ACTIVE_PROCESSES.filter(pid => /^\d+$/.test(String(pid)));
  let activeSessions = validatedActiveSessions.length > 0 ? validatedActiveSessions.join(",") : "";
  let sqlStr = `declare @login nvarchar(50)=@p_login, @processId int=@p_processId,@Taken_By_User nvarchar(50), @currentProcessId int
    delete from Controle_Access
    where ((Name_Ecran= case when isnull(@nameEcran,'')!='' then @nameEcran else [Name_Ecran] end and [Value]=case when isnull(@idEcran,'')!='' then @idEcran else [Value] end and Process_Id=@processId and Taken_By_User=@login)
     ${activeSessions ? ` and ( Process_Id in (${activeSessions}))` : ""} ) and id_Societe=@p_id_Societe
 
    `;
  let rsl = await lireSql(sqlStr, [
    { param: "nameEcran", sqlType: NVarChar, valeur: nameEcran || "" },
    { param: "idEcran", sqlType: NVarChar, valeur: idEcran || "" },
    { param: "p_login", sqlType: NVarChar, valeur: username },
    { param: "p_processId", sqlType: NVarChar, valeur: processId },
    { param: "p_id_Societe", sqlType: Int, valeur: Number(id_Societe) || 0 },
  ]);
  return rsl;
};
export const releaseAccessibleApi = async (req: Request, res: Response) => {
  let { nameEcran, idEcran } = req.body;
  let username = req.params.Login || "";
  let processId = req.params.processId || "0";
  const id_Societe = req.params.id_Societe
  return res.send(
    await releaseAccessible(nameEcran, idEcran, username, processId, id_Societe)
  );
};
export const checkAccessible = async (req: Request, res: Response) => {
  let { nameEcran, idEcran } = req.body;
  let username = req.params.Login || "";
  const id_Societe = req.params.id_Societe
  let processId = req.params.processId || "0";
  await releaseAccessible("", "", username, processId, id_Societe);
  return res.send(
    await isAccessible(
      nameEcran,
      IsNull(idEcran, "") || "",
      username,
      processId, id_Societe
    )
  );
};
export const logout = async (req: Request, res: Response) => {
  let username = req.params.Login || "";
  let processId = req.params.processId || "0";
  const id_Societe = req.params.id_Societe
  await releaseAccessible("", "", username, processId, id_Societe).then(() => {
    //deconnexion(processId);
    // res.redirect("/login");
  });
};
