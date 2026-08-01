/* Verification post-installation + infos pour donnees de demo (lecture seule) */
import { lireSql, closePool } from "../modules/module_sqlRW";
import { initialisationSeveur } from "../modules/module_initialisation";

const requetes: { nom: string; sql: string }[] = [
  { nom: "TABLES Sante creees", sql: "SELECT name FROM sys.tables WHERE name LIKE '%Sante%' OR name LIKE 'RH_Declaration_AT_Echeance' OR name LIKE 'RH_Declaration_AT_Transmission' ORDER BY name" },
  { nom: "VUES Sante", sql: "SELECT name FROM sys.views WHERE name LIKE '%Sante%' ORDER BY name" },
  { nom: "OBJETS Sys_Sante", sql: "SELECT name, type_desc FROM sys.objects WHERE name LIKE 'Sys_Sante%' ORDER BY name" },
  { nom: "ALTER Typ_Accident", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='RH_Declaration_AT' AND COLUMN_NAME='Typ_Accident'" },
  { nom: "ALTER Num_Conge", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='RH_Declaration_AT_Detail' AND COLUMN_NAME='Num_Conge'" },
  { nom: "NB rubriques Sante", sql: "SELECT Nom_Controle, COUNT(*) as nb FROM Param_Rubriques WHERE Nom_Controle IN ('Statut_Aptitude','Typ_Visite','Critere_Periodicite','Typ_Accident','Statut_Etape_AT','Typ_Intervenant') GROUP BY Nom_Controle" },
  { nom: "ZOOMS crees", sql: "SELECT Num_Zoom FROM Controle_Def_Zoom WHERE Num_Zoom LIKE 'MS3%' OR Num_Zoom='AT010' ORDER BY Num_Zoom" },
  { nom: "ECRANS crees", sql: "SELECT Name_Ecran FROM Controle_Def_Ecran WHERE Name_Ecran LIKE 'RH_Sante%' OR Name_Ecran='RH_Declaration_AT_Suivi' ORDER BY Name_Ecran" },
  { nom: "MENU dossier", sql: "SELECT Name_Ecran, Text_Ecran, Typ_Ecran, Parent, Rang FROM Controle_TreeView WHERE Name_Ecran='FDR1_20268010900000' OR Parent='FDR1_20268010900000' ORDER BY Rang" },
  { nom: "WORKFLOW VM/FA", sql: "SELECT Typ_Document, Intitule FROM Param_Workflow_Typ_Document WHERE Typ_Document IN ('VM','FA')" },
  { nom: "FONCTIONS securite", sql: "SELECT Function_Sec, Description FROM Controle_Menu_Functions WHERE Function_Sec LIKE 'SANTE%'" },
  { nom: "PARAMS reglement", sql: "SELECT Cod_Param, Valeur FROM Param_Sante_Reglement ORDER BY Cod_Param" },
  { nom: "TRIGGERS ESP crees", sql: "SELECT name, parent_class_desc FROM sys.triggers WHERE name LIKE 'ESP[_]%Sante%' OR name LIKE 'ESP[_]RH_Declaration_AT_Echeance%' ORDER BY name" },
  { nom: "SOCIETES", sql: "SELECT id_Societe, Den FROM Param_Societe" },
  { nom: "RH_Agent colonnes NOT NULL", sql: "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='RH_Agent' AND IS_NULLABLE='NO' ORDER BY ORDINAL_POSITION" },
  { nom: "NB agents existants", sql: "SELECT id_Societe, COUNT(*) as nb FROM RH_Agent GROUP BY id_Societe" },
  { nom: "PLAN PAIE", sql: "SELECT TOP 5 Cod_Plan_Paie, id_Societe, JourPaie FROM RH_Param_Plan_Paie" },
  { nom: "AGENTS exemples", sql: "SELECT TOP 3 Matricule, id_Societe, Nom_Agent, Prenom_Agent, Cod_Poste, Cod_Entite, Sexe, Dat_Naissance FROM RH_Agent" },
];

async function main() {
  await initialisationSeveur();
  for (const q of requetes) {
    const rsl = await lireSql(q.sql);
    console.log("--- " + q.nom + " ---");
    if (!rsl.result) console.log("ERREUR:", JSON.stringify(rsl.sort).substring(0, 200));
    else if (rsl.data.length === 0) console.log("(aucune ligne)");
    else rsl.data.forEach((r: any) => console.log(JSON.stringify(r)));
    console.log("");
  }
  await closePool();
}
main().catch((e) => { console.error("FATAL:", e); process.exit(1); });
