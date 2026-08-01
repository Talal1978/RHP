import { Box, IconButton, Stack, Tooltip, Typography } from "@mui/material";
import { Refresh, Settings, WavingHand } from "@mui/icons-material";
import { colorBase } from "../../../modules/module_general";
import type { WelcomeSectionProps } from "./SectionTypes";

const WelcomeSection = ({ firstName, onRefresh, onOpenConfig }: WelcomeSectionProps) => {
  return (
    <Box
      sx={{
        pb: 1,
        display: "flex",
        alignItems: { xs: "center", md: "flex-start" },
        justifyContent: "space-between",
        gap: 2,
      }}
    >
      <Box sx={{ flex: 1, textAlign: { xs: "center", md: "left" } }}>
        <Typography
          variant="h5"
          fontWeight="bold"
          sx={{
            color: colorBase.colorBase01,
            display: "flex",
            alignItems: "center",
            justifyContent: { xs: "center", md: "flex-start" },
            gap: 1,
          }}
        >
          Bonjour, {firstName} <WavingHand sx={{ color: "#ffc107", fontSize: 28 }} />
        </Typography>
        <Typography variant="body2" color="text.secondary" sx={{ mt: 0.5, lineHeight: 1.6 }}>
          Bon retour sur votre espace collaborateur. Voici ce qui se passe aujourd&apos;hui.
        </Typography>
      </Box>
      <Stack direction="row" spacing={2} alignItems="center" sx={{ alignSelf: { xs: "flex-start", md: "center" } }}>
        <Tooltip title="Rafraîchir">
          <IconButton onClick={onRefresh} color="primary" sx={{ bgcolor: "background.paper", boxShadow: "0 1px 3px rgba(0,0,0,0.08)" }}>
            <Refresh fontSize="small" />
          </IconButton>
        </Tooltip>
        <Tooltip title="Personnaliser">
          <IconButton onClick={onOpenConfig} color="primary" sx={{ bgcolor: "background.paper", boxShadow: "0 1px 3px rgba(0,0,0,0.08)" }}>
            <Settings fontSize="small" />
          </IconButton>
        </Tooltip>
      </Stack>
    </Box>
  );
};

export default WelcomeSection;
