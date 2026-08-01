/* Module Sante - Examens complementaires (CLINIQUE, cloisonnement fin par Visibilite) */
import { Request, Response } from "express";
import { ecrireSql, lireSql, controleInjection } from "../modules/module_sqlRW";
import { Int, NVarChar, SmallDateTime } from "mssql";
import {
  getAgent, santeEndpoint, santeAudit, verrouCndpActif, nouveauNumero, toDate,
} from "../modules/module_sante";

/* Controle de visibilite d'un examen : 'AUT' = medecin prescripteur uniquement.
   L'utilisateur courant est presume prescripteur si son matricule = Cod_Medecin_Prescripteur
   ou s'il est l'auteur de la saisie (Created_By). */
async function peutVoirResultat(theAgent: any, examen: any): Promise<boolean> {
  if (!examen) return false;
  if ((examen.Visibilite || "MED") !== "AUT") return true;
  const mat = theAgent?.Matricule || "";
  return examen.Cod_Medecin_Prescripteur === mat || examen.Created_By === mat || examen.Created_By === theAgent?.Login;
}

export async function sante_examen_liste(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Examen", async (req2, res2, idSocNum) => {
    let { Matricule, Typ_Examen, Statut_Examen, Dat_Du, Dat_Au } = req.body;
    if (controleInjection(Matricule).result === false) return res2.send({ result: false, message: "Injection détectée dans Matricule" });
    const du = toDate(Dat_Du) || new Date(1900, 0, 1);
    const au = toDate(Dat_Au) || new Date(2045, 11, 31);
    // Jamais de contenu clinique dans la liste : motif et resultat resumes exclus
    const rsl = await lireSql(
      `select TOP 50 Num_Examen 'N° examen', e.Matricule, r.Nom,
         dbo.FindRubrique('Typ_Examen',Typ_Examen) as 'Examen', Dat_Examen as 'Date',
         dbo.FindRubrique('Statut_Examen',Statut_Examen) as 'Statut', Dat_Resultat as 'Résultat le',
         case when FD_Resultat is not null then 'Oui' else '' end as 'Pièce'
       from RH_Sante_Examen e
       outer apply (select Nom_Agent + ' ' +Prenom_Agent as Nom from RH_Agent where id_Societe=e.id_Societe and Matricule=e.Matricule) r
       where e.id_Societe=@idSoc and e.Matricule like '%'+@Matricule
         and isnull(Dat_Examen,Dat_Prescription) between @du and @au
         and isnull(Typ_Examen,'') like @typ and isnull(Statut_Examen,'') like @st
       order by [Date] desc`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "Matricule", sqlType: NVarChar, valeur: Matricule || "" },
        { param: "typ", sqlType: NVarChar, valeur: (Typ_Examen || "") + "%" },
        { param: "st", sqlType: NVarChar, valeur: (Statut_Examen || "") + "%" },
        { param: "du", sqlType: SmallDateTime, valeur: du },
        { param: "au", sqlType: SmallDateTime, valeur: au },
      ]
    );
    await santeAudit({ req, action: "LECT", objet: "RH_Sante_Examen", succes: true });
    res2.send(rsl);
  });
}

export async function get_sante_examen(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Examen", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    const { Num_Examen } = req.body;
    const rsl = await lireSql(
      `select * from RH_Sante_Examen where Num_Examen=@num and id_Societe=@idSoc`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_Examen || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    if (rsl.result && rsl.data.length > 0) {
      const ex = rsl.data[0];
      if (!(await peutVoirResultat(theAgent, ex))) {
        await santeAudit({ req, action: "AUTH_KO", objet: "RH_Sante_Examen", valeurIndex: Num_Examen, matriculeConcerne: ex.Matricule, succes: false, motif: "Résultat réservé au médecin prescripteur" });
        // Masque le contenu du resultat mais laisse les metadonnees
        ex.Resultat_Resume = null;
        ex.Motif = null;
        ex.FD_Resultat = null;
      }
    }
    await santeAudit({ req, action: "LECT", objet: "RH_Sante_Examen", valeurIndex: Num_Examen, matriculeConcerne: rsl?.data?.[0]?.Matricule, succes: true });
    res2.send(rsl);
  });
}

