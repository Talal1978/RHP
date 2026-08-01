import { Request, Response } from "express";
import { estDate, toSqlDateFormat } from "../modules/module_format";
import { ecrireSql, lireSql, controleInjection } from "../modules/module_sqlRW";
import { NVarChar, SmallDateTime, Int } from "mssql";
import { sousmettre_signature } from "../modules/module_workflow";

export async function demandeDocAdminListe(req: Request, res: Response) {
    let { Matricule, Cod_Entite, Statut, Dat_Du, Dat_Au } = req.body;
    if (controleInjection(Matricule).result === false) return res.send({ result: false, message: "Injection détectée dans Matricule" });
    if (controleInjection(Cod_Entite).result === false) return res.send({ result: false, message: "Injection détectée dans Entité" });
    if (controleInjection(Statut).result === false) return res.send({ result: false, message: "Injection détectée dans Statut" });

    const { processId, ...theAgent } = req.params;
    const TblRef = "RH_Demande_Doc_Admin";
    let idSocNum = Number(theAgent?.id_Societe || "3068");
    if (isNaN(idSocNum) || idSocNum <= 0) {
        return res.send({ result: false, message: "id_Societe invalide" });
    }

    if (theAgent.TeamLeader) {
        // Access control logic for team leaders if needed
    } else {
        Matricule = theAgent.Matricule;
        Cod_Entite = theAgent.Cod_Entite;
    }
    Dat_Du = estDate(Dat_Du)
        ? toSqlDateFormat(Dat_Du)
        : toSqlDateFormat(new Date(1900, 0, 1));
    Dat_Au = estDate(Dat_Au)
        ? toSqlDateFormat(Dat_Au)
        : toSqlDateFormat(new Date(2045, 11, 31));
    Statut = Statut || "";
    let sqlStr = `SELECT TOP 50 Num_Demande as 'N° Demande', ${Matricule === theAgent.Matricule ? "Matricule,Nom, " : ""
        } isnull(Lib_Demande,'') as Libellé, dbo.FindRubrique('Statut_Signature',Statut) as Statut, isnull(Etat_Traitement,'') as 'Etat Traitement', Dat_Demande as 'Date'
   ${Cod_Entite === theAgent.Cod_Entite
            ? ""
            : ", isnull(Lib_Entite,'') as 'Entité'"
        }
  FROM RH_Demande_Doc_Admin v
   outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom, Cod_Entite from RH_Agent where id_Societe=v.id_Societe and Matricule=v.Matricule) r
    outer apply (select Lib_Entite from Org_Entite where id_Societe=v.id_Societe and Cod_Entite=r.Cod_Entite) e
  where id_Societe=@p_id_Societe and Matricule like '%'+@Matricule and Dat_Demande between @Dat_Du and @Dat_Au and isnull(Statut,'') like @p_Statut + '%' Order by [Date] desc`;
    const rsl = await lireSql(sqlStr, [
        { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
        { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
        { param: "p_Statut", sqlType: NVarChar, valeur: Statut },
        { param: "Dat_Du", sqlType: SmallDateTime, valeur: Dat_Du },
        { param: "Dat_Au", sqlType: SmallDateTime, valeur: Dat_Au },
    ]);
    res.send(rsl);
}

export async function get_demande_doc_admin(req: Request, res: Response) {
    const { num_demande } = req.body;
    const { processId, ...theAgent } = req.params;
    let idSocNum = Number(theAgent.id_Societe || "3068");
    if (isNaN(idSocNum) || idSocNum <= 0) {
        return res.send({ result: false, message: "id_Societe invalide" });
    }

    let sqlStr = `SELECT   *
  FROM RH_Demande_Doc_Admin where  Num_Demande=@num_demande and id_Societe=@p_id_Societe`;
    const rsl = await lireSql(sqlStr, [
        { param: "num_demande", sqlType: NVarChar, valeur: num_demande },
        { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
    ]);
    if (rsl.result) {
        sqlStr = `select Typ_Doc, Nbr_Exemplaire, Dat_Du, Dat_Au, Commentaire, RowId
    from RH_Demande_Doc_Admin_Detail f 
    where Num_Demande=@num_demande and id_Societe=@p_id_Societe`;
        const rslDetail = await lireSql(sqlStr, [
            { param: "num_demande", sqlType: NVarChar, valeur: num_demande },
            { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
        ]);
        if (rslDetail.result) {
            res.send({ result: true, entete: rsl.data[0], detail: rslDetail.data });
            return;
        } else {
            res.send({ result: true, entete: rsl.data[0], detail: [] });
            return;
        }
    } else {
        res.send({ result: false, entete: {}, detail: [], message: rsl.sort });
        return;
    }
}
export async function save_demande_doc_admin(req: Request, res: Response) {
    const { entete: _entete, detail } = req.body;

    const { id_Societe, Matricule } = req.params;
    let idSocNum = Number(id_Societe || "3068");
    if (isNaN(idSocNum) || idSocNum <= 0) {
        return res.send({ result: false, message: "id_Societe invalide" });
    }

    let { Num_Demande, ...entete } = _entete;
    if (!Num_Demande || Num_Demande === "") {
        const currentYear = new Date().getFullYear();
        const prefix = `DD${idSocNum}-${currentYear}`;
        const rsNum = await lireSql(
            `select @p_prefix + right('000000'+convert(nvarchar(6),isnull(max(racine),0)+1),6) as racine from (select convert(int,case when isnumeric(ISNULL(racine,''))!=1 then 0 else racine end ) as Racine from RH_Demande_Doc_Admin 
    outer apply(select RIGHT(Num_Demande,6) as racine)n
    where id_Societe=@p_id_Societe and year(Dat_Demande)=@p_year)f`,
            [
                { param: "p_prefix", sqlType: NVarChar, valeur: prefix },
                { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
                { param: "p_year", sqlType: Int, valeur: currentYear },
            ]
        );
        Num_Demande = rsNum?.data?.[0]?.racine;
    }
    const rsEnt = await ecrireSql({
        tableName: "RH_Demande_Doc_Admin",
        fields: { ...entete, Num_Demande, id_Societe: idSocNum },
        joinFields: ["Num_Demande", "id_Societe"],
        excludeFields: [],
        login: Matricule,
    });
    if (rsEnt.result) {
        const flgMaj = Math.floor(Math.random() * 10000);
        let detailOk = true;
        let detailError: any = null;

        for (const d of detail) {
            const rsDet = await ecrireSql({
                tableName: "RH_Demande_Doc_Admin_Detail",
                fields: { ...d, id_Societe: idSocNum, Num_Demande, Flag_Maj: flgMaj },
                joinFields: ["Num_Demande", "id_Societe", "RowId"],
                excludeFields: ["RowId"],
                login: Matricule,
            });
            if (!rsDet.result) {
                detailOk = false;
                detailError = rsDet.sort; // Capture error
                console.error("Detail Save Error:", rsDet);
                break;
            }
        }

        if (detailOk) {
            await lireSql(
                `delete from RH_Demande_Doc_Admin_Detail where id_Societe=@p_id_Societe and Num_Demande=@p_Num_Demande and Flag_Maj!=@p_flgMaj`,
                [
                    { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
                    { param: "p_Num_Demande", sqlType: NVarChar, valeur: Num_Demande },
                    { param: "p_flgMaj", sqlType: Int, valeur: flgMaj },
                ]
            );
            if (entete.Statut === "SS")
                await sousmettre_signature("DD", Num_Demande, idSocNum.toString(), Matricule);
            return res.send(rsEnt);
        } else {
            return res.send({ result: false, message: "Error saving details", error: detailError });
        }
    } else {
        return res.send(rsEnt);
    }
}
export async function delete_demande_doc_admin(req: Request, res: Response) {
    const { Num_Demande } = req.body;
    const { id_Societe } = req.params;
    let idSocNum = Number(id_Societe || "3068");
    if (isNaN(idSocNum) || idSocNum <= 0) {
        return res.send({ result: false, message: "id_Societe invalide" });
    }

    // Delete details first
    await lireSql(
        `delete from RH_Demande_Doc_Admin_Detail where Num_Demande=@Num_Demande and id_Societe=@p_id_Societe`,
        [
            { param: "Num_Demande", sqlType: NVarChar, valeur: Num_Demande },
            { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
        ]
    );

    // Delete header
    const rsl = await lireSql(
        `delete from RH_Demande_Doc_Admin where Num_Demande=@Num_Demande and id_Societe=@p_id_Societe`,
        [
            { param: "Num_Demande", sqlType: NVarChar, valeur: Num_Demande },
            { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
        ]
    );

    if (rsl.result) {
        return res.send({ result: true, data: Num_Demande });
    } else return res.send({ result: false, data: rsl.sort });
}
