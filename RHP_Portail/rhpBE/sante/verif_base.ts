/* Verification en lecture seule de la base RHP - Phase 2 Module Sante
   Execution : npx ts-node --transpile-only sante/verif_base.ts            */
import { lireSql, closePool } from "../modules/module_sqlRW";
import { initialisationSeveur } from "../modules/module_initialisation";

const requetes: { nom: string; sql: string }[] = [
  { nom: "BASE COURANTE", sql: "SELECT DB_NAME() as base_courante, @@SERVERNAME as serveur" },

  { nom: "COLONNES RH_Conge_Type", sql: "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='RH_Conge_Type' ORDER BY ORDINAL_POSITION" },
  { nom: "DONNEES RH_Conge_Type", sql: "SELECT * FROM RH_Conge_Type" },
  { nom: "COLONNES RH_Conge_Suivi", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='RH_Conge_Suivi' ORDER BY ORDINAL_POSITION" },
  { nom: "COLONNES RH_Conge_Suivi_Detail", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='RH_Conge_Suivi_Detail' ORDER BY ORDINAL_POSITION" },
  { nom: "DEFINITION Sys_GetCongePris", sql: "SELECT OBJECT_DEFINITION(OBJECT_ID('dbo.Sys_GetCongePris')) as def" },
  { nom: "DEFINITION Sys_Conge_Check", sql: "SELECT OBJECT_DEFINITION(OBJECT_ID('dbo.Sys_Conge_Check')) as def" },
  { nom: "DEFINITION Sys_Conge_MajConso", sql: "SELECT OBJECT_DEFINITION(OBJECT_ID('dbo.Sys_Conge_MajConso')) as def" },

  { nom: "COLONNES Controle_Profile", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Controle_Profile' ORDER BY ORDINAL_POSITION" },
  { nom: "DONNEES Controle_Profile", sql: "SELECT * FROM Controle_Profile" },
  { nom: "COLONNES Controle_Menu_Functions", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Controle_Menu_Functions' ORDER BY ORDINAL_POSITION" },
  { nom: "DONNEES Controle_Menu_Functions", sql: "SELECT * FROM Controle_Menu_Functions" },
  { nom: "COLONNES Controle_Droit_Functions", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Controle_Droit_Functions' ORDER BY ORDINAL_POSITION" },
  { nom: "DONNEES Controle_Droit_Functions", sql: "SELECT TOP 20 * FROM Controle_Droit_Functions" },

  { nom: "WORKFLOW TYPES DOCUMENT", sql: "SELECT Typ_Document, Intitule, Table_Ref, Table_Index, Name_Ecran, Index_Ecran FROM Param_Workflow_Typ_Document" },

  { nom: "ZOOMS MS3xx et AT0xx (collisions)", sql: "SELECT Num_Zoom, Table_Ref FROM Controle_Def_Zoom WHERE Num_Zoom LIKE 'MS3%' OR Num_Zoom LIKE 'AT0%' ORDER BY Num_Zoom" },
  { nom: "COLONNES Controle_Def_Zoom", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Controle_Def_Zoom' ORDER BY ORDINAL_POSITION" },

  { nom: "COLONNES Param_Rubriques", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Param_Rubriques' ORDER BY ORDINAL_POSITION" },
  { nom: "RUBRIQUES existantes AT/Sante", sql: "SELECT DISTINCT Nom_Controle FROM Param_Rubriques WHERE Nom_Controle LIKE '%AT%' OR Nom_Controle LIKE '%Aptitude%' OR Nom_Controle LIKE '%Sante%' OR Nom_Controle LIKE '%Lesion%' OR Nom_Controle LIKE '%Certificat%' ORDER BY Nom_Controle" },

  { nom: "COLONNES Controle_TreeView", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Controle_TreeView' ORDER BY ORDINAL_POSITION" },
  { nom: "TREE dossiers FDR racine et niveau 1", sql: "SELECT Name_Ecran, Text_Ecran, Typ_Ecran, Parent, Rang FROM Controle_TreeView WHERE Typ_Ecran='FDR' AND (Parent='' OR Parent IS NULL OR Parent LIKE 'FDR1_20197231657389') ORDER BY Parent, Rang" },
  { nom: "COLONNES Controle_Menu", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Controle_Menu' ORDER BY ORDINAL_POSITION" },
  { nom: "COLONNES Controle_Def_Ecran", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Controle_Def_Ecran' ORDER BY ORDINAL_POSITION" },
  { nom: "COLONNES Controle_Def_Ecran_Button", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Controle_Def_Ecran_Button' ORDER BY ORDINAL_POSITION" },
  { nom: "COLONNES Controle_Menu_Avance", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Controle_Menu_Avance' ORDER BY ORDINAL_POSITION" },
  { nom: "COLONNES Controle_Droit", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Controle_Droit' ORDER BY ORDINAL_POSITION" },
  { nom: "COLONNES Controle_Profile_Regles", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Controle_Profile_Regles' ORDER BY ORDINAL_POSITION" },

  { nom: "COLONNES RH_Declaration_AT", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='RH_Declaration_AT' ORDER BY ORDINAL_POSITION" },
  { nom: "COLONNES RH_Declaration_AT_Detail", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='RH_Declaration_AT_Detail' ORDER BY ORDINAL_POSITION" },

  { nom: "COLONNES Param_GED", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Param_GED' ORDER BY ORDINAL_POSITION" },
  { nom: "COLONNES Notifications", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Notifications' ORDER BY ORDINAL_POSITION" },
  { nom: "COLONNES Param_Audit_Espion", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Param_Audit_Espion' ORDER BY ORDINAL_POSITION" },
  { nom: "COLONNES Mouchard_Suppression", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Mouchard_Suppression' ORDER BY ORDINAL_POSITION" },

  { nom: "COLONNES RH_Agent (clefs sante)", sql: "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='RH_Agent' AND (COLUMN_NAME LIKE '%Naissance%' OR COLUMN_NAME LIKE '%Sexe%' OR COLUMN_NAME LIKE '%Genre%' OR COLUMN_NAME LIKE '%Poste%' OR COLUMN_NAME LIKE '%Entite%' OR COLUMN_NAME LIKE '%Grade%' OR COLUMN_NAME LIKE '%Categ%' OR COLUMN_NAME LIKE '%Nuit%' OR COLUMN_NAME LIKE '%Matricule%' OR COLUMN_NAME LIKE '%Nom%' OR COLUMN_NAME LIKE '%Embauche%') ORDER BY ORDINAL_POSITION" },
  { nom: "COLONNES Controle_Users", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Controle_Users' ORDER BY ORDINAL_POSITION" },
  { nom: "COLONNES Param_Societe", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Param_Societe' ORDER BY ORDINAL_POSITION" },
  { nom: "COLONNES Param_Compteur", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Param_Compteur' ORDER BY ORDINAL_POSITION" },
  { nom: "COLONNES Param_Mod_Edition", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Param_Mod_Edition' ORDER BY ORDINAL_POSITION" },
  { nom: "COLONNES Controle_Def_Ecran_Mod_Edition", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Controle_Def_Ecran_Mod_Edition' ORDER BY ORDINAL_POSITION" },

  { nom: "TABLES Sante existantes (doit etre vide)", sql: "SELECT name FROM sys.tables WHERE name LIKE '%Sante%' ORDER BY name" },
  { nom: "TABLES RH_ reference", sql: "SELECT name FROM sys.tables WHERE name LIKE 'RH_%' ORDER BY name" },
];

async function main() {
  await initialisationSeveur();
  console.log("=== VERIFICATION BASE - MODULE SANTE (lecture seule) ===\n");
  for (const q of requetes) {
    const rsl = await lireSql(q.sql);
    console.log("--- " + q.nom + " ---");
    if (!rsl.result) {
      console.log("ERREUR:", JSON.stringify(rsl.sort).substring(0, 300));
    } else if (rsl.data.length === 0) {
      console.log("(aucune ligne)");
    } else {
      for (const row of rsl.data) {
        console.log(JSON.stringify(row));
      }
    }
    console.log("");
  }
  await closePool();
  console.log("=== FIN ===");
}

main().catch((e) => { console.error("FATAL:", e); process.exit(1); });
