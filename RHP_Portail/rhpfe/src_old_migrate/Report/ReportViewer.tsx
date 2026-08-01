import { Worker } from "@react-pdf-viewer/core";
// Import the main component
import { Viewer } from "@react-pdf-viewer/core";
import { defaultLayoutPlugin } from "@react-pdf-viewer/default-layout";
import "@react-pdf-viewer/default-layout/lib/styles/index.css";
import "@react-pdf-viewer/core/lib/styles/index.css";
import "@react-pdf-viewer/zoom/lib/styles/index.css";
import "./report_viewer.scss";
import { ObjetGenerique } from "../types";
import useMsgBox from "../hooks/useMsgBox";
import { useContext, useEffect, useState, useMemo } from "react";
import { useLocation, useParams } from "react-router-dom";
import useAxiosPost from "../hooks/useAxiosPost";
import { cntX } from "../Menu/MenuMain";
import { telecharger } from "../modules/module_filesNfolders";

export type TReport = { reportName: string; params: ObjetGenerique };

export const ReportViewer = () => {
  const [withPassword, setWithPassword] = useState("");
  const { setShowLoading } = useContext(cntX);
  const { state: report } = useLocation();
  const { pdfURL } = useParams();
  const myAxios = useAxiosPost();
  const msgBox = useMsgBox();
  const [rptUrl, setRptUrl] = useState(pdfURL);

  // Memoize the options for the default layout plugin
  const layoutPluginOptions = useMemo(() => ({
    sidebarTabs: (defaultTabs: any[]) => [],
  }), []);

  // Create the plugin instance directly (it uses hooks, so can't be wrapped in useMemo)
  const defaultLayoutPluginInstance = defaultLayoutPlugin(layoutPluginOptions);

  // Memoize pageLoadPlugin to depend on setShowLoading
  const pageLoadPlugin = useMemo(() => ({
    onCanvasLayerRender: (e: any) => {
      if (e.pageIndex === 0) {
        setTimeout(() => {
          setShowLoading(false);
        }, 5000);
      }
    },
  }), [setShowLoading]);

  // Memoize the plugins array so it remains stable unless dependencies change
  const plugins = useMemo(() => [defaultLayoutPluginInstance, pageLoadPlugin], [defaultLayoutPluginInstance, pageLoadPlugin]);

  useEffect(() => {
    setShowLoading(true);
    // Guard against report being null/undefined (e.g., direct URL access)
    if (!pdfURL && report) {
      myAxios(
        `getreport`,
        {
          report: report.reportName,
          params: report.params,
        },
        {},
        { responseType: "blob" }
      )
        .then((response) => {
          if (response.headers) {
            setWithPassword(response.headers["autres"] || "");
            if (response.headers["autres"]) {
              setShowLoading(false);
              msgBox({
                titre: "Mot de passe",
                msg:
                  "Ce document est protégé par ce mot de passe : " +
                  response.headers["autres"],
                typMsg: "info",
                typReply: "OkOnly",
                handleOk: async () => {
                  await telecharger(response.data, "Blob", "Test.pdf");
                },
              });
            } else {
              const url = window.URL.createObjectURL(response.data);
              setRptUrl(url);
            }
          } else {
            throw (response as any).error || "Erreur inconnue lors de la récupération du rapport";
          }
        })
        .catch((err) => {
          setShowLoading(false);
          msgBox({
            titre: "Génération du rapport",
            msg: "Erreur : " + err,
            typMsg: "error",
            typReply: "OkOnly",
          });
        });
    } else if (pdfURL !== rptUrl) {
      setRptUrl(pdfURL);
    }
  }, [report, pdfURL]); // myAxios and msgBox are custom hooks, usually stable, but can be added if needed

  return (
    <>
      {rptUrl && (
        <Worker workerUrl="https://unpkg.com/pdfjs-dist@3.4.120/build/pdf.worker.min.js">
          <Viewer
            key={rptUrl}
            fileUrl={rptUrl}
            plugins={plugins}
          />
        </Worker>
      )}
    </>
  );
};

export default ReportViewer;
