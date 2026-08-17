import "dotenv/config";
import express, { Request, Response, NextFunction } from "express";
import http from "http";
import jwt from "jsonwebtoken";
import { Server } from "socket.io";
import cors from "cors-ts";
import cookieParser from "cookie-parser";
import helmet from "helmet";
import rateLimit from "express-rate-limit";
import compression from "compression";
import mainRooting from "../root/root";
import { VGLOBALES, initialisationGlobale } from "../modules/module_initialisation";
import { TJwtSession } from "../modules/module_jwt";
import { lireSql, getPool } from "../modules/module_sqlRW";
process.env.TZ = "Africa/Casablanca";

if (!process.env.JWT_KEY) {
  console.error("[FATAL] JWT_KEY n'est pas définie dans les variables d'environnement.");
  process.exit(1);
}

const allowedOrigins = [
  "http://localhost",
  "http://localhost:5173",
  "https://ray1.ma",
];

function isOriginAllowed(origin: string): boolean {
  return allowedOrigins.some((o) => {
    if (origin === o) return true;
    // Permet http://localhost:* pour le dev Vite
    if (o === "http://localhost" && /^http:\/\/localhost(:\d+)?$/.test(origin)) return true;
    return false;
  });
}

export const myCors = {
  origin: (origin: string | undefined, callback: (err: Error | null, allow?: boolean) => void) => {
    if (!origin || isOriginAllowed(origin)) {
      callback(null, true);
    } else {
      callback(new Error("L'origine : [" + origin + "] est non autorisée par le CORS"));
    }
  },
  methods: ["POST", "GET", "OPTIONS"],
  credentials: true,
};

export const app = express();
const server = http.createServer(app);
const io = new Server(server, { cors: myCors });

app.use(helmet());
app.use(compression());
app.use(cors<Request>(myCors));
app.use(cookieParser());
app.use(express.urlencoded({ extended: true }));
app.use(express.json());

const limiter = rateLimit({
  windowMs: 15 * 60 * 1000,
  max: 200,
  standardHeaders: true,
  legacyHeaders: false,
  message: "Trop de requêtes, veuillez réessayer plus tard.",
  // Hors production (dev localhost) : pas de bridage. Le StrictMode de React
  // double chaque appel API et la navigation enchaîne les écrans — 200 req/15 min
  // sont consommées en quelques minutes, puis TOUTES les API répondent 429 et
  // chaque page document retombe sur ses valeurs initiales (page vide).
  skip: () => process.env.NODE_ENV !== "production",
});
app.use(limiter);

const authLimiter = rateLimit({
  windowMs: 15 * 60 * 1000,
  max: 10,
  message: "Trop de tentatives de connexion. Réessayez plus tard.",
  // Même exemption hors production que le limiteur global (déconnexions /
  // reconnexions en chaîne pendant les tests ne doivent pas verrouiller).
  skip: () => process.env.NODE_ENV !== "production",
});
app.use("/api/auth", authLimiter);
app.use("/api/getNewPwd", authLimiter);

app.use("/api", mainRooting);

app.get("/health", async (req, res) => {
  try {
    const poolCheck = await getPool();
    if (poolCheck.connected) {
      return res.status(200).send({ status: "ok", db: "connected", timestamp: new Date().toISOString() });
    }
    return res.status(503).send({ status: "degraded", db: "disconnected", timestamp: new Date().toISOString() });
  } catch (e) {
    return res.status(503).send({ status: "error", db: "unreachable", timestamp: new Date().toISOString() });
  }
});

// Middleware d'erreur global
app.use((err: any, req: Request, res: Response, next: NextFunction) => {
  console.error("[Express Error]", err);
  if (res.headersSent) {
    return next(err);
  }
  res.status(500).send({ result: false, message: "Erreur interne du serveur" });
});

io.on("connection", (socket) => {
  let intervalId: NodeJS.Timeout | null = null;
  jwt.verify(
    String(socket.handshake.headers?.jwt || ""),
    VGLOBALES.JWT_KEY,
    (err, decod) => {
      if (decod) {
        const { Matricule, id_Societe } = decod as TJwtSession;
        if (Matricule) {
          socket.emit("connecte", Matricule);
          intervalId = setInterval(async () => {
            try {
              let nbSignature = 0;
              const rsl = await lireSql(
                `select count(*) as nb from dbo.Sys_Parapheur_Signature(@Matricule,@id_Societe)`,
                [
                  { param: "Matricule", sqlType: require("mssql").NVarChar, valeur: Matricule },
                  { param: "id_Societe", sqlType: require("mssql").Int, valeur: id_Societe },
                ]
              );
              if (rsl.result) nbSignature = rsl.data?.[0]?.nb ?? 0;
              socket.emit("nbSignature", nbSignature);
            } catch (e) {
              console.error("[Socket.IO] Erreur polling signature:", e);
            }
          }, 10000); // Polling allégé : 10s au lieu de 2s
        }
      }
    }
  );
  socket.on("disconnect", () => {
    if (intervalId) clearInterval(intervalId);
  });
});

const startServer = async () => {
  try {
    await initialisationGlobale();
    server.listen(VGLOBALES.PORT, () => {
      console.log(`Serveur démarré sur le port ${VGLOBALES.PORT}`);
    });
  } catch (error) {
    console.error("Failed to start server:", error);
    process.exit(1);
  }
};

startServer();
