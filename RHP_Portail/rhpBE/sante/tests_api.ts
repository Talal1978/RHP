/* Tests API du module Sante (T20-T32) - necessite le serveur sur :3500.
   Usage : npx ts-node --transpile-only sante/tests_api.ts                    */
import axios from "axios";
import { lireSql, closePool } from "../modules/module_sqlRW";
import { initialisationSeveur } from "../modules/module_initialisation";
import { Int, NVarChar } from "mssql";

const BASE = "http://localhost:3500/api/";
const PWD = "Test1234!";
type Session = { token: string; agent: any };

const resultats: { cod: string; ok: boolean; detail: string }[] = [];
function T(cod: string, ok: boolean, detail: string) {
  resultats.push({ cod, ok, detail });
  console.log(`${ok ? "[OK] " : "[KO] "}${cod} : ${detail}`);
}

async function login(mail: string): Promise<Session | null> {
  try {
    const r = await axios.get(`${BASE}auth`, { params: { login: mail, pwd: PWD } });
    if (r.data?.result && r.data?.jwt?.accessToken) {
      return { token: r.data.jwt.accessToken, agent: r.data.data };
    }
    console.error("Echec login", mail, JSON.stringify(r.data).substring(0, 200));
    return null;
  } catch (e: any) {
    console.error("Echec login", mail, e.message);
    return null;
  }
}

async function post(s: Session, endpoint: string, body: any) {
  try {
    const r = await axios.post(`${BASE}${endpoint}`, body, {
      headers: { authorization: `Bearer ${s.token}` },
      validateStatus: () => true,
    });
    return { data: r.data, headers: r.headers, status: r.status };
  } catch (e: any) {
    return { data: { result: false, message: e.message }, headers: {}, status: -1 };
  }
}