export async function save_sante_examen(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Examen", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    if (await verrouCndpActif(idSocNum)) {
      await santeAudit({ req, action: "AUTH_KO", objet: "RH_Sante_Examen", succes: false, motif: "Verrou CNDP actif" });
      return res2.send({ result: false, message: "Traitement bloqué : autorisation CNDP non renseignée dans les paramètres" });
    }
    const { entete: _entete } = req.body;
    let { Num_Examen, ...entete } = _entete;
    const estCreation = !Num_Examen || Num_Examen === "";
    if (!entete.Matricule) return res2.send({ result: false, message: "Matricule non renseigné" });

    if (!estCreation) {
      const ex = await lireSql(
        `select * from RH_Sante_Examen where Num_Examen=@num and id_Societe=@idSoc`,
        [
          { param: "num", sqlType: NVarChar, valeur: Num_Examen },
          { param: "idSoc", sqlType: Int, valeur: idSocNum },
        ]
      );
      if (ex.result && ex.data.length > 0 && !(await peutVoirResultat(theAgent, ex.data[0]))) {
        await santeAudit({ req, action: "AUTH_KO", objet: "RH_Sante_Examen", valeurIndex: Num_Examen, succes: false, motif: "Modification réservée au médecin prescripteur" });
        return res2.send({ result: false, message: "Accès non autorisé" });
      }
    } else {
      Num_Examen = await nouveauNumero("EX", "RH_Sante_Examen", "Num_Examen", "Dat_Examen", idSocNum);
    }

    // Date limite de conservation calculee depuis le parametre (si defini)
    if (entete.Dat_Resultat && !entete.Dat_Limite_Conservation) {
      const ans = await lireSql(`select dbo.Sys_Sante_Param('DUREE_CONSERVATION_EXAMEN_ANS', @idSoc) as v`, [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]);
      const n = Number(ans?.data?.[0]?.v || 0);
      if (n > 0) {
        const lim = toDate(entete.Dat_Resultat) as Date;
        lim.setFullYear(lim.getFullYear() + n);
        entete.Dat_Limite_Conservation = lim;
      }
    }

    const rsEnt = await ecrireSql({
      tableName: "RH_Sante_Examen",
      fields: { ...entete, Num_Examen, id_Societe: idSocNum },
      joinFields: ["Num_Examen", "id_Societe"],
      excludeFields: [],
      login: theAgent.Matricule || theAgent.Login,
    });
    await santeAudit({ req, action: estCreation ? "CREA" : "MODI", objet: "RH_Sante_Examen", valeurIndex: Num_Examen, matriculeConcerne: entete.Matricule, succes: rsEnt.result });
    res2.send(rsEnt);
  });
}

export async function delete_sante_examen(req: Request, res: Response) {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Examen", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    const { Num_Examen } = req.body;
    await lireSql(
      `insert into Mouchard_Suppression (Nom_Table, Nom_Champs, Valeur_Champs, Deleted_by, Deleted_Date)
       values ('RH_Sante_Examen','Num_Examen',@num, @usr, convert(nvarchar(20),getdate(),120))`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_Examen || "" },
        { param: "usr", sqlType: Int, valeur: Number(theAgent?.id_User || 0) },
      ]
    );
    const rsl = await lireSql(
      `delete from RH_Sante_Examen where Num_Examen=@num and id_Societe=@idSoc`,
      [
        { param: "num", sqlType: NVarChar, valeur: Num_Examen || "" },
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
      ]
    );
    await santeAudit({ req, action: "SUPP", objet: "RH_Sante_Examen", valeurIndex: Num_Examen, succes: rsl.result });
    res2.send(rsl.result ? { result: true, data: Num_Examen } : { result: false, message: "Erreur suppression" });
  });
}
