import { evalFormula } from "./Survey_Function_VbScript";
import { TAnswers, TQuestionType } from "./Types";
import { Arrondi } from "../../modules/module_general_formulas";
export const defaultValueMap: { [key: string]: any } = {
    'entier': 0,
    'numerique': 0,
    'alpha': '',
    'texte': '',
    'date': '01/01/1900',
    'heure': '00:00',
    'echelle': 0,
    'oui_non': 2,
    'dateheure': '01/01/1900 00:00',
    'vrai_faux': 2,
    'paragraph': '',
    'multiLine': '',
    'choix': 0,
    'cocher': 0,
    'liste': '',
    'grille_cases': 0,
    'grille_choix': 0,
    'grille_libre': '',
};

/**
 * Fonction utilitaire pour sécuriser les valeurs numériques (éviter NaN)
 */
export const safeNumber = (value: any, defaultValue: number = 0): number => {
    if (value === null || value === undefined) return defaultValue;
    const num = Number(value);
    return isNaN(num) ? defaultValue : num;
};
export const safeArrondi = (value: any, decimals: number = 2): number => {
    const safe = safeNumber(value, 0);
    return Arrondi(safe, decimals);
};

/**
 * Calcule les scores individuels pour chaque ligne d'une question de type grille ou liste.
 * Reproduit la logique du Desktop (ud_grille_cases, ud_grille_choix, etc.)
 */
export function calculateGridScores(value: any, typ_reponse: TQuestionType, funcScoring: string = "", columnsDef: string = ""): number[] {
    const scores: number[] = [];

    if (!value) return scores;

    // 1. OUI_NON / VRAI_FAUX
    if (['oui_non', 'vrai_faux'].includes(typ_reponse)) {
        if (Array.isArray(value) && Array.isArray(value[0])) {
            const isChecked = value[0][0] === 1 || value[0][0] === true || value[0][0] === "1";
            scores.push(isChecked ? 1 : 0);
        }
        return scores;
    }

    // 2. COCHER / ECHELLE (Single Row Grids essentially)
    if (['cocher', 'echelle'].includes(typ_reponse)) {
        if (Array.isArray(value) && Array.isArray(value[0])) {
            // Find index of checked item
            const index = value[0].findIndex((v: any) => v === 1 || v === true || v === "1");
            if (index >= 0) {
                scores.push(index + 1); // 1-based index
            }
        }
        return scores;
    }

    // 3. GRILLE_CHOIX / CHOIX
    // Desktop: ud_grille_choix.vb -> laNote += j + 1 (Start at index 1 -> note 2??)
    if (['grille_choix', 'choix'].includes(typ_reponse)) {
        if (Array.isArray(value)) {
            value.forEach((row: any[]) => {
                if (Array.isArray(row)) {
                    // Find checked column
                    const index = row.findIndex((v: any) => v === 1 || v === true || v === "1");
                    if (index >= 0) {
                        scores.push(index + 2); // j+1 where j=index+1 => index+1+1 = index+2
                    }
                }
            });
        }
        return scores;
    }

    // 4. GRILLE_CASES (Default)
    if (typ_reponse === 'grille_cases') {
        if (Array.isArray(value)) {
            value.forEach((row: any[]) => {
                if (Array.isArray(row)) {
                    const index = row.findIndex((v: any) => v === 1 || v === true || v === "1");
                    if (index >= 0) {
                        scores.push(index + 1);
                    }
                }
            });
        }
    }

    // 5. GRILLE_LIBRE
    if (typ_reponse === 'grille_libre') {
        return calculateGridScoresFromFunction(value, funcScoring, columnsDef);
    }

    return scores;
}



// Helper to get default value based on column type (Desktop logic alignment)
function getDefaultValueForColumn(colType: string): string {
    if (!colType) return "''";
    // Check for [C], [O], [E], [N] -> Return 0
    if (/\[[COEN]\]/i.test(colType)) {
        return '0';
    }
    return "''";
}

/**
 * Calcule les scores pour chaque ligne en utilisant une formule VB (Func_Scoring)
 * Utilisé principalement pour grille_libre ou grille_cases avec calculs complexes par ligne.
 * Remplace Col(x) par la valeur de la colonne x (base 1) pour chaque ligne.
 */
