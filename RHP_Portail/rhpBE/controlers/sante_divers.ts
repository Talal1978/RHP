/* Module Sante - Espace salarie, tableau de bord, rapport annuel, audit,
   et referentiels (parametrage). */
import { Request, Response } from "express";
import { ecrireSql, lireSql, controleInjection } from "../modules/module_sqlRW";
import { Int, NVarChar, SmallDateTime } from "mssql";
import {
  getAgent, DomaineSante, checkSanteAccess, santeEndpoint, santeAudit, setNoStore, toDate,
} from "../modules/module_sante";

/* ============ Espace salarie (role Agent : ses donnees publiables uniquement) ============
   Pas de fonction SANTE_* requise : l'agent ne voit que SON matricule, objets
   explicitement publiables. Aucune donnee clinique. */
export async function ma_sante(req: Request, res: Response) {
  setNoStore(res);
  const { theAgent, idSocNum } = getAgent(req);
  if (isNaN(idSocNum) || idSocNum <= 0) return res.send({ result: false, message: "id_Societe invalide" });
  const mat = theAgent?.Matricule || "";
  if (!mat) return res.send({ result: false, message: "Matricule non identifié" });

  const convocations = await lireSql(
    `select c.RowId, p.Lib_Campagne as 'Campagne', c.Dat_Convocation as 'Date convocation', c.Heure,
            dbo.FindRubrique('Statut_Convocation',c.Statut_Convocation) as Statut
     from RH_Sante_Convocation c
     inner join RH_Sante_Campagne p on p.Cod_Campagne=c.Cod_Campagne and p.id_Societe=c.id_Societe
     where c.id_Societe=@idSoc and c.Matricule=@mat and c.Dat_Convocation >= dateadd(month,-6,getdate())
     order by c.Dat_Convocation desc`,
    [
      { param: "idSoc", sqlType: Int, valeur: idSocNum },
      { param: "mat", sqlType: NVarChar, valeur: mat },
    ]
  );
  const aptitudes = await lireSql(
    `select Num_Aptitude, Dat_Aptitude, dbo.FindRubrique('Statut_Aptitude',Statut_Aptitude) as Aptitude,
            Restrictions_Poste, Dat_Fin
     from RH_Sante_Aptitude
     where id_Societe=@idSoc and Matricule=@mat and isnull(Publie_RH,'false')='true' and isnull(Statut,'') in ('VA','SG')
     order by Dat_Aptitude desc`,
    [
      { param: "idSoc", sqlType: Int, valeur: idSocNum },
      { param: "mat", sqlType: NVarChar, valeur: mat },
    ]
  );
  const prochaine = await lireSql(
    `select Dat_Prochaine_Visite from RH_Sante_Dossier where Matricule=@mat and id_Societe=@idSoc`,
    [
      { param: "idSoc", sqlType: Int, valeur: idSocNum },
      { param: "mat", sqlType: NVarChar, valeur: mat },
    ]
  );
  await santeAudit({ req, action: "LECT", objet: "ma_sante", valeurIndex: mat, matriculeConcerne: mat, succes: true });
  res.send({
    result: true,
    data: {
      convocations: convocations.data || [],
      aptitudes: aptitudes.data || [],
      prochaine_visite: prochaine.data?.[0]?.Dat_Prochaine_Visite || null,
    },
  });
}

