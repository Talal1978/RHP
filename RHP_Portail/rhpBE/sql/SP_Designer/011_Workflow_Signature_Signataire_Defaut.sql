/* ============================================================================
   RHP - Correctif Sys_Workflow_Signature : signataire par défaut non signable
   ----------------------------------------------------------------------------
   Problème : à la soumission d'un document dont AUCUNE ligne du circuit
   (Workflow_Signatures_Detail) ne correspond au contexte (condition Traitement
   non vérifiée), la branche de repli de Sys_Workflow_Signature insère la ligne
   du signataire par défaut DEJA DECIDEE :
       Decision='Signataire par défaut', Dat_Signature=getdate()
   Conséquences :
     - le parapheur (Sys_Parapheur_Signature, desktop ET portail) ne liste que
       les lignes Decision='' => le signataire par défaut ne voit JAMAIS le
       document (parapheur vide) ;
     - le document reste bloqué en statut 'SS' à vie : le roll-up
       Sys_Workflow_Maj_Statut_Signature n'est pas appelé à la soumission et
       'Signataire par défaut' <> 'SG' ne clôturerait de toute façon pas le
       circuit.
   Or l'écran Workflow_Signatures IMPOSE un signataire par défaut (blocage
   Saving) : sa vocation est de signer quand aucune règle ne s'applique.

   Correctif : la ligne du signataire par défaut est insérée SIGNABLE
   (Decision='', Dat_Signature=NULL), comme toute ligne de circuit normale.
   Effets de bord positifs : Sys_Workflow_Suppleant (qui ne traite que les
   lignes Decision='') s'applique désormais aussi au signataire par défaut ;
   la signature via le portail/desktop clôt le circuit normalement (SG).

   Cas constaté : XNF3072-2026000001 (RHP_Metafy, société 3072) - condition
   'Dat_Depart > getdate()' non vérifiée (départ passé) => document invisible
   dans le parapheur de M001.
   Pour débloquer les documents déjà figés, voir le bloc en bas de ce script.
   Idempotent : ré-exécutable sans erreur.
   ============================================================================ */

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
	-- >> Correctif : la ligne du signataire par défaut doit etre SIGNABLE
	-- >> (Decision='', Dat_Signature=NULL) pour apparaitre dans son parapheur ;
	-- >> auparavant insérée déjà décidée ('Signataire par défaut', getdate()),
	-- >> elle restait invisible et le document bloqué en 'SS' à vie.
	insert into Signatures_Lig (Typ_Document,id_Societe,Num_Ligne, Valeur_Index, Signataire, Decision, Dat_Signature)
	values (@TypDoc, @idSoc, -1, @indx,@SignataireDefaut,'', null)
end
set @sqlStr  =''
select @sqlStr='update '+Table_Ref+' set Statut=''SS'' where id_Societe='+@idSoc+' and '+Table_Index+'='''+@indx+'''' from Param_Workflow_Typ_Document d
where Typ_Document=@TypDoc and isnull(nullif(id_Societe,-1),@idSoc)=@idSoc

exec (@sqlStr)
--Changement par les suppléants:
 exec Sys_Workflow_Suppleant

GO

/* ----------------------------------------------------------------------------
   Déblocage des documents déjà figés par l'ancien comportement (optionnel,
   au cas par cas) - exemple appliqué sur RHP_Metafy pour XNF3072-2026000001 :

update Signatures_Lig set Decision='', Dat_Signature=null
where Typ_Document='XNF' and id_Societe=3072 and Valeur_Index='XNF3072-2026000001'
  and Decision='Signataire par défaut'
   ---------------------------------------------------------------------------- */
