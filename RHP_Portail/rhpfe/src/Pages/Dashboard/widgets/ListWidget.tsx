import React, { useContext } from "react";
import { Card, CardContent, Stack, Typography, Box, Paper } from "@mui/material";
import { DynamicIcon } from "./DynamicIcon";
import { StandardWidgetDataContext } from "./StandardWidgetDataContext";
import { dashboardSectionRegistry } from "../dashboardSectionRegistry";
import ParapheurSection, { type ParapheurSectionProps } from "../sections/ParapheurSection";
import type { DashboardSectionId } from "../dashboardSections";
import type { WidgetDefinition } from "./types";

interface ListWidgetProps {
  definition: WidgetDefinition;
}

/** Correspondance standardId du widget -> section du dashboard. */
const STANDARD_TO_SECTION: Partial<Record<string, DashboardSectionId>> = {
  blogs: "news",
  notifications: "notifications",
  quickActions: "quickActions",
  weather: "weather",
};

export const ListWidget = ({ definition }: ListWidgetProps) => {
  const standardData = useContext(StandardWidgetDataContext);
  const sectionId = definition.standardId ? STANDARD_TO_SECTION[definition.standardId] : undefined;

  // Widget "Parapheur" : composant dédié (documents à signer)
  if (definition.standardId === "parapheur") {
    const props = (standardData["parapheur"] ?? {}) as unknown as ParapheurSectionProps;
    return <ParapheurSection {...props} />;
  }

  // Widgets standards rattachés à une section : rendu du vrai contenu
  // (la section affiche son propre en-tête avec la couleur de la charte).
  // NB : le contexte est alimenté par standardId ("blogs", "notifications", "quickActions").
  if (sectionId) {
    const SectionComponent = dashboardSectionRegistry[sectionId];
    const sectionProps = (definition.standardId ? standardData[definition.standardId] : undefined) ?? {};
    return (
      <React.Suspense
        fallback={
          <Paper sx={{ p: 3, borderRadius: 2, border: "1px solid", borderColor: "divider", boxShadow: "none", bgcolor: "background.paper" }}>
            <Typography color="text.secondary">Chargement...</Typography>
          </Paper>
        }
      >
        <SectionComponent {...sectionProps} />
      </React.Suspense>
    );
  }

  return (
    <Card
      sx={{
        borderRadius: 2,
        boxShadow: "0 1px 3px rgba(0,0,0,0.06)",
        border: "1px solid rgba(0,0,0,0.06)",
        height: "100%",
      }}
    >
      <CardContent sx={{ p: 3 }}>
        <Stack
          direction="row"
          alignItems="center"
          spacing={1}
          sx={{ mb: 2, justifyContent: { xs: "center", sm: "flex-start" } }}
        >
          <DynamicIcon name={definition.icon} sx={{ fontSize: 20, color: definition.color }} />
          <Typography variant="h6" fontWeight="bold" sx={{ color: definition.color }}>
            {definition.title}
          </Typography>
        </Stack>
        <Box
          sx={{
            p: 3,
            textAlign: "center",
            bgcolor: "rgba(0,0,0,0.02)",
            borderRadius: 1,
          }}
        >
          <Typography variant="body2" color="text.secondary">
            Widget standard : {definition.title}
          </Typography>
          <Typography variant="caption" color="text.secondary" display="block" sx={{ mt: 1 }}>
            Ce widget affichera le contenu de l&apos;objet standard sélectionné.
          </Typography>
        </Box>
      </CardContent>
    </Card>
  );
};
