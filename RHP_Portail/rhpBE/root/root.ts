import express from "express";
import multer from "multer";
import path from "path";
import { validate } from "../modules/module_jwt";
import { authentication, checkVersion, getNewPwd, refreshToken, setPwd } from "../controlers/authentication";
import { getZoomApi } from "../modules/module_zoom";
import { findLibelleApi } from "../modules/module_findLibelle";
import { getRubrique, listRubriques } from "../modules/module_rubrique";
import { rh_agent } from "../controlers/rh_agent";
import { lireSql } from "../modules/module_sqlRW";
import { get_ged_docs } from "../controlers/ged";
import fileClass from "../modules/module_file";
import { bulletin_liste } from "../controlers/rh_bulletin_liste";
import {
  demande_avance_liste,
  get_demande_avance,
  save_demande_avance,
  delete_demande_avance,
  get_mnt_avances_encours,
} from "../controlers/demande_avance";

import {
  demande_pret_liste,
  get_demande_pret,
  save_demande_pret,
  delete_demande_pret,
  get_mnt_prets_encours,
} from "../controlers/demande_pret";

import {
  dossier_maladie_liste,
  get_dossier_maladie,
  save_dossier_maladie,
  delete_dossier_maladie,
} from "../controlers/dossier_maladie";

import {
  demande_conge_liste,
  get_demande_conge,
  save_demande_conge,
  delete_demande_conge,
  get_conge_droits,
  calcul_conge,
} from "../controlers/demande_conge";

import {
  delete_note_frais,
  get_note_frais,
  noteFraisListe,
  save_note_frais,
} from "../controlers/note_frais";
import {
  get_parapheur,
  get_signataires,
  signer,
} from "../modules/module_workflow";
import {
  checkAccessible,
  isPaieEncours,
  releaseAccessibleApi,
} from "../modules/module_access";
import { surveyAnswers, surveyAnswersSave, surveyQuestions } from "../controlers/survey";
import { ficheposte } from "../controlers/org_ficheposte";
import { generateReport } from "../controlers/report";
import { getEvaluationListe } from "../controlers/evaluation";
import { formation_evaluation_context, formation_evaluation_liste, get_formation, get_formation_liste, save_formation } from "../controlers/formation";
import { getOrganigramme, getPoste } from "../controlers/organization";
import {
  get_recrutement_demande,
  save_recrutement_demande,
  delete_recrutement_demande,
  get_recrutement_demande_liste
} from "../controlers/recrutement";
import { get_avancement_timeline } from "../controlers/rh_avancement";
import { get_agenda } from "../controlers/agenda";
import { discipline_liste, get_discipline } from "../controlers/discipline";
import { get_diverse_editions } from "../controlers/editions";
import {
  demandeDocAdminListe,
  get_demande_doc_admin,
  save_demande_doc_admin,
  delete_demande_doc_admin,
} from "../controlers/demande_doc_admin";
import { declarationATListe, get_declaration_at } from "../controlers/declaration_at";
import { getDashboardData } from "../controlers/dashboard";
import { getDashboardWidgetData } from "../controlers/dashboard_widgets";
import { execDashboardQueryWidget, getDashboardQueryWidgetCatalog } from "../controlers/dashboard_query_widgets";
import { get_communication_blog, get_communication_blogs_liste } from "../controlers/communication";
import { ask_ai_assistant } from "../controlers/ai_assistant";
import {
  outillageMouvementListe,
  get_outillage_mouvement,
  save_outillage_mouvement,
  delete_outillage_mouvement,
  get_outillage_info,
} from "../controlers/outillage_mouvement";
import {
  sante_visite_liste, sante_visite_liste_planning, get_sante_visite,
  save_sante_visite, delete_sante_visite, sante_calcul_echeance, sante_dossier,
} from "../controlers/sante_visite";
import {
  sante_aptitude_liste, get_sante_aptitude, save_sante_aptitude, sante_aptitude_masse,
} from "../controlers/sante_aptitude";
import {
  sante_consultation_liste, get_sante_consultation, save_sante_consultation,
  delete_sante_consultation, sante_vaccination_liste, save_sante_vaccination,
} from "../controlers/sante_infirmerie";
import {
  sante_examen_liste, get_sante_examen, save_sante_examen, delete_sante_examen,
} from "../controlers/sante_examen";
import {
  sante_maladie_pro_liste, get_sante_maladie_pro, save_sante_maladie_pro,
  delete_sante_maladie_pro, save_sante_maladie_pro_statut,
} from "../controlers/sante_maladie_pro";
import {
  sante_campagne_liste, get_sante_campagne, save_sante_campagne, delete_sante_campagne,
  sante_convocation_generer, save_sante_convocation,
} from "../controlers/sante_campagne";
import {
  sante_at_suivi_get, save_sante_at_typ, sante_at_generer_echeances,
  save_sante_at_echeance, save_sante_at_transmission, sante_at_stats,
} from "../controlers/sante_at_suivi";
import {
  ma_sante, sante_tableau_bord, sante_rapport_annuel_donnees, sante_rapport_annuel_controle,
  save_sante_rapport_annuel, sante_audit_liste,
  sante_intervenant_liste, save_sante_intervenant,
  sante_periodicite_liste, save_sante_periodicite,
  sante_reglement_liste, save_sante_reglement,
  sante_destinataire_liste, save_sante_destinataire,
  sante_etape_at_liste, save_sante_etape_at,
  sante_heures_liste, save_sante_heures,
  sante_poste_risque_liste, save_sante_poste_risque,
  sante_agent_critere_liste, save_sante_agent_critere,
} from "../controlers/sante_divers";
import {
  sante_aptitude_pdf, sante_incident_at_pdf, sante_rapport_annuel_pdf,
} from "../controlers/sante_report";
const mainRooting = express.Router();
const storage = multer.diskStorage({
  destination: async (req, file, cb) => {
    cb(null, path.resolve(process.cwd(), "tmp"));
  },
  filename: (req, file, cb) => {
    const originalName = file.originalname;
    cb(null, `${Date.now()}-${originalName}`);
  },
});
const upload = multer({ storage: storage });
export default mainRooting;

