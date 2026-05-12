import { Request, Response } from "express";
import { lireSql } from "../modules/module_sqlRW";
import { Int, NVarChar } from "mssql";
export async function get_ged_docs(req: Request, res: Response) {
  const { name_ecran, valeur_index } = req.query;
  const { Login, id_Societe, id_User, Matricule } = req.params;
  let id_user = Number(id_User) >= 0 ? Login : Matricule;

  const rsl = await lireSql(
    `;
with Tbl (FD_id,Name_Ecran,Typ,Index_Ecran,Value_Index,FD_Alias,Parent_Dir,Ecriture,Created_By,Date_Modif, Racine)
as(
select FD_id,Name_Ecran,Typ,Index_Ecran,Value_Index,FD_Alias,Parent_Dir,
convert(bit,case when isnull(me_w,'false') = 'true' or Created_By=@id_user then 'true' 
else 'false' end) as Ecriture,Created_By, isnull(Dat_Modif, Dat_Crea) as Date_Modif, convert(varchar(max),';0;') Racine
    from Param_Ged g
	outer apply (select [value] as me_w from string_split(case when isnull(g.Ecriture,'')='*' then @id_user else isnull(g.Ecriture,'') end,';') where [value]=@id_user) me_wr
	outer apply (select [value] as Masquer from string_split(case when isnull(Cacher,'')='*' then @id_user else isnull(Cacher,'') end,';') where [value]=@id_user) c
    where id_Societe=@id_societe and Parent_Dir=0 and Name_Ecran=@name_ecran and Value_Index=@valeur_index
    and (Masquer is null or Created_By=@id_user)
union all
select g.FD_id,g.Name_Ecran,g.Typ,g.Index_Ecran,g.Value_Index,g.FD_Alias,g.Parent_Dir,
convert(bit,case when isnull(t.Ecriture,'false')='false' then 'false' 
when isnull(me_w,'false') = 'true' or g.Created_By=@id_user then 'true' 
else 'false' end) as Ecriture,g.Created_By, isnull(Dat_Modif, Dat_Crea) as Date_Modif,convert(varchar(max),t.Racine+convert(nvarchar(50),g.Parent_Dir)+';') 
    from Param_Ged g inner join Tbl t on g.Parent_Dir=t.FD_id
	outer apply (select [value] as me_w from string_split(case when isnull(g.Ecriture,'')='*' then @id_user else isnull(g.Ecriture,'') end,';') where [value]=@id_user) me_wr
	outer apply (select [value] as Masquer from string_split(case when isnull(Cacher,'')='*' then @id_user else isnull(Cacher,'') end,';') where [value]=@id_user) c
    where id_Societe=@id_societe and g.Name_Ecran=@name_ecran and g.Value_Index=@valeur_index
    and (Masquer is null or g.Created_By=@id_user))
select FD_id,Name_Ecran,Typ,Index_Ecran,Value_Index,FD_Alias,Parent_Dir,Ecriture,Created_By, isnull(a.Cree_Par,u.Cree_Par) as Nom_Created_By,convert(datetime,case when isdate(Date_Modif)=1 then Date_Modif else null end) Date_Modif,Racine,FD_Alias as 'newName',convert(bit,0) as editMode from Tbl g
outer apply (select Nom_User+' '+Prenom_User as Cree_Par from Controle_Users where Login_User=g.Created_By)u
outer apply (select Nom_Agent+' '+Prenom_Agent as Cree_Par from RH_Agent where Matricule=g.Created_By and id_Societe=@id_societe)a
order by Typ asc, Date_Modif desc
`,
    [
      { param: "name_ecran", sqlType: NVarChar, valeur: name_ecran },
      { param: "valeur_index", sqlType: NVarChar, valeur: valeur_index },
      { param: "id_societe", sqlType: Int, valeur: id_Societe },
      { param: "id_user", sqlType: NVarChar, valeur: id_user },
    ]
  );
  res.send(rsl);
}