export function calculateGridScoresFromFunction(value: any, funcScoring: string, columnsDef: string = ""): number[] {
    const scores: number[] = [];
    if (!value || !Array.isArray(value)) return scores;

    if (!funcScoring || funcScoring.trim() === '') return scores;



    const columns = columnsDef ? columnsDef.split(';') : [];

    value.forEach((row: any[], rowIndex: number) => {
        // Ignorer les lignes non valides
        if (!Array.isArray(row)) return;

        let formula = funcScoring;

        // Remplacer Col(x) par la valeur
        const replaceColumnValue = (match: string, p1: string) => {
            const colIndex = parseInt(p1) - 1; // Base 1 -> Base 0
            const colType = columns[colIndex] || "";

            if (colIndex >= 0 && colIndex < row.length) {
                const rawVal = row[colIndex];
                if (rawVal === null || rawVal === undefined || rawVal === "") return getDefaultValueForColumn(colType);
                if (typeof rawVal === 'number') return String(rawVal);
                if (typeof rawVal === 'boolean') return rawVal ? '1' : '0';

                let normalizedVal = rawVal;
                if (typeof rawVal === 'string') normalizedVal = rawVal.replace(/,/g, '.');

                if (normalizedVal !== "" && normalizedVal !== null && !isNaN(Number(normalizedVal)) && isFinite(Number(normalizedVal))) {
                    return String(normalizedVal);
                }
                return `"${String(rawVal).replace(/"/g, '\\"')}"`;
            }
            return getDefaultValueForColumn(colType);
        };

        // Regex Robust pour Q[Num] ou Q[Num][Col] ou Q[Num][Row,Col] matching Desktop logic
        // Desktop Regex: (?i)\bQ\s*\[\s*(?<N>\w+)\s*\](?:\s*\[\s*(?:(?<L>\w+)\s*(?:,|:)\s*)?(?<C>\d+)\s*\])?
        // JS Regex (no named groups for wider support if target is old, but we can use indices)
        // Groups: 1=N, 2=Full second brackets, 3=L (row), 4=C (col)
        // Note: L (row) is optional. If missing or non-numeric ("LigneEncours"), we use rowIndex + 1.

        const qRefRegex = /Q\s*\[\s*(\w+)\s*\](?:\s*\[\s*(?:(\w+)\s*(?:,|:)\s*)?(\d+)\s*\])?/gi;

        // Fonction de remplacement pour la regex
        const replaceQRef = (match: string, qNumCtx: string, rowCtx: string, colCtx: string) => {


            // Si Col est défini
            if (colCtx) {
                // Logique Desktop: Si Row est non-numérique ou absent, utiliser numLigne (ici rowIndex + 1)
                let targetRowIndex = rowIndex; // default to current row (0-based)

                if (rowCtx && !isNaN(parseInt(rowCtx))) {
                    targetRowIndex = parseInt(rowCtx) - 1; // Convert 1-based to 0-based
                }

                const targetColIndex = parseInt(colCtx) - 1; // Convert 1-based to 0-based

                // Si on fait référence à la question courante (ou pas de numéro Q spécifié dans le contexte global, mais ici le match a Q[N])
                // Dans le contexte de "calculateGridScoresFromFunction", on traite souvent la question elle-même.
                // Le code VBS utilise 'getValeur' qui peut aller chercher dans d'autres questions.
                // MAIS ici 'value' contient SEULEMENT les données de la question en cours.
                // LIMITATION: Cette fonction ne connait pas les 'answers' globales.
                // HYPOTHÈSE: La formule fait référence à la grille en cours (Q[Numero]).
                // TODO: Si Num != CurrentNum, ça ne marchera pas avec 'value' seul.
                // Cependant, le cas d'usage 'LigneEncours' est typiquement pour l'auto-référence.

                if (targetRowIndex >= 0 && targetRowIndex < value.length) {
                    const targetRow = value[targetRowIndex];
                    if (Array.isArray(targetRow) && targetColIndex >= 0 && targetColIndex < targetRow.length) {
                        const colType = columns[targetColIndex] || "";
                        const rawVal = targetRow[targetColIndex];

                        // Réutilisation de la logique de formatage
                        if (rawVal === null || rawVal === undefined || rawVal === "") {
                            return getDefaultValueForColumn(colType);
                        }

                        if (typeof rawVal === 'number') return String(rawVal);
                        if (typeof rawVal === 'boolean') return rawVal ? '1' : '0';

                        let normalizedVal = rawVal;
                        if (typeof rawVal === 'string') {
                            normalizedVal = rawVal.replace(/,/g, '.');
                        }

                        if (normalizedVal !== "" && normalizedVal !== null && !isNaN(Number(normalizedVal)) && isFinite(Number(normalizedVal))) {
                            return String(normalizedVal);
                        }

                        return `"${String(rawVal).replace(/"/g, '\\"')}"`;
                    }
                }
                // Hors limites
                return "0";
            }

            return "0"; // Fallback
        };

        // 1. Remplacer les références Q[...]
        formula = formula.replace(qRefRegex, replaceQRef);

        // 2. Remplacer les références Col(x) (Legacy simple)
        formula = formula.replace(/Col\s*\(\s*(\d+)\s*\)/gi, replaceColumnValue);

        // 3. Appliquer les transformations de syntaxe VBScript -> JS (via traitementFonctions 'light' ou manuel)
        // Comme on n'a pas accès direct à traitementFonctions ici sans import circulaire ou duplication,
        // on applique les remplacements critiques (True, False, ;, =)

        formula = formula.replace(/\bTrue\b/gi, 'true');
        formula = formula.replace(/\bFalse\b/gi, 'false');
        formula = formula.replace(/;/g, ','); // Séparateur arguments
        formula = formula.replace(/(\w+|\)|"[^"]*")\s*=\s*(\w+|\(|"[^"]*")/g, '$1 == $2'); // Comparaison (Loose equality for VBScript compatibility 1 == true)
        formula = formula.replace(/<>/g, '!==');

        // Évaluer la formule


        const rowScore = evalFormula(formula);
        scores.push(safeNumber(rowScore, 0));
    });

    return scores;
}

