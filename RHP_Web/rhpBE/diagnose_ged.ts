import { VGLOBALES, initialisationSeveur } from "./modules/module_initialisation";
import { lireSql } from "./modules/module_sqlRW";
import fs from "fs";

async function diagnose() {
    try {
        await initialisationSeveur();
        console.log("Current Upload Path:", VGLOBALES.UPLOADS_PATH);

        if (fs.existsSync(VGLOBALES.UPLOADS_PATH)) {
            const files = fs.readdirSync(VGLOBALES.UPLOADS_PATH);
            console.log("Files in Upload Path:", files);
        } else {
            console.log("Upload Path does not exist!");
        }

        const rsl = await lireSql("select top 5 FD_id, FD_Alias, Created_By, dat_crea from Param_GED order by FD_id desc", []);
        if (rsl.result) {
            console.log("Recent DB Entries:", rsl.data);
        } else {
            console.log("DB Read Error:", rsl.message);
        }

    } catch (e) {
        console.error("Diagnosis Error:", e);
    }
}

diagnose();
