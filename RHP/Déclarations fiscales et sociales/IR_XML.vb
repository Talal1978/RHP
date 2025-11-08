Imports System.Runtime.CompilerServices
Imports System.Xml
Public Class IR_XML
    Dim AnneePaieDu, AnneePaieAu As Date
    Private Sub IR_XML_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Annee_Paie_cbo.FromSQL("select Annee , Annee as AnneePaie from Param_Periode_Paie where id_Societe=" & Societe.id_Societe)
    End Sub
    Private Sub OK_ButtonX_Click(sender As Object, e As EventArgs) Handles Save_ud.Click
        If Annee_Paie_cbo.Items.Count = 0 Or Annee_Paie_cbo.SelectedIndex = -1 Then
            ShowMessageBox("Aucune année de paie n'est renseignée", "Année de paie", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If Not IsNumeric(Annee_Paie_cbo.SelectedValue) Then
            ShowMessageBox("Aucune année de paie n'est renseignée", "Année de paie", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        AnneePaieDu = FindLibelle("Dat_Deb", "Annee", Annee_Paie_cbo.SelectedValue, "Param_Periode_Paie")
        AnneePaieAu = FindLibelle("Dat_Fin", "Annee", Annee_Paie_cbo.SelectedValue, "Param_Periode_Paie")

        Dim dialog2 As New SaveFileDialog
        dialog2.FileName = "IR_" & Societe.IdentFisc & "_" & Annee_Paie_cbo.SelectedValue & ".xml"
        dialog2.Filter = "Fichiers xml|*.xml*"
        dialog2.DefaultExt = "xml"
        dialog2.AddExtension = True
        dialog2.ShowDialog()
        Dim fileName As String = dialog2.FileName
        dialog2 = Nothing
        If (fileName <> "") Then
            Cursor = Cursors.WaitCursor
            GenererXML(fileName)
            Cursor = Cursors.Default
        End If
    End Sub
    Dim ErrXml As Integer = 0
    Dim xmlId As Integer = -1
    Dim Exercice As Integer = 1700
    Dim Maj2017 As Boolean = True
    Sub GenererXML(ByVal FichierXML As String)
        Cursor = Cursors.WaitCursor
        XmlLiasse.LoadXml("<TraitementEtSalaire xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""traitementSalaire.xsd""></TraitementEtSalaire>")
        Dim identifiantFiscalB As XmlElement = XmlLiasse.CreateElement("identifiantFiscal")
        Dim nomB As XmlElement = XmlLiasse.CreateElement("nom")
        Dim prenomB As XmlElement = XmlLiasse.CreateElement("prenom")
        Dim raisonSocialeB As XmlElement = XmlLiasse.CreateElement("raisonSociale")
        Dim exerciceFiscalDuB As XmlElement = XmlLiasse.CreateElement("exerciceFiscalDu")
        Dim exerciceFiscalAuB As XmlElement = XmlLiasse.CreateElement("exerciceFiscalAu")
        Dim anneeB As XmlElement = XmlLiasse.CreateElement("annee")
        Exercice = CDate(AnneePaieAu).Year
        If Exercice = 2017 Then
            Maj2017 = (ShowMessageBox("Voulez-vous appliquer les maj prévues par la DGI pour l'exercice 2017?", "MAJ DGI-IR", MessageBoxButtons.YesNo) = DialogResult.Yes)
        ElseIf Exercice <= 2016 Then
            Maj2017 = False
        End If
        identifiantFiscalB.InnerText = Societe.IdentFisc
        nomB.InnerText = ""
        prenomB.InnerText = ""
        raisonSocialeB.InnerText = Societe.Denomination
        exerciceFiscalDuB.InnerText = CDate(AnneePaieDu).ToString("yyyy-MM-dd")
        exerciceFiscalAuB.InnerText = CDate(AnneePaieAu).ToString("yyyy-MM-dd")
        anneeB.InnerText = Year(CDate(AnneePaieAu).ToString("yyyy-MM-dd"))
        Dim formeJuridiqueB As XmlElement = XmlLiasse.CreateElement("formeJuridique")
        Dim codeB As XmlElement = XmlLiasse.CreateElement("code")

        codeB.InnerText = "SF" 'Societe.FJ
        formeJuridiqueB.AppendChild(codeB)
        Dim communeB As XmlElement = XmlLiasse.CreateElement("commune")
        Dim codeB1 As XmlElement = XmlLiasse.CreateElement("code")
        codeB1.InnerText = Societe.Cod_Commune.Trim()
        communeB.AppendChild(codeB1)
        Dim professionB As XmlElement = XmlLiasse.CreateElement("profession")
        Dim adresseB As XmlElement = XmlLiasse.CreateElement("adresse")
        Dim numeroCINB As XmlElement = XmlLiasse.CreateElement("numeroCIN")
        Dim numeroCEB As XmlElement = XmlLiasse.CreateElement("numeroCE")
        Dim numeroCNSSB As XmlElement = XmlLiasse.CreateElement("numeroCNSS")
        Dim numeroRCB As XmlElement = XmlLiasse.CreateElement("numeroRC")
        Dim identifiantTPB As XmlElement = XmlLiasse.CreateElement("identifiantTP")
        Dim numeroFaxB As XmlElement = XmlLiasse.CreateElement("numeroFax")
        Dim numeroTelephoneB As XmlElement = XmlLiasse.CreateElement("numeroTelephone")
        Dim emailB As XmlElement = XmlLiasse.CreateElement("email")
        Dim effectifTotalB As XmlElement = XmlLiasse.CreateElement("effectifTotal")
        Dim nbrPersoPermanentB As XmlElement = XmlLiasse.CreateElement("nbrPersoPermanent")
        Dim nbrPersoOccasionnelB As XmlElement = XmlLiasse.CreateElement("nbrPersoOccasionnel")
        Dim nbrStagiairesB As XmlElement = XmlLiasse.CreateElement("nbrStagiaires")
        Dim totalMtRevenuBrutImposablePPB As XmlElement = XmlLiasse.CreateElement("totalMtRevenuBrutImposablePP")
        Dim totalMtRevenuNetImposablePPB As XmlElement = XmlLiasse.CreateElement("totalMtRevenuNetImposablePP")
        Dim totalMtTotalDeductionPPB As XmlElement = XmlLiasse.CreateElement("totalMtTotalDeductionPP")
        Dim totalMtIrPrelevePPB As XmlElement = XmlLiasse.CreateElement("totalMtIrPrelevePP")
        Dim totalMtBrutSommesPOB As XmlElement = XmlLiasse.CreateElement("totalMtBrutSommesPO")
        Dim totalIrPrelevePOB As XmlElement = XmlLiasse.CreateElement("totalIrPrelevePO")
        Dim totalMtBrutTraitSalaireSTGB As XmlElement = XmlLiasse.CreateElement("totalMtBrutTraitSalaireSTG")
        Dim totalMtBrutIndemnitesSTGB As XmlElement = XmlLiasse.CreateElement("totalMtBrutIndemnitesSTG")
        Dim totalMtRetenuesSTGB As XmlElement = XmlLiasse.CreateElement("totalMtRetenuesSTG")
        Dim totalMtRevenuNetImpSTGB As XmlElement = XmlLiasse.CreateElement("totalMtRevenuNetImpSTG")
        Dim totalSommePayeRTSB As XmlElement = XmlLiasse.CreateElement("totalSommePayeRTS")
        Dim totalmtAnuuelRevenuSalarialB As XmlElement = XmlLiasse.CreateElement("totalmtAnuuelRevenuSalarial")
        Dim totalmtAbondementB As XmlElement = XmlLiasse.CreateElement("totalmtAbondement")
        Dim montantPermanentB As XmlElement = XmlLiasse.CreateElement("montantPermanent")
        Dim montantOccasionnelB As XmlElement = XmlLiasse.CreateElement("montantOccasionnel")
        Dim montantStagiaireB As XmlElement = XmlLiasse.CreateElement("montantStagiaire")
        professionB.InnerText = Societe.Activite
        adresseB.InnerText = Societe.Adresse
        numeroCINB.InnerText = ""
        numeroCEB.InnerText = ""
        numeroCNSSB.InnerText = Societe.CNSS
        numeroRCB.InnerText = Societe.RC
        identifiantTPB.InnerText = Societe.TP
        numeroFaxB.InnerText = Societe.Fax
        numeroTelephoneB.InnerText = Societe.Tel
        emailB.InnerText = Societe.Email

        Dim NbPERM, NbOCCAS, NbSTAG, NbExo, NbDoc, NbBen, NbVer As Integer

        NbPERM = CnExecuting("Select count(*) from IR_Permanents where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value
        NbOCCAS = CnExecuting("Select count(*) from IR_Occasionnels  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value
        NbSTAG = CnExecuting("Select count(*) from IR_Stagiaires  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value
        NbExo = CnExecuting("Select count(*) from IR_Exoneres  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value
        NbDoc = CnExecuting("Select count(*) from IR_Doctorants  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value
        NbBen = CnExecuting("Select count(*) from IR_Beneficiaires  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value
        NbVer = 0 ' CnExecuting("Select count(*) from IR_Versements  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value

        effectifTotalB.InnerText = NbPERM + NbOCCAS + NbSTAG
        nbrPersoPermanentB.InnerText = XmlNb(NbPERM)
        nbrPersoOccasionnelB.InnerText = XmlNb(NbOCCAS)
        nbrStagiairesB.InnerText = XmlNb(NbSTAG)
        'MntBrutImpot


        totalMtRevenuBrutImposablePPB.InnerText = XmlNb(CnExecuting("select isnull(sum(mtBrutTraitementSalaire),0) from IR_Permanents  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value)
        totalMtRevenuNetImposablePPB.InnerText = XmlNb(CnExecuting("select isnull(sum(mtRevenuNetImposable),0) from IR_Permanents  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value)
        totalMtTotalDeductionPPB.InnerText = XmlNb(CnExecuting("select isnull(sum(mtAutresRetenues+mtFraisProfess+mtCotisationAssur+mtEcheances),0) from IR_Permanents  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value)
        totalMtIrPrelevePPB.InnerText = XmlNb(CnExecuting("select isnull(sum(irPreleve),0) from IR_Permanents  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value)
        totalMtBrutSommesPOB.InnerText = XmlNb(CnExecuting("select isnull(sum(mtBrutSommes),0) from IR_Occasionnels  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value)
        totalIrPrelevePOB.InnerText = XmlNb(CnExecuting("select isnull(sum(irPreleve),0) from IR_Occasionnels  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value)
        totalMtBrutTraitSalaireSTGB.InnerText = XmlNb(CnExecuting("select isnull(sum(mtBrutTraitementSalaire),0) from IR_Stagiaires  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value)
        totalMtBrutIndemnitesSTGB.InnerText = XmlNb(CnExecuting("select isnull(sum(mtBrutIndemnites),0) from IR_Stagiaires  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value)
        totalMtRetenuesSTGB.InnerText = XmlNb(CnExecuting("select isnull(sum(mtRetenues),0) from IR_Stagiaires  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value)
        totalMtRevenuNetImpSTGB.InnerText = XmlNb(CnExecuting("select isnull(sum(mtRevenuNetImposable),0) from IR_Stagiaires  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value)
        montantPermanentB.InnerText = XmlNb(CnExecuting("select isnull(sum(mtBrutTraitementSalaire),0) from IR_Permanents  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value)
        montantOccasionnelB.InnerText = XmlNb(CnExecuting("select isnull(sum(mtBrutSommes),0) from IR_Occasionnels  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value)
        montantStagiaireB.InnerText = XmlNb(CnExecuting("select isnull(sum(mtBrutTraitementSalaire),0) from IR_Stagiaires  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value)
        totalSommePayeRTSB.InnerText = XmlNb(CnExecuting("select isnull(sum(mtBrutTraitementSalaire),0) from IR_Stagiaires  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value + CnExecuting("select isnull(sum(mtBrutSommes),0) from IR_Occasionnels  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value + CnExecuting("select isnull(sum(mtBrutTraitementSalaire),0) from IR_Permanents  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value)
        totalmtAnuuelRevenuSalarialB.InnerText = 0 'montantPermanentB.InnerText + montantOccasionnelB.InnerText + montantStagiaireB.InnerText
        totalmtAbondementB.InnerText = XmlNb(CnExecuting("select isnull(sum(mtAbondement),0) from IR_Beneficiaires  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "'").Fields(0).Value)

        XmlLiasse.DocumentElement.AppendChild(identifiantFiscalB)
        XmlLiasse.DocumentElement.AppendChild(nomB)
        XmlLiasse.DocumentElement.AppendChild(prenomB)
        XmlLiasse.DocumentElement.AppendChild(raisonSocialeB)
        XmlLiasse.DocumentElement.AppendChild(exerciceFiscalDuB)
        XmlLiasse.DocumentElement.AppendChild(exerciceFiscalAuB)
        XmlLiasse.DocumentElement.AppendChild(anneeB)
        'XmlLiasse.DocumentElement.AppendChild(formeJuridiqueB)
        XmlLiasse.DocumentElement.AppendChild(communeB)
        'XmlLiasse.DocumentElement.AppendChild(professionB)
        XmlLiasse.DocumentElement.AppendChild(adresseB)
        XmlLiasse.DocumentElement.AppendChild(numeroCINB)
        XmlLiasse.DocumentElement.AppendChild(numeroCNSSB)
        XmlLiasse.DocumentElement.AppendChild(numeroCEB)

        XmlLiasse.DocumentElement.AppendChild(numeroRCB)
        XmlLiasse.DocumentElement.AppendChild(identifiantTPB)
        XmlLiasse.DocumentElement.AppendChild(numeroFaxB)
        XmlLiasse.DocumentElement.AppendChild(numeroTelephoneB)
        XmlLiasse.DocumentElement.AppendChild(emailB)
        XmlLiasse.DocumentElement.AppendChild(effectifTotalB)
        XmlLiasse.DocumentElement.AppendChild(nbrPersoPermanentB)
        XmlLiasse.DocumentElement.AppendChild(nbrPersoOccasionnelB)
        XmlLiasse.DocumentElement.AppendChild(nbrStagiairesB)
        XmlLiasse.DocumentElement.AppendChild(totalMtRevenuBrutImposablePPB)
        XmlLiasse.DocumentElement.AppendChild(totalMtRevenuNetImposablePPB)
        XmlLiasse.DocumentElement.AppendChild(totalMtTotalDeductionPPB)
        XmlLiasse.DocumentElement.AppendChild(totalMtIrPrelevePPB)
        XmlLiasse.DocumentElement.AppendChild(totalMtBrutSommesPOB)
        XmlLiasse.DocumentElement.AppendChild(totalIrPrelevePOB)
        XmlLiasse.DocumentElement.AppendChild(totalMtBrutTraitSalaireSTGB)
        XmlLiasse.DocumentElement.AppendChild(totalMtBrutIndemnitesSTGB)
        XmlLiasse.DocumentElement.AppendChild(totalMtRetenuesSTGB)
        XmlLiasse.DocumentElement.AppendChild(totalMtRevenuNetImpSTGB)
        XmlLiasse.DocumentElement.AppendChild(totalSommePayeRTSB)

        XmlLiasse.DocumentElement.AppendChild(totalmtAnuuelRevenuSalarialB)
        XmlLiasse.DocumentElement.AppendChild(totalmtAbondementB)

        XmlLiasse.DocumentElement.AppendChild(montantPermanentB)
        XmlLiasse.DocumentElement.AppendChild(montantOccasionnelB)
        XmlLiasse.DocumentElement.AppendChild(montantStagiaireB)

        If NbPERM > 0 Then
            listPersonnelPermanentB = XmlLiasse.CreateElement("listPersonnelPermanent")
            PersonnelPermanent()

            If ErrXml = 1 Then
                ErrXml = 0
                Exit Sub
            End If

            XmlLiasse.DocumentElement.AppendChild(listPersonnelPermanentB)
        End If
        If NbExo > 0 And Maj2017 Then
            listPersonnelExonereB = XmlLiasse.CreateElement("listPersonnelExonere")
            listExonores()

            XmlLiasse.DocumentElement.AppendChild(listPersonnelExonereB)
        End If

        If NbOCCAS > 0 Then
            listPersonnelOccasionnelB = XmlLiasse.CreateElement("listPersonnelOccasionnel")
            listPersonnelOccasionnel()

            XmlLiasse.DocumentElement.AppendChild(listPersonnelOccasionnelB)
        End If
        If NbSTAG > 0 Then
            listStagiairesB = XmlLiasse.CreateElement("listStagiaires")
            listStagiaires()

            XmlLiasse.DocumentElement.AppendChild(listStagiairesB)
        End If
        If NbDoc > 0 And Maj2017 Then
            listDoctorantsB = XmlLiasse.CreateElement("listDoctorants")
            listDoctorants()

            XmlLiasse.DocumentElement.AppendChild(listDoctorantsB)
        End If
        If NbBen > 0 Then
            listBeneficiairesB = XmlLiasse.CreateElement("listBeneficiaires")
            listBeneficiaires()

            XmlLiasse.DocumentElement.AppendChild(listBeneficiairesB)
        End If
        If NbVer > 0 Then
            listVersementsB = XmlLiasse.CreateElement("listVersements")
            listVersements()

            XmlLiasse.DocumentElement.AppendChild(listVersementsB)
        End If

        ' Dim w As New XmlTextWriter(FichierXML, Encoding.GetEncoding("UTF-8")) 'With {.Formatting = Formatting.Indented}
        Dim w As New IO.StreamWriter(FichierXML, False)
        XmlLiasse.Save(w)
        w.Close()
        Interaction.MsgBox("Enregistrement reussi", MsgBoxStyle.ApplicationModal, Nothing)
        If openXml_chk.Checked Then
            StartPrograme(FichierXML)
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub PersonnelPermanent()
        Dim cod_sql As String = ""
        Dim otbl As DataTable
        cod_sql = "SELECT     isnull(nom,'') as nom,ISNULL(prenom,'') prenom, isnull(adressePersonnelle,'') adressePersonnelle, 
isnull(numCNI,'') as numCNI, isnull(numCE,'') numCE,ISNULL(numPPR,'') numPPR,ISNULL(numCNSS,'') numCNSS,
ISNULL( ifu,0) as ifu,ISNULL(mtBrutTraitementSalaire,0) mtBrutTraitementSalaire, 
isnull(periodejours,0) periodejours,isnull(mtExonere,0) mtExonere,ISNULL(mtEcheances,0) mtEcheances, 
isnull(nbrReductions,0)nbrReductions,ISNULL(mtReductions,0) mtReductions,ISNULL(mtIndemnite,0) mtIndemnite, 
isnull(mtAvantages,0)mtAvantages,ISNULL(mtRevenuBrutImposable,0) mtRevenuBrutImposable,ISNULL(mtFraisProfess,0) mtFraisProfess, 
isnull(mtCotisationAssur,0) mtCotisationAssur, isnull(mtAutresRetenues,0) mtAutresRetenues,
ISNULL(mtRevenuNetImposable,0) mtRevenuNetImposable, isnull(mtTotalDeduction,0) mtTotalDeduction, 
isnull(irPreleve,0) irPreleve, isnull(numMatricule,'') numMatricule, isnull(datePermis,'')datePermis,
ISNULL( dateAutorisation,'') dateAutorisation, isnull(refSituationFamiliale,'')refSituationFamiliale, 
isnull(refTaux,'0') refTaux, isnull(salaireBaseAnnuel,0) salaireBaseAnnuel, isnull(Source,'') Source
FROM         IR_Permanents  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "' order by Clef"

        otbl = DATA_READER_GRD(cod_sql)
        For i = 0 To otbl.Rows.Count - 1
            Dim PersonnelPermanent As XmlElement = XmlLiasse.CreateElement("PersonnelPermanent")
            Dim nomB As XmlElement = XmlLiasse.CreateElement("nom")
            Dim prenomB As XmlElement = XmlLiasse.CreateElement("prenom")
            Dim adressePersonnelleB As XmlElement = XmlLiasse.CreateElement("adressePersonnelle")
            Dim numCNIB As XmlElement = XmlLiasse.CreateElement("numCNI")
            Dim numCEB As XmlElement = XmlLiasse.CreateElement("numCE")
            Dim numPPRB As XmlElement = XmlLiasse.CreateElement("numPPR")
            Dim numCNSSB As XmlElement = XmlLiasse.CreateElement("numCNSS")
            Dim ifuB As XmlElement = XmlLiasse.CreateElement("ifu")
            Dim mtBrutTraitementSalaireB As XmlElement = XmlLiasse.CreateElement("mtBrutTraitementSalaire")
            Dim periodeB As XmlElement = XmlLiasse.CreateElement("periode")
            Dim mtExonereB As XmlElement = XmlLiasse.CreateElement("mtExonere")
            Dim mtEcheancesB As XmlElement = XmlLiasse.CreateElement("mtEcheances")
            Dim nbrReductionsB As XmlElement = XmlLiasse.CreateElement("nbrReductions")
            Dim mtIndemniteB As XmlElement = XmlLiasse.CreateElement("mtIndemnite")
            Dim mtAvantagesB As XmlElement = XmlLiasse.CreateElement("mtAvantages")
            Dim mtRevenuBrutImposableB As XmlElement = XmlLiasse.CreateElement("mtRevenuBrutImposable")
            Dim mtFraisProfessB As XmlElement = XmlLiasse.CreateElement("mtFraisProfess")
            Dim mtCotisationAssurB As XmlElement = XmlLiasse.CreateElement("mtCotisationAssur")
            Dim mtAutresRetenuesB As XmlElement = XmlLiasse.CreateElement("mtAutresRetenues")
            Dim mtRevenuNetImposableB As XmlElement = XmlLiasse.CreateElement("mtRevenuNetImposable")
            Dim salaireBaseAnnuelB As XmlElement = XmlLiasse.CreateElement("salaireBaseAnnuel")
            Dim mtTotalDeductionB As XmlElement = XmlLiasse.CreateElement("mtTotalDeduction")
            Dim irPreleveB As XmlElement = XmlLiasse.CreateElement("irPreleve")
            Dim casSportifB As XmlElement = XmlLiasse.CreateElement("casSportif")
            Dim numMatriculeB As XmlElement = XmlLiasse.CreateElement("numMatricule")
            Dim datePermisB As XmlElement = XmlLiasse.CreateElement("datePermis")
            Dim dateAutorisationB As XmlElement = XmlLiasse.CreateElement("dateAutorisation")
            Dim refSituationFamilialeB As XmlElement = XmlLiasse.CreateElement("refSituationFamiliale")
            Dim codeB As XmlElement = XmlLiasse.CreateElement("code")
            codeB.InnerText = otbl.Rows(i).Item("refSituationFamiliale") 'C : Celeba, M : Marie,V : Veuf,D: Divorcé
            refSituationFamilialeB.AppendChild(codeB)
            Dim refTauxB As XmlElement = XmlLiasse.CreateElement("refTaux")
            Dim codeB1 As XmlElement = XmlLiasse.CreateElement("code")

            If IsNull(Societe.Cod_TFP, "") = "" Then
                ShowMessageBox("Taux frais professionelle obligatoire")
                Exit Sub
            End If
            codeB1.InnerText = Societe.Cod_TFP  'CAS 20% 'otbl.Rows(i).Item("refTaux")
            refTauxB.AppendChild(codeB1)

            ' Balise element exonore
            Dim listElementsExonereB As XmlElement = Nothing

            Dim MtExo As Double
            Dim NbExono As Integer
            NbExono = CnExecuting("Select count(*) from IR_Permanent_Exoneres  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "' and Matricule='" & otbl.Rows(i).Item("numMatricule") & "'").Fields(0).Value

            If Maj2017 Then
                listElementsExonereB = XmlLiasse.CreateElement("listElementsExonere")
                Dim cod_sqlX As String = ""
                Dim otblX As DataTable
                cod_sqlX = "select * from IR_Permanent_Exoneres    where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "' and Matricule='" & otbl.Rows(i).Item("numMatricule") & "' order by Clef"
                otblX = DATA_READER_GRD(cod_sqlX)
                For j = 0 To otblX.Rows.Count - 1
                    Dim ElementExonerePPB As XmlElement = XmlLiasse.CreateElement("ElementExonerePP")
                    Dim montantExonereB As XmlElement = XmlLiasse.CreateElement("montantExonere")
                    montantExonereB.InnerText = "0"
                    Dim refNatureElementExonereB As XmlElement = XmlLiasse.CreateElement("refNatureElementExonere")
                    Dim codeBX As XmlElement = XmlLiasse.CreateElement("code")
                    codeBX.InnerText = XmlStr(otblX.Rows(j).Item("refNatureElementExonere"))
                    montantExonereB.InnerText = XmlNb(otblX.Rows(j).Item("montantExonere"))
                    refNatureElementExonereB.AppendChild(codeBX)
                    ElementExonerePPB.AppendChild(montantExonereB)
                    ElementExonerePPB.AppendChild(refNatureElementExonereB)
                    listElementsExonereB.AppendChild(ElementExonerePPB)
                Next
            End If
            nomB.InnerText = XmlStr(otbl.Rows(i).Item("nom"))
            prenomB.InnerText = XmlStr(otbl.Rows(i).Item("prenom"))
            adressePersonnelleB.InnerText = otbl.Rows(i).Item("adressePersonnelle")
            numCNIB.InnerText = XmlStr(otbl.Rows(i).Item("numCNI"))
            numCEB.InnerText = XmlStr(otbl.Rows(i).Item("numCE"))
            numPPRB.InnerText = XmlStr(otbl.Rows(i).Item("numPPR"))
            numCNSSB.InnerText = XmlStr(otbl.Rows(i).Item("numCNSS"))
            ifuB.InnerText = XmlStr(otbl.Rows(i).Item("ifu"))
            mtBrutTraitementSalaireB.InnerText = XmlNb(otbl.Rows(i).Item("mtBrutTraitementSalaire"))
            periodeB.InnerText = XmlNb(otbl.Rows(i).Item("periodejours"))


            mtExonereB.InnerText = XmlNb(otbl.Rows(i).Item("mtExonere"))
            If Maj2017 Then
                MtExo = IsNull(CnExecuting("select sum(isnull(montantExonere,0)) from IR_Permanent_Exoneres  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "' and Matricule='" & otbl.Rows(i).Item("numMatricule") & "'").Fields(0).Value, 0)
                If MtExo <> otbl.Rows(i).Item("mtExonere") Then
                    MsgBox("Ecart :  Total des elements exoneres  " & MtExo & " different au Mt exonere " & otbl.Rows(i).Item("mtExonere") & "  Matricule :   " & otbl.Rows(i).Item("numMatricule"))
                    ErrXml = 1
                    Exit Sub
                End If
            End If
            mtEcheancesB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtEcheances"), 0))
            nbrReductionsB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("nbrReductions"), 0))
            mtIndemniteB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtIndemnite"), 0))
            mtAvantagesB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtAvantages"), 0))
            mtRevenuBrutImposableB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtRevenuBrutImposable"), 0))
            mtFraisProfessB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtFraisProfess"), 0))
            mtCotisationAssurB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtCotisationAssur"), 0))
            mtAutresRetenuesB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtAutresRetenues"), 0))
            mtRevenuNetImposableB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtRevenuNetImposable"), 0))
            mtTotalDeductionB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtTotalDeduction"), 0))
            irPreleveB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("irPreleve"), 0))

            salaireBaseAnnuelB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("salaireBaseAnnuel"), 0))

            casSportifB.InnerText = "false"
            numMatriculeB.InnerText = otbl.Rows(i).Item("numMatricule")
            datePermisB.InnerText = XmlDate(otbl.Rows(i).Item("datePermis"))
            dateAutorisationB.InnerText = XmlDate(otbl.Rows(i).Item("dateAutorisation"))



            PersonnelPermanent.AppendChild(nomB)
            PersonnelPermanent.AppendChild(prenomB)
            PersonnelPermanent.AppendChild(adressePersonnelleB)
            PersonnelPermanent.AppendChild(numCNIB)
            PersonnelPermanent.AppendChild(numCEB)
            PersonnelPermanent.AppendChild(numPPRB)
            PersonnelPermanent.AppendChild(numCNSSB)
            PersonnelPermanent.AppendChild(ifuB)

            If Maj2017 Then
                PersonnelPermanent.AppendChild(salaireBaseAnnuelB)
            End If

            PersonnelPermanent.AppendChild(mtBrutTraitementSalaireB)
            PersonnelPermanent.AppendChild(periodeB)
            PersonnelPermanent.AppendChild(mtExonereB)
            PersonnelPermanent.AppendChild(mtEcheancesB)
            PersonnelPermanent.AppendChild(nbrReductionsB)
            PersonnelPermanent.AppendChild(mtIndemniteB)
            PersonnelPermanent.AppendChild(mtAvantagesB)
            PersonnelPermanent.AppendChild(mtRevenuBrutImposableB)
            PersonnelPermanent.AppendChild(mtFraisProfessB)
            PersonnelPermanent.AppendChild(mtCotisationAssurB)
            PersonnelPermanent.AppendChild(mtAutresRetenuesB)
            PersonnelPermanent.AppendChild(mtRevenuNetImposableB)
            PersonnelPermanent.AppendChild(mtTotalDeductionB)
            PersonnelPermanent.AppendChild(irPreleveB)
            PersonnelPermanent.AppendChild(casSportifB)
            PersonnelPermanent.AppendChild(numMatriculeB)
            PersonnelPermanent.AppendChild(datePermisB)
            PersonnelPermanent.AppendChild(dateAutorisationB)
            PersonnelPermanent.AppendChild(refSituationFamilialeB)

            PersonnelPermanent.AppendChild(refTauxB)
            If NbExono > 0 And Maj2017 Then
                PersonnelPermanent.AppendChild(listElementsExonereB)
            End If
            listPersonnelPermanentB.AppendChild(PersonnelPermanent)

        Next
    End Sub
    Private Sub listStagiaires()

        Dim cod_sql As String = ""
        Dim otbl As DataTable
        cod_sql = "Select * from IR_Stagiaires  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "' order by Clef"
        otbl = DATA_READER_GRD(cod_sql)
        For i = 0 To otbl.Rows.Count - 1

            Dim Stagiaire As XmlElement = XmlLiasse.CreateElement("Stagiaire")
            Dim nomB As XmlElement = XmlLiasse.CreateElement("nom")
            Dim prenomB As XmlElement = XmlLiasse.CreateElement("prenom")
            Dim adressePersonnelleB As XmlElement = XmlLiasse.CreateElement("adressePersonnelle")
            Dim numCNIB As XmlElement = XmlLiasse.CreateElement("numCNI")
            Dim numCEB As XmlElement = XmlLiasse.CreateElement("numCE")
            'Dim numPPRB As XmlElement = XmlLiasse.CreateElement("numPPR")
            Dim numCNSSB As XmlElement = XmlLiasse.CreateElement("numCNSS")
            Dim ifuB As XmlElement = XmlLiasse.CreateElement("ifu")
            Dim mtBrutTraitementSalaireB As XmlElement = XmlLiasse.CreateElement("mtBrutTraitementSalaire")

            Dim mtBrutIndemnitesB As XmlElement = XmlLiasse.CreateElement("mtBrutIndemnites")
            Dim mtRetenuesB As XmlElement = XmlLiasse.CreateElement("mtRetenues")
            Dim mtRevenuNetImposableB As XmlElement = XmlLiasse.CreateElement("mtRevenuNetImposable")
            Dim periodeB As XmlElement = XmlLiasse.CreateElement("periode")

            nomB.InnerText = XmlStr(otbl.Rows(i).Item("nom"))
            prenomB.InnerText = XmlStr(otbl.Rows(i).Item("prenom"))
            adressePersonnelleB.InnerText = XmlStr(otbl.Rows(i).Item("adressePersonnelle"))
            numCNIB.InnerText = XmlStr(otbl.Rows(i).Item("numCNI"))
            numCEB.InnerText = XmlStr(otbl.Rows(i).Item("numCE"))
            'numPPRB.InnerText = XmlStr(otbl.Rows(i).Item("numPPR"))
            numCNSSB.InnerText = XmlStr(otbl.Rows(i).Item("numCNSS"))
            ifuB.InnerText = XmlStr(otbl.Rows(i).Item("ifu"))
            mtBrutTraitementSalaireB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtBrutTraitementSalaire"), 0))
            mtBrutIndemnitesB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtBrutIndemnites"), 0))
            mtRetenuesB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtRetenues"), 0))
            mtRevenuNetImposableB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtRevenuNetImposable"), 0))
            periodeB.InnerText = XmlPeriode(IsNull(otbl.Rows(i).Item("periodejours"), 0))



            Stagiaire.AppendChild(nomB)
            Stagiaire.AppendChild(prenomB)
            Stagiaire.AppendChild(adressePersonnelleB)
            Stagiaire.AppendChild(numCNIB)
            Stagiaire.AppendChild(numCEB)
            'Stagiaire.AppendChild(numPPRB)
            Stagiaire.AppendChild(numCNSSB)
            Stagiaire.AppendChild(ifuB)
            Stagiaire.AppendChild(mtBrutTraitementSalaireB)
            Stagiaire.AppendChild(mtBrutIndemnitesB)
            Stagiaire.AppendChild(mtRetenuesB)
            Stagiaire.AppendChild(mtRevenuNetImposableB)
            Stagiaire.AppendChild(periodeB)
            listStagiairesB.AppendChild(Stagiaire)

        Next
    End Sub
    Private Sub listExonores()

        Dim cod_sql As String = ""
        Dim otbl As DataTable
        cod_sql = "Select * from IR_Exoneres  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "' order by Clef"
        otbl = DATA_READER_GRD(cod_sql)
        For i = 0 To otbl.Rows.Count - 1

            Dim PersonnelExonere As XmlElement = XmlLiasse.CreateElement("PersonnelExonere")
            Dim nomB As XmlElement = XmlLiasse.CreateElement("nom")
            Dim prenomB As XmlElement = XmlLiasse.CreateElement("prenom")
            Dim adressePersonnelleB As XmlElement = XmlLiasse.CreateElement("adressePersonnelle")
            Dim numCNIB As XmlElement = XmlLiasse.CreateElement("numCNI")
            Dim numCEB As XmlElement = XmlLiasse.CreateElement("numCE")
            Dim numCNSSB As XmlElement = XmlLiasse.CreateElement("numCNSS")
            Dim ifuB As XmlElement = XmlLiasse.CreateElement("ifu")
            Dim PeriodeB As XmlElement = XmlLiasse.CreateElement("periode")
            Dim dateRecrutementB As XmlElement = XmlLiasse.CreateElement("dateRecrutement")
            Dim mtBrutTraitementSalaireB As XmlElement = XmlLiasse.CreateElement("mtBrutTraitementSalaire")
            Dim mtIndemniteArgentNatureB As XmlElement = XmlLiasse.CreateElement("mtIndemniteArgentNature")
            Dim mtIndemniteFraisProB As XmlElement = XmlLiasse.CreateElement("mtIndemniteFraisPro")
            Dim mtRevenuBrutImposableB As XmlElement = XmlLiasse.CreateElement("mtRevenuBrutImposable")
            Dim mtRetenuesOpereesB As XmlElement = XmlLiasse.CreateElement("mtRetenuesOperees")
            Dim mtRevenuNetImposableB As XmlElement = XmlLiasse.CreateElement("mtRevenuNetImposable")


            nomB.InnerText = XmlStr(otbl.Rows(i).Item("nom"))
            prenomB.InnerText = XmlStr(otbl.Rows(i).Item("prenom"))
            adressePersonnelleB.InnerText = XmlStr(otbl.Rows(i).Item("adressePersonnelle"))
            numCNIB.InnerText = XmlStr(otbl.Rows(i).Item("numCNI"))
            numCEB.InnerText = XmlStr(otbl.Rows(i).Item("numCE"))
            numCNSSB.InnerText = XmlStr(otbl.Rows(i).Item("numCNSS"))
            ifuB.InnerText = XmlStr(otbl.Rows(i).Item("ifu"))
            PeriodeB.InnerText = Droite(Year(CDate(AnneePaieDu).ToString("yyyy-MM-dd")), 2)
            dateRecrutementB.InnerText = XmlDate(otbl.Rows(i).Item("dateRecrutement"))
            mtBrutTraitementSalaireB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtBrutTraitementSalaire"), 0))
            mtIndemniteArgentNatureB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtIndemniteArgentNature"), 0))
            mtIndemniteFraisProB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtIndemniteFraisPro"), 0))
            mtRevenuBrutImposableB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtRevenuBrutImposable"), 0))
            mtRetenuesOpereesB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtRetenuesOperees"), 0))
            mtRevenuNetImposableB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtRevenuNetImposable"), 0))



            PersonnelExonere.AppendChild(nomB)
            PersonnelExonere.AppendChild(prenomB)
            PersonnelExonere.AppendChild(adressePersonnelleB)
            PersonnelExonere.AppendChild(numCNIB)
            PersonnelExonere.AppendChild(numCEB)
            PersonnelExonere.AppendChild(numCNSSB)
            PersonnelExonere.AppendChild(ifuB)
            PersonnelExonere.AppendChild(PeriodeB)
            PersonnelExonere.AppendChild(dateRecrutementB)
            PersonnelExonere.AppendChild(mtBrutTraitementSalaireB)
            PersonnelExonere.AppendChild(mtIndemniteArgentNatureB)
            PersonnelExonere.AppendChild(mtIndemniteFraisProB)
            PersonnelExonere.AppendChild(mtRevenuBrutImposableB)
            PersonnelExonere.AppendChild(mtRetenuesOpereesB)
            PersonnelExonere.AppendChild(mtRevenuNetImposableB)

            listPersonnelExonereB.AppendChild(PersonnelExonere)

        Next
    End Sub

    Private Sub listDoctorants()

        Dim cod_sql As String = ""
        Dim otbl As DataTable
        cod_sql = "Select * from IR_Doctorants  where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "' order by Clef"
        otbl = DATA_READER_GRD(cod_sql)
        For i = 0 To otbl.Rows.Count - 1

            Dim Doctorant As XmlElement = XmlLiasse.CreateElement("Doctorant")
            Dim nomB As XmlElement = XmlLiasse.CreateElement("nom")
            Dim prenomB As XmlElement = XmlLiasse.CreateElement("prenom")
            Dim adressePersonnelleB As XmlElement = XmlLiasse.CreateElement("adressePersonnelle")
            Dim numCNIB As XmlElement = XmlLiasse.CreateElement("numCNI")
            Dim numCEB As XmlElement = XmlLiasse.CreateElement("numCE")
            Dim mtBrutIndemnitesB As XmlElement = XmlLiasse.CreateElement("mtBrutIndemnites")

            nomB.InnerText = XmlStr(otbl.Rows(i).Item("nom"))
            prenomB.InnerText = XmlStr(otbl.Rows(i).Item("prenom"))
            adressePersonnelleB.InnerText = XmlStr(otbl.Rows(i).Item("adressePersonnelle"))
            numCNIB.InnerText = XmlStr(otbl.Rows(i).Item("numCNI"))
            numCEB.InnerText = XmlStr(otbl.Rows(i).Item("numCE"))
            'numPPRB.InnerText = XmlStr(otbl.Rows(i).Item("numPPR"))
            mtBrutIndemnitesB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtBrutIndemnites"), 0))




            Doctorant.AppendChild(nomB)
            Doctorant.AppendChild(prenomB)
            Doctorant.AppendChild(adressePersonnelleB)
            Doctorant.AppendChild(numCNIB)
            Doctorant.AppendChild(numCEB)
            'Stagiaire.AppendChild(numPPRB)


            Doctorant.AppendChild(mtBrutIndemnitesB)

            listDoctorantsB.AppendChild(Doctorant)

        Next
    End Sub


    Private Sub listPersonnelOccasionnel()
        Dim cod_sql As String = ""
        Dim otbl As DataTable
        cod_sql = "Select * from IR_Occasionnels    where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "' order by Clef"
        otbl = DATA_READER_GRD(cod_sql)
        For i = 0 To otbl.Rows.Count - 1
            Dim PersonnelOccasionnel As XmlElement = XmlLiasse.CreateElement("PersonnelOccasionnel")
            Dim nomB As XmlElement = XmlLiasse.CreateElement("nom")
            Dim prenomB As XmlElement = XmlLiasse.CreateElement("prenom")
            Dim adressePersonnelleB As XmlElement = XmlLiasse.CreateElement("adressePersonnelle")
            Dim numCNIB As XmlElement = XmlLiasse.CreateElement("numCNI")
            Dim numCEB As XmlElement = XmlLiasse.CreateElement("numCE")
            'Dim numPPRB As XmlElement = XmlLiasse.CreateElement("numPPR")
            'Dim numCNSSB As XmlElement = XmlLiasse.CreateElement("numCNSS")
            Dim ifuB As XmlElement = XmlLiasse.CreateElement("ifu")
            Dim mtBrutSommesB As XmlElement = XmlLiasse.CreateElement("mtBrutSommes")
            Dim irPreleveB As XmlElement = XmlLiasse.CreateElement("irPreleve")
            Dim profession As XmlElement = XmlLiasse.CreateElement("profession")

            nomB.InnerText = otbl.Rows(i).Item("nom")
            prenomB.InnerText = otbl.Rows(i).Item("prenom")
            adressePersonnelleB.InnerText = otbl.Rows(i).Item("adressePersonnelle")
            numCNIB.InnerText = otbl.Rows(i).Item("numCNI")
            numCEB.InnerText = otbl.Rows(i).Item("numCE")
            'numPPRB.InnerText = otbl.Rows(i).Item("numPPR")
            'numCNSSB.InnerText = otbl.Rows(i).Item("numCNSS")
            ifuB.InnerText = otbl.Rows(i).Item("ifu")
            mtBrutSommesB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("mtBrutSommes"), 0))
            irPreleveB.InnerText = XmlNb(IsNull(otbl.Rows(i).Item("irPreleve"), 0))
            profession.InnerText = otbl.Rows(i).Item("profession")


            PersonnelOccasionnel.AppendChild(nomB)
            PersonnelOccasionnel.AppendChild(prenomB)
            PersonnelOccasionnel.AppendChild(adressePersonnelleB)
            PersonnelOccasionnel.AppendChild(numCNIB)
            PersonnelOccasionnel.AppendChild(numCEB)
            'PersonnelOccasionnel.AppendChild(numPPRB)
            'PersonnelOccasionnel.AppendChild(numCNSSB)
            PersonnelOccasionnel.AppendChild(ifuB)
            PersonnelOccasionnel.AppendChild(mtBrutSommesB)
            PersonnelOccasionnel.AppendChild(irPreleveB)
            PersonnelOccasionnel.AppendChild(profession)
            listPersonnelOccasionnelB.AppendChild(PersonnelOccasionnel)
        Next
    End Sub
    Private Sub listBeneficiaires()
        Dim cod_sql As String = ""
        Dim otbl As DataTable
        cod_sql = "Select * from IR_BENEFICIAIRES    where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "' order by Clef"
        otbl = DATA_READER_GRD(cod_sql)
        For i = 0 To otbl.Rows.Count - 1

            Dim Beneficiaire As XmlElement = XmlLiasse.CreateElement("Beneficiaire")
            Dim nomB As XmlElement = XmlLiasse.CreateElement("nom")
            Dim prenomB As XmlElement = XmlLiasse.CreateElement("prenom")
            Dim adressePersonnelleB As XmlElement = XmlLiasse.CreateElement("adressePersonnelle")
            Dim numCNIB As XmlElement = XmlLiasse.CreateElement("numCNI")
            Dim numCEB As XmlElement = XmlLiasse.CreateElement("numCE")
            ' Dim numPPRB As XmlElement = XmlLiasse.CreateElement("numPPR")
            Dim numCNSSB As XmlElement = XmlLiasse.CreateElement("numCNSS")
            Dim ifuB As XmlElement = XmlLiasse.CreateElement("ifu")
            Dim organismeB As XmlElement = XmlLiasse.CreateElement("organisme")
            Dim nbrActionsAcquisesB As XmlElement = XmlLiasse.CreateElement("nbrActionsAcquises")
            Dim nbrActionsDistribueesB As XmlElement = XmlLiasse.CreateElement("nbrActionsDistribuees")
            Dim prixAcquisitionB As XmlElement = XmlLiasse.CreateElement("prixAcquisition")
            Dim valeurActionAttributionB As XmlElement = XmlLiasse.CreateElement("valeurActionAttribution")
            Dim valeurActionLeveeOptionB As XmlElement = XmlLiasse.CreateElement("valeurActionLeveeOption")
            Dim mtAbondementB As XmlElement = XmlLiasse.CreateElement("mtAbondement")
            Dim nbrActionsCedeesB As XmlElement = XmlLiasse.CreateElement("nbrActionsCedees")
            Dim complementSalaireB As XmlElement = XmlLiasse.CreateElement("complementSalaire")
            Dim dateAttributionB As XmlElement = XmlLiasse.CreateElement("dateAttribution")
            Dim dateLeveOptionB As XmlElement = XmlLiasse.CreateElement("dateLeveOption")
            Dim dateCessionB As XmlElement = XmlLiasse.CreateElement("dateCession")


            nomB.InnerText = otbl.Rows(i).Item("nom")
            prenomB.InnerText = otbl.Rows(i).Item("prenom")
            adressePersonnelleB.InnerText = otbl.Rows(i).Item("adressePersonnelle")
            numCNIB.InnerText = otbl.Rows(i).Item("numCNI")
            numCEB.InnerText = otbl.Rows(i).Item("numCE")
            ' numPPRB.InnerText = otbl.Rows(i).Item("numPPR")
            numCNSSB.InnerText = otbl.Rows(i).Item("numCNSS")
            ifuB.InnerText = otbl.Rows(i).Item("ifu")
            organismeB.InnerText = otbl.Rows(i).Item("organisme")
            nbrActionsAcquisesB.InnerText = XmlNb(otbl.Rows(i).Item("nbrActionsAcquises"))
            nbrActionsDistribueesB.InnerText = XmlNb(otbl.Rows(i).Item("nbrActionsDistribuees"))
            prixAcquisitionB.InnerText = XmlNb(otbl.Rows(i).Item("prixAcquisition"))
            valeurActionAttributionB.InnerText = XmlNb(otbl.Rows(i).Item("valeurActionAttribution"))
            valeurActionLeveeOptionB.InnerText = XmlNb(otbl.Rows(i).Item("valeurActionLeveeOption"))
            mtAbondementB.InnerText = XmlNb(otbl.Rows(i).Item("mtAbondement"))
            nbrActionsCedeesB.InnerText = XmlNb(otbl.Rows(i).Item("nbrActionsCedees"))
            complementSalaireB.InnerText = XmlNb(otbl.Rows(i).Item("complementSalaire"))
            dateAttributionB.InnerText = XmlDate(otbl.Rows(i).Item("dateAttribution"))
            dateLeveOptionB.InnerText = XmlDate(otbl.Rows(i).Item("dateLeveOption"))
            dateCessionB.InnerText = XmlDate(otbl.Rows(i).Item("dateCession"))


            Beneficiaire.AppendChild(nomB)
            Beneficiaire.AppendChild(prenomB)
            Beneficiaire.AppendChild(adressePersonnelleB)
            Beneficiaire.AppendChild(numCNIB)
            Beneficiaire.AppendChild(numCEB)
            ' Beneficiaire.AppendChild(numPPRB)
            Beneficiaire.AppendChild(numCNSSB)
            Beneficiaire.AppendChild(ifuB)
            Beneficiaire.AppendChild(organismeB)
            Beneficiaire.AppendChild(nbrActionsAcquisesB)
            Beneficiaire.AppendChild(nbrActionsDistribueesB)
            Beneficiaire.AppendChild(prixAcquisitionB)
            Beneficiaire.AppendChild(valeurActionAttributionB)
            Beneficiaire.AppendChild(valeurActionLeveeOptionB)
            Beneficiaire.AppendChild(mtAbondementB)
            Beneficiaire.AppendChild(nbrActionsCedeesB)
            Beneficiaire.AppendChild(complementSalaireB)
            Beneficiaire.AppendChild(dateAttributionB)
            Beneficiaire.AppendChild(dateLeveOptionB)
            Beneficiaire.AppendChild(dateCessionB)
            listBeneficiairesB.AppendChild(Beneficiaire)
        Next
    End Sub
    Private Sub listVersements()
        Dim cod_sql As String = ""
        Dim otbl, otblE As DataTable
        cod_sql = "Select  mois, max(dateVersement) As dateDerniereVersment, sum(totalVerse) As totalVersement from IR_VERSEMENTS    where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "' group by mois order by mois"
        otblE = DATA_READER_GRD(cod_sql)
        For j = 0 To otblE.Rows.Count - 1

            Dim VersementTraitementSalaire As XmlElement = XmlLiasse.CreateElement("VersementTraitementSalaire")
            Dim moisB As XmlElement = XmlLiasse.CreateElement("mois")
            Dim dateDerniereVersmentB As XmlElement = XmlLiasse.CreateElement("dateDerniereVersment")
            Dim totalVersement As XmlElement = XmlLiasse.CreateElement("totalVersement")
            Dim listDetailPaiementB As XmlElement = XmlLiasse.CreateElement("listDetailPaiement")


            moisB.InnerText = otblE.Rows(j).Item("mois")
            totalVersement.InnerText = XmlNb(otblE.Rows(j).Item("totalVersement"))
            dateDerniereVersmentB.InnerText = XmlDate(otblE.Rows(j).Item("dateDerniereVersment"))
            VersementTraitementSalaire.AppendChild(moisB)
            VersementTraitementSalaire.AppendChild(totalVersement)

            VersementTraitementSalaire.AppendChild(dateDerniereVersmentB)
            cod_sql = "Select * from IR_VERSEMENTS    where id_Societe=" & Societe.id_Societe & " and Annee_Paie='" & Annee_Paie_cbo.SelectedValue & "' And mois= " & otblE.Rows(j).Item("mois") & " order by Clef"
            otbl = DATA_READER_GRD(cod_sql)
            For i = 0 To otbl.Rows.Count - 1
                Dim DetailPaiementTraitementSalaireB As XmlElement = XmlLiasse.CreateElement("DetailPaiementTraitementSalaire")
                Dim referenceB As XmlElement = XmlLiasse.CreateElement("reference")
                Dim totalVerseB As XmlElement = XmlLiasse.CreateElement("totalVerse")
                Dim principalB As XmlElement = XmlLiasse.CreateElement("principal")
                Dim penaliteB As XmlElement = XmlLiasse.CreateElement("penalite")
                Dim majorationsB As XmlElement = XmlLiasse.CreateElement("majorations")
                Dim dateVersementB As XmlElement = XmlLiasse.CreateElement("dateVersement")
                Dim refMoyenPaiementB As XmlElement = XmlLiasse.CreateElement("refMoyenPaiement")
                Dim codeB As XmlElement = XmlLiasse.CreateElement("code")
                codeB.InnerText = IsNull(otbl.Rows(i).Item("refMoyenPaiement"), Societe.Moyen_Paiement)
                refMoyenPaiementB.AppendChild(codeB)
                Dim numQuittanceB As XmlElement = XmlLiasse.CreateElement("numQuittance")



                ' listDetailPaiementB.InnerText = otbl.Rows(i).Item("listDetailPaiement")
                referenceB.InnerText = otbl.Rows(i).Item("reference")
                totalVerseB.InnerText = XmlNb(otbl.Rows(i).Item("totalVerse"))
                principalB.InnerText = XmlNb(otbl.Rows(i).Item("principal"))
                penaliteB.InnerText = XmlNb(otbl.Rows(i).Item("penalite"))
                majorationsB.InnerText = XmlNb(otbl.Rows(i).Item("majorations"))
                dateVersementB.InnerText = XmlDate(otbl.Rows(i).Item("dateVersement"))
                numQuittanceB.InnerText = otbl.Rows(i).Item("numQuittance")


                DetailPaiementTraitementSalaireB.AppendChild(referenceB)
                DetailPaiementTraitementSalaireB.AppendChild(totalVerseB)
                DetailPaiementTraitementSalaireB.AppendChild(principalB)
                DetailPaiementTraitementSalaireB.AppendChild(penaliteB)
                DetailPaiementTraitementSalaireB.AppendChild(majorationsB)
                DetailPaiementTraitementSalaireB.AppendChild(dateVersementB)
                DetailPaiementTraitementSalaireB.AppendChild(refMoyenPaiementB)
                'VersementTraitementSalaire.AppendChild(DetailPaiementTraitementSalaireB)
                DetailPaiementTraitementSalaireB.AppendChild(numQuittanceB)
                listDetailPaiementB.AppendChild(DetailPaiementTraitementSalaireB)
            Next
            VersementTraitementSalaire.AppendChild(listDetailPaiementB)

            listVersementsB.AppendChild(VersementTraitementSalaire)
        Next
    End Sub

    Private Function XmlDate(ByVal Dtdb As Object) As String
        If Not Information.IsDate(RuntimeHelpers.GetObjectValue(Dtdb)) Then
            Return ""
        End If
        Return Convert.ToDateTime(Dtdb).ToString("yyyy-MM-dd")
    End Function
    Private Function XmlNb(ByVal Nb As String) As String
        Nb = IsNull(Nb, 0)
        If Information.IsDBNull(Nb) Then
            Return Convert.ToString(0)
        End If

        Nb = Strings.Replace(IsNull(Nb, 0), ".", ",")
        Nb = Strings.Replace(Convert.ToString(Math.Round(CDbl(Nb), 2)), ",", ".")
        Nb = Nb.Replace(" ", "")


        Return Nb


    End Function

    Private Function XmlPeriode(ByVal Nb As String) As String
        If Information.IsDBNull(Nb) Then
            Return Convert.ToString(0)
        End If
        Nb = Strings.Replace(Nb, ".", ",")
        Nb = Strings.Replace(Convert.ToString(Math.Round(CDbl(Nb), 0)), ",", ".")
        Nb = Nb.Replace(" ", "")
        Return Nb
    End Function
    Private Function XmlNbHono(ByVal Nb As String) As String
        If Information.IsDBNull(Nb) Then
            Return Convert.ToString(0)
        End If
        'Nb = Strings.Replace(Nb, ".", CStr(Module_General.strSepar))
        Nb = Strings.Replace(Nb, ".", ", ")
        Nb = Strings.Replace(CStr(Math.Round(CDbl(Nb), 2)), ",", ".")
        Nb = Nb.Replace(" ", "")
        If (Nb.IndexOf(".") <= 0) Then
            Nb = (Nb & ".0")
        End If
        Return Nb
    End Function
    Private Function XmlStr(ByVal Str As Object) As String
        If Information.IsDBNull(RuntimeHelpers.GetObjectValue(Str)) Then
            Str = ""
        End If
        Return Strings.Replace(Strings.Replace(Strings.Replace(Strings.Replace(Strings.Replace(Strings.Trim(Convert.ToString(Str)), "&", "et", 1, -1, CompareMethod.Binary), ", ", "", 1, -1, CompareMethod.Binary), ChrW(13), "", 1, -1, CompareMethod.Binary), Convert.ToString(Strings.Chr(&H92)), " ", 1, -1, CompareMethod.Binary), "'", "", 1, -1, CompareMethod.Binary)
    End Function

    Private XmlLiasse As XmlDocument = New XmlDocument
    Private listPersonnelPermanentB As XmlElement
    Private listPersonnelOccasionnelB As XmlElement
    Private listStagiairesB As XmlElement
    Private listPersonnelExonereB As XmlElement
    Private listBeneficiairesB As XmlElement
    Private listVersementsB As XmlElement
    '   Dim ChampsdeFromuleX, ChampsdeFromuleTxtX, ChampsCalculesX, ChampsCalculesValeurX As New ArrayList
    Private listDoctorantsB As XmlElement

    Private Sub Annuler_ud_Load(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        Me.Close()
    End Sub
End Class