/* ============ Tableau de bord (ADMIN, agregats seuilles) ============ */
export async function sante_tableau_bord(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Sante_Tableau_Bord", async (req2, res2, idSocNum) => {
    const seuilRsl = await lireSql(`select try_cast(isnull(dbo.Sys_Sante_Param('SEUIL_AGREGAT_MIN', @idSoc),'5') as int) as s`, [
      { param: "idSoc", sqlType: Int, valeur: idSocNum },
    ]);
    const seuil = Number(seuilRsl?.data?.[0]?.s || 5);

    const aptitudes = await lireSql(
      `select Statut_Aptitude, Situation, case when Effectif < @seuil then null else Effectif end as Effectif
       from RH_Sante_Vue_TB_Aptitudes where id_Societe=@idSoc`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "seuil", sqlType: Int, valeur: seuil },
      ]
    );
    const visitesParType = await lireSql(
      `select dbo.FindRubrique('Typ_Visite',Typ_Visite) as 'Type', count(*) as Nb
       from RH_Sante_Visite where id_Societe=@idSoc and year(Dat_Visite)=year(getdate())
       group by Typ_Visite having count(*) >= @seuil`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "seuil", sqlType: Int, valeur: seuil },
      ]
    );
    const atEnCours = await lireSql(
      `select count(*) as Nb from RH_Declaration_AT where id_Societe=@idSoc and isnull(Cloture,'false')='false'`,
      [{ param: "idSoc", sqlType: Int, valeur: idSocNum }]
    );
    const etapesRetard = await lireSql(
      `select count(*) as Nb from RH_Declaration_AT_Echeance
       where id_Societe=@idSoc and isnull(Statut_Etape,'AFA') in ('AFA','ENC') and Dat_Echeance < getdate()`,
      [{ param: "idSoc", sqlType: Int, valeur: idSocNum }]
    );
    await santeAudit({ req, action: "LECT", objet: "RH_Sante_Tableau_Bord", succes: true });
    res2.send({
      result: true,
      data: {
        seuil,
        aptitudes: aptitudes.data || [],
        visites_par_type: visitesParType.data || [],
        at_en_cours: atEnCours.data?.[0]?.Nb ?? 0,
        etapes_en_retard: etapesRetard.data?.[0]?.Nb ?? 0,
      },
    });
  });
}

/* ============ Rapport annuel ============ */
export async function sante_rapport_annuel_donnees(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Sante_Rapport_Annuel", async (req2, res2, idSocNum) => {
    const an = Number(req.body?.Annee || new Date().getFullYear() - 1);
    const effectifs = await lireSql(
      `select isnull(Sexe,'') as Sexe, isnull(Cod_Grade,'') as Cod_Grade, count(*) as Effectif
       from RH_Agent where id_Societe=@idSoc group by Sexe, Cod_Grade order by Cod_Grade, Sexe`,
      [{ param: "idSoc", sqlType: Int, valeur: idSocNum }]
    );
    const visites = await lireSql(
      `select dbo.FindRubrique('Typ_Visite',Typ_Visite) as Typ_Visite, count(*) as Nb
       from RH_Sante_Visite where id_Societe=@idSoc and year(Dat_Visite)=@an and isnull(Statut,'') in ('VA','SG')
       group by Typ_Visite`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "an", sqlType: Int, valeur: an },
      ]
    );
    const at = await lireSql(
      `select isnull(Typ_Accident,'TRAVAIL') as Typ_Accident, count(*) as Nb, isnull(sum(j.Jours),0) as Jours
       from RH_Declaration_AT t
       outer apply (select sum(d.Nbr_Jours) as Jours from RH_Declaration_AT_Detail d
                    where d.Num_Declaration=t.Num_Declaration and d.id_Societe=t.id_Societe
                      and isnull(d.Valide,'false')='true' and d.Dat_Debut_Arret is not null) j
       where t.id_Societe=@idSoc and year(t.Dat_Accident)=@an and isnull(t.Typ_Accident,'TRAVAIL')<>'NREC'
       group by isnull(Typ_Accident,'TRAVAIL')`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "an", sqlType: Int, valeur: an },
      ]
    );
    const mp = await lireSql(
      `select dbo.FindRubrique('Statut_Declaration_MP',Statut_Declaration) as Statut, count(*) as Nb
       from RH_Sante_Maladie_Pro where id_Societe=@idSoc and year(Dat_Declaration)=@an
       group by Statut_Declaration`,
      [
        { param: "idSoc", sqlType: Int, valeur: an },
      ]
    );
    const suivi = await lireSql(
      `select * from RH_Sante_Rapport_Annuel where Annee=@an and id_Societe=@idSoc`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "an", sqlType: Int, valeur: an },
      ]
    );
    await santeAudit({ req, action: "LECT", objet: "RH_Sante_Rapport_Annuel", valeurIndex: String(an), succes: true });
    res2.send({
      result: true,
      data: {
        annee: an,
        effectifs: effectifs.data || [],
        visites: visites.data || [],
        accidents: at.data || [],
        maladies_pro: mp.data || [],
        suivi: suivi.data?.[0] || null,
      },
    });
  });
}

