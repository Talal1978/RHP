import express, { Request } from "express";
import http from "http";
import jwt from "jsonwebtoken";
import { Server } from "socket.io";
import cors from "cors-ts";
import dotenv from "dotenv";
import cookieParser from "cookie-parser";
import mainRooting from "../root/root";
import { VGLOBALES, initialisationSeveur, initialisationGlobale } from "../modules/module_initialisation";
import { TJwtSession } from "../modules/module_jwt";
import { lireSql } from "../modules/module_sqlRW";
import { decrypt } from "../modules/module_encrypt";
dotenv.config();
process.env.TZ = "Africa/Casablanca";
export const myCors = {
  origin: (origin: any, callback: any) => {
    if (
      (origin || "")?.startsWith("http://localhost") ||
      (origin || "")?.startsWith("https://ray1.ma") ||
      (origin || "*")?.startsWith("*")
    ) {
      callback(null, true);
    } else {
      // Deny all other requests
      callback(
        new Error("L'origine : [" + origin + "] est non autorisé par le CORS")
      );
    }
  },
  methods: ["POST", "GET", "OPTIONS"],
  credentials: true,
};

export const app = express();
const server = http.createServer(app);
const io = new Server(server, { cors: myCors });
app.use(cors<Request>(myCors));
app.use(cookieParser());
app.use(express.urlencoded({ extended: true }));
app.use(express.json()); // Middleware to parse JSON bodies
app.use("/api", mainRooting);
io.on("connection", (socket) => {
  let _Matricule: String, _Nom: String, _Mail: String;
  jwt.verify(
    String(socket.handshake.headers?.jwt || ""),
    VGLOBALES.JWT_KEY,
    (err, decod) => {
      if (decod) {
        const { Matricule, Nom, Mail, id_Societe } = decod as TJwtSession;
        _Matricule = Matricule;
        if (Matricule) {
          socket.emit("connecte", Matricule);

          setInterval(async () => {
            let nbSignature = 0;
            const rsl = await lireSql(
              `select count(*) as nb from dbo.Sys_Parapheur_Signature('${Matricule}','${id_Societe}')`
            );
            if (rsl.result) nbSignature = rsl.data?.[0].nb;
            socket.emit("nbSignature", nbSignature);
          }, 2000);
        }
      }
    }
  );
  socket.on("disconnect", () => {

  });
});

const startServer = async () => {
  try {
    await initialisationGlobale();

    server.listen(VGLOBALES.PORT, async () => {
      console.log(`Serveur démarré sur le port ${VGLOBALES.PORT}`);
    });
  } catch (error) {
    console.error("Failed to start server:", error);
    process.exit(1);
  }
};

startServer();
