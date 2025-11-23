Imports System.Text
Imports System.Text.RegularExpressions
Class PayRollEngine
    Friend oAvancementStr As String = ""
    Friend oAvancementStrTitre As String = ""
    Dim curMat As String = ""
    Friend CalculAuto As Boolean = True
    Friend Modifie As Boolean = False
    Friend PaieCloture As Boolean = False
    Friend TblPrePaie, TblAgent, TblFunction, Tbl_Controles, TblEC, TblRubriqueCumulable, TblElementSpecifique, TblRules, TblEX_Base As New DataTable
    Friend dicMat As New Dictionary(Of String, Dictionary(Of String, Double))
    Dim dicTypFunction As New Dictionary(Of String, String)
    Friend dicColor As New Dictionary(Of String, Color)
    Friend rgRules As New System.Text.RegularExpressions.Regex("!ùé&")
    Friend strEP, strEM, elementDetailBulletinPaie As String()
    Friend EBSalBase, ECSalNet, ECSalaireBrut, ECChargesPAtronales, EVJrConge, EVAvance, EVPret, EVInteret, EVRembFraisMedic, EVPrimeABrutifier, EVPrimeBrutifiee, EVNoteFrais As String
    Friend CodPlan, CodPreparation As String
    Friend DatDeb, DatFin As Date
    Friend reinitialiserPreparation As Boolean = False
    Friend myVBS As New vsEngine

    Sub New()
        curMat = ""
        CalculAuto = True
        PaieCloture = False
        Building_Sys_RH_Agent_AG()
        If Tbl_Controles.Columns.Count = 0 Then
            With Tbl_Controles
                .Columns.Add("Criticite")
                .Columns.Add("Matricule")
                .Columns.Add("Message d'erreur")
                .Columns.Add("Bloquant")
                .Columns.Add("N° d'erreur")
                .Columns("Bloquant").DataType = System.Type.GetType("System.Boolean")
            End With
        End If

    End Sub
    Sub InitialisationPaie(CodPreparation_ As String, codPlan_ As String, DatDeb_ As Date, DatFin_ As Date, withLog As Boolean)
        Dim str As String = ""
        curMat = ""
        CodPreparation = CodPreparation_
        CodPlan = codPlan_
        DatDeb = DatDeb_
        DatFin = DatFin_
        strEP = "".Split(";")
        strEM = "".Split(";")
        Dim TblPlan As DataTable = DATA_READER_GRD("select * from RH_Param_Plan_Paie where Cod_Plan_Paie='" & CodPlan & "' and id_Societe=" & Societe.id_Societe)
        With TblPlan
            If .Rows.Count > 0 Then
                EVJrConge = IsNull(.Rows(0)("NbJrConge"), "")
                EVAvance = IsNull(.Rows(0)("Avance"), "")
                EVPret = IsNull(.Rows(0)("Pret"), "")
                EVInteret = IsNull(.Rows(0)("Interet"), "")
                EVRembFraisMedic = IsNull(.Rows(0)("RembFraisMedic"), "")
                EVNoteFrais = IsNull(.Rows(0)("RembNoteFrais"), "")
                EVPrimeABrutifier = IsNull(.Rows(0)("PrimeABrutifier"), "")
                EVPrimeBrutifiee = IsNull(.Rows(0)("PrimeBrutifiee"), "")
                ECSalNet = IsNull(.Rows(0)("SalNet"), "")
                EBSalBase = IsNull(.Rows(0)("SalBase"), "")
                ECSalaireBrut = IsNull(.Rows(0)("SalBrut"), "")
                ECChargesPAtronales = IsNull(.Rows(0)("ChargesPatronales"), "")
                strEP = IsNull(.Rows(0)("Element_Paie"), "").Trim.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                elementDetailBulletinPaie = IsNull(.Rows(0)("Element_Detail"), "").Trim.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                If strEP.Length > 0 Then
                    Dim TblSelect As DataTable = DATA_READER_GRD("select Cod_Filtre, Syntaxe from RH_Param_Plan_Paie_Filtre where id_Societe='" & Societe.id_Societe & "' and Cod_Plan_Paie='" & CodPlan & "' and Typ_Filtre='C' and isnull(Actif,'false')='true'")
                    Dim EMstr As String = ""
                    If TblSelect.Rows.Count > 0 Then
                        EMstr = IsNull(TblSelect.Rows(0)("Syntaxe"), "")
                    End If
                    If EMstr = "" Then
                        EMstr = "Date entrée;Entité;Grade;Type agent;Type contrat;" & IsNull(.Rows(0)("Element_Masques"), "")
                    End If
                    strEM = EMstr.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                End If
            Else
                EVJrConge = ""
                EVAvance = ""
                EVPret = ""
                EVInteret = ""
                EVRembFraisMedic = ""
                EVNoteFrais = ""
                EVPrimeABrutifier = ""
                EVPrimeBrutifiee = ""
                EBSalBase = ""
                ECSalNet = ""
                ECSalaireBrut = ""
                ECChargesPAtronales = ""
            End If
            Dim rgRulesStr As String = CnExecuting("declare @r varchar(max)
      set @r=''
Select @r='\b('+replace(isnull(Element_Paie,'') ,';',')\b|\b(')+')\b'
From RH_Param_Plan_Paie where Cod_Plan_Paie='" & CodPlan & "' and id_Societe=" & Societe.id_Societe & "
Select isnull(@r,'')").Fields(0).Value
            rgRulesStr = rgRulesStr.Trim
            If rgRulesStr.Trim <> "" Then
                rgRules = New Regex(rgRulesStr)
            Else
                rgRules = New Regex("!ùé&")
            End If
        End With
        TblEC = DATA_READER_GRD("select Cod_Rubrique, Typ_Retour, Nb_Decimal, isnull(Tx,'') Tx, isnull(Nb,'') Nb, isnull(Base,'') Base from RH_Paie_Rubrique where isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe & " and (isnull(EC,0)=1 or isnull(EX,0)=1)")
        TblFunction = DATA_READER_GRD(" Select Cod_Function, Typ_Function, Lib_Abr, Formule_Function,
                                        Typ_Retour, IsNull(Nb_Decimal, 2) As Nb_Decimal, IsNull(Est_Pourcentage,'false') as Est_Pourcentage, 
                                        isnull(Patronal,'false') Patronal , isnull(Gain_Retenue,'A') as Gain_Retenue,isnull(Couleur,'') Couleur
                                        from  RH_Elements_Paie p
                                        outer apply ( Select Patronal , Gain_Retenue, Couleur  from  RH_Paie_Rubrique where isnull(nullif(id_Societe,-1),p.id_Societe)=p.id_Societe and Cod_Rubrique=Cod_Function)r
                                        where isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)
        dicColor.Clear()
        Dim rw() As DataRow = TblFunction.DefaultView.ToTable(True, "Cod_Function", "Couleur").Select("Couleur<>''")
        If rw.Length > 0 Then
            For i = 0 To rw.Length - 1
                Dim StrCouleur As String = rw(i)("Couleur")
                If StrCouleur.Split({";"}, StringSplitOptions.RemoveEmptyEntries).Length = 3 And Not StrCouleur = "209;226;249" Then
                    If IsNumeric(StrCouleur.Split({";"}, StringSplitOptions.RemoveEmptyEntries)(0)) And IsNumeric(StrCouleur.Split({";"}, StringSplitOptions.RemoveEmptyEntries)(1)) And IsNumeric(StrCouleur.Split({";"}, StringSplitOptions.RemoveEmptyEntries)(2)) Then
                        dicColor.Add(rw(i)("Cod_Function"), Color.FromArgb(CInt(StrCouleur.Split({";"}, StringSplitOptions.RemoveEmptyEntries)(0)), CInt(StrCouleur.Split({";"}, StringSplitOptions.RemoveEmptyEntries)(1)), CInt(StrCouleur.Split({";"}, StringSplitOptions.RemoveEmptyEntries)(2))))
                    End If
                End If
            Next
        End If
        TblRubriqueCumulable = DATA_READER_GRD("select * from dbo.Sys_RH_Paie_Calcul_Rubrique_Cumulable ('" & Year(CDate(DatFin)) & "','" & Month(CDate(DatFin)) & "','" & Societe.id_Societe & "','')")

        TblAgent = DATA_READER_GRD($"select * from {sql_Sys_RH_Agent_AG} where id_Societe=" & Societe.id_Societe & " and isnull(Cod_Plan_Paie,'')='" & CodPlan & "'")

        TblRules = DATA_READER_GRD("select id_Controle, isnull(ErreurSi,'') as ErreurSi, isnull(Msg_Erreur,'') Msg_Erreur, isnull(Criticite,'B') as Criticite, isnull(Bloquant,'false') as Bloquant
                                    FROM  RH_Param_Plan_Paie_Controle
                                    where id_Societe=" & Societe.id_Societe & " and Cod_Plan_Paie='" & CodPlan & "'")
        curMat = ""
        myVBS = New vsEngine
        myVBS.withLog = withLog
        myVBS.setPlan(CodPlan)

        str = "AffectVar Dat_Fin_Periode, """ & DatFin & """
               AffectVar Dat_Deb_Periode, """ & DatDeb & """"

        myVBS.ExecuteStatement(str)
    End Sub
    Function ChargerNouvellePreparation(xwhere As String) As String
        If reinitialiserPreparation Then
            CnExecuting("delete from RH_Preparation_Paie_Detail where Typ_Rubrique!='EV' and Cod_Preparation='" & CodPreparation & "' and id_Societe=" & Societe.id_Societe)
        End If
        Dim nRows() As DataRow = Nothing
        Dim StrSelect As String = ""
        Dim EBouterStr As String = ""
        Dim EVouterStr As String = ""
        For i = 0 To strEP.Length - 1
            nRows = TblFunction.Select("Cod_Function='" & strEP(i) & "' and Typ_Retour in ('float','int')")
            If nRows.Length > 0 Then
                If nRows(0)("Typ_Function") = "EB" Then
                    StrSelect &= IIf(StrSelect = "", "", ",") & " convert(" & nRows(0)("Typ_Retour") & ",isnull(p.[" & strEP(i) & "],0)) as '" & strEP(i) & "'"
                    EBouterStr &= IIf(EBouterStr = "", "", ",") & " sum(case when Cod_Rubrique='" & strEP(i) & "' then isnull(Valeur,0) else 0 end) as '" & strEP(i) & "'"
                ElseIf nRows(0)("Typ_Function") = "CS" Then
                    StrSelect &= IIf(StrSelect = "", "", ",") & " convert(" & nRows(0)("Typ_Retour") & ",'" & nRows(0)("Formule_Function").replace(",", ".") & "') as '" & strEP(i) & "'"
                ElseIf Not reinitialiserPreparation And strEP(i) = EVJrConge Then
                    StrSelect &= IIf(StrSelect = "", "", ",") & " convert(float,isnull(Duree_Conge,0)) as '" & EVJrConge & "'"
                ElseIf Not reinitialiserPreparation And strEP(i) = EVAvance Then
                    StrSelect &= IIf(StrSelect = "", "", ",") & " convert(float,isnull(Montant_Avance,0)) as '" & EVAvance & "'"
                ElseIf Not reinitialiserPreparation And strEP(i) = EVPret Then
                    StrSelect &= IIf(StrSelect = "", "", ",") & " convert(float,isnull(Mensualite,0)) as '" & EVPret & "'"
                ElseIf Not reinitialiserPreparation And strEP(i) = EVInteret Then
                    StrSelect &= IIf(StrSelect = "", "", ",") & " convert(float,isnull(Interet,0)) as '" & EVInteret & "'"
                ElseIf Not reinitialiserPreparation And strEP(i) = EVRembFraisMedic Then
                    StrSelect &= IIf(StrSelect = "", "", ",") & " convert(float,isnull(Mnt_Remboursement,0)) as '" & EVRembFraisMedic & "'"
                ElseIf Not reinitialiserPreparation And strEP(i) = EVNoteFrais Then
                    StrSelect &= IIf(StrSelect = "", "", ",") & " convert(float,isnull(Mnt_NF,0)) as '" & EVNoteFrais & "'"
                ElseIf nRows(0)("Typ_Function") = "EV" And CodPreparation <> "" And reinitialiserPreparation Then
                    StrSelect &= IIf(StrSelect = "", "", ",") & " convert(" & nRows(0)("Typ_Retour") & ",isnull(d.[" & strEP(i) & "],0)) as '" & strEP(i) & "'"
                    EVouterStr &= IIf(EVouterStr = "", "", ",") & " sum(case when Cod_Rubrique='" & strEP(i) & "' then isnull(Valeur,0) else 0 end) as '" & strEP(i) & "'"
                Else
                    StrSelect &= IIf(StrSelect = "", "", ",") & " convert(" & nRows(0)("Typ_Retour") & ",0) as '" & strEP(i) & "'"
                End If
            End If
        Next
        If EBouterStr <> "" Then EBouterStr = " outer apply (select " & EBouterStr & " from RH_Agent_Element_Paie where Matricule=a.Matricule and id_Societe=" & Societe.id_Societe & ") p "
        If EVouterStr <> "" Then EVouterStr = " outer apply (select " & EVouterStr & " from RH_Preparation_Paie_Detail  where Matricule=a.Matricule and id_Societe=" & Societe.id_Societe & " and Typ_Rubrique='EV' and Cod_Preparation='" & CodPreparation & "') d "
        StrSelect = "select Matricule,Nom_Agent+' '+Prenom_Agent as 'Nom',Dat_Entree as 'Date entrée',Cod_Entite as Entité,Cod_Grade as Grade , TypAgent 'Type agent',TypContrat as 'Type contrat', " & StrSelect & "
                        from RH_Agent a
                        " & EVouterStr & "
                        " & EBouterStr & "
                        outer apply (select top 1 Membre as TypAgent from Param_Rubriques where Nom_Controle='Typ_Agent' and Valeur=Typ_Agent) ta
                        outer apply (select top 1 Membre as TypContrat from Param_Rubriques where Nom_Controle='Typ_Contrat' and Valeur=Typ_Contrat) tc
                        outer apply (select isnull(Duree_Conge,0) as Duree_Conge from dbo.Sys_GetCongePris('" & CodPlan & "','" & DatDeb & "','" & DatFin & "'," & Societe.id_Societe & ") where Matricule= a.Matricule) conge 
                        outer apply (select sum(isnull(Montant_Avance,0)-isnull(Reglement,0)) as Montant_Avance from RH_Paie_Avance where id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and isnull(Statut,'') in ('V','SG') and isnull(Traite,0)=0 and Dat_Demande<='" & DatFin & "' having sum(isnull(Montant_Avance,0)-isnull(Reglement,0))>0) av 
                        outer apply (select sum(Mnt_Remboursement) as Mnt_Remboursement from RH_Dossier_Maladie where id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and isnull(Statut,'') in ('P','SG') and isnull(Traite,0)=0 and Dat_Dossier<='" & DatFin & "') rbfrmd 
                        outer apply (select sum(Mnt_NF) as Mnt_NF from RH_Note_Frais where id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and isnull(Statut,'') in ('V','SG') and isnull(Traite,0)=0 and Dat_NF<='" & DatFin & "') rbnf 
                        outer apply (select sum(isnull(Mensualite,0)) as Mensualite  from RH_Pret_Detail d
                                    where exists(select Num_Pret from RH_Pret where isnull(Typ_Pret,'')<>'I' and id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and Num_Pret=d.Num_Pret) and id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and Echeance between '" & DatDeb & "' and '" & DatFin & "') pret
                        outer apply (select sum(isnull(Interet,0)) as Interet  from RH_Pret_Detail d
                                    where exists(select Num_Pret from RH_Pret where isnull(Typ_Pret,'')='I' and id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and Num_Pret=d.Num_Pret) and id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and Echeance between '" & DatDeb & "' and '" & DatFin & "') int  
                      where id_Societe=" & Societe.id_Societe & " and isnull(Droit_Paie,0)=1 and isnull(Plan_Paie,'')='" & CodPlan & "' and isnull(Dat_Entree,'01/01/2050')<='" & DatFin & "'
                     and not exists(select 1 from RH_Preparation_Paie_Detail d left join RH_Preparation_Paie e on e.Cod_Preparation=d.Cod_Preparation
                    where '" & DatDeb & "' <= Dat_Fin_Periode and '" & DatFin & "' >= Dat_Deb_Periode  and isnull(Plan_Paie,'')='" & CodPlan & "'  and d.id_Societe=" & Societe.id_Societe & " and d.Matricule=a.Matricule and d.Cod_Preparation!='" & CodPreparation & "')
                    " & xwhere & "
                    order by Nom"
        reinitialiserPreparation = False
        Return StrSelect
    End Function
    Sub Request(CodPreparation As String, CodPlan As String, DatDeb As String, DatFin As String, withLog As Boolean)
        Dim StrOuterApply As String = ""
        Dim StrSelect As String = ""
        curMat = ""
        InitialisationPaie(CodPreparation, CodPlan, DatDeb, DatFin, withLog)
        If CodPreparation = "" Or reinitialiserPreparation Then
            StrOuterApply = ChargerNouvellePreparation("")
            TblEX_Base = DATA_READER_GRD("select Matricule, Cod_Rubrique, Valeur from RH_Agent_Element_Paie e 
where exists(select Cod_Rubrique from RH_Paie_Rubrique where isnull(nullif(id_Societe,-1),e.id_Societe)=e.id_Societe and isnull(EX,0)=1)
and exists(select Matricule from Rh_Agent a where a.id_Societe=e.id_Societe and a.Matricule=e.Matricule and Plan_Paie='" & CodPlan & "' and isnull(Droit_Paie,0)=1)
and id_Societe =" & Societe.id_Societe)
        Else
            strEP = CStr(CnExecuting("declare @EE nvarchar(max)
select @EE = ';'+isnull(e.ElementPaie,isnull(p.Element_Paie,''))+';' 
from RH_Param_Plan_Paie p 
outer apply (select ElementPaie from RH_Preparation_Paie e 
where e.id_Societe=p.id_Societe and e.Cod_Plan_Paie=p.Cod_Plan_Paie and Cod_Preparation='" & CodPreparation & "')e
where p.id_Societe =" & Societe.id_Societe & " and p.Cod_Plan_Paie ='" & CodPlan & "'
select @EE
 ").Fields(0).Value).ToString.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
            For i = 0 To strEP.Length - 1
                StrSelect &= IIf(StrSelect = "", "", ",") & " isnull([" & strEP(i) & "],0) as '" & strEP(i) & "'"
                StrOuterApply &= IIf(StrOuterApply = "", "", ",") & "[" & strEP(i) & "]"
            Next
            StrOuterApply = "select Matricule,Nom,Dat_Entree as 'Date entrée',Cod_Entite as Entité,Cod_Grade as Grade , Typ_Agent as 'Type agent',Typ_Contrat as 'Type contrat', " & StrSelect & "
            from (select d.Matricule,Nom,Dat_Entree , Cod_Entite, Cod_Grade, Typ_Agent, Typ_Contrat, Cod_Rubrique , isnull(Valeur,0) as Valeur 
                from RH_Preparation_Paie_Detail d left join dbo.Sys_RH_Preparation_Paie_Agent a on  a.Matricule=d.Matricule and a.id_Societe=d.id_Societe
                where Cod_Preparation ='" & CodPreparation & "' 
                and d.id_Societe =" & Societe.id_Societe & " and Typ_Retour in ('float','int')) t
                pivot (sum(Valeur) 
                    FOR Cod_Rubrique IN (" & StrOuterApply & ")
                ) AS pivot_table order by Nom"
            TblEX_Base = DATA_READER_GRD("select Matricule, Cod_Rubrique, Base as Valeur
from RH_Preparation_Paie_Detail where Cod_Preparation='" & CodPreparation & "' and id_Societe=" & Societe.id_Societe & " and Typ_Rubrique='EX' and isnull(Base,0)!=0")
        End If
        TblPrePaie = DATA_READER_GRD(StrOuterApply)
        Dim colName As String = ""
        Dim MatrName As String = ""
        Dim nrw() As DataRow
        dicTypFunction = New Dictionary(Of String, String)
        With TblPrePaie
            For i = 0 To .Columns.Count - 1
                .Columns(i).ReadOnly = False
                colName = .Columns(i).ColumnName
                If strEP.Contains(colName) Then
                    nrw = TblFunction.Select("Cod_Function='" & colName & "'")
                    If nrw.Length > 0 Then
                        dicTypFunction.Add(colName, nrw(0)("Typ_Function"))
                    End If
                End If
            Next
        End With
        CalculTotal(True)
    End Sub

    Sub CalculTotal(CalculDetail As Boolean)
        dicMat = New Dictionary(Of String, Dictionary(Of String, Double))
        With TblPrePaie
            For i = 0 To .Rows.Count - 1
                oAvancementStrTitre = "Recalcul général de la préparation : " & CodPreparation & " " & CInt(((i + 1) / .Rows.Count) * 100) & "% " & StrDup(i Mod 4, ".")
                oAvancementStr = CStr(i + 1)
                CalculPaie(.Rows(i)("Matricule"), CalculDetail)
            Next
        End With
    End Sub
    Dim fstTest = True
    Function getModulesExternes(CodPlan As String, DatDeb As Date, DatFin As Date, updConge As Boolean, updAvance As Boolean, updPret As Boolean, updInteret As Boolean, updRemb As Boolean, updNF As Boolean) As String
        Return "select Matricule " &
                                  IIf(updConge = "0", "", ", convert(float,isnull(Duree_Conge,0)) as '" & EVJrConge & "'") &
                                  If(updNF = "0", "", ", convert(float,isnull(Mnt_NF,0)) as '" & EVNoteFrais & "'") &
                                  IIf(updAvance = "0", "", ", Convert(float, IsNull(Montant_Avance, 0)) as '" & EVAvance & "'") &
                                  IIf(updPret = "0", "", ", Convert(float,IsNull(Mensualite,0)) As '" & EVPret & "'") &
                                  IIf(updInteret = "0", "", ", convert(float,isnull(Interet,0)) as '" & EVInteret & "'") &
                                  IIf(updRemb = "0", "", ", convert(float,isnull(Mnt_Remboursement,0)) as '" & EVRembFraisMedic & "'") &
                                  " from RH_Agent a " &
                                  IIf(updConge = "0", "", " outer apply (select isnull(Duree_Conge,0) as Duree_Conge from dbo.Sys_GetCongePris('" & CodPlan & "','" & DatDeb & "','" & DatFin & "'," & Societe.id_Societe & ") where Matricule= a.Matricule) conge ") &
                                  If(updNF = "0", "", " outer apply (select sum(Mnt_NF) as Mnt_NF from RH_Note_Frais where Matricule= a.Matricule and id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and isnull(Statut,'') in ('V','SG') and isnull(Traite,0)=0 and Dat_NF<='" & DatFin & "' having sum(Mnt_NF)>0) nf  ") &
                                  IIf(updAvance = "0", "", " outer apply (select sum(isnull(Montant_Avance,0)-isnull(Reglement,0)) as Montant_Avance from RH_Paie_Avance where id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and isnull(Statut,'') in ('V','SG') and isnull(Traite,0)=0 and Dat_Demande<='" & DatFin & "' having sum(isnull(Montant_Avance,0)-isnull(Reglement,0))>0) av ") &
                                  IIf(updRemb = "0", "", " outer apply (select sum(Mnt_Remboursement) as Mnt_Remboursement from RH_Dossier_Maladie where id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and isnull(Statut,'') in ('P','SG') and isnull(Traite,0)=0 and Dat_Dossier<='" & DatFin & "') rbfrmd ") &
                                  IIf(updPret = "0", "", " outer apply (select sum(isnull(Mensualite,0)) as Mensualite  from RH_Pret_Detail d
                                            where exists(select Num_Pret from RH_Pret where isnull(Typ_Pret,'')<>'I' and id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and Num_Pret=d.Num_Pret) and id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and Echeance between '" & DatDeb & "' and '" & DatFin & "') pret ") &
                                  IIf(updInteret = "0", "", "  outer apply (select sum(isnull(Interet,0)) as Interet  from RH_Pret_Detail d
                                            where exists(select Num_Pret from RH_Pret where isnull(Typ_Pret,'')='I' and id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and Num_Pret=d.Num_Pret) and id_Societe=" & Societe.id_Societe & " and Matricule=a.Matricule and Echeance between '" & DatDeb & "' and '" & DatFin & "') int ") &
                                  " where id_Societe=" & Societe.id_Societe & " and isnull(Droit_Paie,0)=1 and isnull(Plan_Paie,'')='" & CodPlan & "'"
    End Function
    Sub MiseAJourModulesAnnexes(CodPlan As String, DatDeb As Date, DatFin As Date, updConge As Boolean, updAvance As Boolean, updPret As Boolean, updInteret As Boolean, updRemb As Boolean, updNF As Boolean)
        If TblPrePaie.Columns.Count = 0 Then
            Return
        End If
        Dim SqlStr As String = getModulesExternes(CodPlan, DatDeb, DatFin, updConge, updAvance, updPret, updInteret, updRemb, updNF)
        Dim TblConge As DataTable = DATA_READER_GRD(SqlStr)
        Dim oRw() As DataRow
        Dim calculer As Boolean = False
        With TblPrePaie
            For i = 0 To .Rows.Count - 1
                oRw = TblConge.Select("[Matricule]='" & .Rows(i)("Matricule") & "'")
                calculer = False
                If oRw.Length > 0 Then
                    For j = 1 To TblConge.Columns.Count - 1
                        If .Columns.Contains(TblConge.Columns(j).ColumnName) Then
                            calculer = True
                            .Rows(i)(TblConge.Columns(j).ColumnName) = IsNull(oRw(0).Item(j), 0)
                        End If
                    Next
                End If
                If calculer Then CalculPaie(.Rows(i)("Matricule"), True)
            Next
        End With
    End Sub
    Public Structure savingResult
        Dim result As Boolean
        Dim message As String
        Dim NotDroitPaie As ArrayList
    End Structure

    Function Saving(libPreparation As String, avecControle As Boolean, avecCloture As Boolean) As savingResult
        Dim rsl As New savingResult
        Dim objSC As Object
        Dim objCum As Double = 0
        Dim Matricule As String = ""
        Dim CodFunction As String = ""
        Dim TypFunction As String = ""
        Dim TypRetour As String = ""
        Dim nRw(), cRw() As DataRow
        Dim rnd As New Random
        Dim flg As Integer = rnd.Next(1111, 999999)
        Dim dicTmp As New Dictionary(Of String, Double)
        Dim oDat As String = CnExecuting("select getdate()").Fields(0).Value
        Dim str0 As String = ""
        rsl.result = False
        rsl.NotDroitPaie = New ArrayList()
        oAvancementStrTitre = "Enregistrement de la paie," & vbCrLf & "Plan de paie : " & CodPlan & ", du : " & DatDeb & " au " & DatFin
        oAvancementStrTitre &= vbCrLf & "Calcul lancé à : " & Now

        Dim nbErrorB As Integer = 0
        With TblPrePaie
            oAvancementStrTitre &= vbCrLf & "Vérification de droit à la paie "
            For i = 0 To .Rows.Count - 1
                If TblAgent.Select("Matricule='" & .Rows(i)("Matricule") & "' and Droit_Paie='true'").Length = 0 Then
                    rsl.NotDroitPaie.Add(.Rows(i)("Matricule"))
                End If
            Next
            If rsl.NotDroitPaie.Count > 0 Then
                rsl.message = "Certains matricules n'ont pas droit à la paie."
                rsl.result = False
                Return rsl
            End If
            str0 = oAvancementStrTitre
            For i = 0 To .Rows.Count - 1
                oAvancementStrTitre = str0 & vbCrLf & "Recalcul des lignes : " & i + 1 & "/" & .Rows.Count & " " & StrDup(i Mod 5, ".")
                oAvancementStr = i + 1
                If Not CalculPaie(.Rows(i)("Matricule"), True) Then
                    rsl.message = "Erreur bloquante de calcul du matricule : " & .Rows(i)("Matricule")
                    rsl.result = False
                    Return rsl
                End If
            Next
            If avecControle Then
                Dim strRule As String = ""
                Dim strRuleMsg As String = ""
                For i = 0 To .Rows.Count - 1
                    With TblRules
                        For j = 0 To .Rows.Count - 1
                            strRule = .Rows(j)("ErreurSi")
                            strRuleMsg = .Rows(j)("Msg_Erreur")
                            If strRule <> "" Then
                                For Each c As System.Text.RegularExpressions.Match In rgRules.Matches(strRule)
                                    If TblPrePaie.Columns.Contains(c.Value) Then
                                        strRule = strRule.Replace(c.Value, ConvertNombre(TblPrePaie.Rows(i)(c.Value)))
                                    End If
                                Next
                                If myVBS.Eval(TraitementCaractere(strRule)) Then
                                    Tbl_Controles.Rows.Add(.Rows(j)("Criticite"), TblPrePaie.Rows(i)("Matricule"), strRuleMsg, .Rows(j)("Bloquant"), .Rows(j)("id_Controle"))
                                    If CBool(.Rows(j)("Bloquant")) Then nbErrorB += 1
                                End If
                            End If
                        Next
                    End With
                Next
            End If
            If nbErrorB > 0 Then
                rsl.message = "Votre paie contient des erreurs bloquantes."
                rsl.result = False
                Return rsl
            End If
        End With
        oAvancementStrTitre &= vbCrLf & "Enregistrement : " & Now
        oAvancementStr = ""
        Dim racine As String = "P" & Societe.id_Societe & "-" & CDate(DatDeb).Year & Droite("00" & CDate(DatDeb).Month, 2) & "-"
        If CodPreparation = "" Then
            Dim Cp As New ADODB.Recordset
            Cp = CnExecuting("select Top 1 convert(int,right(Cod_Preparation,3)) from RH_Preparation_Paie where id_Societe=" & Societe.id_Societe & " and Cod_Preparation like '" & racine & "%' order by Cod_Preparation Desc")
            If Not Cp.EOF Then
                CodPreparation = racine & Droite("000" & CInt(Cp.Fields(0).Value + 1), 3)
            Else
                CodPreparation = racine & "001"
            End If
        End If
        Dim rs As New ADODB.Recordset
        rs.Open("select * from RH_Preparation_Paie where Cod_Preparation='" & CodPreparation & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Dat_Crea").Value = oDat
            rs("Created_By").Value = theUser.Login
            rs("id_Societe").Value = Societe.id_Societe
            rs("Cod_Preparation").Value = CodPreparation
        Else
            rs.Update()
        End If
        rs("Lib_Preparation").Value = Gauche(libPreparation, 250)
        rs("Cod_Plan_Paie").Value = CodPlan
        rs("Annee_Paie").Value = CDate(DatFin).Year
        rs("Mois_Paie").Value = CDate(DatFin).Month
        rs("Dat_Deb_Periode").Value = DatDeb
        rs("Dat_Fin_Periode").Value = DatFin
        rs("Dat_Preparation").Value = oDat
        rs("Cloture").Value = avecCloture
        rs("ElementPaie").Value = String.Join(";", TblPrePaie.Columns.Cast(Of DataColumn).Where(Function(d) dicTypFunction.ContainsKey(d.ColumnName)).Select(Function(c) c.ColumnName).ToList)
        rs("Flag_Maj").Value = flg
        rs("Dat_Modif").Value = oDat
        rs("Modified_By").Value = theUser.Login
        rs.Update()
        rs.Close()
        str0 = oAvancementStrTitre
        With TblPrePaie
            rs.Open("select * from RH_Preparation_Paie_Detail", cn, 2, 2)
            For i = 0 To .Rows.Count - 1
                Matricule = .Rows(i)("Matricule")
                oAvancementStrTitre = str0 & vbCrLf & "Avancement : " & i + 1 & "/" & .Rows.Count & " " & StrDup(i Mod 5, ".")
                oAvancementStr = i + 1
                For j = 0 To .Columns.Count - 1
                    CodFunction = .Columns(j).ColumnName
                    nRw = TblFunction.Select("Cod_Function='" & CodFunction & "'")
                    If nRw.Length > 0 Then
                        TypFunction = nRw(0)("Typ_Function")
                        TypRetour = nRw(0)("Typ_Retour")
                        If "EC;EV;EB;CS;FU;FS;FP;EX".Split(";").Contains(TypFunction) Then
                            cRw = TblRubriqueCumulable.Select("Matricule='" & Matricule & "' and Cod_Rubrique='" & CodFunction & "'")
                            If cRw.Length > 0 Then
                                objCum = CDbl(cRw(0)("Cumul"))
                            Else
                                objCum = 0
                            End If
                            objSC = IsNull(.Rows(i)(CodFunction), "0").Replace(".", ",")
                            objSC = ConvertNombre(objSC)
                            rs.AddNew()
                            rs("id_Societe").Value = Societe.id_Societe
                            rs("Cod_Preparation").Value = CodPreparation
                            rs("Matricule").Value = Matricule
                            rs("Cod_Rubrique").Value = CodFunction
                            rs("Typ_Rubrique").Value = TypFunction
                            rs("Typ_Retour").Value = TypRetour
                            rs("Annee_Paie").Value = CDate(DatFin).Year
                            rs("Mois_Paie").Value = CDate(DatFin).Month
                            rs("Valeur").Value = Math.Round(objSC, nRw(0)("nb_Decimal"))
                            If "EC;EX".Split(";").Contains(TypFunction) Then
                                dicTmp = dicMat(Matricule & "_|_" & CodFunction)
                                rs("Nb").Value = dicTmp("Nb")
                                rs("Tx").Value = dicTmp("Tx")
                                rs("Base").Value = dicTmp("Base")
                            Else
                                rs("Nb").Value = 0
                                rs("Tx").Value = 0
                                rs("Base").Value = 0
                            End If
                            rs("Cumul").Value = Math.Round(objCum + rs("Valeur").Value, nRw(0)("nb_Decimal"))
                            rs("Flag_Maj").Value = flg
                            rs.Update()
                        End If
                    End If
                Next
            Next
            rs.Close()
        End With
        Dim SqlStr As String = ""
        oAvancementStrTitre &= vbCrLf & "Resynchronisation des cumuls : " & Now
        SqlStr = "update RH_Param_Plan_Paie set DatDernierePaie='" & DatDeb & "', 
                    LastAnneePaie='" & CDate(DatDeb).Year & "', LastMoisPaie='" & CDate(DatDeb).Month & "'
                     where   RH_Param_Plan_Paie.Cod_Plan_Paie='" & CodPlan & "'  and id_Societe=" & Societe.id_Societe
        CnExecuting(SqlStr)
        oAvancementStrTitre &= vbCrLf & "Resynchronisation des soldes : " & Now
        SqlStr = "insert into RH_Preparation_Paie_Detail (id_Societe, Cod_Preparation, Matricule, Cod_Rubrique, Typ_Rubrique, Typ_Retour, Valeur, Nb, Tx, Base, Rang, Cumul,  Annee_Paie, Mois_Paie, Flag_Maj)
                        select id_Societe,'" & CodPreparation & "', Matricule,'Droit_Conge_Mensuel', 'EB','float',isnull(Droit_Conge_Mensuel,0),0,0,0,0,0,'" & CDate(DatFin).Year & "','" & CDate(DatFin).Month & "','" & flg & "'
                        from RH_Agent a
                        where id_Societe=" & Societe.id_Societe & " and isnull(Plan_Paie,'')='" & CodPlan & "' 
                        and exists(select Matricule from RH_Preparation_Paie_Detail where Cod_Preparation='" & CodPreparation & "' and isnull(Flag_Maj,0)=" & flg & " and Matricule=a.Matricule)
                        and isnull(Droit_Paie,0)=1"
        CnExecuting(SqlStr)
        SqlStr = "Delete from RH_Preparation_Paie_Detail where Cod_Preparation='" & CodPreparation & "' and isnull(Flag_Maj,0)<>" & flg
        CnExecuting(SqlStr)
        oAvancementStrTitre &= vbCrLf & "Resynchronisation des congés : " & Now
        CnExecuting("exec Sys_Conge_MajConge '" & Societe.id_Societe & "'")
        rsl.message = CodPreparation
        If avecCloture Then
            oAvancementStrTitre &= vbCrLf & "Clôture de la prépartion."
        End If
        oAvancementStrTitre &= vbCrLf & "Préparation des bulletins de paie : " & Now
        CnExecuting("exec Sys_Bulletin_Preparation " & Societe.id_Societe & ", '" & CodPreparation & "'")
        oAvancementStrTitre &= vbCrLf & "Terminé à " & Now
        rsl.result = True
        Modifie = False
        Return rsl
    End Function

#Region "NetToBrut"
    Function CalculNetToBrut() As Boolean
        If ShowMessageBox("Attention: assurez-vous d'exécuter ce traitement une fois que votre paie est quasi finalisée." & vbCrLf _
                & "Les changements postérieurs à ce traitement ne seront pas pris en considération", "Génération de l'équivalent en brut des primes servies en net", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return False

        If EVPrimeABrutifier = "" OrElse EVPrimeBrutifiee = "" Then
            ShowMessageBox("Pour exécuter ce traitement, vous dever déclarer d'abord les éléments variables relatifs" & vbCrLf & "aux primes brutifiées et à brutifier, au niveau du paramétrage du plan de paie", "Paramétrage du plan de paie", MessageBoxButtons.OK, msgIcon.Stop)
            Return False
        End If
        With TblPrePaie
            If Not .Columns.Contains(EVPrimeABrutifier) OrElse Not .Columns.Contains(EVPrimeBrutifiee) Then
                ShowMessageBox("Votre préparation ne contient pas les éléments variables relatifs" & vbCrLf & "aux primes brutifiées et à brutifier", "Paramétrage du plan de paie", MessageBoxButtons.OK, msgIcon.Stop)
                Return False
            End If
            If .Compute("sum(" & EVPrimeABrutifier & ")", "1=1") = 0 And .Compute("sum(" & EVPrimeBrutifiee & ")", "1=1") = 0 Then
                ShowMessageBox("Vous n'avez pas renseigné de prime nette au niveau de la colonne : " & vbCrLf & TblFunction.Select("Cod_Function='" & EVPrimeBrutifiee & "'")(0)("Lib_Abr"), "Vérifications", MessageBoxButtons.OK, msgIcon.Stop)
                Return False
            End If
        End With
        With Zoom_Generation_NetToBrut
            .PrePaie = Me
            .evABrutifier = EVPrimeABrutifier
            .evBrutifiee = EVPrimeBrutifiee
            .evSalNet = ECSalNet
            .ShowDialog()
        End With
        Return True
    End Function


#End Region

#Region "Calcul"
    Function CalculPaie(ByVal Matricule As String, CalculDetail As Boolean) As Boolean
        If TblPrePaie Is Nothing Then Return False
        If PaieCloture Then Return False
        If Not CalculAuto Then Return False
        Dim matRw() As DataRow = TblPrePaie.Select("Matricule='" & Matricule & "'")
        Dim agRw() As DataRow = TblAgent.Select("Matricule='" & Matricule & "'")
        If matRw.Length = 0 Then Return False
        If agRw.Length = 0 Then Return False
        Dim colName As String = ""
        Dim EVstr As String = ""
        Dim valCell As Double = 0
        '  Try
        With matRw(0)
            CalculAuto = False
            Dim vrw() As DataRow = Nothing
            'Affectation des Rubriques cumulables et AG
            If curMat <> Matricule Then
                'Affectation des AG
                Dim Ag() As DataRow = TblFunction.Select("Typ_Function='AG'")
                For i = 0 To Ag.Length - 1
                    If "int;float".Split(";").Contains(Ag(i)("Typ_Retour")) Then
                        EVstr &= IIf(EVstr = "", "", vbCrLf) & " AffectVar " & Ag(i)("Cod_Function") & ";" & IsNull(agRw(0)(Ag(i)("Cod_Function")), 0)
                    Else
                        EVstr &= IIf(EVstr = "", "", vbCrLf) & " AffectVar " & Ag(i)("Cod_Function") & ";""" & IsNull(agRw(0)(Ag(i)("Cod_Function")), "") & """"
                    End If
                Next
                'Affectation des Rubriques cumulables
                Dim Crw() As DataRow = TblRubriqueCumulable.Select("Matricule='" & Matricule & "'")
                For i = 0 To Crw.Length - 1
                    EVstr &= IIf(EVstr = "", "", vbCrLf) & " AffectVar Cumul_" & Crw(i)("Cod_Rubrique") & ";" & Crw(i)("Cumul")
                Next
                curMat = Matricule
            End If
            For Each c In dicTypFunction.Where(Function(x) "EV;EB".Split(";").Contains(x.Value))
                colName = c.Key
                'Affectation des EV et EB
                EVstr &= vbCrLf & " AffectVar " & colName & ";" & IsNull(matRw(0)(colName), 0)
            Next
            For Each c In dicTypFunction.Where(Function(x) "EX".Split(";").Contains(x.Value))
                colName = c.Key
                'Affectation des EX élément de base calculés
                Dim xrw() As DataRow = TblEX_Base.Select("Matricule='" & Matricule & "' and Cod_Rubrique='" & colName & "'")
                Dim valBase As Double = 0
                If xrw.Length > 0 Then
                    EVstr &= vbCrLf & "V_" & colName & " = " & IsNull(xrw(0)("Valeur"), 0)
                    valBase = IsNull(xrw(0)("Valeur"), 0)
                Else
                    EVstr &= vbCrLf & "V_" & colName & " = 0 "
                End If
                If Not dicMat.ContainsKey(Matricule & "_|_" & colName) Then
                    Dim dicRubDetail As New Dictionary(Of String, Double)
                    dicRubDetail.Add("Nb", 0)
                    dicRubDetail.Add("Tx", 0)
                    dicRubDetail.Add("Base", valBase)
                    dicMat.Add(Matricule & "_|_" & colName, dicRubDetail)
                Else
                    dicMat(Matricule & "_|_" & colName)("Nb") = 0
                    dicMat(Matricule & "_|_" & colName)("Tx") = 0
                    dicMat(Matricule & "_|_" & colName)("Base") = valBase
                End If
            Next

            EVstr = TraitementCaractere(EVstr)
            myVBS.ExecuteStatement(EVstr)

            'If fstTest Then
            '    Dim sw As New IO.StreamWriter(My.Application.Info.DirectoryPath & "\rsc\debugger_tumag.vbs", True)
            '    sw.Write(myVBS.innerCodeStr)
            '    sw.Close()
            '    fstTest = False
            'End If


            'Calcul des éléments calculables
            For Each c In dicTypFunction
                colName = c.Key
                If "EX;EC;FU;FP;FS".Split(";").Contains(c.Value) Then
                    valCell = IsNull(myVBS.Eval(TraitementCaractere(colName)), 0)
                    If valCell <> TblPrePaie.Select("Matricule='" & Matricule & "'")(0)(colName) Then
                        TblPrePaie.Select("Matricule='" & Matricule & "'")(0)(colName) = valCell
                        Modifie = True
                    End If
                    '  If manuel Then MsgBox(Matricule & "  >> " & colName & "  >>  " & TblPrePaie.Select("Matricule='" & Matricule & "'")(0)(colName))
                    If "EC".Split(";").Contains(c.Value) And CalculDetail Then
                        If Not dicMat.ContainsKey(Matricule & "_|_" & colName) Then
                            Dim dicRubDetail As New Dictionary(Of String, Double)
                            dicRubDetail.Add("Nb", 0)
                            dicRubDetail.Add("Tx", 0)
                            dicRubDetail.Add("Base", 0)
                            dicMat.Add(Matricule & "_|_" & colName, dicRubDetail)
                        Else
                            dicMat(Matricule & "_|_" & colName)("Nb") = 0
                            dicMat(Matricule & "_|_" & colName)("Tx") = 0
                            dicMat(Matricule & "_|_" & colName)("Base") = 0
                        End If
                        vrw = TblEC.Select("Cod_Rubrique='" & colName & "'")
                        If IsNull(vrw(0)("Nb"), "").Trim() = "" Then
                            dicMat(Matricule & "_|_" & colName)("Nb") = 0
                        Else
                            dicMat(Matricule & "_|_" & colName)("Nb") = ConvertNombre(myVBS.Eval(TraitementCaractere(vrw(0)("Nb"))))
                        End If
                        If IsNull(vrw(0)("Tx"), "").Trim() = "" Then
                            dicMat(Matricule & "_|_" & colName)("Tx") = 0
                        Else
                            dicMat(Matricule & "_|_" & colName)("Tx") = ConvertNombre(myVBS.Eval(TraitementCaractere(vrw(0)("Tx"))))
                        End If
                        If IsNull(vrw(0)("Base"), "").Trim() = "" Then
                            dicMat(Matricule & "_|_" & colName)("Base") = 0
                        Else
                            dicMat(Matricule & "_|_" & colName)("Base") = ConvertNombre(myVBS.Eval(TraitementCaractere(vrw(0)("Base"))))
                        End If

                    End If
                    If Not IsNumeric(IsNull(matRw(0)(colName), 0)) Then
                        TblPrePaie.Select("Matricule='" & Matricule & "'")(0)(colName) = 0
                    End If
                End If
            Next
        End With
        CalculAuto = True
        '  Catch ex As Exception
        Return True
        '   If Not ex.HResult = -2146233079 Then
        '   ShowMessageBox("Erreur de calcul de matricule : " & Matricule & ", Rubrique : " & colName & vbCrLf & ex.Message, "Calcul", MessageBoxButtons.OK, msgIcon.Stop)
        '  End If
        '  CalculAuto = True
        '   Return False
        '   End Try
    End Function
#End Region
End Class
