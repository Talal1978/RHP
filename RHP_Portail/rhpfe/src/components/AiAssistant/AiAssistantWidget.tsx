import React, { useState, useRef, useEffect } from 'react';
import {
    Box,
    Paper,
    Typography,
    IconButton,
    TextField,
    Avatar,
    InputAdornment,
    CircularProgress,
    Grow,
    useTheme,
    Tooltip,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow
} from '@mui/material';
import {
    SmartToy,
    Close,
    Send,
    Psychology,
    Person,
    ContentCopy,
    Fullscreen,
    FullscreenExit
} from '@mui/icons-material';
import { colorBase } from '../../modules/module_general';
import useAxiosPost from '../../hooks/useAxiosPost'; // Assuming we'll use this later

interface IMessage {
    id: string;
    text: string;
    sender: 'user' | 'bot';
    timestamp: Date;
    data?: any[];
    isLoading?: boolean;
}

const AiAssistantWidget = () => {
    const theme = useTheme();
    const [isOpen, setIsOpen] = useState(false);
    const [input, setInput] = useState("");
    const [isLoading, setIsLoading] = useState(false);
    const [isAiInit, setIsAiInit] = useState(false); // Track if AI is initializing
    const [isMaximized, setIsMaximized] = useState(false);
    const [messages, setMessages] = useState<IMessage[]>([
        {
            id: '1',
            text: "Bonjour ! Je suis votre assistant RH personnel. Posez-moi une question sur vos congés, les procédures ou l'organigramme.",
            sender: 'bot',
            timestamp: new Date()
        }
    ]);
    const scrollRef = useRef<HTMLDivElement>(null);
    const inputRef = useRef<HTMLInputElement>(null);
    const myAxios = useAxiosPost(); // Preparing for API call

    const [isAiReady, setIsAiReady] = useState(false); // Track readiness for UI indicator

    // Helper for Markdown-like parsing (Bold and Lists)
    const parseBold = (text: string) => {
        const parts = text.split(/(\*\*.*?\*\*)/g);
        return parts.map((part, index) => {
            if (part.startsWith('**') && part.endsWith('**')) {
                return <b key={index}>{part.slice(2, -2)}</b>;
            }
            return part;
        });
    };

    const renderMessageContent = (text: string) => {
        if (!text) return null;
        return text.split('\n').map((line, i) => {
            if (line.trim().startsWith('- ')) {
                return (
                    <Box key={i} component="li" sx={{ ml: 2, listStyleType: 'disc' }}>
                        <Typography variant="body2" component="span">{parseBold(line.trim().substring(2))}</Typography>
                    </Box>
                );
            }
            return (
                <Typography key={i} variant="body2" component="div" sx={{ minHeight: line.trim() === '' ? '0.5em' : 'auto' }}>
                    {parseBold(line)}
                </Typography>
            );
        });
    };

    useEffect(() => {
        if (scrollRef.current) {
            scrollRef.current.scrollIntoView({ behavior: "smooth" });
        }
    }, [messages, isOpen]);

    // Auto-focus input when assistant opens
    useEffect(() => {
        if (isOpen && inputRef.current) {
            inputRef.current.focus();
        }
    }, [isOpen]);

    // Check AI Status on Open/Poll
    useEffect(() => {
        let intervalId: any;

        const checkStatus = () => {
            if (!isOpen) return;
            myAxios("/ask_ai", { question: "PING_STATUS" })
                .then((res: any) => {
                    if (res?.data?.result) {
                        const loading = res.data.data.isAiLoading;
                        setIsAiReady(!loading);
                        
                        if (loading) {
                            setMessages(prev => {
                                const updated = [...prev];
                                // Update first message to loading if it's the bot welcome message
                                if (updated.length > 0 && updated[0].id === '1') {
                                    updated[0] = {
                                        ...updated[0],
                                        text: "Je charge actuellement ma base de connaissances merci de patienter",
                                        isLoading: true
                                    };
                                }
                                return updated;
                            });
                        } else {
                             setMessages(prev => {
                                const updated = [...prev];
                                // Restore welcome message if it was loading
                                if (updated.length > 0 && updated[0].id === '1' && updated[0].isLoading) {
                                    updated[0] = {
                                        ...updated[0],
                                        text: "Bonjour ! Je suis votre assistant RH personnel. Posez-moi une question sur vos congés, les procédures ou l'organigramme.",
                                        isLoading: false
                                    };
                                }
                                return updated;
                            });
                        }
                    }
                })
                .catch(err => console.error("AI Status Check Failed", err));
        };

        if (isOpen) {
            checkStatus(); // Initial check
            // Poll every 5s if not ready
            if (!isAiReady) {
                 intervalId = setInterval(checkStatus, 5000);
            }
        }

        return () => {
            if (intervalId) clearInterval(intervalId);
        };
    }, [isOpen, isAiReady]);

    // Monitor AI initialization status by checking welcome message content
    useEffect(() => {
        if (messages.length > 0 && messages[0].sender === 'bot') {
            const firstMsg = messages[0].text;
            const isLoadingMsg = firstMsg.includes("charge") && firstMsg.includes("base de connaissances");
            if (isLoadingMsg !== isAiInit) {
                setIsAiInit(isLoadingMsg);
            }
        }
    }, [messages, isAiInit]);

    const handleSend = async () => {
        if (!input.trim()) return;

        const userMsg: IMessage = {
            id: Date.now().toString(),
            text: input,
            sender: 'user',
            timestamp: new Date()
        };

        setMessages(prev => [...prev, userMsg]);
        setInput("");
        setIsLoading(true);

        // Build conversation history (last 10 messages for context)
        const history = [...messages, userMsg].slice(-10).map(msg => ({
            role: msg.sender === 'user' ? 'user' : 'assistant',
            content: msg.text
        }));

        // Actual API Call with history
        myAxios("/ask_ai", { question: input, history })
            .then((response: any) => {
                const res = response.data;
                let botText = "Désolé, je n'ai pas pu obtenir de réponse.";
                let botData = undefined;

                if (res?.result && res?.data?.answer) {
                    botText = res.data.answer;
                    // Check for Agentic Tool Data
                    if (res.data.sqlData) {
                        if (Array.isArray(res.data.sqlData)) {
                            botData = res.data.sqlData;
                        } else if (res.data.sqlData.data && Array.isArray(res.data.sqlData.data)) {
                            botData = res.data.sqlData.data;
                        }
                    }

                    if (res.data.isAiLoading) {
                        // AI is still loading - force the specific loading text response
                        botText = "Je charge actuellement ma base de connaissances merci de patienter";
                        
                        // Also update the first message for consistency if it's visible
                        setMessages(prev => {
                            const updated = [...prev];
                            if (updated.length > 0 && updated[0].id === '1') {
                                updated[0] = {
                                    ...updated[0],
                                    text: "Je charge actuellement ma base de connaissances merci de patienter",
                                    isLoading: true
                                };
                            }
                            return updated;
                        });
                        // IMPORTANT: Do NOT return here. Continue to add the botMsg to the conversation
                        // so the user gets a reply to their "salut".
                    } else {
                        // AI is ready - restore welcome message if it was a loading message
                        setMessages(prev => {
                            const updated = [...prev];
                            if (updated[0].isLoading) {
                                updated[0] = {
                                    id: '1',
                                    text: "Bonjour ! Je suis votre assistant RH personnel. Posez-moi une question sur vos congés, les procédures ou l'organigramme.",
                                    sender: 'bot',
                                    timestamp: new Date()
                                };
                            }
                            return updated;
                        });
                    }

                    if (res.data.sources && res.data.sources.length > 0) {
                        botText += "\n\nSources:\n- " + res.data.sources.join("\n- ");
                    }
                } else if (res?.message) {
                    botText = "Erreur: " + res.message;
                }

                const botMsg: IMessage = {
                    id: (Date.now() + 1).toString(),
                    text: botText,
                    sender: 'bot',
                    timestamp: new Date(),
                    data: botData
                };  
                setMessages(prev => [...prev, botMsg]);
            })
            .catch((err: any) => {
                const errorMsg: IMessage = {
                    id: (Date.now() + 1).toString(),
                    text: "Erreur de connexion au serveur IA.",
                    sender: 'bot',
                    timestamp: new Date()
                };
                setMessages(prev => [...prev, errorMsg]);
            })
            .finally(() => {
                setIsLoading(false);
            });
    };

    const handleKeyPress = (e: React.KeyboardEvent) => {
        if (e.key === 'Enter' && !e.shiftKey) {
            e.preventDefault();
            handleSend();
        }
    };

    return (
        <Box sx={{ position: 'relative', display: 'inline-flex' }}>
            <Grow in={isOpen}>
                <Paper
                    elevation={12}
                    sx={{
                        position: isMaximized ? 'fixed' : { xs: 'fixed', sm: 'absolute' },
                        top: isMaximized ? '5vh' : { xs: 70, sm: 60 },
                        right: isMaximized ? '5vw' : { xs: 0, sm: 0 },
                        left: isMaximized ? '5vw' : { xs: 0, sm: 'auto' },
                        margin: isMaximized ? 0 : { xs: '0 auto', sm: 0 },
                        width: isMaximized ? '90vw' : { xs: '90vw', sm: 400 },
                        height: isMaximized ? '90vh' : { xs: 'calc(100vh - 100px)', sm: 600 },
                        maxHeight: isMaximized ? '90vh' : '80vh',
                        zIndex: 1300,
                        display: 'flex',
                        flexDirection: 'column',
                        borderRadius: 4,
                        overflow: 'hidden',
                        border: `1px solid ${theme.palette.divider}`,
                        backgroundImage: theme.palette.mode === 'dark'
                            ? 'linear-gradient(rgba(255, 255, 255, 0.05), rgba(255, 255, 255, 0.05))'
                            : 'none'
                    }}
                >
                    {/* Header */}
                    <Box sx={{
                        p: 2,
                        bgcolor: colorBase.colorBase01,
                        color: 'white',
                        display: 'flex',
                        alignItems: 'center',
                        justifyContent: 'space-between',
                        boxShadow: 1
                    }}>
                        <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
                            <Avatar sx={{ bgcolor: 'white', color: colorBase.colorBase01 }}>
                                <Psychology />
                            </Avatar>
                            <Box sx={{ display: 'flex', flexDirection: 'column' }}>
                                <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
                                    <Typography variant="subtitle1" fontWeight="bold">Assistant RH</Typography>
                                    <Tooltip title={isAiReady ? "Base de connaissance chargée" : "Chargement en cours..."}>
                                        <Box sx={{
                                            width: 8,
                                            height: 8,
                                            borderRadius: '50%',
                                            bgcolor: isAiReady ? '#4caf50' : '#ff9800',
                                            boxShadow: isAiReady ? '0 0 5px #4caf50' : '0 0 5px #ff9800',
                                            animation: isAiReady ? 'none' : 'pulse 1.5s infinite',
                                            '@keyframes pulse': {
                                                '0%': { opacity: 1 },
                                                '50%': { opacity: 0.5 },
                                                '100%': { opacity: 1 },
                                            }
                                        }} />
                                    </Tooltip>
                                </Box>
                                <Typography variant="caption" sx={{ opacity: 0.8 }}>IA Connectée</Typography>
                            </Box>
                        </Box>
                        <Box sx={{ display: 'flex' }}>
                             <IconButton size="small" onClick={() => setIsMaximized(!isMaximized)} sx={{ color: 'white', mr: 1 }}>
                                {isMaximized ? <FullscreenExit /> : <Fullscreen />}
                            </IconButton>
                            <IconButton size="small" onClick={() => setIsOpen(false)} sx={{ color: 'white' }}>
                                <Close />
                            </IconButton>
                        </Box>
                    </Box>

                    {/* Messages Area */}
                    <Box sx={{
                        flexGrow: 1,
                        p: 2,
                        overflowY: 'auto',
                        display: 'flex',
                        flexDirection: 'column',
                        gap: 2,
                        bgcolor: theme.palette.background.default
                    }}>
                        {messages.map((msg) => (
                            <Box
                                key={msg.id}
                                sx={{
                                    alignSelf: msg.sender === 'user' ? 'flex-end' : 'flex-start',
                                    maxWidth: '85%',
                                    display: 'flex',
                                    flexDirection: 'column',
                                    alignItems: msg.sender === 'user' ? 'flex-end' : 'flex-start'
                                }}
                            >
                                <Box sx={{
                                    display: 'flex',
                                    gap: 1,
                                    flexDirection: msg.sender === 'user' ? 'row-reverse' : 'row'
                                }}>
                                    {msg.sender === 'bot' && (
                                        <Avatar sx={{ width: 28, height: 28, bgcolor: colorBase.colorBase02, fontSize: '0.8rem' }}>
                                            <SmartToy fontSize="inherit" />
                                        </Avatar>
                                    )}
                                    <Paper sx={{
                                        p: 1.5,
                                        borderRadius: 2,
                                        bgcolor: msg.sender === 'user'
                                            ? colorBase.colorBase01
                                            : theme.palette.background.paper,
                                        color: msg.sender === 'user' ? 'white' : 'text.primary',
                                        boxShadow: 1,
                                        borderTopLeftRadius: msg.sender === 'bot' ? 0 : 2,
                                        borderTopRightRadius: msg.sender === 'user' ? 0 : 2
                                    }}>
                                        <Box sx={{ display: 'flex', gap: 1, alignItems: 'flex-start', flexDirection: 'column', width: '100%' }}>
                                            <Box sx={{ width: '100%', display: 'flex', gap: 1 }}>
                                                <Box sx={{ flexGrow: 1 }}>
                                                    {renderMessageContent(msg.text)}
                                                </Box>
                                                <Tooltip title="Copier" arrow>
                                                    <IconButton
                                                        size="small"
                                                        onClick={() => {
                                                            let plainText = msg.text;
                                                            let htmlText = `<p>${msg.text}</p>`;

                                                            if (msg.data && msg.data.length > 0) {
                                                                // 1. Prepare TSV for Excel/Plain Text
                                                                const headers = Object.keys(msg.data[0]);
                                                                const separator = "\t";
                                                                const headerRow = headers.join(separator);
                                                                const dataRows = msg.data.map(row => 
                                                                    Object.values(row).map(val => 
                                                                        typeof val === 'boolean' ? (val ? 'Oui' : 'Non') : String(val ?? '')
                                                                    ).join(separator)
                                                                ).join("\n");
                                                                plainText += `\n\n${headerRow}\n${dataRows}`;

                                                                // 2. Prepare HTML Table for Word/Outlook/RichText
                                                                const htmlHeaders = headers.map(h => `<th style="border: 1px solid #ddd; padding: 8px; background-color: #f2f2f2;">${h}</th>`).join("");
                                                                const htmlRows = msg.data.map(row => 
                                                                    `<tr>${Object.values(row).map(val => 
                                                                        `<td style="border: 1px solid #ddd; padding: 8px;">${typeof val === 'boolean' ? (val ? 'Oui' : 'Non') : String(val ?? '')}</td>`
                                                                    ).join("")}</tr>`
                                                                ).join("");
                                                                
                                                                htmlText += `<br><br><table style="border-collapse: collapse; width: 100%; font-family: Arial, sans-serif; font-size: 12px;"><thead><tr>${htmlHeaders}</tr></thead><tbody>${htmlRows}</tbody></table>`;
                                                            }

                                                            const clipboardItem = new ClipboardItem({
                                                                "text/plain": new Blob([plainText], { type: "text/plain" }),
                                                                "text/html": new Blob([htmlText], { type: "text/html" })
                                                            });

                                                            navigator.clipboard.write([clipboardItem]).catch(err => {
                                                                console.error("Clipboard Write Failed", err);
                                                                // Fallback to plain text if API fails
                                                                navigator.clipboard.writeText(plainText);
                                                            });
                                                        }}
                                                        sx={{
                                                            p: 0.5,
                                                            opacity: 0.6,
                                                            alignSelf: 'flex-start',
                                                            color: 'inherit',
                                                            '&:hover': { opacity: 1, bgcolor: 'action.hover' }
                                                        }}
                                                    >
                                                        <ContentCopy fontSize="inherit" style={{ fontSize: '0.9rem' }} />
                                                    </IconButton>
                                                </Tooltip>
                                            </Box>
                                            {msg.isLoading && (
                                               <Box sx={{ display: 'flex', alignItems: 'center', gap: 1, mt: 0.5 }}>
                                                    <Typography variant="caption" sx={{ fontStyle: 'italic', opacity: 0.7 }}>Génération en cours...</Typography>
                                                    <CircularProgress size={12} color="inherit" />
                                               </Box>
                                            )}
                                        </Box>
                                        
                                        {/* Render Analysis Table */}
                                        {msg.data && msg.data.length > 0 && (
                                            <TableContainer component={Box} sx={{ mt: 2, maxHeight: 300, bgcolor: 'background.default', borderRadius: 1, overflow: 'auto' }}>
                                                <Table size="small" stickyHeader>
                                                    <TableHead>
                                                        <TableRow>
                                                            {Object.keys(msg.data[0]).map((key) => (
                                                                <TableCell key={key} sx={{ fontWeight: 'bold', fontSize: '0.7rem', bgcolor: 'action.hover' }}>{key}</TableCell>
                                                            ))}
                                                        </TableRow>
                                                    </TableHead>
                                                    <TableBody>
                                                        {msg.data.map((row: any, i: number) => (
                                                            <TableRow key={i} hover>
                                                                {Object.values(row).map((val: any, j: number) => (
                                                                    <TableCell key={j} sx={{ fontSize: '0.7rem' }}>
                                                                        {typeof val === 'boolean' ? (val ? 'Oui' : 'Non') : String(val ?? '')}
                                                                    </TableCell>
                                                                ))}
                                                            </TableRow>
                                                        ))}
                                                    </TableBody>
                                                </Table>
                                            </TableContainer>
                                        )}
                                    </Paper>
                                </Box>
                                <Typography variant="caption" color="text.secondary" sx={{ mt: 0.5, mx: 1, fontSize: '0.65rem' }}>
                                    {msg.timestamp.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })}
                                </Typography>
                            </Box>
                        ))}
                        {isLoading && (
                            <Box sx={{ display: 'flex', gap: 1, alignItems: 'center', ml: 1 }}>
                                <Avatar sx={{ width: 28, height: 28, bgcolor: theme.palette.action.disabledBackground }}>
                                    <CircularProgress size={14} color="inherit" />
                                </Avatar>
                                <Typography variant="caption" color="text.secondary">L'assistant écrit...</Typography>
                            </Box>
                        )}
                        <div ref={scrollRef} />
                    </Box>

                    {/* Input Area */}
                    <Box sx={{ p: 2, bgcolor: theme.palette.background.paper, borderTop: `1px solid ${theme.palette.divider}` }}>
                        <TextField
                            fullWidth
                            variant="outlined"
                            placeholder="Posez votre question..."
                            size="small"
                            value={input}
                            onChange={(e) => setInput(e.target.value)}
                            onKeyDown={handleKeyPress}
                            inputRef={inputRef}
                            InputProps={{
                                sx: { borderRadius: 4 },
                                endAdornment: (
                                    <InputAdornment position="end">
                                        <IconButton
                                            onClick={handleSend}
                                            disabled={!input.trim() || isLoading}
                                            color="primary"
                                        >
                                            <Send />
                                        </IconButton>
                                    </InputAdornment>
                                )
                            }}
                        />
                        <Typography variant="caption" color="text.secondary" sx={{ display: 'block', textAlign: 'center', mt: 1, fontSize: '0.65rem' }}>
                            L'IA peut commettre des erreurs. Vérifiez les informations importantes.
                        </Typography>
                    </Box>
                </Paper>
            </Grow>

            <Tooltip title="Assistant RH" placement="left">
                <IconButton
                    size="large"
                    color="inherit"
                    onClick={() => setIsOpen(!isOpen)}
                >
                    {isOpen ? <Close /> : <SmartToy />}
                </IconButton>
            </Tooltip>
        </Box>
    );
};

export default AiAssistantWidget;
