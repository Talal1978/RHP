Class mybtn_Signature
    Inherits ud_btn
    Friend frm As Form
    Friend tbl As DataTable
    Friend valeurIndex As String
    Dim _statut As String = ""
    Public Property Statut As String
        Get
            Return _statut
        End Get
        Set(value As String)
            _statut = value
            Select Case _statut
                Case "NSS"
                    Image = My.Resources.btn_sign_00
                Case "SS"
                    Image = My.Resources.btn_sign_01
                Case "SP"
                    Image = My.Resources.btn_sign_02
                Case "SG", "VA"
                    Image = My.Resources.btn_sign_03
                Case "RJ"
                    Image = My.Resources.btn_sign_04
            End Select

        End Set
    End Property
    Public Sub New(frm As Form, btnName As String, procName As String, _imgName As String)
        MyBase.New(frm, btnName, procName, _imgName)
    End Sub
End Class
Module Module_Workflow
    Public Tbl_Workflow_ParamDocuments

    Public Structure subSignatureData
        Public frm As Form
        Public statut As String
        Public tbl As DataTable
        Public valeurIndex As String
    End Structure
    Public Structure lic
        Public WorkFlow As Boolean
    End Structure

    Public LicenceJson As New lic
    Sub InitialisationWorfRulesSignature()
        LicenceJson.WorkFlow = True
        CnExecuting("exec Sys_Workflow_Suppleant")
        Tbl_Workflow_ParamDocuments = DATA_READER_GRD("select s.Typ_Document,Intitule , s.Table_Ref,Typ_Signature , s.Table_Index , Accepte_Detail , Name_Ecran , isnull(Actif,1) as Actif ,
isnull(Signataire_Defaut,'') Signataire_Defaut, isnull(Condition_Ecran,'') as Condition_Ecran , convert(bit,case when p.id_Societe is null then 0 else 1 end) Gere_Signature
, isnull(Index_Ecran,'') Index_Ecran, isnull(Champs_Proprietaire,'Matricule') as Champs_Proprietaire
from Param_Workflow_Typ_Document s 
outer apply(select * from Workflow_Signatures where Typ_Document=s.Typ_Document and id_Societe=isnull(nullif(s.id_Societe,-1),id_Societe)  and isnull(Actif,'false')='true')p
where  isnull(nullif(s.id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe)
    End Sub

#Region "Gestion du bouton de Signatures au niveau du menu"
    Sub SubSignatures(sender As mybtn_Signature, e As Object)
        If IsNull(sender.Statut, "NSS") = "NSS" Then
            Dim sRsl As savingResult = CallByName(sender.frm, "SoumettreEnSignature", CallType.Method)
            If Not sRsl.result Then
                ShowMessageBox(sRsl.message)
                Return
            End If
            CnExecuting("exec Sys_Workflow_Signature '" & sender.tbl.Rows(0)("Typ_Document") & "','" & Societe.id_Societe & "', '" & sender.valeurIndex & "','" & theUser.Matricule & "'")
            '   MsgBox("exec Sys_Workflow_Signature '" & sender.tbl.Rows(0)("Typ_Document") & "','" & Societe.id_Societe & "', '" & sender.valeurIndex & "','" & theUser.Matricule & "'")
            sender.Statut = "SS"
            sender.Text = " " & FindRubriques("Statut_Signature", sender.Statut)
            sender.Refresh()
        ElseIf IsNull(sender.Statut, "") = "VA" Then
            ShowMessageBox("Validé")
            Return
        End If
        Dim f As New Zoom_Signataires
        With f
            .btn_Signature = sender
            .ShowDialog()
        End With
        CallByName(sender.frm, "requestAfterSignature", CallType.Method)
    End Sub
#End Region
    Sub GestionDesSignatures(f As Ecran, ValeurIndex As String)
        'gestion des règles de signatures
        If f.dictButtons.ContainsKey("Signer_D") Then
            Dim btn_Signature = CType(f.dictButtons("Signer_D"), mybtn_Signature)
            btn_Signature.valeurIndex = ValeurIndex
            Dim Tbl As DataTable = btn_Signature.tbl
            If Tbl.Rows.Count = 0 Then Return
            Dim TypPie As String = IsNull(Tbl.Rows(0)("Typ_Document"), "")
            If TypPie = "" Then Return
            Dim Dt As DataTable = DATA_READER_GRD("select isnull(Statut,'NSS') as Statut from Signatures_Ent where Typ_Document='" & TypPie & "' and Valeur_Index='" & ValeurIndex & "' and id_Societe=" & Societe.id_Societe)
            Dim statut As String = IsNull(FindLibelle("Statut", Tbl.Rows(0)("Table_Index"), ValeurIndex, Tbl.Rows(0)("Table_Ref")), "NSS")
            If Dt.Rows.Count > 0 And statut <> "VA" Then
                statut = Dt.Rows(0)("Statut")
            End If
            btn_Signature.ToolTip = FindRubriques("Statut_Signature", statut)
            btn_Signature.Statut = statut
            btn_Signature.Visible = (statut <> "VA") And (estGereEnSignature(TypPie) And btn_Signature.valeurIndex <> "")
            btn_Signature.Enabled = (statut <> "NSS" Or theUser.Typ_Role <> "Agent" Or (theUser.Matricule = estProprietaire(TypPie, ValeurIndex)))
            btn_Signature.Refresh()
        End If
        If f.dictButtons.ContainsKey("Valide_D") Then
            With f.dictButtons("Valide_D")
                If f.dictButtons.ContainsKey("Signer_D") Then
                    .Visible = Not f.dictButtons("Signer_D").Visible And ValeurIndex <> ""
                Else
                    .Visible = True
                End If
            End With

        End If
    End Sub
    Function estGereEnSignature(TypPie As String) As Boolean
        Return (Tbl_Workflow_ParamDocuments.Select("Typ_Document='" & TypPie & "' and Gere_Signature=1").Length > 0 And CBool(LicenceJson.WorkFlow))
    End Function
    Function estSigne(TypPie As String, Indx As String) As Boolean
        Dim Rsl As String = CnExecuting("select isnull((select top 1 isnull(Statut,'NSS') from Signatures_Ent where id_Societe=" & Societe.id_Societe & "  and  Typ_Document='" & TypPie & "' and Valeur_Index='" & Indx & "'),'NSS')").Fields(0).Value
        Return ("SG;VA".Split(";").Contains(Rsl))
    End Function
    Function estRejete(TypPie As String, Indx As String) As Boolean
        Dim Rsl As String = CnExecuting("select isnull((select top 1 isnull(Statut,'NSS') from Signatures_Ent where id_Societe=" & Societe.id_Societe & "  and  Typ_Document='" & TypPie & "' and Valeur_Index='" & Indx & "'),'NSS')").Fields(0).Value
        Return (Rsl = "RJ")
    End Function
    Function estProprietaire(TypPie As String, Indx As String) As String
        Dim nrw() As DataRow = Tbl_Workflow_ParamDocuments.Select("Typ_Document='" & TypPie & "'")
        If nrw.Length = 0 Then Return True
        Dim TblRef As String = nrw(0)("Table_Ref")
        Dim TblIndx As String = nrw(0)("Table_Index")
        Dim ChampsProprietaire As String = IsNull(nrw(0)("Champs_Proprietaire"), "Matricule")
        Return CnExecuting("select isnull((select top 1 isnull(" & ChampsProprietaire & ",'') from " & TblRef & " where id_Societe=" & Societe.id_Societe & "  and  " & TblIndx & "='" & Indx & "'),'')").Fields(0).Value
    End Function
    Sub initialisationSuppleantWorkflow()

    End Sub
End Module