function formatValueForVBScript(value: any, typ_reponse: string): any {
    // Types numériques → retourner le nombre
    const numericTypes = ['entier', 'numerique', 'echelle', 'oui_non', 'vrai_faux',
        'choix', 'cocher', 'grille_cases', 'grille_choix'];

    if (numericTypes.includes(typ_reponse)) {
        return safeNumber(value, 0);
    }

    // Types texte → retourner la valeur string SANS quotes
    // Les quotes seront ajoutées par evaluateExpression
    return String(value ?? '');
}

export function getValeur(orgineValeur: any, typ_reponse: TQuestionType): any {
    let score = defaultValueMap[typ_reponse];
    switch (typ_reponse) {
        case 'oui_non':
        case 'vrai_faux':
            if (Array.isArray(orgineValeur) && Array.isArray(orgineValeur[0])) {
                score = orgineValeur?.[0][0] === 1 ? 1 : 0;
            }
            break;
        case 'echelle':
        case 'cocher':
            // retourner l'indice de la colonne sélectionnée + 1
            if (Array.isArray(orgineValeur) && Array.isArray(orgineValeur[0])) {
                const selectedIndex = orgineValeur[0].findIndex((val: any) => val === 1);
                score = selectedIndex >= 0 ? selectedIndex + 1 : 0;
            }
            break;
        case 'grille_choix':
        case 'choix':
        case 'grille_cases':
            // Logic updated to match Desktop via calculateGridScores default SUM behavior
            // We use calculateGridScores to get the list of scores, then sum them.
            const scores = calculateGridScores(orgineValeur, typ_reponse);
            score = scores.reduce((a: number, b: number) => a + b, 0);
            break;
        case 'numerique':
        case 'entier':
            // retourner la valeur numérique
            score = safeNumber(orgineValeur, 0);
            break;
        case 'alpha':
        case 'paragraph':
        case 'multiLine':

        case 'liste':
            score = String(orgineValeur ?? '');
            break;
        case 'date':
        case 'heure':
        case 'dateTime':
            score = String(orgineValeur ?? '');
            break;
    }
    return score;
}

/**
 * Calcule les scores individuels pour chaque ligne d'une question de type grille ou liste.
 * Reproduit la logique du Desktop (ud_grille_cases, ud_grille_choix, etc.)
 */


