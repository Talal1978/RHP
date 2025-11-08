import { Box, Chip, Divider } from "@mui/material";
import "./groupbox.scss";
import React, { Children } from "react";
import { relative } from "path";
const GroupBox = ({
  sx,
  display,
  id,
  label,
  children,
  showTitre = true,
  showBorders = false,
  className = "",
  onClick = (e: any) => {},
}: {
  sx?: any;
  id?: string;
  label: string;
  display?: undefined | "none";
  children?: React.ReactNode;
  showTitre?: boolean;
  showBorders?: boolean;
  className?: string;
  onClick?: (e: any) => void;
}) => {
  return (
    <Box
      id={id}
      display={display}
      minHeight={100}
      mb={5}
      sx={{
        ...sx,
        marginInline: { xs: 0, sm: 0, md: 0, lg: "2em", xl: "3em" },
        // paddingInline: { xs: 0, sm: 0, md: 0, lg: "2em", xl: "3em" },
      }}
      className={`groupbox ${className}`}
      onClick={onClick}
    >
      {showTitre && !showBorders && (
        <Divider sx={{ mb: 2 }}>
          <Chip label={label} className="chip" />
        </Divider>
      )}

      <div className={`grpDiv ${showBorders ? "withBorders" : ""}`}>
        {showBorders && <Chip label={label} className="chip" />}
        {children}
      </div>
    </Box>
  );
};

export default GroupBox;
