Public Class Admin_Definition_Ecran
    Friend Code As String = ""
    Friend ListTbl As New DataTable
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Next_D As ud_btn
    Dim Back_D As ud_btn
    Dim Last_D As ud_btn
    Dim First_D As ud_btn
    Dim New_D As ud_btn
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom("Name_Ecran", "Text_Ecran", "Controle_Menu", "Typ_Ecran='ECR'", Name_Ecran_Text, Me)
    End Sub
    Sub RequestLabels()
        Try
            If Code <> "" Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
            End If
            DroitAcces(Me, DroitModify_Fiche(Name_Ecran_Text.Text, Me))
            If Save_D.Enabled = True Then
                Check_Accessible(Me.Name, Name_Ecran_Text.Text)
                Code = Name_Ecran_Text.Text
            End If
            Dim C1, C2, C3, C4 As Object
            Labels_GRD.Rows.Clear()
            Dim CodSql As String = "select * from Controle_Def_Label where Name_Ecran='" & Name_Ecran_Text.Text & "' order by Text_Label_Origine"
            Dim Tbl As New DataTable
            Tbl = DATA_READER_GRD(CodSql)
            With Tbl
                For i = 0 To .Rows.Count - 1
                    C1 = IsNull(.Rows(i).Item("Name_Label"), "")
                    C2 = IsNull(.Rows(i).Item("Text_Label_Origine"), "")
                    C3 = IsNull(.Rows(i).Item("Typ_Label"), "")
                    C4 = IsNull(.Rows(i).Item("Alias_Label"), "")
                    Labels_GRD.Rows.Add(C1, C2, C3, C4)
                Next
            End With
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub SavingLabels()
        Dim rs1 As New ADODB.Recordset
        With Labels_GRD
            For i = 0 To .RowCount - 1
                If IsNull(.Item(Alias_Label.Index, i).Value, "").Trim <> "" And IsNull(.Item(Text_Label_Origine.Index, i).Value, "").Trim <> "" Then
                    If CStr(.Item(Alias_Label.Index, i).Value).Length > CStr(.Item(Text_Label_Origine.Index, i).Value).Length Then
                        DevComponents.DotNetBar.MessageBoxEx.Show("Longueur de l'alias supérieure au texte d'origine : " & CStr(.Item(Text_Label_Origine.Index, i).Value).Length, "Nombre de caractère", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        .Rows(i).Selected = True
                        .FirstDisplayedCell = .Item(Alias_Label.Index, i)
                        Return
                    End If
                End If
            Next
            For i = 0 To .RowCount - 1
                rs1.Open("select * from Controle_Def_Label where Name_Ecran='" & Name_Ecran_Text.Text & "' and Name_Label='" & .Item(0, i).Value & "' and Typ_Label='" & .Item(2, i).Value & "'", cn, 2, 2)
                rs1.Update()
                rs1("Alias_Label").Value = .Item(3, i).Value
                rs1.Update()
                rs1.Close()
            Next
            Tbl_Controle_Def_Label = DATA_READER_GRD("select * from Controle_Def_Label where isnull(Alias_Label,'')<>''")
        End With
    End Sub
    Private Sub Name_Ecran_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Name_Ecran_Text.TextChanged
        Try
            If Code <> "" Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
            End If
            DroitAcces(Me, DroitModify_Fiche(Name_Ecran_Text.Text, Me))
            If Save_D.Enabled = True Then
                Check_Accessible(Me.Name, Name_Ecran_Text.Text)
                Code = Name_Ecran_Text.Text
            End If
            Grd_Info.Rows.Clear()
            Grd_Report.Rows.Clear()
            Dim Tbl As DataTable = DATA_READER_GRD("select * from Controle_Def_Ecran where Name_Ecran='" & Name_Ecran_Text.Text & "'")
            If Tbl.Rows.Count > 0 Then
                Text_Ecran_Text.Text = FindLibelle("Text_Ecran", "Name_Ecran", Name_Ecran_Text.Text, "Controle_Menu")
                Table_Ref_Text.Text = IsNull(Tbl.Rows(0)("Table_Ref"), "")
                Index_Ecran_Text.Text = IsNull(Tbl.Rows(0)("Index_Ecran"), "")
                Index_Table_Text.Text = IsNull(Tbl.Rows(0)("Index_Table"), "")
                Num_Zoom_Text.Text = IsNull(Tbl.Rows(0)("Num_Zoom"), "")
                Est_Modal.Checked = IsNull(Tbl.Rows(0)("Modal"), False)
                PJ_D.Checked = IsNull(Tbl.Rows(0)("PJ"), False)
                Info_D.Checked = IsNull(Tbl.Rows(0)("Info"), False)
            Else
                Text_Ecran_Text.Text = ""
                Table_Ref_Text.Text = ""
                Index_Ecran_Text.Text = ""
                Index_Table_Text.Text = ""
                Num_Zoom_Text.Text = ""
                Est_Modal.Checked = False
                PJ_D.Checked = False
                Info_D.Checked = False
            End If

            Dim SqlStr As String = "select Champs,Lib_Champs,Rang from Controle_Def_Ecran_Proprietes where Name_Ecran='" & Name_Ecran_Text.Text & "' order by Rang"
            Dim C1, C2, C3 As Object
            Tbl = DATA_READER_GRD(SqlStr)
            With Tbl
                For i = 0 To .Rows.Count - 1
                    C1 = IsNull(.Rows(i).Item("Champs"), "")
                    C2 = IsNull(.Rows(i).Item("Lib_Champs"), "")
                    C3 = IsNull(.Rows(i).Item("Rang"), 0)
                    Grd_Info.Rows.Add(C1, C2, C3)
                Next
            End With
            SqlStr = "select Cod_Report,(select Nom_Report from Param_Mod_Edition where Cod_Report=r.Cod_Report) as Nom_Report, Criteres from Controle_Def_Ecran_Mod_Edition r where Name_Ecran='" & Name_Ecran_Text.Text & "'"
            Tbl = DATA_READER_GRD(SqlStr)
            With Tbl
                For i = 0 To .Rows.Count - 1
                    C1 = IsNull(.Rows(i).Item("Cod_Report"), "")
                    C2 = IsNull(.Rows(i).Item("Nom_Report"), "")
                    C3 = IsNull(.Rows(i).Item("Criteres"), "")
                    Grd_Report.Rows.Add(C1, C2, C3)
                Next
            End With
            SqlStr = "select Cod_Traitement,(select Traitement from Sys_Def_Ecran_Traitements_Specifiques where Code=r.Cod_Traitement) as Traitement, isnull(Typ_Traitement,'QRY') Typ_Traitement, Relation 
                        from Controle_Def_Ecran_Traitements_Specifiques r where Name_Ecran='" & Name_Ecran_Text.Text & "'
order by Rang"
            Tbl = DATA_READER_GRD(SqlStr)
            With Tbl
                For i = 0 To .Rows.Count - 1
                    C1 = IsNull(.Rows(i).Item("Cod_Traitement"), "")
                    C2 = IsNull(.Rows(i).Item("Traitement"), "")
                    C3 = IsNull(.Rows(i).Item("Typ_Traitement"), "")
                    Dim C4 = IsNull(.Rows(i).Item("Relation"), "")
                    Grille_Traitements.Rows.Add(C1, C2, C3, C4)
                Next
            End With
            RequestLabels()
        Catch ex As Exception
            ErrorMsg(ex)
        End Try

    End Sub

    Sub Saving()
        If Name_Ecran_Text.Text = "" Then Exit Sub
        Try
            If Index_Table_Text.Text.Trim <> "" Or Table_Ref_Text.Text.Trim <> "" Then
                cn.Execute("Select " & Index_Table_Text.Text & " from " & Table_Ref_Text.Text)
            End If
        Catch ex As Exception
            MessageBoxRHP(1013)
            Exit Sub
        End Try
        Try
            Dim rs As New ADODB.Recordset
            If CnExecuting("Select count(*) from Controle_Def_Ecran where Name_Ecran='" & Name_Ecran_Text.Text & "'").Fields(0).Value = 0 Then
                rs.Open("select * from Controle_Def_Ecran", cn, 2, 2)
                rs.AddNew()
                rs("Dat_Crea").Value = CnExecuting("select getdate()").Fields(0).Value
                rs("Created_By").Value = theUser.Login
            Else
                rs.Open("select * from Controle_Def_Ecran where Name_Ecran='" & Name_Ecran_Text.Text & "'", cn, 2, 2)
                rs.Update()
            End If
            rs("Name_Ecran").Value = Name_Ecran_Text.Text
            rs("Table_Ref").Value = Table_Ref_Text.Text
            rs("Index_Ecran").Value = Index_Ecran_Text.Text
            rs("Num_Zoom").Value = Num_Zoom_Text.Text
            rs("Index_Table").Value = Index_Table_Text.Text
            rs("Modal").Value = Est_Modal.Checked
            rs("PJ").Value = PJ_D.Checked
            rs("Info").Value = Info_D.Checked
            rs("Dat_Modif").Value = CnExecuting("select getdate()").Fields(0).Value
            rs("Modified_By").Value = theUser.Login
            rs.Update()
            rs.Close()
            CnExecuting("delete from Controle_Def_Ecran_Proprietes where Name_Ecran='" & Name_Ecran_Text.Text & "'")
            rs.Open("select * from Controle_Def_Ecran_Proprietes", cn, 2, 2)
            With Grd_Info
                For i = 0 To .RowCount - 1
                    If IsNull(.Item(Champs.Index, i).Value, "") <> "" Then
                        rs.AddNew()
                        rs("Name_Ecran").Value = Name_Ecran_Text.Text
                        rs("Table_Ref").Value = Table_Ref_Text.Text
                        rs("Champs").Value = .Item(Champs.Index, i).Value
                        rs("Lib_Champs").Value = .Item(Lib_Champs.Index, i).Value
                        rs("Rang").Value = IsNull(.Item(Rang.Index, i).Value, i + 1)
                        rs.Update()
                    End If
                Next
            End With
            rs.Close()
            CnExecuting("delete from Controle_Def_Ecran_Mod_Edition where Name_Ecran='" & Name_Ecran_Text.Text & "'")
            rs.Open("select * from Controle_Def_Ecran_Mod_Edition", cn, 2, 2)
            With Grd_Report
                For i = 0 To .RowCount - 1
                    If IsNull(.Item(Cod_Report.Index, i).Value, "") <> "" Then
                        rs.AddNew()
                        rs("Name_Ecran").Value = Name_Ecran_Text.Text
                        rs("Cod_Report").Value = .Item(Cod_Report.Index, i).Value
                        rs("Criteres").Value = .Item(Criteres.Index, i).Value
                        rs.Update()
                    End If
                Next
            End With
            rs.Close()
            CnExecuting("delete from Controle_Def_Ecran_Traitements_Specifiques where Name_Ecran='" & Name_Ecran_Text.Text & "'")
            rs.Open("select * from Controle_Def_Ecran_Traitements_Specifiques", cn, 2, 2)
            With Grille_Traitements
                For i = 0 To .RowCount - 1
                    If IsNull(.Item(Cod_Traitement.Index, i).Value, "") <> "" Then
                        rs.AddNew()
                        rs("Name_Ecran").Value = Name_Ecran_Text.Text
                        rs("Cod_Traitement").Value = .Item(Cod_Traitement.Index, i).Value
                        rs("Typ_Traitement").Value = .Item(Typ_Traitement.Index, i).Value
                        rs("Relation").Value = .Item(Relation.Index, i).Value
                        rs("Rang").Value = Droite("0000" & i, 4)
                        rs.Update()
                    End If
                Next
            End With
            rs.Close()
            Tbl_Controle_Def_Ecran = DATA_READER_GRD("select convert(bit,ContientSociete) as ContientSociete,Name_Ecran, Index_Ecran, Table_Ref, 
Index_Table, Num_Zoom,isnull(Modal,'false') as Modal, isnull(PJ,'false') as PJ, isnull(Info,'false') as Info
from Controle_Def_Ecran d
outer apply (select count(name) as ContientSociete from sys.columns where object_name(object_id)=d.Table_Ref and name='id_Societe' )s")

            SavingLabels()

            MessageBoxRHP(348)
            TabControl1.SelectedIndex = 0
        Catch ex As Exception
            MessageBoxRHP(349)
        End Try
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Appel_Zoom1("MS002", Table_Ref_Text, Me)
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If Table_Ref_Text.Text = "" Then Exit Sub
        Appel_Zoom("Name", "Name", "syscolumns", "Object_Name(Id)='" & Table_Ref_Text.Text & "'", Index_Table_Text, Me)
    End Sub


    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        ListTbl.Rows.Clear()
        Dim IndexEcran As String = Index_Ecran_Text.Text
        If Name_Ecran_Text.Text <> "" Then
            Dim frm As Form = CType(System.Activator.CreateInstance(System.Type.GetType("RHP." & Name_Ecran_Text.Text)), Form)
            Findindex(frm)
            Dim f As New Zoom_Libre
            With f
                .ZoomObject = Index_Ecran_Text
                .Libre_GRD.DataSource = ListTbl
                .ShowDialog()
                If Index_Ecran_Text.Text <> "" Then
                    IndexEcran &= IIf(IndexEcran <> "", ";", "") & Index_Ecran_Text.Text
                    Index_Ecran_Text.Text = IndexEcran
                End If
            End With
        End If
    End Sub
    Sub Findindex(ByVal frm As Object)
        For Each c In frm.Controls
            If c.GetType.Name = "ud_ComboBox" Or c.GetType.Name = "ud_TextBox" Or c.GetType.Name = "TextBox" Or c.GetType.Name = "NumericUpDown" Or c.GetType.Name = "ComboBox" Or c.GetType.Name = "LinkLabel" Then
                ListTbl.Rows.Add(c.Name, c.Name)
            ElseIf c.HasChildren Then
                Findindex(c)
            End If
        Next
    End Sub
    Private Sub Admin_Definition_Ecran_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Save_D = dictButtons("Save_D")
        Del_D = dictButtons("Del_D")
        Next_D = dictButtons("Next_D")
        Back_D = dictButtons("Back_D")
        Last_D = dictButtons("Last_D")
        First_D = dictButtons("First_D")
        New_D = dictButtons("New_D")
        ListTbl.Columns.Add("Nom Controle")
        ListTbl.Columns.Add("Texte Controle")
    End Sub

    Private Sub ChampsObligatoires_GRD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChampsObligatoires_GRD.KeyDown
        ListTbl.Rows.Clear()

        With ChampsObligatoires_GRD
            Dim c As Integer = .CurrentCell.ColumnIndex
            Dim r As Integer = .CurrentRow.Index
            If e.KeyData = Keys.F6 And c = Cod_Champs.Index And .Item(Origine.Index, r).Value <> "S" Then
                If Name_Ecran_Text.Text <> "" Then
                    Dim frm As Form = CType(System.Activator.CreateInstance(System.Type.GetType("RHP." & Name_Ecran_Text.Text)), Form)
                    FindChamps(frm)
                    Dim f As New Zoom_Libre
                    With f
                        .ZoomObject = ChampsObligatoires_GRD.CurrentCell
                        .Libre_GRD.DataSource = ListTbl
                        .ShowDialog()
                    End With
                    If .Item(c, r).Value <> "" Then
                        Dim obj As Object = GetControlByName(.Item(c, r).Value, frm)
                        If Not obj Is Nothing Then
                            .Item(Typ_Champs.Index, r).Value = obj.GetType.Name
                        End If
                    End If
                End If
            End If
        End With
    End Sub
    Sub FindChamps(ByVal frm As Object)
        For Each c In frm.Controls
            If c.GetType.Name = "TextBox" Then
                ListTbl.Rows.Add(CType(c, TextBox).Name, CType(c, TextBox).Name)
            ElseIf c.GetType.Name = "ComboBox" Then
                ListTbl.Rows.Add(CType(c, ComboBox).Name, CType(c, ComboBox).Name)
            ElseIf c.GetType.Name = "DataGridView" Then
                For Each a In CType(c, DataGridView).Columns
                    ListTbl.Rows.Add(a.Name, a.HeaderText)
                Next
            ElseIf c.HasChildren Then
                FindChamps(c)
            End If
        Next
    End Sub

    Sub Div_First()
        If Name_Ecran_Text.Text <> "" Then

            Diviseur_First("Controle_Def_Ecran", "Name_Ecran", "Name_Ecran", Name_Ecran_Text)
        End If
    End Sub

    Sub Div_Back()
        If Name_Ecran_Text.Text <> "" Then

            Diviseur_Back("Controle_Def_Ecran", "Name_Ecran", "Name_Ecran", Name_Ecran_Text)
        End If
    End Sub

    Sub Div_Next()
        If Name_Ecran_Text.Text <> "" Then

            Diviseur_Next("Controle_Def_Ecran", "Name_Ecran", "Name_Ecran", Name_Ecran_Text)
        End If
    End Sub

    Sub Div_Last()
        If Name_Ecran_Text.Text <> "" Then

            Diviseur_Last("Controle_Def_Ecran", "Name_Ecran", "Name_Ecran", Name_Ecran_Text)
        End If
    End Sub

    Sub Nouveau()
        Reset_Form(Me)
    End Sub

    Sub Deleting()
        If Name_Ecran_Text.Text = "" Then Exit Sub
        Diviseur_delete("Controle_Def_Ecran", "Name_Ecran", "Name_Ecran", Name_Ecran_Text, Me)
        Tbl_Controle_Def_Ecran = DATA_READER_GRD("select convert(bit,ContientSociete) as ContientSociete,Name_Ecran, Index_Ecran, Table_Ref, Index_Table,
Num_Zoom, Description, Condition , isnull(Modal,'false') as Modal, isnull(PJ,'false') as PJ, isnull(Info,'false') as Info
from Controle_Def_Ecran d
outer apply (select count(name) as ContientSociete from sys.columns where object_name(object_id)=d.Table_Ref and name='id_Societe' )s")

    End Sub
    Private Sub Grd_Info_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Info.CellMouseDoubleClick
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex <> Champs.Index Then Return
        Dim r As Integer = e.RowIndex
        With Grd_Info
            If r = .RowCount - 1 Then
                .Rows.Insert(r, {"", "", r + 1})
            End If
            Appel_Zoom("COLUMN_NAME", "COLUMN_NAME", "INFORMATION_SCHEMA.COLUMNS", "TABLE_NAME='" & Table_Ref_Text.Text & "'", .Item(e.ColumnIndex, r), Me)
            .CurrentCell = .Item(Lib_Champs.Index, e.RowIndex)
            .BeginEdit(True)
            .Refresh()
        End With
    End Sub
    Private Sub Num_Ser_GRD_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Info.CellMouseEnter
        If e.ColumnIndex = Champs.Index Then
            Grd_Info.Cursor = Cursors.Hand
        Else
            Grd_Info.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub Num_Ser_GRD_Leave(sender As Object, e As EventArgs) Handles Grd_Info.Leave
        Cursor = Cursors.Default
    End Sub
    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Appel_Zoom("Num_Zoom", "Table_Ref", "Controle_Def_Zoom", "1=1", Num_Zoom_Text, Me)
    End Sub
    Private Sub Grd_Report_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Report.CellMouseEnter
        If e.ColumnIndex = Cod_Report.Index Then
            Grd_Report.Cursor = Cursors.Hand
        Else
            Grd_Report.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub Grd_Report_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd_Report.CellMouseDoubleClick
        Dim r As Integer = e.RowIndex
        With Grd_Report
            If e.RowIndex = .RowCount - 1 Then
                .Rows.Add("")
            End If
            If e.ColumnIndex = Cod_Report.Index Then
                Appel_Zoom1("MS031", .Item(e.ColumnIndex, r), Me)
                .Item(Nom_Report.Index, r).Value = FindLibelle("Nom_Report", "Cod_Report", .Item(e.ColumnIndex, r).Value, "Param_Mod_Edition")
                Dim crt As String = ""
                Dim TblCrt As DataTable = DATA_READER_GRD("select Critere+':='+isnull(Default_Value,'') as Crt from Param_Mod_Edition_Criteres where Cod_Report='" & .Item(e.ColumnIndex, r).Value & "' order by Rang")
                With TblCrt
                    For i = 0 To .Rows.Count - 1
                        crt &= IIf(crt = "", "", ";") & .Rows(i)("Crt")
                    Next
                End With
                .Item(Criteres.Index, r).Value = crt
            End If
        End With
    End Sub

    Private Sub Admin_Definition_Ecran_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Save_D.Enabled = True Then
                CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Private Sub Grille_Traitements_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grille_Traitements.CellMouseMove
        If e.RowIndex < 0 Then Return
        Grille_Traitements.Cursor = If(e.ColumnIndex = Cod_Traitement.Index, Cursors.Hand, Cursors.Default)

    End Sub

    Private Sub Grille_Traitements_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grille_Traitements.CellMouseDoubleClick
        Dim r As Integer = e.RowIndex
        With Grille_Traitements
            If e.RowIndex = .RowCount - 1 Then
                .Rows.Add("")
            End If
            If e.ColumnIndex = Cod_Traitement.Index Then
                Appel_Zoom1("MS170", .Item(e.ColumnIndex, r), Me)
                .Item(Lib_Traitement.Index, r).Value = FindLibelle("Traitement", "Code", .Item(e.ColumnIndex, r).Value, "Sys_Def_Ecran_Traitements_Specifiques")
                .Item(Typ_Traitement.Index, r).Value = IsNull(FindLibelle("Type", "Code", .Item(e.ColumnIndex, r).Value, "Sys_Def_Ecran_Traitements_Specifiques"), "QRY")
                Dim sqlCriteria As String = "select string_agg(Critere+':='+isnull(Default_Value,''),';')  WITHIN GROUP (ORDER BY Rang) AS   Crt from Param_Query_Criteres where Cod_Query='" & .Item(e.ColumnIndex, r).Value & "'"
                If .Item(Typ_Traitement.Index, r).Value = "PYT" Then
                    sqlCriteria = "select string_agg(isnull(Argument,'')+':='+isnull(Default_Value,''),';')  WITHIN GROUP (ORDER BY Rang) AS   Crt from Param_Python_Arguments where Cod_Python='" & .Item(e.ColumnIndex, r).Value & "'"
                End If
                Dim crt As String = CnExecuting(sqlCriteria).Fields(0).Value
                .Item(Relation.Index, r).Value = IsNull(crt, "")
            End If
        End With
    End Sub
End Class