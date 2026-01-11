import "./mainmenu.scss";
import {
  Accordion,
  AccordionDetails,
  AccordionSummary,
  Collapse,
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Typography,
} from "@mui/material";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import { controleMenus } from "../modules/module_menus";
import {
  ExpandLess,
  ExpandMore,
} from "@mui/icons-material";
import { Fragment, useContext, useEffect, useState } from "react";
import { cntX } from "./MenuMain";
import { useNavigate } from "react-router-dom";
import { GetMenuIcon } from "./MenuIcons";

const MenuSideBarContent = () => {
  const navigate = useNavigate();
  const { isOpen, setIsOpen } = useContext(cntX);
  const [showDetail, setShowDetail] = useState(false);
  useEffect(() => {
    setTimeout(() => setShowDetail(isOpen), isOpen ? 50 : 0);
  }, [isOpen]);
  const [currentMnu, setCurrentMnu] = useState("orga");
  const handleOpenEcran = (nameEcran: string, textEcran: string) => {
    setIsOpen(false);
    navigate(`/myspace/${nameEcran}/${textEcran}`);
  };
  const mnus = controleMenus
    .filter((mnu) => mnu.parent === "")
    .sort((a, b) => a.rang - b.rang);
  return (
    <List>
      {mnus.map((mnu, indx) => {
        const childs = controleMenus.filter(
          (chd) => chd.parent === mnu.name_ecran
        );
        return (
          <Fragment key={indx * 590 + mnu.name_ecran}>
            <ListItem
              disablePadding
              key={mnu.name_ecran + indx}
              className={
                !isOpen && currentMnu === mnu.name_ecran ? "selected" : ""
              }
              onClick={() => {
                setCurrentMnu((prv: string) =>
                  isOpen && prv === mnu.name_ecran ? "" : mnu.name_ecran
                );
                if (childs.length > 0) {
                  setIsOpen(true);
                } else {
                  handleOpenEcran(mnu.name_ecran, mnu.text_ecran);
                }
              }}
            >
              <ListItemButton>
                <ListItemIcon>
                  <GetMenuIcon name_ecran={mnu.img || ""} />
                </ListItemIcon>
                {isOpen && (
                  <ListItemText
                    primary={mnu.text_ecran}
                    sx={{ fontSize: { xs: "0.7em", sm: "0.8em", md: "1em" } }}
                  />
                )}
                {childs.length > 0 &&
                  (isOpen && currentMnu === mnu.name_ecran ? (
                    <ExpandLess />
                  ) : (
                    <ExpandMore />
                  ))}
              </ListItemButton>
            </ListItem>
            {
              <Collapse
                in={showDetail && currentMnu === mnu.name_ecran}
                timeout={"auto"}
                unmountOnExit
              >
                <List component="div" disablePadding>
                  {childs.map((ecr, indx) => (
                    <ListItemButton
                      key={ecr.name_ecran + indx}
                      // Removed hardcoded background color
                      sx={{
                        pl: 7,
                        backgroundColor: "var(--bg-input)", // or transparent/"background.paper"
                        color: "var(--title-color)",
                        '&:hover': {
                          backgroundColor: "var(--color-base-03)", // Highlight color
                        }
                      }}
                      onClick={() =>
                        handleOpenEcran(ecr.name_ecran, ecr.text_ecran)
                      }
                    >
                      <ListItemIcon>
                        <GetMenuIcon
                          name_ecran={ecr.img || ""}
                          sx={{ color: "inherit" }}
                        />
                      </ListItemIcon>
                      <ListItemText
                        primary={ecr.text_ecran}
                        className="subMenuItems"
                        sx={{
                          fontSize: { xs: "0.7em", sm: "0.8em", md: "1em" },
                        }}
                      />
                    </ListItemButton>
                  ))}
                </List>
              </Collapse>
            }
          </Fragment>
        );
      })}
    </List>
  );
};
export default MenuSideBarContent;
