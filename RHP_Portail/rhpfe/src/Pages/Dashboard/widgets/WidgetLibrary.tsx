import { useState } from "react";
import {
  Box,
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Typography,
  TextField,
  InputAdornment,
  Chip,
} from "@mui/material";
import { Search, Add } from "@mui/icons-material";
import { DynamicIcon } from "./DynamicIcon";
import type { WidgetDefinition } from "./types";

interface WidgetLibraryProps {
  availableWidgets: WidgetDefinition[];
  onAdd: (widget: WidgetDefinition) => void;
}

const CATEGORIES = [
  { id: "all", label: "Tous" },
  { id: "standard", label: "Standards" },
  { id: "backend", label: "Données backend" },
];

export const WidgetLibrary = ({ availableWidgets, onAdd }: WidgetLibraryProps) => {
  const [search, setSearch] = useState("");
  const [category, setCategory] = useState("all");

  const filteredWidgets = availableWidgets.filter((widget) => {
    const matchesSearch = widget.title.toLowerCase().includes(search.toLowerCase()) ||
      (widget.description?.toLowerCase().includes(search.toLowerCase()) ?? false);
    const matchesCategory = category === "all" || widget.sourceType === category;
    return matchesSearch && matchesCategory;
  });

  return (
    <Box sx={{ p: 2 }}>
      <TextField
        fullWidth
        size="small"
        placeholder="Rechercher un widget..."
        value={search}
        onChange={(e) => setSearch(e.target.value)}
        InputProps={{
          startAdornment: (
            <InputAdornment position="start">
              <Search fontSize="small" />
            </InputAdornment>
          ),
        }}
        sx={{ mb: 2 }}
      />
      <Box sx={{ display: "flex", gap: 1, mb: 2, flexWrap: "wrap" }}>
        {CATEGORIES.map((cat) => (
          <Chip
            key={cat.id}
            label={cat.label}
            size="small"
            onClick={() => setCategory(cat.id)}
            color={category === cat.id ? "primary" : "default"}
            variant={category === cat.id ? "filled" : "outlined"}
          />
        ))}
      </Box>
      <List dense>
        {filteredWidgets.map((widget) => (
          <ListItem
            key={widget.id}
            disablePadding
            secondaryAction={
              <ListItemButton
                onClick={() => onAdd(widget)}
                sx={{ justifyContent: "center", width: 40, borderRadius: 1 }}
              >
                <Add sx={{ color: widget.color }} />
              </ListItemButton>
            }
          >
            <ListItemButton onClick={() => onAdd(widget)}>
              <ListItemIcon>
                <DynamicIcon name={widget.icon} sx={{ color: widget.color, fontSize: 24 }} />
              </ListItemIcon>
              <ListItemText
                primary={widget.title}
                secondary={widget.description}
                primaryTypographyProps={{ fontWeight: 600, fontSize: "0.9rem" }}
              />
            </ListItemButton>
          </ListItem>
        ))}
      </List>
      {filteredWidgets.length === 0 && (
        <Typography variant="body2" color="text.secondary" textAlign="center" sx={{ mt: 4 }}>
          Aucun widget trouvé
        </Typography>
      )}
    </Box>
  );
};
