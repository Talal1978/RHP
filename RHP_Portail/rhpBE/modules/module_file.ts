import { Response, NextFunction, Request } from "express";
import { ecrireSql, lireSql } from "./module_sqlRW";
import path, { join } from "node:path";
import { BigInt, NVarChar } from "mssql";
import fs from "fs";
import { toSqlDateFormat } from "./module_format";
import { VGLOBALES } from "./module_initialisation";
import { findLibelle } from "./module_findLibelle";
export default class fileClass {
  static upload = async (req: Request, res: Response, next: NextFunction) => {
    if (req.file) {
      const cheminUploads = VGLOBALES.UPLOADS_PATH;
      const seq: number = Number(Date.now());
      const created_by = req.params.Matricule;
      const originalName = req.body.filename
        ? req.body.filename.replace(/ /g, "_")
        : req.file.originalname.replace(/ /g, "_");
      const finalFileName = `${seq}_${originalName}`;

      if (!fs.existsSync(path.resolve(process.cwd(), "tmp"))) {
        return res.status(209).send({
          message:
            "Dossier 'temp' inexistent :" + path.resolve(process.cwd(), "tmp"),
        });
      }
      if (!fs.existsSync(path.resolve(cheminUploads))) {
        return res.status(209).send({
          message:
            "Dossier 'upload' inexistent :" + path.resolve(cheminUploads),
        });
      }
      const tempFilePath = path.resolve(
        process.cwd(),
        "tmp",
        req.file.filename
      );

      const finalFilePath = path.resolve(cheminUploads + "/" + finalFileName);
      fs.rename(tempFilePath, finalFilePath, async (err) => {
        if (err) {
          return res
            .status(209)
            .send({ message: "Impossible de renommer le fichier." });
        } else {
          let ged = {
            fd_id: seq,
            name_ecran: req.body.name_ecran,
            typ: "F",
            value_index: req.body.valeur_index,
            index_ecran: await findLibelle(
              "index_ecran",
              "name_ecran",
              req.body.name_ecran,
              "Controle_Def_Ecran",
              ""
            ),
            id_societe: req.params.id_Societe,
            fd_alias: req.body.filename,
            file_path: finalFilePath,
            parent_dir: req.body.parent_dir,
            created_by: created_by,
            dat_crea: toSqlDateFormat(new Date(), true),
          };
          let rsl = await ecrireSql({
            tableName: "Param_GED",
            fields: ged,
            joinFields: ["fd_id"],
            excludeFields: [],
            login: created_by,
          });
          if (rsl.result) {
            return res.status(200).send({
              fd_name: finalFileName,
              alias: req.body.filename,
              fd_id: seq,
            });
          }
          return res
            .status(209)
            .send({ message: "Erreur chargement de fichier" });
        }
      });
    } else {
      return res.status(400).send({ message: "Aucun fichier à charger" });
    }
  };
  static uploadAudiBase64 = async (req: Request, res: Response) => {
    try {
      const db = req.params.db!;
      const {
        audio,
        filename,
        name_ecran,
        index_ecran,
        created_by,
        media_duration,
      } = req.body;
      const seq: number = Number(Date.now());
      const cheminUploads = VGLOBALES.UPLOADS_PATH;
      const audioBuffer = Buffer.from(audio, "base64");
      const filePath = path.resolve(cheminUploads + "/" + filename);

      await fs.promises.writeFile(filePath, audioBuffer as unknown as Uint8Array);

      let ged = {
        fd_id: seq,
        name_ecran: name_ecran,
        typ: "F",
        value_index: index_ecran,
        fd_alias: filename,
        file_path: filePath,
        media_duration,
        parent_dir: 0,
        created_by: created_by,
        dat_crea: toSqlDateFormat(new Date(), true),
      };

      let rsl = await ecrireSql({
        tableName: "Param_GED",
        fields: ged,
        joinFields: ["fd_id"],
        excludeFields: [],
        login: created_by,
      });

      if (rsl.result) {
        return res.status(200).send({
          fd_name: filename,
          alias: filename,
          fd_id: seq,
        });
      }
      return res
        .status(209)
        .send({ message: "Erreur chargement de fichier" });

    } catch (error) {
      console.error("Erreur chargement du fichier audio:", error);
      return res.status(209).send("Erreur chargement du fichier audio.");
    }
  };
  static readFile = async (req: Request, res: Response) => {
    try {
      const { fd_name } = req.body;
      const cheminUploads = VGLOBALES.UPLOADS_PATH;
      const file_name = path.resolve(cheminUploads + "\\" + fd_name);
      const buff = fs.readFileSync(file_name, "base64");
      const rsl = await lireSql(
        `select FD_id as fd_id,FD_Alias as fd_alias,isnull(Media_Duration,0) as duration from Param_GED where FD_Alias=@fd_name`,
        [{ param: "fd_name", sqlType: NVarChar, valeur: fd_name }]
      );
      if (rsl.result) {
        return res
          .status(200)
          .send({ audio: buff, duration: rsl.data[0].duration });
      } else {
        return res.status(209).send({ audio: buff, duration: 0 });
      }
    } catch (err) {
      return res.status(209).send(err);
    }
  };
  static download = async (req: Request, res: Response, next: NextFunction) => {
    let { filename } = req.query;
    filename = String(filename || "");
    filename = filename.replace(/ /g, "_");
    const cheminUploads = VGLOBALES.UPLOADS_PATH;
    let file_name = path.resolve(cheminUploads, String(filename));
    if (!fs.existsSync(file_name)) {
      return res.status(209).send({ erreur: `Le fichier n'existe pas.` });
    } else {
      return res.status(200).download(file_name);
    }
  };
  static ged_rename = async (req: Request, res: Response) => {
    let { typ, fd_name, new_name, fd_id } = req.body;
    const id_Societe = req.params.id_Societe;
    try {
      if (typ === "F") {
        const cheminUploads = VGLOBALES.UPLOADS_PATH;
        let file_oldName = path.resolve(
          cheminUploads,
          `${fd_id}_${fd_name.replace(/ /g, "_")}`
        );
        let file_newName = path.resolve(
          cheminUploads,
          `${fd_id}_${new_name.replace(/ /g, "_")}`
        );

        if (fs.existsSync(file_oldName)) {
          try {
            // Renommer le fichier
            await fs.promises.rename(file_oldName, file_newName);
          } catch (err) {
            return res.status(209).send({
              data: `Impossible de renommer le fichier.\n${fd_name} à ${new_name}`,
              err,
            });
          }
        } else {

        }

      }
      const rsl = await lireSql(
        `declare @fd_id bigint = ${fd_id}
       update Param_GED set FD_Alias=@new_name where id_Societe=${id_Societe} and FD_id=@fd_id`,
        [{ param: "new_name", sqlType: NVarChar, valeur: new_name }]
      );
      if (rsl.result) {
        return res.status(200).send({ data: "Succès" });
      } else {
        return res.status(209).send({ data: rsl.data[0] });
      }
    } catch (error: any) {
      return res.status(209).send({
        message: "Erreur interne du serveur",
        data: error.message,
      });
    }
  };
  static delete_file = async (req: Request, res: Response) => {
    let { fd_name, fd_id } = req.body;
    const id_Societe = req.params.id_Societe;
    const cheminUploads = VGLOBALES.UPLOADS_PATH;
    let file_name = path.resolve(cheminUploads + "\\" + fd_name);
    fs.unlink(file_name, async (err) => {
      if (err) {
        if (fs.existsSync(file_name))
          return res.status(209).send({ data: `Suppression impossible` });
      }
      let rsl = await lireSql(
        `delete from Param_GED where id_Societe=${id_Societe} and FD_id=@fd_id`,
        [{ param: "fd_id", sqlType: BigInt, valeur: fd_id }]
      );
      if (rsl.result) {
        return res.status(200).send({ data: `Supprimé avec succès` });
      } else {
        return res
          .status(209)
          .send({ data: `Suppression impossible de la base de donnée` });
      }
    });
  };
  static delete_folder = async (req: Request, res: Response) => {
    try {
      const id_Societe = req.params.id_Societe;
      let { fd_id } = req.body;
      const cheminUploads = VGLOBALES.UPLOADS_PATH;
      const rsl =
        await lireSql(`declare @dir bigint = ${fd_id}, @idSoc int = ${id_Societe}
;
with Tbl (fd,alias, typ, parent)
as (select FD_id,FD_Alias, Typ, Parent_Dir from Param_GED where id_Societe=@idSoc and Typ='D' and FD_id=@dir
union all
select FD_id,FD_Alias, g.Typ, Parent_Dir 
from Param_GED g inner join Tbl t on t.fd=g.Parent_Dir where id_Societe=@idSoc )
select fd,alias,typ from Tbl`);
      if (rsl.result) {
        const files = rsl.data as { fd: number; alias: string; typ: string }[];
        const deletedFiles: { fd: number; alias: string }[] = [];
        for (const file of files.filter((d) => d["typ"] === "F")) {
          const file_name = path.resolve(
            cheminUploads,
            `${file["fd"]}_${file["alias"]}`
          );
          try {
            await fs.promises.unlink(file_name);
            deletedFiles.push({ fd: file.fd, alias: file.alias });
          } catch (err) {
            if (!fs.existsSync(file_name))
              deletedFiles.push({ fd: file.fd, alias: file.alias });
          }
        }
        const failedDeletes = files.filter(
          (v) => v.typ === "F" && !deletedFiles.find((f) => f.fd === v.fd)
        );
        if (
          failedDeletes.length ===
          files.filter((d) => d["typ"] === "F").length &&
          failedDeletes.length > 0
        ) {
          return res.status(209).send({ data: `Suppression impossible` });
        } else if (deletedFiles.length > 0 && failedDeletes.length > 0) {
          await lireSql(
            `delete from Param_Ged where id_Societe=${id_Societe} and FD_id in (${deletedFiles
              .map((f) => f.fd)
              .join(", ")})`
          );
          return res.status(209).send({
            data: `Certains fichiers non supprimés :\n ${failedDeletes
              .map((obj) => obj.alias)
              .join(", ")}`,
          });
        } else {
          await lireSql(
            `delete from Param_Ged where id_Societe=${id_Societe} and FD_id in (${files
              .map((f) => f.fd)
              .join(", ")})`
          );
          return res.status(200).send({ data: `Supprimé avec succès` });
        }
      } else {
        return res
          .status(209)
          .send({ data: `Erreur lors de la lecture de la base de données` });
      }
    } catch (error) {
      console.error("Erreur lors de la suppression du dossier : ", error);
      return res.status(500).send({ data: `Erreur interne du serveur` });
    }
  };

