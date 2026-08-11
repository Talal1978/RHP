/* ============================================================================
   RHP - Correctif FK_Signatures_Lig_Signatures_Ent (soumission FKM)
   ----------------------------------------------------------------------------
   Problème : à la soumission d'une note de frais kilométriques (Typ_Document
   'FKM'), la procédure Sys_Workflow_Signature insère une ligne Signatures_Lig
   SANS en-tête Signatures_Ent correspondant lorsqu'aucun circuit de signature
   n'est configuré pour le type de document
     => "The INSERT statement conflicted with the FOREIGN KEY constraint
        FK_Signatures_Lig_Signatures_Ent" et rollback de l'enregistrement.

   Correctif :
     1. Sys_Workflow_Signature : garde-fou - si aucun circuit n'existe dans
        Workflow_Signatures pour (Typ_Document, id_Societe), on arrête avec un
        message explicite AVANT toute écriture (au lieu du crash FK).
     2. Circuit de signature FKM pour les sociétés 3060 et 3068 (même périmètre
        que NF) : modèle simple 'L' (comme DD), signataire D0011.
   Idempotent : ré-exécutable sans erreur.
   ============================================================================ */

/* -------------------------------------------------------------------------- */
/* 1. Sys_Workflow_Signature : garde-fou "circuit inexistant"                 */
/*    (corps identique à l'original + bloc de contrôle après le curseur)      */
/* -------------------------------------------------------------------------- */
ALTER proc [dbo].[Sys_Workflow_Signature] @TypDoc nvarchar(50),@idSoc nvarchar(10),@indx nvarchar(50) , @CreatedBy nvarchar(50)
as
declare @Lig int, @Trait nvarchar(max),  @laLigne int=-1, @SqlSignatire varchar(max), @TypListe nvarchar(1),
@select nvarchar(max)='', @from nvarchar(max)='', @RegrouperSignataires bit = 'true'
declare Sig cursor for
select Num_Ligne,Traitement,RegrouperSignataires  from  Workflow_Signatures_Detail
where Typ_Document =@TypDoc and id_Societe=@idSoc
order by Num_Ligne asc
open Sig
fetch next from Sig into @Lig , @Trait ,@RegrouperSignataires
while @@FETCH_STATUS =0
begin
set @Trait =  replace(replace(@Trait,'@@@Index',@indx) ,'@@@idSoc',@idSoc)
declare @isTheLine int,@SqlStr nvarchar(max), @ParamDef nvarchar(100)
--Axe Ana
set @SqlStr='set @EstLig = 0
			if ('+@Trait+')>0
			set @EstLig = 1'
set @ParamDef = '@EstLig int output'
exec sp_executesql @SqlStr, @ParamDef ,@EstLig=@isTheLine output
	if @isTheLine=1
	begin
	set @laLigne = @Lig
	break
	end
fetch next from Sig into @Lig , @Trait ,@RegrouperSignataires
end
close Sig
deallocate Sig

print('@laLigne >> '+convert(nvarchar(50),@laLigne))

-- >> Correctif : sans en-tête Workflow_Signatures, les inserts ci-dessous ne
-- >> produisent aucune ligne Signatures_Ent alors que Signatures_Lig est
-- >> alimentée => violation FK_Signatures_Lig_Signatures_Ent. Message clair.
if not exists (select 1 from Workflow_Signatures where Typ_Document=@TypDoc and id_Societe=@idSoc)
begin
	raiserror('Aucun circuit de signature n''est configuré pour le type de document ''%s'' (société %s). Paramétrez-le dans l''écran Workflow_Signatures.',16,1,@TypDoc,@idSoc)
	return
end

