import {
  Box,
  TextField,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  Typography,
  Stack,
  Slider,
  Divider,
  Switch,
  FormControlLabel,
} from "@mui/material";
import { Info } from "@mui/icons-material";
import { colorBase } from "../../../modules/module_general";
import type { UserDashboardWidget, WidgetType, ChartType, StandardWidgetId } from "./types";
import { STANDARD_WIDGET_OPTIONS, BACKEND_OBJECT_OPTIONS } from "./types";

interface WidgetSettingsProps {
  widget: UserDashboardWidget;
  onChange: (updates: Partial<UserDashboardWidget>) => void;
}

const ICON_OPTIONS = [
  "Dashboard", "Speed", "TrendingUp", "Groups", "BeachAccess",
  "AccountBalance", "Receipt", "WorkOutline", "NotificationsOutlined",
  "Newspaper", "CloudOutlined", "Apps", "History", "AccountCircleOutlined",
  "BarChart", "ShowChart", "PieChart", "TableChart", "ListAlt",
];

const COLOR_OPTIONS = [
  colorBase.colorBase01,
  colorBase.colorBase02,
  "#2e7d32",
  "#f57c00",
  "#8e24aa",
  "#d32f2f",
  "#1976d2",
  "#00695c",
  "#455a64",
];

const WIDGET_TYPE_LABELS: Record<WidgetType, string> = {
  kpi: "KPI",
  chart: "Graphique",
  table: "Tableau",
  list: "Liste",
};

const CHART_TYPE_OPTIONS: { value: ChartType; label: string; icon: string }[] = [
  { value: "bar", label: "Barres", icon: "BarChart" },
  { value: "line", label: "Courbe", icon: "ShowChart" },
  { value: "pie", label: "Camembert", icon: "PieChart" },
  { value: "area", label: "Aire", icon: "Timeline" },
];

const AGGREGATION_OPTIONS = [
  { value: "count", label: "Nombre" },
  { value: "sum", label: "Somme" },
  { value: "avg", label: "Moyenne" },
  { value: "min", label: "Minimum" },
  { value: "max", label: "Maximum" },
  { value: "value", label: "Valeur" },
];

