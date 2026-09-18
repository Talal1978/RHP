import "dotenv/config";
import express, { Request, Response, NextFunction } from "express";
import http from "http";
import path from "path";
import fs from "fs";
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

// Filet de sécurité production : Express 4 n'attrape pas les exceptions des
// handlers async ; sans ces handlers, toute promesse rejetée non gérée TUE le
// processus Node (indisponibilité totale du portail). On journalise au lieu
// de crasher — le service Windows reste vivant.
process.on("unhandledRejection", (reason) => {
  console.error("[unhandledRejection]", reason);
});
process.on("uncaughtException", (err) => {
  console.error("[uncaughtException]", err);
});

// Origines autorisées CORS. Deux mécanismes complémentaires :
//  1. SAME-ORIGIN (automatique) : le backend sert lui-même le frontend, donc
//     tout accès légitime arrive avec un Origin dont l'hôte est IDENTIQUE à
//     l'en-tête Host de la requête. On l'autorise par construction, quel que
//     soit le nom utilisé (localhost, IP, nom NetBIOS, FQDN, alias DNS) —
//     aucune configuration nécessaire, même si le serveur change de nom.
//  2. ALLOWED_ORIGINS (liste explicite, séparée par des virgules) : uniquement
//     pour les accès INTER-origines (frontend hébergé ailleurs, proxy avec un
//     nom public différent, ex. "https://portail.monclient.ma").
const envOrigins = (process.env.ALLOWED_ORIGINS || "")
  .split(",")
  .map((o) => o.trim())
  .filter((o) => o.length > 0);

const allowedOrigins = [
  "http://localhost",
  "http://localhost:5173",
  ...envOrigins,
];

function isOriginAllowed(origin: string): boolean {
  if (process.env.NODE_ENV !== "production") {
    // Dev : tout localhost quel que soit le port
    if (/^https?:\/\/localhost(:\d+)?$/.test(origin)) return true;
    if (/^https?:\/\/127\.0\.0\.1(:\d+)?$/.test(origin)) return true;
  }
  return allowedOrigins.some((o) => origin === o);
}

// Le callback du package cors ne reçoit pas la requête : on fabrique donc le
// middleware par requête (coût négligeable) pour comparer Origin et Host.
const corsMiddleware = (req: Request, res: Response, next: NextFunction) => {
  const mw = cors<Request>({
    origin: (origin, callback) => {
      if (!origin || isOriginAllowed(origin)) return callback(null, true);
      try {
        if (new URL(origin).host === req.headers.host) return callback(null, true);
      } catch { /* Origin mal formé : refusé ci-dessous */ }
      callback(new Error("L'origine : [" + origin + "] est non autorisée par le CORS"));
    },
    methods: ["POST", "GET", "OPTIONS"],
    credentials: true,
  });
  return mw(req, res, next);
};

export const app = express();
const server = http.createServer(app);
// Socket.IO : l'authentification se fait par JWT dans l'en-tête du handshake
// (PAS par cookie — un site étranger ne peut pas lire le localStorage de
// l'origine du portail pour fabriquer un handshake valide). On reflète donc
// l'origine : sans JWT valide, la connexion ne produit aucune donnée.
const io = new Server(server, {
  cors: { origin: true, methods: ["POST", "GET", "OPTIONS"], credentials: true },
});

// Si le portail est derrière un proxy inverse (IIS/ARR, nginx...), TRUST_PROXY=1
// permet de retrouver l'IP réelle du client (rate-limit, logs).
if (process.env.TRUST_PROXY === "1") {
  app.set("trust proxy", 1);
}

// CSP : les directives par défaut de helmet n'ont pas de connect-src — elle
// retombe sur default-src 'self', qui exclut les URL blob:. Or le viewer PDF
// (@react-pdf-viewer / pdf.js) charge les états via URL.createObjectURL(...)
// côté client : le navigateur bloque alors le fetch et pdf.js affiche
// « Unexpected server response (0) while retrieving PDF "blob:..." ».
// img-src / worker-src blob: couvrent les besoins internes de pdf.js.
app.use(
  helmet({
    contentSecurityPolicy: {
      directives: {
        ...helmet.contentSecurityPolicy.getDefaultDirectives(),
        "connect-src": ["'self'", "blob:"],
        "img-src": ["'self'", "data:", "blob:"],
        "worker-src": ["'self'", "blob:"],
      },
    },
  })
);
app.use(compression());
app.use(corsMiddleware);
app.use(cookieParser());
app.use(express.urlencoded({ extended: true }));
app.use(express.json());

const limiter = rateLimit({
  windowMs: 15 * 60 * 1000,
  // Plafond configurable (RATE_LIMIT_MAX) : sur un site client, de nombreux
  // utilisateurs peuvent partager la même IP (NAT/proxy). 200 est le défaut
  // historique ; prévoir plus haut en production multi-utilisateurs.
  max: Number(process.env.RATE_LIMIT_MAX) > 0 ? Number(process.env.RATE_LIMIT_MAX) : 200,
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

// --- Frontend statique (production : le backend sert le build Vite) ---
// STATIC_PATH = dossier du build frontend (index.html + assets). Par défaut,
// ../frontend relatif au répertoire d'exécution du backend. En dev (Vite sur
// le port 5173), ce bloc est simplement inactif si le dossier n'existe pas.
const staticPath = path.resolve(
  process.env.STATIC_PATH || path.join(process.cwd(), "..", "frontend")
);
const staticActif = fs.existsSync(path.join(staticPath, "index.html"));
if (staticActif) {
  app.use(express.static(staticPath));
  console.log(`[Static] Frontend servi depuis ${staticPath}`);
}

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

// Fallback SPA : toute route non-API renvoie index.html (React Router).
// Placé APRÈS toutes les routes (/api, /health) pour ne pas les masquer.
if (staticActif) {
  app.get("*", (req, res, next) => {
    if (req.path.startsWith("/api") || req.path.startsWith("/socket.io")) {
      return next();
    }
    res.sendFile(path.join(staticPath, "index.html"));
  });
}

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
