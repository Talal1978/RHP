import React, {
  Fragment,
  useCallback,
  useContext,
  useEffect,
  useRef,
  useState,
} from "react";
import {
  Add,
  ArrowBackOutlined,
  CreateNewFolderOutlined,
  DeleteOutline,
  DriveFileRenameOutlineOutlined,
  NoteAddOutlined,
} from "@mui/icons-material";
import { TGed } from "../../types";
import "./ged.scss";
import { cntX } from "../../Menu/MenuMain";
import {
  Avatar,
  Divider,
  IconButton,
  List,
  ListItem,
  ListItemAvatar,
  ListItemText,
  TextField,
} from "@mui/material";
import useAxiosGet from "../../hooks/useAxiosGet";
import useMsgBox from "../../hooks/useMsgBox";
import GroupBox from "../../components/GroupBox/GroupBox";
import { telecharger } from "../../modules/module_filesNfolders";
import useAlert from "../../hooks/useAlert";
import useAxiosPost from "../../hooks/useAxiosPost";
import { formatDateFR } from "../../modules/module_formats";
import { colorBase } from "../../modules/module_general";

type TDoc = {
  FD_id?: number;
  Name_Ecran?: string;
  Typ?: string;
  Index_Ecran?: string;
  Value_Index?: string;
  FD_Alias?: string;
  Parent_Dir?: number;
  Ecriture?: string;
  Created_By?: string;
  Nom_Created_By?: string;
  Date_Modif?: Date;
  Racine?: string;
  editMode: boolean;
  newName: string;
};

