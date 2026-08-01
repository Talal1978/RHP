import { KpiWidget } from "./KpiWidget";
import { ChartWidget } from "./ChartWidget";
import { TableWidget } from "./TableWidget";
import { ListWidget } from "./ListWidget";
import { MOCK_KPI_DATA, MOCK_CHART_DATA, MOCK_TABLE_DATA } from "./mocks";
import type { WidgetDefinition } from "./types";

interface WidgetRendererProps {
  definition: WidgetDefinition;
}

const getMockDataKey = (dataConfig?: WidgetDefinition["dataConfig"]) => {
  if (!dataConfig?.objectName) return null;
  return `${dataConfig.objectName}_${dataConfig.field || "default"}`;
};

export const WidgetRenderer = ({ definition }: WidgetRendererProps) => {
  if (definition.type === "kpi") {
    const key = getMockDataKey(definition.dataConfig) || "kpi_effectif";
    const data = MOCK_KPI_DATA[key] || MOCK_KPI_DATA["kpi_effectif"];
    return <KpiWidget definition={definition} data={data} />;
  }

  if (definition.type === "chart") {
    const key = `chart_${definition.dataConfig?.objectName || "effectif"}_${definition.dataConfig?.groupBy || "mois"}`;
    const data = MOCK_CHART_DATA[Object.keys(MOCK_CHART_DATA).find((k) => k.includes(definition.dataConfig?.objectName || "")) || "chart_effectif_mois"];
    return <ChartWidget definition={definition} data={data} />;
  }

  if (definition.type === "table") {
    const data =
      MOCK_TABLE_DATA[Object.keys(MOCK_TABLE_DATA).find((k) => k.includes(definition.dataConfig?.objectName || "")) || "table_three_cols"];
    return <TableWidget definition={definition} data={data} />;
  }

  if (definition.type === "list") {
    return <ListWidget definition={definition} />;
  }

  return null;
};
