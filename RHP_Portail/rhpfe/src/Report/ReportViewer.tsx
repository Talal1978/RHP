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
import { useContext, useEffect, useState } from "react";
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
  const defaultLayoutPluginInstance = defaultLayoutPlugin({
    sidebarTabs: (defaultTabs) => [],
  });
  useEffect(() => {
    setShowLoading(false);
    if (!pdfURL) {
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
          msgBox({
            titre: "Génération du rapport",
            msg: "Erreur : " + err,
            typMsg: "error",
            typReply: "OkOnly",
          });
        });
    } else if (pdfURL !== rptUrl) setRptUrl(pdfURL);
  }, [report, pdfURL]);
  return (
    <>
      {rptUrl && (
        <Worker workerUrl="https://unpkg.com/pdfjs-dist@3.4.120/build/pdf.worker.min.js">
          <Viewer
            fileUrl={rptUrl}
            plugins={[defaultLayoutPluginInstance]}
            onDocumentLoad={() => setShowLoading(false)}
          />
        </Worker>
      )}
    </>
  );
};

export default ReportViewer;
