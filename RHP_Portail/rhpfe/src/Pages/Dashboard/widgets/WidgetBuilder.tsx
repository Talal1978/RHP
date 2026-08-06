import { useState, useCallback, useEffect } from "react";
import {
  Box,
  Button,
  Drawer,
  IconButton,
  Stack,
  Typography,
  Tabs,
  Tab,
  Paper,
  TextField,
  Checkbox,
  FormControlLabel,
} from "@mui/material";
import {
  Close,
  Save,
  Preview,
  Add,
  Edit,
  Delete,
  DragIndicator,
  ExpandLess,
  ExpandMore,
} from "@mui/icons-material";
import type { UserDashboardWidget, WidgetDefinition, WidgetSection } from "./types";
import { WidgetRenderer } from "./WidgetRenderer";
import { WidgetLibrary } from "./WidgetLibrary";
import { WidgetSettings } from "./WidgetSettings";
import useMsgBox from "../../../hooks/useMsgBox";

interface WidgetBuilderProps {
  open: boolean;
  onClose: () => void;
  availableWidgets: WidgetDefinition[];
  userWidgets: UserDashboardWidget[];
  userSections: WidgetSection[];
  onSave: (widgets: UserDashboardWidget[]) => void;
  onSaveSections: (sections: WidgetSection[]) => void;
}

