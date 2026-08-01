import { Card, CardContent, Box, Typography, Stack } from "@mui/material";
import { TrendingUp, TrendingDown } from "@mui/icons-material";
import { DynamicIcon } from "./DynamicIcon";
import type { WidgetDefinition, KpiData } from "./types";

interface KpiWidgetProps {
  definition: WidgetDefinition;
  data: KpiData;
}

export const KpiWidget = ({ definition, data }: KpiWidgetProps) => {
  const trendValue = typeof data.trend === "number" ? data.trend : 0;
  const isPositive = trendValue >= 0;

  return (
    <Card
      sx={{
        borderRadius: 2,
        boxShadow: "0 1px 3px rgba(0,0,0,0.06)",
        border: "1px solid rgba(0,0,0,0.06)",
        height: "100%",
        display: "flex",
        flexDirection: "column",
        justifyContent: "center",
      }}
    >
      <CardContent sx={{ p: 3, textAlign: { xs: "center", sm: "left" } }}>
        <Stack
          direction={{ xs: "column", sm: "row" }}
          justifyContent={{ xs: "center", sm: "space-between" }}
          alignItems="center"
          spacing={{ xs: 2, sm: 0 }}
        >
          <Box>
            <Stack
              direction="row"
              alignItems="center"
              justifyContent={{ xs: "center", sm: "flex-start" }}
              spacing={1}
              sx={{ mt: 1 }}
            >
              <DynamicIcon name={definition.icon} sx={{ fontSize: 16, color: definition.color }} />
              <Typography
                variant="caption"
                sx={{
                  textTransform: "uppercase",
                  letterSpacing: 0.5,
                  color: definition.color,
                }}
              >
                {definition.title}
              </Typography>
            </Stack>
            <Typography variant="h4" fontWeight="bold" color="text.primary" sx={{ mt: 0.5 }}>
              {data.value}{" "}
              <Typography component="span" variant="body1" color="text.secondary">
                {data.label}
              </Typography>
            </Typography>
          </Box>
          <Box
            sx={{
              width: 44,
              height: 44,
              borderRadius: 2,
              display: "flex",
              alignItems: "center",
              justifyContent: "center",
              bgcolor: `${definition.color}15`,
              color: definition.color,
            }}
          >
            <DynamicIcon name={definition.icon} sx={{ fontSize: 24 }} />
          </Box>
        </Stack>
        {data.trend !== undefined && (
          <Stack
            direction="row"
            alignItems="center"
            justifyContent={{ xs: "center", sm: "flex-start" }}
            spacing={0.5}
            sx={{ mt: 2 }}
          >
            {isPositive ? (
              <TrendingUp sx={{ fontSize: 16, color: "success.main" }} />
            ) : (
              <TrendingDown sx={{ fontSize: 16, color: "error.main" }} />
            )}
            <Typography variant="caption" color={isPositive ? "success.main" : "error.main"}>
              {isPositive ? "+" : ""}
              {trendValue}% vs période précédente
            </Typography>
          </Stack>
        )}
      </CardContent>
    </Card>
  );
};