mainRooting.get("/auth", authentication);
mainRooting.get("/check_version", checkVersion);
mainRooting.post("/refresh", refreshToken);
mainRooting.post("/getNewPwd", getNewPwd);
mainRooting.post("/setPwd", validate, setPwd);
mainRooting.post("/zoom", validate, getZoomApi);
mainRooting.post("/rubrique", validate, getRubrique);
mainRooting.get("/rubrique", validate, getRubrique);
mainRooting.get("/list_rubriques", listRubriques);
mainRooting.post("/signer", validate, signer);
mainRooting.get("/get_signataires", validate, get_signataires);
mainRooting.get("/get_parapheur", validate, get_parapheur);
mainRooting.post("/getreport", validate, generateReport);
mainRooting.post("/findlibelle", findLibelleApi);
mainRooting.post("/rh_agent", validate, rh_agent);
mainRooting.post("/get_demande_avance", validate, get_demande_avance);
mainRooting.post("/demande_avance_liste", validate, demande_avance_liste);
mainRooting.post("/save_demande_avance", validate, save_demande_avance);
mainRooting.post("/get_mnt_avances_encours", validate, get_mnt_avances_encours);
mainRooting.post("/delete_demande_avance", validate, delete_demande_avance);

mainRooting.post("/get_demande_pret", validate, get_demande_pret);
mainRooting.post("/demande_pret_liste", validate, demande_pret_liste);
mainRooting.post("/save_demande_pret", validate, save_demande_pret);
mainRooting.post("/get_mnt_prets_encours", validate, get_mnt_prets_encours);
mainRooting.post("/delete_demande_pret", validate, delete_demande_pret);

mainRooting.post("/get_dossier_maladie", validate, get_dossier_maladie);
mainRooting.post("/dossier_maladie_liste", validate, dossier_maladie_liste);
mainRooting.post("/save_dossier_maladie", validate, save_dossier_maladie);
mainRooting.post("/get_mnt_prets_encours", validate, get_mnt_prets_encours);
mainRooting.post("/delete_dossier_maladie", validate, delete_dossier_maladie);

mainRooting.post("/get_demande_conge", validate, get_demande_conge);
mainRooting.post("/demande_conge_liste", validate, demande_conge_liste);
mainRooting.post("/save_demande_conge", validate, save_demande_conge);
mainRooting.post("/get_mnt_prets_encours", validate, get_mnt_prets_encours);
mainRooting.post("/delete_demande_conge", validate, delete_demande_conge);
mainRooting.post("/get_conge_droits", validate, get_conge_droits);
mainRooting.post("/calcul_conge", validate, calcul_conge);

mainRooting.get("/surveyQuestions", validate, surveyQuestions);
mainRooting.get("/surveyAnswers", validate, surveyAnswers);
mainRooting.post("/surveyAnswersSave", validate, surveyAnswersSave);