export const WidgetSettings = ({ widget, onChange }: WidgetSettingsProps) => {
  return (
    <Box sx={{ p: 2 }}>
      {/* Visibility toggle */}
      <FormControlLabel
        control={
          <Switch
            checked={!widget.dataConfig?.hidden}
            onChange={(e) =>
              onChange({
                dataConfig: { ...widget.dataConfig, hidden: !e.target.checked },
              })
            }
          />
        }
        label="Visible"
        sx={{ mb: 2, display: "block" }}
      />

      <Divider sx={{ my: 2 }} />

      {/* Type */}
      <Typography variant="subtitle2" fontWeight="bold" sx={{ mb: 1 }}>
        Type de widget
      </Typography>
      <Box
        sx={{
          p: 1.5,
          mb: 2,
          borderRadius: 1,
          bgcolor: "rgba(0,0,0,0.04)",
          display: "flex",
          alignItems: "center",
          gap: 1,
        }}
      >
        <Info fontSize="small" color="action" />
        <Typography variant="body2" color="text.secondary">
          {WIDGET_TYPE_LABELS[widget.type]} — Le type est fixé à la création du widget.
        </Typography>
      </Box>

      {/* Chart type */}
      {widget.type === "chart" && (
        <FormControl fullWidth size="small" sx={{ mb: 2 }}>
          <InputLabel>Type de graphique</InputLabel>
          <Select
            value={widget.chartType || "bar"}
            label="Type de graphique"
            onChange={(e) => onChange({ chartType: e.target.value as ChartType })}
          >
            {CHART_TYPE_OPTIONS.map((opt) => (
              <MenuItem key={opt.value} value={opt.value}>
                {opt.label}
              </MenuItem>
            ))}
          </Select>
        </FormControl>
      )}

      <Divider sx={{ my: 2 }} />

      {/* Source */}
      <Typography variant="subtitle2" fontWeight="bold" sx={{ mb: 1 }}>
        Source de données
      </Typography>
      <FormControl fullWidth size="small" sx={{ mb: 2 }}>
        <InputLabel>Objet à afficher</InputLabel>
        <Select
          value={widget.standardId || widget.dataConfig?.objectName || ""}
          label="Objet à afficher"
          onChange={(e) => {
            const value = e.target.value as string;
            const standard = STANDARD_WIDGET_OPTIONS.find((s) => s.id === value);
            if (standard) {
              onChange({
                standardId: value as StandardWidgetId,
                sourceType: "standard",
                title: standard.label,
                icon: standard.icon,
                color: standard.color,
                dataConfig: { ...widget.dataConfig, objectName: value },
              });
            } else {
              const backend = BACKEND_OBJECT_OPTIONS.find((b) => b.id === value);
              onChange({
                standardId: undefined,
                sourceType: "backend",
                title: backend?.label || widget.title,
                icon: backend?.icon || widget.icon,
                color: backend?.color || widget.color,
                dataConfig: { ...widget.dataConfig, objectName: value },
              });
            }
          }}
        >
          <MenuItem disabled>
            <em>Objets standards</em>
          </MenuItem>
          {STANDARD_WIDGET_OPTIONS.map((opt) => (
            <MenuItem key={opt.id} value={opt.id}>
              {opt.label}
            </MenuItem>
          ))}
          <MenuItem disabled>
            <em>Données backend</em>
          </MenuItem>
          {BACKEND_OBJECT_OPTIONS.map((opt) => (
            <MenuItem key={opt.id} value={opt.id}>
              {opt.label}
            </MenuItem>
          ))}
        </Select>
      </FormControl>

      {/* KPI/Chart config */}
      {(widget.type === "kpi" || widget.type === "chart" || widget.type === "table") &&
        widget.sourceType === "backend" && (
          <>
            <FormControl fullWidth size="small" sx={{ mb: 2 }}>
              <InputLabel>Champ</InputLabel>
              <Select
                value={widget.dataConfig?.field || ""}
                label="Champ"
                onChange={(e) =>
                  onChange({
                    dataConfig: { ...widget.dataConfig, field: e.target.value },
                  })
                }
              >
                <MenuItem value="id">Identifiant</MenuItem>
                <MenuItem value="montant">Montant</MenuItem>
                <MenuItem value="duree">Durée</MenuItem>
                <MenuItem value="statut">Statut</MenuItem>
                <MenuItem value="date">Date</MenuItem>
                <MenuItem value="departement">Département</MenuItem>
              </Select>
            </FormControl>
            <FormControl fullWidth size="small" sx={{ mb: 2 }}>
              <InputLabel>Agrégation</InputLabel>
              <Select
                value={widget.dataConfig?.aggregation || "count"}
                label="Agrégation"
                onChange={(e) =>
                  onChange({
                    dataConfig: { ...widget.dataConfig, aggregation: e.target.value as any },
                  })
                }
              >
                {AGGREGATION_OPTIONS.map((opt) => (
                  <MenuItem key={opt.value} value={opt.value}>
                    {opt.label}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
            {widget.type === "chart" && (
              <FormControl fullWidth size="small" sx={{ mb: 2 }}>
                <InputLabel>Grouper par</InputLabel>
                <Select
                  value={widget.dataConfig?.groupBy || ""}
                  label="Grouper par"
                  onChange={(e) =>
                    onChange({
                      dataConfig: { ...widget.dataConfig, groupBy: e.target.value },
                    })
                  }
                >
                  <MenuItem value="">Aucun</MenuItem>
                  <MenuItem value="mois">Mois</MenuItem>
                  <MenuItem value="departement">Département</MenuItem>
                  <MenuItem value="statut">Statut</MenuItem>
                  <MenuItem value="annee">Année</MenuItem>
                </Select>
              </FormControl>
            )}
          </>
        )}

      <Divider sx={{ my: 2 }} />

      {/* Appearance */}
      <Typography variant="subtitle2" fontWeight="bold" sx={{ mb: 1 }}>
        Apparence
      </Typography>
      <TextField
        fullWidth
        size="small"
        label="Titre"
        value={widget.title}
        onChange={(e) => onChange({ title: e.target.value })}
        sx={{ mb: 2 }}
      />
      <FormControl fullWidth size="small" sx={{ mb: 2 }}>
        <InputLabel>Icône</InputLabel>
        <Select
          value={widget.icon}
          label="Icône"
          onChange={(e) => onChange({ icon: e.target.value })}
        >
          {ICON_OPTIONS.map((icon) => (
            <MenuItem key={icon} value={icon}>
              {icon}
            </MenuItem>
          ))}
        </Select>
      </FormControl>
      <Typography variant="caption" color="text.secondary" sx={{ mb: 1, display: "block" }}>
        Couleur
      </Typography>
      <Stack direction="row" spacing={1} sx={{ mb: 2, flexWrap: "wrap" }}>
        {COLOR_OPTIONS.map((color) => (
          <Box
            key={color}
            onClick={() => onChange({ color })}
            sx={{
              width: 28,
              height: 28,
              borderRadius: "50%",
              bgcolor: color,
              cursor: "pointer",
              border: widget.color === color ? "2px solid #000" : "2px solid transparent",
              boxShadow: widget.color === color ? "0 0 0 2px #fff inset" : "none",
            }}
          />
        ))}
      </Stack>

      <Typography variant="caption" color="text.secondary" sx={{ mb: 1, display: "block" }}>
        Largeur ({widget.span}/12)
      </Typography>
      <Slider
        value={widget.span}
        onChange={(_, value) => onChange({ span: value as number })}
        min={3}
        max={12}
        step={3}
        marks={[
          { value: 3, label: "25%" },
          { value: 6, label: "50%" },
          { value: 9, label: "75%" },
          { value: 12, label: "100%" },
        ]}
        valueLabelDisplay="auto"
        sx={{ mb: 2 }}
      />
    </Box>
  );
};
