Public Class RH_Parametrage_Bulletin_Paie
    Friend Code As String = ""
    Dim ArrTypFunc, ArrTypFuncColor As New ArrayList
    Dim TblFunction As DataTable = Nothing
    Dim dicColor As New Dictionary(Of String, ArrayList)
    Dim PnlOrg As Panel = Nothing
    Dim PnlDes As Panel = Nothing
    Dim lblM As Label = Nothing
    Dim P0 As New Point
    Dim lbSep As New Label
    Dim Indx As Integer = 0
    Dim strEP() As String = Nothing
    Dim strED() As String = Nothing
    Sub Initialisation()
        If dicColor.Count = 0 Then
            Dim R0, G0, B0 As Integer
            R0 = 0
            G0 = 255
            B0 = 0
            dicColor.Add("G", New ArrayList({Color.FromArgb(50, R0, G0, B0), Color.FromArgb(R0, G0, B0)}))
            R0 = 255
            G0 = 0
            B0 = 0
            dicColor.Add("R", New ArrayList({Color.FromArgb(50, R0, G0, B0), Color.FromArgb(R0, G0, B0)}))
            dicColor.Add("A", New ArrayList({Color.FromArgb(100, colorBase04.R, colorBase04.G, colorBase04.B), colorBase04}))
            With lbSep
                .AutoSize = False
                .Width = 2
                .Height = 25
                .BackColor = Color.Red
            End With
        End If
    End Sub
    Private Sub RH_Parametrage_Plan_Paie_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Reset_Form(Me)
    End Sub
    Private Sub RH_Parametrage_Plan_Paie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Initialisation()
    End Sub
    Private Sub Cod_Plan_Paie__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Cod_Plan_Paie_.LinkClicked
        Cod_Plan_Paie_Text.Select()
        Appel_Zoom1("MS012", Cod_Plan_Paie_Text, Me)
    End Sub
    Private Sub Cod_Plan_Paie_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Plan_Paie_Text.TextChanged
        If Code <> "" Then
            CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and Value='" & Code & "' and id_Societe=" & Societe.id_Societe)
        End If
        Request()
        DroitAcces(Me, DroitModify_Fiche(Cod_Plan_Paie_Text.Text, Me))
        If dictButtons("Save_D").Enabled = True Then
            Check_Accessible(Me.Name, Cod_Plan_Paie_Text.Text)
            Code = Cod_Plan_Paie_Text.Text
        End If
        Enabling(Cod_Plan_Paie_Text, False)
    End Sub
    Sub Request()
        MajTablFunction()
        strEP = Nothing
        strED = Nothing
        PnlPlan.Controls.Clear()
        PnlDetail.Controls.Clear()
        PnlDes = Nothing
        PnlOrg = Nothing
        Dim TblPlan As DataTable = DATA_READER_GRD("select * from RH_Param_Plan_Paie where Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and id_Societe=" & Societe.id_Societe)
        With TblPlan
            If .Rows.Count > 0 Then
                Lib_Plan_Paie_Text.Text = IsNull(.Rows(0)("Lib_Plan_Paie"), "")
                strEP = IsNull(.Rows(0)("Element_Paie"), "").Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                strED = IsNull(.Rows(0)("Element_Detail"), "").Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                For i = 0 To strED.Length - 1
                    If strEP.Contains(strED(i)) Then AjouterRubrique(strED(i), PnlDetail)
                Next
                For i = 0 To strEP.Length - 1
                    If Not strED.Contains(strEP(i)) Then
                        AjouterRubrique(strEP(i), PnlPlan)
                    End If
                Next
            Else
                Lib_Plan_Paie_Text.Text = ""
            End If
        End With
        ReorrganiserRub(PnlPlan)
        ReorrganiserRub(PnlDetail)
    End Sub
    Function AjouterRubrique(CodRubrique As String, Pnl As Panel, Optional Pos As Point = Nothing, Optional indx As Integer = -1) As Label
        Dim nRow() As DataRow = TblFunction.Select("Cod_Function='" & CodRubrique & "'")
        Dim infobulle As New System.Windows.Forms.ToolTip
        If nRow.Length = 0 Then Return Nothing
        Dim gr As System.Drawing.Graphics = Graphics.FromImage(New Bitmap(1, 1))
        Dim lb As New Label
        With lb
            .AutoSize = False
            .Name = CodRubrique
            .Text = IsNull(nRow(0)("Lib_Abr"), nRow(0)("Lib_Function"))
            .TextAlign = ContentAlignment.MiddleRight
            .Tag = IsNull(nRow(0)("Gain_Retenue"), "A")
            .ContextMenuStrip = Cntx
            Dim lesize As SizeF = gr.MeasureString(.Text, .Font, New PointF(0, 0), New StringFormat(StringFormatFlags.MeasureTrailingSpaces))
            .MinimumSize = New Size(lesize.Width + 25, lesize.Height)
            .BorderStyle = BorderStyle.None
            .Cursor = Cursors.Hand
            .BackColor = dicColor(nRow(0)("Gain_Retenue"))(0)
            If Pos <> Nothing Then
                .Location = Pos
            End If
            '   AddHandler .DoubleClick, AddressOf dblClickEv
            '   AddHandler .Click, AddressOf ClickEv
            AddHandler .MouseDown, AddressOf lb_MouseDown
            AddHandler .MouseMove, AddressOf lb_MouseMove
            AddHandler .MouseUp, AddressOf lb_MouseUp
            infobulle.SetToolTip(lb, IsNull(nRow(0)("Cod_Function"), "") & vbCrLf & IsNull(nRow(0)("Lib_Function"), "") & vbCrLf & IsNull(nRow(0)("Lib_Typ_Function"), ""))
            AddHandler .Paint, AddressOf LblBordure
            Pnl.Controls.Add(lb)
            If indx <> -1 Then
                Pnl.Controls.SetChildIndex(lb, indx)
            End If
        End With
        Return lb
    End Function
    Sub LblBordure(sender As Label, e As PaintEventArgs)
        Dim nRow() As DataRow = TblFunction.Select("Cod_Function='" & sender.Name & "'")
        If nRow.Length = 0 Then Return
        Dim Color2 As Color = dicColor(nRow(0)("Gain_Retenue"))(1)
        ControlPaint.DrawBorder(e.Graphics, sender.DisplayRectangle, Color2, ButtonBorderStyle.Solid)
    End Sub
    Sub Enregistrer()
        Saving()
    End Sub
    Sub Saving()
        Cursor = Cursors.WaitCursor
        Try
            If Cod_Plan_Paie_Text.Text = "" Then
                MessageBoxRHP(700)
                Exit Sub
            End If
            If Lib_Plan_Paie_Text.Text = "" Then
                MessageBoxRHP(701)
                Exit Sub
            End If
            Dim strEE As String = ""
            Dim sqlEE As String = ""
            Dim strED As String = ""
            Dim oDat As String = CnExecuting("select getdate()").Fields(0).Value
            For i = 0 To PnlPlan.Controls.Count - 1
                If PnlPlan.Controls(i).Tag = "G" Or PnlPlan.Controls(i).Tag = "R" Then
                    ShowMessageBox("Toutes les rubrique de type 'Gain' ou 'Retenue' doivent être affectées à la section détail." & vbCrLf & PnlPlan.Controls(i).Text, "Contrôle", MessageBoxButtons.OK, msgIcon.Error)
                    Return
                End If
            Next
            For i = 0 To PnlDetail.Controls.Count - 1
                If Not strEP.Contains(PnlDetail.Controls(i).Name) Then
                    ShowMessageBox("La rubrique " & vbCrLf & PnlDetail.Controls(i).Text & vbCrLf & "dans la section détail, n'est pas comprise dans le plan de paie." & vbCrLf & PnlPlan.Controls(i).Text, "Contrôle", MessageBoxButtons.OK, msgIcon.Error)
                    Return
                End If
            Next
            For i = 0 To PnlDetail.Controls.Count - 1
                If Not (";" & strED & ";").Contains(";" & PnlDetail.Controls(i).Name & ";") Then
                    strED &= IIf(strED = "", "", ";") & PnlDetail.Controls(i).Name
                End If

            Next
            Dim rs As New ADODB.Recordset
            rs.Open("select * from RH_Param_Plan_Paie where Cod_Plan_Paie='" & Cod_Plan_Paie_Text.Text & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            If Not rs.EOF Then
                rs.Update()
                rs("Element_Detail").Value = strED
                rs("Dat_Modif").Value = oDat
                rs("Modified_By").Value = theUser.Login
                rs.Update()
                rs.Close()
            End If
            Request()
            ShowMessageBox("Enregistré avec succès", "Enregistrer", MessageBoxButtons.OK, msgIcon.Information)
        Catch ex As Exception
            ShowMessageBox(ex.Message, "Erreur", MessageBoxButtons.OK, msgIcon.Error)
        End Try
        Cursor = Cursors.Default
    End Sub
    Sub Nouveau()
        Reset_Form(Plan_Grp)
    End Sub
    Sub Actualiser()
        If ShowMessageBox("Les modifications non enregistrées seront perdues, voulez-vous continuer?", "Raffraichir", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.OK Then Request()
    End Sub

    Private Sub EditerLaRubriqueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditerLaRubriqueToolStripMenuItem.Click
        Dim lbl As Label = CType(CType(sender, ToolStripMenuItem).GetCurrentParent, ContextMenuStrip).SourceControl
        Dim f As New RH_Parametrage_Rubrique_Paie
        With f
            .Cod_Rubrique_txt.Text = lbl.Name
            .Request()
            newShowEcran(f, True)
        End With
        MajTablFunction()
        Dim pt As Point = lbl.Location
        Dim Pnl As Panel = lbl.Parent
        Dim inDx As Integer = Pnl.Controls.IndexOf(lbl)
        AjouterRubrique(lbl.Name, Pnl, pt, inDx)
        Pnl.Controls.Remove(lbl)
    End Sub
    Sub MajTablFunction()
        Initialisation()
        TblFunction = DATA_READER_GRD("select Typ_Function,Cod_Function,Lib_Function,Lib_Abr ,Lib_Typ_Function,
Groupe_Function,
Typ_Retour,isnull(nullif(Gain_Retenue,''),'A') as Gain_Retenue
from dbo.RH_Elements_Paie e
outer apply(select Membre as Lib_Typ_Function from Param_Rubriques where Nom_Controle='Typ_Function' and Valeur=e.Typ_Function) f
outer apply(select Gain_Retenue from RH_Paie_Rubrique  where id_Societe=e.id_Societe and Cod_Rubrique=e.Cod_Function) r
where  Typ_Function<>'FS' and isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")= " & Societe.id_Societe & " order by Lib_Function")
    End Sub
    Sub Affecter()
        Dim Glist, RList, Alist As New ArrayList
        For Each c As Label In PnlDetail.Controls
            If IsNull(c.Tag, "A") = "R" Then
                RList.Add(c)
            ElseIf IsNull(c.Tag, "A") = "G" Then
                Glist.Add(c)
            ElseIf IsNull(c.Tag, "A") = "A" Then
                Alist.Add(c)
            End If
        Next
        For Each c As Label In PnlPlan.Controls
            If IsNull(c.Tag, "A") = "R" Then
                RList.Add(c)
            ElseIf IsNull(c.Tag, "A") = "G" Then
                Glist.Add(c)
            ElseIf IsNull(c.Tag, "A") = "A" Then
                Alist.Add(c)
            End If
        Next
        PnlPlan.Controls.Clear()
        PnlDetail.Controls.Clear()
        For i = 0 To Glist.Count - 1
            PnlDetail.Controls.Add(Glist(i))
        Next
        For i = 0 To RList.Count - 1
            PnlDetail.Controls.Add(RList(i))
        Next
        ReorrganiserRub(PnlDetail)
        ReorrganiserRub(PnlPlan)
    End Sub

    Private Sub RéinitialiserLePanelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RéinitialiserLePanelToolStripMenuItem.Click
        Dim Pnl As Panel = CType(CType(sender, ToolStripMenuItem).GetCurrentParent, ContextMenuStrip).SourceControl
        With Pnl
            For i = Pnl.Controls.Count - 1 To 0 Step -1
                PnlPlan.Controls.Add(Pnl.Controls(i))
            Next
        End With
        ReorrganiserRub(PnlPlan)
    End Sub

    Private Sub RéorganiserLesÉlémentsDeLaSectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RéorganiserLesÉlémentsDeLaSectionToolStripMenuItem.Click
        Dim Pnl As Panel = CType(CType(sender, ToolStripMenuItem).GetCurrentParent, ContextMenuStrip).SourceControl
        ReorrganiserRub(Pnl)
    End Sub

    Sub ReorrganiserRub(Pnl As Panel)
        Dim dist As Integer = 5
        Dim LastLbl As Label = Nothing
        For Each c In Pnl.Controls
            If LastLbl Is Nothing Then
                c.Location = New Point(dist, dist - Pnl.VerticalScroll.Value)
            Else
                If (LastLbl.Location.X + LastLbl.Size.Width + c.Width + dist <= Pnl.Width - dist) Then
                    c.Location = New Point(LastLbl.Location.X + LastLbl.Size.Width + dist, LastLbl.Location.Y)
                Else
                    c.Location = New Point(dist, LastLbl.Location.Y + LastLbl.Size.Height + dist)
                End If
            End If
            LastLbl = c
        Next
    End Sub
    Private Sub lb_MouseEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        PnlDes = sender.parent
    End Sub
    Private Sub lb_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim lb As Object = sender.parent.GetChildAtPoint(New Point(e.X + sender.location.x, e.Y + sender.location.y))
        If Not lb Is Nothing Then
            lblM = lb
            If lblM.Parent IsNot PnlDetail And lblM.Parent IsNot PnlPlan Then
                PnlOrg = PnlPlan
                PnlPlan.Controls.Add(lblM)
            End If
            P0 = New Point(e.X, e.Y)
            PnlOrg = lblM.Parent
            Indx = PnlOrg.Controls.GetChildIndex(lblM)
            PnlOrg.Controls.Remove(lblM)
            Me.Controls.Add(lblM)
            lblM.BringToFront()
            lblM.Cursor = Cursors.Hand
        End If

    End Sub
    Private Sub lb_MouseMove(sender As Object, e As MouseEventArgs)
        Dim pt As Point = getPanelLocation(New Point(e.X + sender.location.x, e.Y + sender.location.y))
        If lblM Is Nothing Then Return
        lblM.Cursor = Cursors.Hand
        lblM.Location = New Point(e.X + sender.location.x - P0.X, e.Y + sender.location.y - P0.Y)
        If PnlDes Is Nothing Then Return
        Dim lb As Object = PnlDes.GetChildAtPoint(New Point(e.X + sender.location.x - pt.X, e.Y + sender.location.y - pt.Y))
        '    If lb Is lblM Then Return
        Dim Xx, Yy As Integer
        If lb IsNot Nothing Then
            Xx = lb.location.x - 2
            Yy = lb.location.y
            With lbSep
                .BringToFront()
                .Visible = True
                .Location = New Point(Xx - 1, Yy)
                If Not PnlDes.Controls.Contains(lbSep) Then PnlDes.Controls.Add(lbSep)
            End With
        Else
            If PnlDes.Controls.Contains(lbSep) Then PnlDes.Controls.Remove(lbSep)
        End If
    End Sub
    Function getPanelLocation(PDes As Point) As Point
        '  obtenir les coordonnées par rapport aux panels Ent et Detail
        Dim X0 As Integer = SplitContainer2.Location.X + GrpD.Location.X + PnlDetail.Location.X
        Dim Y0 As Integer = SplitContainer2.Location.Y + GrpD.Location.Y + PnlDetail.Location.Y
        ' Panel détail 
        If (PDes.X >= X0 And PDes.X <= X0 + PnlDetail.Width) And (PDes.Y >= Y0 And PDes.Y <= Y0 + PnlDetail.Height) Then
            PnlDes = PnlDetail
            Return New Point(X0, Y0)
        Else
            ' Panel Plan
            X0 = SplitContainer2.Location.X + SplitContainer2.SplitterDistance + GrpP.Location.X + PnlPlan.Location.X
            Y0 = SplitContainer2.Location.Y + GrpP.Location.Y + PnlPlan.Location.Y
            If (PDes.X >= X0 And PDes.X <= X0 + PnlPlan.Width) And (PDes.Y >= Y0 And PDes.Y <= Y0 + PnlPlan.Height) Then
                PnlDes = PnlPlan
                Return New Point(X0, Y0)
            Else
                PnlDes = PnlOrg
                Return Nothing
            End If
        End If

    End Function

    Private Sub lb_MouseUp(sender As Object, e As MouseEventArgs)
        Dim PDes As Point = New Point(e.X + sender.location.x, e.Y + sender.location.y)
        Dim Pt As Point = getPanelLocation(PDes)
        If Not PnlDes Is Nothing Then
            Dim nP As Point = New Point(PDes.X - Pt.X, PDes.Y - Pt.Y)
            Dim obj As Object = PnlDes.GetChildAtPoint(nP)
            Dim Idx As Integer = -1
            If Not obj Is Nothing Then
                PnlDes.Controls.Add(lblM)
                Idx = PnlDes.Controls.IndexOf(obj)
                lblM.Location = obj.location
                PnlDes.Controls.Add(lblM)
                PnlDes.Controls.SetChildIndex(lblM, Idx)
            ElseIf ((Math.Abs(e.X - P0.X) > 10 Or Math.Abs(e.Y - P0.Y) > 10) And PnlDes Is PnlOrg) Or PnlDes IsNot PnlOrg Then
                PnlDes.Controls.Add(lblM)
            ElseIf PnlDes Is PnlOrg Then
                PnlOrg.Controls.Add(lblM)
                PnlOrg.Controls.SetChildIndex(lblM, Indx)
                lblM.Location = P0
            End If
            ReorrganiserRub(PnlDes)
        Else

            PnlOrg.Controls.Add(lblM)
            PnlOrg.Controls.SetChildIndex(lblM, Indx)
            lblM.Location = P0
        End If
Fin:
        ReorrganiserRub(PnlOrg)
        lbSep.Visible = False
        If PnlDes IsNot Nothing Then If PnlDes.Controls.Contains(lbSep) Then PnlDes.Controls.Remove(lbSep)
        lblM = Nothing
        Indx = 0
        PnlOrg = Nothing
        PnlDes = Nothing
    End Sub
    Dim rw() As DataRow = Nothing
    Private Sub Search_txt_TextChanged(sender As Object, e As EventArgs) Handles Search_txt.TextChanged
        Try
            If strEP Is Nothing Then Return
            If PnlDetail.Controls.Count = 0 And PnlPlan.Controls.Count = 0 Then Return
            If rw IsNot Nothing Then
                If rw.Length > 0 Then
                    For i = 0 To rw.Length - 1
                        Dim obj As Label = TrouverRubrique(rw(i)("Cod_Function"))
                        Dim Color1 As Color = dicColor(rw(i)("Gain_Retenue"))(0)
                        If obj IsNot Nothing Then
                            With obj
                                .Font = New Font("Century Gothic", 8.25!, FontStyle.Regular)
                                .BackColor = Color1
                            End With
                        End If
                    Next
                End If
            End If
            If Search_txt.Text.Trim = "" Then Return
            Dim libFiltre As String = "Cod_Function in('" & Join(strEP, "','") & "') and (Cod_Function like '%" & Search_txt.Text.Trim.Replace("'", "''").Replace("*", "%") & "%' or Lib_Function like '%" & Search_txt.Text.Trim.Replace("'", "''").Replace("*", "%") & "%' or Lib_Abr like '%" & Search_txt.Text.Trim.Replace("'", "''").Replace("*", "%") & "%')"
            rw = TblFunction.Select(libFiltre)
            If rw.Length > 0 Then
                For i = 0 To rw.Length - 1
                    Dim obj As Label = TrouverRubrique(rw(i)("Cod_Function"))
                    If obj IsNot Nothing Then
                        With obj
                            .Font = New Font("Century Gothic", 8.25!, FontStyle.Underline)
                            .BackColor = Color.FromArgb(35, 0, 0, 255)
                        End With
                    End If
                Next
            End If
        Catch ex As Exception
            Search_txt.Text = ""
        End Try

    End Sub
    Function TrouverRubrique(Nom As String) As Label
        Dim obj() As Control = PnlDetail.Controls.Find(Nom, False)
        If obj.Length > 0 Then Return obj(0)
        obj = PnlPlan.Controls.Find(Nom, False)
        If obj.Length > 0 Then Return obj(0)
        Return Nothing
    End Function
End Class