export function getAnswerValue(expression: string, answers: TAnswers): any {
    const qMatch = expression.match(/^Q\[(\d+)\]/);
    if (!qMatch) return ""; // Valeur par défaut

    const qNum = parseInt(qMatch[1]);
    const answer = answers[qNum];

    if (!answer) {
        console.warn(`⚠️ Question ${qNum} non trouvée`);
        return ""; // Valeur par défaut
    }

    // ============================================================================
    // 1. GESTION DE Q[N] SEUL (sans index)
    // ============================================================================
    if (qMatch[0].length === expression.trim().length) {

        // 1.1. PARAGRAPH / MULTILINE / TEXTE
        if (['paragraph', 'multiLine', 'texte'].includes(answer.typ_reponse)) {
            const textValue = typeof answer.value === 'string'
                ? answer.value
                : (defaultValueMap[answer.typ_reponse] ?? '');
            return formatValueForVBScript(textValue, answer.typ_reponse);
        }

        // 1.2. VALEUR UNIQUE (text ou numérique)
        if (['alpha', 'date', 'heure', 'dateheure', 'liste', 'entier', 'numerique'].includes(answer.typ_reponse)) {
            const value = typeof answer.value === 'string' || typeof answer.value === 'number'
                ? answer.value
                : (defaultValueMap[answer.typ_reponse] ?? '');
            return formatValueForVBScript(value, answer.typ_reponse);
        }

        // 1.3. GRILLE CHOIX
        if (answer.typ_reponse === 'grille_choix') {
            if (Array.isArray(answer.value) && answer.value.length > 0) {
                if (Array.isArray(answer.value[0]) && answer.value[0].length > 0) {
                    const firstValue = answer.value[0][0];
                    return firstValue === true || firstValue === 1 || firstValue === "1" ? 1 : 0;
                }
            }
            return 0;
        }

        // 1.4. GRILLE CASES / ECHELLE / CHOIX / COCHER
        if (['grille_cases', 'echelle', 'choix', 'cocher', 'oui_non', 'vrai_faux'].includes(answer.typ_reponse)) {
            if (Array.isArray(answer.value)) {
                const rowData = Array.isArray(answer.value[0]) ? answer.value[0] : answer.value;

                for (let i = 0; i < rowData.length; i++) {
                    const val = rowData[i];
                    if (val === true || val === 1 || val === "1") {
                        return i + 1; // Retourne index+1 (base 1)
                    }
                }
            }
            return 0;
        }

        // 1.5. GRILLE LIBRE
        if (answer.typ_reponse === 'grille_libre') {
            if (Array.isArray(answer.value) && answer.value.length > 0) {
                if (Array.isArray(answer.value[0]) && answer.value[0].length > 0) {
                    return answer.value[0][0] ?? "";
                }
            }
            return "";
        }

        // 1.6. Cas par défaut - valeur simple
        if (typeof answer.value === 'string' || typeof answer.value === 'number') {
            return formatValueForVBScript(answer.value, answer.typ_reponse);
        }

        // Si tableau mais pas géré ci-dessus, prendre premier élément
        if (Array.isArray(answer.value) && answer.value.length > 0) {
            const firstValue = Array.isArray(answer.value[0]) ? answer.value[0][0] : answer.value[0];
            return formatValueForVBScript(firstValue, answer.typ_reponse);
        }

        return "";
    }

    // ============================================================================
    // 2. GESTION DE Q[N][C] et Q[N][L,C]
    // ============================================================================

    const cleanExpression = expression.replace(/\s+/g, '');
    const indexMatch = cleanExpression.match(/\[(\d+)(?:[,:]\s*(\d+))?\]$/);

    if (indexMatch && Array.isArray(answer.value)) {
        // 2.1. CAS Q[N][C] (une seule dimension)
        if (!indexMatch[2]) {
            const index1 = parseInt(indexMatch[1]) - 1;

            if (answer.typ_reponse === 'grille_choix') {
                if (Array.isArray(answer.value[0])) {
                    const value = answer.value[0][index1];
                    return value === true || value === 1 || value === "1" ? 1 : 0;
                }
                return 0;
            }

            if (['grille_cases', 'echelle', 'choix', 'cocher'].includes(answer.typ_reponse)) {
                if (Array.isArray(answer.value[0])) {
                    const value = answer.value[0][index1];
                    return value === true || value === 1 || value === "1" ? 1 : 0;
                } else {
                    const value = answer.value[index1];
                    return value === true || value === 1 || value === "1" ? 1 : 0;
                }
            }

            if (answer.typ_reponse === 'grille_libre') {
                if (Array.isArray(answer.value[0])) {
                    const val = answer.value[0][index1];
                    if (val !== undefined && val !== null && val !== "") return val;
                    // Logic equivalent to desktop: Check column definition for [C/O/E/N]
                    if (answer.colonnes) {
                        const cols = answer.colonnes.split(';');
                        if (index1 < cols.length) {
                            const colDef = cols[index1];
                            if (/\[[COEN]\]/i.test(colDef)) return 0;
                        }
                    }
                    return "";
                }
                return "";
            }

            if (!Array.isArray(answer.value[0])) {
                return formatValueForVBScript(answer.value[index1], answer.typ_reponse);
            }

            if (Array.isArray(answer.value[0])) {
                return formatValueForVBScript(answer.value[0][index1], answer.typ_reponse);
            }

            return "";
        }
        const index1Ligne = parseInt(indexMatch[1]) - 1;    // Ligne (base 1 → 0)
        const index2Colonne = parseInt(indexMatch[2]) - 1;      // Colonne (DÉJÀ en base 0)
        if (Array.isArray(answer.value[index1Ligne])) {
            const value = answer.value[index1Ligne][index2Colonne];

            if (['grille_cases', 'grille_choix', 'echelle', 'choix', 'cocher'].includes(answer.typ_reponse)) {
                return value === true || value === 1 || value === "1" ? 1 : 0;
            }
            if (answer.typ_reponse === 'grille_libre') {
                if (value !== undefined && value !== null && value !== "") return value;
                // Logic equivalent to desktop: Check column definition for [C/O/E/N]
                if (answer.colonnes) {
                    const cols = answer.colonnes.split(';');
                    if (index2Colonne < cols.length) {
                        const colDef = cols[index2Colonne];
                        if (/\[[COEN]\]/i.test(colDef)) return 0;
                    }
                }
                return "";
            }
            return formatValueForVBScript(value, answer.typ_reponse);
        }
    }

    console.warn(`⚠️ Cas non géré pour ${expression}`);
    return "";
}

