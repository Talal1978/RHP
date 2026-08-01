const fs = require('fs');
const path = require('path');

console.log("CWD:", process.cwd());
console.log("__dirname:", __dirname);
const uploadPath = path.resolve(process.cwd(), "uploads");
console.log("Resolved Upload Path:", uploadPath);

if (!fs.existsSync(uploadPath)) {
    console.log("Upload path does not exist, creating...");
    fs.mkdirSync(uploadPath);
}

const testFile = path.join(uploadPath, "test_write.txt");
fs.writeFileSync(testFile, "Hello World");
console.log("Wrote test file to:", testFile);
console.log("File exists?", fs.existsSync(testFile));
