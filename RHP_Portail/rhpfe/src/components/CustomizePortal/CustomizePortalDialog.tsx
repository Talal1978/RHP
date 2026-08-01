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
  InputAdornment,
  Divider,
  IconButton,
  Stack,
} from "@mui/material";
import { useEffect, useMemo, useState } from "react";
import { controleMenus } from "../../modules/module_menus";
import { GetMenuIcon } from "../../Menu/MenuIcons";
import { ArrowDownward, ArrowUpward, RestartAlt, Search } from "@mui/icons-material";
import {
  DASHBOARD_SECTION_DEFINITIONS,
  DEFAULT_DASHBOARD_SECTION_PREFERENCES,
  loadDashboardSectionPreferences,
  saveDashboardSectionPreferences,
  type DashboardSectionPreference,
} from "../../Pages/Dashboard/dashboardSections";
import {
  DASHBOARD_SHORTCUTS_STORAGE_KEY,
  DASHBOARD_SHORTCUTS_UPDATED_EVENT,
  DEFAULT_DASHBOARD_SHORTCUTS,
} from "../../Pages/Dashboard/dashboardShortcuts";

const MAX_SHORTCUTS = 4;

const CustomizePortalDialog = ({
  open,
  onClose,
}: {
  open: boolean;
  onClose: () => void;
}) => {
  const [selectedItems, setSelectedItems] = useState<string[]>([]);
  const [sectionPreferences, setSectionPreferences] = useState<DashboardSectionPreference[]>(
    DEFAULT_DASHBOARD_SECTION_PREFERENCES
  );
  const [searchTerm, setSearchTerm] = useState("");

  useEffect(() => {
    if (!open) {
      return;
    }

    const savedShortcuts = localStorage.getItem(DASHBOARD_SHORTCUTS_STORAGE_KEY);

    if (savedShortcuts) {
      try {
        const parsed = JSON.parse(savedShortcuts);
        const selectedIds = parsed.map((item: any) => item.name_ecran);
        setSelectedItems(selectedIds);
      } catch (error) {
        console.error("Error parsing shortcuts", error);
        setSelectedItems(DEFAULT_DASHBOARD_SHORTCUTS.map((item) => item.name_ecran));
      }
    } else {
      setSelectedItems(DEFAULT_DASHBOARD_SHORTCUTS.map((item) => item.name_ecran));
    }

    setSectionPreferences(loadDashboardSectionPreferences());
  }, [open]);

  const handleToggleShortcut = (value: string) => () => {
    const currentIndex = selectedItems.indexOf(value);
    const newChecked = [...selectedItems];

    if (currentIndex === -1) {
      if (newChecked.length < MAX_SHORTCUTS) {
        newChecked.push(value);
      }
    } else {
      newChecked.splice(currentIndex, 1);
    }

    setSelectedItems(newChecked);
  };

  const handleToggleSection = (sectionId: DashboardSectionPreference["id"]) => {
    setSectionPreferences((current) =>
      current.map((section) =>
        section.id === sectionId ? { ...section, visible: !section.visible } : section
      )
    );
  };

  const moveSection = (sectionId: DashboardSectionPreference["id"], direction: -1 | 1) => {
    setSectionPreferences((current) => {
      const index = current.findIndex((section) => section.id === sectionId);
      const targetIndex = index + direction;

      if (index < 0 || targetIndex < 0 || targetIndex >= current.length) {
        return current;
      }

      const next = [...current];
      const [moved] = next.splice(index, 1);
      next.splice(targetIndex, 0, moved);
      return next;
    });
  };

  const handleResetSections = () => {
    setSectionPreferences(DEFAULT_DASHBOARD_SECTION_PREFERENCES);
  };

  const handleSave = () => {
    const shortcutsToSave = controleMenus
      .filter((item) => selectedItems.includes(item.name_ecran))
      .map((item) => ({
        label: item.text_ecran,
        link:
          item.typ_ecran === "ECR" && item.parent !== ""
            ? `/myspace/${item.name_ecran}/${item.text_ecran}`
            : `/myspace/${item.name_ecran}`,
        img: item.img,
        color: "#e3f2fd",
        name_ecran: item.name_ecran,
      }));

    localStorage.setItem(DASHBOARD_SHORTCUTS_STORAGE_KEY, JSON.stringify(shortcutsToSave));
    window.dispatchEvent(new Event(DASHBOARD_SHORTCUTS_UPDATED_EVENT));
    saveDashboardSectionPreferences(sectionPreferences);
    onClose();
  };

  const availableMenus = useMemo(
    () =>
      controleMenus
        .filter((item) => item.typ_ecran === "ECR" && item.parent !== "")
        .filter((item) =>
          item.text_ecran.toLowerCase().includes(searchTerm.toLowerCase())
        ),
    [searchTerm]
  );

  return (
    <Dialog open={open} onClose={onClose} maxWidth="md" fullWidth>
      <DialogTitle>Personnaliser mon portail</DialogTitle>
      <DialogContent dividers sx={{ maxHeight: "75vh" }}>
        <Stack spacing={3}>
          <Box>
            <Box sx={{ display: "flex", justifyContent: "space-between", alignItems: "center", mb: 2 }}>
              <Box>
                <Typography variant="h6">Sections du portail</Typography>
                <Typography variant="body2" color="text.secondary">
                  Masquez, affichez et réorganisez les sections du dashboard.
                </Typography>
              </Box>
              <Button startIcon={<RestartAlt />} onClick={handleResetSections}>
                Réinitialiser
              </Button>
            </Box>
            <List>
              {sectionPreferences.map((section, index) => {
                const definition = DASHBOARD_SECTION_DEFINITIONS.find(
                  (item) => item.id === section.id
                );

                if (!definition) {
                  return null;
                }

                return (
                  <ListItem
                    key={section.id}
                    secondaryAction={
                      <Stack direction="row" spacing={1}>
                        <IconButton
                          edge="end"
                          size="small"
                          disabled={index === 0}
                          onClick={() => moveSection(section.id, -1)}
                        >
                          <ArrowUpward fontSize="small" />
                        </IconButton>
                        <IconButton
                          edge="end"
                          size="small"
                          disabled={index === sectionPreferences.length - 1}
                          onClick={() => moveSection(section.id, 1)}
                        >
                          <ArrowDownward fontSize="small" />
                        </IconButton>
                      </Stack>
                    }
                    disablePadding
                  >
                    <ListItemButton onClick={() => handleToggleSection(section.id)}>
                      <ListItemIcon>
                        <Checkbox edge="start" checked={section.visible} tabIndex={-1} disableRipple />
                      </ListItemIcon>
                      <ListItemText
                        primary={definition.label}
                        secondary={`Position ${index + 1}`}
                      />
                    </ListItemButton>
                  </ListItem>
                );
              })}
            </List>
          </Box>

          <Divider />

          <Box>
            <Typography variant="h6" sx={{ mb: 1 }}>Accès rapides</Typography>
            <Typography variant="body2" color="text.secondary" paragraph>
              Affichez vos écrans favoris sur votre tableau de bord (max {MAX_SHORTCUTS}).
            </Typography>
            <TextField
              fullWidth
              size="small"
              placeholder="Rechercher un écran..."
              value={searchTerm}
              onChange={(event) => setSearchTerm(event.target.value)}
              InputProps={{
                startAdornment: (
                  <InputAdornment position="start">
                    <Search fontSize="small" />
                  </InputAdornment>
                ),
              }}
              sx={{ mb: 2 }}
            />
            <List>
              {availableMenus.map((item) => {
                const labelId = `shortcut-${item.name_ecran}`;
                const isChecked = selectedItems.includes(item.name_ecran);
                const disabled = !isChecked && selectedItems.length >= MAX_SHORTCUTS;

                return (
                  <ListItem key={item.name_ecran} disablePadding>
                    <ListItemButton role={undefined} onClick={handleToggleShortcut(item.name_ecran)} dense disabled={disabled}>
                      <ListItemIcon>
                        <Checkbox
                          edge="start"
                          checked={isChecked}
                          tabIndex={-1}
                          disableRipple
                          inputProps={{ "aria-labelledby": labelId }}
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
          </Box>
        </Stack>
      </DialogContent>
      <DialogActions>
        <Button onClick={onClose}>Annuler</Button>
        <Button onClick={handleSave} variant="contained">Enregistrer</Button>
      </DialogActions>
    </Dialog>
  );
};

export default CustomizePortalDialog;
