import { Card, CardContent, Skeleton, Stack, Typography } from "@mui/material";
import { LockOutlined } from "@mui/icons-material";
import { KpiWidget } from "./KpiWidget";
import { ChartWidget } from "./ChartWidget";
import { TableWidget } from "./TableWidget";
import { ListWidget } from "./ListWidget";
import { useWidgetData } from "./useWidgetData";
import type { ChartData, KpiData, TableData, WidgetDefinition } from "./types";

interface WidgetRendererProps {
  definition: WidgetDefinition;
}

const CARD_SX = {
  borderRadius: 2,
  boxShadow: "0 1px 3px rgba(0,0,0,0.06)",
  border: "1px solid rgba(0,0,0,0.06)",
  height: "100%",
};

export const WidgetRenderer = ({ definition }: WidgetRendererProps) => {
  const isBackendWidget =
    (definition.sourceType === "backend" || definition.sourceType === "query") &&
    (definition.type === "kpi" || definition.type === "chart" || definition.type === "table");
  const { data, loading, error } = useWidgetData(definition, isBackendWidget);

  if (definition.type === "list") {
    return <ListWidget definition={definition} />;
  }

  if (!isBackendWidget) {
    return null;
  }

  if (loading) {
    return (
      <Card sx={CARD_SX}>
        <CardContent sx={{ p: 3 }}>
          <Skeleton variant="text" width="45%" />
          <Skeleton variant="text" width="70%" sx={{ fontSize: "2rem" }} />
          <Skeleton variant="rectangular" height={60} sx={{ mt: 1, borderRadius: 1 }} />
        </CardContent>
      </Card>
    );
  }

  if (error || !data) {
    return (
      <Card sx={CARD_SX}>
        <CardContent sx={{ p: 3, height: "100%", boxSizing: "border-box" }}>
          <Stack
            direction="row"
            alignItems="center"
            justifyContent="center"
            spacing={1}
            sx={{ height: "100%", minHeight: 80, color: "text.secondary" }}
          >
            <LockOutlined sx={{ fontSize: 18 }} />
            <Typography variant="body2">{error || "Données indisponibles"}</Typography>
          </Stack>
        </CardContent>
      </Card>
    );
  }

  if (definition.type === "kpi") {
    return <KpiWidget definition={definition} data={data as KpiData} />;
  }

  if (definition.type === "chart") {
    return <ChartWidget definition={definition} data={data as ChartData} />;
  }

  if (definition.type === "table") {
    return <TableWidget definition={definition} data={data as TableData} />;
  }

  return null;
};
