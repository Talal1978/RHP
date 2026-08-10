import { Card, CardContent, Stack, Typography } from "@mui/material";
import { BarChart, LineChart, PieChart } from "@mui/x-charts";
import { DynamicIcon } from "./DynamicIcon";
import type { WidgetDefinition, ChartData } from "./types";

interface ChartWidgetProps {
  definition: WidgetDefinition;
  data: ChartData;
}

export const ChartWidget = ({ definition, data }: ChartWidgetProps) => {
  const colors = [definition.color, "#1976d2", "#2e7d32", "#f57c00", "#8e24aa", "#d32f2f"];

  // Axe X : des étiquettes nombreuses ou longues se chevauchent horizontalement
  // et deviennent illisibles => bascule en vertical avec marge adaptée.
  const labels = data.labels.map((l) => String(l ?? ""));
  const maxLabelLen = labels.reduce((max, l) => Math.max(max, l.length), 0);
  const rotateXLabels = labels.length > 12 || (labels.length >= 5 && maxLabelLen >= 8);
  const xTickLabelStyle = rotateXLabels ? { angle: -90, textAnchor: "end" as const, fontSize: 11 } : undefined;
  const bottomMargin = rotateXLabels ? Math.min(180, 14 + maxLabelLen * 6.5) : 30;
  // Hauteur augmentée d'autant que la marge basse pour préserver la zone de tracé.
  const chartHeight = 250 + Math.max(0, bottomMargin - 30);

  // Axe Y : si toutes les valeurs sont identiques, le domaine est dégénéré et
  // les graduations se superposent ("000000") => on force une échelle lisible.
  const values = data.series.flatMap((s) => s.data).filter((v) => typeof v === "number" && Number.isFinite(v));
  const maxValue = values.length ? Math.max(...values) : 0;
  const minValue = values.length ? Math.min(...values) : 0;
  const yMin = Math.min(0, minValue);
  const yAxis = [
    maxValue === minValue
      ? { min: yMin, max: maxValue > yMin ? Math.ceil(maxValue * 1.2) : yMin + 1 }
      : { min: yMin },
  ];

  const renderChart = () => {
    switch (definition.chartType) {
      case "bar":
        return (
          <BarChart
            xAxis={[{ scaleType: "band", data: labels, tickLabelStyle: xTickLabelStyle }]}
            yAxis={yAxis}
            series={data.series.map((s, index) => ({
              data: s.data,
              label: s.label,
              color: colors[index % colors.length],
            }))}
            height={chartHeight}
            margin={{ left: 50, right: 20, top: 20, bottom: bottomMargin }}
          />
        );
      case "line":
        return (
          <LineChart
            xAxis={[{ scaleType: "point", data: labels, tickLabelStyle: xTickLabelStyle }]}
            yAxis={yAxis}
            series={data.series.map((s, index) => ({
              data: s.data,
              label: s.label,
              color: colors[index % colors.length],
              curve: "linear",
            }))}
            height={chartHeight}
            margin={{ left: 50, right: 20, top: 20, bottom: bottomMargin }}
          />
        );
      case "area":
        return (
          <LineChart
            xAxis={[{ scaleType: "point", data: labels, tickLabelStyle: xTickLabelStyle }]}
            yAxis={yAxis}
            series={data.series.map((s, index) => ({
              data: s.data,
              label: s.label,
              color: colors[index % colors.length],
              area: true,
              showMark: false,
            }))}
            height={chartHeight}
            margin={{ left: 50, right: 20, top: 20, bottom: bottomMargin }}
          />
        );
      case "pie":
        return (
          <PieChart
            series={[
              {
                data: data.labels.map((label, index) => ({
                  id: index,
                  value: data.series[0]?.data[index] ?? 0,
                  label,
                })),
              },
            ]}
            height={250}
            margin={{ left: 20, right: 20, top: 20, bottom: 80 }}
            slotProps={{
              legend: { direction: "row", position: { vertical: "bottom", horizontal: "middle" } },
            }}
          />
        );
      default:
        return null;
    }
  };

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
        {renderChart()}
      </CardContent>
    </Card>
  );
};
