Imports DevComponents.DotNetBar
Public Class Param_Audit
    Friend code As String = ""
    Dim Col_Audit_Upd As String = ""
    Dim Col_Audit_Ins As String = ""
    Dim Col_Audit_Del As String = ""
    Dim Audits_Espions As String = ""
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim New_D As ud_btn
    Private Sub Cod_Audit_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Audit_txt.TextChanged
        Dim Tbl As DataTable = DATA_READER_GRD("select * from Param_Audit_Espion where Cod_Audit='" & Cod_Audit_txt.Text & "'")
        Audits_Espions_lbl.Text = ""
        With Tbl
            If .Rows.Count > 0 Then

                Col_Audit_Upd = .Rows(0)("Col_Audit_Upd")
                Col_Audit_Ins = .Rows(0)("Col_Audit_Ins")
                Col_Audit_Del = .Rows(0)("Col_Audit_Del")
                Audits_Espions = .Rows(0)("Audits_Espions")
                table_Name_Text.Text = .Rows(0)("Table_Name")
                Dim aesp As String() = Audits_Espions.Split(";")
                For i = 0 To aesp.Length - 1
                    If aesp(i).Trim <> "" Then
                        Audits_Espions_lbl.Text &= vbCrLf & " ->   " & aesp(i).Trim
                    End If
                Next
            Else
                Index_Table_Text.Text = ""
                Audits_Espions_lbl.Text = ""
                Col_Audit_Upd = ""
                Col_Audit_Ins = ""
                Col_Audit_Del = ""
                Audits_Espions = ""
                table_Name_Text.Text = ""
            End If
        End With
        Audits_Espions_lbl.Refresh()
    End Sub
    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Zoom1("MS002", table_Name_Text, Me, "type='U'")
    End Sub
    Private Sub table_Name_Text_TextChanged(sender As Object, e As EventArgs) Handles table_Name_Text.TextChanged
        Index_Table_Text.Text = FindLibelle("Index_Table", "Table_Ref", table_Name_Text.Text, "Controle_Def_Ecran")
        Request()
    End Sub
    Sub Request()
        Dim SqlStr As String = "declare @upd nvarchar(max), @ins nvarchar(max), @del nvarchar(max)
            set @upd='" & Col_Audit_Upd & "'
            set @ins='" & Col_Audit_Ins & "'
            set @del='" & Col_Audit_Del & "'
            select name as Champs, convert(bit,case when @upd like '%'+name+'%' then 'true' else 'false' end) as 'Modification',
