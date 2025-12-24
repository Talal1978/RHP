Public Class Param_Python
    Friend Code As String = ""
    Dim First_D As ud_btn
    Dim Back_D As ud_btn
    Dim Next_D As ud_btn
    Dim Last_D As ud_btn
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Dupliquer_D As ud_btn
    Dim Exec_D As ud_btn
    Sub Chargement()
        If First_D Is Nothing Then
            First_D = dictButtons("First_D")
            Back_D = dictButtons("Back_D")
            Next_D = dictButtons("Next_D")
            Last_D = dictButtons("Last_D")
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
            Dupliquer_D = dictButtons("Dupliquer_D")
            Exec_D = dictButtons("Exec_D")
            Combo_GRD(Typ_Param)
            Combo_GRD(Fonction_Critere)
        End If
    End Sub
    Private Sub Admin_TreeView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Chargement()

        Dim menu_context_copy As New ContextMenuStrip
        Dim oMenu1 As New ToolStripMenuItem
        With oMenu1
            .Text = "Copier le Contenu de la liste"
            AddHandler .Click, AddressOf menu_context_grd
        End With
        Dim oMenu2 As New ToolStripMenuItem
        With oMenu2
            .Text = "Supprimer la Ligne"
            AddHandler .Click, AddressOf DelRow
        End With
        menu_context_copy.Items.AddRange(New System.Windows.Forms.ToolStripItem() {oMenu1, oMenu2})
        With Grd_Arguments

            .ContextMenuStrip = menu_context_copy
        End With
    End Sub
    Sub Request()
        Dim Cod_Sql As String
        Dim C1, C2, C3, C4, C5, C6, C7, C8, C9, C10 As Object
        Cod_Sql = "Select  * From Param_Python_Arguments where Cod_Python='" & Cod_Python_Text.Text & "'"
        Grd_Arguments.Rows.Clear()
        Dim Tbl As New DataTable
        Tbl = DATA_READER_GRD(Cod_Sql)
        With Tbl
            For i = 0 To .Rows.Count - 1
                C1 = IsNull(.Rows(i).Item("Argument"), "")
                C2 = IsNull(.Rows(i).Item("Lib_Argument"), "")
                C3 = IsNull(.Rows(i).Item("Typ_Critere"), "")
                C4 = IsNull(.Rows(i).Item("Fonction_Critere"), "")
                C5 = IsNull(.Rows(i).Item("Table_Critere"), "")
                C6 = IsNull(.Rows(i).Item("Champs_01"), "")
                C7 = IsNull(.Rows(i).Item("Champs_02"), "")
                C8 = IsNull(.Rows(i).Item("Condition"), "")
                C10 = IsNull(.Rows(i).Item("Default_Value"), "")
                C9 = IsNull(.Rows(i).Item("Rang"), "")
                Grd_Arguments.Rows.Add(C1, C2, C3, C4, C5, C6, C7, C8, C10, C9)
            Next
        End With
    End Sub

    Sub DelRow(ByVal sender, ByVal e)
        With Grd_Arguments
            For Each c As DataGridViewRow In .SelectedRows
                If Not c.IsNewRow Then .Rows.Remove(c)
            Next
        End With
    End Sub
    Sub Deleting()
        If Cod_Python_Text.Text = "" Then Exit Sub
        If MessageBox.Show("Etes-vous sûr de vouloir supprimer cette requête", "Vérification", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) = MsgBoxResult.Cancel Then Exit Sub
        '        Supprimer le Modèle ou le Procedure
        CnExecuting("delete from Param_Python where Cod_Python='" & Cod_Python_Text.Text & "'")
        CnExecuting("delete from Param_Favoris where Form_Name='" & Cod_Python_Text.Text & "'")
            CnExecuting("delete from Controle_TreeView where Name_Ecran='" & Cod_Python_Text.Text & "' and Typ_Ecran='PYT'")
            CnExecuting("delete from Controle_Menu where Name_Ecran='" & Cod_Python_Text.Text & "' and Typ_Ecran='PYT'")
            CnExecuting($"delete from Controle_Def_Ecran_Traitements_Specifiques where Cod_Traitement='{Cod_Python_Text.Text}'")
        Reset_Form(Me)
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        If Nom_Python_Text.Text = "************" Then Nom_Python_Text.Text = ""
        Appel_Zoom1("MS052", Cod_Python_Text, Me)
    End Sub

    Private Sub Name_Ecran_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Python_Text.TextChanged
        If Code <> "" Then
            CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "'")
        End If
        If Nom_Python_Text.Text = "************" Then Exit Sub
        Dim Tbl As DataTable = DATA_READER_GRD("select * from Param_Python where Cod_Python='" & Cod_Python_Text.Text & "'")
        Dim Droit_Societe As String = ""
        With Tbl
            If .Rows.Count > 0 Then
                Nom_Python_Text.Text = .Rows(0)("Nom_Python")
                Text_Code_txt.Text = .Rows(0)("Text_Code")
                Typ_Python_Text.Text = .Rows(0)("Typ_Python")
                ud_withConn.Checked = IsNull(.Rows(0)("withConn"), False)
                Actif_chk.Checked = IsNull(.Rows(0)("Actif"), False)
            Else
                Nom_Python_Text.Text = ""
                Text_Code_txt.Text = ""
                Typ_Python_Text.Text = "U"
                Actif_chk.Checked = True
                ud_withConn.Checked = False
            End If
        End With


        'Afficher la photo
        If Typ_Python_Text.Text = "S" Then
            Del_D.Enabled = False
            Text_Code_txt.ReadOnly = True
            Grd_Arguments.ReadOnly = True

        Else
            Del_D.Enabled = True
            Text_Code_txt.ReadOnly = False
            Grd_Arguments.ReadOnly = False

        End If

        Request()


    End Sub

    Sub Saving()
        'vérifier que python fonctionne
        Dim msg As New System.Text.StringBuilder
        Dim codeUser As String =
