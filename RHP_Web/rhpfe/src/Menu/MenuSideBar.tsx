import { useContext } from "react";
import MenuSideBarContent from "./MenuSideBarContent";
import "./mainmenu.scss";
import { cntX } from "./MenuMain";
const MenuSideBar = () => {
  const { isOpen, setIsOpen } = useContext(cntX);
  return (
    <div
      className="sideMenuBarContainer"
      onClick={() => setIsOpen((prevOpen: boolean) => !prevOpen)}
      style={{ width: isOpen ? "100%" : "auto" }}
    >
      <div
        className={`sidebar${isOpen ? "" : " sidebar-collapsed"}`}
        onClick={(ev) => ev.stopPropagation()}
      >
        <MenuSideBarContent />
      </div>
    </div>
  );
};

export default MenuSideBar;
