import { Fragment } from "react";
import { ChevronRight, NotificationsOutlined } from "@mui/icons-material";
import { Avatar, Box, Card, CardContent, Divider, Stack, Typography } from "@mui/material";
import { colorBase } from "../../../modules/module_general";
import type { NotificationsSectionProps } from "./SectionTypes";

const NotificationsSection = ({ notifications, getColor, getIcon, onNavigate }: NotificationsSectionProps) => {
  return (
    <Box>
      <Stack direction="row" alignItems="center" spacing={1} sx={{ mb: 2, mt: 2, justifyContent: { xs: "center", sm: "flex-start" } }}>
        <NotificationsOutlined sx={{ fontSize: 22, color: colorBase.colorBase01 }} />
        <Typography variant="h6" fontWeight="bold" sx={{ color: colorBase.colorBase01, textAlign: { xs: "center", sm: "left" } }}>
          À faire & Notifications
        </Typography>
      </Stack>
      <Card
        sx={{
          borderRadius: 2,
          border: "1px solid rgba(0,0,0,0.06)",
          boxShadow: "0 1px 3px rgba(0,0,0,0.06)",
        }}
      >
        <CardContent sx={{ p: 0, "&:last-child": { pb: 0 } }}>
          {notifications.length === 0 ? (
            <Box sx={{ p: 3, textAlign: "center" }}>
              <Typography color="text.secondary">Chargement...</Typography>
            </Box>
          ) : (
            notifications.map((notif, index) => {
              const style = getColor(notif.type);
              return (
                <Fragment key={notif.id}>
                  <Box
                    onClick={() => notif.link && notif.link !== "#" && onNavigate(notif.link, { state: notif.state })}
                    sx={{
                      px: 2.5,
                      py: 1.75,
                      display: "flex",
                      flexDirection: { xs: "column", sm: "row" },
                      alignItems: "center",
                      textAlign: { xs: "center", sm: "left" },
                      gap: { xs: 1, sm: 2 },
                      cursor: "pointer",
                      transition: "background-color 0.15s",
                      "&:hover": { bgcolor: "rgba(0,0,0,0.02)" },
                    }}
                  >
                    <Avatar sx={{ width: 36, height: 36, bgcolor: style.bg, color: style.color, flexShrink: 0 }}>
                      {getIcon(notif.type)}
                    </Avatar>
                    <Box sx={{ flex: 1, minWidth: 0 }}>
                      <Typography variant="body2" fontWeight="600" color="text.primary" noWrap>
                        {notif.title}
                      </Typography>
                      <Typography variant="body2" color="text.secondary" noWrap>
                        {notif.desc}
                      </Typography>
                    </Box>
                    {notif.time && (
                      <Typography variant="caption" color="text.secondary" sx={{ flexShrink: 0 }}>
                        {notif.time}
                      </Typography>
                    )}
                    {notif.link && notif.link !== "#" && (
                      <ChevronRight sx={{ fontSize: 20, color: "text.disabled", flexShrink: 0, display: { xs: "none", sm: "block" } }} />
                    )}
                  </Box>
                  {index < notifications.length - 1 && <Divider sx={{ mx: 2.5 }} />}
                </Fragment>
              );
            })
          )}
        </CardContent>
      </Card>
    </Box>
  );
};

export default NotificationsSection;
