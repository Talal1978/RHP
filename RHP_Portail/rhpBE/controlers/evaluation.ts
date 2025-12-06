import { Request, Response } from "express";
import { estDate, toSqlDateFormat } from "../modules/module_format";
import { lireSql } from "../modules/module_sqlRW";
import { NVarChar, SmallDateTime } from "mssql";

export const getEvaluationListe = async (req: Request, res: Response) => {
    let {
        Dat_Du,
        Dat_Au,
        Evaluateur,
        Evalue,
        Cod_Entite,
        Cod_Grade,
        Cod_Evaluation,
        Statut_Evaluation,
        Rd1,
        Rd2,
    } = req.body;

    const { processId, ...theAgent } = req.params;
    let idSoc = theAgent?.id_Societe || "0000";

    // Build WHERE clause based on logic
    let swhere = ` where id_Societe = ${idSoc}`;
    Dat_Du = estDate(Dat_Du)
        ? toSqlDateFormat(Dat_Du)
        : toSqlDateFormat(new Date(1900, 0, 1));
    Dat_Au = estDate(Dat_Au)
        ? toSqlDateFormat(Dat_Au)
        : toSqlDateFormat(new Date(2045, 11, 31));

    swhere += ` and (Dat_Du <= @Dat_Au or Dat_Au >= @Dat_Du) `;

    const params: any[] = [
        { param: "Dat_Du", sqlType: SmallDateTime, valeur: Dat_Du },
        { param: "Dat_Au", sqlType: SmallDateTime, valeur: Dat_Au },
    ];

    if (Evaluateur) {
        swhere += ` and Cod_Evaluateur = @Evaluateur`;
        params.push({ param: "Evaluateur", sqlType: NVarChar, valeur: Evaluateur });
    }

    if (Evalue) {
        swhere += ` and Matricule = @Evalue`;
        params.push({ param: "Evalue", sqlType: NVarChar, valeur: Evalue });
    }

    if (Cod_Entite) {
        swhere += ` and isnull(Cod_Entite,'') = @Cod_Entite`;
        params.push({ param: "Cod_Entite", sqlType: NVarChar, valeur: Cod_Entite });
    }

    if (Cod_Grade) {
        swhere += ` and isnull(Cod_Grade,'') = @Cod_Grade`;
        params.push({ param: "Cod_Grade", sqlType: NVarChar, valeur: Cod_Grade });
    }

    if (Cod_Evaluation) {
        swhere += ` and isnull(Cod_Evaluation,'') = @Cod_Evaluation`;
        params.push({ param: "Cod_Evaluation", sqlType: NVarChar, valeur: Cod_Evaluation });
    }

    if (Statut_Evaluation) {
        swhere += ` and isnull(Statut_Evaluation,'Planifiee') = @Statut_Evaluation`;
        params.push({ param: "Statut_Evaluation", sqlType: NVarChar, valeur: Statut_Evaluation });
    }

    if (Rd1 === true || Rd1 === 'true') {
        swhere += ` and nb = 0 `;
    }
    if (Rd2 === true || Rd2 === 'true') {
        swhere += ` and nb > 0 `;
    }

    let sqlStr = `
    select 
      Cod_Evaluation as 'Evaluation', 
      Description,
      Cod_Evaluateur as 'Evaluateur', 
      Nom_Evaluateur as 'Nom évaluateur',
      Dat_Du as 'Du', 
      Dat_Au as 'Au',
      s.Statut,
      Entite as 'Entité',
      Grade,
      Matricule, 
      Nom, 
      Poste,
      CONVERT(bit, case isnull(Cod_Reply,'') when '' then 'false' else 'true' end) as 'Effectuée',
      dbo.FindRubrique('Statut_Signature',v.Statut) as 'Validation', 
      Dat_Survey as 'Date'
    from Sys_Evaluation_Liste l
    outer apply (
      select Membre as Statut 
      from Param_Rubriques 
      where Nom_Controle ='Statut_Evaluation' and Valeur=Statut_Evaluation
    ) s
    outer apply (
      select Cod_Reply, Statut, Paie_Calculee, Dat_Survey 
      from Survey_Reply 
      where id_Societe = l.id_Societe 
        and Cod_Survey = l.Cod_Survey 
        and ISNULL(Ref_Evaluation,'') = Cod_Evaluation 
        and Typ_Evalue ='E' 
        and Evalue = Matricule
    ) v
    ${swhere}
  `;

    try {
        const rsl = await lireSql(sqlStr, params);
        res.send(rsl);
    } catch (error: any) {
        res.send({ result: false, message: error.message });
    }
};