"print('1- Tester Pyhton.', flush=True)"

        Dim ok = executerCodePython(codeUser, msg, True) ' withConn := True -> import pyodbc + connexion SQL
        If Not ok.result Then
            MsgBox("Erreur Python :" & vbCrLf & msg.ToString())
        End If
        Grd_Arguments.EndEdit(True)
        If Cod_Python_Text.Text = "" Then Exit Sub
        If Cod_Python_Text.Text.Contains("'") = True Or
Cod_Python_Text.Text.Contains(",") = True Or
Cod_Python_Text.Text.Contains("&") = True Then
            MessageBox.Show("Evitez les caractères spéciaux", "Vérification", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If Nom_Python_Text.Text = "" Then
            MessageBox.Show("Nom de la requête vide", "Vérification", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Nom_Python_Text.Select()
            Exit Sub
        End If

        With Grd_Arguments
            For i As Integer = 0 To .RowCount - 2
                If .Item("Rang", i).Value Is Nothing Then
                    MessageBox.Show("Renseigner le rang", "Vérification", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    .Item("Rang", i).Style.ForeColor = Color.Red
                    Exit Sub
                Else
                    For j As Integer = 0 To .RowCount - 2
                        If .Item(Argument.Index, i).Value = .Item(Argument.Index, j).Value And i <> j Then
                            MessageBox.Show("Evitez les doublons de critères", "Vérification", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            .Item(Argument.Index, i).Style.ForeColor = Color.Red
                            Exit Sub
                        End If
                    Next
                End If
            Next
        End With
        Dim nbDs As Integer = 0
        Dim oCode As String = Text_Code_txt.Text
        Dim val As String = ""
        With Grd_Arguments
            For i As Integer = 0 To .RowCount - 2
                If IsNull(.Item(Argument.Index, i).Value, "").Trim <> "" Then
                    .Item(Default_Value.Index, i).Value = IsNull(.Item(Default_Value.Index, i).Value, "")
                    val = If(IsNull(.Item(Default_Value.Index, i).Value, "").ToUpper.StartsWith("GV_"), GlobalVar(CStr(.Item(Default_Value.Index, i).Value).Trim()), CStr(.Item(Default_Value.Index, i).Value).Trim())
                    val = val.Replace("\\", "\")
                    val = val.Replace("\", "/")
                    oCode = vbCrLf & CStr(.Item(Argument.Index, i).Value).ToUpper & " = """ & val & """" & vbCrLf & oCode
                End If
            Next
        End With
        Dim str As New System.Text.StringBuilder
        Dim rsl = codePythonChecker(oCode, str)
        If Not rsl.result Then
            MessageBox.Show("Erreur compilation.", "Vérification", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Dim f As New Zoom_SqlText
            With f
                .Sql_Text.Text = rsl.CodeCompiled & vbCrLf & vbCrLf & "**************  Erreur *****************" & vbCrLf & rsl.Erreur
                .ShowDialog()
            End With
            Return
        End If
        Dim rs, rs1, rs2 As New ADODB.Recordset
        'Insertion du modèle d'édition dans Param_Python
        rs.Open("Select * from Param_Python where Cod_Python='" & Cod_Python_Text.Text & "'", cn, 2, 2)
        If Not rs.EOF Then
            rs.Update()
        Else
            rs.AddNew()
            rs("Created_By").Value = theUser.Login
            rs("Dat_Crea").Value = Now
        End If
        rs("Cod_Python").Value = Cod_Python_Text.Text
        rs("Nom_Python").Value = Nom_Python_Text.Text
        rs("Text_Code").Value = Text_Code_txt.Text
        rs("Actif").Value = Actif_chk.Checked
        rs("Modified_By").Value = theUser.Login
        rs("Dat_Modif").Value = Now
        rs("withConn").Value = ud_withConn.Checked
        rs.Update()
        rs.Close()

        'Insertion  dans la table Menu et Menu_Droit

        If CnExecuting("Select count(*) from Controle_Menu where Name_Ecran='" & Cod_Python_Text.Text & "'").Fields(0).Value > 0 Then
            rs1.Open("Select * from Controle_Menu where Name_Ecran='" & Cod_Python_Text.Text & "'", cn, 2, 2)
            rs1.Update()
        Else
            rs1.Open("Select * from Controle_Menu", cn, 2, 2)
            rs1.AddNew()
        End If
        rs1("Name_Ecran").Value = Cod_Python_Text.Text
        rs1("Text_Ecran").Value = Nom_Python_Text.Text
        rs1("Typ_Ecran").Value = "PYT"
        rs1("Image1").Value = "ud_Pyhton"
        rs1.Update()
        rs1.Close()




        With Grd_Arguments
            Dim Cod_Sql As String = ""
            For i = 0 To .RowCount - 1
                If Not .Item(0, i).Value Is Nothing Then
                    If Cod_Sql = "" Then
                        Cod_Sql = "'" & .Item(0, i).Value & "'"
                    Else
                        Cod_Sql = Cod_Sql & ",'" & .Item(0, i).Value & "'"
                    End If
                End If
            Next

            If Cod_Sql <> "" Then
                CnExecuting("Delete from Param_Python_Arguments where Cod_Python='" & Cod_Python_Text.Text & "' and Argument not in (" & Cod_Sql & ")")
            Else
                CnExecuting("Delete from Param_Python_Arguments where Cod_Python='" & Cod_Python_Text.Text & "'")
            End If
            For i = 0 To .RowCount - 1
                If Not .Item(0, i).Value Is Nothing Then
                    rs1.Open("select * from Param_Python_Arguments where Cod_Python='" & Cod_Python_Text.Text & "' and Argument ='" & .Item(0, i).Value & "'", cn, 2, 2)
                    If rs1.EOF Then
                        rs1.AddNew()
                        rs1("Cod_Python").Value = Cod_Python_Text.Text
                    Else
                        rs1.Update()
                    End If
                    rs1("Argument").Value = .Item(0, i).Value
                    rs1("Lib_Argument").Value = .Item(1, i).Value
                    rs1("Typ_Critere").Value = .Item(2, i).Value
                    rs1("Fonction_Critere").Value = .Item(3, i).Value
                    If .Item(3, i).Value = "Appel_Zoom" Then
                        rs1("Table_Critere").Value = .Item(4, i).Value
                        rs1("Champs_01").Value = .Item(5, i).Value
                        rs1("Champs_02").Value = .Item(6, i).Value
                        rs1("Condition").Value = .Item(7, i).Value

                    ElseIf .Item(3, i).Value = "Combo" Then
                        rs1("Table_Critere").Value = "Param_Rubriques"
                        rs1("Champs_01").Value = "Valeur"
                        rs1("Champs_02").Value = "Membre"
                        rs1("Condition").Value = .Item(7, i).Value

                    End If
                    rs1("Default_Value").Value = .Item("Default_Value", i).Value
                    rs1("Rang").Value = .Item("Rang", i).Value
                    rs1.Update()
                    rs1.Close()
                End If
            Next
        End With
        ShowMessageBox("Enregistré")
    End Sub
    Private Sub Modele_Python_GRD_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grd_Arguments.KeyUp
        With Grd_Arguments
            If e.KeyData = Keys.F6 Then
                If .CurrentCell.ColumnIndex = 4 Then
                    Appel_Zoom("Name", "Name", "sysobjects", "xtype='U' order by Name ", .CurrentCell, Me)
                End If
                If .CurrentCell.ColumnIndex = 5 Or .CurrentCell.ColumnIndex = 6 Then
                    Appel_Zoom("Name", "Name", "sysColumns", "id in (select id from sysobjects where name='" & .Item(4, .CurrentRow.Index).Value & "') order by Name", .CurrentCell, Me)
                End If
            End If
        End With
    End Sub
    Sub Adding()
        Reset()
        Dim A As String = InputBox("Saisissez le Nom du Modèle", "Nouvel Etat ou Procedure")
        If A.Contains("'") Or A.Contains("%") Or A.Contains("&") Or A.Contains(",") Then
            MessageBox.Show("Evitez les caractères spéciaux", "Vérification", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If CnExecuting("select count(*) from Controle_Menu where Name_Ecran='" & A & "'").Fields(0).Value > 0 Then
            Dim strlib As String = FindLibelle("Text_Ecran", "Name_Ecran", Cod_Python_Text.Text, "Controle_Menu")
            MessageBox.Show("Ce nom est déjà utilisé: " & strlib, "Vérification", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If A <> "" Then
            Cod_Python_Text.Text = A
        End If
        Enabling(Nom_Python_Text, True)
    End Sub
    Sub Executing()
        If Cod_Python_Text.Text = "" Then Exit Sub
        If Text_Code_txt.Text = "" Then Exit Sub
        Dim f As New Param_Python_Saisi
        f.Text = Nom_Python_Text.Text
        f.Python_Generator(Cod_Python_Text.Text, Nom_Python_Text.Text)
        newShowEcran(f)
    End Sub
    Sub Dupliquing()
        If Cod_Python_Text.Text = "" Then Exit Sub
        Nom_Python_Text.Text = "************"
        Dim a As String = InputBox("Saisisser le Code de la Requête :", "Duplication de l'élément : " & Nom_Python_Text.Text).ToUpper
        If a.Contains("'") Or a.Contains("%") Or a.Contains("&") Or a.Contains(",") Then
            MessageBox.Show("Evitez les caractères spéciaux", "Vérification", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        ElseIf a = "" Then
            MessageBox.Show("Code vide", "Vérification", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        ElseIf a.Length > 50 Then
            MessageBox.Show("Nombre de caractères supérieur à 50", "Vérification", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If CnExecuting("select count(*) from Param_Python where Cod_Python ='" & a & "'").Fields(0).Value >= 1 Then
            MessageBox.Show("Nom déjà utilisé : " & CnExecuting("select Nom_Python from Param_Python where Cod_Python ='" & a & "'").Fields(0).Value, "Vérification", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        Cod_Python_Text.Text = a
        Typ_Python_Text.Text = "U"
        Del_D.Enabled = True
        Text_Code_txt.ReadOnly = False
        Grd_Arguments.ReadOnly = False
    End Sub
    Private Sub Text_Code_Text_DoubleClick(sender As Object, e As EventArgs) Handles Text_Code_txt.DoubleClick
        Text_Code_txt.SelectAll()
    End Sub
    Private Sub Param_Python_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try

        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Grd_Arguments.EditingControlShowing
        If Grd_Arguments.CurrentCell.ColumnIndex = Argument.Index Then
            ' Check if the editing control is a TextBox
            Dim tb As TextBox = TryCast(e.Control, TextBox)
            If tb IsNot Nothing Then
                ' Remove any existing handler to prevent attaching multiple handlers
                RemoveHandler tb.TextChanged, AddressOf TextBox_TextChanged
                ' Add the TextChanged event handler
                AddHandler tb.TextChanged, AddressOf TextBox_TextChanged
            End If
        End If
    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs)
        Dim tb As TextBox = TryCast(sender, TextBox)
        If tb IsNot Nothing Then
            ' Detach the handler to avoid recursion
            RemoveHandler tb.TextChanged, AddressOf TextBox_TextChanged

            ' Change the text to uppercase
            tb.Text = tb.Text.ToUpper()

            ' Move the cursor to the end of the text
            tb.SelectionStart = tb.Text.Length

            ' Re-attach the handler
            AddHandler tb.TextChanged, AddressOf TextBox_TextChanged
        End If
    End Sub

End Class