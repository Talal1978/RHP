import * as crypto from "crypto";

// Fixed parameters
const password = "cH0uCh0ub@B@";
const saltValue = "maraYliChaJoud";
const passwordIterations = 1000; // For example
const initVector = "XXXXXXXXXXXXXXXX"; // Must be 16 bytes
const keySize = 256; // Key size in bits

// Helper function to create a key
function createKey(): Buffer {
  const saltBytes = Buffer.from(saltValue, "utf8");
  return crypto.pbkdf2Sync(
    password,
    saltBytes,
    passwordIterations,
    keySize / 8,
    "sha1"
  );
}

// Simplified Encrypt function
export const encrypt = (textOrig: any): string => {
  const initVectorBytes = Buffer.from(initVector, "utf8");
  const textBytes = Buffer.from(textOrig, "utf8");
  const keyBytes = createKey();

  const cipher = crypto.createCipheriv(
    "aes-256-cbc",
    keyBytes,
    initVectorBytes
  );
  const encrypted = Buffer.concat([cipher.update(textBytes), cipher.final()]);
  return encrypted.toString("base64");
};

// Simplified Decrypt function
export const decrypt = (textCryp: any): string => {
  try {
    const initVectorBytes = Buffer.from(initVector, "utf8");
    const textBytes = Buffer.from(textCryp, "base64");
    const keyBytes = createKey();

    const decipher = crypto.createDecipheriv(
      "aes-256-cbc",
      keyBytes,
      initVectorBytes
    );
    const decrypted = Buffer.concat([
      decipher.update(textBytes),
      decipher.final(),
    ]);
    return decrypted.toString("utf8");
  } catch (err) {
    console.error("Decryption failed:", err);
    return ""; // Or handle the error as needed
  }
};