delete from Signatures_Ent where Typ_Document=@TypDoc  and Valeur_Index=@Indx and id_Societe=@idSoc
delete from Signatures_Lig where Typ_Document=@TypDoc  and Valeur_Index=@Indx and id_Societe=@idSoc
if @laLigne>=0
--Une configuration de signature existe
	begin
	print ('Une configuration de signature existe')
	select @SqlSignatire =isnull(Sql_Signataires,'') , @TypListe=isnull(Typ_Liste,'L') from Workflow_Signatures_Detail where Typ_Document =@TypDoc and Num_Ligne=@laLigne
	insert into Signatures_Ent (Typ_Document,id_Societe, Valeur_Index, Statut, Typ_Signature, Num_Ligne,Operande_Signature, Dans_Ordre, Dat_Crea, Created_By)
	select e.Typ_Document,@idSoc,@indx ,'SS',e.Typ_Signature, d.Num_Ligne, Operande_Signature,Dans_Ordre, getdate(),@CreatedBy
	from  Workflow_Signatures e left join Workflow_Signatures_Detail d on e.Typ_Document =d.Typ_Document and e.id_Societe=d.id_Societe  left join Workflow_Signatures_Signataires s
	on s.Num_Ligne =d.Num_Ligne and s.Typ_Document =d.Typ_Document  and s.id_Societe=d.id_Societe
	where e.Typ_Document=@TypDoc and d.Num_Ligne=@laLigne and e.id_Societe=@idSoc
	group by e.Typ_Document,e.Typ_Signature, d.Num_Ligne, Operande_Signature,Dans_Ordre
	if @TypListe ='F'
	begin
	print('Type liste Formule')
	set @select = ' select '''+@TypDoc+''' as Typ_Document, '''+@idSoc+''' as id_Societe,'+convert(nvarchar(5),@laLigne)+' as Num_Ligne,'''+@indx+''' as Valeur_Index, '
	set @from = replace(@Trait,'Select count(*)','')
	set @SqlSignatire= ltrim(rtrim(@SqlSignatire))
	set @SqlSignatire= case when @SqlSignatire like '%;' then left(@SqlSignatire,len(@SqlSignatire)-1) else @SqlSignatire end
	set @SqlSignatire= case when @SqlSignatire like ';%' then right(@SqlSignatire,len(@SqlSignatire)-1) else @SqlSignatire end
	set @SqlSignatire = @select + replace(@SqlSignatire,';',' as Signataire '+@from+char(10)+' union all '+char(10)+@select)+@from

	set @SqlSignatire = 'declare @tbl table (Typ_Document nvarchar(50), id_Societe nvarchar(50), Num_Ligne int, Valeur_Index nvarchar(50), Signataire nvarchar(50), RowId int Identity(1,1)) insert into @tbl ' + replace(replace(replace(@SqlSignatire,'@@@ValIndx',@Indx),'@@@Index',@indx) ,'@@@idSoc',@idSoc)
	set @SqlSignatire +='insert into Signatures_Lig (Typ_Document,id_Societe,Num_Ligne, Valeur_Index, Signataire)
						 select Typ_Document,id_Societe,Num_Ligne,Valeur_Index,Signataire from @tbl'
	set @SqlSignatire += case when @RegrouperSignataires='true' then ' group by Typ_Document,id_Societe,Num_Ligne,Valeur_Index,Signataire order by min(RowId)' else '' end

	 exec (@SqlSignatire)
    print 'regroupsignataire   '+ convert(nvarchar(50),@laLigne)+' >> ' +isnull(convert(nvarchar(50),@RegrouperSignataires),'xxxxxxxxx')
    print @SqlSignatire
	end
	else
	begin
	print('Type liste '+@TypListe)
	insert into Signatures_Lig (Typ_Document,id_Societe, Num_Ligne, Valeur_Index, Signataire, Decision, Dat_Signature)
	select Typ_Document,@idSoc,Num_Ligne,@indx , Signataire ,'', null
	from Workflow_Signatures_Signataires
	where Typ_Document=@TypDoc and Num_Ligne=@laLigne and  id_Societe=@idSoc
	order by RowId
	end
    end
else
begin
print('Aucune configuration de signature ne correspond au contexte')
--Aucune configuration de signature ne correspond au contexte
declare @SignataireDefaut nvarchar(50)=isnull((select top 1 Signataire_Defaut from Workflow_Signatures where id_Societe=@idSoc and Typ_Document=@TypDoc and isnull(Signataire_Defaut,'')!=''),'')
	insert into Signatures_Ent (Typ_Document,id_Societe, Valeur_Index, Statut, Typ_Signature, Num_Ligne,Operande_Signature, Dans_Ordre, Dat_Crea, Created_By)
	select e.Typ_Document,@idSoc,@indx ,'SS',e.Typ_Signature, -1, 'ET',0, getdate(),@CreatedBy
	from  Workflow_Signatures e where Typ_Document=@TypDoc and  id_Societe=@idSoc
	insert into Signatures_Lig (Typ_Document,id_Societe,Num_Ligne, Valeur_Index, Signataire, Decision, Dat_Signature)
	values (@TypDoc, @idSoc, -1, @indx,@SignataireDefaut,'Signataire par défaut', getdate())
end
set @sqlStr  =''
select @sqlStr='update '+Table_Ref+' set Statut=''SS'' where id_Societe='+@idSoc+' and '+Table_Index+'='''+@indx+'''' from Param_Workflow_Typ_Document d
where Typ_Document=@TypDoc and isnull(nullif(id_Societe,-1),@idSoc)=@idSoc

exec (@sqlStr)
--Changement par les suppléants:
 exec Sys_Workflow_Suppleant

GO

/* -------------------------------------------------------------------------- */
/* 2. Circuit de signature FKM (sociétés 3060 et 3068 - même périmètre que NF)*/
/*    Modèle simple en une ligne (comme DD) : signataire fixe D0011.          */
/* -------------------------------------------------------------------------- */
SET XACT_ABORT ON;
BEGIN TRANSACTION;

DECLARE @Socs TABLE (id_Societe int);
INSERT INTO @Socs VALUES (3060), (3068);

INSERT INTO Workflow_Signatures (Typ_Document, id_Societe, Typ_Signature, Table_Ref, Table_Index, Actif, Signataire_Defaut, Dat_Crea, Created_By)
SELECT 'FKM', s.id_Societe, 'E', 'SP_FKM_Ent', 'Num_Doc', 1, 'Admin', GETDATE(), 'SCRIPT'
FROM @Socs s
WHERE NOT EXISTS (SELECT 1 FROM Workflow_Signatures w
                  WHERE w.Typ_Document = 'FKM' AND w.id_Societe = s.id_Societe);

INSERT INTO Workflow_Signatures_Detail (Typ_Document, id_Societe, Num_Ligne, Lib_Ligne, Operande_Signature, Dans_Ordre, Condition, Traitement, Typ_Liste, Query_Sigantaire, Sql_Signataires, RegrouperSignataires)
SELECT 'FKM', s.id_Societe, 10, 'Default', 'ET', 0, '',
    'Select count(*) 
 from SP_FKM_Ent
 where SP_FKM_Ent.id_Societe=''@@@idSoc''  and  Num_Doc=''@@@Index'' ',
    'L', '', '', 1
FROM @Socs s
WHERE NOT EXISTS (SELECT 1 FROM Workflow_Signatures_Detail d
                  WHERE d.Typ_Document = 'FKM' AND d.id_Societe = s.id_Societe AND d.Num_Ligne = 10);

INSERT INTO Workflow_Signatures_Signataires (Typ_Document, id_Societe, Num_Ligne, Signataire)
SELECT 'FKM', s.id_Societe, 10, 'D0011'
FROM @Socs s
WHERE NOT EXISTS (SELECT 1 FROM Workflow_Signatures_Signataires x
                  WHERE x.Typ_Document = 'FKM' AND x.id_Societe = s.id_Societe AND x.Num_Ligne = 10);

COMMIT TRANSACTION;
GO

/* -------------------------------------------------------------------------- */
/* Vérifications                                                              */
/* -------------------------------------------------------------------------- */
SELECT Typ_Document, id_Societe, Typ_Signature, Actif, Signataire_Defaut
FROM Workflow_Signatures WHERE Typ_Document = 'FKM';
SELECT Typ_Document, id_Societe, Num_Ligne, Typ_Liste, Operande_Signature, Dans_Ordre
FROM Workflow_Signatures_Detail WHERE Typ_Document = 'FKM';
SELECT Typ_Document, id_Societe, Num_Ligne, Signataire
FROM Workflow_Signatures_Signataires WHERE Typ_Document = 'FKM';