  static newFolder = async (req: Request, res: Response) => {
    const fd_id = Number(Date.now()) * 1000 + Math.floor(Math.random() * 1000);
    const { Matricule } = req.params;
    let nbFdr = await findLibelle(
      "count(*)",
      "FD_Alias like 'Nouveau dossier%' and name_ecran",
      req.body.name_ecran,
      "Param_GED",
      req.params.id_Societe
    );
    nbFdr = nbFdr ? ` (${String(Number(nbFdr) + 1)})` : "";
    nbFdr = `Nouveau dossier${nbFdr}`;
    let ged = {
      fd_id,
      name_ecran: req.body.name_ecran,
      typ: "D",
      value_index: req.body.valeur_index,
      index_ecran: await findLibelle(
        "index_ecran",
        "name_ecran",
        req.body.name_ecran,
        "Controle_Def_Ecran",
        ""
      ),
      id_societe: req.params.id_Societe,
      fd_alias: nbFdr,
      file_path: "",
      parent_dir: req.body.parent_dir,
      created_by: req.params.Matricule,
      dat_crea: toSqlDateFormat(new Date(), true),
    };
    let rsl = await ecrireSql({
      tableName: "Param_GED",
      fields: ged,
      joinFields: ["fd_id"],
      excludeFields: [],
      login: Matricule,
    });
    if (rsl.result) {
      return res.status(200).send({
        result: true,
        fd_id,
      });
    }
    return res
      .status(209)
      .send({ result: false, message: "Erreur création de dossier." });
  };
}
