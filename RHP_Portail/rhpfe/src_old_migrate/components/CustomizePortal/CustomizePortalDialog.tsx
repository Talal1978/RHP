import {
    Dialog,
    DialogTitle,
    DialogContent,
    DialogActions,
    Button,
    List,
    ListItem,
    ListItemButton,
    ListItemIcon,
    ListItemText,
    Checkbox,
    Typography,
    Box,
    TextField,
    InputAdornment
} from "@mui/material";
import { useEffect, useState } from "react";
import { controleMenus } from "../../modules/module_menus";
import { GetMenuIcon } from "../../Menu/MenuIcons";
import { Search } from "@mui/icons-material";

const CustomizePortalDialog = ({
    open,
    onClose
}: {
    open: boolean;
    onClose: () => void;
}) => {
    const [selectedItems, setSelectedItems] = useState<string[]>([]);
    const [searchTerm, setSearchTerm] = useState("");

    // Load saved shortcuts on open
    useEffect(() => {
        if (open) {
            const savedShortcuts = localStorage.getItem("MYSPACE_SHORTCUTS");
            if (savedShortcuts) {
                try {
                    const parsed = JSON.parse(savedShortcuts);
                    const selectedIds = parsed.map((item: any) => item.name_ecran);
                    setSelectedItems(selectedIds);
                } catch (e) {
                    console.error("Error parsing shortcuts", e);
                }
            }
        }
    }, [open]);

    const handleToggle = (value: string) => () => {
        const currentIndex = selectedItems.indexOf(value);
        const newChecked = [...selectedItems];

        if (currentIndex === -1) {
            if (newChecked.length < 4) {
                newChecked.push(value);
            }
        } else {
            newChecked.splice(currentIndex, 1);
        }

        setSelectedItems(newChecked);
    };

    const handleSave = () => {
        // Find full menu objects for selected IDs
        const shortcutsToSave = controleMenus
            .filter(item => selectedItems.includes(item.name_ecran))
            .map(item => ({
                label: item.text_ecran,
                link: item.typ_ecran === "ECR" && item.parent !== ""
                    ? `/myspace/${item.name_ecran}/${item.text_ecran}`
                    : `/myspace/${item.name_ecran}`, // Fallback logic
                img: item.img,
                color: "#e3f2fd", // Default color
                name_ecran: item.name_ecran
            }));

        localStorage.setItem("MYSPACE_SHORTCUTS", JSON.stringify(shortcutsToSave));

        // Dispatch event to notify Dashboard
        window.dispatchEvent(new Event("portal-shortcuts-updated"));

        onClose();
    };

    // Filter available menus: Only "ECR" type and leaf nodes (usually have parent)
    const availableMenus = controleMenus
        .filter(item => item.typ_ecran === "ECR" && item.parent !== "")
        .filter(item =>
            item.text_ecran.toLowerCase().includes(searchTerm.toLowerCase())
        );

    return (
        <Dialog open={open} onClose={onClose} maxWidth="sm" fullWidth>
            <DialogTitle>Personnaliser mes accès rapides</DialogTitle>
            <DialogContent dividers sx={{ height: '400px' }}>
                <Box sx={{ mb: 2 }}>
                    <Typography variant="body2" color="text.secondary" paragraph>
                        Affichez vos écrans favoris sur votre tableau de bord (max 4).
                    </Typography>
                    <TextField
                        fullWidth
                        size="small"
                        placeholder="Rechercher un écran..."
                        value={searchTerm}
                        onChange={(e) => setSearchTerm(e.target.value)}
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <Search fontSize="small" />
                                </InputAdornment>
                            ),
                        }}
                    />
                </Box>
                <List>
                    {availableMenus.map((item) => {
                        const labelId = `checkbox-list-label-${item.name_ecran}`;
                        const isChecked = selectedItems.includes(item.name_ecran);
                        const disabled = !isChecked && selectedItems.length >= 4;

                        return (
                            <ListItem
                                key={item.name_ecran}
                                disablePadding
                            >
                                <ListItemButton role={undefined} onClick={handleToggle(item.name_ecran)} dense disabled={disabled}>
                                    <ListItemIcon>
                                        <Checkbox
                                            edge="start"
                                            checked={isChecked}
                                            tabIndex={-1}
                                            disableRipple
                                            inputProps={{ 'aria-labelledby': labelId }}
                                        />
                                    </ListItemIcon>
                                    <ListItemIcon sx={{ minWidth: 40 }}>
                                        <GetMenuIcon name_ecran={item.img || ""} />
                                    </ListItemIcon>
                                    <ListItemText id={labelId} primary={item.text_ecran} />
                                </ListItemButton>
                            </ListItem>
                        );
                    })}
                </List>
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose}>Annuler</Button>
                <Button onClick={handleSave} variant="contained" color="primary">Enregistrer</Button>
            </DialogActions>
        </Dialog>
    );
};

export default CustomizePortalDialog;
