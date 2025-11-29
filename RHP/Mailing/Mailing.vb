Imports System.Text.RegularExpressions
Imports DevComponents.AdvTree

Public Class Mailing
    Dim Excluding_List As String
    Dim oTable As New DataTable
    Dim uploadpath As String = FindParam("Lecteur_Digital_Upload")
    Private Sub Param_Messagerie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Initialisation()
        PJ_List.SmallImageList = imageList1
        Adv.Nodes.Clear()
        RequestDestinataire()

    End Sub
    Sub Initialisation()
        Reset_Form(Me)
        Grd_Destinataire.DataSource = Nothing
    End Sub
    Sub Nouveau()
        Initialisation()
        Dim Str As String = InputBox("Veuillez saisir le code de la compagne mailing")
        If Str = "" Then
            Exit Sub
        End If
        If (Str.Contains("'") Or Str.Contains(Chr(34)) Or Str.Contains("&")) Then
            MessageBoxRHP(51)
            Exit Sub
        End If
        Cod_Mailing_Text.Text = Str

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS062", Cod_Mailing_Text, Me)
    End Sub
    Sub Chargement()
        If Typ_Param.Items.Count = 0 Then Combo_GRD(Typ_Param)
        If Fonction_Critere.Items.Count = 0 Then Combo_GRD(Fonction_Critere)
        Report_with_Pw_chk.Checked = False
    End Sub
    Private Sub Cod_Mailing_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Mailing_Text.TextChanged
        Requesting()
    End Sub
    Sub Requesting()
        Chargement()
        Dim rs As New ADODB.Recordset
        rs.Open("select top 1 * from Mailing where Cod_Mailing='" & Cod_Mailing_Text.Text & "'", cn, 3, 3)
        If Not rs.EOF Then
            Lib_Mailing_Text.Text = rs("Lib_Mailing").Value
            Mailing_List_txt.Text = rs("Mailing_List").Value
            ReplyTo_Text.Text = rs("ReplyTo").Value
            R_Source_Liste_rd.Checked = (IsNull(rs("sql_Destinataires").Value, "") = "" And IsNull(rs("Mailing_List").Value, "") <> "")
            R_Source_Sql_rd.Checked = IsNull(rs("sql_Destinataires").Value, "") <> ""
            sql_Destinataires_txt.Text = IsNull(rs("sql_Destinataires").Value, "")
            CC_Text.Text = rs("CC").Value
            CCi_Text.Text = rs("CCi").Value
            Header_Mail_Text.Text = rs("Header_Mail").Value
            Footer_Mail_Text.Text = rs("Footer_Mail").Value
            Sujet_Mail_Text.Text = rs("Sujet_Mail").Value
            Cod_Query_Text.Text = rs("Cod_Query").Value
            Cod_Report_Text.Text = rs("Cod_Report").Value
            Report_with_Pw_chk.Checked = IsNull(rs("Report_with_Pw").Value, False)
            MajRapport()
        Else
            Lib_Mailing_Text.Text = ""
            Mailing_List_txt.Text = ""
            ReplyTo_Text.Text = ""
            CC_Text.Text = ""
            CCi_Text.Text = ""
            Header_Mail_Text.Text = ""
            Footer_Mail_Text.Text = ""
            Sujet_Mail_Text.Text = ""
            Cod_Query_Text.Text = ""
            Cod_Report_Text.Text = ""
            Report_with_Pw_chk.Checked = False
            MajRapport()
        End If
        rs.Close()
        MajPJList()
        Dim Cod_Sql As String
        Dim C1, C2, C3, C4, C5, C6, C7, C8, C9, C10 As Object
        Cod_Sql = "Select  * From Mailing_Parametres where Cod_Mailing='" & Cod_Mailing_Text.Text & "'"
        Grd_Parametres.Rows.Clear()
        Dim Tbl As New DataTable
        Tbl = DATA_READER_GRD(Cod_Sql)
        With Tbl
            For i = 0 To .Rows.Count - 1
                C1 = IsNull(.Rows(i).Item("Parametre"), "")
                C2 = IsNull(.Rows(i).Item("Lib_Parametre"), "")
                C3 = IsNull(.Rows(i).Item("Typ_Parametre"), "")
                C4 = IsNull(.Rows(i).Item("Fonction_Parametre"), "")
                C5 = IsNull(.Rows(i).Item("Table_Parametre"), "")
                C6 = IsNull(.Rows(i).Item("Champs_01"), "")
                C7 = IsNull(.Rows(i).Item("Champs_02"), "")
                C8 = IsNull(.Rows(i).Item("Condition"), "")
                C10 = IsNull(.Rows(i).Item("Default_Value"), "")
                C9 = IsNull(.Rows(i).Item("Rang"), "")
                Grd_Parametres.Rows.Add(C1, C2, C3, C4, C5, C6, C7, C8, C10, C9)
            Next
        End With
        ' Grd_Query.DataSource = DATA_READER_GRD("select Critere,Valeur from Mailing_Critere where Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Cod_Query='" & Cod_Query_Text.Text & "' and Typ_Query='SQL'")
        '  Grd_CrystalReport.DataSource = DATA_READER_GRD("select Critere,Valeur from Mailing_Critere where Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Cod_Query='" & Cod_Report_Text.Text & "' and Typ_Query='RPT'")
        RequestDestinataire()
    End Sub
    Sub MajRapport()
        Dim Tbl As New DataTable
        Tbl = DATA_READER_GRD("select  Email, max(Dat_Envoi) as 'Envoyé le', case Envoye when 1 then 'Oui' else 'Non' end as 'Envoyé?' 
    from Mailing_Rapport r 
    where Cod_Mailing='" & Cod_Mailing_Text.Text & "'
    group by Email, case Envoye when 1 then 'Oui' else 'Non' end")
        With Rapport_Grd
            .DataSource = Tbl
            .ReadOnly = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub
    Sub Deleting()
        CnExecuting("delete from Mailing where Cod_Mailing='" & Cod_Mailing_Text.Text & "'")
        CnExecuting("delete from Controle_TreeView where Name_Ecran='" & Cod_Mailing_Text.Text & "' and Typ_Ecran='EML'")
        CnExecuting("delete from Controle_Menu where Name_Ecran='" & Cod_Mailing_Text.Text & "'  and Typ_Ecran='EML'")
    End Sub
    Sub Enregistrer()
        Saving()
    End Sub
    Sub Dupliquer()

    End Sub
    Sub Saving()
        Try
            Dim rs1 As New ADODB.Recordset
            Dim rnd As New Random
            Dim flagMaj As Integer = rnd.Next(156, 59875)
            If Grd_Destinataire.RowCount = 0 Then
                TabControl1.SelectedIndex = 2
                ShowMessageBox("Liste de destinataires vide", "Destinataire", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
            If Sujet_Mail_Text.Text.Trim = "" Then
                TabControl1.SelectedIndex = 1
                ShowMessageBox("Sujet vide", "Destinataire", MessageBoxButtons.OK, msgIcon.Stop)
                Sujet_Mail_Text.Select()
                Return
            End If
            If Header_Mail_Text.Text = "" And Footer_Mail_Text.Text = "" And Cod_Query_Text.Text = "" Then
                MessageBoxRHP(586)
                Exit Sub
            End If
            CC_Text.Text = CC_Text.Text.Trim.Replace(",", ";")
            Dim Cc() As String = CC_Text.Text.Trim.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
            Dim CcStr As String = ""
            For i = 0 To Cc.Length - 1
                If Not estEmail(Cc(i)) Then
                    ShowMessageBox("Erreur format email : " & Cc(i), "Champs Cc", MessageBoxButtons.OK, msgIcon.Stop)
                    CC_Text.Select()
                    Return
                End If
                CcStr &= IIf(CcStr = "", "", ";") & Cc(i).Trim
            Next
            CC_Text.Text = CcStr
            CCi_Text.Text = CCi_Text.Text.Trim.Replace(",", ";")
            Cc = CCi_Text.Text.Trim.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
            CcStr = ""
            For i = 0 To Cc.Length - 1
                If Not estEmail(Cc(i)) Then
                    ShowMessageBox("Erreur format email : " & Cc(i), "Champs Cci", MessageBoxButtons.OK, msgIcon.Stop)
                    CCi_Text.Select()
                    Return
                End If
                CcStr &= IIf(CcStr = "", "", ";") & Cc(i).Trim
            Next
            CCi_Text.Text = CcStr
            If Lib_Mailing_Text.Text = "" Or Cod_Mailing_Text.Text = "" Then
                MessageBoxRHP(587)
                Exit Sub
            End If
            'vérifier que les paramètres utilisée dans le mail existent

            Dim pattern As String = "@@@\w+"
            Dim rgP As New Regex(pattern, RegexOptions.IgnoreCase)
            Dim chaineTotal As String = ""
            If rgP.IsMatch(Sujet_Mail_Text.Text) Then chaineTotal &= vbCrLf & Sujet_Mail_Text.Text
            If rgP.IsMatch(Header_Mail_Text.Text) Then chaineTotal &= vbCrLf & Header_Mail_Text.Text
            If rgP.IsMatch(Footer_Mail_Text.Text) Then chaineTotal &= vbCrLf & Footer_Mail_Text.Text
            With Grd_Query
                For i = 0 To .RowCount - 1
                    If IsNull(.Item(Valeur.Index, i).Value, "") <> "" Then
                        If rgP.IsMatch(.Item(Valeur.Index, i).Value) Then chaineTotal &= vbCrLf & .Item(Valeur.Index, i).Value
                    End If
                Next
            End With
            With Grd_CrystalReport
                For i = 0 To .RowCount - 1
                    If IsNull(.Item(cr_Valeur.Index, i).Value, "") <> "" Then
                        If rgP.IsMatch(.Item(cr_Valeur.Index, i).Value) Then chaineTotal &= vbCrLf & .Item(cr_Valeur.Index, i).Value
                    End If
                Next
            End With
            Dim matches As MatchCollection = Regex.Matches(chaineTotal, pattern)
            ' 3. Boucler sur les résultats trouvés
            For Each m As Match In matches
                Dim tagTrouve As String = m.Value ' Ex: "@@@Nom"
                Dim nod As Node = Adv.FindNodeByName(tagTrouve)
                ' 4. Vérifier si ce tag est dans votre liste autorisée
                If nod Is Nothing Then
                    ShowMessageBox("Le paramètre suivant est introuvable : " & tagTrouve, "Paramètres", MessageBoxButtons.OK, msgIcon.Stop)
                    Return
                End If
            Next

            Dim rs As New ADODB.Recordset
            rs.Open("select * from Mailing where Cod_Mailing='" & Cod_Mailing_Text.Text & "'", cn, 2, 2)
            If Not rs.EOF Then
                rs.Update()
            Else
                rs.AddNew()
            End If
            rs("Cod_Mailing").Value = Cod_Mailing_Text.Text
            rs("Lib_Mailing").Value = Lib_Mailing_Text.Text
            rs("Mailing_List").Value = Mailing_List_txt.Text
            rs("sql_Destinataires").Value = sql_Destinataires_txt.Text
            If sql_Destinataires_txt.Text.Trim <> "" Then
                rs("sql_Destinataires_rendred").Value = sql_Destinataires_txt.Tag
            Else
                rs("sql_Destinataires_rendred").Value = ""
            End If
            rs("ReplyTo").Value = ReplyTo_Text.Text
            rs("CC").Value = CC_Text.Text
            rs("CCi").Value = CCi_Text.Text
            rs("Header_Mail").Value = Header_Mail_Text.Text
            rs("Footer_Mail").Value = Footer_Mail_Text.Text
            rs("Sujet_Mail").Value = Sujet_Mail_Text.Text
            rs("Cod_Query").Value = Cod_Query_Text.Text
            rs("Cod_Report").Value = Cod_Report_Text.Text
            rs("Report_with_Pw").Value = Report_with_Pw_chk.Checked
            rs.Update()
            rs.Close()

            'Saving Destinataire


            'Saving Criteres SQL
            CnExecuting("delete from Mailing_Critere where Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Typ_Query='SQL'")
            With Grd_Query
                rs.Open("select * from Mailing_Critere where Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Typ_Query='SQL'", cn, 2, 2)
                For i = 0 To .RowCount - 1
                    rs.AddNew()
                    rs("Cod_Mailing").Value = Cod_Mailing_Text.Text
                    rs("Cod_Query").Value = Cod_Query_Text.Text
                    rs("Typ_Query").Value = "SQL"
                    rs("Critere").Value = .Item("Critere", i).Value
                    rs("Valeur").Value = .Item("Valeur", i).Value
                    rs.Update()
                Next
                rs.Close()
            End With
            'Saving Criteres Crystal
            CnExecuting("delete from Mailing_Critere where Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Typ_Query='RPT'")
            With Grd_CrystalReport
                rs.Open("select * from Mailing_Critere where Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Typ_Query='RPT'", cn, 2, 2)
                For i = 0 To .RowCount - 1
                    rs.AddNew()
                    rs("Cod_Mailing").Value = Cod_Mailing_Text.Text
                    rs("Cod_Query").Value = Cod_Report_Text.Text
                    rs("Typ_Query").Value = "RPT"
                    rs("Critere").Value = .Item("cr_Critere", i).Value
                    rs("Valeur").Value = .Item("cr_Valeur", i).Value
                    rs.Update()
                Next
                rs.Close()
            End With
            'Saving PJ
            For Each c As ListViewItem In PJ_List.Items
                If IO.File.Exists(c.Tag) Then
                    rs.Open("select * from Mailing_PJ where Nom_Fichier='" & c.Name & "' and Cod_Mailing='" & Cod_Mailing_Text.Text & "'", cn, 2, 2)
                    Dim fi As New IO.FileInfo(c.Tag)
                    If Not IO.File.Exists(uploadpath & "\" & c.Name & fi.Extension) Then
                        IO.File.Copy(c.Tag, uploadpath & "\" & c.Name & fi.Extension)
                    End If
                    If rs.EOF Then
                        rs.AddNew()
                    Else
                        rs.Update()
                    End If
                    rs("Cod_Mailing").Value = Cod_Mailing_Text.Text
                    rs("Nom_Fichier").Value = c.Name
                    rs("Alias_Fichier").Value = c.Text
                    rs("Extension").Value = fi.Extension
                    rs("Rang").Value = c.Index
                    rs("Flag_Maj").Value = flagMaj
                    rs.Update()
                    rs.Close()
                End If
            Next
            CnExecuting("delete from Mailing_PJ where isnull(Flag_Maj,0)<>'" & flagMaj & "' and Cod_Mailing='" & Cod_Mailing_Text.Text & "'")
            With Grd_Parametres
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
                    CnExecuting("Delete from Mailing_Parametres where Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Parametre not in (" & Cod_Sql & ")")
                Else
                    CnExecuting("Delete from Mailing_Parametres where Cod_Mailing='" & Cod_Mailing_Text.Text & "'")
                End If
                For i = 0 To .RowCount - 1
                    If Not .Item(0, i).Value Is Nothing Then
                        rs1.Open("select * from Mailing_Parametres where Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Parametre ='" & .Item(0, i).Value & "'", cn, 2, 2)
                        If rs1.EOF Then
                            rs1.AddNew()
                        Else
                            rs1.Update()
                        End If
                        rs1("Cod_Mailing").Value = Cod_Mailing_Text.Text
                        rs1("Parametre").Value = .Item(0, i).Value
                        rs1("Lib_Parametre").Value = .Item(1, i).Value
                        rs1("Typ_Parametre").Value = .Item(2, i).Value
                        rs1("Fonction_Parametre").Value = .Item(3, i).Value
                        If .Item(3, i).Value = "Appel_Zoom" Then
                            rs1("Table_Parametre").Value = .Item(4, i).Value
                            rs1("Champs_01").Value = .Item(5, i).Value
                            rs1("Champs_02").Value = .Item(6, i).Value
                            rs1("Condition").Value = .Item(7, i).Value

                        ElseIf .Item(3, i).Value = "Combo" Then
                            rs1("Table_Parametre").Value = "Param_Rubriques"
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
            'Insertion du modèle d'édition dans la table génératrice du treeview
            rs1.Open("Select * from Controle_TreeView where Name_Ecran='" & Cod_Mailing_Text.Text & "' and Typ_Ecran='EML'", cn, 2, 2)
            If rs1.EOF Then
                rs1.AddNew()
            Else
                rs1.Update()
            End If
            rs1("Name_Ecran").Value = Cod_Mailing_Text.Text
            rs1("Text_Ecran").Value = Lib_Mailing_Text.Text
            rs1("Typ_Ecran").Value = "EML"
            rs1.Update()
            rs1.Close()

            'Insertion  dans la table Menu et Menu_Droit
            rs1.Open("Select * from Controle_Menu where Name_Ecran='" & Cod_Mailing_Text.Text & "' and Typ_Ecran='EML'", cn, 2, 2)
            If rs1.EOF Then
                rs1.AddNew()
            Else
                rs1.Update()
            End If
            rs1("Name_Ecran").Value = Cod_Mailing_Text.Text
            rs1("Text_Ecran").Value = Lib_Mailing_Text.Text
            rs1("Typ_Ecran").Value = "EML"
            rs1.Update()
            rs1.Close()
            Requesting()
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub

    Sub Envoyer_Mail()
        Dim f As New Mailing_Saisi
        With f
            .Mailing_Generator(Cod_Mailing_Text.Text, Lib_Mailing_Text.Text)
            newShowEcran(f)
        End With
    End Sub
#Region "Requete"
    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Zoom1("MS050", Cod_Query_Text, Me)
    End Sub
    Private Sub Cod_Query_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Query_Text.TextChanged
        Nom_Query_Text.Text = FindLibelle("Nom_Query", "Cod_Query", Cod_Query_Text.Text, "Param_Query")
        With Grd_Query
            .Rows.Clear()
            Dim Cod_Sql As String = "Select Critere,Lib_Critere,isnull(Valeur,Default_Value) as Default_Value,Fonction_Critere  from Param_Query_Criteres q
                outer apply (select isnull(Valeur,'') as Valeur from Mailing_Critere where isnull(Typ_Query,'')='SQL' and Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Cod_Query=q.Cod_Query and Critere=q.Critere) m
                where Cod_Query='" & Cod_Query_Text.Text & "' 
                order by rang"
            Dim Tbl As DataTable = DATA_READER_GRD(Cod_Sql)
            Dim C1, C2, C3, C4 As Object
            With Tbl
                For i = 0 To .Rows.Count - 1

                    C1 = IsNull(Tbl.Rows(i).Item("Critere"), "")
                    C2 = IsNull(Tbl.Rows(i).Item("Lib_Critere"), "")
                    C3 = IsNull(.Rows(i).Item("Default_Value"), "")
                    C4 = IsNull(Tbl.Rows(i).Item("Fonction_Critere"), "")
                    Grd_Query.Rows.Add(C1, C2, C3, C4)
                Next
            End With

        End With

    End Sub
#End Region
#Region "Etat CrystalReport"
    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Appel_Zoom("Cod_Report", "Nom_Report", "Param_Mod_Edition", "1=1", Cod_Report_Text, Me)
    End Sub
    Private Sub Cod_Report_Text_TextChanged(sender As Object, e As EventArgs) Handles Cod_Report_Text.TextChanged
        Nom_Report_Text.Text = FindLibelle("Nom_Report", "Cod_Report", Cod_Report_Text.Text, "Param_Mod_Edition")
        With Grd_CrystalReport
            .Rows.Clear()
            Dim Cod_Sql As String = "Select Critere,Lib_Critere,isnull(Valeur,Default_Value) as Default_Value,Fonction_Critere  from Param_Mod_Edition_Criteres q
                outer apply (select isnull(Valeur,'') as Valeur from Mailing_Critere where isnull(Typ_Query,'')='RPT' and Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Cod_Query=q.Cod_Report and Critere=q.Critere) m
                where Cod_Report='" & Cod_Report_Text.Text & "' 
                order by rang"
            Dim Tbl As DataTable = DATA_READER_GRD(Cod_Sql)
            Dim C1, C2, C3, C4 As Object
            With Tbl
                For i = 0 To .Rows.Count - 1
                    C1 = IsNull(Tbl.Rows(i).Item("Critere"), "")
                    C2 = IsNull(Tbl.Rows(i).Item("Lib_Critere"), "")
                    C3 = IsNull(.Rows(i).Item("Default_Value"), "")
                    C4 = IsNull(Tbl.Rows(i).Item("Fonction_Critere"), "")
                    Grd_CrystalReport.Rows.Add(C1, C2, C3, C4)
                Next
            End With
        End With
    End Sub
#End Region
#Region "PiècesJointes"
    Sub MajPJList()
        PJ_List.BeginUpdate()
        Dim Tbl As DataTable = DATA_READER_GRD("select * from Mailing_PJ where Cod_Mailing='" & Cod_Mailing_Text.Text & "' order by Rang")
        Dim Fichier As String = ""
        Dim iconForFile As Icon = SystemIcons.WinLogo
        With Tbl
            PJ_List.Items.Clear()
            For i = 0 To .Rows.Count - 1
                Fichier = IsNull(.Rows(i)("Nom_Fichier"), "") & IsNull(.Rows(i)("Extension"), "")
                Fichier = uploadpath & "\" & Fichier
                If IO.File.Exists(Fichier) Then
                    Dim fi As IO.FileInfo = New IO.FileInfo(Fichier)
                    Dim oItm As New ListViewItem
                    oItm.Text = .Rows(i)("Alias_Fichier")
                    oItm.Name = .Rows(i)("Nom_Fichier")
                    oItm.Tag = Fichier
                    If Not (imageList1.Images.ContainsKey(fi.Extension)) Then
                        ' If not, add the image to the image list.
                        iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)
                        imageList1.Images.Add(fi.Extension, iconForFile)
                    End If
                    oItm.ImageKey = fi.Extension
                    If Not PJ_List.Items.Contains(oItm) Then PJ_List.Items.Add(oItm)
                End If
            Next
        End With
        PJ_List.EndUpdate()
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim Fichier As String = OuvrirFichier()
        Dim iconForFile As Icon = SystemIcons.WinLogo
        If Not Fichier.Trim = "" Then
            If IO.File.Exists(Fichier) Then
                Dim fi As IO.FileInfo = New IO.FileInfo(Fichier)
                Dim oItm As New ListViewItem
                oItm.Text = fi.Name
                oItm.Name = Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second & Now.Millisecond & PJ_List.Items.Count
                oItm.Tag = Fichier
                If Not (imageList1.Images.ContainsKey(fi.Extension)) Then
                    ' If not, add the image to the image list.
                    iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)
                    imageList1.Images.Add(fi.Extension, iconForFile)
                End If
                oItm.ImageKey = fi.Extension
                If Not PJ_List.Items.Contains(oItm) Then
                    PJ_List.Items.Add(oItm)
                End If
            End If
        End If
    End Sub
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        With PJ_List
            For Each c As ListViewItem In .SelectedItems
                .Items.Remove(c)
            Next
        End With
    End Sub
#End Region
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS104", Mailing_List_txt, Me)
    End Sub
    Private Sub Mailing_List_txt_TextChanged(sender As Object, e As EventArgs) Handles Mailing_List_txt.TextChanged
        Lib_Mailing_List_txt.Text = FindLibelle("Lib_List", "Cod_List", IsNull(Mailing_List_txt.Text, "-99"), "Mailing_List")
        RequestDestinataire()
    End Sub
    Function sqlSourceValide() As Boolean
        Dim rsl = False
        If sql_Destinataires_txt.Text.Trim = "" Then Return False
        Dim Cod_Sql = ""
        With Grd_Parametres
            For i = 0 To .RowCount - 1
                If IsNull(.Item(Parametre.Index, i).Value, "") <> "" Then
                    Dim typ = IsNull(.Item(Typ_Param.Index, i).Value, "nvarchar(max)")
                    If typ <> "" Then
                        Dim declStr As String = $"declare @{ .Item(Parametre.Index, i).Value} {typ}"
                        Dim defVal As String = IsNull(.Item(Default_Value.Index, i).Value, "").Trim
                        If defVal <> "" Then
                            declStr &= $" = '{If(defVal.StartsWith("GV_"), GlobalVar(defVal), defVal)}'"
                        End If
                        Cod_Sql &= declStr & vbCrLf
                    End If
                End If
            Next
        End With
        Cod_Sql &= sql_Destinataires_txt.Text.Replace("@@@", "@")
        Dim rgs As New Regex(sql_injection, RegexOptions.IgnoreCase)
        Dim match As Match = rgs.Match(sql_Destinataires_txt.Text.Trim)
        If match.Success Then
            ShowMessageBox($"Votre expression contient des expressions interdites : '{match.Value}'", "Injection", MessageBoxButtons.OK, msgIcon.Error)
            sql_Destinataires_txt.SelectAll()
            Return False
        End If
        Try
            Dim Tbl As DataTable = DATA_READER_GRD(Cod_Sql)
            If Tbl Is Nothing OrElse Tbl.Columns.Count = 0 Then
                ShowMessageBox("Votre expression ne retourne pas de résultats", "Injection", MessageBoxButtons.OK, msgIcon.Error)
                sql_Destinataires_txt.SelectAll()
                Return False
            End If
            Dim colDic As New Dictionary(Of String, String)
            colDic.Add("Nom", "Nom")
            colDic.Add("Prenom", "Prénom")
            colDic.Add("Email", "Email")
            colDic.Add("Civilite", "Civilité")
            For Each c In colDic.Keys
                Dim cl As DataColumn = Tbl.Columns.Cast(Of DataColumn)().FirstOrDefault(Function(x) x.ColumnName.ToUpper() = c.ToUpper())
                If cl Is Nothing Then
                    ShowMessageBox($"Votre expression doit retourner obligatoirement une colonne nommée :{c}", "Mappage de colonne", MessageBoxButtons.OK, msgIcon.Error)
                    sql_Destinataires_txt.SelectAll()
                    Return False
                Else
                    cl.Caption = colDic(c)
                End If
            Next
            With Grd_Destinataire
                .DataSource = Tbl
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
                .setFilter({ .Columns("Civilite").Index, .Columns("Nom").Index, .Columns("Prenom").Index, .Columns("Email").Index})
            End With
            sql_Destinataires_txt.Tag = Cod_Sql
            Return True
        Catch ex As Exception
            ShowMessageBox(ex.Message, "Erreur", MessageBoxButtons.OK, msgIcon.Error)
            Return False
        End Try
        Return rsl
    End Function
    Sub MajTreeView()
        Adv.Nodes.Clear()
        With Grd_Destinataire
            For i = 0 To .ColumnCount - 1
                If .Columns(i).Name <> "" Then
                    Dim Nod As New Node
                    Nod.DragDropEnabled = True
                    Nod.Text = .Columns(i).HeaderText
                    Nod.Name = "@@@" & .Columns(i).Name
                    Nod.Image = My.Resources.fleche
                    Nod.Tag = "D"
                    Adv.Nodes.Add(Nod)
                End If
            Next
        End With
        With Grd_Parametres
            For i = 0 To .RowCount - 1
                If IsNull(.Item(Parametre.Index, i).Value, "") <> "" Then
                    Dim Nod As New Node
                    Nod.DragDropEnabled = True
                    Nod.Text = .Item(Lib_Parametre.Index, i).Value
                    Nod.Name = "@@@" & .Item(Parametre.Index, i).Value
                    Nod.Image = My.Resources.fleche
                    Nod.Tag = "P"
                    Adv.Nodes.Add(Nod)
                End If
            Next
        End With
        AddReportPW()
    End Sub
    Sub RequestDestinataire()
        If R_Source_Sql_rd.Checked Then
            If Not sqlSourceValide() Then Return
        Else
            With Grd_Destinataire
                Dim CodSql = $"declare @NumList nvarchar(50)={IsNull(Mailing_List_txt.Text, -99) }
select civilite,nom,prenom,email  from Mailing_Destinataire
where @NumList in (select value from string_split(Liste,',')) "
                Dim Tbl As DataTable = DATA_READER_GRD(CodSql)
                .DataSource = Tbl
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .Columns("Civilite").HeaderText = "Civilité"
                .Columns("Prenom").HeaderText = "Prénom"
                .ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
                .setFilter({ .Columns("Civilite").Index, .Columns("Nom").Index, .Columns("Prenom").Index, .Columns("Email").Index})
            End With
        End If
        MajTreeView()
    End Sub
    Private Sub PJ_List_DoubleClick(sender As Object, e As EventArgs) Handles PJ_List.DoubleClick
        With PJ_List
            If .SelectedItems.Count = 0 Or .SelectedItems.Count > 1 Then Return
            Try
                StartPrograme(.SelectedItems(0).Tag)
            Catch ex As Exception

            End Try
        End With
    End Sub

    Private Sub PJ_List_KeyUp(sender As Object, e As KeyEventArgs) Handles PJ_List.KeyUp
        With PJ_List
            If e.KeyData = Keys.Delete Then
                If .SelectedItems.Count = 0 Or .SelectedItems.Count > 1 Then Return
                .Items.Remove(.SelectedItems(0))
            End If
        End With
    End Sub
    Private Sub Adv_NodeDoubleClick(sender As Object, e As TreeNodeMouseEventArgs) Handles Adv.NodeDoubleClick
        Dim oText As New ud_TextBox
        Dim Str As String = e.Node.Name
        If sql_Destinataires_txt.SelectionStart > 0 And TabControl1.SelectedTab Is TabPage1 And Not sql_Destinataires_txt.ReadOnly Then
            If IsNull(e.Node.Tag, "") <> "D" Then oText = sql_Destinataires_txt
        ElseIf Footer_Mail_Text.SelectionStart > 0 And TabControl1.SelectedTab Is TabPage2 Then
            oText = Footer_Mail_Text
        ElseIf Sujet_Mail_Text.SelectionStart > 0 And TabControl1.SelectedTab Is TabPage2 Then
            oText = Sujet_Mail_Text
        ElseIf Grd_Query.SelectedCells.Count = 1 And TabControl1.SelectedTab Is Attachements And TabControl2.SelectedIndex = 0 Then
            If Grd_Query.SelectedCells(0).ColumnIndex = Valeur.Index Then
                Grd_Query.SelectedCells(0).Value = Str
                Return
            End If
        ElseIf Grd_CrystalReport.SelectedCells.Count = 1 And TabControl1.SelectedTab Is Attachements And TabControl2.SelectedIndex = 1 Then
            If Grd_CrystalReport.SelectedCells(0).ColumnIndex = Valeur.Index Then
                Grd_CrystalReport.SelectedCells(0).Value = Str
                Return
            End If
        ElseIf Header_Mail_Text.SelectionStart > 0 And TabControl1.SelectedTab Is TabPage2 Then
            oText = Header_Mail_Text
        Else
            Return
        End If
        oText.Text = oText.Text.Insert(oText.SelectionStart, Str)
    End Sub
    Private Sub sql_Destinataires_txt_Validated(sender As Object, e As EventArgs) Handles sql_Destinataires_txt.Validated
        If Me.ActiveControl IsNot Adv Then
            RequestDestinataire()
        End If
    End Sub

    Private Sub Grd_Parametres_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Parametres.RowValidated
        MajTreeView()
    End Sub

    Private Sub R_Source_Sql_rd_CheckedChanged(sender As Object, e As EventArgs) Handles R_Source_Sql_rd.CheckedChanged
        If R_Source_Sql_rd.Checked Then
            Mailing_List_txt.ResetText()
            sql_Destinataires_txt.ReadOnly = False
        End If
    End Sub

    Private Sub R_Source_Liste_rd_CheckedChanged(sender As Object, e As EventArgs) Handles R_Source_Liste_rd.CheckedChanged
        If R_Source_Liste_rd.Checked Then
            sql_Destinataires_txt.ResetText()
            sql_Destinataires_txt.ReadOnly = True
        End If
    End Sub
    Sub AddReportPW()
        Dim _nod As Node = Adv.FindNodeByName("@@@Pwd")
        If Report_with_Pw_chk.Checked Then
            If _nod Is Nothing Then
                With Adv
                    Dim Nod As New Node
                    Nod.DragDropEnabled = True
                    Nod.Text = "Mot de passe du rapport"
                    Nod.Name = "@@@Pwd"
                    Nod.Image = My.Resources.fleche
                    Nod.Tag = "W"
                    Adv.Nodes.Add(Nod)
                End With
            End If

        Else
            If _nod IsNot Nothing Then
                Adv.Nodes.Remove(_nod)
            End If
        End If
    End Sub
    Private Sub Report_with_Pw_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Report_with_Pw_chk.CheckedChanged
        AddReportPW()
    End Sub
End Class