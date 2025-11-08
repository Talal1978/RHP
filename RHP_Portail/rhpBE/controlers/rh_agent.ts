import { Request, Response } from "express";
import { IsNull } from "../modules/module_general";
import { lireSql } from "../modules/module_sqlRW";
import { Int, NVarChar } from "mssql";

export const rh_agent = async (req: Request, res: Response) => {
  const { Matricule } = req.body;
  let idSoc = IsNull(req.params?.id_Societe, "3068");
  const rsl = await lireSql(
    `select * from Rh_Agent where id_Societe=@idSoc and Matricule=@Matricule`,
    [
      { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
      { param: "idSoc", sqlType: Int, valeur: idSoc },
    ]
  );
  if (!rsl || !rsl.result) {
    return res.send(rsl);
  }
  const rsCompetence = await lireSql(
    `select Competence, Intitule,Note from Sys_GPEC_Competence_Agent(@idSoc, @Matricule ) where Matricule=@Matricule`,
    [
      { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
      { param: "idSoc", sqlType: Int, valeur: idSoc },
    ]
  );
  const rsFormation = await lireSql(
    `select Annee as Année,Etablissement, Diplome as Diplôme, Commentaire from RH_Agent_CV where Typ_CV='F' and Matricule=@Matricule and id_Societe=@idSoc order by Annee desc`,
    [
      { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
      { param: "idSoc", sqlType: Int, valeur: idSoc },
    ]
  );
  const rsExperiences = await lireSql(
    `select Etablissement, Poste, Dat_Deb as Du, Dat_Fin as Au, Commentaire from RH_Agent_CV where Typ_CV='E' and Matricule=@Matricule and id_Societe=@idSoc order by Au desc`,
    [
      { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
      { param: "idSoc", sqlType: Int, valeur: idSoc },
    ]
  );
  const rsFamille = await lireSql(
    `select upper(Nom_Prenom) as Nom,dbo.FindRubrique('Lien_Parente',Lien_Parente) as Lien, isnull(convert(nvarchar(10),Dat_Naissance,103),'') 'Date naissance', Scolarise as Scolarisé 
    from RH_Agent_Famille where id_Societe=@idSoc and Matricule=@Matricule`,
    [
      { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
      { param: "idSoc", sqlType: Int, valeur: idSoc },
    ]
  );
  const rsPaie = await lireSql(
    `select Lib_Rubrique as Rubrique,Valeur as Montant from RH_Agent_Element_Paie a 
    outer apply (select Lib_Rubrique,Typ_Retour from RH_Paie_Rubrique where Cod_Rubrique=a.Cod_Rubrique 
    and  isnull(Nullif(id_Societe,-1),@idSoc)=@idSoc) o  where Matricule=@Matricule and id_Societe=@idSoc`,
    [
      { param: "Matricule", sqlType: NVarChar, valeur: Matricule },
      { param: "idSoc", sqlType: Int, valeur: idSoc },
    ]
  );
  return res.send({
    result: true,
    data: {
      agent: rsl.data,
      competences: rsCompetence.result ? rsCompetence.data : [],
      formations: rsFormation.result ? rsFormation.data : [],
      experiences: rsExperiences.result ? rsExperiences.data : [],
      famille: rsFamille.result ? rsFamille.data : [],
      paie: rsPaie.result ? rsPaie.data : [],
    },
  });
};
