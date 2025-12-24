Imports System.Text.RegularExpressions
Imports ExcelLibrary.Office.Excel
Public Class Notifications
    Dim rgC As New Regex("\{(\w+\.\w+)\}", RegexOptions.IgnoreCase)
    Dim rg_exp_interdite As String = "\b(eval)\b|\b(set)\b|\b(alter)\b|\b(create)\b|\b(drop)\b|\b(update)\b|\b(delete)\b|\b(truncate)\b"
    Dim rg_Colonne As String = ""
    Dim rgEmail As New Regex("^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", RegexOptions.IgnoreCase)
    Dim dicTbl As New Dictionary(Of String, String)
    Dim dicCol As New Dictionary(Of String, String)
    Dim lesTables As DataTable = DATA_READER_GRD("select name from sys.objects where type in ('U', 'V')")
    Dim selectedObject As Object = Nothing
    Dim Duplik As Boolean = False
    Dim TblUser As DataTable = DATA_READER_GRD("select convert(nvarchar(50),id_User) as id_User from Controle_Users")
    Dim New_D, Save_D, Del_D, Duplik_D, Help_D As ud_btn
    Function estDateConforme(strDate As String) As Boolean
        If IsDate(strDate) Then Return True
        If rgC.IsMatch(strDate) Then
            strDate = rgC.Matches(strDate)(0).Groups(1).Value
            Dim SqlStr As String = "Select count(*) from INFORMATION_SCHEMA.COLUMNS where 
            Column_name='" & strDate.Split(".")(1) & "' and
            Table_name ='" & dicTbl(strDate.Split(".")(0)) & "' and
            data_type in ('datetime','smalldatetime','date','time')"
            Return (CnExecuting(SqlStr).Fields(0).Value > 0)
        End If
        Return False
    End Function
    Function validationDestinataire() As Boolean
        Dim rgtest As New Regex("\;\W*\;*", RegexOptions.IgnoreCase)
        Destinataires_txt.Text = rgtest.Replace(Destinataires_txt.Text, ";")
        Cc_txt.Text = rgtest.Replace(Cc_txt.Text, ";")
        Cci_txt.Text = rgtest.Replace(Cci_txt.Text, ";")
        Dim rgs As New Regex("\s+|\,")
        Destinataires_txt.Text = rgs.Replace(Destinataires_txt.Text.Trim, ";").Trim
        If Destinataires_txt.Text.Replace(";", "").Trim = "" Then
            MessageBox.Show("Aucun destinataire n'est renseigné.", "Validation des destinataires", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Dim lsDestinataires() As String = Destinataires_txt.Text.Split(";")
        For i = 0 To lsDestinataires.Length - 1
            If rgEmail.IsMatch(lsDestinataires(i)) And Notification_Externe_chk.Checked Then Continue For
            If Notification_Interne_chk.Checked And TblUser.Select("id_User='" & CStr(lsDestinataires(i)) & "'").Length > 0 And IsNumeric(lsDestinataires(i)) Then Continue For
            If Notification_Interne_chk.Checked And rgC.IsMatch(lsDestinataires(i)) And lsDestinataires(i).ToLower.EndsWith("id_user") Then Continue For
            If Notification_Externe_chk.Checked Then
                If rgC.IsMatch(lsDestinataires(i)) Then
                    Dim chp As String = rgC.Matches(lsDestinataires(i))(0).Groups(1).Value
                    Dim SqlStr As String = "Select count(*) from INFORMATION_SCHEMA.COLUMNS where 
            Column_name='" & chp.Split(".")(1) & "' and Column_name not in ('id_User','Created_By','Modified_By', 'Login_User') and
            Table_name ='" & dicTbl(chp.Split(".")(0)) & "'"
                    If CnExecuting(SqlStr).Fields(0).Value = 0 Then
                        MessageBox.Show("Ce champs est erroné " & rgC.Matches(lsDestinataires(i))(0).Groups(0).Value)
                        Return False
                    End If
                Else
                    MessageBox.Show("Ce champs est erroné " & lsDestinataires(i))
                    Return False
                End If
            End If
        Next
        Return True
    End Function
    Private Sub Param_Num_Ser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not CBool(LicenceJson.WorkFlow) Then
            MessageBox.Show("Le module 'Workflow'  n'est pas activé pour votre licence.", "Licence", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Return
        End If
        Save_D = dictButtons("Save_D")
        Del_D = dictButtons("Del_D")
        Duplik_D = dictButtons("Duplik_D")
        Help_D = dictButtons("Help_D")
        New_D = dictButtons("New_D")
        Me.BackColor = Cod_Notification_txt.BackColor
    End Sub
    Private Sub Cod_Notification_txtTextChanged(sender As Object, e As EventArgs) Handles Cod_Notification_txt.TextChanged
        Request()
    End Sub
    Sub Request()
        If Duplik Then Return
        Dim Tbl As DataTable = DATA_READER_GRD("select * from Notifications where Cod_Notification='" & Cod_Notification_txt.Text & "'")
        With Tbl
            If .Rows.Count > 0 Then
                Table_Ref_txt.Text = IsNull(.Rows(0)("Table_Ref"), "")
                Table_Index_txt.Text = IsNull(.Rows(0)("Table_Index"), "")
                Actif_chk.Checked = IsNull(.Rows(0)("Actif"), False)
                CRE_chk.Checked = IsNull(.Rows(0)("Creation"), False)
                UPD_chk.Checked = IsNull(.Rows(0)("Modification"), False)
                DEL_chk.Checked = IsNull(.Rows(0)("Suppression"), False)
                Condition_txt.Text = IsNull(.Rows(0)("Condition"), "")
                Destinataires_txt.Text = IsNull(.Rows(0)("Destinataires"), "")
                Cc_txt.Text = IsNull(.Rows(0)("Cc"), "")
                Cci_txt.Text = IsNull(.Rows(0)("Cci"), "")
                Dat_Deb_txt.Text = IsNull(.Rows(0)("Dat_Deb"), "")
                Dat_Fin_txt.Text = IsNull(.Rows(0)("Dat_Fin"), "")
                Duree_txt.Text = IsNull(.Rows(0)("Duree"), 0)
                Objet_txt.Text = IsNull(.Rows(0)("Objet"), "")
                Corps_txt.Text = IsNull(.Rows(0)("Corps"), "")
                Champs_txt.Text = IsNull(.Rows(0)("Champs"), "")
                Agenda_chk.Checked = IsNull(.Rows(0)("Agenda"), False)
                Notification_Externe_chk.Checked = IsNull(.Rows(0)("Externe"), False)
                Notification_Interne_chk.Checked = IsNull(.Rows(0)("Interne"), False)
                Cod_Report_txt.Text = IsNull(.Rows(0)("Cod_Report"), "")
            Else
                Table_Ref_txt.Text = ""
                Table_Index_txt.Text = ""
                Actif_chk.Checked = False
                CRE_chk.Checked = False
                UPD_chk.Checked = False
                DEL_chk.Checked = False
                Condition_txt.Text = ""
                Destinataires_txt.Text = ""
                Cc_txt.Text = ""
                Cci_txt.Text = ""
                Dat_Deb_txt.Text = Now
                Dat_Fin_txt.Text = Now.AddHours(1)
                Duree_txt.Text = 1
                Objet_txt.Text = ""
                Corps_txt.Text = ""
                Champs_txt.Text = ""
                Notification_Externe_chk.Checked = False
                Notification_Interne_chk.Checked = False
                Agenda_chk.Checked = False
                Cod_Report_txt.Text = ""
            End If
        End With
        If Not Notification_Externe_chk.Checked Then
            Agenda_chk.Checked = False
            Agenda_chk.Enabled = False
        Else
            Agenda_chk.Enabled = True
        End If
        RequestTbl()
    End Sub
    Sub RequestTbl()
        Dim Cod_Sql As String = "SELECT      * 
                                 FROM Notifications_Tables  
                                 WHERE    Cod_Notification='" & Cod_Notification_txt.Text & "' order by RowId"
        Dim oTbl As DataTable = DATA_READER_GRD(Cod_Sql)
        Grd_Tbl.Rows.Clear()
        With oTbl
            For i = 0 To .Rows.Count - 1
                Grd_Tbl.Rows.Add(IsNull(.Rows(i).Item("Table_Liee"), ""), IsNull(.Rows(i).Item("Liaison"), ""))
            Next
        End With
    End Sub
    Sub Adding()
        Initialisation()
    End Sub
    Sub Initialisation()
        Grd_Tbl.Rows.Clear()
        Reset_Form(Panel1)
        Reset_Form(Panel2)
        Actif_chk.Checked = True
    End Sub
    Private Sub Tbl_Grd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grd_Tbl.KeyUp
        If e.KeyData = Keys.F6 Then
            If Grd_Tbl.CurrentCell.ColumnIndex = Table_Liee.Index Then
                Appel_Zoom("name", "name", "sysobjects", "xtype='U'", Grd_Tbl.CurrentCell, Me)
            End If
        End If
    End Sub
    Sub Enregister()
        Saving()
    End Sub
    Function Saving() As Boolean
        If Table_Ref_txt.Text = "" Then Return False
        Dim rg As New Regex(rg_exp_interdite, RegexOptions.IgnoreCase)
        Dim rs As New ADODB.Recordset
        Dim oNotif As Notif = chechNotification()
        If Not oNotif.Resulat Then Return False
        If Not CRE_chk.Checked And Not UPD_chk.Checked And Not DEL_chk.Checked Then
            MessageBox.Show("Aucun événement n'est coché.", "Evénement", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If Not estDateConforme(Dat_Deb_txt.Text) Then Dat_Deb_txt.Text = Now.Date.ToShortDateString & " " & Now.ToLongTimeString
        If Not estDateConforme(Dat_Fin_txt.Text) Then Dat_Fin_txt.Text = Dat_Deb_txt.Text
        If Not validationDestinataire() Then
            Return False
        End If
        Dim codNotification As String = Cod_Notification_txt.Text
        If codNotification = "" Then codNotification = "NT" & Droite("000000000000" & CnExecuting("select isnull((select convert(int, max(right(Cod_Notification,10))) from Notifications),0)+1").Fields(0).Value, 11)
        ' Try
        rs.Open("select * from Notifications where Cod_Notification='" & codNotification & "'", cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Cod_Notification").Value = codNotification
            rs("Dat_Crea").Value = Now
            rs("Created_By").Value = GlobalVar("GV_LOGIN")
        Else
            rs.Update()
        End If
        rs("Table_Ref").Value = Table_Ref_txt.Text
        rs("Table_Index").Value = Table_Index_txt.Text
        rs("Actif").Value = Actif_chk.Checked
        rs("Creation").Value = CRE_chk.Checked
        rs("Modification").Value = UPD_chk.Checked
        rs("Suppression").Value = DEL_chk.Checked
        rs("Condition").Value = Condition_txt.Text
        rs("Destinataires").Value = Destinataires_txt.Text
        rs("Cc").Value = Cc_txt.Text
        rs("Cci").Value = Cci_txt.Text
        rs("Interne").Value = Notification_Interne_chk.Checked
        rs("Externe").Value = Notification_Externe_chk.Checked
        rs("Agenda").Value = Agenda_chk.Checked
        rs("Dat_Deb").Value = IIf(Agenda_chk.Checked, Dat_Deb_txt.Text, Nothing)
        rs("Dat_Fin").Value = IIf(Agenda_chk.Checked, Dat_Fin_txt.Text, Nothing)
        rs("Duree").Value = IIf(Agenda_chk.Checked, IIf(IsNumeric(Duree_txt.Text), Duree_txt.Text, 0), 0)
        rs("Objet").Value = Objet_txt.Text
        rs("Corps").Value = Corps_txt.Text
        rs("SqlPattern").Value = oNotif.SqlStr
        rs("Champs").Value = IIf(Champs_txt.Text.Trim = "" Or Not UPD_chk.Checked, "", Champs_txt.Text.Trim)
        rs("Cod_Report").Value = Cod_Report_txt.Text
        rs("Dat_Modif").Value = Now
        rs("Modified_By").Value = GlobalVar("GV_LOGIN")
        rs.Update()
        rs.Close()
        CnExecuting("delete from Notifications_Tables where Cod_Notification='" & codNotification & "'")
        rs.Open("select * from Notifications_Tables where Cod_Notification='" & codNotification & "'", cn, 2, 2)
        With Grd_Tbl
            For i = 0 To .Rows.Count - 2
                If IsNull(.Item(Table_Liee.Index, i).Value, "") <> "" And IsNull(.Item(Liaison.Index, i).Value, "") <> "" Then
                    rs.AddNew()
                    rs("Cod_Notification").Value = codNotification
                    rs("Table_Ref").Value = Table_Ref_txt.Text
                    rs("Table_Index").Value = Table_Index_txt.Text
                    rs("Table_Liee").Value = .Item(Table_Liee.Index, i).Value
                    rs("Liaison").Value = .Item(Liaison.Index, i).Value
                    rs.Update()
                End If
            Next
        End With
        rs.Close()

        If Not SupprssionTrigger(codNotification) Then
            Return False
        End If
        If Actif_chk.Checked Then
            Dim cnt As New ADODB.Connection
            cnt.ConnectionString = connectionString
            cnt.CommandTimeout = 10
            cnt.ConnectionTimeout = 10
            cnt.Open()
            If CRE_chk.Checked Then cnt.Execute("exec Sys_Notification_Creation 'INSERT','" + codNotification + "'")
            If UPD_chk.Checked Then cnt.Execute("exec Sys_Notification_Creation 'UPDATE','" + codNotification + "'")
            If DEL_chk.Checked Then cnt.Execute("exec Sys_Notification_Creation 'DELETE','" + codNotification + "'")
            cnt.Close()
        End If
        'Saving Criteres Crystal
        CnExecuting("delete from Notifications_Critere where Cod_Notification='" & codNotification & "' and Typ_Query='RPT'")
        With Grd_CrystalReport
            rs.Open("select * from Notifications_Critere where Cod_Notification='" & codNotification & "' and Typ_Query='RPT'", cn, 2, 2)
            For i = 0 To .RowCount - 1
                rs.AddNew()
                rs("Cod_Notification").Value = codNotification
                rs("Cod_Query").Value = Cod_Report_txt.Text
                rs("Typ_Query").Value = "RPT"
                rs("Critere").Value = .Item("cr_Critere", i).Value
                rs("Valeur").Value = .Item("cr_Valeur", i).Value
                rs.Update()
            Next
            rs.Close()
        End With
        If Cod_Notification_txt.Text = "" Then
            Cod_Notification_txt.Text = codNotification
        Else
            Request()
        End If

        Return True
        '    Catch ex As Exception
        '  MessageBox.Show(ex.Message)
        '   Return False
        '    End Try
    End Function
    Function SupprssionTrigger(codNotification As String, Optional Asupprimer As String = "") As Boolean
        Dim SqlStr As String = "declare @tr1 nvarchar(500)
                                declare tr cursor for
                                select name from sys.objects where type='TR' and name like 'Notif_%_" & codNotification & "'" & IIf(Asupprimer <> "", " and name in (" & Asupprimer & ")", "") & "
                                open tr
                                fetch next from tr into @tr1
                                while @@FETCH_STATUS=0
                                begin
                                exec('drop trigger ['+@tr1+']')
                                fetch next from tr into @tr1
                                end 
                                close tr
                                deallocate tr"
        Try
            Dim tbl As DataTable = DATA_READER_GRD("select name from sys.objects where type='TR' and name like 'Notif_%_" & codNotification & "'")
            For i = 0 To tbl.Rows.Count - 1
                Dim cnt As New ADODB.Connection
                cnt.ConnectionString = connectionString
                cnt.CommandTimeout = 10
                cnt.ConnectionTimeout = 10
                cnt.Open()
                cnt.Execute("drop trigger dbo.[" & tbl.Rows(i)("name") & "]")
                cnt.Close()
            Next

        Catch ex As Exception

        End Try
        Return True
    End Function
    Private Sub Supprimer()
        If Cod_Notification_txt.Text = "" Then Return
        If MessageBoxRHP(541, "Notification : " & Cod_Notification_txt.Text) = MsgBoxResult.Cancel Then Return
        If Not SupprssionTrigger(Cod_Notification_txt.Text) Then Return
        Grd_Tbl.Rows.Clear()
        Diviseur_delete("Notifications", "Cod_Notification", "Cod_Notification", Cod_Notification_txt, Me, False)
    End Sub
    Sub Nouveau()
        Adding()
    End Sub

    Sub Deleting()
        Supprimer()
    End Sub
    Private Sub Grd_Tbl_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Tbl.CellDoubleClick
        With Grd_Tbl
            If e.ColumnIndex = Table_Liee.Index Then
                Dim r As Integer = e.RowIndex
                Dim c As Integer = e.ColumnIndex
                If .Rows(r).IsNewRow Then .Rows.Insert(.RowCount - 1, "")
                Appel_Zoom("name", "name", "sys.objects", "type in ('U','V')", .Item(c, r), Me)
                If .Item(c, r).Value <> "" Then
                    .Item(Liaison.Index, r).Value = ""
                End If
            End If
        End With
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom("name", "name", "sys.objects", "type ='U'", Table_Ref_txt, Me)
    End Sub

    Private Sub Table_Ref_txt_TextChanged(sender As Object, e As EventArgs) Handles Table_Ref_txt.TextChanged
        Table_Index_txt.Text = FindLibelle("Index_Table", "Table_Ref", Table_Ref_txt.Text, "Controle_Def_Ecran")
        setDicColumns()
    End Sub

    Private Sub Cod_Profile_Label_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Cod_Profile_Label.LinkClicked
        Appel_Zoom1("MS168", Cod_Notification_txt, Me)
    End Sub

    Private Sub Agenda_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Agenda_chk.CheckedChanged
        Agenda_Grp.Visible = Agenda_chk.Checked
    End Sub

    Private Sub Grd_Tbl_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Tbl.RowValidated
        setDicColumns()
    End Sub
    Sub setDicColumns()
        dicTbl.Clear()
        dicCol.Clear()
        rg_Colonne = ""
        If Table_Ref_txt.Text = "" Then Return
        Dim tblname() As String
        Dim tbls As String = ""
        Dim rgs As New Regex("\s+")
        dicTbl.Add(Table_Ref_txt.Text, Table_Ref_txt.Text)
        Dim ind As New List(Of Integer)
        With Grd_Tbl
            For i = 0 To .RowCount - 2
                If IsNull(.Item(Table_Liee.Index, i).Value, "").Trim <> "" Then
                    If IsNull(.Item(Liaison.Index, i).Value, "").Trim = "" Then
                        ind.Add(i)
                    Else
                        tblname = rgs.Replace(.Item(Table_Liee.Index, i).Value.ToString.Trim, " ").Split(" ")
                        If tblname.Length = 0 Then
                            ind.Add(i)
                        Else
                            If lesTables.Select("name = '" & tblname(0) & "'").Length = 0 Then
                                ind.Add(i)
                            Else
                                If tblname.Length = 1 Then
                                    If Not dicTbl.ContainsKey(tblname(0)) Then
                                        dicTbl.Add(tblname(0), tblname(0))
                                    Else
                                        ind.Add(i)
                                    End If
                                ElseIf tblname.Length = 2 Then
                                    If Not dicTbl.ContainsKey(tblname(1)) Then
                                        dicTbl.Add(tblname(1), tblname(0))
                                    Else
                                        ind.Add(i)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next
            Try
                For i = 0 To ind.Count - 1
                    .Rows.RemoveAt(ind(i))
                Next
            Catch ex As Exception

            End Try

            'Charger les colonnes
            tbls = String.Format("select TABLE_NAME, COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME in ('{0}')", String.Join("','", dicTbl.Select(Function(x) x.Value).Distinct().ToList))
            Dim TblCol As DataTable = DATA_READER_GRD(tbls)
            For Each a In dicTbl
                Dim rw() As DataRow = TblCol.Select("TABLE_NAME = '" & a.Value & "'")
                If rw.Length > 0 Then
                    For i = 0 To rw.Length - 1
                        dicCol.Add(a.Key & "." & rw(i)("COLUMN_NAME"), rw(i)("COLUMN_NAME"))
                        rg_Colonne = IIf(rg_Colonne = "", "", "|") & "\b(" & a.Key & "[.]" & rw(i)("COLUMN_NAME") & ")\b"
                    Next
                End If
            Next
            rg_Colonne = IIf(rg_Colonne = "", "", "\{(" + rg_Colonne + ")\}")
        End With
    End Sub

    Private Sub Grd_Tbl_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles Grd_Tbl.RowsRemoved
        setDicColumns()
    End Sub
    Structure Notif
        Public Resulat As Boolean
        Public SqlStr As String
    End Structure
    Function chechNotification() As Notif
        setDicColumns()

        Dim oNotif As New Notif
        With oNotif
            .Resulat = True
            .SqlStr = ""
        End With
        If dicCol.Count = 0 Then Return oNotif
        Dim chp As String = ""
        Dim Sqlstr As String = "select {0} from " & Table_Ref_txt.Text
        With Grd_Tbl
            For i = 0 To .RowCount - 2
                If IsNull(.Item(Table_Liee.Index, i).Value, "").Trim <> "" And IsNull(.Item(Liaison.Index, i).Value, "").Trim <> "" Then
                    Sqlstr &= String.Format(" left join {0} on {1}", IsNull(.Item(Table_Liee.Index, i).Value, "").Trim, IsNull(.Item(Liaison.Index, i).Value, "").Trim)
                End If
            Next
        End With
        Sqlstr &= IIf(Condition_txt.Text.Trim = "", "", " where (" & Condition_txt.Text.Trim & ")").Replace("{", "").Replace("}", "")
        Sqlstr = Regex.Replace(Sqlstr, rg_exp_interdite, "Expression intéridite")
        Try
            Dim cnt As New ADODB.Connection
            cnt.ConnectionString = connectionString
            cnt.CommandTimeout = 10
            cnt.ConnectionTimeout = 10
            cnt.Open()
            cnt.Execute(String.Format(Sqlstr, "count(*)"))
            cnt.Close()
            If Table_Index_txt.Text <> "" Then Sqlstr &= IIf(Condition_txt.Text.Trim = "", " where ", " and ") & Table_Index_txt.Text & "= '@@@ValIndex' "
        Catch ex As Exception
            ErrorMsg(ex)
            Return oNotif
        End Try
        Dim txtC As String = vbCrLf & Corps_txt.Text & vbCrLf & Objet_txt.Text & vbCrLf & Destinataires_txt.Text & vbCrLf & Dat_Deb_txt.Text & vbCrLf & Dat_Fin_txt.Text & vbCrLf & Cc_txt.Text & vbCrLf & Cci_txt.Text
        With Grd_CrystalReport
            For i = 0 To .Rows.Count - 1
                If IsNull(.Item(cr_Valeur.Index, i).Value, "") <> "" Then
                    txtC &= vbCrLf & IsNull(.Item(cr_Valeur.Index, i).Value, "").Trim
                End If
            Next
        End With

        For Each c As Match In rgC.Matches(txtC)
            If dicCol.Where(Function(x) x.Key = c.Groups(1).Value.Trim).Count = 0 Then
                MessageBox.Show("Ce champs est erroné : " & c.Value)
                Return oNotif
            Else
                chp &= IIf(chp = "", "", " , ") & c.Groups(1).Value & " as '" & c.Value & "'"
            End If
        Next
        If Champs_txt.Text.Trim <> "" Then
            For Each c In Champs_txt.Text.Trim.Split(";")
                If Not chp.Contains("{" & Table_Ref_txt.Text & "." & c & "}") Then chp &= If(chp = "", "", ", ") & Table_Ref_txt.Text & "." & c & " as '{" & Table_Ref_txt.Text & "." & c & "}'"
            Next
        End If
        chp = If(chp = "", "1", chp)
        oNotif.Resulat = True
        oNotif.SqlStr = String.Format(Sqlstr, chp)
        Return oNotif
    End Function

    Sub Helping()
        If selectedObject Is Nothing Then
            selectedObject = Corps_txt
        End If
        setDicColumns()
        Dim f As New Zoom_Notifications_Champs
        With f
            If selectedObject.GetType.Name.StartsWith("DataGridView") Then
                .txtBox = Nothing
                .txtCell = selectedObject
            Else
                .txtBox = selectedObject
                .txtCell = Nothing
            End If
            .dicCol = dicCol
            .dicTbl = dicTbl
            .ShowDialog()
        End With
    End Sub

    Private Sub selectedObject_selecting(sender As Object, e As EventArgs) Handles Corps_txt.GotFocus, Destinataires_txt.GotFocus, Condition_txt.GotFocus, Dat_Deb_txt.GotFocus, Dat_Fin_txt.GotFocus, Objet_txt.GotFocus, Cci_txt.GotFocus, Cc_txt.GotFocus
        selectedObject = sender
    End Sub
    Private Sub Duree_txt_TextChanged(sender As TextBox, e As EventArgs) Handles Duree_txt.Leave
        If Not IsNumeric(Duree_txt.Text) Then Duree_txt.Text = 0
        If Not estDateConforme(Dat_Deb_txt.Text) Then Dat_Deb_txt.Text = Now.Date.ToShortDateString & " " & Now.ToLongTimeString
        If IsDate(Dat_Deb_txt.Text) Then Dat_Fin_txt.Text = DateAdd(DateInterval.Hour, CDbl(Duree_txt.Text), CDate(Dat_Deb_txt.Text))
    End Sub

    Private Sub Duree_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Duree_txt.KeyPress
        ControleSaisie(sender, e, True, False, True, False, False)
    End Sub
    Sub Duplicating()
        Duplik = True
        Cod_Notification_txt.ResetText()
        Duplik = False
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Champs_lbl.LinkClicked
        Dim f As New Zoom_Notifications_Champs_TableRef
        With f
            .Table_Ref = Table_Ref_txt.Text
            .dicCol = dicCol
            .txtBox = Champs_txt
            .ShowDialog()
        End With
    End Sub

    Private Sub UPD_chk_CheckedChanged(sender As Object, e As EventArgs) Handles UPD_chk.CheckedChanged
        Champs_lbl.Visible = UPD_chk.Checked
        Champs_txt.Visible = UPD_chk.Checked
    End Sub

    Private Sub Notification_Externe_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Notification_Externe_chk.CheckedChanged
        If Not Notification_Externe_chk.Checked Then
            Agenda_chk.Checked = False
            Agenda_chk.Enabled = False
        Else
            Agenda_chk.Enabled = True
        End If
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Appel_Zoom("Cod_Report", "Nom_Report", "Param_Mod_Edition", "1=1", Cod_Report_txt, Me)
    End Sub

    Private Sub Cod_Report_Text_TextChanged(sender As Object, e As EventArgs) Handles Cod_Report_txt.TextChanged
        Nom_Report_Text.Text = FindLibelle("Nom_Report", "Cod_Report", Cod_Report_txt.Text, "Param_Mod_Edition")
        With Grd_CrystalReport
            .Rows.Clear()
            Dim Cod_Sql As String = "Select Critere,Lib_Critere,isnull(Valeur,Default_Value) as Default_Value,Fonction_Critere  from Param_Mod_Edition_Criteres q
            outer apply (select isnull(Valeur,'') as Valeur from Notifications_Critere where isnull(Typ_Query,'')='RPT' and Cod_Notification='" & Cod_Notification_txt.Text & "' and Cod_Query=q.Cod_Report and Critere=q.Critere) m
            where Cod_Report='" & Cod_Report_txt.Text & "' 
            order by rang"
            Dim Tbl As DataTable = DATA_READER_GRD(Cod_Sql)
            Dim C1, C2, C3, C4 As Object
            With Tbl
                For i = 0 To .Rows.Count - 1
                    C1 = IsNull(Tbl.Rows(i).Item("Critere"), "")
                    C2 = IsNull(Tbl.Rows(i).Item("Lib_Critere"), C1)
                    C3 = IsNull(.Rows(i).Item("Default_Value"), "")
                    C4 = IsNull(Tbl.Rows(i).Item("Fonction_Critere"), "")
                    Grd_CrystalReport.Rows.Add(C1, C2, C3, C4)
                Next
            End With
        End With
    End Sub
    Private Sub Grd_CrystalReport_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Grd_CrystalReport.CellBeginEdit
        selectedObject = Grd_CrystalReport.Item(e.ColumnIndex, e.RowIndex)
    End Sub
End Class