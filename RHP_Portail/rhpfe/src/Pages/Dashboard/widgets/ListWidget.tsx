import { Card, CardContent, Stack, Typography, Box } from "@mui/material";
import { DynamicIcon } from "./DynamicIcon";
import type { WidgetDefinition } from "./types";

interface ListWidgetProps {
  definition: WidgetDefinition;
}

export const ListWidget = ({ definition }: ListWidgetProps) => {
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
