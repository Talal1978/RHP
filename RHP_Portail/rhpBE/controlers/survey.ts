
import { Request, Response } from 'express';
import { lireSql } from "../modules/module_sqlRW";
import { Int, NVarChar } from "mssql";


export const surveyQuestions = async (req: Request, res: Response) => {
    const { cod_survey } = req.query;
    const { id_Societe } = req.params;
    const qst_sql = `select row_number() over(order by Rang asc) as NumQuestion, isnull(Typ_Reponse, '') as Typ_Reponse, RowId as Cod_Question, isnull(Question, '') as Question, isnull(Sous_Question, '') as Sous_Question,
    isnull(Reponses_Possibles, '') as Reponses_Possibles, convert(bit,case when isnull(Obligatoire_Si, '') <> '' then 'false' else isnull(Obligatoire, 'false') end) as Obligatoire,
    isnull(AvecNote, 'false') as AvecNote, isnull(Mode_Scoring, 'na') as Mode_Scoring, isnull(Max_Score, 0) as Max_Score, isnull(Func_Scoring, '') as Func_Scoring, isnull(Coef, 1) as Coef, isnull(Obligatoire_Si, '') as Obligatoire_Si,
    isnull(Erreur_Si, '') as Erreur_Si, isnull(Erreur_Msg, '') as Erreur_Msg
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
    const { cod_survey, cod_reply, answers, evalue, evaluateur, ref_evaluation } = req.body;
    // Note: User snippet usually gets idSoc from params or user context.
    const idSoc = req.params.id_Societe || 1;

    const login = req.params.login || "System";
    if (!cod_survey) return res.send({ result: false, data: ["Code évaluation vide."] });

    // Generate Flg_Maj (Batch ID)
    const flg_maj = Math.floor(Math.random() * 2147483647); // Random positive 32-bit integer

    // 2. Header Handling
    // Check existence
    let currentCodReply = 0;

    // Use Composite Key (Ref_Evaluation + Evalue + Evaluateur)
    let checkSql = `select Cod_Reply, convert(bit, isnull(Paie_Calculee, 0)) as Paie_Calculee 
                    from Survey_Reply 
                    where Ref_Evaluation = @ref_evaluation 
                      and Evalue = @evalue 
                      and Evaluateur = @evaluateur 
                      and id_Societe = @idSoc`;

    let exists = false;

    const rslCheck = await lireSql(checkSql, [
        { param: "ref_evaluation", sqlType: NVarChar, valeur: ref_evaluation },
        { param: "evalue", sqlType: NVarChar, valeur: evalue },
        { param: "evaluateur", sqlType: NVarChar, valeur: evaluateur },
        { param: "idSoc", sqlType: Int, valeur: idSoc }
    ]);

    if (rslCheck.result && rslCheck.data.length > 0) {
        exists = true;
        currentCodReply = rslCheck.data[0].Cod_Reply;
        if (rslCheck.data[0].Paie_Calculee) return res.send({ result: false, data: ["Cette évaluation concerne une paie déjà calculée."] });
    }

    let headerSql = "";
    if (!exists) {
        // INSERT
        headerSql = `insert into Survey_Reply(id_Societe, Cod_Survey, Dat_Crea, Created_By, Evaluateur, Typ_Evalue, Evalue, Ref_Evaluation, Statut, Note, Coef, Note_Totale, Dat_Survey, Dat_Modif, Modified_By, Flg_Maj)
values(@idSoc, @cod_survey, getdate(), @login, @evaluateur, 'E', @evalue, @ref_evaluation, '', 0, 1, 0, getdate(), getdate(), @login, @flg_maj);
        SELECT SCOPE_IDENTITY() as NewId; `;

        const rslHeader = await lireSql(headerSql, [
            { param: "idSoc", sqlType: Int, valeur: idSoc },
            { param: "cod_survey", sqlType: NVarChar, valeur: cod_survey },
            { param: "login", sqlType: NVarChar, valeur: login },
            { param: "evaluateur", sqlType: NVarChar, valeur: evaluateur },
            { param: "evalue", sqlType: NVarChar, valeur: evalue },
            { param: "ref_evaluation", sqlType: NVarChar, valeur: ref_evaluation },
            { param: "flg_maj", sqlType: NVarChar, valeur: flg_maj.toString() }
        ]);

        if (rslHeader.result && rslHeader.data.length > 0) {
            currentCodReply = rslHeader.data[0].NewId;
        } else {
            return res.send({ result: false, data: [rslHeader.sort] });
        }

    } else {
        // UPDATE
        headerSql = `update Survey_Reply set
Evaluateur = @evaluateur, Typ_Evalue = 'E', Evalue = @evalue, Ref_Evaluation = @ref_evaluation, Statut = '',
    Dat_Modif = getdate(), Modified_By = @login, Flg_Maj = @flg_maj
            where Cod_Reply = @cod_reply`;

        await lireSql(headerSql, [
            { param: "evaluateur", sqlType: NVarChar, valeur: evaluateur },
            { param: "evalue", sqlType: NVarChar, valeur: evalue },
            { param: "ref_evaluation", sqlType: NVarChar, valeur: ref_evaluation },
            { param: "login", sqlType: NVarChar, valeur: login },
            { param: "flg_maj", sqlType: NVarChar, valeur: flg_maj.toString() },
            { param: "cod_reply", sqlType: Int, valeur: currentCodReply }
        ]);
    }

    const deleteSql = `delete from Survey_Reply_Detail where Cod_Reply = @cod_reply and isnull(Flg_Maj, 0) <> @flg_maj`;
    await lireSql(deleteSql, [
        { param: "cod_reply", sqlType: Int, valeur: currentCodReply },
        { param: "flg_maj", sqlType: NVarChar, valeur: flg_maj.toString() }
    ]);

    const qstSql2 = `select row_number() over(order by Rang asc) as NumQuestion, * from Survey_Detail d where Cod_Survey = @cod_survey and id_Societe = @idSoc order by isnull(Rang, 0)`;
    const rslQsts2 = await lireSql(qstSql2, [
        { param: "cod_survey", sqlType: NVarChar, valeur: cod_survey },
        { param: "idSoc", sqlType: Int, valeur: idSoc }
    ]);
    const questionsList = rslQsts2.data || [];
    let rang = 0;

    const insertPromises: Promise<any>[] = [];

    for (const qDef of questionsList) {
        const qNum = qDef.NumQuestion;
        const ansState = answers[qNum];
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

            const sqlIns = `insert into Survey_Reply_Detail(Cod_Reply, Cod_Question, Question, Obligatoire, Typ_Reponse, Num_Sous_Question, Reponses, Valeur_Reponse, Note, Coef, Note_Totale, Rang, Flg_Maj)
values(@cod_reply, @cod_question, @question, @obligatoire, @typ_reponse, @num_sous, @reponses, @valeur_reponse, @note, @coef, @note_totale, @rang, @flg_maj)`;

            insertPromises.push(lireSql(sqlIns, [
                { param: "cod_reply", sqlType: Int, valeur: currentCodReply },
                { param: "cod_question", sqlType: NVarChar, valeur: String(qDef.RowId) },
                { param: "question", sqlType: NVarChar, valeur: qDef.Question },
                { param: "obligatoire", sqlType: NVarChar, valeur: qDef.Obligatoire ? "true" : "false" },
                { param: "typ_reponse", sqlType: NVarChar, valeur: qDef.Typ_Reponse },
                { param: "num_sous", sqlType: NVarChar, valeur: row.num },
                { param: "reponses", sqlType: NVarChar, valeur: reponseStr },
                { param: "valeur_reponse", sqlType: NVarChar, valeur: valeurReponse },
                { param: "note", sqlType: Int, valeur: noteData.note || 0 }, // Float?
                { param: "coef", sqlType: Int, valeur: noteData.coef || 1 },
                { param: "note_totale", sqlType: Int, valeur: noteData.note_totale || 0 },
                { param: "rang", sqlType: Int, valeur: rang++ },
                { param: "flg_maj", sqlType: NVarChar, valeur: flg_maj.toString() }
            ], true).then((res) => {
                if (!res.result) {
                    console.error(`INSERT ERROR[Q:${qDef.RowId} Sub:${row.num}]: `, res.sort);
                }
                return res;
            }));
        }
    }

    try {
        const results = await Promise.all(insertPromises);
        const allSuccess = results.every(r => r.result);

        if (!allSuccess) {
            return res.send({ result: false, data: ["Erreur lors de l'enregistrement de certaines réponses."] });
        }
    } catch (error) {
        return res.send({ result: false, data: [error] });
    }

    return res.send({ result: true, data: [{ Cod_Reply: currentCodReply }] });
};