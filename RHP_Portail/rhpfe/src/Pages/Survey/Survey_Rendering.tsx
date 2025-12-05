import { useCallback, useEffect, useMemo, useState, useRef } from 'react';
import { Box, Typography } from "@mui/material";
import UdValeurUnique from './Components/UdValeurUnique';
import UdGrilleCases from './Components/UdGrilleCases';
import UdGrilleChoix from './Components/UdGrilleChoix';
import UdGrilleLibre from './Components/UdGrilleLibre';
import { colorBase } from '../../modules/module_general';
import Loading from '../../components/Loading/Loading';
import { TAnswers, TAnswerState, TNoteResult, TQuestion } from './Types';
import useAxiosGet from '../../hooks/useAxiosGet';
import { defaultValueMap, evaluateExpression, func_multi_avg, func_multi_max, func_multi_min, func_multi_sum, getValeur, safeNumber } from './Survey_Functions';

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

const Survey_Rendering = ({ avecNote }: { avecNote: boolean }) => {
    const myAxios = useAxiosGet();
    const [questions, setQuestions] = useState<TQuestion[]>([]);
    const [answers, setAnswers] = useState<TAnswers>({});
    const [isLoading, setIsLoading] = useState(true);
    const questionsRef = useRef<TQuestion[]>([]);
    useEffect(() => {
        questionsRef.current = questions;
    }, [questions]);
    useEffect(() => {
        let isMounted = true;

        const loadQuestions = async () => {
            setIsLoading(true);

            try {
                const rsl = await myAxios({ apiStr: 'surveyQuestions', bdy: { cod_survey: 'SVY000005' } });

                if (!isMounted) return; // Éviter les updates si le composant est démonté

                if (rsl.data.result && rsl.data.data.length > 0) {
                    setQuestions(rsl.data.data);
                    const initialAnswers: TAnswers = {};
                    rsl.data.data.forEach((q: TQuestion) => {
                        initialAnswers[q.NumQuestion] = {
                            ...initialAnswerState,
                            value: initializeQuestionValue(q),
                            note: q.Mode_Scoring === 'na' ? null : {
                                note: 0,
                                coef: safeNumber(q.Coef, 1),
                                note_totale: 0,
                                max_score: safeNumber(q.Max_Score, 0),
                                min_score: 0,
                                note_manuelle: q.Mode_Scoring === 'manuel' ? true : false,

                            },
                            isMandatory: q.Obligatoire,
                            typ_reponse: q.Typ_Reponse,
                            mode_scoring: q.Mode_Scoring,
                        };
                    });
                     setAnswers(initialAnswers);
                } 
            } catch (error) {
                console.error("Erreur chargement questions:", error);
            } finally {
                if (isMounted) {
                    setIsLoading(false);
                }
            }
        };

        loadQuestions();

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
            let finalNote = prevAnswers[qNum]?.note ;
            if (finalNote!== null) {
                if (currentQ.Mode_Scoring === 'func' && currentQ.Func_Scoring) {
                    try {
                        const funcScore = evaluateExpression(
                            currentQ.Func_Scoring,
                            prevAnswers,
                            newValue || defaultValueMap[currentQ.Typ_Reponse], currentQ.Typ_Reponse
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
        
          const reEvaluatedAnswers: TAnswers = { ...updatedAnswers };
            hasChanged = false;
            questionsRef.current.forEach(q => {
                const qState = updatedAnswers[q.NumQuestion] || initialAnswerState;
                // Traitement des questions obligatoires 
                if (q.Obligatoire_Si && q.Obligatoire_Si.trim().length !== 0) {
                    const mandatoryRule = q.Obligatoire_Si;
                    let isConditionallyMandatory = false;
                    try {
                        isConditionallyMandatory = evaluateExpression(mandatoryRule, updatedAnswers, null, q.Typ_Reponse) === true;
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
                            qState.value || defaultValueMap[q.Typ_Reponse], q.Typ_Reponse
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
    }, []); // CORRECTION: Dépendances vides car on utilise questionsRef


    const QuestionRenderer = (q: TQuestion) => {
        const qState = answers[q.NumQuestion] || initialAnswerState;
        const commonProps = {
            numQuestion:  q.NumQuestion ,
            laquestion: q.Question,
            Obligatoire: qState.isMandatory,
            avecNote: q.AvecNote,
            note: qState.note,
            colonnes: q.Reponses_Possibles,
            valeurInitiale: qState.value,
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
        return questions.reduce((total, q) => {
            const qState = answers[q.NumQuestion];
            if (qState && qState.isVisible && q.AvecNote) {
                const noteTotal = safeNumber(qState.note?.note_totale, 0);
                return total + noteTotal;
            }
            return total;
        }, 0);
    }, [answers, questions]);

    if (isLoading) {
        return <Loading />;
    }

    return (
        <div style={{ width: '100vw', minHeight: '100vh', backgroundColor: '#eef2f6', overflowY: 'auto' }}>
            <div style={{
                maxWidth: '1200px',
                width: '95%',
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'stretch',
                justifyContent: 'flex-start',
                margin: '20px auto',
                backgroundColor: 'white',
                padding: '30px',
                borderRadius: '8px',
                boxShadow: '0 4px 12px rgba(0,0,0,0.1)'
            }}>
                <h1 style={{
                    color: colorBase.colorBase01,
                    marginBottom: '20px',
                    borderBottom: `2px solid ${colorBase.colorBase02}`,
                    paddingBottom: '10px'
                }}>
                    Questionnaire de Satisfaction
                </h1>

                {questions.map((q) => {
                    const qState = answers[q.NumQuestion];
                    if (!qState || !qState.isVisible) return null;
                    console.log(`🔍 Rendu Q[${q.NumQuestion}] - note: ${qState.note}`);
                    return (
                        <Box key={q.NumQuestion} sx={{ mb: 2 }}>
                            {QuestionRenderer(q)}
                            {qState.hasError && (
                                <Typography color="error" sx={{ ml: 2, mt: 0.5 }}>
                                    {qState.errorMsg}
                                </Typography>
                            )}
                        </Box>
                    );
                })}

                <Box sx={{ mt: 4, pt: 2, borderTop: '2px solid #ccc' }}>
                    <Typography variant="h6" sx={{ color: colorBase.colorBase01 }}>
                        Score Total du Questionnaire: {totalScore.toFixed(2)}
                    </Typography>
                </Box>
            </div>
        </div>
    );
};

export default Survey_Rendering;