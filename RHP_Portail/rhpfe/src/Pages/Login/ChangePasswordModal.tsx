import React, { useState, useEffect } from "react";
import { Dialog, DialogContent, DialogTitle, LinearProgress, TextField, Typography, Box, InputAdornment, IconButton } from "@mui/material";
import { colorBase } from "../../modules/module_general";
import Bouton from "../../components/Bouton/Bouton";
import useAxiosPost from "../../hooks/useAxiosPost";
import { Agent } from "../../modules/module_general";
import { Visibility, VisibilityOff, Close } from "@mui/icons-material";

interface ChangePasswordModalProps {
    open: boolean;
    onClose?: () => void;
    onSuccess: () => void;
}

const ChangePasswordModal: React.FC<ChangePasswordModalProps> = ({ open, onClose, onSuccess }) => {
    const [pwd, setPwd] = useState("");
    const [confirmPwd, setConfirmPwd] = useState("");
    const [strength, setStrength] = useState(0);
    const [error, setError] = useState("");
    const [showPwd, setShowPwd] = useState(false);
    const [showConfirmPwd, setShowConfirmPwd] = useState(false);
    const myAxiosPost = useAxiosPost();

    const calculateStrength = (password: string) => {
        let score = 0;
        if (password.length >= 8) score++;
        if (/[A-Z]/.test(password)) score++;
        if (/[a-z]/.test(password)) score++;
        if (/[0-9]/.test(password)) score++;
        if (/[^A-Za-z0-9]/.test(password)) score++;
        return score;
    };

    useEffect(() => {
        setStrength(calculateStrength(pwd));
    }, [pwd]);

    const handleSubmit = async () => {
        if (pwd !== confirmPwd) {
            setError("Les mots de passe ne correspondent pas.");
            return;
        }
        if (strength < 5) {
            setError("Le mot de passe doit contenir 8 caractères, majuscule, minuscule, chiffre et caractère spécial.");
            return;
        }

        // Call backend
        const rsl = await myAxiosPost("setPwd", {
            pwd,
            Login: Agent.Matricule,
            id_Societe: Agent.id_Societe
        });

        if (rsl?.data?.result) {
            onSuccess();
        } else {
            setError("Erreur lors de la mise à jour du mot de passe.");
        }
    };

    const getProgressColor = () => {
        if (strength <= 2) return "error";
        if (strength <= 4) return "warning";
        return "success";
    };

    const handleClickShowPassword = () => setShowPwd((show) => !show);
    const handleClickShowConfirmPassword = () => setShowConfirmPwd((show) => !show);

    return (
        <Dialog open={open} maxWidth="sm" fullWidth>
            <DialogTitle sx={{ m: 0, p: 2, display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                Changer votre mot de passe
                {onClose ? (
                    <IconButton
                        aria-label="close"
                        onClick={onClose}
                        sx={{
                            color: (theme) => theme.palette.grey[500],
                        }}
                    >
                        <Close />
                    </IconButton>
                ) : null}
            </DialogTitle>
            <DialogContent>
                <Box sx={{ display: 'flex', flexDirection: 'column', gap: 2, mt: 1 }}>
                    <TextField
                        label="Nouveau mot de passe"
                        type={showPwd ? "text" : "password"}
                        autoComplete="new-password"
                        fullWidth
                        value={pwd}
                        onChange={(e) => {
                            setPwd(e.target.value);
                            setError("");
                        }}
                        InputProps={{
                            endAdornment: (
                                <InputAdornment position="end">
                                    <IconButton
                                        aria-label="toggle password visibility"
                                        onClick={handleClickShowPassword}
                                        edge="end"
                                    >
                                        {showPwd ? <VisibilityOff /> : <Visibility />}
                                    </IconButton>
                                </InputAdornment>
                            ),
                        }}
                    />
                    <LinearProgress
                        variant="determinate"
                        value={(strength / 5) * 100}
                        color={getProgressColor()}
                        sx={{ height: 10, borderRadius: 5 }}
                    />
                    <Typography variant="caption" color="textSecondary">
                        Force du mot de passe (Requis: 8 chars, Maj, Min, Chiffre, Special)
                    </Typography>

                    <TextField
                        label="Confirmer le mot de passe"
                        type={showConfirmPwd ? "text" : "password"}
                        autoComplete="new-password"
                        fullWidth
                        value={confirmPwd}
                        onChange={(e) => {
                            setConfirmPwd(e.target.value);
                            setError("");
                        }}
                        InputProps={{
                            endAdornment: (
                                <InputAdornment position="end">
                                    <IconButton
                                        aria-label="toggle password visibility"
                                        onClick={handleClickShowConfirmPassword}
                                        edge="end"
                                    >
                                        {showConfirmPwd ? <VisibilityOff /> : <Visibility />}
                                    </IconButton>
                                </InputAdornment>
                            ),
                        }}
                    />

                    {error && (
                        <Typography color="error" variant="body2">
                            {error}
                        </Typography>
                    )}

                    <Bouton
                        label="Valider"
                        variant="contained"
                        sx={{ backgroundColor: colorBase.colorBase01, mt: 2 }}
                        onClick={handleSubmit}
                        disabled={strength < 5 || pwd !== confirmPwd}
                    />
                </Box>
            </DialogContent>
        </Dialog>
    );
};

export default ChangePasswordModal;
