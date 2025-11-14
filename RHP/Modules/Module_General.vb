Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports DevComponents.AdvTree
Module Module_General
    Public Sub CenterControlInParent(control As Control, Optional horizontally As Boolean = True, Optional vertically As Boolean = True)
        If control.Parent Is Nothing Then Return
        If horizontally Then
            control.Left = (control.Parent.Width - control.Width) / 2
        End If
        If vertically Then
            control.Top = (control.Parent.Height - control.Height) / 2
        End If
    End Sub

    Function GetCoursDevAchat(ByVal CodDev As String, ByVal Dat As Date) As Double
        Dim Cours As Double = 1
        Dim rs As New ADODB.Recordset
        rs = CnExecuting("select Cours_Achat from Compta_Devise_Cours where Cod_Dev='" & CodDev & "' and Dat_Cours='" & Dat & "'")
        If Not rs.EOF Then
            If rs.Fields(0).Value > 0 Then Cours = rs.Fields(0).Value
        End If
        Return Cours

    End Function

    Function GetCoursDevVente(ByVal CodDev As String, ByVal Dat As Date) As Double
        Dim Cours As Double = 1
        Dim rs As New ADODB.Recordset
        rs = CnExecuting("select Cours_Vente from Compta_Devise_Cours where Cod_Dev='" & CodDev & "' and Dat_Cours='" & Dat & "'")
        If Not rs.EOF Then
            If rs.Fields(0).Value > 0 Then Cours = rs.Fields(0).Value
        End If
        Return Cours

    End Function


    Function Gauche(ByVal str As String, ByVal n As Integer) As String
        Return Microsoft.VisualBasic.Left(str, n)
    End Function
    Function Droite(ByVal str As String, ByVal n As Integer) As String
        Return Microsoft.VisualBasic.Right(str, n)
    End Function
    Sub Appel_Zoom2(ByVal Zom_Cod As String, ByVal Zom_Lib As String, ByVal Zom_Tbl As String, ByVal Zom_Where1 As String, ByVal Zom_Object As Object, ByVal Zom_Form As Form)

        Zoom_Cod = Zom_Cod
        Zoom_Lib = Zom_Lib
        Zoom_Tbl = Zom_Tbl
        Zoom_Object = Zom_Object
        Zoom_Form = Zom_Form
        Zoom_Where1 = Zom_Where1
        Dim f As New Zoom
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub
    Public Sub Combo_GRD(ByVal Combo As DataGridViewComboBoxColumn, Optional Rubrique As String = "")
        Try
            If Rubrique = "" Then Rubrique = Combo.Name
            Dim cn1 As New OleDb.OleDbConnection
            cn1.ConnectionString = connectionString
            Dim CMD As OleDbCommand = cn1.CreateCommand()
            CMD.CommandText = "Select Membre, Valeur from Param_Rubriques where Nom_Controle='" & Rubrique & "' Group by Nom_Controle,Membre,valeur,Rang order by isnull(Rang,Membre)"
            cn1.Open()
            Dim monreader As OleDbDataReader = CMD.ExecuteReader()
            Dim dtr As New DataTable(Rubrique)
            dtr.Load(monreader)
            cn1.Close()
            With Combo
                .DataSource = dtr
                .DataPropertyName = "Valeur"
                .DisplayMember = "Membre"
                .ValueMember = "Valeur"
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
            End With
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Public Sub Combo_GRD_Linked(ByVal Combo As DataGridViewComboBoxColumn, ByVal Cod_Sql As String)
        Try
            Dim cn1 As New OleDb.OleDbConnection
            cn1.ConnectionString = connectionString
            Dim CMD As OleDbCommand = cn1.CreateCommand()
            CMD.CommandText = Cod_Sql
            cn1.Open()
            Dim monreader As OleDbDataReader = CMD.ExecuteReader()
            Dim dtr As New DataTable(Combo.Name)
            dtr.Load(monreader)
            cn1.Close()
            With Combo
                .DataSource = dtr
                .DataPropertyName = dtr.Columns(0).Caption
                .DisplayMember = dtr.Columns(1).Caption
                .ValueMember = dtr.Columns(0).Caption
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
            End With
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Sub CheckList(ByVal oList As CheckedListBox, ByVal Cod_Sql As String)
        Try
            Dim cn1 As New OleDb.OleDbConnection
            cn1.ConnectionString = connectionString
            Dim CMD As OleDbCommand = cn1.CreateCommand()
            CMD.CommandText = Cod_Sql
            cn1.Open()
            Dim monreader As OleDbDataReader = CMD.ExecuteReader()
            Dim dtr As New DataTable(oList.Name)
            dtr.Load(monreader)
            cn1.Close()
            With oList
                .DataSource = dtr
                .DisplayMember = "Membre"
                .ValueMember = "Valeur"
                For i = 0 To .Items.Count - 1
                    .SetItemChecked(i, True)
                Next
            End With
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Function ChargerGrille(ByVal Cod_Sql As String) As DataTable
        Try
            Dim cn1 As New OleDb.OleDbConnection
            cn1.ConnectionString = connectionString
            Dim CMD As OleDbCommand = cn1.CreateCommand()
            Cod_Sql = AppliquerRegleProfil(Cod_Sql)
            '   MsgBox(Cod_Sql)
            CMD.CommandText = Cod_Sql
            CMD.CommandTimeout = 0
            cn1.Open()
            Dim monreader As OleDbDataReader = CMD.ExecuteReader()
            Dim dtr As New DataTable("Table")
            dtr.Load(monreader)
            Return dtr
            cn1.Close()
        Catch ex As Exception
            MsgBox(Cod_Sql)
            ErrorMsg(ex)
            Return Nothing
        End Try
    End Function
    Function AppliquerRegleProfil(CodSql As String) As String
        ' Return CodSql
        Dim CodSql0 As String = CodSql
        Dim rg As New Regex("\b(DELETE|UPDATE|TRUNCATE|DROP)\b", RegexOptions.IgnoreCase)
        Dim srg As New Regex("", RegexOptions.IgnoreCase)
        If theUser.Cod_Profile = 1 Then Return CodSql
        If rg.IsMatch(CodSql) Then Return CodSql
        If Tbl_Controle_Profile_Regles.Columns.Count = 0 Then Return CodSql
        CodSql = FilterRoleWhere(CodSql)
        rg = New Regex("(?<=\W)GV_\w+", RegexOptions.IgnoreCase)
        For Each c As Match In rg.Matches(CodSql)
            srg = New Regex("\b(" & c.Value.Trim & ")\b", RegexOptions.IgnoreCase)
            CodSql = srg.Replace(CodSql, "'" & GlobalVar(c.Value.Trim.ToString) & "'")
        Next

        Return CodSql

    End Function
    Function DATA_READER_GRD(ByVal Cod_Sql As String, Optional AfficherSql As Boolean = False) As DataTable
        If AfficherSql Then
            MsgBox(Cod_Sql)
        End If
        Try
            Dim CMD As OleDbCommand = cn1.CreateCommand()
            With CMD
                .CommandText = Cod_Sql
                .CommandTimeout = 0
                Dim monreader As OleDbDataReader = .ExecuteReader()
                Dim dtr As New DataTable
                dtr.Load(monreader)
                Return dtr
            End With
        Catch ex As Exception
            MsgBox(Cod_Sql)
            ErrorMsg(ex)
            Return Nothing
        End Try
    End Function
    Sub GRD(ByVal Cod_Sql As String, ByVal grd As ud_Grd)
        Try
            Dim DTR As DataTable = DATA_READER_GRD(Cod_Sql)
            With grd
                .DataSource = DTR
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .BorderStyle = BorderStyle.None
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .RowHeadersVisible = False
                .ContextMenuStrip = AddContextMenu(False, True, True, True, False, False, False, False)
                .AllowUserToAddRows = False
                .ReadOnly = True
                .EnableHeadersVisualStyles = False
                ' .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Dim c As Integer = DTR.Columns.Count - 1
                For i = 0 To c
                    If TblAccess.Select("[Name_Ecran]='" & grd.FindForm.Name & "' and [Name_Controle]='" & .Columns(i).Name & "' and [Typ_Controle]='DataGridColumn' and [Visible]='false'").Length > 0 Then
                        .Columns(i).Visible = False
                    Else
                        If DTR.Columns(i).DataType.ToString.ToUpper.Contains("DOUBLE") Then
                            .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Columns(i).DefaultCellStyle.Format = "N"
                        ElseIf DTR.Columns(i).DataType.ToString.ToUpper.Contains("BOOLEAN") Then
                            .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            '    Else
                            '   .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        End If
                    End If
                    ' AJOUT : Forcer le style du header pour chaque colonne
                    With .Columns(i).HeaderCell.Style
                        .BackColor = Color.FromArgb(56, 153, 185)
                        .ForeColor = Color.White
                        .SelectionBackColor = Color.FromArgb(56, 153, 185)
                        .SelectionForeColor = Color.White
                    End With
                Next
            End With
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub GRD_Past_Copy(ByVal Cod_Sql As String, ByVal grd As DataGridView, ByVal Paste As Boolean, ByVal del As Boolean, ByVal delall As Boolean)

        Dim menu_context_copy As New ContextMenuStrip
        Dim oMenu1, oMenu2, oMenu3, oMenu4 As New ToolStripMenuItem
        With oMenu1
            .Text = "Copier le Contenu de la liste"
            AddHandler .Click, AddressOf menu_context_grd
        End With
        With oMenu2
            .Text = "Coller la liste"
            AddHandler .Click, AddressOf menu_context_grd_past
        End With
        With oMenu3
            .Text = "Supprimer la ligne"
            AddHandler .Click, AddressOf menu_context_grd_del
        End With
        With oMenu4
            .Text = "Supprimer toutes les lignes"
            AddHandler .Click, AddressOf menu_context_grd_delall
        End With
        If Paste = True Then
            oMenu2.Enabled = True
        Else
            oMenu2.Enabled = False
        End If
        If del = True Then
            oMenu3.Enabled = True
        Else
            oMenu3.Enabled = False
        End If
        If delall = True Then
            oMenu4.Enabled = True
        Else
            oMenu4.Enabled = False
        End If
        menu_context_copy.Items.AddRange(New System.Windows.Forms.ToolStripItem() {oMenu1, oMenu2, oMenu3, oMenu4})
        Dim DTR As Object = DATA_READER_GRD(Cod_Sql)
        With grd
            .DataSource = DTR

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .BorderStyle = BorderStyle.None
            .ColumnHeadersVisible = True
            .RowHeadersVisible = False
            .ContextMenuStrip = menu_context_copy
        End With
    End Sub

    Sub menu_context_grd_del(ByVal sender As Object, ByVal e As EventArgs)
        Try
            sender.getcurrentparent.sourcecontrol.Rows.Remove(sender.getcurrentparent.sourcecontrol.CurrentRow)
        Catch ex As Exception
            ErrorMsg(ex)
        End Try

    End Sub

    Sub menu_context_grd_past(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim tArr() As String
            Dim Art() As String
            Dim j, r As Integer
            Dim TBL As New DataTable
            TBL.Columns.Add("Libellé")
            TBL.Columns.Add("Valeur")
            tArr = Clipboard.GetText().Split(Environment.NewLine)
            r = tArr.Length - 1
            For j = 0 To r - 1
                Art = tArr(j).Split(vbTab)
                With TBL.Rows
                    .Add(Art(0).TrimStart, Art(1).TrimStart)
                End With
            Next
            sender.getcurrentparent.sourcecontrol.DataSource = TBL
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub


    Function Check_Special_Char(ByVal objet As Object, ByVal Cpt As Integer) As Integer
        Dim a As Integer
        a = Cpt
        For Each c As Object In objet.Controls
            If c.GetType.Name = "TextBox" Then
                If (c.Text.Contains("'") Or c.Text.Contains(Chr(34)) Or c.Text.Contains("&")) Then
                    a = a + 1
                End If
            End If
            If c.haschildren Then
                a += Check_Special_Char(c, a)
            End If
        Next
        Return a
    End Function

    Public Sub ControleSaisie(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal Nombre As Boolean, ByVal Est_entier As Boolean, ByVal Est_positif As Boolean, ByVal Alphabet As Boolean, ByVal Maj As Boolean)
        Select Case e.KeyChar
            Case "0" To "9"
                If Nombre = False Then e.Handled = True
                'If CInt(sender) > 999 Then e.Handled = True
            Case "a" To "z"
                If Alphabet = False Then e.Handled = True
            Case "A" To "Z"
                If Maj = False Then e.Handled = True
            Case ",", "."
                If Est_entier = True Then
                    e.Handled = True
                Else
                    e.KeyChar = ","
                End If
            Case "-"
                If Est_positif = True Then
                    e.Handled = True
                Else
                    'enlever le moins précedent
                End If
            Case Else
                If (Char.IsControl(e.KeyChar)) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
        End Select
    End Sub


    Public Sub Reset_Form(ByVal objet As Object, Optional InitialisationPicTBox As Boolean = False)
        Try
            For Each c In objet.controls
                Select Case c.GetType.Name
                    Case "TextBox"
                        If c.text <> "" Then
                            CType(c, TextBox).ResetText()
                        End If
                    Case "ud_TextBox"
                        If c.text <> "" Then
                            CType(c, ud_TextBox).innerTextBox.ResetText()
                        End If
                    Case "RichTextBox"
                        If c.rtf <> "" Then
                            CType(c, RichTextBox).ResetText()
                        End If
                    Case "CheckBox", "ud_CheckBox"
                        c.checked = False
                    Case "ComboBox", "ud_ComboBox"
                        If c.selectedindex <> -1 Then
                            c.selectedindex = -1
                        End If
                    Case "DataGridView", "DataGridViewX", "ud_Grd"
                        With CType(c, DataGridView)
                            If Not .DataSource Is Nothing Then
                                .DataSource = Nothing
                                .DataMember = Nothing
                            Else
                                .Rows.Clear()
                            End If
                        End With
                    Case "LinkLabel"
                        If CType(c, LinkLabel).BorderStyle = BorderStyle.Fixed3D Then c.text = ""
                    Case "PictureBox"
                        If InitialisationPicTBox Then CType(c, PictureBox).Image = Nothing
                    Case "ud_RichTextBox"
                        CType(c, ud_RichTextBox).rtb.Rtf = ""
                    Case "ud_RT"
                        CType(c, ud_RT).Rtb.RtfText = ""
                    Case "AdvTree"
                        CType(c, AdvTree).Nodes.Clear()
                    Case "NumericUpDown"
                        CType(c, NumericUpDown).Value = CType(c, NumericUpDown).Minimum
                End Select
                If c.haschildren And c.GetType IsNot GetType(DevComponents.DotNetBar.DockSite) And TypeOf c IsNot UserControl Then
                    Reset_Form(c, InitialisationPicTBox)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    ' Friend otesto As Integer = 0
    Public Function FindLibelle(ByVal LibelleToFind As String, ByVal oCode As String, ByVal Valeur_Code As String, ByVal oTbl As String, Optional ByVal AfficherSql As Boolean = False) As Object
        Dim Resultat As Object = Nothing
        Dim CodSqlS As String = ""
        '  MsgBox("select " & LibelleToFind & " From " & oTbl & " where " & oCode & "='" & Valeur_Code & "'")
        '

        Try
            Dim fDataTbl As New DataTable
            If ContientIdSoc(oTbl).Count > 0 Then
                CodSqlS = "select " & LibelleToFind & " From " & oTbl & " where isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")=" & Societe.id_Societe & " and " & oCode & "='" & Valeur_Code & "'"
            Else
                CodSqlS = "select " & LibelleToFind & " From " & oTbl & " where " & oCode & "='" & Valeur_Code & "'"
            End If
            '   If oTbl = "Survey" Then MsgBox(CodSqlS)
            fDataTbl = DATA_READER_GRD(CodSqlS)
            Dim oDefault As String = ""
            If fDataTbl.Columns.Count > 0 Then
                If fDataTbl.Columns(0).DataType.ToString.Contains("Int") Then
                    oDefault = 0
                ElseIf fDataTbl.Columns(0).DataType.ToString.Contains("Bool") Then
                    oDefault = False
                ElseIf fDataTbl.Columns(0).DataType.ToString.Contains("Double") Then
                    oDefault = 0
                End If
            End If
            If fDataTbl.Rows.Count > 0 Then
                Resultat = IsNull(fDataTbl.Rows(0).Item(0), oDefault)
            Else
                Resultat = oDefault
            End If
        Catch ex As Exception
            '
        End Try
        Return Resultat
    End Function
    Function ContientIdSoc(TblName As String) As List(Of String)
        Dim oList As New List(Of String)
        Dim sqlExclude As String = "select|from|outer|where|group|by|order|having|string_agg|string_split|apply|left|join|as|inner|right|update|delete|truncate|drop"
        'try
        If TablesAvecIdSoc.Contains(TblName.ToLower()) Then
            oList.Add(TblName)
            Return oList
        Else
            Dim rg As New Regex($"\w*\b(?!{sqlExclude})\w+\b", RegexOptions.IgnoreCase)
            For Each c As Match In rg.Matches(TblName)
                If TablesAvecIdSoc.Contains(c.Value.ToLower()) Then
                    Dim srg As New Regex($"\b(?<={c.Value.ToLower()}\s)(?!from|left)\b(?<alias>\w+)", RegexOptions.IgnoreCase)
                    If srg.IsMatch(TblName) Then
                        oList.Add(srg.Matches(TblName)(0).Groups(0).Value)
                    Else
                        oList.Add(c.Value)
                    End If
                End If
            Next
        End If
        Return oList
        '    Catch ex As Exception
        '  MsgBox("case 4")
        '  Return False
        '   End Try
    End Function
    Public Function FindRubriques(ByVal Champs As String, ByVal Valeur As String) As String
        Return FindLibelle("Membre", "Valeur", Valeur & "' and Nom_Controle='" & Champs, "Param_Rubriques")
    End Function
    Public Function FindParam(ByVal Valeur As String) As Object
        Dim Rslt As Object = Nothing
        Dim Tbl As DataTable = DATA_READER_GRD("select Cod_Param,isnull(Valeur_User,Valeur) as Valeur,isnull(Type,'') as Type
from Param_General g
outer apply (select Valeur as Valeur_User from Param_General_User where id_User=" & theUser.id_User & " and Cod_Param=g.Cod_Param)u
where Cod_Param='" & Valeur & "'")
        If Tbl.Rows.Count > 0 Then
            Rslt = Tbl.Rows(0).Item("Valeur")
            Select Case Tbl.Rows(0).Item("Type")
                Case "Boolean__"
                    Return CBool(IIf(IsNull(Rslt, "") = "O", True, False))
                Case "Calender"
                    If Not IsDate(Rslt) Then
                        Rslt = "01/01/1900 00:00"
                    End If
                    Return CDate(Rslt)
                Case "Ent", "Entier"
                    If Not IsNumeric(Rslt) Then
                        Rslt = 0
                    End If
                    Return CInt(Rslt)
                Case "Numeric", "Double"
                    If Not IsNumeric(Rslt) Then
                        Rslt = 0
                    End If
                    Return CDbl(Rslt)
                Case Else
                    Return CStr(IsNull(Rslt, ""))
            End Select
        End If
        If Left(IsNull(Rslt, ""), 3) = "GV_" Then
            Return GlobalVar(Rslt)
        End If
        Return Rslt
    End Function
    Public Function IsNull(ByVal Champs As Object, ByVal Valeur As String) As String
        If Champs Is Nothing Then
            Return Valeur
        ElseIf Champs.GetType Is GetType(Bitmap) Then
            Return Nothing
        ElseIf IsDBNull(Champs) Then
            Return Valeur
        ElseIf Champs.ToString.Trim = "" Then
            Return Valeur
        Else
            Return Champs
        End If
    End Function

    Public Function estEmail(str As String) As Boolean
        Dim estValide As Boolean = False
        If IsNull(str, "").Trim = "" Then Return False
        Dim rg As New Regex("\b(\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\b")
        Return rg.IsMatch(str)
    End Function
    Public Function DefaultDate(ByVal modul)
        Try
            Dim Dat As Date = CnExecuting("select getdate()").Fields(0).Value
            Dim Dat1 As Date
            Dim datdebbloquageparametre As DateTime = Societe.DateDebPaie
            Dim datfinbloquageparametre As DateTime = Societe.DateFinPaie

            If datdebbloquageparametre <> "" Then
                If Dat1 < datdebbloquageparametre Then
                    Dat1 = datdebbloquageparametre
                End If
            End If
            If Dat1 <= Droits.DatDebContrat Then
                Dat1 = Droits.DatDebContrat
            End If
            If Dat < Dat1 Then
                Dat = Dat1
            End If
            Return FormatDateTime(Dat, DateFormat.ShortDate)
        Catch ex As Exception
            ShowMessageBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Sub Notification(oTitre As String, oTexte As String, AutoClose As Integer, TypeNotif As String)
        Dim r As Rectangle = Screen.GetWorkingArea(leMenu)

        Dim img As Image = My.Resources.Alert_info
        Select Case TypeNotif
            Case "OK"
                img = My.Resources.Alert_Ok
            Case "CRITICAL"
                img = My.Resources.Alert_Critical
            Case "ALERT"
                img = My.Resources.Alert_Alert
        End Select
        With Zoom_Alerte_Msg
            .TitreMsg.Text = oTitre
            .TextMsg.Text = oTexte
            .reflectionImage1.Image = img
            .Location = New Point(r.Right - .Width, r.Bottom - .Height)
            .AlertAnimation = eAlertAnimation.BottomToTop
            .AlertAnimationDuration = 300
            If AutoClose > 0 Then
                .AutoClose = True
                .AutoCloseTimeOut = AutoClose
                .BringToFront()
                .BringToFront()
                .Show()
            Else
                .ShowDialog()
            End If
        End With
    End Sub
End Module
