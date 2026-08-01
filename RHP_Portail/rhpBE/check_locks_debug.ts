
import { lireSql } from "./modules/module_sqlRW";
import { initialisationSeveur } from "./modules/module_initialisation";
import { closePool } from "./modules/module_initialisation";

async function checkDocs() {
    try {
        await initialisationSeveur();
        console.log("=== Demande conge C3068-2026000002 ===");
        const c = await lireSql(`select Num_Conge, Matricule, Statut, Dat_Deb_Conge, Dat_Fin_Conge from RH_Conge_Suivi where Num_Conge='C3068-2026000002'`);
        console.log(JSON.stringify(c.data));

        console.log("=== Notes de frais recentes ===");
        const nf = await lireSql(`select top 5 Num_NF, Matricule, Statut, Dat_NF from RH_Note_Frais order by Dat_NF desc`);
        console.log(JSON.stringify(nf.data));

        console.log("=== Agent D0011 ===");
        const ag = await lireSql(`select Matricule, Nom_Agent, Prenom_Agent, id_Societe from RH_Agent where Matricule='D0011'`);
        console.log(JSON.stringify(ag.data));

        console.log("=== Rubrique Statut_Signature ===");
        const rub = await lireSql(`select * from Param_Rubriques where Nom_Controle='Statut_Signature'`);
        console.log(JSON.stringify(rub.data));
    } catch (e) {
        console.error("Query failed:", e);
    } finally {
        try { await (closePool as any)(); } catch { }
        process.exit(0);
    }
}

checkDocs();
