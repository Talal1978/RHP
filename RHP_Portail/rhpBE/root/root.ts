import express from "express";
import multer from "multer";
import path from "path";
import { validate } from "../modules/module_jwt";
import { authentication } from "../controlers/authentication";
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
import { surveyQuestions } from "../controlers/survey";
import { ficheposte } from "../controlers/org_ficheposte";
import { generateReport } from "../controlers/report";
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
mainRooting.post("/zoom", validate, getZoomApi);
mainRooting.post("/rubrique", getRubrique);
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

mainRooting.post("/save_note_frais", validate, save_note_frais);
mainRooting.post("/note_frais_liste", validate, noteFraisListe);
mainRooting.post("/get_note_frais", validate, get_note_frais);
mainRooting.post("/delete_note_frais", validate, delete_note_frais);
mainRooting.post("/is_paie_encours", validate, isPaieEncours);
mainRooting.post("/check_accessible", validate, checkAccessible);
mainRooting.post("/release_accessible", validate, releaseAccessibleApi);
mainRooting.get("/get_ged_docs", validate, get_ged_docs);
mainRooting.post("/test", testFunction);
mainRooting.get("/download", validate, fileClass.download);
mainRooting.post("/delete_file", validate, fileClass.delete_file);
mainRooting.post("/delete_folder", validate, fileClass.delete_folder);
mainRooting.post("/ged_rename", validate, fileClass.ged_rename);
mainRooting.post("/readfile", validate, fileClass.readFile);
mainRooting.post("/newFolder", validate, fileClass.newFolder);
mainRooting.post("/savingaudio", validate, fileClass.uploadAudiBase64);
mainRooting.post("/bulletin_liste", validate, bulletin_liste);
mainRooting.get("/ficheposte", validate, ficheposte);
mainRooting.post(
  "/uploadfile",
  upload.single("file"),
  validate,
  fileClass.upload
);
async function testFunction() {
  console.log("first");
  return await lireSql("select * from RH_Agent where Matricule='1'", []);
}
