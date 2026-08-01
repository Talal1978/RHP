import { Request, Response } from "express";
import { estDate, toSqlDateFormat } from "../modules/module_format";
import { ecrireSql, lireSql, controleInjection } from "../modules/module_sqlRW";
import { NVarChar, SmallDateTime, Int, Float } from "mssql";
import { sousmettre_signature } from "../modules/module_workflow";

export async function outillageMouvementListe(req: Request, res: Response) {
    let { Matricule, Cod_Entite, Statut, Dat_Du, Dat_Au } = req.body;
    if (controleInjection(Matricule).result === false) return res.send({ result: false, message: "Injection détectée dans Matricule" });
    if (controleInjection(Cod_Entite).result === false) return res.send({ result: false, message: "Injection détectée dans Entité" });
    if (controleInjection(Statut).result === false) return res.send({ result: false, message: "Injection détectée dans Statut" });

    const { processId, ...theAgent } = req.params;
    const TblRef = "RH_Outillage_Mouvement";
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
    let sqlStr = `SELECT TOP 50 Num_Mouvement as 'N° Mouvement', ${Matricule === theAgent.Matricule ? "Matricule,Nom, " : ""
        } dbo.FindRubrique('Typ_Mouvement_Outillage',Typ_Mouvement) as 'Type Mouvement', dbo.FindRubrique('Statut_Signature',Statut) as Statut, Dat_Mouvement as 'Date', Commentaire
   ${Cod_Entite === theAgent.Cod_Entite
            ? ""
            : ", isnull(Lib_Entite,'') as 'Entité'"
        }
  FROM RH_Outillage_Mouvement v
   outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom, Cod_Entite from RH_Agent where id_Societe=v.id_Societe and Matricule=v.Matricule) r
    outer apply (select Lib_Entite from Org_Entite where id_Societe=v.id_Societe and Cod_Entite=r.Cod_Entite) e
  where id_Societe=@p_id_Societe and Matricule like '%'+@Matricule and Dat_Mouvement between @Dat_Du and @Dat_Au and isnull(Statut,'') like @p_Statut + '%' Order by [Date] desc`;
    const rsl = await lireSql(sqlStr, [
        { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
        { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
        { param: "p_Statut", sqlType: NVarChar, valeur: Statut },
        { param: "Dat_Du", sqlType: SmallDateTime, valeur: Dat_Du },
        { param: "Dat_Au", sqlType: SmallDateTime, valeur: Dat_Au },
    ]);
    res.send(rsl);
}

export async function get_outillage_mouvement(req: Request, res: Response) {
    const { num_mouvement } = req.body;
    const { processId, ...theAgent } = req.params;
    let idSocNum = Number(theAgent.id_Societe || "3068");
    if (isNaN(idSocNum) || idSocNum <= 0) {
        return res.send({ result: false, message: "id_Societe invalide" });
    }

    let sqlStr = `SELECT *
  FROM RH_Outillage_Mouvement where Num_Mouvement=@num_mouvement and id_Societe=@p_id_Societe`;
    const rsl = await lireSql(sqlStr, [
        { param: "num_mouvement", sqlType: NVarChar, valeur: num_mouvement },
        { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
    ]);
    if (rsl.result) {
        sqlStr = `select d.Cod_Outillage, o.Lib_Outillage, o.Typ_Outillage, o.Num_Serie,
            case h.Typ_Mouvement when 'R' then isnull(agt.Qte_Detenus,0) else isnull(disp.Qte_Disponible,0) end as Qte_Dispo,
            d.Qte, d.RowId
            from RH_Outillage_Mouvement_Detail d
            inner join RH_Outillage_Mouvement h on h.Num_Mouvement=d.Num_Mouvement and h.id_Societe=d.id_Societe
            left join RH_Outillage o on o.Cod_Outillage=d.Cod_Outillage and o.id_Societe=d.id_Societe
            left join RH_Outillage_Dispo disp on disp.Cod_Outillage=d.Cod_Outillage and disp.id_Societe=d.id_Societe
            left join RH_Outillage_Agent agt on agt.Cod_Outillage=d.Cod_Outillage and agt.id_Societe=d.id_Societe and agt.Matricule=h.Matricule
            where d.Num_Mouvement=@num_mouvement and d.id_Societe=@p_id_Societe`;
        const rslDetail = await lireSql(sqlStr, [
            { param: "num_mouvement", sqlType: NVarChar, valeur: num_mouvement },
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

export async function save_outillage_mouvement(req: Request, res: Response) {
    const { entete: _entete, detail } = req.body;

    const { id_Societe, Matricule } = req.params;
    let idSocNum = Number(id_Societe || "3068");
    if (isNaN(idSocNum) || idSocNum <= 0) {
        return res.send({ result: false, message: "id_Societe invalide" });
    }

    let { Num_Mouvement, ...entete } = _entete;
    if (!Num_Mouvement || Num_Mouvement === "") {
        const currentYear = new Date().getFullYear();
        const prefix = `OTM${idSocNum}-${currentYear}`;
        const rsNum = await lireSql(
            `select @p_prefix + right('000000'+convert(nvarchar(6),isnull(max(racine),0)+1),6) as racine from (select convert(int,case when isnumeric(ISNULL(racine,''))!=1 then 0 else racine end ) as Racine from RH_Outillage_Mouvement
    outer apply(select RIGHT(Num_Mouvement,6) as racine)n
    where id_Societe=@p_id_Societe and year(Dat_Crea)=@p_year)f`,
            [
                { param: "p_prefix", sqlType: NVarChar, valeur: prefix },
                { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
                { param: "p_year", sqlType: Int, valeur: currentYear },
            ]
        );
        Num_Mouvement = rsNum?.data?.[0]?.racine;
    }
    const rsEnt = await ecrireSql({
        tableName: "RH_Outillage_Mouvement",
        fields: { ...entete, Num_Mouvement, id_Societe: idSocNum },
        joinFields: ["Num_Mouvement", "id_Societe"],
        excludeFields: [],
        login: Matricule,
    });
    if (rsEnt.result) {
        const flgMaj = Math.floor(Math.random() * 10000);
        let detailOk = true;
        let detailError: any = null;

        for (const d of detail) {
            const rsDet = await ecrireSql({
                tableName: "RH_Outillage_Mouvement_Detail",
                fields: { ...d, id_Societe: idSocNum, Num_Mouvement, Flag_Maj: flgMaj },
                joinFields: ["Num_Mouvement", "id_Societe", "RowId"],
                excludeFields: ["RowId"],
                login: Matricule,
            });
            if (!rsDet.result) {
                detailOk = false;
                detailError = rsDet.sort;
                console.error("Detail Save Error:", rsDet);
                break;
            }
        }

        if (detailOk) {
            await lireSql(
                `delete from RH_Outillage_Mouvement_Detail where id_Societe=@p_id_Societe and Num_Mouvement=@p_Num_Mouvement and Flag_Maj!=@p_flgMaj`,
                [
                    { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
                    { param: "p_Num_Mouvement", sqlType: NVarChar, valeur: Num_Mouvement },
                    { param: "p_flgMaj", sqlType: Int, valeur: flgMaj },
                ]
            );
            if (entete.Statut === "SS" || entete.Statut === "VA")
                await sousmettre_signature("OTM", Num_Mouvement, idSocNum.toString(), Matricule);
            return res.send(rsEnt);
        } else {
            return res.send({ result: false, message: "Error saving details", error: detailError });
        }
    }
}

export async function get_outillage_info(req: Request, res: Response) {
    const { cod_outillage, typ_mouvement, matricule } = req.body;
    const { id_Societe } = req.params;
    let idSocNum = Number(id_Societe || "3068");
    if (isNaN(idSocNum) || idSocNum <= 0) {
        return res.send({ result: false, message: "id_Societe invalide" });
    }

    const sqlStr = typ_mouvement === "R"
        ? `select Cod_Outillage, Lib_Outillage, Typ_Outillage, Num_Serie, Qte_Detenus as Qte_Ref from RH_Outillage_Agent where Cod_Outillage=@cod and Matricule=@mat and id_Societe=@idSoc`
        : `select Cod_Outillage, Lib_Outillage, Typ_Outillage, Num_Serie, Qte_Disponible as Qte_Ref from RH_Outillage_Dispo where Cod_Outillage=@cod and id_Societe=@idSoc`;

    const params: any[] = [
        { param: "cod", sqlType: NVarChar, valeur: cod_outillage },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
    ];
    if (typ_mouvement === "R") {
        params.push({ param: "mat", sqlType: NVarChar, valeur: matricule });
    }

    const rsl = await lireSql(sqlStr, params);
    res.send(rsl);
}

export async function delete_outillage_mouvement(req: Request, res: Response) {
    const { Num_Mouvement } = req.body;
    const { id_Societe } = req.params;
    let idSocNum = Number(id_Societe || "3068");
    if (isNaN(idSocNum) || idSocNum <= 0) {
        return res.send({ result: false, message: "id_Societe invalide" });
    }

    await lireSql(
        `delete from RH_Outillage_Mouvement_Detail where Num_Mouvement=@Num_Mouvement and id_Societe=@p_id_Societe`,
        [
            { param: "Num_Mouvement", sqlType: NVarChar, valeur: Num_Mouvement },
            { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
        ]
    );

    const rsl = await lireSql(
        `delete from RH_Outillage_Mouvement where Num_Mouvement=@Num_Mouvement and id_Societe=@p_id_Societe`,
        [
            { param: "Num_Mouvement", sqlType: NVarChar, valeur: Num_Mouvement },
            { param: "p_id_Societe", sqlType: Int, valeur: idSocNum },
        ]
    );

    if (rsl.result) {
        return res.send({ result: true, data: Num_Mouvement });
    } else return res.send({ result: false, data: rsl.sort });
}
