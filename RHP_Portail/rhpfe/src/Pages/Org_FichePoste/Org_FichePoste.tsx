import { useContext, useEffect, useState } from "react";
import RTFDisplay from "../../components/RTFDisplay/RTFDisplay";
import useAxiosGet from "../../hooks/useAxiosGet";
import { cntX } from "../../Menu/MenuMain";

const Org_FichePoste = () => {
  const [jobDescription, setJobDescription] = useState("");
  const [domainesCompetence, setDomainesCompetence] = useState("");
  const myAxios = useAxiosGet();
  const { setShowLoading } = useContext(cntX);
  useEffect(() => {
    setShowLoading(true);
    myAxios({
      apiStr: "ficheposte",
    }).then((dt) => {
      setJobDescription(dt.data?.data[0]?.JobDescription || "");
      setDomainesCompetence(dt.data?.data[0]?.domainesCompetence || "");
    }).finally(() => setShowLoading(false));
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
