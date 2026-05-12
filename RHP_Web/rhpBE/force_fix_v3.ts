
import { lireSql } from "./modules/module_sqlRW";
import { initialisationSeveur, VGLOBALES } from "./modules/module_initialisation";

async function applyFix() {
    try {
        await initialisationSeveur();
        console.log(`Server initialized. Connected to ${VGLOBALES.SQL_SERVER}, DB: ${VGLOBALES.SQL_DB}`);

        console.log("Dropping SQL Function (Unconditional)...");
        // Using generic OBJECT_ID check which works for IF, TF, FN etc.
        const dropSql = `IF OBJECT_ID('dbo.Sys_Portail_DashBoard_Insights') IS NOT NULL DROP FUNCTION dbo.Sys_Portail_DashBoard_Insights`;
        let res = await lireSql(dropSql);
        console.log("Drop result:", res.result);
        if (!res.result) console.error("Drop Error:", res.sort);

        console.log("Creating SQL Function (Inline)...");
        const createSql = `
        CREATE FUNCTION dbo.Sys_Portail_DashBoard_Insights
            (	
                @Pilote nvarchar(50),
                @idSoc int,
                @Top int = 5
            )
            RETURNS TABLE 
            AS
            RETURN 
            (
            select top(@Top) 'Formation' as Evenement, Cod_Formation as Code, Lib_Formation as Libelle, Dat_Du,
            Dat_Au, 
            isnull(g.Genre_Formation,'') as Genre, case when isnull(Nature_Formation,'2')='2' then isnull(Raison_Sociale,'') else 'Formation Interne' end Nature,
            s.Statut_Formation as Statut,
            f.Cod_Survey as Cod_Survey 
            from dbo.Formation f
            outer apply (select Membre as Genre_Formation from Param_Rubriques where Nom_Controle ='Genre_Formation' and Valeur=Genre_Formation)g
            outer apply (select Membre as Statut_Formation from Param_Rubriques where Nom_Controle ='Statut_Formation' and Valeur=Statut_Formation)s
            outer apply (select Raison_Sociale from Formation_Cabinet  where Cod_Cabinet  =f.Cod_Cabinet and id_Societe =f.id_Societe )c
            where  id_Societe =@idSoc and case when isnull(@Pilote ,'')!='*' then (select COUNT(*) from Formation_Participants where id_Societe =@idSoc and Cod_Formation =f.Cod_Formation  and Matricule =@Pilote) else 1 end>0
            union all 
            select top(@Top) 'Entretien de recrutement',Num_RC, Lib_Rec,isnull(Dat_Entretien_Realise, Dat_Entretien_Prevue), dateadd(minute,30,isnull(Dat_Entretien_Realise, Dat_Entretien_Prevue)), Motif_RC,'Evaluation Recrutement',Statut, NULL as Cod_Survey
            from Recrutement_Entretiens c
            outer apply (select Lib_RC,dbo.FindRubrique('Motif_RC',Motif_RC) as Motif_RC,Buget_Salaire as Budget from Recrutement where id_Societe=c.id_Societe and Num_RC=c.Num_RC)r                            
            outer apply (select Nom_Agent+' '+Prenom_Agent as Nom from Rh_Agent where id_Societe=c.id_Societe and Matricule=c.Candidat)a                            
            outer apply (select Nom+' '+Prenom as Nom from CVtheque where id_Societe=c.id_Societe and Matricule=c.Candidat)v
            outer apply (select case when isdate(Dat_Entretien_Realise)=1 then 'Réalisé' else 'Planifié' end Statut)s
            outer apply (select 'Entretien recrutement '+ isnull(a.Nom,v.Nom)+' ('+ Statut +')' as Lib_Rec)l
            where  id_Societe =@idSoc and Evaluateur like replace( isnull(@Pilote ,''),'*','%') 
            union all
            select top(@Top) 'Entretien de candidature',Num_RC,Lib_Rec,isnull(Dat_Entretien_Realise, Dat_Entretien_Prevue), dateadd(minute,30,isnull(Dat_Entretien_Realise, Dat_Entretien_Prevue)), Motif_RC,'Candidature',Statut, NULL as Cod_Survey
            from Recrutement_Entretiens c
            outer apply (select Lib_RC,dbo.FindRubrique('Motif_RC',Motif_RC) as Motif_RC,Buget_Salaire as Budget,Cod_Poste_RC,Cod_Entite_RC, Cod_Grade_RC, Titre_RC from Recrutement where id_Societe=c.id_Societe and Num_RC=c.Num_RC)r                            
            outer apply (select Nom_Agent+' '+Prenom_Agent as Nom from Rh_Agent where id_Societe=c.id_Societe and Matricule=c.Evaluateur)a							
            outer apply (select Lib_Poste from Org_Poste where id_Societe=c.id_Societe and Cod_Poste=r.Cod_Poste_RC)p							
            outer apply (select Lib_Grade from Org_Grade where id_Societe=c.id_Societe and Cod_Grade=r.Cod_Grade_RC)g							
            outer apply (select Lib_Entite from Org_Entite where id_Societe=c.id_Societe and Cod_Entite=r.Cod_Entite_RC)t							
            outer apply (select case when isdate(Dat_Entretien_Realise)=1 then 'Réalisé' else 'Planifié' end Statut)s
            outer apply (select 'Entretien avec '+ isnull(a.Nom,'')+char(10)+isnull('Poste : '+nullif(Lib_Poste,'')+char(10),'')
            +isnull('Grade : '+nullif(Lib_Grade,'')+char(10),'')
            +isnull('Titre : '+nullif(Titre_RC,'')+char(10),'')+
            +isnull('Entité : '+nullif(Lib_Entite,'')+char(10),'')+' ('+ Statut +')' as Lib_Rec) l
            where  id_Societe =@idSoc and Candidat like replace( isnull(@Pilote ,''),'*','%') 
            union all
            select top(@Top) 'Evaluation à effectuer',Cod_Evaluation, Description,
            Dat_Du, Dat_Au,convert(nvarchar(10),count(*))+  ' Evaluations restantes','Actions d''évaluation',dbo.FindRubrique('Statut_Signature',v.Statut) 'Statut', NULL as Cod_Survey
            from Sys_Evaluation_Liste l
            outer apply(select Membre as Statut from Param_Rubriques where Nom_Controle ='Statut_Evaluation' and Valeur=Statut_Evaluation)s
            outer apply (select Cod_Reply, Statut, Paie_Calculee, Dat_Survey from Survey_Reply where id_Societe =l.id_Societe and Cod_Survey =l.Cod_Survey and ISNULL(Ref_Evaluation,'')=Cod_Evaluation and Typ_Evalue ='E' and Evalue =Matricule) v
            where  id_Societe =@idSoc and Cod_Evaluateur like replace( isnull(@Pilote ,''),'*','%') and isnull(Cod_Reply,'')=''
            group by Cod_Evaluation, Description,Dat_Du, Dat_Au,v.Statut ,Dat_Survey 
             union all
            select top(@Top) 'Evaluation',Cod_Evaluation, Description,
            Dat_Du, Dat_Au,'Vous serez évalué par '+Nom_Evaluateur,'Actions d''évaluation',dbo.FindRubrique('Statut_Signature',v.Statut) Statut, NULL as Cod_Survey
            from Sys_Evaluation_Liste l
            outer apply(select Membre as Statut from Param_Rubriques where Nom_Controle ='Statut_Evaluation' and Valeur=Statut_Evaluation)s
            outer apply (select Cod_Reply, Statut, Paie_Calculee, Dat_Survey from Survey_Reply where id_Societe =l.id_Societe and Cod_Survey =l.Cod_Survey and ISNULL(Ref_Evaluation,'')=Cod_Evaluation and Typ_Evalue ='E' and Evalue =Matricule) v
            where  id_Societe =@idSoc and Matricule like replace( isnull(@Pilote ,''),'*','%') and isnull(Cod_Reply,'')=''
            )`;

        res = await lireSql(createSql);
        console.log("Create result:", res.result);
        if (!res.result) console.error("Create Error:", res.sort);

        // Verification
        console.log("Verifying Execution Result for D0011...");
        const execSql = `select * from Sys_Portail_DashBoard_Insights('D0011', 3060, 10)`;
        const execRes = await lireSql(execSql);
        if (execRes.data && execRes.data.length > 0) {
            const row = execRes.data.find((r: any) => r.Code === 'FOR000001');
            if (row) {
                console.log("Keys:", Object.keys(row));
                console.log("Cod_Survey:", row.Cod_Survey);
            } else {
                console.log("FOR000001 not found, but keys are:", Object.keys(execRes.data[0]));
            }
        } else {
            console.log("No data returned from function.");
        }

    } catch (e) {
        console.error("Script error:", e);
    }
}

applyFix();
