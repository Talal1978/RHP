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

  const renderChart = () => {
    switch (definition.chartType) {
      case "bar":
        return (
          <BarChart
            xAxis={[{ scaleType: "band", data: data.labels }]}
            series={data.series.map((s, index) => ({
              data: s.data,
              label: s.label,
              color: colors[index % colors.length],
            }))}
            height={250}
            margin={{ left: 50, right: 20, top: 20, bottom: 30 }}
          />
        );
      case "line":
        return (
          <LineChart
            xAxis={[{ scaleType: "point", data: data.labels }]}
            series={data.series.map((s, index) => ({
              data: s.data,
              label: s.label,
              color: colors[index % colors.length],
              curve: "linear",
            }))}
            height={250}
            margin={{ left: 50, right: 20, top: 20, bottom: 30 }}
          />
        );
      case "area":
        return (
          <LineChart
            xAxis={[{ scaleType: "point", data: data.labels }]}
            series={data.series.map((s, index) => ({
              data: s.data,
              label: s.label,
              color: colors[index % colors.length],
              area: true,
              showMark: false,
            }))}
            height={250}
            margin={{ left: 50, right: 20, top: 20, bottom: 30 }}
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
