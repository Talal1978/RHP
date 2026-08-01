import type { ReactNode } from "react";
import type { DashboardShortcutItem } from "../dashboardShortcuts";

export interface DashboardWeather {
  temp: number;
  code: number;
  wind: number;
  humidity: number;
}

export interface DashboardNotification {
  id: number;
  title: string;
  desc: string;
  time: string;
  type: string;
  link: string;
  state?: unknown;
}

export interface DashboardSectionNavigateOptions {
  state?: unknown;
}

export type DashboardSectionNavigate = (
  path: string,
  options?: DashboardSectionNavigateOptions
) => void;

export type DashboardNotificationIconGetter = (type: string) => ReactNode;
export type DashboardNotificationColorGetter = (type: string) => {
  bg: string;
  color: string;
};

export interface WelcomeSectionProps {
  firstName: string;
  onRefresh: () => void;
  onOpenConfig: () => void;
}

export interface ProfileSectionProps {
  fullName: string;
  matricule: string;
  roleLabel: string;
  onOpenProfile: () => void;
}

export interface LeaveBalanceSectionProps {
  soldeConge: string;
  onOpenLeave: () => void;
}

export interface WeatherSectionProps {
  weather: DashboardWeather | null;
  weatherDescription: string;
}

export interface QuickActionsSectionProps {
  shortcuts: DashboardShortcutItem[];
  onNavigate: DashboardSectionNavigate;
}

export interface NotificationsSectionProps {
  notifications: DashboardNotification[];
  getColor: DashboardNotificationColorGetter;
  getIcon: DashboardNotificationIconGetter;
  onNavigate: DashboardSectionNavigate;
}

export interface NewsSectionProps {
  blogs: any[];
  formatDate: (dateStr: string) => string;
  onNavigate: DashboardSectionNavigate;
}
