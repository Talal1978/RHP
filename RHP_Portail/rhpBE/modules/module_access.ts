import { Request, Response } from "express";
import { IsNull } from "./module_general";
import { lireSql } from "./module_sqlRW";
import { NVarChar } from "mssql";
import { VGLOBALES } from "./module_initialisation";

export async function isPaieEncours(req: Request, res: Response) {
  const idSoc = IsNull(req.params.id_Societe, "3068");
  const sqlStr = `Select count(*) as nb from Controle_Access where Name_Ecran='RH_Preparation_Paie' and id_Societe=${idSoc}`;
  const rsl = await lireSql(sqlStr, []);
  if (rsl.result) {
    return res.send(rsl.data[0]["nb"] > 0);
  }
  return res.send(false);
}

export const isAccessible = async (
  nameEcran: string,
  idEcran: string,
  username: string,
  processId: string
) => {
  let sqlStr = `declare @nameEcran nvarchar(50),@equiv nvarchar(50), @idEcran nvarchar(50),@login nvarchar(50), @processId int,@Taken_By_User nvarchar(50), @currentProcessId int
    set @nameEcran='${nameEcran}'
    set @idEcran ='${IsNull(idEcran, "")}'
    set @processId ='${processId}'
    set @login ='${username}'
    select top 1 @currentProcessId= Process_Id, @Taken_By_User= Taken_By_User
    from Controle_Access a
    where Name_Ecran=@nameEcran and [Value]=@idEcran 
    if (@currentProcessId is null and isnull(@idEcran,'')!='' and isnull(@idEcran,'')!='undefined')
    begin
    insert into Controle_Access ( Name_Ecran, Value, Taken_By_User, Taken_By_Machine, IP, Process_Id, Date_Deb)
    values (@nameEcran,@idEcran,@login,'portail','',@processId,getdate())
    select convert(bit,'true') as canModify, @login as Taken_By_User,@processId as Process_Id
    end
    else
    begin
    select convert(bit, case when @currentProcessId=@processId and @Taken_By_User=@login then 'true' when isnull(@idEcran,'')='' then 'true' else 'false' end) as canModify,@Taken_By_User as Taken_By_User,@currentProcessId as Process_Id
    end`;
  let rsl = await lireSql(sqlStr, []);
  return rsl.data[0];
};
export const releaseAccessible = async (
  nameEcran: string,
  idEcran: string,
  username: string,
  processId: string
) => {
  let activeSessions =
    VGLOBALES.ACTIVE_PROCESSES.length > 0
      ? `'${VGLOBALES.ACTIVE_PROCESSES.join("','")}'`
      : "";
  let sqlStr = `declare @login nvarchar(50), @processId int,@Taken_By_User nvarchar(50), @currentProcessId int
    set @processId ='${processId}'
    set @login ='${username}'
    delete from Controle_Access
    where ((Name_Ecran= case when isnull(@nameEcran,'')!='' then @nameEcran else [Name_Ecran] end and [Value]=case when isnull(@idEcran,'')!='' then @idEcran else [Value] end and Process_Id=@processId and Taken_By_User=@login)
     ${activeSessions ? ` or ( Process_Id not in (${activeSessions}))` : ""} )
 
    `;
  let rsl = await lireSql(sqlStr, [
    { param: "nameEcran", sqlType: NVarChar, valeur: nameEcran || "" },
    { param: "idEcran", sqlType: NVarChar, valeur: idEcran || "" },
  ]);
  return rsl;
};
export const releaseAccessibleApi = async (req: Request, res: Response) => {
  let { nameEcran, idEcran } = req.body;
  let username = req.params.Login || "";
  let processId = req.params.processId || "0";
  return res.send(
    await releaseAccessible(nameEcran, idEcran, username, processId)
  );
};
export const checkAccessible = async (req: Request, res: Response) => {
  let { nameEcran, idEcran } = req.body;
  let username = req.params.Login || "";
  let processId = req.params.processId || "0";
  await releaseAccessible("", "", username, processId);
  return res.send(
    await isAccessible(
      nameEcran,
      IsNull(idEcran, "") || "",
      username,
      processId
    )
  );
};
export const logout = async (req: Request, res: Response) => {
  let username = req.params.Login || "";
  let processId = req.params.processId || "0";
  await releaseAccessible("", "", username, processId).then(() => {
    //deconnexion(processId);
    // res.redirect("/login");
  });
};
