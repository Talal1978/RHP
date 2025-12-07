import * as nodemailer from "nodemailer";
import { Response, Request } from "express";
import { VGLOBALES, loadSmtpConfig } from "./module_initialisation";

export interface mailOptionsFormat {
  from: string;
  to: string;
  subject: string;
  text: string;
  html: string;
  headers: {};
}
export const envoiMail = async (mailOptions: mailOptionsFormat) => {
  await loadSmtpConfig();
  console.log("DEBUG: VGLOBALES SMTP:", {
    HOST: VGLOBALES.SMTP_HOST,
    PORT: VGLOBALES.SMTP_PORT,
    SECURE: VGLOBALES.SMTP_PORT === 465,
    USER: VGLOBALES.SMTP_USERNAME,
  });
  const transporter = nodemailer.createTransport({
    host: VGLOBALES.SMTP_HOST,
    port: VGLOBALES.SMTP_PORT,
    secure: VGLOBALES.SMTP_PORT === 465, // true for 465, false for other ports
    auth: {
      user: VGLOBALES.SMTP_USERNAME,
      pass: VGLOBALES.SMTP_PASSWORD,
    },
  });
  let info = await transporter.sendMail(mailOptions);
  return info;
};

export const sendMail_api = async (req: Request, res: Response) => {
  const mailOptions = <mailOptionsFormat>req.body.mailOptions;
  mailOptions.headers = { "x-cloudmta-class": "standard" };
  let info = await envoiMail(mailOptions);
  return res.send({ Result: info.accepted });
};