export function evaluateExpression(expression: string, answers: TAnswers, currentAnswerValue: any = null, typ_reponse: TQuestionType, evalue: string, evaluateur: string, typ_survey: string): any {
    if (!expression || expression.trim().length === 0) return true;

    let evaluatedExpression = expression;

    // Remplacement de CurrentAnswer, Evalue, Evaluateur et Typ_Evaluation
    evaluatedExpression = evaluatedExpression.replace(/\bCurrentAnswer\b/gi, getValeur(currentAnswerValue ?? '', typ_reponse));
    evaluatedExpression = evaluatedExpression.replace(/\bEvalue\b/gi, evalue);
    evaluatedExpression = evaluatedExpression.replace(/\bEvaluateur\b/gi, evaluateur);
    evaluatedExpression = evaluatedExpression.replace(/\bTyp_Evaluation\b/gi, typ_survey);

    // Remplacement des fonctions InStr
    const funcRegex = /(InStr)\s*\((.*?)\)/gi;
    evaluatedExpression = evaluatedExpression.replace(funcRegex, (match, funcName, argsStr) => {
        const args = argsStr.split(';').map((s: string) => s.trim());
        if (funcName.toLowerCase() === 'instr') {
            const textToSearch = String(getAnswerValue(args[0], answers) || '');
            const searchValue = args[1].replace(/"/g, '');
            const result = textToSearch.toLowerCase().indexOf(searchValue.toLowerCase()) > -1;
            return result ? 'true' : 'false';
        }
        return match;
    });

    // Remplacement des Q[N]...
    // Permissive regex matching desktop logic: Q space? [ space? N space? ] (opt: [ space? L , space? C ])
    // Note: JS regex doesn't support named groups in replace callback consistently across envs easily without logic,
    // so we'll use indexed groups.
    // Group 1: Whole Q expression
    // The previous regex was: /(Q\[\d+\]\s*(?:\[\d+(?:[,:]\s*\d+)?\])?)/g
    // New regex:
    const qRefRegex = /(Q\s*\[\s*\d+\s*\](?:\s*\[\s*\d+(?:[,:]\s*\d+)?\s*\])?)/gi;

    evaluatedExpression = evaluatedExpression.replace(qRefRegex, (match) => {
        // Normalize the match to standard form for getAnswerValue (which expects Q[N] or Q[N][C] or Q[N][L,C] with tight spacing or loose?)
        // actually getAnswerValue regex is: /^Q\[(\d+)\]/ and /\[(\d+)(?:[,:]\s*(\d+))?\]$/
        // So we should just pass the match as is?
        // getAnswerValue cleans spaces: const cleanExpression = expression.replace(/\s+/g, '');
        // so we can pass the loose match directly.

        const val = getAnswerValue(match, answers);
        const qNumMatch = match.match(/Q\s*\[\s*(\d+)\s*\]/i);
        const qNum = qNumMatch ? parseInt(qNumMatch[1]) : 0;

        const answer = answers[qNum];

        if (!answer) {
            console.warn(`⚠️ Question ${qNum} non trouvée dans answers`);
            return '""';
        }

        // Types numériques : retourner sans guillemets
        const numericTypes = ['numerique', 'entier', 'echelle', 'grille_cases', 'grille_choix', 'cocher', 'oui_non', 'vrai_faux', 'choix'];
        if (numericTypes.includes(answer.typ_reponse)) {
            const numVal = typeof val === 'number' ? val : safeNumber(val, 0);

            return String(numVal);
        }
        const strVal = String(val);
        return `"${strVal.replace(/"/g, '\\"')}"`;
    });
    try {
        const result = evalFormula(evaluatedExpression);
        return result;
    } catch (error) {
        console.error("Erreur évaluation expression:", error);
        console.error("Expression:", evaluatedExpression);
        return false;
    }
}

export function func_multi_sum(value: any): number {
    // Vérifier que c'est un tableau
    if (!Array.isArray(value)) {
        return 0;
    }

    let sum = 0;

    // Parcourir le tableau (peut être 1D ou 2D)
    for (const item of value) {
        if (Array.isArray(item)) {
            // Tableau 2D : récursion
            sum += func_multi_sum(item);
        } else if (typeof item === 'number' && !isNaN(item)) {
            // Valeur numérique : additionner
            sum += item;
        } else if (typeof item === 'boolean') {
            // Boolean : 1 si true, 0 si false
            sum += item ? 1 : 0;
        } else if (item === 1 || item === "1") {
            // String "1" ou nombre 1 (case cochée)
            sum += 1;
        }
        // Tous les autres types : 0 (pas ajouté à la somme)
    }

    return sum;
}

export function func_multi_avg(value: any): number {
    if (!Array.isArray(value)) {
        return 0;
    }

    let sum = 0;
    let count = 0;

    // Fonction récursive pour parcourir les tableaux imbriqués
    function processValue(item: any): void {
        if (Array.isArray(item)) {
            // Tableau 2D : récursion
            for (const subItem of item) {
                processValue(subItem);
            }
        } else {
            // Compter l'élément
            count++;

            if (typeof item === 'number' && !isNaN(item)) {
                // Valeur numérique
                sum += item;
            } else if (typeof item === 'boolean') {
                // Boolean : 1 si true, 0 si false
                sum += item ? 1 : 0;
            } else if (item === 1 || item === "1") {
                // String "1" ou nombre 1 (case cochée)
                sum += 1;
            }
            // Autres types : 0 (ne rien ajouter à la somme)
        }
    }

    processValue(value);

    // Éviter division par zéro
    return count > 0 ? sum / count : 0;
}

export function func_multi_max(value: any): number {
    if (!Array.isArray(value)) {
        return 0;
    }

    let maxValue = -Infinity;
    let hasValues = false;

    // Fonction récursive pour parcourir les tableaux imbriqués
    function processValue(item: any): void {
        if (Array.isArray(item)) {
            // Tableau 2D : récursion
            for (const subItem of item) {
                processValue(subItem);
            }
        } else {
            hasValues = true;
            let itemValue = 0;

            if (typeof item === 'number' && !isNaN(item)) {
                // Valeur numérique
                itemValue = item;
            } else if (typeof item === 'boolean') {
                // Boolean : 1 si true, 0 si false
                itemValue = item ? 1 : 0;
            } else if (item === 1 || item === "1") {
                // String "1" ou nombre 1 (case cochée)
                itemValue = 1;
            }

            maxValue = Math.max(maxValue, itemValue);
        }
    }

    processValue(value);

    // Si aucune valeur trouvée, retourner 0
    return hasValues ? maxValue : 0;
}
export function func_multi_min(value: any): number {
    if (!Array.isArray(value)) {
        return 0;
    }

    let minValue = Infinity;
    let hasValues = false;

    // Fonction récursive pour parcourir les tableaux imbriqués
    function processValue(item: any): void {
        if (Array.isArray(item)) {
            // Tableau 2D : récursion
            for (const subItem of item) {
                processValue(subItem);
            }
        } else {
            hasValues = true;
            let itemValue = 0;

            if (typeof item === 'number' && !isNaN(item)) {
                // Valeur numérique
                itemValue = item;
            } else if (typeof item === 'boolean') {
                // Boolean : 1 si true, 0 si false
                itemValue = item ? 1 : 0;
            } else if (item === 1 || item === "1") {
                // String "1" ou nombre 1 (case cochée)
                itemValue = 1;
            }

            minValue = Math.min(minValue, itemValue);
        }
    }

    processValue(value);

    // Si aucune valeur trouvée, retourner 0
    return hasValues ? minValue : 0;
}