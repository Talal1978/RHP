Imports System.ComponentModel
Imports DevComponents.AdvTree

Public Class Mailing
    '    Dim Excluding_List As String
    '    Dim oTable As New DataTable
    '    Dim uploadpath As String = FindParam("Lecteur_Digital_Upload")
    '    Private Sub Param_Messagerie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '        Initialisation()
    '        PJ_List.SmallImageList = imageList1
    '        Adv.Nodes.Clear()
    '        RequestDestinataire(-99)
    '        With Grd_Destinataire
    '            For i = 0 To .ColumnCount - 1
    '                If .Columns(i).Name <> "" Then
    '                    Dim Nod As New Node
    '                    Nod.DragDropEnabled = True
    '                    Nod.Text = .Columns(i).HeaderText
    '                    Nod.Name = "@@@" & .Columns(i).Name
    '                    Nod.Image = My.Resources.fleche
    '                    Adv.Nodes.Add(Nod)
    '                End If
    '            Next
    '        End With
    '    End Sub
    '    Sub Initialisation()
    '        Reset_Form(Me)
    '        Grd_Destinataire.DataSource = Nothing
    '    End Sub
    '    sub Nouveau
    '        Initialisation()
    '        Dim Str As String = InputBox("Veuillez saisir le code de la compagne mailing")
    '        If Str = "" Then
    '            Exit Sub
    '        End If
    '        If (Str.Contains("'") Or Str.Contains(Chr(34)) Or Str.Contains("&")) Then
    '            MessageBoxRHP(51)
    '            Exit Sub
    '        End If
    '        Cod_Mailing_Text.Text = Str

    '    End Sub

    '    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
    '        Appel_Zoom1("MS062", Cod_Mailing_Text, Me)
    '    End Sub

    '    Private Sub Cod_Mailing_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Mailing_Text.TextChanged
    '        Requesting()
    '    End Sub
    '    Sub Requesting()
    '        Dim rs As New ADODB.Recordset
    '        rs.Open("select top 1 * from Mailing where Cod_Mailing='" & Cod_Mailing_Text.Text & "'", cn, 3, 3)
    '        If Not rs.EOF Then
    '            Lib_Mailing_Text.Text = rs("Lib_Mailing").Value
    '            Mailing_List_txt.Text = rs("Mailing_List").Value
    '            ReplyTo_Text.Text = rs("ReplyTo").Value
    '            CC_Text.Text = rs("CC").Value
    '            CCi_Text.Text = rs("CCi").Value
    '            Header_Mail_Text.Text = rs("Header_Mail").Value
    '            Footer_Mail_Text.Text = rs("Footer_Mail").Value
    '            Sujet_Mail_Text.Text = rs("Sujet_Mail").Value
    '            Cod_Query_Text.Text = rs("Cod_Query").Value
    '            Cod_Report_Text.Text = rs("Cod_Report").Value
    '            MajRapport()
    '        Else
    '            Lib_Mailing_Text.Text = ""
    '            Mailing_List_txt.Text = ""
    '            ReplyTo_Text.Text = ""
    '            CC_Text.Text = ""
    '            CCi_Text.Text = ""
    '            Header_Mail_Text.Text = ""
    '            Footer_Mail_Text.Text = ""
    '            Sujet_Mail_Text.Text = ""
    '            Cod_Query_Text.Text = ""
    '            Cod_Report_Text.Text = ""
    '            MajRapport()
    '        End If
    '        rs.Close()
    '        MajPJList()
    '        ' Grd_Query.DataSource = DATA_READER_GRD("select Critere,Valeur from Mailing_Critere where Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Cod_Query='" & Cod_Query_Text.Text & "' and Typ_Query='SQL'")
    '        '  Grd_CrystalReport.DataSource = DATA_READER_GRD("select Critere,Valeur from Mailing_Critere where Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Cod_Query='" & Cod_Report_Text.Text & "' and Typ_Query='RPT'")

    '    End Sub
    '    Sub MajRapport()
    '        Dim Tbl As New DataTable
    '        Tbl = DATA_READER_GRD("select  Email, max(Dat_Envoi) as 'Envoyé le', case Envoye when 1 then 'Oui' else 'Non' end as 'Envoyé?' 
    'from Mailing_Rapport r
    'outer apply(select top 1 Email from Mailing_Destinataire  where id_Destinataire=r.id_Destinataire)d
    'where Cod_Mailing='" & Cod_Mailing_Text.Text & "'
    'group by Email, case Envoye when 1 then 'Oui' else 'Non' end")
    '        With Rapport_Grd
    '            .DataSource = Tbl
    '            .ReadOnly = True
    '            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    '        End With
    '    End Sub
    '    sub Enregistrer
    '        Saving()
    '    End Sub
    '    Sub Saving()
    '        Try
    '            Dim rnd As New Random
    '            Dim flagMaj As Integer = rnd.Next(156, 59875)
    '            If Grd_Destinataire.RowCount = 0 Then
    '                TabControl1.SelectedIndex = 2
    '                ShowMessageBox("Liste de destinataires vide", "Destinataire", MessageBoxButtons.OK, msgIcon.Stop)
    '                Return
    '            End If
    '            If Sujet_Mail_Text.Text.Trim = "" Then
    '                TabControl1.SelectedIndex = 1
    '                ShowMessageBox("Sujet vide", "Destinataire", MessageBoxButtons.OK, msgIcon.Stop)
    '                Sujet_Mail_Text.Select()
    '                Return
    '            End If
    '            If Header_Mail_Text.Text = "" And Footer_Mail_Text.Text = "" And Cod_Query_Text.Text = "" Then
    '                MessageBoxRHP(586)
    '                Exit Sub
    '            End If
    '            CC_Text.Text = CC_Text.Text.Trim.Replace(",", ";")
    '            Dim Cc() As String = CC_Text.Text.Trim.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
    '            Dim CcStr As String = ""
    '            For i = 0 To Cc.Length - 1
    '                If Not estEmail(Cc(i)) Then
    '                    ShowMessageBox("Erreur format email : " & Cc(i), "Champs Cc", MessageBoxButtons.OK, msgIcon.Stop)
    '                    CC_Text.Select()
    '                    Return
    '                End If
    '                CcStr &= IIf(CcStr = "", "", ";") & Cc(i).Trim
    '            Next
    '            CC_Text.Text = CcStr
    '            CCi_Text.Text = CCi_Text.Text.Trim.Replace(",", ";")
    '            Cc = CCi_Text.Text.Trim.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
    '            CcStr = ""
    '            For i = 0 To Cc.Length - 1
    '                If Not estEmail(Cc(i)) Then
    '                    ShowMessageBox("Erreur format email : " & Cc(i), "Champs Cci", MessageBoxButtons.OK, msgIcon.Stop)
    '                    CCi_Text.Select()
    '                    Return
    '                End If
    '                CcStr &= IIf(CcStr = "", "", ";") & Cc(i).Trim
    '            Next
    '            CCi_Text.Text = CcStr
    '            If Lib_Mailing_Text.Text = "" Or Cod_Mailing_Text.Text = "" Then
    '                MessageBoxRHP(587)
    '                Exit Sub
    '            End If
    '            Dim rs As New ADODB.Recordset
    '            rs.Open("select * from Mailing where Cod_Mailing='" & Cod_Mailing_Text.Text & "'", cn, 2, 2)
    '            If Not rs.EOF Then
    '                rs.Update()
    '            Else
    '                rs.AddNew()
    '            End If
    '            rs("Cod_Mailing").Value = Cod_Mailing_Text.Text
    '            rs("Lib_Mailing").Value = Lib_Mailing_Text.Text
    '            rs("Mailing_List").Value = Mailing_List_txt.Text
    '            rs("ReplyTo").Value = ReplyTo_Text.Text
    '            rs("CC").Value = CC_Text.Text
    '            rs("CCi").Value = CCi_Text.Text
    '            rs("Header_Mail").Value = Header_Mail_Text.Text
    '            rs("Footer_Mail").Value = Footer_Mail_Text.Text
    '            rs("Sujet_Mail").Value = Sujet_Mail_Text.Text
    '            rs("Cod_Query").Value = Cod_Query_Text.Text
    '            rs("Cod_Report").Value = Cod_Report_Text.Text
    '            rs.Update()
    '            rs.Close()

    '            'Saving Destinataire


    '            'Saving Criteres SQL
    '            CnExecuting("delete from Mailing_Critere where Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Typ_Query='SQL'")
    '            With Grd_Query
    '                rs.Open("select * from Mailing_Critere where Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Typ_Query='SQL'", cn, 2, 2)
    '                For i = 0 To .RowCount - 1
    '                    rs.AddNew()
    '                    rs("Cod_Mailing").Value = Cod_Mailing_Text.Text
    '                    rs("Cod_Query").Value = Cod_Query_Text.Text
    '                    rs("Typ_Query").Value = "SQL"
    '                    rs("Critere").Value = .Item("Critere", i).Value
    '                    rs("Valeur").Value = .Item("Valeur", i).Value
    '                    rs.Update()
    '                Next
    '                rs.Close()
    '            End With
    '            'Saving Criteres Crystal
    '            CnExecuting("delete from Mailing_Critere where Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Typ_Query='RPT'")
    '            With Grd_CrystalReport
    '                rs.Open("select * from Mailing_Critere where Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Typ_Query='RPT'", cn, 2, 2)
    '                For i = 0 To .RowCount - 1
    '                    rs.AddNew()
    '                    rs("Cod_Mailing").Value = Cod_Mailing_Text.Text
    '                    rs("Cod_Query").Value = Cod_Report_Text.Text
    '                    rs("Typ_Query").Value = "RPT"
    '                    rs("Critere").Value = .Item("cr_Critere", i).Value
    '                    rs("Valeur").Value = .Item("cr_Valeur", i).Value
    '                    rs.Update()
    '                Next
    '                rs.Close()
    '            End With
    '            'Saving PJ
    '            For Each c As ListViewItem In PJ_List.Items
    '                If IO.File.Exists(c.Tag) Then
    '                    rs.Open("select * from Mailing_PJ where Nom_Fichier='" & c.Name & "' and Cod_Mailing='" & Cod_Mailing_Text.Text & "'", cn, 2, 2)
    '                    Dim fi As New IO.FileInfo(c.Tag)
    '                    If Not IO.File.Exists(uploadpath & "\" & c.Name & fi.Extension) Then
    '                        IO.File.Copy(c.Tag, uploadpath & "\" & c.Name & fi.Extension)
    '                    End If
    '                    If rs.EOF Then
    '                        rs.AddNew()
    '                    Else
    '                        rs.Update()
    '                    End If
    '                    rs("Cod_Mailing").Value = Cod_Mailing_Text.Text
    '                    rs("Nom_Fichier").Value = c.Name
    '                    rs("Alias_Fichier").Value = c.Text
    '                    rs("Extension").Value = fi.Extension
    '                    rs("Rang").Value = c.Index
    '                    rs("Flag_Maj").Value = flagMaj
    '                    rs.Update()
    '                    rs.Close()
    '                End If
    '            Next
    '            CnExecuting("delete from Mailing_PJ where isnull(Flag_Maj,0)<>'" & flagMaj & "' and Cod_Mailing='" & Cod_Mailing_Text.Text & "'")

    '        Catch ex As Exception
    '            ErrorMsg(ex)
    '        End Try
    '    End Sub

    '    Private Sub Envoyer_Mail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Envoyer_Mail.Click
    '        If Not EnvoyerCompagneBGW.IsBusy Then EnvoyerCompagneBGW.RunWorkerAsync()
    '    End Sub
    '#Region "Requete"
    '    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
    '        Appel_Zoom1("MS050", Cod_Query_Text, Me)
    '    End Sub
    '    Private Sub Cod_Query_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Query_Text.TextChanged
    '        Nom_Query_Text.Text = FindLibelle("Nom_Query", "Cod_Query", Cod_Query_Text.Text, "Param_Query")
    '        With Grd_Query
    '            .Rows.Clear()
    '            Dim Cod_Sql As String = "Select Critere,Lib_Critere,isnull(Valeur,Default_Value) as Default_Value,Fonction_Critere  from Param_Query_Criteres q
    '            outer apply (select isnull(Valeur,'') as Valeur from Mailing_Critere where isnull(Typ_Query,'')='SQL' and Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Cod_Query=q.Cod_Query and Critere=q.Critere) m
    '            where Cod_Query='" & Cod_Query_Text.Text & "' 
    '            order by rang"
    '            Dim Tbl As DataTable = DATA_READER_GRD(Cod_Sql)
    '            Dim C1, C2, C3, C4 As Object
    '            With Tbl
    '                For i = 0 To .Rows.Count - 1

    '                    C1 = IsNull(Tbl.Rows(i).Item("Critere"), "")
    '                    C2 = IsNull(Tbl.Rows(i).Item("Lib_Critere"), "")
    '                    C3 = IsNull(.Rows(i).Item("Default_Value"), "")
    '                    C4 = IsNull(Tbl.Rows(i).Item("Fonction_Critere"), "")
    '                    Grd_Query.Rows.Add(C1, C2, C3, C4)
    '                Next
    '            End With

    '        End With

    '    End Sub
    '#End Region
    '#Region "Etat CrystalReport"
    '    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
    '        Appel_Zoom("Cod_Report", "Nom_Report", "Param_Mod_Edition", "1=1", Cod_Report_Text, Me)
    '    End Sub
    '    Private Sub Cod_Report_Text_TextChanged(sender As Object, e As EventArgs) Handles Cod_Report_Text.TextChanged
    '        Nom_Report_Text.Text = FindLibelle("Nom_Report", "Cod_Report", Cod_Report_Text.Text, "Param_Mod_Edition")
    '        With Grd_CrystalReport
    '            .Rows.Clear()
    '            Dim Cod_Sql As String = "Select Critere,Lib_Critere,isnull(Valeur,Default_Value) as Default_Value,Fonction_Critere  from Param_Mod_Edition_Criteres q
    '            outer apply (select isnull(Valeur,'') as Valeur from Mailing_Critere where isnull(Typ_Query,'')='RPT' and Cod_Mailing='" & Cod_Mailing_Text.Text & "' and Cod_Query=q.Cod_Report and Critere=q.Critere) m
    '            where Cod_Report='" & Cod_Report_Text.Text & "' 
    '            order by rang"
    '            Dim Tbl As DataTable = DATA_READER_GRD(Cod_Sql)
    '            Dim C1, C2, C3, C4 As Object
    '            With Tbl
    '                For i = 0 To .Rows.Count - 1
    '                    C1 = IsNull(Tbl.Rows(i).Item("Critere"), "")
    '                    C2 = IsNull(Tbl.Rows(i).Item("Lib_Critere"), "")
    '                    C3 = IsNull(.Rows(i).Item("Default_Value"), "")
    '                    C4 = IsNull(Tbl.Rows(i).Item("Fonction_Critere"), "")
    '                    Grd_CrystalReport.Rows.Add(C1, C2, C3, C4)
    '                Next
    '            End With
    '        End With
    '    End Sub
    '#End Region
    '#Region "PiècesJointes"
    '    Sub MajPJList()
    '        PJ_List.BeginUpdate()
    '        Dim Tbl As DataTable = DATA_READER_GRD("select * from Mailing_PJ where Cod_Mailing='" & Cod_Mailing_Text.Text & "' order by Rang")
    '        Dim Fichier As String = ""
    '        Dim iconForFile As Icon = SystemIcons.WinLogo
    '        With Tbl
    '            PJ_List.Items.Clear()
    '            For i = 0 To .Rows.Count - 1
    '                Fichier = IsNull(.Rows(i)("Nom_Fichier"), "") & IsNull(.Rows(i)("Extension"), "")
    '                Fichier = uploadpath & "\" & Fichier
    '                If IO.File.Exists(Fichier) Then
    '                    Dim fi As IO.FileInfo = New IO.FileInfo(Fichier)
    '                    Dim oItm As New ListViewItem
    '                    oItm.Text = .Rows(i)("Alias_Fichier")
    '                    oItm.Name = .Rows(i)("Nom_Fichier")
    '                    oItm.Tag = Fichier
    '                    If Not (imageList1.Images.ContainsKey(fi.Extension)) Then
    '                        ' If not, add the image to the image list.
    '                        iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)
    '                        imageList1.Images.Add(fi.Extension, iconForFile)
    '                    End If
    '                    oItm.ImageKey = fi.Extension
    '                    If Not PJ_List.Items.Contains(oItm) Then PJ_List.Items.Add(oItm)
    '                End If
    '            Next
    '        End With
    '        PJ_List.EndUpdate()
    '    End Sub
    '    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
    '        Dim Fichier As String = OuvrirFichier()
    '        Dim iconForFile As Icon = SystemIcons.WinLogo
    '        If Not Fichier.Trim = "" Then
    '            If IO.File.Exists(Fichier) Then
    '                Dim fi As IO.FileInfo = New IO.FileInfo(Fichier)
    '                Dim oItm As New ListViewItem
    '                oItm.Text = fi.Name
    '                oItm.Name = Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second & Now.Millisecond & PJ_List.Items.Count
    '                oItm.Tag = Fichier
    '                If Not (imageList1.Images.ContainsKey(fi.Extension)) Then
    '                    ' If not, add the image to the image list.
    '                    iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName)
    '                    imageList1.Images.Add(fi.Extension, iconForFile)
    '                End If
    '                oItm.ImageKey = fi.Extension
    '                If Not PJ_List.Items.Contains(oItm) Then
    '                    PJ_List.Items.Add(oItm)
    '                End If
    '            End If
    '        End If
    '    End Sub
    '    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
    '        With PJ_List
    '            For Each c As ListViewItem In .SelectedItems
    '                .Items.Remove(c)
    '            Next
    '        End With
    '    End Sub
    '#End Region
    '    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
    '        Appel_Zoom1("MS104", Mailing_List_txt, Me)
    '    End Sub
    '    Private Sub Mailing_List_txt_TextChanged(sender As Object, e As EventArgs) Handles Mailing_List_txt.TextChanged
    '        Lib_Mailing_List_txt.Text = FindLibelle("Lib_List", "Cod_List", IsNull(Mailing_List_txt.Text, "-99"), "Mailing_List")
    '        RequestDestinataire(IsNull(Mailing_List_txt.Text, "-99"))
    '    End Sub
    '    Sub RequestDestinataire(CodList As Integer)
    '        Dim Cod_Sql As String = ""
    '        '   Cod_Sql = ""
    '        '    Dim Tbl As DataTable = DATA_READER_GRD(Cod_Sql)
    '        With Grd_Destinataire
    '            '         .DataSource = Tbl
    '            '   .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    '            '  .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    '            '    .Columns("Civilite").HeaderText = "Civilité"
    '            '     .Columns("Prenom").HeaderText = "Prénom"
    '            '     .Columns("Typ_Tiers").HeaderText = "Type Tiers"
    '            '     .Columns("id_Destinataire").HeaderText = "id Destinataire"
    '            '     .Columns("id_Destinataire").Visible = False
    '            '     .ContextMenuStrip = AddContextMenu(False, True, True, False, False, False, False, False)
    '            '   FonctionDeRecherche({ .Columns("Civilite").Index, .Columns("Nom").Index, .Columns("Prenom").Index, .Columns("Email").Index, .Columns("Typ_Tiers").Index, .Columns("Tiers").Index, .Columns("Code").Index}, Grd_Destinataire)
    '        End With
    '    End Sub
    '    Private Sub PJ_List_DoubleClick(sender As Object, e As EventArgs) Handles PJ_List.DoubleClick
    '        With PJ_List
    '            If .SelectedItems.Count = 0 Or .SelectedItems.Count > 1 Then Return
    '            Try
    '                StartPrograme(.SelectedItems(0).Tag)
    '            Catch ex As Exception

    '            End Try
    '        End With
    '    End Sub

    '    Private Sub PJ_List_KeyUp(sender As Object, e As KeyEventArgs) Handles PJ_List.KeyUp
    '        With PJ_List
    '            If e.KeyData = Keys.Delete Then
    '                If .SelectedItems.Count = 0 Or .SelectedItems.Count > 1 Then Return
    '                .Items.Remove(.SelectedItems(0))
    '            End If
    '        End With
    '    End Sub
    '    Private Sub Adv_NodeDoubleClick(sender As Object, e As TreeNodeMouseEventArgs) Handles Adv.NodeDoubleClick
    '        Dim oText As New TextBox
    '        Dim Str As String = e.Node.Name

    '        If Footer_Mail_Text.SelectionStart > 0 Then
    '            oText = Footer_Mail_Text
    '        ElseIf Sujet_Mail_Text.SelectionStart > 0 Then
    '            oText = Sujet_Mail_Text
    '        ElseIf Grd_Query.SelectedCells.Count = 1 And TabControl1.SelectedIndex = 0 And TabControl2.Selectedindex = 0 Then
    '            If Grd_Query.SelectedCells(0).ColumnIndex = Valeur.Index Then
    '                Grd_Query.SelectedCells(0).Value = Str
    '                Return
    '            End If
    '        ElseIf Grd_CrystalReport.SelectedCells.Count = 1 And TabControl1.SelectedIndex = 0 And TabControl2.Selectedindex = 1 Then
    '            If Grd_CrystalReport.SelectedCells(0).ColumnIndex = Valeur.Index Then
    '                Grd_CrystalReport.SelectedCells(0).Value = Str
    '                Return
    '            End If
    '        Else
    '            oText = Header_Mail_Text
    '        End If
    '        oText.Text = oText.Text.Insert(oText.SelectionStart, Str)

    '    End Sub

    '    Private Sub EnvoyerCompagneBGW_DoWork(sender As Object, e As DoWorkEventArgs) Handles EnvoyerCompagneBGW.DoWork
    '        CompagneMailing(Cod_Mailing_Text.Text)
    '    End Sub
    '    Private Sub EnvoyerCompagneBGW_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles EnvoyerCompagneBGW.RunWorkerCompleted
    '        MajRapport()
    '        TabControl1.SelectedTab = TabPage4
    '    End Sub
End Class