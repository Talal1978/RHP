const fs = require('fs');
const path = require('path');

console.log("Checking E: path...");
const ePath = "E:/Dev/Mobile/RayOneMobile/RayOneBE/tools/uploads";
if (fs.existsSync(ePath)) {
    console.log("E: path EXISTS.");
    try {
        console.log("Files in E:", fs.readdirSync(ePath));
    } catch(e) { console.log("Cannot read E:", e.message); }
} else {
    console.log("E: path does NOT exist.");
}

console.log("Checking local uploads path...");
const localPath = path.resolve(process.cwd(), "uploads");
console.log("Local path:", localPath);
if (fs.existsSync(localPath)) {
    console.log("Local path EXISTS.");
    console.log("Files in local:", fs.readdirSync(localPath));
} else {
    console.log("Local path does NOT exist.");
}