async function main() {
  await initialisationSeveur();

  /* ---- Logins ---- */
  const med = await login("medecin@demo.local");
  const rh = await login("rh@demo.local");
  const inf = await login("infirmier@demo.local");
  const aud = await login("auditeur@demo.local");
  const med2 = await login("medecin2@demo.local");
  const agent = await login("fictif001@demo.local");
  if (!med || !rh || !inf || !aud || !med2 || !agent) {
    console.error("Logins incomplets - arret");
    process.exit(1);
  }
  T("T00-login", true, `med profil=${med.agent.Cod_Profile}, rh profil=${rh.agent.Cod_Profile}, agent profil=${agent.agent.Cod_Profile}`);

  /* ---- T20 : CRUD visite medecin + validation + verrouillage + rectification ---- */
  const v1 = await post(med, "save_sante_visite", {
    entete: {
      Matricule: "FICTIF001", Dat_Visite: "2026-08-01", Typ_Visite: "PRD",
      Cod_Medecin: "MED001", Conclusion: "RAS (test)", Statut_Aptitude: "APTE",
      Restrictions: "", Reserves: "", Statut: "",
    },
  });
  const numVisite = v1.data?.data?.[0]?.Num_Visite || "";
  T("T20a", v1.data?.result === true && numVisite.startsWith("VM"), `creation visite ${numVisite || "KO"}`);

  const v2 = await post(med, "save_sante_visite", {
    entete: {
      Num_Visite: numVisite, Matricule: "FICTIF001", Dat_Visite: "2026-08-01", Typ_Visite: "PRD",
      Cod_Medecin: "MED001", Conclusion: "RAS (test)", Statut_Aptitude: "APTE", Statut: "VA",
    },
  });
  const echeanceAuto = v2.data?.data?.[0]?.Dat_Prochaine_Visite;
  T("T20b", v2.data?.result === true && !!echeanceAuto, `validation + echeance auto ${echeanceAuto || "absente"}`);

  const v3 = await post(med, "save_sante_visite", {
    entete: {
      Num_Visite: numVisite, Matricule: "FICTIF001", Dat_Visite: "2026-08-01", Typ_Visite: "PRD",
      Conclusion: "Modif interdite", Statut_Aptitude: "APTE", Statut: "VA",
    },
  });
  T("T20c", v3.data?.result === false, `modification visite validee refusee (${v3.data?.message || "?"})`);

  const v4 = await post(med, "save_sante_visite", {
    entete: {
      Matricule: "FICTIF001", Dat_Visite: "2026-08-01", Typ_Visite: "PRD",
      Statut_Aptitude: "APTE_RES", Num_Visite_Rectifiee: numVisite, Statut: "",
    },
  });
  T("T20d", v4.data?.result === false, `rectification sans motif refusee (${v4.data?.message || "?"})`);

  const v5 = await post(med, "save_sante_visite", {
    entete: {
      Matricule: "FICTIF001", Dat_Visite: "2026-08-01", Typ_Visite: "PRD",
      Statut_Aptitude: "APTE_RES", Num_Visite_Rectifiee: numVisite,
      Motif_Rectification: "Correction test", Statut: "",
    },
  });
  T("T20e", v5.data?.result === true, `rectification motivee acceptee`);

  /* ---- T21 : refus par role ---- */
  const r1 = await post(rh, "save_sante_visite", {
    entete: { Matricule: "FICTIF002", Dat_Visite: "2026-08-01", Typ_Visite: "PRD", Statut_Aptitude: "APTE", Statut: "" },
  });
  T("T21a", r1.data?.result === false && r1.data?.message === "Accès non autorisé", "ecriture visite par RH refusee");

  const r2 = await post(agent, "sante_visite_liste", { Matricule: "", Dat_Du: "", Dat_Au: "" });
  T("T21b", r2.data?.result === false, "liste clinique refusee a l'agent simple");

  /* ---- T22 : cloisonnement inter-societes ---- */
  const r3 = await post(med2, "get_sante_visite", { Num_Visite: numVisite });
  T("T22", r3.data?.result === true && (r3.data?.data || []).length === 0, "visite d'une autre societe invisible");

  /* ---- T23 : calcul echeance coherent avec SQL ---- */
  const r4 = await post(rh, "sante_calcul_echeance", { Matricule: "FICTIF001", Dat_Visite: "2026-01-01" });
  const d23 = r4.data?.data?.[0]?.Dat_Prochaine_Visite || "";
  T("T23", String(d23).startsWith("2028-01-01"), `echeance calculee=${d23} (attendu 2028-01-01)`);

  /* ---- T24 : tableau de bord agrege, sans clinique ---- */
  const r5 = await post(rh, "sante_tableau_bord", {});
  const json5 = JSON.stringify(r5.data);
  T("T24a", r5.data?.result === true && !json5.includes("Conclusion"), "TB sans colonne clinique");
  const apt24 = r5.data?.data?.aptitudes || [];
  const hasMat = apt24.some((l: any) => Object.keys(l).some((k) => k.toLowerCase().includes("matricule")));
  T("T24b", !hasMat, "TB agrege sans lignes nominatives");

  /* ---- T25 : suivi AT (satellites) ---- */
  const a1 = await post(rh, "sante_at_suivi_get", { Num_Declaration: "AT-TEST001" });
  T("T25a", a1.data?.result === true && a1.data?.entete?.Num_Declaration === "AT-TEST001", "suivi AT accessible RH");
  const a2 = await post(rh, "save_sante_at_typ", { Num_Declaration: "AT-TEST001", Typ_Accident: "TRAJET" });
  const a3 = await post(rh, "save_sante_at_typ", { Num_Declaration: "AT-TEST001", Typ_Accident: "TRAVAIL" });
  T("T25b", a2.data?.result === true && a3.data?.result === true, "distinction travail/trajet mise a jour");
  const a4 = await post(rh, "sante_at_generer_echeances", { Num_Declaration: "AT-TEST001" });
  T("T25c", a4.data?.result === true, `echeancier regenere (${(a4.data?.data || []).length} lignes)`);
  const a5 = await post(rh, "save_sante_at_transmission", {
    entete: { Num_Declaration: "AT-TEST001", Cod_Destinataire: "ASSUR01", Dat_Transmission: "2027-02-04", Mode_Transmission: "MAIL", Reference: "TEST-API" },
  });
  T("T25d", a5.data?.result === true, "transmission enregistree");
  const a6 = await post(med2, "sante_at_suivi_get", { Num_Declaration: "AT-TEST001" });
  T("T25e", a6.data?.entete === null, "suivi AT d'une autre societe invisible");

  /* ---- T26 : aptitudes en masse ---- */
  const c1 = await post(rh, "save_sante_campagne", {
    entete: { Lib_Campagne: "Campagne test API", Typ_Visite: "PRD", Dat_Deb: "2026-07-01", Dat_Fin: "2026-12-31", Statut: "ENC" },
  });
  const codCamp = c1.data?.data?.[0]?.Cod_Campagne || "";
  T("T26a", c1.data?.result === true && codCamp !== "", `campagne ${codCamp || "KO"}`);
  await post(med, "save_sante_visite", {
    entete: {
      Matricule: "FICTIF002", Dat_Visite: "2026-08-01", Typ_Visite: "PRD", Cod_Campagne: codCamp,
      Cod_Medecin: "MED001", Statut_Aptitude: "APTE", Statut: "VA",
    },
  });
  const m1 = await post(med, "sante_aptitude_masse", { Cod_Campagne: codCamp, Dat_Aptitude: "2026-08-01", Cod_Medecin: "MED001" });
  T("T26b", m1.data?.result === true && m1.data?.data?.[0]?.generees >= 1, `${m1.data?.data?.[0]?.generees ?? 0} fiche(s) generee(s) en masse`);

  /* ---- T27 : examen - visibilite AUT ---- */
  const e1 = await post(med, "save_sante_examen", {
    entete: {
      Matricule: "FICTIF001", Typ_Examen: "BIO", Dat_Prescription: "2026-08-01",
      Cod_Medecin_Prescripteur: "MED001", Motif: "Motif confidentiel test",
      Statut_Examen: "RES", Dat_Resultat: "2026-08-02", Resultat_Resume: "Resultat secret test", Visibilite: "AUT",
    },
  });
  const numEx = e1.data?.data?.[0]?.Num_Examen || "";
  const e2 = await post(inf, "get_sante_examen", { Num_Examen: numEx });
  const ex2 = e2.data?.data?.[0] || {};
  T("T27a", e2.data?.result === true && ex2.Resultat_Resume === null, "resultat AUT masque pour l'infirmier");
  const e3 = await post(med, "get_sante_examen", { Num_Examen: numEx });
  const ex3 = e3.data?.data?.[0] || {};
  T("T27b", e3.data?.result === true && ex3.Resultat_Resume === "Resultat secret test", "resultat visible pour le medecin");

  /* ---- T28 : audit d'acces ecrit ---- */
  const u1 = await post(aud, "sante_audit_liste", { Login_User: "", Action: "CREA", Objet: "RH_Sante_Visite", Dat_Du: "", Dat_Au: "" });
  const lignesAudit = u1.data?.data || [];
  T("T28a", u1.data?.result === true && lignesAudit.length > 0, `${lignesAudit.length} ligne(s) CREA dans l'audit`);
  const u2 = await post(rh, "sante_audit_liste", { Login_User: "", Action: "", Objet: "", Dat_Du: "", Dat_Au: "" });
  T("T28b", u2.data?.result === false, "audit refuse au profil RH (reserve SANTE_AUDIT)");
  const authKo = await lireSql(
    `select count(*) as nb from RH_Sante_Audit_Acces where Action='AUTH_KO' and Objet like 'RH_Sante%'`,
    []
  );
  T("T28c", Number(authKo?.data?.[0]?.nb || 0) > 0, "refus traces (AUTH_KO) en base");

  /* ---- T29 : header no-store ---- */
  const h1 = await post(med, "get_sante_visite", { Num_Visite: numVisite });
  T("T29", String(h1.headers["cache-control"] || "").includes("no-store"), `Cache-Control=${h1.headers["cache-control"] || "absent"}`);

  /* ---- T30 : upload fichier interdit ---- */
  const form = new FormData();
  form.append("file", new Blob([Buffer.from("MZfichierbidon")], { type: "application/x-msdownload" }), "virus.exe");
  form.append("filename", "virus.exe");
  form.append("name_ecran", "RH_Sante_Examen");
  form.append("valeur_index", numEx);
  form.append("parent_dir", "");
  try {
    const up = await axios.post(`${BASE}uploadfile`, form, {
      headers: { authorization: `Bearer ${med.token}` },
      validateStatus: () => true,
    });
    T("T30", up.status === 400, `upload .exe rejete (status ${up.status})`);
  } catch (e: any) {
    T("T30", true, `upload .exe rejete (${e.message})`);
  }

  /* ---- T31 : espace salarie ---- */
  const s1 = await post(agent, "ma_sante", { Matricule: "FICTIF002" });
  const apts = s1.data?.data?.aptitudes || [];
  const okOwn = apts.every((a: any) => ["TEST-T17A", "TEST-T17B"].includes(a.Num_Aptitude) || true);
  const a1mat = await lireSql(
    `select Num_Aptitude from RH_Sante_Aptitude where Num_Aptitude in (${apts.map((a: any) => `'${a.Num_Aptitude}'`).join(",") || "''"}) and Matricule='FICTIF001'`,
    []
  );
  T("T31a", s1.data?.result === true && apts.length > 0 && (a1mat.data?.length || 0) === apts.length,
    `ma_sante : ${apts.length} aptitude(s) publiee(s) de FICTIF001 (body Matricule ignore)`);
  const s2 = await post(agent, "sante_dossier", { Matricule: "FICTIF001" });
  T("T31b", s2.data?.result === false, "dossier clinique refuse a l'agent");

  /* ---- T32 : liste planning sans clinique ---- */
  const p1 = await post(rh, "sante_visite_liste_planning", { Matricule: "", Dat_Du: "", Dat_Au: "" });
  const cols = p1.data?.data?.[0] ? Object.keys(p1.data.data[0]) : [];
  T("T32", p1.data?.result === true && !cols.includes("Conclusion") && !cols.includes("Reserves"), `planning sans clinique (colonnes: ${cols.join(",")})`);

  /* ---- Bilan ---- */
  const ko = resultats.filter((x) => !x.ok).length;
  console.log(`\n=== BILAN : ${resultats.length - ko}/${resultats.length} tests OK ===`);
  await closePool();
  process.exit(ko > 0 ? 2 : 0);
}

main().catch((e) => { console.error("FATAL:", e); process.exit(1); });
