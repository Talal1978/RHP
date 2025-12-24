Public Class Org_Organigramme
    Friend TblOrg As New DataTable
    Dim nb, disT, disB, DisL, DisR, disSpV, disSpH, disSpH0, WGrp, HGrp, pnlLarg, pnlHaut, disLine As Integer
    Dim dicGrp As New Dictionary(Of String, Org_Organigram_Element)
    Dim dicColor As New Dictionary(Of String, Color)
    Dim dicX0 As New Dictionary(Of Integer, Integer)
    Dim dicNivY As New Dictionary(Of Integer, Integer)
    Dim rndC As New Random
    Dim oTootlTip As New System.Windows.Forms.ToolTip
    Dim Lbl As New List(Of Label)
    Dim Mypnl As New Panel
    Friend Tbl_Org_Typ_Entite As New DataTable
    Friend Tbl_Org_Entite As New DataTable
    Friend Tbl_RH_Agent As New DataTable
    Friend Tbl_RH_Categorie_Effectif As New DataTable
    Sub InitialisationOrg()
        Tbl_Org_Typ_Entite = DATA_READER_GRD("select * from Org_Typ_Entite")
        Tbl_Org_Entite = DATA_READER_GRD("select * from Org_Entite where  id_Societe=" & Societe.id_Societe)
        Tbl_RH_Agent = DATA_READER_GRD("select Matricule, ltrim(rtrim(ISNULL(Nom_Agent,'')+' '+ISNULL(Prenom_Agent,''))) as Nom, ISNULL(Civilite,'M.') as Civilite ,
ISNULL(nullif(Lib_Poste,''),'Employé') as 'Poste' 
from RH_Agent a
outer apply (select Lib_Poste from Org_Poste where id_Societe =a.id_Societe and Cod_Poste=a.Cod_Poste) f
where id_Societe =" & Societe.id_Societe)
        Tbl_RH_Categorie_Effectif = DATA_READER_GRD("select Cod_Entite,Cod_Grade,isnull(Lib_Grade,'') as Lib_Grade, count(*) as Effectif 
                                            from RH_Agent a
                                            outer apply (select Lib_Grade from Org_Grade where Cod_Grade=a.Cod_Grade and id_Societe=a.id_Societe)c
                                            where id_Societe=" & Societe.id_Societe & "
                                            group by Cod_Entite,Cod_Grade,Lib_Grade")
    End Sub
    Sub InitialisationGraphique()
        Mypnl = New Panel
        With Mypnl
            .Controls.Clear()
            .MinimumSize = leMenu.Size
            .AutoSize = True
            .AutoScroll = True
            .BackColor = Color.White
            .ContextMenuStrip = Org_CMS
        End With
        disT = 5
        disB = 5
        DisL = 5
        DisR = 5
        disSpH = 18
        disLine = 6
        disSpV = disLine * 15
        pnlLarg = Me.Width
        nb = 0
        pnlHaut = Me.Height - entPnl.Height
        disSpH0 = 3
        Mypnl.Controls.Clear()
        Org_pnl.Controls.Clear()
        dicGrp.Clear()
        dicX0.Clear()
        dicColor.Clear()
        dicNivY.Clear()
        Lbl.Clear()
    End Sub
    Private Sub Entite__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Entite_.LinkClicked
        Appel_Zoom1("MS010", Cod_Entite_txt, Me)
    End Sub
    Private Sub AjouterModifierUneEntitéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjouteUneEntitéToolStripMenuItem.Click
        Dim obj As Object = Org_CMS.SourceControl
        Dim f As New Zoom_Org_Organigramme
        With f
            .ModeCreationModification = "C"
            .frm = Me
            .Cod_Entite_txt.Text = ""
            If Not obj Is Nothing Then
                .Parent_txt.Text = obj.name
            Else
                .Parent_txt.Text = ""
            End If
            .ShowDialog()
        End With
    End Sub

    Private Sub ModifierUneEntitéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModifierUneEntitéToolStripMenuItem.Click
        If Mypnl.Controls.Count = 0 Then Return
        Dim obj As Object = Org_CMS.SourceControl
        If Not obj Is Nothing Then
            Dim f As New Zoom_Org_Organigramme
            With f
                .frm = Me
                .ModeCreationModification = "M"
                .Cod_Entite_txt.Text = obj.name
                newShowEcran(f, True)
            End With
        End If
    End Sub
    Private Sub SupprimerCetteEntitéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerCetteEntitéToolStripMenuItem.Click
        If Mypnl.Controls.Count = 0 Then Return
        Dim obj As Object = Org_CMS.SourceControl
        If Not obj Is Nothing Then
            Dim nrw() As DataRow = TblOrg.Select("[Parent]='" & obj.name & "'")
            If nrw.Length > 0 Then
                ShowMessageBox("Entité non vide. Suppression impossible", "Suppression", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
            If ShowMessageBox("Etes-vous sûr de vouloir supprimer l'entité : " & obj.text & " (" & obj.name & ")", "Confirmation de suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.OK Then
                CnExecuting("delete from Org_Entite where Cod_Entite='" & obj.name & "' and id_Societe=" & Societe.id_Societe)
                CnExecuting("update RH_Agent set Cod_Entite='' where Cod_Entite='" & obj.name & "' and id_Societe=" & Societe.id_Societe)
                Interroger()
            End If
        End If
    End Sub

    Private Sub AfficherLaListeDesAgentsAffectésÀCetteEntitéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfficherLaListeDesAgentsAffectésÀCetteEntitéToolStripMenuItem.Click
        If Mypnl.Controls.Count = 0 Then Return
        Dim obj As Object = Org_CMS.SourceControl
        If Not obj Is Nothing Then
            Dim f As New Zoom_Org_Organigramme_ListeAgent
            With f
                .Text = "Liste des agents affectés à l'entité : " & obj.text & " (" & obj.name & ")"
                .CodEntite = obj.name
                newShowEcran(f, True)
            End With
        End If
    End Sub

    Private Sub EnregistrerEnImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnregistrerEnImageToolStripMenuItem.Click
        ExporterImage()
    End Sub

    Private Sub Cod_Entite_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Entite_txt.TextChanged
        Lib_Entite_txt.Text = FindLibelle("Lib_Entite", "Cod_Entite", Cod_Entite_txt.Text, "Org_Entite")
    End Sub
    Private Sub Rd_Man_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_Man.CheckedChanged
        If Rd_Man.Checked Then
            For Each c As Org_Organigram_Element In dicGrp.Values
                c.GetElementOrganigrame("M")
            Next
        End If

    End Sub
    Private Sub Rd_Entite_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_Entite.CheckedChanged
        If Rd_Entite.Checked Then
            For Each c As Org_Organigram_Element In dicGrp.Values
                c.GetElementOrganigrame("E")
            Next
        End If
    End Sub
    Sub ExporterImage()
        Dim dlg As New SaveFileDialog
        With dlg
            .Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|png (*.png)|*.png|All files (*.*)|*.*"
            .FilterIndex = 3
            If .ShowDialog() = DialogResult.OK Then
                Using bmp = New Bitmap(Mypnl.Width, Mypnl.Height)
                    Mypnl.DrawToBitmap(bmp, New Rectangle(0, 0, bmp.Width, bmp.Height))
                    Dim bmp2 As New Bitmap(bmp.Width * 3, bmp.Height * 3)
                    Dim gr As Graphics = Graphics.FromImage(bmp2)
                    gr.DrawImage(bmp, New Rectangle(0, 0, bmp2.Width, bmp2.Height))
                    bmp2.Save(.FileName, System.Drawing.Imaging.ImageFormat.Png)
                    Process.Start(.FileName)
                End Using
            End If
        End With
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If theUser.Typ_Role = "Agent" Then
            AjouteUneEntitéToolStripMenuItem.Visible = False
            ModifierUneEntitéToolStripMenuItem.Visible = False
            SupprimerCetteEntitéToolStripMenuItem.Visible = False
        End If
        InitialisationOrg()
        Org_pnl.Controls.Add(Mypnl)
        Cod_Entite_txt.Text = CnExecuting("select isnull((select Top 1 Cod_Entite from Org_Entite o 
outer apply (select Niveau_Hierarchique from Org_Typ_Entite where Typ_Entite = o.Typ_Entite)t
where id_Societe=" & Societe.id_Societe & "
order by Niveau_Hierarchique ),'DG')").Fields(0).Value
        Interroger()
    End Sub
    Function CreateElement(CodEntite As String) As Org_Organigram_Element
        Dim Grp As New Org_Organigram_Element
        With Grp
            .frm = Me
            .CodEntite = CodEntite
        End With
        Return Grp
    End Function
    Dim oMov As Boolean = False
    Dim nbClick As Integer = 0
    Dim P0 As New Point
    Sub Interroger()

        Try
            InitialisationOrg()
            If Cod_Entite_txt.Text.Trim = "" Then
                Cod_Entite_txt.Text = CnExecuting("select isnull((select top 1 Cod_Entite  from Org_Entite e
outer apply (select Niveau_Hierarchique from Org_Typ_Entite where Typ_Entite =e.Typ_Entite )t
where id_Societe =" & Societe.id_Societe & " and isnull(e.Attachement_Hierarchique,'')='' 
order by t.Niveau_Hierarchique),'') ").Fields(0).Value
                If Cod_Entite_txt.Text.Trim = "" Then
                    CnExecuting("insert into Org_Entite (id_Societe, Cod_Entite, Lib_Entite, Typ_Entite, Attachement_Hierarchique, Responsable)
values (" & Societe.id_Societe & ", 'DG','Direction Générale','DIRG','','')")
                End If
            End If
            TblOrg = DATA_READER_GRD("select * from  dbo.Sys_Organigramme ('" & Societe.id_Societe & "','" & Cod_Entite_txt.Text & "')")

            With TblOrg
                .Columns("Visible").ReadOnly = False
            End With
            If Cod_Entite_txt.Text.Trim = "" Then
                ShowMessageBox("Veuillez renseigner une entité", "Organigramme", MessageBoxButtons.OK, msgIcon.Error)
                Return
            End If
            GenererOrganigrame(Cod_Entite_txt.Text)
        Catch ex As Exception
            ShowMessageBox(ex.Message)
        End Try

    End Sub
    Sub GenererOrganigrame(CodEnt As String)
        InitialisationGraphique()
        Dim Dv As DataTable = TblOrg.DefaultView.ToTable(True, "Nb_Par_Niveau", "Niveau")
        With Dv
            For i = 0 To .Rows.Count - 1
                nb = Math.Max(nb, CDbl(.Rows(i)("Nb_Par_Niveau")))
                dicX0.Add(.Rows(i)("Niveau"), DisR)
                dicNivY.Add(.Rows(i)("Niveau"), 0)
            Next
        End With
        ' calcul de la largeur width

        CreateOrgNode(CodEnt, Nothing)
        Dim w0 As Integer = 0
        Dim w1 As Integer = 0
        Dim h As Integer = 0
        Dim oX, oY As Integer
        With Mypnl
            For Each c As Org_Organigram_Element In dicGrp.Values
                w0 = Math.Min(w0, c.Location.X)
                h = Math.Max(h, c.Location.Y + c.Height)
                w1 = Math.Max(w1, c.Location.X + c.Width)
            Next
            .MinimumSize = New Size(Math.Max(Org_pnl.Width, w1 - w0 + DisL + DisR), Math.Max(Org_pnl.Height, h + disT + disB))
            For Each c As Org_Organigram_Element In dicGrp.Values
                oX = IIf(w0 < 0, Math.Abs(w0) + DisR, 0) + c.Location.X
                oY = c.Location.Y
                c.Location = New Point(oX, oY)
                .Controls.Add(c)
            Next
            For Each c As Label In Lbl
                c.Location = New Point(IIf(w0 < 0, Math.Abs(w0) + DisR, 0) + c.Location.X, c.Location.Y)
                .Controls.Add(c)
            Next
            Org_pnl.Controls.Add(Mypnl)
            .AutoScroll = True
            If .Controls.Count > 0 Then .Controls(0).Select()
        End With
    End Sub
    Sub CreateOrgNode(CodEntite As String, GrpP As Org_Organigram_Element)
        Dim nRow() As DataRow = TblOrg.Select("Cod_Entite='" & CodEntite & "'")
        Dim pRow() As DataRow = Nothing
        If nRow.Length = 0 Then Return
        Dim Grp As Org_Organigram_Element = CreateElement(CodEntite)
        Dim Xx, Yy, aa, diffdis As Integer
        With Grp
            .Name = CodEntite
            .Text = nRow(0)("Lib_Entite")
            .ContextMenuStrip = Org_CMS
            oTootlTip.SetToolTip(Grp, .Name & vbCrLf & .Text & vbCrLf & "Attachement Hiérarchique : " & nRow(0)("Parent"))
            .Tag = nRow(0)("Parent")
            .Expand(nRow(0)("Visible"))
            dicGrp.Add(.Name, Grp)
            '    Grp.Controls(0).Text = nRow(0)("Intitule")
            Yy = CInt(nRow(0)("Niveau")) * (HGrp + disSpV) + CInt(nRow(0)("Niveau_Hierarchique")) * 17
            Xx = dicX0(nRow(0)("Niveau"))
            If GrpP Is Nothing Then
                Yy = disT
                Xx = ((pnlLarg - DisR - DisL) - WGrp) / 2
                WGrp = .Width
                HGrp = .Height
            Else
                diffdis = IIf(nRow(0)("Rang_Parent") = 1, disSpH, disSpH0)
                dicX0(nRow(0)("Niveau")) += diffdis
                pRow = TblOrg.Select("Cod_Entite='" & GrpP.Name & "'")
                Xx = (GrpP.Location.X + GrpP.Width / 2) - pRow(0)("Nb_Child") * (WGrp + disSpH0) / 2 + (nRow(0)("Rang_Parent") - 1) * (WGrp + disSpH0)
                aa = Xx
                Xx = Math.Max(Xx, IIf(dicX0(nRow(0)("Niveau")) = DisR Or dicX0(nRow(0)("Niveau")) = DisR + disSpH, Xx, dicX0(nRow(0)("Niveau"))))
            End If
            dicX0(nRow(0)("Niveau")) = Xx + WGrp
            .Location = New Point(Xx, Yy)
            .BringToFront()
            'Dessiner Childs
            If CBool(nRow(0)("Visible")) Then
                Dim chRow() As DataRow = TblOrg.Select("[Parent] = '" & CodEntite & "'")
                Grp.ShowExpandBouton(chRow.Length > 0)
                If chRow.Length > 0 Then
                    dicColor.Add(CodEntite, Color.FromArgb(rndC.Next(0, 234), rndC.Next(0, 234), rndC.Next(0, 234)))
                    For i = 0 To chRow.Length - 1
                        CreateOrgNode(chRow(i)("Cod_Entite"), Grp)
                    Next
                    'Dessiner Liens
                    Dim lh, lv1 As New Label
                    Dim lhX, lhY, lhw, lvX As Integer
                    lhY = dicGrp(chRow(0)("Cod_Entite")).Location.Y - 2 * disLine
                    If dicNivY(nRow(0)("Niveau")) <= lhY And dicNivY(nRow(0)("Niveau")) > 0 Then
                        lhY = dicNivY(nRow(0)("Niveau")) - disLine
                    End If
                    dicNivY(nRow(0)("Niveau")) = lhY
                    If dicGrp(chRow(0)("Cod_Entite")).Location.X <= Grp.Location.X Then
                        lhX = dicGrp(chRow(0)("Cod_Entite")).Location.X + Grp.Width / 2
                        lhw = (nRow(0)("Nb_Child") - 1) * (WGrp + disSpH0)
                    Else
                        lhX = Grp.Location.X + Grp.Width / 2
                        lhw = dicGrp(chRow(nRow(0)("Nb_Child") - 1)("Cod_Entite")).Location.X - Grp.Location.X
                    End If
                    With lh
                        .BorderStyle = BorderStyle.None
                        .AutoSize = False
                        .Name = CodEntite
                        .Height = 2
                        .Width = lhw
                        .Location = New Point(lhX, lhY)
                        .BringToFront()
                        .BackColor = dicColor(Grp.Name)
                        oTootlTip.SetToolTip(lh, Grp.Name & vbCrLf & Grp.Text)
                    End With
                    With lv1
                        .BorderStyle = BorderStyle.None
                        .AutoSize = False
                        .Name = CodEntite
                        .Width = 2
                        .Height = lh.Location.Y - (Grp.Location.Y + Grp.Height)
                        .Location = New Point(Grp.Location.X + Grp.Width / 2, Grp.Location.Y + Grp.Height)
                        .BringToFront()
                        .BackColor = dicColor(Grp.Name)
                        oTootlTip.SetToolTip(lv1, Grp.Name & vbCrLf & Grp.Text)
                    End With
                    For i = 0 To chRow.Length - 1
                        Dim lv As New Label
                        With lv
                            .BorderStyle = BorderStyle.None
                            .AutoSize = False
                            .Name = CodEntite
                            .Width = 2
                            .Height = dicGrp(chRow(i)("Cod_Entite")).Location.Y - lh.Location.Y
                            lvX = dicGrp(chRow(i)("Cod_Entite")).Location.X + WGrp / 2
                            .Location = New Point(IIf(Math.Abs(lv1.Location.X - lvX) < 3, lv1.Location.X, lvX), lh.Location.Y)
                            .BringToFront()
                            .BackColor = dicColor(Grp.Name)
                            oTootlTip.SetToolTip(lv, Grp.Name & vbCrLf & Grp.Text)
                        End With
                        Lbl.Add(lv)
                    Next
                    Lbl.AddRange({lh, lv1})

                End If
            End If
        End With
    End Sub


End Class
