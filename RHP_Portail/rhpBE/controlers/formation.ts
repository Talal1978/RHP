
import { Request, Response } from "express";
import { lireSql } from "../modules/module_sqlRW";
import { Int, NVarChar } from "mssql";

export const formation_evaluation_context = async (req: Request, res: Response) => {
    const { processId, ...theAgent } = req.params;
    let idSoc = theAgent?.id_Societe || "0000";
    let Matricule = theAgent?.Matricule;

    // Logic adapted from Formation_Evaluation.vb Request() and Load
    // 1. Find the formation (Cloturee, Present, User is participant)
    // 2. Find the Survey linked to it
    // 3. Find existing Reply if any

    let sqlStr = `
    select top 1 
        f.Cod_Formation, 
        f.Lib_Formation, 
        dbo.FindLibelle('Cod_Survey', 'Cod_Formation', f.Cod_Formation, 'Formation') as Cod_Survey,
        s.Lib_Survey,
        s.Preambule,
        r.Cod_Reply,
        r.Dat_Survey,
        r.Statut,
        (select Nom_Agent + ' ' + Prenom_Agent from Rh_Agent where Matricule = @Matricule and id_Societe = @idSoc) as Nom_Evaluateur
    from Formation f
    left join Survey s on s.Cod_Survey = dbo.FindLibelle('Cod_Survey', 'Cod_Formation', f.Cod_Formation, 'Formation') and s.id_Societe = f.id_Societe
    left join Survey_Reply r on r.Cod_Survey = s.Cod_Survey 
          and r.Evaluateur = @Matricule 
          and r.Evalue = f.Cod_Formation
          and r.id_Societe = f.id_Societe
    where 
        isnull(f.Statut_Formation,'')='Cloturee' 
        and f.id_Societe = @idSoc 
        and f.Cod_Formation in (select Cod_Formation from Formation_Participants where id_Societe=@idSoc and isnull(Present,'false')='true' and Matricule = @Matricule)
    `;

    // Note: In VB, Cod_Reply = -1 if not found. SQL returns NULL if left join fails. Frontend usually handles NULL or we coalesce.

    const params: any[] = [
        { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
        { param: "idSoc", sqlType: NVarChar, valeur: idSoc } // Using NVarChar for idSoc as safe default or int if consistent
    ];

    try {
        const rsl = await lireSql(sqlStr, params);
        if (rsl.result && rsl.data && rsl.data.length > 0) {
            // Found a formation context
            const ctx = rsl.data[0];
            // Format for frontend
            res.send({
                result: true,
                data: {
                    cod_survey: ctx.Cod_Survey,
                    cod_evaluation: ctx.Cod_Formation, // In Formation context, Evaluation Code is Formation Code
                    lib_evaluation: ctx.Lib_Formation,
                    cod_reply: ctx.Cod_Reply || -1,
                    evalue: ctx.Cod_Formation, // Evaluated object is the Formation
                    nom_evalue: ctx.Lib_Formation,
                    evaluateur: Matricule,
                    nom_evaluateur: ctx.Nom_Evaluateur,
                    typ_survey: "F",
                    statut: ctx.Statut || ""
                }
            });
        } else {
            res.send({ result: false, message: "Aucune évaluation de formation trouvée pour ce collaborateur." });
        }
    } catch (error: any) {
        res.send({ result: false, message: error.message });
    }
};

export const formation_evaluation_liste = async (req: Request, res: Response) => {
    let {
        Cod_Formation,
        Matricule,
        Cod_Entite
    } = req.body;

    const { processId, ...theAgent } = req.params;
    let idSoc = theAgent?.id_Societe || "0000";

    let swhere = ` where f.id_Societe = @idSoc and isnull(f.Statut_Formation,'')='Cloturee' and isnull(fp.Present,'false')='true' `;

    const params: any[] = [
        { param: "idSoc", sqlType: Int, valeur: idSoc }
    ];

    if (Cod_Formation) {
        swhere += ` and f.Cod_Formation = @Cod_Formation`;
        params.push({ param: "Cod_Formation", sqlType: NVarChar, valeur: Cod_Formation });
    }

    if (Matricule) {
        swhere += ` and fp.Matricule = @Matricule`;
        params.push({ param: "Matricule", sqlType: NVarChar, valeur: Matricule });
    }

    // Attempt to filter by entity if provided? Note: Formation doesn't always track participant entity snapshot.
    // Assuming we might join Rh_Agent for current entity or trust provided criteria matches logic.

    let sqlStr = `
 select
                    fp.Matricule,
                    isnull(a.Nom_Agent,'') + ' ' + isnull(a.Prenom_Agent,'') as Nom_Complet,
                    fp.Present,
                    case when r.Statut is not null then r.Statut else 'Non évalué' end as Statut_Evaluation
                from Formation_Participants fp left join Formation f on f.Cod_Formation=fp.Cod_Formation and f.id_Societe=fp.id_Societe

                left join RH_Agent a on a.Matricule=fp.Matricule and a.id_Societe=fp.id_Societe
                left join Survey s on s.Cod_Survey = f.Cod_Survey  and s.id_Societe = fp.id_Societe
                left join Survey_Reply r on r.Cod_Survey = s.Cod_Survey
                    and r.Evaluateur = fp.Matricule
                    and r.Evalue = fp.Cod_Formation
                    and r.id_Societe = fp.id_Societe
    ${swhere}
    order by f.Dat_Du desc, f.Lib_Formation
    `;
    try {
        const rsl = await lireSql(sqlStr, params);
        res.send({
            result: true,
            data: rsl.data || [],
            fields: rsl.fields // Assuming lireSql returns fields metadata useful for Grille
        });
    } catch (error: any) {
        res.send({ result: false, message: error.message });
    }
};

export const get_formation_liste = async (req: Request, res: Response) => {
    const { processId, ...theAgent } = req.params;
    const {
        Matricule,
        Date_Du,
        Date_Au,
        Statut_Formation,
    } = req.body;

    let idSoc = theAgent?.id_Societe || "0000";
    let swhere = "where id_Societe=@idSoc";
    let params: any[] = [{ param: "idSoc", sqlType: Int, valeur: idSoc }];

    if (Matricule) {
        swhere += " and Cod_Formateur=@Matricule";
        params.push({ param: "Matricule", sqlType: NVarChar, valeur: Matricule });
    }

    if (Date_Du) {
        swhere += " and Dat_Du >= @Date_Du";
        params.push({ param: "Date_Du", sqlType: NVarChar, valeur: Date_Du });
    }

    if (Date_Au) {
        swhere += " and Dat_Du <= @Date_Au";
        params.push({ param: "Date_Au", sqlType: NVarChar, valeur: Date_Au });
    }

    if (Statut_Formation) {
        swhere += " and Statut_Formation=@Statut_Formation";
        params.push({ param: "Statut_Formation", sqlType: NVarChar, valeur: Statut_Formation });
    }

    const sql = `
        select 
            Cod_Formation, 
            Lib_Formation, 
            Dat_Du, 
            Dat_Au, 
            Budget, 
            Statut_Formation
        from Formation 
        ${swhere} 
        order by Dat_Du desc
    `;

    try {
        const result = await lireSql(sql, params);
        res.send(result);
    } catch (error: any) {
        res.send({ result: false, message: error.message });
    }
}

export const get_formation = async (req: Request, res: Response) => {
    const { processId, ...theAgent } = req.params;
    const { Cod_Formation } = req.body;
    let idSoc = theAgent?.id_Societe || "0000";

    try {
        console.log(`[DEBUG] get_formation: Cod_Formation=${Cod_Formation}, idSoc=${idSoc}`);

        // Headers
        const sqlHeader = `select * from Formation where Cod_Formation=@Cod_Formation and id_Societe=@idSoc`;
        const paramsHeader = [
            { param: "Cod_Formation", sqlType: NVarChar, valeur: Cod_Formation },
            { param: "idSoc", sqlType: Int, valeur: idSoc }
        ];
        const resHeader = await lireSql(sqlHeader, [...paramsHeader]); // Use spread to avoid reference issues


        if (resHeader.result && resHeader.data.length > 0) {
            let data = resHeader.data[0];

            // Participants - Include Evaluation Status
            const sqlParticipants = `
                select 
                    fp.Matricule, 
                    isnull(a.Nom_Agent,'') + ' ' + isnull(a.Prenom_Agent,'') as Nom_Complet,
                    case when isnull(fp.Present,'false')='true' then 'OK' else '' end as Present,
                    case when r.Statut is not null then 'OK' else '' end as Statut_Evaluation
                from Formation_Participants fp
                left join RH_Agent a on a.Matricule=fp.Matricule and a.id_Societe=fp.id_Societe
                left join Formation f on f.Cod_Formation = fp.Cod_Formation and f.id_Societe = fp.id_Societe
                left join Survey s on s.Cod_Survey = f.Cod_Survey and s.id_Societe = fp.id_Societe
                left join Survey_Reply r on r.Cod_Survey = s.Cod_Survey 
                    and r.Evaluateur = fp.Matricule 
                    and r.Evalue = fp.Cod_Formation
                    and r.id_Societe = fp.id_Societe
                where fp.Cod_Formation=@Cod_Formation and fp.id_Societe=@idSoc
            `;
            const resPart = await lireSql(sqlParticipants, [...paramsHeader]);

            data.Participants = resPart.data || [];
            data.Participants.forEach((p: any) => {
                p.Present === 'OK' ? p.Present = '✔' : p.Present = '';
                p.Statut_Evaluation === 'OK' ? p.Statut_Evaluation = '✔' : p.Statut_Evaluation = '';
            });
            // Modules / Competences
            const sqlModules = `
                select 
                    fm.Domaines_Competence,
                    dc.Lib_Domaines_Competence,
                    fm.Typ_Formation,
                    tf.Typ_Formation
                from Formation_Modules fm
                left join GPEC_Domaines_Competence dc on dc.Domaines_Competence=fm.Domaines_Competence and dc.id_Societe=fm.id_Societe
                left join Formation_Typ_Formation tf on tf.RowId=fm.Typ_Formation 
                where fm.Cod_Formation=@Cod_Formation and fm.id_Societe=@idSoc
            `;
            const resMod = await lireSql(sqlModules, [...paramsHeader]);
            data.Modules = resMod.data || [];

            // Financement
            const sqlFin = `
                select 
                    ff.Organisme,
                    ff.Montant
                from Formation_Financement ff
                where ff.Cod_Formation=@Cod_Formation and ff.id_Societe=@idSoc
            `;
            const resFin = await lireSql(sqlFin, [...paramsHeader]);
            data.Financement = resFin.data || [];

            res.send({ result: true, data: [data] });
        } else {
            console.log(`[DEBUG] No header data found`);
            res.send({ result: true, data: [] });
        }

    } catch (error: any) {
        res.send({ result: false, message: error.message });
    }
}
