import React, { useState, useEffect, CSSProperties } from "react";
import { RTFParser } from "rtf-parser";

interface RTFDisplayProps {
  rtfText: string;
  style?: CSSProperties;
}

const RTFDisplay: React.FC<RTFDisplayProps> = ({ rtfText, style }) => {
  const [htmlContent, setHtmlContent] = useState<string | null>(null);

  useEffect(() => {
    const parseRTF = () => {
      let parsedContent = "";
      const parser = new RTFParser();

      parser.on("text", (text) => {
        parsedContent += text;
      });

      parser.on("error", (error) => {
        console.error("RTF parsing error:", error);
      });

      parser.write(rtfText);
      parser.end();
      setHtmlContent(parsedContent);
    };

    parseRTF();
  }, [rtfText]);

  return (
    <div style={style}>
      {htmlContent ? <div>{htmlContent}</div> : <p>Chargement du contenu...</p>}
    </div>
  );
};

export default RTFDisplay;
