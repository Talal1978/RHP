import { Rating } from "@mui/material";
import React from "react";
import { colorBase } from "../../modules/module_general";

const Competence = ({
  competence,
  intitule,
  note = 1,
  showNote = false,
}: {
  competence: string;
  intitule: string;
  note?: number;
  showNote?: boolean;
}) => {
  return (
    <div
      id={competence}
      style={{
        textAlign: "center",
        padding: "10px 20px",
        borderRadius: "50px",
        display: "inline-block",
        fontSize: "16px",
        whiteSpace: "nowrap",
        backgroundColor: colorBase.colorBase04,
        minWidth: "6em",
      }}
    >
      <span>{intitule}</span>
      {showNote && (
        <Rating
          name="half-rating-read"
          defaultValue={note}
          precision={note}
          readOnly
          sx={{ fontSize: "smaller" }}
        />
      )}
    </div>
  );
};

export default Competence;
