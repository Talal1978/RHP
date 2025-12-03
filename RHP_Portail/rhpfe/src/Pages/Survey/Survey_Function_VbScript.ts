// --- OBJET DE CONTEXTE GLOBAL DU MODULE (Pour l'injection) ---
const VB_FUNCTIONS = {
    SiNull, Si, SansEspace, Remplacer, Puissance, NullSi,
    Mois, Miniscule, Min, Max, Majiscule, Maintenant, Jour,
    Gauche, Floor, Droite, CountWorkingDays, Ceiling, Arrondir, Annee, InStr,
    Len, Mid, IsNull, IsNumeric, CInt, CDbl, CStr, Abs, Sqr, Int, Trim, LTrim, RTrim
};

function traitementFonctions(strFonction: string) {
    if (!strFonction) return strFonction;
    if (typeof strFonction !== "string") return strFonction;

    // Nettoyage initial
    let rg = /^\s*=|{|}/gi;
    strFonction = strFonction.replace(rg, "");
    strFonction = strFonction.replace(/;/g, ",");

    // Remplacement des fonctions
    const fnName = Object.keys(VB_FUNCTIONS);
    for (let fn of fnName) {
        rg = new RegExp(`(?<=^|[\\s=]|[^a-z0-9])${fn}\\s?\\(`, "gi");
        strFonction = strFonction.replace(rg, ` ${fn}(`);
    }

    // Valeurs booléennes et nulles VBScript
    strFonction = strFonction.replace(/\bTrue\b/gi, 'true');
    strFonction = strFonction.replace(/\bFalse\b/gi, 'false');
    strFonction = strFonction.replace(/\bNothing\b/gi, 'null');
    strFonction = strFonction.replace(/\bEmpty\b/gi, 'null');

    // ORDRE CRITIQUE: Protéger les opérateurs booléens avec des marqueurs temporaires
    // pour éviter que && ne devienne ++ lors du remplacement de &
    strFonction = strFonction.replace(/\sOR\s/gi, ' ___OR___ ');
    strFonction = strFonction.replace(/\sAND\s/gi, ' ___AND___ ');
    strFonction = strFonction.replace(/\sNOT\s/gi, ' ___NOT___ ');

    // Opérateur de concaténation VBScript (& -> +)
    strFonction = strFonction.replace(/&/g, '+');

    // Restaurer les opérateurs booléens APRÈS le remplacement de &
    strFonction = strFonction.replace(/___OR___/g, '||');
    strFonction = strFonction.replace(/___AND___/g, '&&');
    strFonction = strFonction.replace(/___NOT___/g, '!');

    // APPROCHE ROBUSTE POUR LES OPÉRATEURS DE COMPARAISON
    // 1. D'abord, remplacer <> par !==
    strFonction = strFonction.replace(/<>/g, '!==');

    // 2. Protéger les opérateurs composés avec des marqueurs temporaires
    strFonction = strFonction.replace(/<=>/g, '___LTE___');  // Au cas où
    strFonction = strFonction.replace(/>=/g, '___GTE___');
    strFonction = strFonction.replace(/<=/g, '___LTE___');
    strFonction = strFonction.replace(/===/g, '___EQ3___');
    strFonction = strFonction.replace(/==/g, '___EQ2___');
    strFonction = strFonction.replace(/!==/g, '___NEQ3___');
    strFonction = strFonction.replace(/!=/g, '___NEQ2___');

    // 3. Remplacer les = simples restants par ===
    // FIX CRITIQUE: Inclure les chaînes entre guillemets dans le match
    // Matches: mots, nombres, parenthèses fermantes, OU chaînes entre guillemets
    strFonction = strFonction.replace(/(\w+|\)|"[^"]*")\s*=\s*(\w+|\(|"[^"]*")/g, '$1 === $2');

    // 4. Restaurer les opérateurs protégés
    strFonction = strFonction.replace(/___GTE___/g, '>=');
    strFonction = strFonction.replace(/___LTE___/g, '<=');
    strFonction = strFonction.replace(/___EQ3___/g, '===');
    strFonction = strFonction.replace(/___EQ2___/g, '==');
    strFonction = strFonction.replace(/___NEQ3___/g, '!==');
    strFonction = strFonction.replace(/___NEQ2___/g, '!=');

    // Exponentiation
    strFonction = strFonction.replace(/\^/g, '**');

    // Modulo
    strFonction = strFonction.replace(/\sMOD\s/gi, ' % ');

    // Division Entière VBScript (\ -> Math.floor(a / b))
    const divEntiereRegex = /(\S+)\s*\\\s*(\S+)/g;
    strFonction = strFonction.replace(divEntiereRegex, 'Math.floor($1 / $2)');

    // Nettoyage des espaces multiples
    strFonction = strFonction.replace(/\s+/g, ' ').trim();

    return strFonction;
}

// --- FONCTIONS EXISTANTES ---

function SiNull(Expression: any, ValReplacement: any) {
    return (Expression === null || Expression === undefined) ? ValReplacement : Expression;
}

function Si(exp: any, trueP: any, falseP: any) {
    return eval(exp) ? trueP : falseP;
}

function SansEspace(str: string) {
    return String(str).trim();
}

function Remplacer(Expression: any, ancienStr: any, NouvelleStr: any) {
    return String(Expression).split(ancienStr).join(NouvelleStr);
}

function Puissance(Nombre: number, lapuissance: number) {
    return Math.pow(Nombre, lapuissance);
}

function NullSi(Expression: any, Valeur: any) {
    return Expression === Valeur ? null : Expression;
}

