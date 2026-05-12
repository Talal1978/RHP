
import { lireSql } from "./modules/module_sqlRW";
import { initialisationSeveur } from "./modules/module_initialisation";

async function check() {
    try {
        await initialisationSeveur();
        console.log("Server initialized.");

        // Query using the Matricule seen in screenshot 'D0011' and assuming id_Societe=1
        // Also try to find the Id_Societe for this agent first to be sure
        const agtSql = "select top 1 id_Societe from Rh_Agent where Matricule='D0011'";
        const agtRes = await lireSql(agtSql);
        const idSoc = agtRes.data && agtRes.data.length > 0 ? agtRes.data[0].id_Societe : 1;
        console.log(`Testing for Matricule='D0011' and id_Societe=${idSoc}`);

        const sql = `select * from Sys_Portail_DashBoard_Insights('D0011', ${idSoc}, 10)`;
        const result = await lireSql(sql);

        if (result.data && result.data.length > 0) {
            console.log("Rows returned:", result.data.length);
            const formation = result.data.find((r: any) => r.Code === 'FOR000001');
            if (formation) {
                console.log("Found FOR000001. Keys:", Object.keys(formation));
                console.log("Cod_Survey Value:", formation.Cod_Survey);
            } else {
                console.log("FOR000001 not found in insights for this user.");
                console.log("First row keys:", Object.keys(result.data[0]));
            }
        } else {
            console.log("No result from function.");
        }
    } catch (e) {
        console.error("Query failed:", e);
    }
}

check();
