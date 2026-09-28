import { Request, Response } from "express";
import axios from "axios";
import { lireSql } from "../modules/module_sqlRW";
import { Int, NVarChar, DateTime } from "mssql";

export const getDashboardData = async (req: Request, res: Response) => {
    const { processId, ...theAgent } = req.params;
    const Matricule = theAgent?.Matricule || "";
    const id_Societe = Number(theAgent?.id_Societe || 0);
    if (isNaN(id_Societe) || id_Societe <= 0) {
        return res.status(400).send({ result: false, message: "id_Societe invalide" });
    }

    try {
        const sqlSignatures = `select top 5 Intitule, Valeur_Index, Name_Ecran, Index_Ecran, Typ_Document from dbo.Sys_Parapheur_Signature(@Matricule, @id_Societe)`;
        const sqlInsights = `select * from Sys_Portail_DashBoard_Insights(@Matricule, @id_Societe,5) order by Dat_Du asc`;
        const sqlBlogs = `select top 6 Num_Blog, Titre_Blog, Categorie, Tags, Contenus, Dat_Crea from Communication_Blogs where id_Societe=@id_Societe and Publier=1 order by Dat_Crea desc`;

        const now = new Date();
        const sqlSolde = `select Solde_Conge from dbo.Sys_Rh_Conge(@id_Societe,@todayStr) where Matricule=@Matricule`;

        const [signaturesResult, insightsResult, blogsResult, soldeResult] = await Promise.all([
            lireSql(sqlSignatures, [
                { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
                { param: "id_Societe", sqlType: Int, valeur: id_Societe },
            ]),
            lireSql(sqlInsights, [
                { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
                { param: "id_Societe", sqlType: Int, valeur: id_Societe },
            ]),
            lireSql(sqlBlogs, [
                { param: "id_Societe", sqlType: Int, valeur: id_Societe },
            ]),
            lireSql(sqlSolde, [
                { param: "id_Societe", sqlType: Int, valeur: id_Societe },
                { param: "todayStr", sqlType: DateTime, valeur: now },
                { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
            ]),
        ]);

        const soldeVal = (soldeResult.data && soldeResult.data.length > 0) ? soldeResult.data[0].Solde_Conge : 0;

        res.send({
            result: true,
            data: {
                signatures: signaturesResult.data || [],
                insights: insightsResult.data || [],
                blogs: blogsResult.data || [],
                solde: soldeVal
            }
        });

    } catch (error: any) {
        res.send({ result: false, message: error.message });
    }
};

/* --------------------------------------------------------------------------
   Météo du tableau de bord : relais serveur de l'API open-meteo.
   En production, les postes clients n'ont pas nécessairement accès à
   Internet (intranet) : l'appel direct du navigateur échoue. Le backend —
   seul point de sortie à autoriser — fait l'appel et le met en cache
   30 minutes (une seule requête externe pour tous les utilisateurs).
   -------------------------------------------------------------------------- */
const WEATHER_URL =
    "https://api.open-meteo.com/v1/forecast?latitude=33.5731&longitude=-7.5898&current_weather=true&hourly=relativehumidity_2m&timezone=auto";
const WEATHER_CACHE_MS = 30 * 60 * 1000;
let weatherCache: { at: number; data: unknown } | null = null;

export const getDashboardWeather = async (_req: Request, res: Response) => {
    try {
        if (weatherCache && Date.now() - weatherCache.at < WEATHER_CACHE_MS) {
            return res.send({ result: true, data: weatherCache.data });
        }
        const response = await axios.get(WEATHER_URL, { timeout: 8000 });
        const payload = response.data;
        const current = payload?.current_weather;
        if (!current) {
            return res.send({ result: false, message: "Réponse météo inattendue" });
        }
        // Humidité de l'heure courante : current_weather.time est à la
        // demi-heure près (ex. "19:30") alors que hourly.time est à l'heure
        // pile — on rapproche donc sur le préfixe "AAAA-MM-JJTHH".
        const hourPrefix = typeof current.time === "string" ? current.time.substring(0, 13) : "";
        const hourIndex = hourPrefix && Array.isArray(payload?.hourly?.time)
            ? payload.hourly.time.findIndex(
                (t: unknown) => typeof t === "string" && t.startsWith(hourPrefix)
            )
            : -1;
        const humidity =
            hourIndex >= 0 ? payload.hourly.relativehumidity_2m?.[hourIndex] ?? 45 : 45;
        const data = {
            temp: current.temperature,
            code: current.weathercode,
            wind: current.windspeed,
            humidity,
        };
        weatherCache = { at: Date.now(), data };
        res.send({ result: true, data });
    } catch (error: any) {
        res.send({ result: false, message: error.message });
    }
};

export const get_signatures_api = async (req: Request, res: Response) => {
    const { processId, ...context } = req.params;
    const Matricule = context?.Matricule || req.body?.Matricule || "";
    const id_Societe = Number(context?.id_Societe || req.body?.id_Societe || 0);
    if (isNaN(id_Societe) || id_Societe <= 0) {
        return res.status(400).send({ result: false, message: "id_Societe invalide" });
    }

    try {
        const sqlSignatures = `select Intitule, Valeur_Index, Name_Ecran, Index_Ecran, Typ_Document from dbo.Sys_Parapheur_Signature(@Matricule, @id_Societe)`;
        const rsl = await lireSql(sqlSignatures, [
            { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
            { param: "id_Societe", sqlType: Int, valeur: id_Societe },
        ]);
        res.send(rsl);
    } catch (error: any) {
        res.send({ result: false, message: error.message });
    }
};
