Public Class Consultation_Audit_Espion
    Dim ChampsAudit As String = ""
    Private Sub Cod_Audit_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Audit_txt.TextChanged
        Dim Col_Audit_Upd As String = ""
        Dim Col_Audit_Ins As String = ""
        Dim Col_Audit_Del As String = ""
        ChampsAudit = ""
        Dim Tbl As DataTable = DATA_READER_GRD("select * from Param_Audit_Espion where Cod_Audit='" & Cod_Audit_txt.Text & "'")
        With Tbl
            If .Rows.Count > 0 Then
                Col_Audit_Upd = .Rows(0)("Col_Audit_Upd")
                Col_Audit_Ins = .Rows(0)("Col_Audit_Ins")
                Col_Audit_Del = .Rows(0)("Col_Audit_Del")
                table_Name_Text.Text = .Rows(0)("Table_Name")
            Else
                Champs_Table_Text.Text = ""
                Col_Audit_Upd = ""
                Col_Audit_Ins = ""
                Col_Audit_Del = ""
                table_Name_Text.Text = ""
            End If
        End With
        ChampsAudit &= IIf(Col_Audit_Upd = "", "", ";" & Col_Audit_Upd & ";")
        ChampsAudit &= IIf(Col_Audit_Del = "", "", ";" & Col_Audit_Del & ";")
        ChampsAudit &= IIf(Col_Audit_Ins = "", "", ";" & Col_Audit_Ins & ";")
        ChampsAudit = "'" & ChampsAudit.Replace(";", "','") & "'"
        UPD_chk.Checked = (Col_Audit_Upd <> "")
        UPD_chk.Enabled = (Col_Audit_Upd <> "")
        DEL_chk.Checked = (Col_Audit_Del <> "")
        DEL_chk.Enabled = (Col_Audit_Del <> "")
        INS_chk.Checked = (Col_Audit_Ins <> "")
        INS_chk.Enabled = (Col_Audit_Ins <> "")
    End Sub
    Sub Requesting()
        Try
            Dim swhere As String = " where table_Ref='" & table_Name_Text.Text & "' and Dat_Modif between '" & Dat_Deb.Value & "' and '" & Dat_Fin.Value & "' "
            Dim oper As String = IIf(UPD_chk.Checked, "'Modification'", "")
            oper &= IIf(DEL_chk.Checked, IIf(oper = "", "", ",") & "'Suppression'", "")
            oper &= IIf(INS_chk.Checked, IIf(oper = "", "", ",") & "'Ajout'", "")
            If oper <> "" Then
                swhere &= " and Operation in (" & oper & ") "
            End If
            If Champs_Table_Text.Text <> "" Then
                swhere &= " and Modified_Field ='" & Champs_Table_Text.Text & "' "
            End If
            If User_Text.Text <> "" Then
                swhere &= " and Modified_By ='" & User_Text.Text & "' "
            End If

            Dim SqlStr As String = "select id_Societe as 'N° Société',Den as 'Société',Table_Ref as 'Table', Val_Index as 'Enregistrement',Modified_Field as 'Champs d''audit', Operation as Opération
, isnull(Val_Avant,'') 'Valeur avant', Val_Apres 'Valeur après', Modified_By_Name 'Modifié par',
Dat_Modif 'Date', Modify_Host 'Host'
from Audit_Events a
outer apply(select Den from Param_Societe where id_Societe=a.id_Societe)s
" & swhere & " order by Dat_Modif desc,Modified_Field "

            Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
            With Audit_Grd
                .DataSource = Tbl
                .Columns("Champs d'audit").MinimumWidth = 200
                .setFilter({0, 1, 2, 3, 4, 5, 6})
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Param_Audit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dat_Deb.CustomFormat = "dd/MM/yyyy HH:mm"
        Dat_Deb.Format = DateTimePickerFormat.Custom
        Dat_Deb.Value = Now.AddDays(-30)
        Dat_Fin.CustomFormat = "dd/MM/yyyy HH:mm"
        Dat_Fin.Format = DateTimePickerFormat.Custom
        Dat_Fin.Value = Now.AddDays(1)
        With Audit_Grd
            .ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        End With
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS167", Cod_Audit_txt, Me)
    End Sub
    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Zoom1("MS003", User_Text, Me)
    End Sub
    Private Sub User_Text_TextChanged(sender As Object, e As EventArgs) Handles User_Text.TextChanged
        Nom_User_Text.Text = CStr(FindLibelle("Prenom_User+ ' ' + Nom_User", "Login_User", User_Text.Text, "Controle_Users"))
    End Sub
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Zoom("name", "name", "sys.columns", "object_name(object_id)='" & table_Name_Text.Text & "' and name in (" & ChampsAudit & ")", Champs_Table_Text, Me)
    End Sub
End Class