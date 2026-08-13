import express from "express";
import multer from "multer";
import path from "path";
import { validate } from "../modules/module_jwt";
import { authentication, checkVersion, getNewPwd, refreshToken, setPwd } from "../controlers/authentication";
import { getZoomApi, getZoomLibelleApi } from "../modules/module_zoom";
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
import { conge_planning } from "../controlers/conge_planning";

import {
  delete_note_frais,
  get_note_frais,
  noteFraisListe,
  save_note_frais,
} from "../controlers/note_frais";
import {
  get_parapheur,
  get_signataires,
  has_signature_rule,
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
  sp_menu_portail, sp_page_meta, sp_document_liste, sp_get_document,
  sp_save_document, sp_delete_document, sp_validate_document, sp_exec_source,
} from "../controlers/sp_document";
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
mainRooting.post("/zoomlibelle", validate, getZoomLibelleApi);
mainRooting.post("/rubrique", validate, getRubrique);
mainRooting.get("/rubrique", validate, getRubrique);
mainRooting.get("/list_rubriques", listRubriques);
mainRooting.post("/signer", validate, signer);
mainRooting.get("/get_signataires", validate, get_signataires);
mainRooting.get("/has_signature_rule", validate, has_signature_rule);
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
mainRooting.post("/conge_planning", validate, conge_planning);

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

mainRooting.post("/get_outillage_info", validate, get_outillage_info);

/* ---- Module SP_ : pages dynamiques du portail (Designer) ---- */
mainRooting.get("/sp_menu_portail", validate, sp_menu_portail);
mainRooting.post("/sp_page_meta", validate, sp_page_meta);
mainRooting.post("/sp_document_liste", validate, sp_document_liste);
mainRooting.post("/sp_get_document", validate, sp_get_document);
mainRooting.post("/sp_save_document", validate, sp_save_document);
mainRooting.post("/sp_delete_document", validate, sp_delete_document);
mainRooting.post("/sp_validate_document", validate, sp_validate_document);
mainRooting.post("/sp_exec_source", validate, sp_exec_source);


