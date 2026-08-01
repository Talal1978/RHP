import { lazy } from "react";
import type { DashboardSectionId } from "./dashboardSections";

export const dashboardSectionRegistry: Record<DashboardSectionId, ReturnType<typeof lazy>> = {
  welcome: lazy(() => import("./sections/WelcomeSection")),
  profile: lazy(() => import("./sections/ProfileSection")),
  leaveBalance: lazy(() => import("./sections/LeaveBalanceSection")),
  weather: lazy(() => import("./sections/WeatherSection")),
  quickActions: lazy(() => import("./sections/QuickActionsSection")),
  notifications: lazy(() => import("./sections/NotificationsSection")),
  news: lazy(() => import("./sections/NewsSection")),
};
