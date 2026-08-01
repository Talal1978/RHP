import { useState, useCallback } from "react";
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
import type { UserDashboardWidget, WidgetDefinition } from "./types";
import { WidgetRenderer } from "./WidgetRenderer";
import { WidgetLibrary } from "./WidgetLibrary";
import { WidgetSettings } from "./WidgetSettings";

interface WidgetBuilderProps {
  open: boolean;
  onClose: () => void;
  availableWidgets: WidgetDefinition[];
  userWidgets: UserDashboardWidget[];
  onSave: (widgets: UserDashboardWidget[]) => void;
}

export const WidgetBuilder = ({
  open,
  onClose,
  availableWidgets,
  userWidgets,
  onSave,
}: WidgetBuilderProps) => {
  const [draftWidgets, setDraftWidgets] = useState<UserDashboardWidget[]>(userWidgets);
  const [selectedWidgetId, setSelectedWidgetId] = useState<string | null>(null);
  const [activeTab, setActiveTab] = useState(0);
  const [previewMode, setPreviewMode] = useState(false);

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

  const handleSave = () => {
    onSave(draftWidgets);
    onClose();
  };

  const handleCancel = () => {
    setDraftWidgets(userWidgets);
    setSelectedWidgetId(null);
    setActiveTab(0);
    setPreviewMode(false);
    onClose();
  };

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
                onChange={(updates) => handleUpdateWidget(selectedWidget.instanceId, updates)}
              />
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
            {draftWidgets.length === 0 ? (
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
                {draftWidgets.map((widget, index) => (
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
                ))}
              </Stack>
            )}
          </Box>
        </Box>
      </Box>
    </Drawer>
  );
};
