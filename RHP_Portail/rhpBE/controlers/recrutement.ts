import { Request, Response } from "express";
import { ecrireSql, lireSql, controleInjection } from "../modules/module_sqlRW";
import { Int, NVarChar, SmallDateTime, Float, Bit } from "mssql";
import { sousmettre_signature } from "../modules/module_workflow";
import { estDate, toSqlDateFormat } from "../modules/module_format";
import { IsNull } from "../modules/module_general";

export async function get_recrutement_demande(req: Request, res: Response) {
    const { Num_DR } = req.body;
    const { id_Societe } = req.params;

    if (controleInjection(Num_DR).result === false) return res.send({ result: false, message: "Injection détectée dans Num_DR" });
    if (controleInjection(id_Societe).result === false) return res.send({ result: false, message: "Injection détectée dans id_Societe" });

    const sqlStr = `SELECT * FROM Recrutement_Demande WHERE Num_DR = @Num_DR AND id_Societe = @id_Societe`;

    const rsl = await lireSql(sqlStr, [
        { param: "Num_DR", sqlType: NVarChar, valeur: Num_DR },
        { param: "id_Societe", sqlType: Int, valeur: id_Societe },
    ]);

    return res.send(rsl);
}

export async function get_recrutement_demande_liste(req: Request, res: Response) {
    const { Matricule, Cod_Entite, Statut, Dat_Du, Dat_Au } = req.body;
    const { id_Societe } = req.params;
    let sWhere = "v.id_Societe=@id_Societe";
    let params: any[] = [{ param: "id_Societe", sqlType: Int, valeur: id_Societe }];

    if (Matricule) {
        sWhere += " AND v.Matricule=@Matricule";
        params.push({ param: "Matricule", sqlType: NVarChar, valeur: Matricule });
    }

    if (Cod_Entite) {
        // Matching logic: if filtering by entity, check if agent belongs to it? 
        // The VB logic was: exists(select Matricule from RH_Agent where ... isnull(Cod_Entite,'') = Cod_Entite_txt)
        // I will implement a direct filter on Cod_Entite_DR or implicit permission logic if required, 
        // but typically for the list based on filter input 'Cod_Entite', we filter the requests made by that entity or for that entity? 
        // VB Logic: and exists(select Matricule from RH_Agent where id_Societe=v.id_Societe and Matricule=v.Matricule and isnull(Cod_Entite,'') ='" & Cod_Entite_txt.Text & "')"
        // This suggests filtering requests where the *REQUESTER* (`v.Matricule`) belongs to the selected `Cod_Entite`.

        sWhere += " AND EXISTS (SELECT 1 FROM RH_Agent a WHERE a.id_Societe=v.id_Societe AND a.Matricule=v.Matricule AND ISNULL(a.Cod_Entite,'') = @Cod_Entite)";
        params.push({ param: "Cod_Entite", sqlType: NVarChar, valeur: Cod_Entite });
    }

    if (Dat_Du) {
        sWhere += " AND v.Dat_DR >= @Dat_Du";
        params.push({ param: "Dat_Du", sqlType: SmallDateTime, valeur: toSqlDateFormat(Dat_Du) });
    }

    if (Dat_Au) {
        sWhere += " AND v.Dat_DR <= @Dat_Au";
        params.push({ param: "Dat_Au", sqlType: SmallDateTime, valeur: toSqlDateFormat(Dat_Au) });
    }

    if (Statut) {
        sWhere += " AND ISNULL(v.Statut,'') = @Statut";
        params.push({ param: "Statut", sqlType: NVarChar, valeur: Statut });
    }

    const sqlStr = `
        SELECT 
            v.Num_DR as 'N° demande', 
            v.Matricule, 
            r.Nom, 
            dbo.FindRubrique('Statut_Signature',v.Statut) as Statut, 
            v.Dat_DR as 'Date', 
            v.Lib_DR as Intitulé, 
            e.Lib_Entite as Entité, 
            v.Titre_DR as Titre,  
            ISNULL(f.Lib_Poste,'') as Poste, 
            ISNULL(g.Lib_Grade,'') as Grade, 
            v.Nb_Personne as Nombre
        FROM Recrutement_Demande v
        OUTER APPLY (SELECT Nom_Agent + ' ' + Prenom_Agent as Nom FROM RH_Agent WHERE id_Societe=v.id_Societe AND Matricule=v.Matricule) r
        OUTER APPLY (SELECT Lib_Entite FROM Org_Entite WHERE id_Societe=v.id_Societe AND Cod_Entite=v.Cod_Entite_DR) e
        OUTER APPLY (SELECT Lib_Poste FROM Org_Poste WHERE id_Societe=v.id_Societe AND Cod_Poste=v.Cod_Poste_DR) f
        OUTER APPLY (SELECT Lib_Grade FROM Org_Grade WHERE id_Societe=v.id_Societe AND Cod_Grade=v.Cod_Grade_DR) g 
        WHERE ${sWhere} 
        ORDER BY v.Dat_DR DESC
    `;

    const rsl = await lireSql(sqlStr, params);
    return res.send(rsl);
}