/* Controle des donnees sources avant edition (anomalies + liens) */
export async function sante_rapport_annuel_controle(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Sante_Rapport_Annuel", async (req2, res2, idSocNum) => {
    const an = Number(req.body?.Annee || new Date().getFullYear() - 1);
    const sansVisite = await lireSql(
      `select d.Matricule, r.Nom_Agent + ' ' + r.Prenom_Agent as Nom
       from RH_Sante_Dossier d
       inner join RH_Agent r on r.Matricule=d.Matricule and r.id_Societe=d.id_Societe
       where d.id_Societe=@idSoc and isnull(d.Archive,'false')='false' and d.Dat_Derniere_Visite is null`,
      [{ param: "idSoc", sqlType: Int, valeur: idSocNum }]
    );
    const echeancesDepassees = await lireSql(
      `select d.Matricule, r.Nom_Agent + ' ' + r.Prenom_Agent as Nom, d.Dat_Prochaine_Visite
       from RH_Sante_Dossier d
       inner join RH_Agent r on r.Matricule=d.Matricule and r.id_Societe=d.id_Societe
       where d.id_Societe=@idSoc and isnull(d.Archive,'false')='false'
         and d.Dat_Prochaine_Visite < datefromparts(@an,12,31)`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "an", sqlType: Int, valeur: an },
      ]
    );
    const atNonClotures = await lireSql(
      `select Num_Declaration, Matricule, Dat_Accident from RH_Declaration_AT
       where id_Societe=@idSoc and year(Dat_Accident)=@an and isnull(Cloture,'false')='false'`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "an", sqlType: Int, valeur: an },
      ]
    );
    const visitesSansAptitude = await lireSql(
      `select Num_Visite, Matricule, Dat_Visite from RH_Sante_Visite
       where id_Societe=@idSoc and year(Dat_Visite)=@an and isnull(Statut,'') in ('VA','SG')
         and isnull(Statut_Aptitude,'')=''`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "an", sqlType: Int, valeur: an },
      ]
    );
    await santeAudit({ req, action: "LECT", objet: "RH_Sante_Rapport_Annuel", valeurIndex: String(an), succes: true, motif: "Contrôle des sources" });
    res2.send({
      result: true,
      data: {
        agents_sans_visite: sansVisite.data || [],
        echeances_depassees: echeancesDepassees.data || [],
        at_non_clotures: atNonClotures.data || [],
        visites_sans_aptitude: visitesSansAptitude.data || [],
      },
    });
  });
}

/* Cycle de vie du rapport : BROUILLON -> CONTROLE -> VALIDE -> TRANSMIS */
export async function save_sante_rapport_annuel(req: Request, res: Response) {
  await santeEndpoint(req, res, "ADMIN", "RH_Sante_Rapport_Annuel", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    const { Annee, Statut, FD_Rapport, FD_Preuve, Commentaire } = req.body;
    const an = Number(Annee || 0);
    if (an < 2000) return res2.send({ result: false, message: "Année invalide" });
    if (!["BROUILLON", "CONTROLE", "VALIDE", "TRANSMIS"].includes(Statut || "")) {
      return res2.send({ result: false, message: "Statut invalide" });
    }
    if (Statut === "TRANSMIS" && !FD_Preuve) {
      return res2.send({ result: false, message: "La preuve de transmission est obligatoire" });
    }
    const rsEnt = await ecrireSql({
      tableName: "RH_Sante_Rapport_Annuel",
      fields: {
        Annee: an, id_Societe: idSocNum, Statut,
        Dat_Controle: Statut === "CONTROLE" ? new Date() : null,
        Dat_Validation: Statut === "VALIDE" ? new Date() : null,
        Dat_Transmission: Statut === "TRANSMIS" ? new Date() : null,
        FD_Rapport: FD_Rapport || null, FD_Preuve: FD_Preuve || null,
        Commentaire: Commentaire || "",
      },
      joinFields: ["Annee", "id_Societe"],
      excludeFields: [],
      login: theAgent.Matricule || theAgent.Login,
    });
    await santeAudit({ req, action: "MODI", objet: "RH_Sante_Rapport_Annuel", valeurIndex: String(an), succes: rsEnt.result, motif: "Statut=" + Statut });
    res2.send(rsEnt);
  });
}

