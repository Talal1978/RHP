
import { lireSql } from "./modules/module_sqlRW";
import { initialisationSeveur, VGLOBALES } from "./modules/module_initialisation";

async function checkDDL() {
    try {
        await initialisationSeveur();
        console.log(`Connected to Server: ${VGLOBALES.SQL_SERVER}, DB: ${VGLOBALES.SQL_DB}`);

        const sql = `exec sp_helptext 'dbo.Sys_Portail_DashBoard_Insights'`;
        const result = await lireSql(sql);

        if (result.data) {
            console.log("Function Definition:");
            result.data.forEach((row: any) => {
                process.stdout.write(row.Text);
            });
        }
    } catch (e) {
        console.error("Query failed:", e);
    }
}

checkDDL();
