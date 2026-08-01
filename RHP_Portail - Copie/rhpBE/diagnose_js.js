const fs = require('fs');
const path = require('path');
const { decrypt } = require('./modules/module_encrypt');

// Mocking minimal parts of module_initialisation/sqlRW to avoid complex dependencies
const VGLOBALES = {
    UPLOADS_PATH: "",
    // ... other fields not needed for this check
};

function checkPath() {
    const configPath = "serverConfig.json";
    if (fs.existsSync(configPath)) {
        try {
            const cnf = fs.readFileSync(configPath, { encoding: "utf-8" });
            const cnfJson = JSON.parse(cnf);
            console.log("Config loaded.");
            
            // Replicate the logic from module_initialisation
            const opath = "E:/Dev/Mobile/RayOneMobile/RayOneBE/tools/uploads";
            if (fs.existsSync(opath)) {
                console.log("E: path exists, using it.");
                VGLOBALES.UPLOADS_PATH = path.resolve(opath);
            } else {
                console.log("E: path NOT found, using local uploads.");
                VGLOBALES.UPLOADS_PATH = path.resolve(process.cwd(), "uploads");
            }
            
            console.log("Active Upload Path:", VGLOBALES.UPLOADS_PATH);
            
            if (fs.existsSync(VGLOBALES.UPLOADS_PATH)) {
                const files = fs.readdirSync(VGLOBALES.UPLOADS_PATH);
                console.log("Files found in directory:", files);
            } else {
                console.log("Directory does NOT exist.");
            }
        } catch(e) {
            console.error("Error reading config:", e);
        }
    } else {
        console.log("serverConfig.json not found.");
    }
}

checkPath();
