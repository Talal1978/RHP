import {
  Box,
  Button,
  Divider,
  Drawer,
  IconButton,
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Stack,
  Tab,
  Tabs,
  Typography,
} from "@mui/material";
import {
  Close,
  Add,
  Delete,
  DragIndicator,
} from "@mui/icons-material";
import { useState } from "react";
import { DynamicIcon } from "./DynamicIcon";
import type { UserDashboardWidget, WidgetDefinition } from "./types";

interface WidgetConfigPanelProps {
  open: boolean;
  onClose: () => void;
  availableWidgets: WidgetDefinition[];
  userWidgets: UserDashboardWidget[];
  onAdd: (widgetId: string) => void;
  onRemove: (instanceId: string) => void;
  onSave: () => void;
}

export const WidgetConfigPanel = ({
  open,
  onClose,
  availableWidgets,
  userWidgets,
  onAdd,
  onRemove,
  onSave,
}: WidgetConfigPanelProps) => {
  const [tab, setTab] = useState(0);

  const userWidgetDefinitions = userWidgets
    .map((uw) => ({
      ...uw,
      definition: availableWidgets.find((aw) => aw.id === uw.widgetId),
    }))
    .filter((uw) => uw.definition);

  return (
    <Drawer anchor="right" open={open} onClose={onClose} PaperProps={{ sx: { width: { xs: "100%", sm: 420 } } }}>
      <Box sx={{ p: 2, display: "flex", alignItems: "center", justifyContent: "space-between" }}>
        <Typography variant="h6" fontWeight="bold">
          Configurer le tableau de bord
        </Typography>
        <IconButton onClick={onClose}>
          <Close />
        </IconButton>
      </Box>
      <Divider />
      <Tabs value={tab} onChange={(_, v) => setTab(v)} variant="fullWidth">
        <Tab label="Widgets disponibles" />
        <Tab label={`Mon dashboard (${userWidgets.length})`} />
      </Tabs>
      <Box sx={{ flex: 1, overflow: "auto", p: 2 }}>
        {tab === 0 && (
          <List dense>
            {availableWidgets.map((widget) => {
              const isAdded = userWidgets.some((uw) => uw.widgetId === widget.id);
              return (
                <ListItem
                  key={widget.id}
                  secondaryAction={
                    <IconButton
                      edge="end"
                      color="primary"
                      onClick={() => onAdd(widget.id)}
                      disabled={isAdded}
                    >
                      <Add />
                    </IconButton>
                  }
                  disablePadding
                >
                  <ListItemButton disabled={isAdded}>
                    <ListItemIcon>
                      <DynamicIcon name={widget.icon} sx={{ color: widget.color }} />
                    </ListItemIcon>
                    <ListItemText
                      primary={widget.title}
                      secondary={widget.description}
                      primaryTypographyProps={{ fontWeight: 600 }}
                    />
                  </ListItemButton>
                </ListItem>
              );
            })}
          </List>
        )}
        {tab === 1 && (
          <List dense>
            {userWidgetDefinitions.map((uw) => (
              <ListItem
                key={uw.instanceId}
                secondaryAction={
                  <IconButton edge="end" color="error" onClick={() => onRemove(uw.instanceId)}>
                    <Delete />
                  </IconButton>
                }
                disablePadding
              >
                <ListItemButton>
                  <ListItemIcon>
                    <DragIndicator sx={{ color: "text.disabled" }} />
                  </ListItemIcon>
                  <ListItemIcon>
                    <DynamicIcon name={uw.definition!.icon} sx={{ color: uw.definition!.color }} />
                  </ListItemIcon>
                  <ListItemText
                    primary={uw.definition!.title}
                    secondary={uw.definition!.description}
                    primaryTypographyProps={{ fontWeight: 600 }}
                  />
                </ListItemButton>
              </ListItem>
            ))}
            {userWidgets.length === 0 && (
              <Typography variant="body2" color="text.secondary" textAlign="center" sx={{ mt: 4 }}>
                Aucun widget ajouté. Allez dans l&apos;onglet "Widgets disponibles" pour en ajouter.
              </Typography>
            )}
          </List>
        )}
      </Box>
      <Divider />
      <Stack direction="row" spacing={2} sx={{ p: 2 }}>
        <Button variant="outlined" fullWidth onClick={onClose}>
          Annuler
        </Button>
        <Button variant="contained" fullWidth onClick={onSave}>
          Enregistrer
        </Button>
      </Stack>
    </Drawer>
  );
};
