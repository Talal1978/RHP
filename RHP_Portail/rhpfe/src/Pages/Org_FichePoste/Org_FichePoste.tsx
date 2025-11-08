import { useEffect, useState } from "react";
import RTFDisplay from "../../components/RTFDisplay/RTFDisplay";
import useAxiosGet from "../../hooks/useAxiosGet";

const Org_FichePoste = () => {
  const [jobDescription, setJobDescription] = useState("");
  const [domainesCompetence, setDomainesCompetence] = useState("");
  const myAxios = useAxiosGet();
  useEffect(() => {
    myAxios({
      apiStr: "ficheposte",
    }).then((dt) => {
      setJobDescription(dt.data?.data[0]?.JobDescription || "");
      setDomainesCompetence(dt.data?.data[0]?.domainesCompetence || "");
    });
  }, []);
  return (
    <div>
      <RTFDisplay
        rtfText={jobDescription}
        style={{ width: "60em", height: "80em", backgroundColor: "red" }}
      />
    </div>
  );
};

export default Org_FichePoste;