mainRooting.post("/save_note_frais", validate, save_note_frais);
mainRooting.post("/note_frais_liste", validate, noteFraisListe);
mainRooting.post("/get_note_frais", validate, get_note_frais);
mainRooting.post("/delete_note_frais", validate, delete_note_frais);
mainRooting.post("/is_paie_encours", validate, isPaieEncours);
mainRooting.post("/check_accessible", validate, checkAccessible);
mainRooting.post("/release_accessible", validate, releaseAccessibleApi);
mainRooting.get("/get_ged_docs", validate, get_ged_docs);
mainRooting.get("/download", validate, fileClass.download);
mainRooting.post("/delete_file", validate, fileClass.delete_file);
mainRooting.post("/delete_folder", validate, fileClass.delete_folder);
mainRooting.post("/ged_rename", validate, fileClass.ged_rename);
mainRooting.post("/readfile", validate, fileClass.readFile);
mainRooting.post("/newFolder", validate, fileClass.newFolder);
mainRooting.post("/savingaudio", validate, fileClass.uploadAudiBase64);
mainRooting.post("/bulletin_liste", validate, bulletin_liste);

mainRooting.post("/get_organigramme", validate, getOrganigramme);
mainRooting.post("/getPoste", validate, getPoste);
mainRooting.post("/evaluation_liste", validate, getEvaluationListe);
mainRooting.post("/formation_evaluation_context", validate, formation_evaluation_context);
mainRooting.post("/formation_evaluation_liste", validate, formation_evaluation_liste);
mainRooting.post("/get_formation_liste", validate, get_formation_liste);
mainRooting.post("/get_formation", validate, get_formation);
mainRooting.post("/save_formation", validate, save_formation);
mainRooting.post("/get_recrutement_demande", validate, get_recrutement_demande);
mainRooting.post("/save_recrutement_demande", validate, save_recrutement_demande);
mainRooting.post("/delete_recrutement_demande", validate, delete_recrutement_demande);
mainRooting.post("/get_recrutement_demande_liste", validate, get_recrutement_demande_liste);
mainRooting.post("/get_avancement_timeline", validate, get_avancement_timeline);
mainRooting.post("/get_agenda", validate, get_agenda);
mainRooting.post("/discipline_liste", validate, discipline_liste);
mainRooting.post("/get_discipline", validate, get_discipline);
mainRooting.get("/ficheposte", validate, ficheposte);
mainRooting.post(
  "/uploadfile",
  upload.single("file"),
  validate,
  fileClass.upload
);
mainRooting.post("/get_diverse_editions", validate, get_diverse_editions);

mainRooting.post("/demande_doc_admin_liste", validate, demandeDocAdminListe);
mainRooting.post("/get_demande_doc_admin", validate, get_demande_doc_admin);
mainRooting.post("/save_demande_doc_admin", validate, save_demande_doc_admin);
mainRooting.post("/delete_demande_doc_admin", validate, delete_demande_doc_admin);

mainRooting.post("/declarationATListe", validate, declarationATListe);
mainRooting.post("/get_declaration_at", validate, get_declaration_at);
mainRooting.post("/dashboard", validate, getDashboardData);
mainRooting.post("/dashboard_widget", validate, getDashboardWidgetData);
mainRooting.post("/dashboard_widget_catalog", validate, getDashboardQueryWidgetCatalog);
mainRooting.post("/dashboard_widget_exec", validate, execDashboardQueryWidget);
mainRooting.post("/communication_blogs_liste", validate, get_communication_blogs_liste);
mainRooting.post("/get_communication_blog", validate, get_communication_blog);
mainRooting.post("/ask_ai", validate, ask_ai_assistant);

mainRooting.post("/outillage_mouvement_liste", validate, outillageMouvementListe);
mainRooting.post("/get_outillage_mouvement", validate, get_outillage_mouvement);
mainRooting.post("/save_outillage_mouvement", validate, save_outillage_mouvement);
mainRooting.post("/delete_outillage_mouvement", validate, delete_outillage_mouvement);

