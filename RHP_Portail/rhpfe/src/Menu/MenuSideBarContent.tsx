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
  SvgIconProps,
  SvgIconTypeMap,
  Typography,
} from "@mui/material";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import { controleMenus } from "../modules/module_menus";
import {
  AccountTree,
  PersonOutline,
  NoteAlt,
  Schema,
  FolderShared,
  DownhillSkiing,
  CurrencyExchange,
  Savings,
  MedicalInformation,
  Commute,
  Money,
  AccountBalanceWallet,
  FolderSpecial,
  StarHalf,
  ThumbUp,
  ContactEmergency,
  Portrait,
  PersonPin,
  EventAvailable,
  Topic,
  ChevronRight,
  StarBorder,
  ExpandLess,
  ExpandMore,
} from "@mui/icons-material";
import { Fragment, useContext, useEffect, useState } from "react";
import { cntX } from "./MenuMain";
import { useNavigate } from "react-router-dom";
import { colorBase } from "../modules/module_general";
import { inherits } from "util";
interface MenuIcons {
  [key: string]: React.ElementType<SvgIconProps>;
}
const menusIcon: MenuIcons = {
  AccountTree: AccountTree,
  PersonOutline: PersonOutline,
  NoteAlt: NoteAlt,
  Schema: Schema,
  FolderShared: FolderShared,
  DownhillSkiing: DownhillSkiing,
  CurrencyExchange: CurrencyExchange,
  Savings: Savings,
  MedicalInformation: MedicalInformation,
  Commute: Commute,
  Money: Money,
  AccountBalanceWallet: AccountBalanceWallet,
  FolderSpecial: FolderSpecial,
  StarHalf: StarHalf,
  ThumbUp: ThumbUp,
  ContactEmergency: ContactEmergency,
  Portrait: Portrait,
  PersonPin: PersonPin,
  EventAvailable: EventAvailable,
  Topic: Topic,
  ChevronRight: ChevronRight,
};
const GetMenuIcon = ({
  name_ecran,
  sx = { color: colorBase.colorBase01 },
}: {
  name_ecran: string;
  sx?: any;
}): JSX.Element => {
  const IconComponent = menusIcon[name_ecran] || ChevronRight;
  return <IconComponent sx={{ ...sx }} />;
};

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
                      style={{ backgroundColor: "#f1ffff" }}
                      sx={{ pl: 7 }}
                      onClick={() =>
                        handleOpenEcran(ecr.name_ecran, ecr.text_ecran)
                      }
                    >
                      <ListItemIcon>
                        <GetMenuIcon
                          name_ecran={ecr.img || ""}
                          sx={{ color: "gray" }}
                        />
                      </ListItemIcon>
                      <ListItemText
                        primary={ecr.text_ecran}
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
