import {
  Card,
  CardContent,
  Stack,
  Typography,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
} from "@mui/material";
import { DynamicIcon } from "./DynamicIcon";
import type { WidgetDefinition, TableData } from "./types";

interface TableWidgetProps {
  definition: WidgetDefinition;
  data: TableData;
}

export const TableWidget = ({ definition, data }: TableWidgetProps) => {
  return (
    <Card
      sx={{
        borderRadius: 2,
        boxShadow: "0 1px 3px rgba(0,0,0,0.06)",
        border: "1px solid rgba(0,0,0,0.06)",
        height: "100%",
      }}
    >
      <CardContent sx={{ p: 3 }}>
        <Stack
          direction="row"
          alignItems="center"
          spacing={1}
          sx={{ mb: 2, justifyContent: { xs: "center", sm: "flex-start" } }}
        >
          <DynamicIcon name={definition.icon} sx={{ fontSize: 20, color: definition.color }} />
          <Typography variant="h6" fontWeight="bold" sx={{ color: definition.color }}>
            {definition.title}
          </Typography>
        </Stack>
        <TableContainer component={Paper} variant="outlined" sx={{ borderRadius: 1 }}>
          <Table size="small">
            <TableHead>
              <TableRow sx={{ bgcolor: `${definition.color}10` }}>
                {data.columns.map((col) => (
                  <TableCell key={col.field} sx={{ fontWeight: "bold", color: definition.color }}>
                    {col.header}
                  </TableCell>
                ))}
              </TableRow>
            </TableHead>
            <TableBody>
              {data.rows.map((row, rowIndex) => (
                <TableRow key={rowIndex} hover>
                  {data.columns.map((col) => (
                    <TableCell key={col.field}>{String(row[col.field] ?? "-")}</TableCell>
                  ))}
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </CardContent>
    </Card>
  );
};
