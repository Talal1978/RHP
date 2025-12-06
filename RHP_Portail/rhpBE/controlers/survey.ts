import { Request, Response } from 'express';
import { lireSql } from "../modules/module_sqlRW";
import { Int, NVarChar, VarBinary } from "mssql";


export const surveyQuestions = async (req: Request, res: Response) => {
    const { cod_survey } = req.query;
    const { id_Societe } = req.params;
    const qst_sql = `select row_number () over(order by Rang asc) as NumQuestion, isnull(Typ_Reponse,'') as Typ_Reponse,RowId as Cod_Question, isnull(Question,'') as Question ,isnull(Sous_Question,'') as Sous_Question,
isnull(Reponses_Possibles,'') as Reponses_Possibles,convert(bit,case when isnull(Obligatoire_Si,'')<>'' then 'false' else isnull(Obligatoire,'false') end) as Obligatoire, 
isnull(AvecNote,'false') as AvecNote,isnull(Mode_Scoring,'na') as Mode_Scoring, isnull(Max_Score,0) as Max_Score, isnull(Func_Scoring,'') as Func_Scoring , isnull(Coef,1) as Coef, isnull(Obligatoire_Si,'') as Obligatoire_Si,
isnull(Erreur_Si,'') as Erreur_Si, isnull(Erreur_Msg,'') as Erreur_Msg
from Survey_Detail d
outer apply (select top 1 AvecNote from Survey s where s.Cod_Survey=d.Cod_Survey)q
where Cod_Survey=@cod_survey and id_Societe=@idSoc
order by isnull(Rang,0)`;
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
      const ans_sql = `SELECT  Cod_Reply, Cod_Question, isnull(Num_Sous_Question,'0') as Num_Sous_Question, 
isnull(Reponses,'') as Reponses, isnull(Note,0) as Note, isnull(Coef,1) as Coef, isnull(Note_Totale,0) as Note_Totale, isnull(Statut,'') as Statut, isnull(Paie_Calculee,'false') as Paie_Calculee
FROM Survey_Reply_Detail d
outer apply (select Statut, Paie_Calculee, Cod_Survey from Survey_Reply where Cod_Reply=d.Cod_Reply and id_Societe=@idSoc)e
where Cod_Survey=@cod_survey and Cod_Reply=@cod_reply`;
    const rsl = await lireSql(
        ans_sql,
        [{ param: "cod_survey", sqlType: NVarChar, valeur: cod_survey },
        { param: "idSoc", sqlType: Int, valeur: id_Societe },
        { param: "cod_reply", sqlType: Int, valeur: cod_reply }
        ]
    );

    return res.send({ result: rsl.result, data: rsl.data });
};