export const WidgetBuilder = ({
  open,
  onClose,
  availableWidgets,
  userWidgets,
  userSections,
  onSave,
  onSaveSections,
}: WidgetBuilderProps) => {
  const [draftWidgets, setDraftWidgets] = useState<UserDashboardWidget[]>(userWidgets);
  const [draftSections, setDraftSections] = useState<WidgetSection[]>(userSections);
  const [selectedWidgetId, setSelectedWidgetId] = useState<string | null>(null);
  const [activeTab, setActiveTab] = useState(0);
  const [previewMode, setPreviewMode] = useState(false);
  const msgBox = useMsgBox();

  // Le builder est monté en permanence par le dashboard (avant même que les
  // widgets existants ne soient chargés depuis localStorage) : le brouillon
  // doit donc être (re)chargé depuis userWidgets à chaque ouverture du tiroir,
  // sinon les widgets existants n'apparaissent pas et seraient écrasés au save.
  useEffect(() => {
    if (open) {
      setDraftWidgets(userWidgets);
      setDraftSections(userSections);
      setSelectedWidgetId(null);
      setActiveTab(0);
      setPreviewMode(false);
    }
  }, [open, userWidgets, userSections]);

  const selectedWidget = draftWidgets.find((w) => w.instanceId === selectedWidgetId);

  const handleAddWidget = useCallback((widget: WidgetDefinition) => {
    const newWidget: UserDashboardWidget = {
      instanceId: `widget_${Date.now()}_${Math.random().toString(36).substr(2, 9)}`,
      widgetId: widget.id,
      title: widget.title,
      type: widget.type,
      chartType: widget.chartType,
      icon: widget.icon,
      color: widget.color,
      span: widget.defaultSpan,
      position: draftWidgets.length,
      sourceType: widget.sourceType,
      standardId: widget.standardId,
      dataConfig: widget.dataConfig,
    };
    setDraftWidgets((prev) => [...prev, newWidget]);
    setSelectedWidgetId(newWidget.instanceId);
    setActiveTab(1);
  }, [draftWidgets.length]);

  const handleUpdateWidget = useCallback((instanceId: string, updates: Partial<UserDashboardWidget>) => {
    setDraftWidgets((prev) =>
      prev.map((w) => (w.instanceId === instanceId ? { ...w, ...updates } : w))
    );
  }, []);

  const handleRemoveWidget = useCallback((instanceId: string) => {
    setDraftWidgets((prev) =>
      prev
        .filter((w) => w.instanceId !== instanceId)
        .map((w, index) => ({ ...w, position: index }))
    );
    if (selectedWidgetId === instanceId) {
      setSelectedWidgetId(null);
      setActiveTab(0);
    }
  }, [selectedWidgetId]);

  const handleMoveUp = useCallback((index: number) => {
    if (index === 0) return;
    setDraftWidgets((prev) => {
      const newOrder = [...prev];
      [newOrder[index - 1], newOrder[index]] = [newOrder[index], newOrder[index - 1]];
      return newOrder.map((w, i) => ({ ...w, position: i }));
    });
  }, []);

  const handleMoveDown = useCallback((index: number) => {
    if (index === draftWidgets.length - 1) return;
    setDraftWidgets((prev) => {
      const newOrder = [...prev];
      [newOrder[index], newOrder[index + 1]] = [newOrder[index + 1], newOrder[index]];
      return newOrder.map((w, i) => ({ ...w, position: i }));
    });
  }, [draftWidgets.length]);

  // ---- Gestion des sections ----
  const orderedSections = [...draftSections].sort((a, b) => a.position - b.position);

  const handleAddSection = useCallback(() => {
    setDraftSections((prev) => [
      ...prev,
      {
        id: `section_${Date.now()}_${Math.random().toString(36).substr(2, 9)}`,
        title: `Section ${prev.length + 1}`,
        position: prev.length,
      },
    ]);
  }, []);

  const handleRenameSection = useCallback((id: string, title: string) => {
    setDraftSections((prev) => prev.map((s) => (s.id === id ? { ...s, title } : s)));
  }, []);

  const handleToggleSectionTitle = useCallback((id: string, showTitle: boolean) => {
    setDraftSections((prev) => prev.map((s) => (s.id === id ? { ...s, showTitle } : s)));
  }, []);

  const handleRemoveSection = useCallback(async (id: string) => {
    // La suppression d'une section entraîne la suppression de son contenu
    const section = draftSections.find((s) => s.id === id);
    const nbWidgets = draftWidgets.filter((w) => w.sectionId === id).length;
    if (nbWidgets > 0) {
      const reply = await msgBox({
        titre: "Suppression de section",
        msg: `Supprimer la section "${section?.title || "Sans titre"}" et ses ${nbWidgets} widget(s) ?`,
        typMsg: "question",
        typReply: "OKCancel",
      });
      if (reply !== "Ok") return;
    }
    setDraftSections((prev) => prev.filter((s) => s.id !== id).map((s, i) => ({ ...s, position: i })));
    setDraftWidgets((prev) => prev.filter((w) => w.sectionId !== id));
  }, [draftSections, draftWidgets, msgBox]);

  const handleMoveSection = useCallback((id: string, direction: "up" | "down") => {
    setDraftSections((prev) => {
      const ordered = [...prev].sort((a, b) => a.position - b.position);
      const index = ordered.findIndex((s) => s.id === id);
      const target = direction === "up" ? index - 1 : index + 1;
      if (index < 0 || target < 0 || target >= ordered.length) return prev;
      [ordered[index], ordered[target]] = [ordered[target], ordered[index]];
      return ordered.map((s, i) => ({ ...s, position: i }));
    });
  }, []);

  const handleSave = () => {
    onSave(draftWidgets);
    onSaveSections(draftSections);
    onClose();
  };

  const handleCancel = () => {
    setDraftWidgets(userWidgets);
    setDraftSections(userSections);
    setSelectedWidgetId(null);
    setActiveTab(0);
    setPreviewMode(false);
    onClose();
  };

  const unsectionedDraft = draftWidgets.filter(
    (w) => !w.sectionId || !draftSections.some((s) => s.id === w.sectionId)
  );

  const renderWidgetItem = (widget: UserDashboardWidget, index: number) => (
    <Paper
      key={widget.instanceId}
      onClick={() => {
        if (!previewMode) {
          setSelectedWidgetId(widget.instanceId);
          setActiveTab(1);
        }
      }}
      sx={{
        position: "relative",
        border: selectedWidgetId === widget.instanceId && !previewMode
          ? "2px solid"
          : "2px solid transparent",
        borderColor: selectedWidgetId === widget.instanceId && !previewMode
          ? widget.color
          : "transparent",
        cursor: previewMode ? "default" : "pointer",
        transition: "all 0.2s",
        "&:hover": previewMode
          ? {}
          : {
              boxShadow: "0 4px 12px rgba(0,0,0,0.1)",
            },
      }}
    >
      {!previewMode && (
        <Box
          sx={{
            position: "absolute",
            top: -12,
            right: 10,
            display: "flex",
            gap: 0.5,
            bgcolor: widget.color,
            borderRadius: 1,
            px: 0.5,
            py: 0.25,
            zIndex: 10,
          }}
        >
          <IconButton
            type="button"
            size="small"
            sx={{ color: "#fff" }}
            onMouseDown={(e) => e.stopPropagation()}
            onClick={(e) => {
              e.stopPropagation();
              e.preventDefault();
              handleMoveUp(index);
            }}
            disabled={index === 0}
          >
            <ExpandLess sx={{ fontSize: 16 }} />
          </IconButton>
          <IconButton
            type="button"
            size="small"
            sx={{ color: "#fff" }}
            onMouseDown={(e) => e.stopPropagation()}
            onClick={(e) => {
              e.stopPropagation();
              e.preventDefault();
              handleMoveDown(index);
            }}
            disabled={index === draftWidgets.length - 1}
          >
            <ExpandMore sx={{ fontSize: 16 }} />
          </IconButton>
          <IconButton
            type="button"
            size="small"
            sx={{ color: "#fff" }}
            onMouseDown={(e) => e.stopPropagation()}
            onClick={(e) => {
              e.stopPropagation();
              e.preventDefault();
              setSelectedWidgetId(widget.instanceId);
              setActiveTab(1);
            }}
          >
            <Edit sx={{ fontSize: 16 }} />
          </IconButton>
          <IconButton
            type="button"
            size="small"
            sx={{ color: "#fff" }}
            onMouseDown={(e) => e.stopPropagation()}
            onClick={(e) => {
              e.stopPropagation();
              e.preventDefault();
              handleRemoveWidget(widget.instanceId);
            }}
          >
            <Delete sx={{ fontSize: 16 }} />
          </IconButton>
        </Box>
      )}
      <Box sx={{ p: 2 }}>
        <WidgetRenderer definition={{
          id: widget.widgetId,
          title: widget.title,
          type: widget.type,
          chartType: widget.chartType,
          sourceType: widget.sourceType,
          standardId: widget.standardId,
          icon: widget.icon,
          color: widget.color,
          defaultSpan: widget.span,
          dataConfig: widget.dataConfig,
        }} />
      </Box>
    </Paper>
  );

  return (
    <Drawer
      anchor="right"
      open={open}
      onClose={handleCancel}
      PaperProps={{ sx: { width: { xs: "100%", md: "80%", lg: "70%" }, maxWidth: 1200 } }}
    >
      <Box sx={{ display: "flex", height: "100%" }}>
        {/* Left sidebar - Library / Settings */}
        <Box sx={{ width: 320, borderRight: 1, borderColor: "divider", display: "flex", flexDirection: "column" }}>
          <Box sx={{ p: 2, borderBottom: 1, borderColor: "divider" }}>
            <Typography variant="h6" fontWeight="bold">
              Builder de widgets
            </Typography>
            <Typography variant="caption" color="text.secondary">
              Style Elementor
            </Typography>
          </Box>
          <Tabs value={activeTab} onChange={(_, v) => setActiveTab(v)} variant="fullWidth">
            <Tab label="Widgets" />
            <Tab label="Réglages" disabled={!selectedWidget} />
            <Tab label="Sections" />
          </Tabs>
          <Box sx={{ flex: 1, overflow: "auto" }}>
            {activeTab === 0 && (
              <WidgetLibrary
                availableWidgets={availableWidgets}
                onAdd={handleAddWidget}
              />
            )}
            {activeTab === 1 && selectedWidget && (
              <WidgetSettings
                widget={selectedWidget}
                sections={orderedSections}
                onChange={(updates) => handleUpdateWidget(selectedWidget.instanceId, updates)}
              />
            )}
            {activeTab === 2 && (
              <Box sx={{ p: 2 }}>
                <Button
                  fullWidth
                  variant="outlined"
                  size="small"
                  startIcon={<Add />}
                  onClick={handleAddSection}
                  sx={{ mb: 2 }}
                >
                  Nouvelle section
                </Button>
                <Stack spacing={1.5}>
                  {orderedSections.map((section, index) => (
                    <Paper key={section.id} variant="outlined" sx={{ p: 1.5 }}>
                      <Stack direction="row" spacing={1} alignItems="center">
                        <Stack spacing={0} sx={{ flexShrink: 0 }}>
                          <IconButton
                            size="small"
                            onClick={() => handleMoveSection(section.id, "up")}
                            disabled={index === 0}
                            sx={{ p: 0.25 }}
                          >
                            <ExpandLess sx={{ fontSize: 18 }} />
                          </IconButton>
                          <IconButton
                            size="small"
                            onClick={() => handleMoveSection(section.id, "down")}
                            disabled={index === orderedSections.length - 1}
                            sx={{ p: 0.25 }}
                          >
                            <ExpandMore sx={{ fontSize: 18 }} />
                          </IconButton>
                        </Stack>
                        <TextField
                          fullWidth
                          size="small"
                          label="Titre de la section"
                          value={section.title}
                          onChange={(e) => handleRenameSection(section.id, e.target.value)}
                        />
                        <IconButton
                          size="small"
                          color="error"
                          onClick={() => handleRemoveSection(section.id)}
                        >
                          <Delete fontSize="small" />
                        </IconButton>
                      </Stack>
                      <FormControlLabel
                        control={
                          <Checkbox
                            size="small"
                            checked={section.showTitle !== false}
                            onChange={(e) => handleToggleSectionTitle(section.id, e.target.checked)}
                          />
                        }
                        label={
                          <Typography variant="caption" color="text.secondary">
                            Afficher le titre de la section
                          </Typography>
                        }
                        sx={{ ml: 0.5, mt: 0.5 }}
                      />
                    </Paper>
                  ))}
                  {orderedSections.length === 0 && (
                    <Typography variant="body2" color="text.secondary">
                      Aucune section. Créez-en une pour regrouper vos widgets, puis affectez-leur
                      la section depuis l'onglet Réglages.
                    </Typography>
                  )}
                </Stack>
              </Box>
            )}
          </Box>
        </Box>

        {/* Center - Preview / Editor */}
        <Box sx={{ flex: 1, display: "flex", flexDirection: "column", bgcolor: "#f5f5f5" }}>
          {/* Toolbar */}
          <Box
            sx={{
              p: 2,
              bgcolor: "background.paper",
              borderBottom: 1,
              borderColor: "divider",
              display: "flex",
              justifyContent: "space-between",
              alignItems: "center",
            }}
          >
            <Stack direction="row" spacing={1} alignItems="center">
              <Typography variant="subtitle1" fontWeight="bold">
                {previewMode ? "Aperçu" : "Édition"}
              </Typography>
              <Button
                size="small"
                startIcon={<Preview />}
                onClick={() => setPreviewMode(!previewMode)}
                variant={previewMode ? "contained" : "outlined"}
              >
                {previewMode ? "Éditer" : "Aperçu"}
              </Button>
            </Stack>
            <Stack direction="row" spacing={1}>
              <Button variant="outlined" size="small" onClick={handleCancel}>
                Annuler
              </Button>
              <Button variant="contained" size="small" startIcon={<Save />} onClick={handleSave}>
                Enregistrer
              </Button>
            </Stack>
          </Box>

          {/* Canvas */}
          <Box sx={{ flex: 1, overflow: "auto", p: 4 }}>
            {draftWidgets.length === 0 && draftSections.length === 0 ? (
              <Paper
                sx={{
                  p: 6,
                  textAlign: "center",
                  border: "2px dashed",
                  borderColor: "divider",
                  bgcolor: "background.paper",
                }}
              >
                <Add sx={{ fontSize: 48, color: "text.disabled", mb: 2 }} />
                <Typography variant="h6" color="text.secondary">
                  Commencez par ajouter un widget
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  Sélectionnez un widget dans la bibliothèque à gauche
                </Typography>
              </Paper>
            ) : (
              <Stack spacing={2}>
                {orderedSections.map((section) => {
                  const sectionWidgets = draftWidgets.filter((w) => w.sectionId === section.id);
                  return (
                    <Paper
                      key={section.id}
                      variant="outlined"
                      sx={{ p: 2, borderStyle: "dashed", borderColor: "divider" }}
                    >
                      <Typography
                        variant="subtitle2"
                        fontWeight="bold"
                        sx={{
                          mb: 1.5,
                          color: "text.secondary",
                          textTransform: "uppercase",
                          letterSpacing: 0.5,
                          opacity: section.showTitle === false ? 0.45 : 1,
                        }}
                      >
                        {section.title || "Sans titre"} ({sectionWidgets.length})
                        {section.showTitle === false ? " — titre masqué" : ""}
                      </Typography>
                      {sectionWidgets.length === 0 ? (
                        <Typography variant="body2" color="text.disabled">
                          Aucun widget dans cette section — affectez-en via l'onglet Réglages
                        </Typography>
                      ) : (
                        <Stack spacing={2}>
                          {sectionWidgets.map((widget) => renderWidgetItem(widget, draftWidgets.indexOf(widget)))}
                        </Stack>
                      )}
                    </Paper>
                  );
                })}
                {unsectionedDraft.length > 0 && (
                  <Stack spacing={2}>
                    {unsectionedDraft.map((widget) => renderWidgetItem(widget, draftWidgets.indexOf(widget)))}
                  </Stack>
                )}
              </Stack>
            )}
          </Box>
        </Box>
      </Box>
    </Drawer>
  );
};
