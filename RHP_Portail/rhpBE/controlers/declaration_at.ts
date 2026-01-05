import { Request, Response } from "express";
import { estDate, toSqlDateFormat } from "../modules/module_format";
import { lireSql, controleInjection } from "../modules/module_sqlRW";
import { NVarChar, SmallDateTime } from "mssql";

export async function declarationATListe(req: Request, res: Response) {
    let { Matricule, Cod_Entite, Statut, Dat_Du, Dat_Au } = req.body;

    if (controleInjection(Matricule).result === false) return res.send({ result: false, message: "Injection détectée dans Matricule" });
    if (controleInjection(Cod_Entite).result === false) return res.send({ result: false, message: "Injection détectée dans Entité" });
    if (controleInjection(Statut).result === false) return res.send({ result: false, message: "Injection détectée dans Statut" });

    const { processId, ...theAgent } = req.params;
    const TblRef = "RH_Declaration_AT";
    let idSoc = theAgent?.id_Societe || "3068";

    // Security Filter logic (similar to Note_Frais)
    let MatriculeWhere = "";
    if (theAgent.TeamLeader) {
        MatriculeWhere = `exists(select Matricule from Rh_Agent _agt where id_Societe=${theAgent.id_Societe} and _agt.Cod_Entite in (
        select  Cod_Entite from Sys_Org_Entite s where 
        ';'+isnull(Racine+';'+s.Cod_Entite,'')+';' like '%;'+isnull(nullif('${theAgent.Cod_Entite}',''),'8787uhuhunjj')+';%' and id_Societe=_agt.id_Societe))`;
    } else {
        Matricule = theAgent.Matricule;
        Cod_Entite = theAgent.Cod_Entite;
        MatriculeWhere = `(${TblRef}.id_Societe=${theAgent.id_Societe} and ${TblRef}.Matricule='${theAgent.Matricule}')`;
    }

    Dat_Du = estDate(Dat_Du)
        ? toSqlDateFormat(Dat_Du)
        : toSqlDateFormat(new Date(1900, 0, 1));
    Dat_Au = estDate(Dat_Au)
        ? toSqlDateFormat(Dat_Au)
        : toSqlDateFormat(new Date(2045, 11, 31));
    Statut = Statut || "";

    let sqlStr = `SELECT Num_Declaration as 'N° Déclaration', Dat_Accident as 'Date Accident', 
                ${Matricule === theAgent.Matricule ? "Matricule,Nom, " : ""} 
                isnull(Statut,'') as Statut, 
                isnull(Cloture,0) as Cloture
                ${Cod_Entite === theAgent.Cod_Entite ? "" : ", isnull(Lib_Entite,'') as 'Entité'"}
                FROM RH_Declaration_AT v
                outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom, Cod_Entite from RH_Agent where id_Societe=v.id_Societe and Matricule=v.Matricule) r
                outer apply (select Lib_Entite from Org_Entite where id_Societe=v.id_Societe and Cod_Entite=r.Cod_Entite) e
                where id_Societe='${idSoc}' and Matricule like '%'+@Matricule and Dat_Accident between @Dat_Du and @Dat_Au and isnull(Statut,'') like '${Statut}%' 
                Order by Dat_Accident desc`;

    const rsl = await lireSql(sqlStr, [
        { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
        { param: "Statut", sqlType: NVarChar, valeur: Statut },
        { param: "Dat_Du", sqlType: SmallDateTime, valeur: Dat_Du },
        { param: "Dat_Au", sqlType: SmallDateTime, valeur: Dat_Au },
    ]);
    res.send(rsl);
}

export async function get_declaration_at(req: Request, res: Response) {
    const { num_declaration } = req.body;
    const { processId, ...theAgent } = req.params;
    let idSoc = theAgent.id_Societe || "3068";

    let sqlStr = `SELECT * FROM RH_Declaration_AT where Num_Declaration=@num_decl and id_Societe=${idSoc}`;
    const rsl = await lireSql(sqlStr, [
        { param: "num_decl", sqlType: NVarChar, valeur: num_declaration },
    ]);

    if (rsl.result) {
        // Get Details
        sqlStr = `select Typ_Certificat, Dat_Certificat, Dat_Debut_Arret, Dat_Fin_Arret, Nbr_Jours, Valide, Commentaire as Comment, RowId
              from RH_Declaration_AT_Detail
              where Num_Declaration=@num_decl and id_Societe=${idSoc}
              order by RowId `;

        const rslDetail = await lireSql(sqlStr, [
            { param: "num_decl", sqlType: NVarChar, valeur: num_declaration },
        ]);

        if (rslDetail.result) {
            res.send({ result: true, entete: rsl.data[0], detail: rslDetail.data });
        } else {
            res.send({ result: true, entete: rsl.data[0], detail: [] });
        }
    } else {
        res.send({ result: false, entete: {}, detail: [], message: rsl.sort });
    }
}