export async function save_recrutement_demande(req: Request, res: Response) {
    const { entete } = req.body;
    const { id_Societe, Matricule } = req.params;

    let { Num_DR } = entete;

    // Validation Logic (similar to VB.NET)
    if (!entete.Matricule) return res.send({ result: false, message: "Matricule non renseigné" });
    if (!entete.Cod_Entite_DR) return res.send({ result: false, message: "Entité demandeuse non renseignée" });
    if (!entete.Cod_Grade_DR) return res.send({ result: false, message: "Grade demandé non renseigné" });

    if (entete.Duree_Indeterminee === false || entete.Duree_Indeterminee === 0) {
        if (!estDate(entete.Duree_Du) || !estDate(entete.Duree_Au)) {
            return res.send({ result: false, message: "Durée du contrat de travail non renseignée." });
        }
        if (new Date(entete.Duree_Au) < new Date(entete.Duree_Du)) {
            return res.send({ result: false, message: "Incohérence entre la date début et fin de la durée du contrat de travail." });
        }
    }

    if (entete.Age_Determine === true || entete.Age_Determine === 1) {
        const ageDu = parseFloat(entete.Age_Du || "0");
        const ageAu = parseFloat(entete.Age_Au || "0");
        if (ageDu < 18 || ageAu > 60) {
            return res.send({ result: false, message: "Age doit être compris entre 18 et 60 ans." });
        }
        if (ageAu < ageDu) {
            return res.send({ result: false, message: "Incohérence de la fourchette d'âge." });
        }
    }

    // Generate Num_DR if empty
    if (!Num_DR || Num_DR === "") {
        const year = new Date().getFullYear();
        const sqlRacine = `select isnull(max(racine),0) as racine from (
        select convert(int, case when isnumeric(ISNULL(racine,''))!=1 then 0 else racine end ) as Racine 
        from Recrutement_Demande 
        outer apply(select charindex('_',Num_DR,1)-1 aa)a
        outer apply(select case when aa<0 then RIGHT(Num_DR,6) else RIGHT(left(Num_DR,aa),6) end as racine)n
        where id_Societe=@id_Societe and year(Dat_DR)=@year
    )f`;
        const rsNum = await lireSql(sqlRacine, [
            { param: "id_Societe", sqlType: Int, valeur: id_Societe },
            { param: "year", sqlType: Int, valeur: year }
        ]);
        const racine = (rsNum.data && rsNum.data.length > 0) ? rsNum.data[0].racine : 0;
        const nextVal = parseInt(racine) + 1;
        const formattedVal = nextVal.toString().padStart(6, '0');
        Num_DR = `DR${id_Societe}-${year}${formattedVal}`;
    }

    const oDat = new Date();

    // Prepare fields for saving
    const fields = {
        ...entete,
        Num_DR,
        id_Societe,
        Dat_Modif: oDat,
        Modified_By: Matricule, // utilizing the logged-in user
        Dat_Crea: entete.Dat_Crea ? entete.Dat_Crea : oDat,
        Created_By: entete.Created_By ? entete.Created_By : Matricule,

        // Formatting Dates
        Dat_DR: toSqlDateFormat(entete.Dat_DR),
        Duree_Du: entete.Duree_Indeterminee ? null : toSqlDateFormat(entete.Duree_Du),
        Duree_Au: entete.Duree_Indeterminee ? null : toSqlDateFormat(entete.Duree_Au),

        // Handling Booleans
        Duree_Indeterminee: entete.Duree_Indeterminee,
        Age_Determine: entete.Age_Determine,

        // Defaults
        Buget_Salaire: parseFloat(entete.Buget_Salaire || "0"),
        Nb_Personne: parseInt(entete.Nb_Personne || "1"),
        Age_Du: entete.Age_Determine ? entete.Age_Du : 18,
        Age_Au: entete.Age_Determine ? entete.Age_Au : 59,
        Motif_DR: (!entete.Motif_DR || entete.Motif_DR === "") ? "N" : entete.Motif_DR,
    };

    // Using ecrireSql to Upsert
    const rsEnt = await ecrireSql({
        tableName: "Recrutement_Demande",
        fields: fields,
        joinFields: ["Num_DR", "id_Societe"],
        excludeFields: [], // Add fields to exclude if any
        login: Matricule,
    });

    if (rsEnt.result) {
        if (entete.Statut === "SS") {
            await sousmettre_signature("DR", Num_DR, id_Societe, Matricule);
        }
        return res.send({ result: true, data: Num_DR, message: "Enregistré avec succès" });
    } else {
        return res.send(rsEnt);
    }
}

export async function delete_recrutement_demande(req: Request, res: Response) {
    const { Num_DR } = req.body;
    const { id_Societe, Matricule } = req.params;

    // Insert into mouchard first (as per VB code)
    await lireSql(`insert into Mouchard_Suppression (Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date) values ('Recrutement_Demande', 'Num_DR', @Num_DR, @Deleted_by, getdate())`, [
        { param: "Num_DR", sqlType: NVarChar, valeur: Num_DR },
        { param: "Deleted_by", sqlType: NVarChar, valeur: Matricule } // Assuming Matricule or ID is used
    ]);

    const rsl = await lireSql(
        `delete from Recrutement_Demande where Num_DR=@Num_DR and id_Societe=@id_Societe`,
        [
            { param: "Num_DR", sqlType: NVarChar, valeur: Num_DR },
            { param: "id_Societe", sqlType: Int, valeur: id_Societe }
        ]
    );

    if (rsl.result) {
        return res.send({ result: true, data: Num_DR });
    } else return res.send({ result: false, message: rsl.sort });
}