/* ============ Audit des acces (SANTE_AUDIT uniquement) ============ */
export async function sante_audit_liste(req: Request, res: Response) {
  await santeEndpoint(req, res, "AUDIT", "RH_Sante_Audit_Acces", async (req2, res2, idSocNum) => {
    let { Login_User, Action, Objet, Dat_Du, Dat_Au } = req.body;
    if (controleInjection(Login_User).result === false) return res2.send({ result: false, message: "Injection détectée" });
    if (controleInjection(Action).result === false) return res2.send({ result: false, message: "Injection détectée" });
    const du = toDate(Dat_Du) || new Date(new Date().getTime() - 30 * 24 * 3600 * 1000);
    const au = toDate(Dat_Au) || new Date(2045, 11, 31);
    const rsl = await lireSql(
      `select TOP 200 RowId, Dat_Action as 'Date', Login_User as 'Utilisateur', Cod_Profile as 'Profil',
              Action, Objet, Valeur_Index as 'Objet (id)', Matricule_Concerne as 'Matricule',
              case when isnull(Succes,'false')='true' then 'Succès' else 'Échec' end as 'Résultat', Motif, IP
       from RH_Sante_Audit_Acces
       where id_Societe=@idSoc and Dat_Action between @du and @au
         and isnull(Login_User,'') like '%'+@login and isnull(Action,'') like @action+'%'
         and isnull(Objet,'') like '%'+@objet
       order by Dat_Action desc`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "login", sqlType: NVarChar, valeur: Login_User || "" },
        { param: "action", sqlType: NVarChar, valeur: Action || "" },
        { param: "objet", sqlType: NVarChar, valeur: Objet || "" },
        { param: "du", sqlType: SmallDateTime, valeur: du },
        { param: "au", sqlType: SmallDateTime, valeur: au },
      ]
    );
    res2.send(rsl);
  });
}

/* ============ Referentiels (parametrage, domaine ADMIN) ============
   Factory de handlers CRUD simples pour les tables Param_Sante_* et annexes. */
function crudReferentiel(
  table: string,
  colCle: string,
  domaine: DomaineSante = "ADMIN"
) {
  return {
    liste: async (req: Request, res: Response) => {
      await santeEndpoint(req, res, domaine, table, async (req2, res2, idSocNum) => {
        const rsl = await lireSql(
          `select TOP 100 * from ${table} where id_Societe in (@idSoc, -1) order by ${colCle}`,
          [{ param: "idSoc", sqlType: Int, valeur: idSocNum }]
        );
        res2.send(rsl);
      });
    },
    save: async (req: Request, res: Response) => {
      await santeEndpoint(req, res, domaine, table, async (req2, res2, idSocNum) => {
        const { theAgent } = getAgent(req);
        const { entete } = req.body;
        if (!entete[colCle] && colCle !== "RowId") return res2.send({ result: false, message: "Clé non renseignée" });
        const rsEnt = await ecrireSql({
          tableName: table,
          fields: { ...entete, id_Societe: entete.id_Societe ?? idSocNum },
          joinFields: colCle === "RowId" ? ["RowId"] : [colCle, "id_Societe"],
          excludeFields: colCle === "RowId" ? ["RowId"] : [],
          login: theAgent.Matricule || theAgent.Login,
        });
        await santeAudit({ req, action: "MODI", objet: table, valeurIndex: String(entete[colCle] ?? ""), succes: rsEnt.result });
        res2.send(rsEnt);
      });
    },
  };
}

