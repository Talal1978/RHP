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
        case 'choix':
            // retourner le nombre d'options sélectionnées
            if (Array.isArray(orgineValeur) && Array.isArray(orgineValeur[0])) {
                score = orgineValeur[0].reduce((acc: number, val: any) => acc + (val === 1 ? 1 : 0), 0);
            }
            break;
        case 'grille_choix':
        case 'grille_cases':
            // retourner le nombre total d'options sélectionnées à deux dimensions
            if (Array.isArray(orgineValeur)) {
                score = orgineValeur.reduce((accRow: number, row: any[]) =>
                    accRow + row.reduce((accCol: number, val: any) => accCol + (val === 1 ? 1 : 0), 0)
                    , 0);
            }
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
                    return answer.value[0][index1] ?? "";
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
                return value ?? "";
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
    const qRefRegex = /(Q\[\d+\]\s*(?:\[\d+(?:[,:]\s*\d+)?\])?)/g;
    evaluatedExpression = evaluatedExpression.replace(qRefRegex, (match) => {
        const val = getAnswerValue(match, answers);
        const qNum = parseInt(match.match(/Q\[(\d+)\]/)![1]);
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