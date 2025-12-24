import { useCallback, useEffect, useMemo, useState, useRef, Dispatch, SetStateAction, useImperativeHandle, forwardRef } from 'react';
import { Box, Typography } from "@mui/material";
import UdValeurUnique from './Components/UdValeurUnique';
import UdGrilleCases from './Components/UdGrilleCases';
import UdGrilleChoix from './Components/UdGrilleChoix';
import UdGrilleLibre from './Components/UdGrilleLibre';
import { colorBase } from '../../modules/module_general';
import Loading from '../../components/Loading/Loading';
import { ChildHandle, TAnswers, TAnswerState, TDbAnswer, TNoteResult, TQuestion } from './Types';
import useAxiosPost from '../../hooks/useAxiosPost';
import { defaultValueMap, evaluateExpression, func_multi_avg, func_multi_max, func_multi_min, func_multi_sum, getValeur, safeNumber } from './Survey_Functions';
import useAxiosGet from '../../hooks/useAxiosGet';

const initialAnswerState: TAnswerState = {
    value: null,
    note: { note: 0, coef: 0, note_totale: 0 },
    isVisible: true,
    isMandatory: false,
    hasError: false,
    errorMsg: '',
    typ_reponse: "alpha",
    mode_scoring: "na",
};
function initializeQuestionValue(q: TQuestion): any {
    const typesGrilles = ['grille_cases', 'grille_choix', 'grille_libre', 'echelle', 'cocher', 'vrai_faux', 'oui_non', 'choix'];

    if (typesGrilles.includes(q.Typ_Reponse)) {
        let nbLignes = 1;
        if (q.Sous_Question && q.Sous_Question.trim().length > 0) {
            const lignes = q.Sous_Question.split(';').filter(l => l.trim().length > 0);
            nbLignes = lignes.length > 0 ? lignes.length : 1;
        }

        let nbColonnes = 1;
        if (q.Reponses_Possibles && q.Reponses_Possibles.trim().length > 0) {
            const colonnes = q.Reponses_Possibles.split(';').filter(c => c.trim().length > 0);
            nbColonnes = colonnes.length > 0 ? colonnes.length : 1;
        }

        const defaultValue = defaultValueMap[q.Typ_Reponse] ?? null;

        return Array(nbLignes).fill(null).map(() =>
            Array(nbColonnes).fill(defaultValue)
        );
    }

    return null;
}
interface TProps {
    cod_survey: string
    cod_reply: number
    evalue: string
    evaluateur: string
    typ_survey: 'E' | 'R' | 'F'
    ref_evaluation: string
    refChild: React.RefObject<ChildHandle>
    readOnly?: boolean
}