function Mois(oDat: any) {
    const date = new Date(oDat);
    if (isNaN(date.getTime())) {
        return "Erreur format date pour la fonction Mois";
    }
    return date.getMonth() + 1;
}

function Miniscule(str: string) {
    return String(str).toLowerCase();
}

function Min(Nombre1: number, Nombre2: number) {
    return Math.min(Nombre1, Nombre2);
}

function Max(Nombre1: number, Nombre2: number) {
    return Math.max(Nombre1, Nombre2);
}

function Majiscule(str: string) {
    return String(str).toUpperCase();
}

function Maintenant() {
    return new Date();
}

function Jour(oDat: any) {
    const date = new Date(oDat);
    if (isNaN(date.getTime())) {
        return "Erreur format date pour la fonction Jour";
    }
    return date.getDate();
}

function Gauche(str: string, length: number) {
    return String(str).substring(0, length);
}

function Floor(Number: number) {
    return Math.floor(Number);
}

function Droite(str: string, length: number) {
    const s = String(str);
    return s.substring(s.length - length);
}

function CountWorkingDays(StartDate: any, EndDate: any) {
    let DayCount = 0;
    let CurrentDate = new Date(StartDate);
    const EndDateObj = new Date(EndDate);

    while (CurrentDate <= EndDateObj) {
        const DayOfWeek = CurrentDate.getDay();
        if (DayOfWeek >= 1 && DayOfWeek <= 5) {
            DayCount++;
        }
        CurrentDate.setDate(CurrentDate.getDate() + 1);
    }

    return DayCount;
}

function Ceiling(Number: number) {
    return Math.ceil(Number);
}

function Arrondir(Nombre: number, nbDecimal: number) {
    const multiplicateur = Math.pow(10, nbDecimal);
    return Math.round(Nombre * multiplicateur) / multiplicateur;
}

function Annee(oDat: any) {
    const date = new Date(oDat);
    if (isNaN(date.getTime())) {
        return 1900;
    }
    return date.getFullYear();
}

function InStr(arg1: any, arg2: any) {
    let str, searchStr, start;

    start = 0;
    str = String(arg1);
    searchStr = String(arg2);

    if (arg1 === null || arg1 === undefined || arg2 === null || arg2 === undefined) {
        return 0;
    }

    const position = str.indexOf(searchStr, start);
    return position === -1 ? 0 : position + 1;
}
function Len(str: any) {
    if (str === null || str === undefined) return 0;
    return String(str).length;
}
function Mid(str: string, start: number, length?: number) {
    const s = String(str);
    if (length !== undefined) {
        return s.substring(start - 1, start - 1 + length);
    }
    return s.substring(start - 1);
}
function IsNull(value: any): boolean {
    return value === null || value === undefined;
}
function IsNumeric(value: any): boolean {
    if (value === null || value === undefined || value === '') return false;
    return !isNaN(parseFloat(value)) && isFinite(value);
}
function CInt(value: any): number {
    const num = parseInt(value, 10);
    return isNaN(num) ? 0 : num;
}
function CDbl(value: any): number {
    const num = parseFloat(value);
    return isNaN(num) ? 0 : num;
}
function CStr(value: any): string {
    if (value === null || value === undefined) return '';
    return String(value);
}
function Abs(nombre: number): number {
    return Math.abs(nombre);
}
function Sqr(nombre: number): number {
    return Math.sqrt(nombre);
}
function Int(nombre: number): number {
    return Math.floor(nombre);
}
function Trim(str: string): string {
    return String(str).trim();
}
function LTrim(str: string): string {
    return String(str).trimStart();
}
function RTrim(str: string): string {
    return String(str).trimEnd();
}

// --- FONCTION D'ÉVALUATION AVEC DEBUG AMÉLIORÉ ---
// Remplacer la fonction evalFormula dans Survey_Function_VbScript.ts par cette version :

export function evalFormula(expression: string) {
    try {
        const processedExpr = traitementFonctions(expression);

        console.log("═══════════════════════════════════════");
        console.log("Expression originale:", expression);
        console.log("Expression traitée:", processedExpr);
        console.log("═══════════════════════════════════════");

        const funcNames = Object.keys(VB_FUNCTIONS);
        const funcValues = Object.values(VB_FUNCTIONS);

        const functionBody = `return (${processedExpr});`;

        console.log("Code à exécuter:", functionBody);

        const result = new Function(...funcNames, functionBody)(...funcValues);

        console.log("Résultat brut:", result);

        // AJOUT : Vérifier si le résultat est NaN et le remplacer par 0
        if (typeof result === 'number' && isNaN(result)) {
            console.warn("⚠️ Résultat NaN détecté, remplacement par 0");
            console.log("═══════════════════════════════════════\n");
            return 0;
        }

        console.log("Résultat final:", result);
        console.log("═══════════════════════════════════════\n");

        return result;
    } catch (e: any) {
        console.error("╔═══════════════════════════════════════╗");
        console.error("║   ERREUR LORS DE L'ÉVALUATION        ║");
        console.error("╚═══════════════════════════════════════╝");
        console.error("Expression originale:", expression);

        try {
            const processedExpr = traitementFonctions(expression);
            console.error("Expression traitée:", processedExpr);
        } catch (e2) {
            console.error("Erreur lors du traitement:", e2);
        }

        console.error("Type d'erreur:", e.name);
        console.error("Message:", e.message);
        console.error("Stack:", e.stack);
        console.error("════════════════════════════════════════\n");

        // MODIFICATION : Retourner 0 au lieu de null pour éviter NaN dans les calculs
        return 0;
    }
}