const interv = crudReferentiel("Param_Sante_Intervenant", "Cod_Intervenant");
export const sante_intervenant_liste = interv.liste;
export const save_sante_intervenant = interv.save;

const period = crudReferentiel("Param_Sante_Periodicite", "Cod_Regle");
export const sante_periodicite_liste = period.liste;
export const save_sante_periodicite = period.save;

const regl = crudReferentiel("Param_Sante_Reglement", "Cod_Param");
export const sante_reglement_liste = regl.liste;
export const save_sante_reglement = regl.save;

const dest = crudReferentiel("Param_Sante_Destinataire", "Cod_Destinataire");
export const sante_destinataire_liste = dest.liste;
export const save_sante_destinataire = dest.save;

const etape = crudReferentiel("Param_Sante_Etape_AT", "Cod_Etape");
export const sante_etape_at_liste = etape.liste;
export const save_sante_etape_at = etape.save;

const heures = crudReferentiel("RH_Sante_Heures_Travaillees", "RowId" as any);
export const sante_heures_liste = async (req: Request, res: Response) => {
  await santeEndpoint(req, res, "ADMIN", "RH_Sante_Heures_Travaillees", async (req2, res2, idSocNum) => {
    const rsl = await lireSql(
      `select Annee, Mois, Heures, Source from RH_Sante_Heures_Travaillees where id_Societe=@idSoc order by Annee desc, Mois desc`,
      [{ param: "idSoc", sqlType: Int, valeur: idSocNum }]
    );
    res2.send(rsl);
  });
};
export const save_sante_heures = async (req: Request, res: Response) => {
  await santeEndpoint(req, res, "ADMIN", "RH_Sante_Heures_Travaillees", async (req2, res2, idSocNum) => {
    const { theAgent } = getAgent(req);
    const { entete } = req.body;
    const rsEnt = await ecrireSql({
      tableName: "RH_Sante_Heures_Travaillees",
      fields: { ...entete, id_Societe: idSocNum },
      joinFields: ["Annee", "Mois", "id_Societe"],
      excludeFields: [],
      login: theAgent.Matricule || theAgent.Login,
    });
    await santeAudit({ req, action: "MODI", objet: "RH_Sante_Heures_Travaillees", valeurIndex: `${entete.Annee}/${entete.Mois}`, succes: rsEnt.result });
    res2.send(rsEnt);
  });
};

const posteRisque = crudReferentiel("Param_Sante_Poste_Risque", "Cod_Poste");
export const sante_poste_risque_liste = posteRisque.liste;
export const save_sante_poste_risque = posteRisque.save;

/* Criteres medicaux temporaires (CLINIQUE) */
const crit = crudReferentiel("RH_Sante_Agent_Critere", "RowId" as any, "CLINIQUE");
export const sante_agent_critere_liste = async (req: Request, res: Response) => {
  await santeEndpoint(req, res, "CLINIQUE", "RH_Sante_Agent_Critere", async (req2, res2, idSocNum) => {
    const { Matricule } = req.body;
    if (controleInjection(Matricule).result === false) return res2.send({ result: false, message: "Injection détectée" });
    const rsl = await lireSql(
      `select RowId, Matricule, Critere, Dat_Deb, Dat_Fin, Cod_Medecin, Commentaire
       from RH_Sante_Agent_Critere where id_Societe=@idSoc and Matricule like '%'+@mat order by Dat_Deb desc`,
      [
        { param: "idSoc", sqlType: Int, valeur: idSocNum },
        { param: "mat", sqlType: NVarChar, valeur: Matricule || "" },
      ]
    );
    res2.send(rsl);
  });
};
export const save_sante_agent_critere = crit.save;