convert(bit,case when @ins like '%'+name+'%' then 'true' else 'false' end) as 'Ajout',
convert(bit,case when @del like '%'+name+'%' then 'true' else 'false' end) as 'Suppression'
  from sys.columns where object_name(object_id)='" & table_Name_Text.Text & "' and name<>'" & Index_Table_Text.Text & "' order by column_id"
        Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
        Tbl.Columns("Modification").ReadOnly = False
        Tbl.Columns("Ajout").ReadOnly = False
        Tbl.Columns("Suppression").ReadOnly = False
        With Audit_Grd
            .DataSource = Tbl
            .Columns("Champs").MinimumWidth = 400
            .Columns("Modification").MinimumWidth = 100
            .Columns("Ajout").MinimumWidth = 100
            .Columns("Suppression").MinimumWidth = 100
            .setFilter({0})
        End With
    End Sub

    Private Sub Param_Audit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Save_D = dictButtons("Save_D")
        Del_D = dictButtons("Del_D")
        New_D = dictButtons("New_D")
        With Audit_Grd
            .ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
        End With
    End Sub

    Function Saving() As Boolean
        If table_Name_Text.Text = "" Then
            MessageBox.Show("Table de référence non renseignée", "Vérification", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        If Index_Table_Text.Text = "" Then
            MessageBox.Show("Index de la table de référence non renseigné", "Vérification", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        If Audit_Grd.RowCount = 0 Then
            MessageBox.Show("Liste des champs vide", "Vérification", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        Col_Audit_Upd = ""
        Col_Audit_Ins = ""
        Col_Audit_Del = ""
        Audits_Espions = ""
        With Audit_Grd
            For i = 0 To .RowCount - 1
                If IsNull(.Item("Modification", i).Value, False) Then
                    Col_Audit_Upd &= IIf(Col_Audit_Upd = "", "", ";") & .Item("Champs", i).Value
                End If
                If IsNull(.Item("Ajout", i).Value, False) Then
                    Col_Audit_Ins &= IIf(Col_Audit_Ins = "", "", ";") & .Item("Champs", i).Value
                End If
                If IsNull(.Item("Suppression", i).Value, False) Then
                    Col_Audit_Del &= IIf(Col_Audit_Del = "", "", ";") & .Item("Champs", i).Value
                End If
            Next
        End With
        Try
            If Col_Audit_Upd <> "" Then
                CnExecuting("exec Sys_Generation_Audit_UPD '" & table_Name_Text.Text & "', '" & Col_Audit_Upd & "'")
                Audits_Espions = "ESP_" & table_Name_Text.Text & "_UPD"
            Else
                CnExecuting("if (select count(*) from sys.objects where name='ESP_" & table_Name_Text.Text & "_UPD' and type='TR')>0 begin drop trigger ESP_" & table_Name_Text.Text & "_UPD end")
            End If
        Catch ex As Exception
            MessageBoxEx.Show("Erreur Espion 'Modification'" & vbCrLf & ex.Message, "Espion 'Modification'", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

        Try
            If Col_Audit_Ins <> "" Then
                CnExecuting("exec Sys_Generation_Audit_INS '" & table_Name_Text.Text & "', '" & Col_Audit_Ins & "'")
                Audits_Espions &= IIf(Audits_Espions = "", "", ";") & "ESP_" & table_Name_Text.Text & "_INS"
            Else
                CnExecuting("if (select count(*) from sys.objects where name='ESP_" & table_Name_Text.Text & "_INS' and type='TR')>0 begin drop trigger ESP_" & table_Name_Text.Text & "_INS end")
            End If
        Catch ex As Exception
            MessageBoxEx.Show("Erreur Espion 'Ajout'" & vbCrLf & ex.Message, "Espion 'Ajout'", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        Try
            If Col_Audit_Del <> "" Then
                CnExecuting("exec Sys_Generation_Audit_DEL '" & table_Name_Text.Text & "', '" & Col_Audit_Del & "'")
                Audits_Espions &= IIf(Audits_Espions = "", "", ";") & "ESP_" & table_Name_Text.Text & "_DEL"
            Else
                CnExecuting("if (select count(*) from sys.objects where name='ESP_" & table_Name_Text.Text & "_DEL' and type='TR')>0 begin drop trigger ESP_" & table_Name_Text.Text & "_DEL end")
            End If
        Catch ex As Exception
            MessageBoxEx.Show("Erreur Espion 'Suppression'" & vbCrLf & ex.Message, "Espion 'Suppression'", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        Dim rs As New ADODB.Recordset
        Dim CodAudit As String = Cod_Audit_txt.Text
        rs.Open("select * from Param_Audit_Espion where Cod_Audit='" & CodAudit & "'", cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            CodAudit = "ESP" & Droite("0000" & CnExecuting("select isnull((select max(isnull(convert(int,right(Cod_Audit,4)),0))+1 from Param_Audit_Espion),0)").Fields(0).Value, 6)
            rs("Cod_Audit").Value = CodAudit
            rs("Dat_Crea").Value = Now
            rs("Created_By").Value = GlobalVar("GV_LOGIN")
        Else
            rs.Update()
        End If
        rs("Table_Name").Value = table_Name_Text.Text
        rs("Audits_Espions").Value = Audits_Espions
        rs("Col_Audit_Upd").Value = Col_Audit_Upd
        rs("Col_Audit_Ins").Value = Col_Audit_Ins
        rs("Col_Audit_Del").Value = Col_Audit_Del
        rs("Dat_Modif").Value = Now
        rs("Modified_By").Value = GlobalVar("GV_LOGIN")
        rs.Update()
        rs.Close()
        If Cod_Audit_txt.Text = "" Then
            Cod_Audit_txt.Text = CodAudit
        Else
            Cod_Audit_txt_TextChanged(Nothing, Nothing)
        End If
        Return True
    End Function

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS167", Cod_Audit_txt, Me)
    End Sub
    Sub Deleting()
        If MessageBoxEx.Show("Etes-vous sûr de vouloir supprimer cet audit?", "Suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) = DialogResult.Cancel Then Return
        Try
            CnExecuting("if (select count(*) from sys.objects where name='ESP_" & table_Name_Text.Text & "_UPD' and type='TR')>0 begin drop trigger ESP_" & table_Name_Text.Text & "_UPD end")
        Catch ex As Exception
            MessageBoxEx.Show("Erreur Espion 'Modification'" & vbCrLf & ex.Message, "Espion 'Modification'", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End Try
        Try
            CnExecuting("if (select count(*) from sys.objects where name='ESP_" & table_Name_Text.Text & "_INS' and type='TR')>0 begin drop trigger ESP_" & table_Name_Text.Text & "_INS end")
        Catch ex As Exception
            MessageBoxEx.Show("Erreur Espion 'Ajout'" & vbCrLf & ex.Message, "Espion 'Ajout'", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End Try
        Try
            CnExecuting("if (select count(*) from sys.objects where name='ESP_" & table_Name_Text.Text & "_DEL' and type='TR')>0 begin drop trigger ESP_" & table_Name_Text.Text & "_DEL end")
        Catch ex As Exception
            MessageBoxEx.Show("Erreur Espion 'Suppression'" & vbCrLf & ex.Message, "Espion 'Suppression'", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End Try
        CnExecuting("delete from Param_Audit_Espion where Cod_Audit='" & Cod_Audit_txt.Text & "'")
        Reset_Form(Me)
    End Sub

    Sub Nouveau()
        Reset_Form(Me)
        LinkLabel2_LinkClicked(Nothing, Nothing)
    End Sub

    Private Sub Audit_Grd_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Audit_Grd.CellClick
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex < 0 Then Return
        With Audit_Grd
            If .RowCount = 0 Then Return
            If e.ColumnIndex = .Columns("Modification").Index Or
                    e.ColumnIndex = .Columns("Ajout").Index Or
                    e.ColumnIndex = .Columns("Suppression").Index Then
                .Item(e.ColumnIndex, e.RowIndex).Value = Not CBool(.Item(e.ColumnIndex, e.RowIndex).Value)
            End If

        End With
    End Sub


End Class