/* ---- Module Sante, Infirmerie & Medecine du travail ---- */
mainRooting.post("/sante_visite_liste", validate, sante_visite_liste);
mainRooting.post("/sante_visite_liste_planning", validate, sante_visite_liste_planning);
mainRooting.post("/get_sante_visite", validate, get_sante_visite);
mainRooting.post("/save_sante_visite", validate, save_sante_visite);
mainRooting.post("/delete_sante_visite", validate, delete_sante_visite);
mainRooting.post("/sante_calcul_echeance", validate, sante_calcul_echeance);
mainRooting.post("/sante_dossier", validate, sante_dossier);
mainRooting.post("/sante_aptitude_liste", validate, sante_aptitude_liste);
mainRooting.post("/get_sante_aptitude", validate, get_sante_aptitude);
mainRooting.post("/save_sante_aptitude", validate, save_sante_aptitude);
mainRooting.post("/sante_aptitude_masse", validate, sante_aptitude_masse);
mainRooting.post("/sante_consultation_liste", validate, sante_consultation_liste);
mainRooting.post("/get_sante_consultation", validate, get_sante_consultation);
mainRooting.post("/save_sante_consultation", validate, save_sante_consultation);
mainRooting.post("/delete_sante_consultation", validate, delete_sante_consultation);
mainRooting.post("/sante_vaccination_liste", validate, sante_vaccination_liste);
mainRooting.post("/save_sante_vaccination", validate, save_sante_vaccination);
mainRooting.post("/sante_examen_liste", validate, sante_examen_liste);
mainRooting.post("/get_sante_examen", validate, get_sante_examen);
mainRooting.post("/save_sante_examen", validate, save_sante_examen);
mainRooting.post("/delete_sante_examen", validate, delete_sante_examen);
mainRooting.post("/sante_maladie_pro_liste", validate, sante_maladie_pro_liste);
mainRooting.post("/get_sante_maladie_pro", validate, get_sante_maladie_pro);
mainRooting.post("/save_sante_maladie_pro", validate, save_sante_maladie_pro);
mainRooting.post("/delete_sante_maladie_pro", validate, delete_sante_maladie_pro);
mainRooting.post("/save_sante_maladie_pro_statut", validate, save_sante_maladie_pro_statut);
mainRooting.post("/sante_campagne_liste", validate, sante_campagne_liste);
mainRooting.post("/get_sante_campagne", validate, get_sante_campagne);
mainRooting.post("/save_sante_campagne", validate, save_sante_campagne);
mainRooting.post("/delete_sante_campagne", validate, delete_sante_campagne);
mainRooting.post("/sante_convocation_generer", validate, sante_convocation_generer);
mainRooting.post("/save_sante_convocation", validate, save_sante_convocation);
mainRooting.post("/sante_at_suivi_get", validate, sante_at_suivi_get);
mainRooting.post("/save_sante_at_typ", validate, save_sante_at_typ);
mainRooting.post("/sante_at_generer_echeances", validate, sante_at_generer_echeances);
mainRooting.post("/save_sante_at_echeance", validate, save_sante_at_echeance);
mainRooting.post("/save_sante_at_transmission", validate, save_sante_at_transmission);
mainRooting.post("/sante_at_stats", validate, sante_at_stats);
mainRooting.post("/ma_sante", validate, ma_sante);
mainRooting.post("/sante_tableau_bord", validate, sante_tableau_bord);
mainRooting.post("/sante_rapport_annuel_donnees", validate, sante_rapport_annuel_donnees);
mainRooting.post("/sante_rapport_annuel_controle", validate, sante_rapport_annuel_controle);
mainRooting.post("/save_sante_rapport_annuel", validate, save_sante_rapport_annuel);
mainRooting.post("/sante_audit_liste", validate, sante_audit_liste);
mainRooting.post("/sante_intervenant_liste", validate, sante_intervenant_liste);
mainRooting.post("/save_sante_intervenant", validate, save_sante_intervenant);
mainRooting.post("/sante_periodicite_liste", validate, sante_periodicite_liste);
mainRooting.post("/save_sante_periodicite", validate, save_sante_periodicite);
mainRooting.post("/sante_reglement_liste", validate, sante_reglement_liste);
mainRooting.post("/save_sante_reglement", validate, save_sante_reglement);
mainRooting.post("/sante_destinataire_liste", validate, sante_destinataire_liste);
mainRooting.post("/save_sante_destinataire", validate, save_sante_destinataire);
mainRooting.post("/sante_etape_at_liste", validate, sante_etape_at_liste);
mainRooting.post("/save_sante_etape_at", validate, save_sante_etape_at);
mainRooting.post("/sante_heures_liste", validate, sante_heures_liste);
mainRooting.post("/save_sante_heures", validate, save_sante_heures);
mainRooting.post("/sante_poste_risque_liste", validate, sante_poste_risque_liste);
mainRooting.post("/save_sante_poste_risque", validate, save_sante_poste_risque);
mainRooting.post("/sante_agent_critere_liste", validate, sante_agent_critere_liste);
mainRooting.post("/save_sante_agent_critere", validate, save_sante_agent_critere);
mainRooting.post("/sante_aptitude_pdf", validate, sante_aptitude_pdf);
mainRooting.post("/sante_incident_at_pdf", validate, sante_incident_at_pdf);
mainRooting.post("/sante_rapport_annuel_pdf", validate, sante_rapport_annuel_pdf);
mainRooting.post("/get_outillage_info", validate, get_outillage_info);


