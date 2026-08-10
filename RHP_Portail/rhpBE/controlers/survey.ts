
import { Request, Response } from 'express';
import { lireSql } from "../modules/module_sqlRW";
import { Float, Int, NVarChar } from "mssql";


export const surveyQuestions = async (req: Request, res: Response) => {
    const { cod_survey } = req.query;
    const { id_Societe } = req.params;
    const qst_sql = `select row_number() over(order by Rang asc) as NumQuestion, isnull(Typ_Reponse, '') as Typ_Reponse, RowId as Cod_Question, isnull(Question, '') as Question, isnull(Sous_Question, '') as Sous_Question,
    isnull(Reponses_Possibles, '') as Reponses_Possibles, convert(bit,case when isnull(Obligatoire_Si, '') <> '' then 'false' else isnull(Obligatoire, 'false') end) as Obligatoire,
    isnull(AvecNote, 'false') as AvecNote, isnull(Mode_Scoring, 'na') as Mode_Scoring, isnull(Max_Score, 0) as Max_Score, isnull(Func_Scoring, '') as Func_Scoring, isnull(Coef, 1) as Coef, isnull(Obligatoire_Si, '') as Obligatoire_Si,
    isnull(Erreur_Si, '') as Erreur_Si, isnull(Erreur_Msg, '') as Erreur_Msg, isnull(Agregation_Scoring, '') as Agregation_Scoring, isnull(Structure_Reponse, 'h6') as Structure_Reponse
from Survey_Detail d
outer apply(select top 1 AvecNote from Survey s where s.Cod_Survey = d.Cod_Survey)q
where Cod_Survey = @cod_survey and id_Societe = @idSoc
order by isnull(Rang, 0)`;
    const rsl = await lireSql(
        qst_sql,
        [{ param: "cod_survey", sqlType: NVarChar, valeur: cod_survey },
        { param: "idSoc", sqlType: Int, valeur: id_Societe }
        ]
    );
    return res.send({ result: rsl.result, data: rsl.data });
};
export const surveyAnswers = async (req: Request, res: Response) => {
    const { cod_survey, cod_reply } = req.query;
    const { id_Societe } = req.params;
    const ans_sql = `SELECT  Cod_Reply, Cod_Question, isnull(Num_Sous_Question, '0') as Num_Sous_Question,
    isnull(Reponses, '') as Reponses, isnull(Note, 0) as Note, isnull(Coef, 1) as Coef, isnull(Note_Totale, 0) as Note_Totale, isnull(Statut, '') as Statut, isnull(Paie_Calculee, 'false') as Paie_Calculee
FROM Survey_Reply_Detail d
outer apply(select Statut, Paie_Calculee, Cod_Survey from Survey_Reply where Cod_Reply = d.Cod_Reply and id_Societe = @idSoc)e
where Cod_Survey = @cod_survey and Cod_Reply = @cod_reply`;
    const rsl = await lireSql(
        ans_sql,
        [{ param: "cod_survey", sqlType: NVarChar, valeur: cod_survey },
        { param: "idSoc", sqlType: Int, valeur: id_Societe },
        { param: "cod_reply", sqlType: Int, valeur: cod_reply }
        ]
    );

    return res.send({ result: rsl.result, data: rsl.data });
};

