import { PersonOutline, AccountCircleOutlined } from "@mui/icons-material";
import { Avatar, Button, Card, CardContent, Stack, Typography } from "@mui/material";
import { colorBase } from "../../../modules/module_general";
import type { ProfileSectionProps } from "./SectionTypes";

const ProfileSection = ({ fullName, matricule, roleLabel, onOpenProfile }: ProfileSectionProps) => {
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
      <CardContent sx={{ p: 3 }}>
        <Stack direction="row" alignItems="center" spacing={1} sx={{ mb: 2, justifyContent: { xs: "center", sm: "flex-start" } }}>
          <AccountCircleOutlined sx={{ fontSize: 16, color: colorBase.colorBase01 }} />
          <Typography variant="caption" sx={{ textTransform: "uppercase", letterSpacing: 0.5, color: colorBase.colorBase01 }}>
            Profil
          </Typography>
        </Stack>
        <Stack
          direction={{ xs: "column", sm: "row" }}
          spacing={2.5}
          alignItems={{ xs: "center", sm: "center" }}
          textAlign={{ xs: "center", sm: "left" }}
        >
          <Avatar
            sx={{
              width: 56,
              height: 56,
              bgcolor: colorBase.colorBase01,
              fontSize: 24,
              border: `2px solid ${colorBase.colorBase04}`,
            }}
          >
            {fullName?.charAt(0)}
          </Avatar>
          <Stack
            spacing={0.5}
            flex={1}
            minWidth={0}
            alignItems={{ xs: "center", sm: "flex-start" }}
            textAlign={{ xs: "center", sm: "left" }}
          >
            <Typography variant="subtitle1" fontWeight="bold" color="text.primary" noWrap>
              {fullName}
            </Typography>
            <Typography variant="body2" color="text.secondary" noWrap>
              {roleLabel} · {matricule}
            </Typography>
            <Button
              variant="text"
              size="small"
              startIcon={<PersonOutline fontSize="small" />}
              onClick={onOpenProfile}
              sx={{
                justifyContent: { xs: "center", sm: "flex-start" },
                px: 0,
                textTransform: "none",
                width: "fit-content",
              }}
            >
              Voir mon profil
            </Button>
          </Stack>
        </Stack>
      </CardContent>
    </Card>
  );
};

export default ProfileSection;
