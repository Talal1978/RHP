import { CalendarMonth, BeachAccess } from "@mui/icons-material";
import { Button, Card, CardContent, Box, Stack, Typography } from "@mui/material";
import { colorBase } from "../../../modules/module_general";
import type { LeaveBalanceSectionProps } from "./SectionTypes";

const LeaveBalanceSection = ({ soldeConge, onOpenLeave }: LeaveBalanceSectionProps) => {
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
        <Box sx={{ display: "flex", flexDirection: { xs: "column", sm: "row" }, justifyContent: { xs: "center", sm: "space-between" }, alignItems: "center", gap: { xs: 2, sm: 0 } }}>
          <Box>
            <Stack direction="row" alignItems="center" justifyContent={{ xs: "center", sm: "flex-start" }} spacing={1} sx={{ mt: 1 }}>
              <BeachAccess sx={{ fontSize: 16, color: colorBase.colorBase01 }} />
              <Typography variant="caption" sx={{ textTransform: "uppercase", letterSpacing: 0.5, color: colorBase.colorBase01 }}>
                Solde de congés
              </Typography>
            </Stack>
            <Typography variant="h4" fontWeight="bold" color="text.primary" sx={{ mt: 0.5 }}>
              {soldeConge} <Typography component="span" variant="body1" color="text.secondary">jours</Typography>
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
              bgcolor: `${colorBase.colorBase01}15`,
              color: colorBase.colorBase01,
            }}
          >
            <CalendarMonth sx={{ fontSize: 24 }} />
          </Box>
        </Box>
        <Button
          variant="text"
          size="small"
          onClick={onOpenLeave}
          sx={{
            mt: 2,
            px: 0,
            textTransform: "none",
            color: colorBase.colorBase01,
            mx: { xs: "auto", sm: 0 },
            display: { xs: "flex", sm: "inline-flex" },
            justifyContent: { xs: "center", sm: "flex-start" },
          }}
        >
          Poser un congé →
        </Button>
      </CardContent>
    </Card>
  );
};

export default LeaveBalanceSection;
