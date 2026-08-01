import * as MuiIcons from "@mui/icons-material";
import type { SvgIconComponent } from "@mui/icons-material";

interface DynamicIconProps {
  name: string;
  sx?: React.CSSProperties;
  className?: string;
}

export const DynamicIcon = ({ name, sx, className }: DynamicIconProps) => {
  const Icon = (MuiIcons as Record<string, SvgIconComponent>)[name];
  if (!Icon) return null;
  return <Icon sx={sx} className={className} />;
};