export const surveyAnswersSave = async (req: Request, res: Response) => {
    const { cod_survey, cod_reply, answers, evalue, evaluateur, ref_evaluation, typ_survey } = req.body;
    // Note: User snippet usually gets idSoc from params or user context.
    const idSoc = req.params.id_Societe || 1;

    const login = req.params.login || "System";
    const typEvalue = typ_survey || 'E'; // Default to 'E' if not provided

    if (!cod_survey) return res.send({ result: false, data: ["Code évaluation vide."] });

    // Generate Flg_Maj (Batch ID)
    const flg_maj = Math.floor(Math.random() * 2147483647); // Random positive 32-bit integer

    // 1. Récupérer les questions AVANT toute écriture.
    // Si le formulaire est introuvable, on ne touche ni à l'en-tête ni aux réponses
    // existantes (sinon l'évaluation serait vidée puis affichée comme "renseignée").
    const qstSql2 = `select row_number() over(order by Rang asc) as NumQuestion, * from Survey_Detail d where Cod_Survey = @cod_survey and id_Societe = @idSoc order by isnull(Rang, 0)`;
    const rslQsts2 = await lireSql(qstSql2, [
        { param: "cod_survey", sqlType: NVarChar, valeur: cod_survey },
        { param: "idSoc", sqlType: Int, valeur: idSoc }
    ]);

    if (!rslQsts2.result) {
        console.error("DEBUG Questions Fetch Error:", rslQsts2.sort);
        return res.send({ result: false, data: ["Error fetching survey details"] });
    }

    const questionsList = rslQsts2.data || [];
    if (questionsList.length === 0) {
        return res.send({ result: false, data: ["Formulaire d'évaluation introuvable. Enregistrement annulé pour préserver les réponses existantes."] });
    }

    // 2. Préparer toutes les lignes de réponses à insérer.
    // Si aucune réponse ne correspond aux questions du formulaire, on annule tout :
    // insérer un en-tête vide ou supprimer l'ancien lot viderait l'évaluation.
    let rang = 0;
    const preparedRows: { param: string; sqlType: any; valeur: any }[][] = [];

    for (const qDef of questionsList) {
        const qNum = qDef.NumQuestion;
        const ansState = answers?.[qNum];

        if (!ansState) continue;

        const val = ansState.value;
        const noteData = ansState.note || { note: 0, coef: 0, note_totale: 0 };

        let rowsToInsert: { num: string, val: string }[] = [];

        if (Array.isArray(val)) {
            val.forEach((v, i) => {
                let s = Array.isArray(v) ? v.join(';') : String(v);
                rowsToInsert.push({ num: String(i), val: s });
            });
        } else {
            rowsToInsert.push({ num: "0", val: String(val || "") });
        }

        for (const row of rowsToInsert) {
            let reponseStr = row.val;
            let valeurReponse = reponseStr;
            const typs = ['grille_cases', 'cocher', 'oui_non', 'vrai_faux', 'echelle', 'grille_choix', 'choix'];

            if (typs.includes(qDef.Typ_Reponse) && qDef.Reponses_Possibles) {
                const opts = qDef.Reponses_Possibles.split(';');
                const chosen = reponseStr.split(';');
                let decoded = "";
                for (let i = 0; i < chosen.length; i++) {
                    if (chosen[i] == "1" && opts[i]) {
                        decoded += (decoded ? ";" : "") + opts[i];
                    }
                }
                if (decoded) valeurReponse = decoded;
            }

            preparedRows.push([
                { param: "cod_question", sqlType: NVarChar, valeur: String(qDef.RowId) },
                { param: "question", sqlType: NVarChar, valeur: qDef.Question },
                { param: "obligatoire", sqlType: NVarChar, valeur: qDef.Obligatoire ? "true" : "false" },
                { param: "typ_reponse", sqlType: NVarChar, valeur: qDef.Typ_Reponse },
                { param: "num_sous", sqlType: NVarChar, valeur: row.num },
                { param: "reponses", sqlType: NVarChar, valeur: reponseStr },
                { param: "valeur_reponse", sqlType: NVarChar, valeur: valeurReponse },
                { param: "note", sqlType: Float, valeur: noteData.note || 0 },
                { param: "coef", sqlType: Float, valeur: noteData.coef || 1 },
                { param: "note_totale", sqlType: Float, valeur: noteData.note_totale || 0 },
                { param: "rang", sqlType: Int, valeur: rang++ },
                { param: "flg_maj", sqlType: NVarChar, valeur: flg_maj.toString() }
            ]);
        }
    }

    if (preparedRows.length === 0) {
        return res.send({ result: false, data: ["Aucune réponse à enregistrer pour ce formulaire. Enregistrement annulé pour préserver les réponses existantes."] });
    }

    // 3. Header Handling
    // Check existence
    let currentCodReply = 0;
    // Mémorise si l'en-tête a été créé par cet appel : en cas d'échec
    // d'insertion des détails, il sera supprimé pour éviter une réponse vide
    // orpheline (évaluation "renseignée" mais sans aucune réponse en base).
    let headerCreated = false;

    // Use Composite Key (Cod_Survey + Ref_Evaluation + Evalue + Evaluateur)
    // Fix: Handle cases where Ref_Evaluation might be NULL in older records, and strictly check Typ_Evalue
    let checkSql = `select top 1 Cod_Reply, convert(bit, isnull(Paie_Calculee, 0)) as Paie_Calculee 
                    from Survey_Reply 
                    where Cod_Survey = @cod_survey
                      and (Ref_Evaluation = @ref_evaluation OR Ref_Evaluation IS NULL OR Ref_Evaluation = '')
                      and Evalue = @evalue 
                      and Evaluateur = @evaluateur 
                      and Typ_Evalue = @typEvalue
                      and id_Societe = @idSoc
                    order by Cod_Reply desc`; // Pick latest if duplicates exist

    let exists = false;

    const rslCheck = await lireSql(checkSql, [
        { param: "cod_survey", sqlType: NVarChar, valeur: cod_survey },
        { param: "ref_evaluation", sqlType: NVarChar, valeur: ref_evaluation },
        { param: "evalue", sqlType: NVarChar, valeur: evalue },
        { param: "evaluateur", sqlType: NVarChar, valeur: evaluateur },
        { param: "typEvalue", sqlType: NVarChar, valeur: typEvalue },
        { param: "idSoc", sqlType: Int, valeur: idSoc }
    ]);

    if (rslCheck.result && rslCheck.data.length > 0) {
        exists = true;
        currentCodReply = rslCheck.data[0].Cod_Reply;
        if (rslCheck.data[0].Paie_Calculee) return res.send({ result: false, data: ["Cette évaluation concerne une paie déjà calculée."] });
    }

    let headerSql = "";
    if (!exists) {
        // ... (INSERT block logs are already there) ...
        // INSERT
        headerSql = `insert into Survey_Reply(id_Societe, Cod_Survey, Dat_Crea, Created_By, Evaluateur, Typ_Evalue, Evalue, Ref_Evaluation, Statut, Note, Coef, Note_Totale, Dat_Survey, Dat_Modif, Modified_By, Flg_Maj)
values(@idSoc, @cod_survey, getdate(), @login, @evaluateur, @typEvalue, @evalue, @ref_evaluation, '', 0, 1, 0, getdate(), getdate(), @login, @flg_maj);
        SELECT SCOPE_IDENTITY() as NewId; `;

        const rslHeader = await lireSql(headerSql, [
            { param: "idSoc", sqlType: Int, valeur: idSoc },
            { param: "cod_survey", sqlType: NVarChar, valeur: cod_survey },
            { param: "login", sqlType: NVarChar, valeur: login },
            { param: "evaluateur", sqlType: NVarChar, valeur: evaluateur },
            { param: "typEvalue", sqlType: NVarChar, valeur: typEvalue },
            { param: "evalue", sqlType: NVarChar, valeur: evalue },
            { param: "ref_evaluation", sqlType: NVarChar, valeur: ref_evaluation },
            { param: "flg_maj", sqlType: NVarChar, valeur: flg_maj.toString() }
        ]);

        if (rslHeader.result && rslHeader.data.length > 0) {
            currentCodReply = rslHeader.data[0].NewId;
            headerCreated = true;
        } else {
            return res.send({ result: false, data: [rslHeader.sort] });
        }

    } else {
        // UPDATE
        headerSql = `update Survey_Reply set
Evaluateur = @evaluateur, Typ_Evalue = @typEvalue, Evalue = @evalue, Ref_Evaluation = @ref_evaluation, Statut = '',
    Dat_Modif = getdate(), Modified_By = @login, Flg_Maj = @flg_maj
            where Cod_Reply = @cod_reply`;

        const rslUpd = await lireSql(headerSql, [
            { param: "evaluateur", sqlType: NVarChar, valeur: evaluateur },
            { param: "typEvalue", sqlType: NVarChar, valeur: typEvalue },
            { param: "evalue", sqlType: NVarChar, valeur: evalue },
            { param: "ref_evaluation", sqlType: NVarChar, valeur: ref_evaluation },
            { param: "login", sqlType: NVarChar, valeur: login },
            { param: "flg_maj", sqlType: NVarChar, valeur: flg_maj.toString() },
            { param: "cod_reply", sqlType: Int, valeur: currentCodReply }
        ]);
    }

    const insertPromises: Promise<any>[] = [];

    for (const rowParams of preparedRows) {
        const sqlIns = `insert into Survey_Reply_Detail(Cod_Reply, Cod_Question, Question, Obligatoire, Typ_Reponse, Num_Sous_Question, Reponses, Valeur_Reponse, Note, Coef, Note_Totale, Rang, Flg_Maj)
values(@cod_reply, @cod_question, @question, @obligatoire, @typ_reponse, @num_sous, @reponses, @valeur_reponse, @note, @coef, @note_totale, @rang, @flg_maj)`;

        insertPromises.push(lireSql(sqlIns, [
            { param: "cod_reply", sqlType: Int, valeur: currentCodReply },
            ...rowParams
        ]).then((res) => {
            if (!res.result) {
                console.error(`INSERT ERROR[Reply:${currentCodReply}]: `, res.sort);
            }
            return res;
        }));
    }

    try {
        const results = await Promise.all(insertPromises);
        const allSuccess = results.every(r => r.result);

        if (!allSuccess) {
            // Annuler le nouveau lot partiel : les anciennes réponses (Flg_Maj différent) sont conservées
            await lireSql(`delete from Survey_Reply_Detail where Cod_Reply = @cod_reply and Flg_Maj = @flg_maj`, [
                { param: "cod_reply", sqlType: Int, valeur: currentCodReply },
                { param: "flg_maj", sqlType: NVarChar, valeur: flg_maj.toString() }
            ]);
            // Supprimer aussi l'en-tête s'il vient d'être créé (pas d'ancien lot à préserver)
            if (headerCreated) {
                await lireSql(`delete from Survey_Reply where Cod_Reply = @cod_reply`, [
                    { param: "cod_reply", sqlType: Int, valeur: currentCodReply }
                ]);
            }
            return res.send({ result: false, data: ["Erreur lors de l'enregistrement de certaines réponses."] });
        }
    } catch (error) {
        // Annuler le nouveau lot partiel en cas d'exception
        await lireSql(`delete from Survey_Reply_Detail where Cod_Reply = @cod_reply and Flg_Maj = @flg_maj`, [
            { param: "cod_reply", sqlType: Int, valeur: currentCodReply },
            { param: "flg_maj", sqlType: NVarChar, valeur: flg_maj.toString() }
        ]);
        // Supprimer aussi l'en-tête s'il vient d'être créé (pas d'ancien lot à préserver)
        if (headerCreated) {
            await lireSql(`delete from Survey_Reply where Cod_Reply = @cod_reply`, [
                { param: "cod_reply", sqlType: Int, valeur: currentCodReply }
            ]);
        }
        return res.send({ result: false, data: [error] });
    }

    // Supprimer l'ancien lot uniquement après insertion réussie du nouveau :
    // en cas d'échec d'insertion, les réponses précédentes sont ainsi conservées
    const deleteSql = `delete from Survey_Reply_Detail where Cod_Reply = @cod_reply and isnull(Flg_Maj, 0) <> @flg_maj`;
    await lireSql(deleteSql, [
        { param: "cod_reply", sqlType: Int, valeur: currentCodReply },
        { param: "flg_maj", sqlType: NVarChar, valeur: flg_maj.toString() }
    ]);

    return res.send({ result: true, data: [{ Cod_Reply: currentCodReply }] });
};