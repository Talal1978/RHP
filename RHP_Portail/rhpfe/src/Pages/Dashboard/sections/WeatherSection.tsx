import { ThermostatOutlined, WbSunnyOutlined, CloudOutlined } from "@mui/icons-material";
import { Box, Paper, Stack, Typography } from "@mui/material";
import { colorBase } from "../../../modules/module_general";
import type { WeatherSectionProps } from "./SectionTypes";

const WeatherSection = ({ weather, weatherDescription }: WeatherSectionProps) => {
  if (!weather) {
    return (
      <Paper sx={{ p: 3, borderRadius: 2, border: "1px solid", borderColor: "divider", boxShadow: "none", bgcolor: "background.paper" }}>
        <Typography color="text.secondary">Chargement météo...</Typography>
      </Paper>
    );
  }

  return (
    <Paper
      sx={{
        p: 3,
        borderRadius: 2,
        bgcolor: "background.paper",
        border: "1px solid rgba(0,0,0,0.06)",
        boxShadow: "0 1px 3px rgba(0,0,0,0.06)",
        height: "100%",
        display: "flex",
        flexDirection: "column",
        justifyContent: "center",
      }}
    >
      <Stack direction="row" alignItems="center" justifyContent={{ xs: "center", sm: "flex-start" }} spacing={1} sx={{ mt: 1, mb: 2 }}>
        <CloudOutlined sx={{ fontSize: 16, color: colorBase.colorBase01 }} />
        <Typography variant="caption" sx={{ textTransform: "uppercase", letterSpacing: 0.5, color: colorBase.colorBase01 }}>
          Météo
        </Typography>
      </Stack>
      <Stack direction={{ xs: "column", sm: "row" }} justifyContent={{ xs: "center", sm: "space-between" }} alignItems="center" spacing={{ xs: 2, sm: 0 }}>
        <Box sx={{ textAlign: { xs: "center", sm: "left" } }}>
          <Stack direction="row" alignItems="center" justifyContent={{ xs: "center", sm: "flex-start" }} spacing={1}>
            <WbSunnyOutlined sx={{ fontSize: 32, color: "#f57c00" }} />
            <Typography variant="h4" fontWeight="bold" color="text.primary">{weather.temp}°C</Typography>
          </Stack>
          <Typography variant="body2" fontWeight="medium" color="text.primary">{weatherDescription}</Typography>
          <Typography variant="caption" color="text.secondary">Casablanca, Maroc</Typography>
        </Box>
        <Box sx={{ textAlign: { xs: "center", sm: "right" } }}>
          <ThermostatOutlined sx={{ fontSize: 24, color: "text.secondary", mb: 0.5 }} />
          <Typography variant="caption" color="text.secondary" display="block">Humidité {weather.humidity}%</Typography>
          <Typography variant="caption" color="text.secondary" display="block">Vent {weather.wind} km/h</Typography>
        </Box>
      </Stack>
    </Paper>
  );
};

export default WeatherSection;