const Survey_Rendering = forwardRef<ChildHandle, TProps>(({ cod_survey, cod_reply, evalue, evaluateur, typ_survey, ref_evaluation, refChild, readOnly = false }, _ref) => {
    const myAxiosGet = useAxiosGet();
    const myAxiosPost = useAxiosPost();
    const [questions, setQuestions] = useState<TQuestion[]>([]);
    const [answers, setAnswers] = useState<TAnswers>({});
    const [isLoading, setIsLoading] = useState(true);
    const questionsRef = useRef<TQuestion[]>([]);
    useImperativeHandle(refChild, () => ({
        save: async () => {
            return await saveAnswers();
        },
    }));
    useEffect(() => {
        questionsRef.current = questions;
    }, [questions]);
    useEffect(() => {
        let isMounted = true;

        const loadData = async () => {
            setIsLoading(true);


            try {
                // Fetch both questions and answers in parallel
                const [rslQuestions, rslAnswers] = await Promise.all([
                    myAxiosGet({ apiStr: 'surveyQuestions', bdy: { cod_survey } }),
                    myAxiosGet({ apiStr: 'surveyAnswers', bdy: { cod_survey, cod_reply } }) // Assuming cod_reply or cod_survey needed here
                ]);

                if (!isMounted) {

                    return;
                }


                if (rslQuestions.data?.result && rslQuestions.data?.data?.length > 0) {
                    const fetchedQuestions: TQuestion[] = rslQuestions.data.data;
                    setQuestions(fetchedQuestions);

                    const dbAnswers: any[] = rslAnswers.data?.result ? rslAnswers.data.data : [];


                    const initialAnswers: TAnswers = {};

                    fetchedQuestions.forEach((q: TQuestion) => {
                        // Initialize default value
                        let value = initializeQuestionValue(q);
                        let note: TNoteResult | null = q.Mode_Scoring === 'na' ? null : {
                            note: 0,
                            coef: safeNumber(q.Coef, 1),
                            note_totale: 0,
                            max_score: safeNumber(q.Max_Score, 0),
                            min_score: 0,
                            note_manuelle: q.Mode_Scoring === 'manuel' ? true : false,
                        };

                        // Find answers for this question
                        const qAnswers = dbAnswers.filter(a => a.Cod_Question === q.Cod_Question);

                        if (qAnswers.length > 0) {
                            // Logic to map DB answers to state value
                            // Case 1: Complex grids (grille_cases, grille_choix, etc.) using Num_Sous_Question
                            if (['grille_cases', 'grille_choix', 'grille_libre', 'echelle', 'cocher', 'choix', 'oui_non', 'vrai_faux'].includes(q.Typ_Reponse)) {
                                if (Array.isArray(value)) {
                                    qAnswers.forEach(ans => {
                                        const rowIndex = parseInt(ans.Num_Sous_Question)
                                        if (rowIndex >= 0 && rowIndex < value.length) {
                                            const reponsesArr = ans.Reponses.split(';');
                                            if (Array.isArray(value[rowIndex])) {
                                                const rowData = value[rowIndex].map((_: any, colIndex: number) => {
                                                    // Safe access to reponsesArr
                                                    if (colIndex < reponsesArr.length) {
                                                        const val = reponsesArr[colIndex];
                                                        // Convert based on type if needed, but 'Reponses' is string
                                                        // If the component expects 0/1 for checkboxes
                                                        if (val === "1") return 1;
                                                        if (val === "0") return 0;
                                                        return val;
                                                    }
                                                    return defaultValueMap[q.Typ_Reponse] ?? 0;
                                                });
                                                value[rowIndex] = rowData;
                                            }
                                        }
                                    });
                                }
                            } else {
                                // Case 2: Simple values (valeur_unique, paragraph, etc.)
                                // Usually just one row with Num_Sous_Question '0' or matching question
                                const ans = qAnswers[0]; // Take the first one
                                value = ans.Reponses;
                                // Convert types if necessary (e.g. numeric)
                                if (['entier', 'numerique'].includes(q.Typ_Reponse)) {
                                    value = safeNumber(value);
                                }
                            }

                            // Map Note
                            // Taking note from the first answer row found? Or sum?
                            // VB code: .noteManuelle = If(nrw.Length > 0, CDbl(IsNull(nrw(0)("Note"), 0)), 0)
                            if (note && qAnswers.length > 0) {
                                note.note = safeNumber(qAnswers[0].Note, 0);
                                note.note_totale = safeNumber(qAnswers[0].Note_Totale, 0);
                            }
                        }

                        initialAnswers[q.NumQuestion] = {
                            ...initialAnswerState,
                            value: value,
                            note: note,
                            isMandatory: q.Obligatoire,
                            typ_reponse: q.Typ_Reponse,
                            mode_scoring: q.Mode_Scoring,
                        };
                    });
                    setAnswers(initialAnswers);
                } else {
                    console.warn("⚠️ No questions found from API");
                }
            } catch (error) {
                console.error("❌ Erreur chargement données survey:", error);
            } finally {
                if (isMounted) {
                    setIsLoading(false);
                }
            }
        };

        loadData();

        // Cleanup function
        return () => {
            isMounted = false;
        };
    }, []);
    const handleValueChange = useCallback((
        qNum: number,
        newValue: any
    ) => {
        setAnswers(prevAnswers => {
            const currentQ = questionsRef.current.find(q => q.NumQuestion === qNum);
            let hasChanged = false
            if (!currentQ) {
                return prevAnswers;
            }
            let finalNote = prevAnswers[qNum]?.note;
            if (finalNote !== null) {
                if (currentQ.Mode_Scoring === 'func' && currentQ.Func_Scoring) {
                    try {
                        const funcScore = evaluateExpression(
                            currentQ.Func_Scoring,
                            prevAnswers,
                            newValue || defaultValueMap[currentQ.Typ_Reponse], currentQ.Typ_Reponse, evalue, evaluateur, typ_survey
                        );
                        const score = safeNumber(funcScore, 0);
                        const coef = safeNumber(currentQ.Coef, 1);

                        finalNote = {
                            ...finalNote,
                            note: Math.min(score, finalNote?.max_score || 100000000), // CORRECTION: Utiliser Math.min pour limiter la note au coefficientscore,
                            coef: coef,
                            note_totale: score * coef
                        };
                    } catch (error) {
                        console.error("Erreur calcul note fonctionnelle:", error);
                        finalNote = {
                            ...finalNote,
                            note: 0,
                            coef: safeNumber(currentQ.Coef, 1),
                            note_totale: 0
                        };
                    }
                } else if (currentQ.Mode_Scoring === 'auto') {
                    let score = safeNumber(getValeur(newValue, currentQ.Typ_Reponse), 0);
                    const coef = safeNumber(currentQ.Coef, 1);
                    finalNote = {
                        ...finalNote,
                        note: score,
                        coef: coef,
                        note_totale: safeNumber(score * coef, 0)
                    };
                } else if (['multi_sum', 'multi_avg', 'multi_min', 'multi_max'].includes(currentQ.Mode_Scoring)) {
                    const func_agg: Record<string, (vals: any) => number> = {};
                    func_agg['multi_sum'] = func_multi_sum
                    func_agg['multi_avg'] = func_multi_avg
                    func_agg['multi_min'] = func_multi_min
                    func_agg['multi_max'] = func_multi_max
                    const score = safeNumber(func_agg[currentQ.Mode_Scoring](newValue), 0);
                    const coef = safeNumber(currentQ.Coef, 1);
                    finalNote = {
                        ...finalNote,
                        note: func_agg[currentQ.Mode_Scoring](newValue),
                        note_totale: score * coef
                    };
                }
            }

            //mise à jour de la réponse
            let updatedAnswers = {} as TAnswers;
            if (newValue !== prevAnswers[qNum]?.value || finalNote?.note_totale !== prevAnswers[qNum]?.note?.note_totale) {
                updatedAnswers = {
                    ...prevAnswers,
                    [qNum]: {
                        ...prevAnswers[qNum],
                        value: newValue,
                        note: finalNote,
                        typ_reponse: currentQ.Typ_Reponse
                    }
                };

                // Logic to clear validation error if field is now valid
                const qState = updatedAnswers[qNum];
                if (qState.hasError && qState.errorMsg === 'Ce champ est obligatoire') {
                    let isFilled = false;
                    const val = newValue;
                    if (['grille_cases', 'grille_choix', 'echelle', 'cocher', 'choix', 'oui_non', 'vrai_faux'].includes(currentQ.Typ_Reponse)) {
                        if (Array.isArray(val) && val.length > 0) {
                            const hasContent = (v: any): boolean => {
                                if (Array.isArray(v)) return v.some(hasContent);
                                return v === true || v === 1 || v === "1" || (typeof v === 'string' && v.trim().length > 0) || (typeof v === 'number' && v !== 0);
                            };
                            isFilled = hasContent(val);
                        }
                    } else {
                        if (val !== null && val !== undefined && val !== '') {
                            if (typeof val === 'string') {
                                isFilled = val.trim().length > 0;
                            } else if (typeof val === 'number') {
                                if (['date', 'dateTime', 'heure'].includes(currentQ.Typ_Reponse)) {
                                    isFilled = val !== defaultValueMap[currentQ.Typ_Reponse];
                                } else {
                                    isFilled = true;
                                }
                            } else {
                                isFilled = true;
                            }
                        }
                    }

                    if (isFilled) {
                        updatedAnswers[qNum] = {
                            ...qState,
                            hasError: false,
                            errorMsg: ''
                        };
                    }
                }

                const reEvaluatedAnswers: TAnswers = { ...updatedAnswers };
                hasChanged = false;
                questionsRef.current.forEach(q => {
                    const qState = updatedAnswers[q.NumQuestion] || initialAnswerState;
                    // Traitement des questions obligatoires 
                    if (q.Obligatoire_Si && q.Obligatoire_Si.trim().length !== 0) {
                        const mandatoryRule = q.Obligatoire_Si;
                        let isConditionallyMandatory = false;
                        try {
                            isConditionallyMandatory = evaluateExpression(mandatoryRule, updatedAnswers, null, q.Typ_Reponse, evalue, evaluateur, typ_survey) === true;
                            reEvaluatedAnswers[q.NumQuestion] = {
                                ...qState,
                                isMandatory: q.Obligatoire || isConditionallyMandatory,
                                isVisible: q.Obligatoire || isConditionallyMandatory,
                            };
                            if (isConditionallyMandatory !== qState.isMandatory) {
                                hasChanged = true;
                            }
                        } catch (error) {
                            console.error(`Erreur évaluation Obligatoire_Si Q${q.NumQuestion}:`, error);
                        }
                    }

                    // Traitement des réponses avec erreur conditionnelle                       }
                    if (q.Erreur_Si && q.Erreur_Si.trim().length !== 0) {
                        const errorRule = q.Erreur_Si;
                        let hasConditionallyError = false;
                        try {
                            hasConditionallyError = evaluateExpression(
                                errorRule,
                                updatedAnswers,
                                qState.value || defaultValueMap[q.Typ_Reponse], q.Typ_Reponse, evalue, evaluateur, typ_survey
                            ) === true;
                            reEvaluatedAnswers[q.NumQuestion] = {
                                ...qState,
                                hasError: hasConditionallyError,
                                errorMsg: hasConditionallyError ? q.Erreur_Msg : '',
                            };
                            if (hasConditionallyError !== qState.hasError) {
                                hasChanged = true;
                            }
                        } catch (error) {
                            console.error(`Erreur évaluation Erreur_Si Q${q.NumQuestion}:`, error);
                        }
                    }
                })
                return hasChanged ? reEvaluatedAnswers : updatedAnswers;
            }
            else {
                return prevAnswers;
            }
        });
    }, [evalue, evaluateur, typ_survey]);


    const QuestionRenderer = (q: TQuestion) => {
        const qState = answers[q.NumQuestion] || initialAnswerState;
        const commonProps = {
            numQuestion: q.NumQuestion,
            laquestion: q.Question,
            Obligatoire: qState.isMandatory,
            avecNote: q.AvecNote,
            note: qState.note,
            colonnes: q.Reponses_Possibles,
            valeurInitiale: qState.value,
            readOnly: readOnly,
            onValueChange: (value: any) => handleValueChange(q.NumQuestion, value),
            handleNoteManuelle: (numQuestion: number, note: TNoteResult) => {
                setAnswers(prevAnswers => ({
                    ...prevAnswers,
                    [numQuestion]: {
                        ...prevAnswers[numQuestion],
                        note: note
                    }
                }));
            }
        };

        switch (q.Typ_Reponse) {
            case 'grille_cases':
            case 'echelle':
            case 'cocher':
            case 'vrai_faux':
            case 'oui_non':
                return (
                    <UdGrilleCases
                        key={q.NumQuestion}
                        {...commonProps}
                        lignes={q.Sous_Question}
                    />
                );

            case 'grille_choix':
            case 'choix':
                return (
                    <UdGrilleChoix
                        key={q.NumQuestion}
                        {...commonProps}
                        lignes={q.Sous_Question}
                    />
                );

            case 'grille_libre':
                return (
                    <UdGrilleLibre
                        key={q.NumQuestion}
                        {...commonProps}
                        lignes={q.Sous_Question.split(';').length ?? 0}
                    />
                );

            case 'paragraph':
            case 'multiLine':
                return (
                    <UdValeurUnique
                        key={q.NumQuestion}
                        {...commonProps}
                        Typ_Reponse="multiLine"
                        funcScoring=''
                    />
                );

            case 'numerique':
            case 'entier':
            case 'date':
            case 'dateTime':
            case 'heure':
            case 'alpha':
            case 'liste':
                return (
                    <UdValeurUnique
                        key={q.NumQuestion}
                        {...commonProps}
                        Typ_Reponse={q.Typ_Reponse}
                        funcScoring=''
                    />
                );

            default:
                return (
                    <Box key={q.NumQuestion} sx={{ p: 2, border: '1px solid red' }}>
                        Type de réponse non pris en charge: {q.Typ_Reponse}
                    </Box>
                );
        }
    };

    const totalScore = useMemo(() => {
        return questions.reduce<{ noteTotal: number, coefTotal: number }>((total, q) => {
            const qState = answers[q.NumQuestion];
            if (qState && qState.isVisible && q.AvecNote) {
                const noteTotal = safeNumber(qState.note?.note_totale, 0);
                const coefTotal = safeNumber(qState.note?.coef, 0);
                return { noteTotal: total.noteTotal + noteTotal, coefTotal: total.coefTotal + coefTotal };
            }
            return total;
        }, { noteTotal: 0, coefTotal: 0 });
    }, [answers, questions]);

    const validateSurvey = useCallback((): { isValid: boolean, newAnswers: TAnswers } => {
        let isValid = true;
        let newAnswers = { ...answers };
        let firstErrorQNum = -1;

        questionsRef.current.forEach(q => {
            const qState = newAnswers[q.NumQuestion];
            if (!qState || !qState.isVisible) return;

            // 1. Check for existing errors
            if (qState.hasError) {
                isValid = false;
                if (firstErrorQNum === -1) firstErrorQNum = q.NumQuestion;
            }

            // 2. Check for mandatory fields
            if (qState.isMandatory) {
                let isFilled = false;
                const val = qState.value;


                if (['grille_cases', 'grille_choix', 'echelle', 'cocher', 'choix', 'oui_non', 'vrai_faux'].includes(q.Typ_Reponse)) {
                    // checks for arrays
                    if (Array.isArray(val) && val.length > 0) {
                        const hasContent = (v: any): boolean => {
                            if (Array.isArray(v)) return v.some(hasContent);
                            return v === true || v === 1 || v === "1" || (typeof v === 'string' && v.trim().length > 0) || (typeof v === 'number' && v !== 0);
                        };
                        isFilled = hasContent(val);
                    }
                } else {
                    // Simple values
                    if (val !== null && val !== undefined && val !== '') {
                        if (typeof val === 'string') {
                            isFilled = val.trim().length > 0;
                        } else if (typeof val === 'number') {
                            // 0 is a valid number usually, but for "choix" or "ids" maybe not?
                            // numeric/entier: 0 is valid.
                            // date: default is '01/01/1900' -> consider empty?
                            if (['date', 'dateTime', 'heure'].includes(q.Typ_Reponse)) {
                                isFilled = val !== defaultValueMap[q.Typ_Reponse];
                            } else {
                                isFilled = true;
                            }
                        } else {
                            isFilled = true;
                        }
                    }
                }

                if (!isFilled) {
                    isValid = false;
                    newAnswers[q.NumQuestion] = {
                        ...qState,
                        hasError: true,
                        errorMsg: 'Ce champ est obligatoire'
                    };
                    if (firstErrorQNum === -1) firstErrorQNum = q.NumQuestion;
                }
            }
        });

        return { isValid, newAnswers };
    }, [answers, questionsRef]); // removed answers dependency to avoid loop if used in effect, but saveAnswers is manual.

    const saveAnswers = useCallback(async (): Promise<{ result: boolean, data: any[] }> => {
        // Validation
        const { isValid, newAnswers } = validateSurvey();

        if (!isValid) {
            setAnswers(newAnswers);
            return { result: false, data: ["Veuillez corriger les erreurs et remplir les champs obligatoires avant d'enregistrer."] };
        }

        // Filter out invisible answers
        const visibleAnswers: TAnswers = {};
        Object.keys(answers).forEach(key => {
            const qNum = parseInt(key);
            if (answers[qNum]?.isVisible) {
                visibleAnswers[qNum] = answers[qNum];
            }
        });

        try {
            const rsl = await myAxiosPost("surveyAnswersSave", {
                cod_survey,
                cod_reply,
                answers: visibleAnswers,
                evalue,
                evaluateur,
                typ_survey,
                ref_evaluation
            });
            if (rsl.data) {
                return rsl.data;
            }
            return { result: false, data: [] };
        } catch (error) {
            console.error('Error saving answers:', error);
            return { result: false, data: [error] };
        }
    }, [answers, cod_reply, cod_survey, evalue, evaluateur, typ_survey, myAxiosPost, ref_evaluation, validateSurvey]);

    if (isLoading) return <Loading />;

    return (
        <div style={{ width: '100%' }}>
            <div style={{ display: 'flex', flexDirection: 'column', gap: '0px' }}>
                {questions.length > 0 && (
                    <Box sx={{ p: 2, bgcolor: 'var(--bg-input)', color: 'var(--fore-color-base-01)', borderRadius: 1, display: 'flex', justifyContent: 'space-around', alignItems: 'center', width: '100%', border: '1px solid #e0e0e0', mb: '10px' }}>
                        <Box sx={{ textAlign: 'center' }}>
                            <Typography variant="subtitle1" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>Note finale</Typography>
                            <Typography variant="h5" sx={{ color: 'var(--fore-color-base-01)', fontWeight: 'bold' }}>
                                {(totalScore.coefTotal ? (totalScore.noteTotal / totalScore.coefTotal) : 0).toFixed(2)}
                            </Typography>
                        </Box>
                        <Box sx={{ textAlign: 'center' }}>
                            <Typography variant="subtitle1" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>Coefficient</Typography>
                            <Typography variant="h5" sx={{ color: 'var(--fore-color-base-01)', fontWeight: 'bold' }}>
                                {totalScore.coefTotal}
                            </Typography>
                        </Box>
                        <Box sx={{ textAlign: 'center' }}>
                            <Typography variant="subtitle1" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>Score global</Typography>
                            <Typography variant="h5" sx={{ color: 'var(--fore-color-base-01)', fontWeight: 'bold' }}>
                                {totalScore.noteTotal.toFixed(2)}
                            </Typography>
                        </Box>
                    </Box>
                )}

                {
                    questions.map((q) => {
                        const qState = answers[q.NumQuestion];
                        if (!qState || !qState.isVisible) return null;

                        return (
                            <Box key={q.NumQuestion} sx={{ mb: 0 }}>
                                {QuestionRenderer(q)}
                                {qState.hasError && (
                                    <div style={{ marginLeft: '16px', marginTop: '4px', color: 'red' }}>
                                        {qState.errorMsg}
                                    </div>
                                )}
                            </Box>
                        );
                    })
                }
            </div >
        </div >
    );
})

export default Survey_Rendering;