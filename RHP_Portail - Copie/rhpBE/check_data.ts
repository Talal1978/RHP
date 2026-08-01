
import { lireSql } from "./modules/module_sqlRW";
import { initialisationSeveur } from "./modules/module_initialisation";

async function checkData() {
    try {
        await initialisationSeveur();
        console.log("Server initialized.");

        const sql = `select Cod_Formation, Lib_Formation, Cod_Survey from Formation where Cod_Formation = 'FOR000001'`;
        const result = await lireSql(sql);

        console.log("Formation Data:", result.data);
    } catch (e) {
        console.error("Query failed:", e);
    }
}

checkData();
