import { ChevronRight, Apps } from "@mui/icons-material";
import { Box, ButtonBase, Divider, Paper, Stack, Typography } from "@mui/material";
import { GetMenuIcon } from "../../../Menu/MenuIcons";
import { colorBase } from "../../../modules/module_general";
import type { QuickActionsSectionProps } from "./SectionTypes";

const QuickActionsSection = ({ shortcuts, onNavigate }: QuickActionsSectionProps) => {
  return (
    <Box sx={{ height: "100%", display: "flex", flexDirection: "column" }}>
      <Stack direction="row" alignItems="center" spacing={1} sx={{ mb: 2, mt: 2, justifyContent: { xs: "center", sm: "flex-start" } }}>
        <Apps sx={{ fontSize: 22, color: colorBase.colorBase01 }} />
        <Typography variant="h6" fontWeight="bold" sx={{ color: colorBase.colorBase01, textAlign: { xs: "center", sm: "left" } }}>
          Accès Rapide
        </Typography>
      </Stack>
      <Paper
        sx={{
          flex: 1,
          borderRadius: 2,
          border: "1px solid rgba(0,0,0,0.06)",
          boxShadow: "0 1px 3px rgba(0,0,0,0.06)",
          overflow: "hidden",
          bgcolor: "background.paper",
        }}
      >
        {shortcuts.map((item, index) => (
          <Box key={`${item.name_ecran}-${index}`}>
            <ButtonBase
              onClick={() => onNavigate(item.link || item.name_ecran)}
              sx={{
                width: "100%",
                px: 2.5,
                py: 1.75,
                display: "flex",
                justifyContent: { xs: "center", sm: "flex-start" },
                alignItems: "center",
                gap: 2,
                textAlign: { xs: "center", sm: "left" },
                transition: "background-color 0.15s",
                "&:hover": { bgcolor: "rgba(0,0,0,0.02)" },
              }}
            >
              <Box
                sx={{
                  width: 36,
                  height: 36,
                  borderRadius: 1.5,
                  display: "flex",
                  alignItems: "center",
                  justifyContent: "center",
                  bgcolor: `${colorBase.colorBase01}12`,
                  color: colorBase.colorBase01,
                  flexShrink: 0,
                }}
              >
                <GetMenuIcon name_ecran={item.img || item.name_ecran || ""} sx={{ fontSize: 22 }} />
              </Box>
              <Typography variant="body2" fontWeight="600" color="text.primary" noWrap>
                {item.label}
              </Typography>
              <ChevronRight sx={{ fontSize: 20, color: "text.disabled", flexShrink: 0, display: { xs: "none", sm: "block" } }} />
            </ButtonBase>
            {index < shortcuts.length - 1 && <Divider sx={{ mx: 2.5 }} />}
          </Box>
        ))}
      </Paper>
    </Box>
  );
};

export default QuickActionsSection;
