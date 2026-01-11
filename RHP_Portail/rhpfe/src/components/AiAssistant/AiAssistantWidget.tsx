import React, { useState, useRef, useEffect } from 'react';
import {
    Box,
    Fab,
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
    ContentCopy
} from '@mui/icons-material';
import { colorBase } from '../../modules/module_general';
import useAxiosPost from '../../hooks/useAxiosPost'; // Assuming we'll use this later

interface IMessage {
    id: string;
    text: string;
    sender: 'user' | 'bot';
    timestamp: Date;
    data?: any[];
}

const AiAssistantWidget = () => {
    const theme = useTheme();
    const [isOpen, setIsOpen] = useState(false);
    const [input, setInput] = useState("");
    const [isLoading, setIsLoading] = useState(false);
    const [messages, setMessages] = useState<IMessage[]>([
        {
            id: '1',
            text: "Bonjour ! Je suis votre assistant RH personnel. Posez-moi une question sur vos congés, les procédures ou l'organigramme.",
            sender: 'bot',
            timestamp: new Date()
        }
    ]);
    const scrollRef = useRef<HTMLDivElement>(null);
    const myAxios = useAxiosPost(); // Preparing for API call

    useEffect(() => {
        if (scrollRef.current) {
            scrollRef.current.scrollIntoView({ behavior: "smooth" });
        }
    }, [messages, isOpen]);

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

        // Simulate API Payload
        // const payload = { question: input };

        // Mock Response for now (until Backend is ready)
        // Actual API Call
        myAxios("/ask_ai", { question: input })
            .then((response: any) => {
                const res = response.data;
                let botText = "Désolé, je n'ai pas pu obtenir de réponse.";
                let botData = undefined;

                if (res?.result && res?.data?.answer) {
                    botText = res.data.answer;
                    // Check for Agentic Tool Data
                    if (res.data.sqlData && Array.isArray(res.data.sqlData)) {
                        botData = res.data.sqlData;
                    }

                    if (res.data.isAiLoading) {
                        // Optional: Handle loading state UI here if needed
                        // For now, text is enough
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
        <Box sx={{ position: 'fixed', bottom: 30, right: 30, zIndex: 9999 }}>
            <Grow in={isOpen}>
                <Paper
                    elevation={12}
                    sx={{
                        position: 'absolute',
                        bottom: 80,
                        right: 0,
                        width: { xs: '90vw', sm: 400 },
                        height: 600,
                        maxHeight: '80vh',
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
                            <Box>
                                <Typography variant="subtitle1" fontWeight="bold">Assistant RH</Typography>
                                <Typography variant="caption" sx={{ opacity: 0.8 }}>IA Connectée</Typography>
                            </Box>
                        </Box>
                        <IconButton size="small" onClick={() => setIsOpen(false)} sx={{ color: 'white' }}>
                            <Close />
                        </IconButton>
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
                                        <Typography variant="body2" sx={{ whiteSpace: 'pre-line' }}>{msg.text}</Typography>
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
                <Fab
                    color="primary"
                    aria-label="chat"
                    onClick={() => setIsOpen(!isOpen)}
                    sx={{
                        width: 64,
                        height: 64,
                        bgcolor: colorBase.colorBase01,
                        '&:hover': { bgcolor: colorBase.colorBase02 },
                        boxShadow: 6
                    }}
                >
                    {isOpen ? <Close fontSize="large" /> : <SmartToy fontSize="large" />}
                </Fab>
            </Tooltip>
        </Box>
    );
};

export default AiAssistantWidget;