const Ged = (props: TGed) => {
  const currentDir = useRef<number[]>([]);
  const inputFileDialog = useRef<HTMLInputElement>(null);
  const alert = useAlert();
  const msgbox = useMsgBox();
  const myAxios = useAxiosGet();
  const myAxiosPost = useAxiosPost();
  const { setShowGED, setShowLoading } = useContext(cntX);
  const [allDocs, setAllDocs] = useState<TDoc[]>([]);
  const [selectedDocs, setSelectedDocs] = useState<TDoc[]>([]);
  const getCurrentDir = (): number =>
    currentDir && currentDir?.current && currentDir.current.length > 0
      ? currentDir.current[currentDir.current.length - 1]
      : 0;
  const fermer = useCallback(
    (e: React.MouseEvent<HTMLDivElement>) => {
      setShowGED(false);
    },
    [props.valeur_index, props.name_ecran]
  );
  const stopPropagation = useCallback(
    (e: React.MouseEvent) => {
      e.stopPropagation();
    },
    [props.valeur_index, props.name_ecran]
  );
  const handleDoc = useCallback(
    (typ: string, fdId: number, fileAlias: string) => {
      if (typ === "D") {
        get_ged_docs(fdId);
      } else if (typ === "F") {
        downloadFile(fdId, fileAlias);
      }
    },
    []
  );
  const goBack = useCallback(() => {
    if (currentDir.current.length > 1) currentDir.current.pop();
    const prevDir = getCurrentDir();
    get_ged_docs(prevDir);
  }, [currentDir.current.length]);
  const openFileDialog = async (e: any) => {
    if (e.target.files && e.target.files.length > 0) {
      setShowLoading(true);
      const fichier = e.target.files[0];
      const currentD = getCurrentDir();
      if (!fichier) {
        setShowLoading(false);
        return;
      }
      let formData = new FormData();
      formData.append("file", fichier);
      formData.append("filename", fichier.name);
      formData.append("name_ecran", props.name_ecran);
      formData.append("valeur_index", props.valeur_index);
      formData.append("parent_dir", String(currentD));
      myAxiosPost("uploadfile", formData)
        .then((data: any) => {
          if (data?.status === 200) {
            get_ged_docs(currentD);
          } else if (data?.status === 209) {
            alert({
              msg: data.data[0].Erreur,
              timeOut: 3000,
              titre: "Erreur",
              typMsg: "error",
            });
          }
        })
        .finally(() => setShowLoading(false));
    }
  };

  const downloadFile = useCallback(
    async (fileid: number, filealias: string) => {
      setShowLoading(true);
      try {
        const response = await myAxios({
          apiStr: "download",
          bdy: { filename: `${fileid}_${filealias}` },
          responseType: "blob",
        });
        if (response.status === 209) {
          alert({
            msg: `${response.data.erreur} :
                    ${filealias}
                    `,
            timeOut: 2000,
            titre: "Erreur",
            typMsg: "error",
          });
        } else {
          await telecharger(response.data, "Blob", filealias);
        }
      } catch {
        alert({
          msg: `Erreur de téléchargement du document :
                ${filealias}
                `,
          timeOut: 2000,
          titre: "Erreur",
          typMsg: "error",
        });
      } finally {
        setShowLoading(false);
      }
    },
    []
  );
  const newFolder = useCallback(() => {
    myAxiosPost("newFolder", {
      name_ecran: props.name_ecran,
      valeur_index: props.valeur_index,
      parent_dir: getCurrentDir(),
    }).then((dt) => {
      if (dt.data.result) {
        get_ged_docs(getCurrentDir());
      } else {
        alert({
          msg: dt.data.message,
          titre: "Erreur",
          timeOut: 3000,
          typMsg: "error",
        });
      }
    });
  }, []);
  const get_ged_docs = useCallback(
    (parent_dir: number) => {
      if (!currentDir.current.includes(parent_dir))
        currentDir.current.push(parent_dir);
      myAxios({
        apiStr: "get_ged_docs",
        bdy: {
          name_ecran: props.name_ecran,
          valeur_index: props.valeur_index,
        },
      })
        .then((dt) => {
          if (dt.data.result) {
            setAllDocs(dt.data.data);
            setSelectedDocs(
              dt.data.data.filter((dc: TDoc) =>
                dc.Racine?.endsWith(`;${String(parent_dir)};`)
              )
            );
          } else {
            setAllDocs([]);
            setSelectedDocs([]);
          }
        })
        .catch((err) => {

          setAllDocs([]);
          setSelectedDocs([]);
        });
    },
    [props.valeur_index, props.name_ecran]
  );
  useEffect(() => {
    get_ged_docs(0);
  }, [props.valeur_index, props.name_ecran]);

  const rename = useCallback(
    (doc: TDoc, i: number) => {
      const newDocs = [...selectedDocs];
      if (
        newDocs.filter(
          (dc) =>
            dc.FD_Alias!.toLowerCase().trim() ===
              String(doc.newName).toLowerCase().trim() && dc.FD_id !== doc.FD_id
        ).length > 0
      ) {
        alert({
          titre: "Erreur",
          msg: "nom déjà existant",
          typMsg: "error",
        });
        newDocs[i] = {
          ...newDocs[i],
          newName: doc.FD_Alias!,
        };
        setSelectedDocs(newDocs);
      } else {
        myAxiosPost("ged_rename", {
          typ: doc.Typ,
          fd_name: doc.FD_Alias,
          new_name: doc.newName,
          fd_id: doc.FD_id,
        })
          .then((dt) => {
            if (dt.status === 200) {
              newDocs[i] = {
                ...newDocs[i],
                FD_Alias: doc.newName!,
                editMode: false,
              };
              setSelectedDocs(newDocs);
            } else {
              alert({
                msg: dt.data.data,
                titre: "Erreur",
                typMsg: "error",
              });
            }
            newDocs[i] = {
              ...newDocs[i],
              newName: doc.FD_Alias!,
              editMode: false,
            };
            setSelectedDocs(newDocs);
          })
          .catch((err) => {

            newDocs[i] = {
              ...newDocs[i],
              newName: doc.FD_Alias!,
              editMode: false,
            };
            setSelectedDocs(newDocs);
          });
      }
    },
    [selectedDocs]
  );
  return (
    <div className="ged" onClick={fermer}>
      <GroupBox
        label="Pièces jointes"
        showTitre={true}
        showBorders={false}
        className="grp"
      >
        <div className="listeHeader" onClick={stopPropagation}>
          <div className="ajouterPJ" onClick={goBack}>
            <ArrowBackOutlined />
          </div>
          {(getCurrentDir() === 0 ||
            allDocs.find((dc) => dc.FD_id === getCurrentDir())?.Ecriture) && (
            <>
              <div
                className="ajouterPJ"
                onClick={() => inputFileDialog?.current?.click()}
              >
                <NoteAddOutlined />
                <input
                  type="file"
                  onChange={openFileDialog}
                  ref={inputFileDialog}
                  style={{ display: "none" }}
                />
              </div>
              <div className="ajouterPJ" onClick={newFolder}>
                <CreateNewFolderOutlined />
              </div>
            </>
          )}
        </div>
        <List className="listeDoc">
          {selectedDocs.map((doc: TDoc, i) => {
            return (
              <Fragment key={`f${i}`}>
                {i > 0 && (
                  <Divider
                    variant="middle"
                    key={`d${i}`}
                    sx={{ width: "95%" }}
                  />
                )}
                <ListItem
                  onClick={stopPropagation}
                  key={i}
                  secondaryAction={
                    doc.Ecriture && (
                      <>
                        <IconButton
                          edge="end"
                          aria-label="rename"
                          onClick={() => {
                            setSelectedDocs((prv: TDoc[]) => {
                              const newDocs = [...prv];
                              newDocs[i] = { ...newDocs[i], editMode: true };
                              return newDocs;
                            });
                          }}
                        >
                          <DriveFileRenameOutlineOutlined
                            sx={{
                              color: colorBase.colorBase01,
                              fontSize: "1.3em",
                              cursor: "pointer",
                            }}
                          />
                        </IconButton>
                        <IconButton
                          edge="end"
                          aria-label="delete"
                          onClick={async () => {
                            if (
                              (await msgbox({
                                msg: `Etes-vous sûr de vouloir supprimer cet élément : \n${doc.FD_Alias}?`,
                                titre: "Suppression",
                                typMsg: "stop",
                                typReply: "OKCancel",
                              })) === "Cancel"
                            )
                              return;
                            setShowLoading(true);
                            myAxiosPost(
                              doc.Typ === "F" ? "delete_file" : "delete_folder",
                              { fd_name: doc.FD_Alias, fd_id: doc.FD_id }
                            )
                              .then((dt) => {
                                if (dt.status === 200) {
                                  get_ged_docs(getCurrentDir());
                                } else {
                                  alert({
                                    titre: "Erreur de suppression",
                                    msg: dt.data.data,
                                    typMsg: "error",
                                  });
                                }
                              })
                              .catch((err) => {
                                alert({
                                  titre: "Erreur de suppression",
                                  msg: err,
                                  typMsg: "error",
                                });
                              })
                              .finally(() => setShowLoading(false));
                          }}
                        >
                          <DeleteOutline
                            sx={{
                              color: "red",
                              fontSize: "1.3em",
                              cursor: "pointer",
                            }}
                          />
                        </IconButton>
                      </>
                    )
                  }
                >
                  <ListItemAvatar>
                    <Avatar>
                      <img
                        src={`${process.env.PUBLIC_URL}/${getImg(
                          doc.FD_Alias || ""
                        )}`}
                        alt="img"
                        width="20px"
                      />
                    </Avatar>
                  </ListItemAvatar>
                  {selectedDocs[i].editMode ? (
                    <TextField
                      value={doc.newName}
                      onChange={(e) =>
                        setSelectedDocs((prv: TDoc[]) => {
                          const newDocs = [...prv];
                          newDocs[i] = {
                            ...newDocs[i],
                            newName: e.target.value,
                          };
                          return newDocs;
                        })
                      }
                      onBlur={() => rename(doc, i)}
                      onKeyUp={(e: React.KeyboardEvent) => {
                        if (e.key === "Enter") rename(doc, i);
                      }}
                      autoFocus
                    />
                  ) : (
                    <ListItemText
                      sx={{
                        cursor: "pointer",
                        color: "rgb(46,46,46)",
                        "&:hover": {
                          textDecoration: "underline",
                        },
                      }}
                      primary={doc.FD_Alias}
                      secondary={
                        <span className="detailDoc">{`${
                          doc.Nom_Created_By
                        } -  ${formatDateFR(doc.Date_Modif, true)}`}</span>
                      }
                      onClick={() =>
                        handleDoc(doc.Typ!, doc.FD_id!, doc.FD_Alias!)
                      }
                    />
                  )}
                </ListItem>
              </Fragment>
            );
          })}
        </List>
      </GroupBox>
    </div>
  );
};
const getImg = (fd_alias: string) => {
  let ln = fd_alias.split(".");
  if (ln.length === 0) return "ged_file.png";
  if (ln.length === 1) return "ged_fdr.png";
  let extStr = ln[ln.length - 1];
  switch (extStr.toLowerCase()) {
    case "xlsx":
    case "xls":
    case "xlsm":
      return "ged_xlsx.png";
    case "docx":
    case "doc":
      return "ged_docx.png";
    case "pdf":
      return "ged_pdf.png";
    case "pptx":
    case "ppt":
      return "ged_pptx.png";
    case "jpg":
    case "jpeg":
    case "png":
    case "bmp":
    case "tiff":
    case "gif":
      return "ged_img.png";
    case "mpeg":
    case "avi":
    case "mp4":
    case "mov":
    case "wmv":
    case "flv":
    case "swf":
      return "ged_video.png";
    case "mp3":
    case "m4a":
    case "wav":
    case "aac":
      return "ged_audio.png";
    default:
      return "ged_file.png";
  }
};
export default Ged;
