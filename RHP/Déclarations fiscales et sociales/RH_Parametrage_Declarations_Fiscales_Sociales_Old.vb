Public Class RH_Parametrage_Declarations_Fiscales_Sociales_Old
    Dim Save_D As ud_btn
    Friend Code As String = ""
    Dim ArrTypFunc, ArrTypFuncColor As New ArrayList
    Dim TblFunction As DataTable = DATA_READER_GRD("select Typ_Function,Cod_Function,Lib_Function,Lib_Abr ,Lib_Typ_Function,Groupe_Function,Typ_Retour
from dbo.RH_Elements_Paie e
outer apply(select Membre as Lib_Typ_Function from Param_Rubriques where Nom_Controle='Typ_Function' and Valeur=e.Typ_Function) f
where  Typ_Function<>'FS' and isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")= " & Societe.id_Societe & " order by Lib_Function")
    Dim TblEleDec As DataTable = DATA_READER_GRD("SELECT     Cod_Declaration, Cod_Element, Lib_Element, Typ_Data, Def_Valeur, Obligatoire, Rang
FROM   RH_Def_Declaration_Element where isnull(Flag,1)in (1,-1)
ORDER BY Cod_Declaration, Rang")
    Dim TblPlan As DataTable = DATA_READER_GRD("select Cod_Plan_Paie, Lib_Plan_Paie from RH_Param_Plan_Paie where isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")= " & Societe.id_Societe)
    Dim TblD As New DataTable
    Dim dicColor As New Dictionary(Of String, ArrayList)
    Dim dicED As New Dictionary(Of String, ud_9421_old)
    Dim dist As Integer = 5
    Dim _width As Integer = 140
    Dim _height As Integer = 160
    Dim EnMvt As Boolean = False
    Dim P0 As New Point
    Dim Indx As Integer = 0
    Friend WithEvents Lv As New ListView
    Private Sub Lv_Leave(sender As Object, e As EventArgs) Handles Lv.Leave
        RequestingPlan()
    End Sub
    Private Sub Lv_MouseLeave(sender As Object, e As EventArgs) Handles Lv.MouseLeave
        RequestingPlan()
    End Sub
    Sub RequestingPlan()
        Dim nb As Integer = 0
        Dim stm As String = ""
        For Each itm As ListViewItem In Lv.Items
            If itm.Checked Then
                stm &= IIf(stm = "", "", ";") & itm.Name
                nb += 1
            End If
        Next
        Cod_Plan_Paie_Text.Text = stm
        Lv.Visible = False
    End Sub
    Private Sub Cod_Plan_Paie__LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Cod_Plan_Paie_.LinkClicked
        If Cod_Declaration_txt.Text = "" Then
            ShowMessageBox("Vuillez sélectionner d'abord la déclaration", "Plan de Paie", MessageBoxButtons.OK, msgIcon.Stop)
            CodDeclaration_LinkClicked(Nothing, Nothing)
            Return
        End If
        Dim stm() As String = Cod_Plan_Paie_Text.Text.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
        With Lv
            For Each itm As ListViewItem In Lv.Items
                itm.Checked = stm.Contains(itm.Name)
            Next
            .Location = New Point(Cod_Plan_Paie_Text.Location.X + Plan_Grp.Location.X, Cod_Plan_Paie_Text.Height + Cod_Plan_Paie_Text.Location.Y + Plan_Grp.Location.Y + 1)
            .Visible = True
            .BringToFront()
        End With
    End Sub
    Private Sub Cod_Plan_Paie_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cod_Plan_Paie_Text.TextChanged
        If Code <> "" Then
            CnExecuting("Delete from Controle_Access where Name_Ecran='" & Me.Name & "' and id_Societe=" & Societe.id_Societe)
        End If
        RequestPlan()
        DroitAcces(Me, DroitModify_Fiche(Cod_Plan_Paie_Text.Text, Me))
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Cod_Plan_Paie_Text.Text)
            Code = Cod_Plan_Paie_Text.Text
        End If
        Enabling(Cod_Plan_Paie_Text, False)
    End Sub
    Sub RequestPlan()
        Dim strEP() As String = Nothing
        Dim strPln() As String = Cod_Plan_Paie_Text.Text.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
        Dim swhere As String = ""
        For i = 0 To strPln.Length - 1
            swhere &= IIf(swhere = "", "", " or ") & "charindex(';" & strPln(i) & ";',';'+isnull(Cod_Plan_Paie,'')+';',0)>0"
        Next
        If swhere = "" Then
            swhere = " and 1=2 "
        Else
            swhere = " and (" & swhere & ") "
        End If
        swhere = "select isnull(Element_Declaration,'') as Element_Declaration, isnull(Element_Plan,'') as Element_Plan from RH_Param_Declarations where Cod_Declaration='" & Cod_Declaration_txt.Text & "'
                                " & swhere & " and id_Societe=" & Societe.id_Societe
        TblD = DATA_READER_GRD(swhere)
        PnlPlan.Controls.Clear()
        RequestDeclaration()
        Dim TblPlan As DataTable = DATA_READER_GRD("select * from RH_Param_Plan_Paie where " & IIf(Cod_Plan_Paie_Text.Text.Contains("*"), "", "  Cod_Plan_Paie in ('" & Cod_Plan_Paie_Text.Text.Replace(";", "','") & "') and ") & " id_Societe=" & Societe.id_Societe)
        With TblPlan
            If .Rows.Count > 0 Then
                strEP = IsNull(.Rows(0)("Element_Paie"), "").Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                For i = 0 To strEP.Length - 1
                    AjouterRubrique(strEP(i), PnlPlan)
                Next
            End If
        End With

        ReorrganiserRub(PnlPlan)
    End Sub
    Private Sub RH_Parametrage_Plan_Paie_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Reset_Form(Me)
    End Sub
    Private Sub RH_Parametrage_Plan_Paie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Save_D = dictButtons("Save_D")
        If dicColor.Count = 0 Then dicColor = setGroupFunctionColor()
        With Lv
            .Size = New Size(400, 100)
            .View = View.Details
            .CheckBoxes = True
            .Columns.Add("Plan", 100)
            .Columns.Add("Intitulé", 200)
            .Visible = False
            Me.Controls.Add(Lv)
        End With
        With TblPlan
            For i = 0 To .Rows.Count - 1
                Dim itm As New ListViewItem
                itm.Checked = False
                itm.Name = .Rows(i)("Cod_Plan_Paie")
                itm.Text = itm.Name
                itm.SubItems.Add(.Rows(i)("Lib_Plan_Paie"))
                Lv.Items.Add(itm)
            Next
        End With
    End Sub
#Region "Element Declarations"
    Private Sub CodDeclaration_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS017", Cod_Declaration_txt, Me)
    End Sub
    Private Sub Cod_Declaration_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Declaration_txt.TextChanged
        Dim TblD As DataTable = DATA_READER_GRD("select Lib_Declaration,Cod_Plan_Paie,Saisie_Libre 
from RH_Def_Declaration d 
outer apply(select  Cod_Plan_Paie,Saisie_Libre from RH_Param_Declarations where Cod_Declaration=d.Cod_Declaration and id_Societe=" & Societe.id_Societe & ") f  
where Cod_Declaration='" & Cod_Declaration_txt.Text & "'")
        With TblD
            If .Rows.Count > 0 Then
                Lib_Declaration_txt.Text = IsNull(.Rows(0)("Lib_Declaration"), "")
                Saisie_Libre_chk.Checked = IsNull(.Rows(0)("Saisie_Libre"), False)
                Cod_Plan_Paie_Text.Text = IsNull(.Rows(0)("Cod_Plan_Paie"), "")
            Else
                Lib_Declaration_txt.Text = ""
                Saisie_Libre_chk.Checked = False
                Cod_Plan_Paie_Text.Text = ""
            End If
        End With
    End Sub
    Sub RequestDeclaration()
        Dim Xx, Yy As Integer
        Xx = dist
        Yy = dist
        dicED.Clear()
        Pnl_ED.Controls.Clear()
        Dim nRow() As DataRow = TblEleDec.Select("Cod_Declaration='" & Cod_Declaration_txt.Text & "'")
        With nRow
            For i = 0 To .Length - 1
                Dim dl As New ud_9421_old
                With dl
                    .Name = nRow(i)("Cod_Element")
                    .Text = nRow(i)("Lib_Element")
                    .Tag = nRow(i)("Typ_Data")
                    .Size = New System.Drawing.Size(_width, _height)
                    .TabIndex = 0
                    If Xx + _width + dist > Pnl_ED.Width - IIf(Pnl_ED.HorizontalScroll.Visible, 20, 0) Then
                        Xx = dist
                        Yy += _height + dist
                    End If
                    .Location = New Point(Xx, Yy)
                    Xx += _width + dist
                    Pnl_ED.Controls.Add(dl)
                    dicED.Add(.Name, dl)
                End With
            Next
        End With

    End Sub

#End Region
    Sub AjouterRubrique(CodRubrique As String, Pnl As Panel)
        Try
            Dim nRow() As DataRow = TblFunction.Select("Cod_Function='" & CodRubrique & "'")
            Dim StrEP() As String = {""}
            Dim StrED() As String = {""}
            If TblD.Rows.Count > 0 Then
                StrED = IsNull(TblD.Rows(0)("Element_Declaration"), "").Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                StrEP = IsNull(TblD.Rows(0)("Element_Plan"), "").Split({";"}, StringSplitOptions.RemoveEmptyEntries)
            End If
            Dim infobulle As New System.Windows.Forms.ToolTip
            If nRow.Length = 0 Then Return
            Dim gr As System.Drawing.Graphics = Graphics.FromImage(New Bitmap(1, 1))
            Dim lb As New Label
            With lb
                .AutoSize = False
                .Name = CodRubrique
                .Text = IsNull(nRow(0)("Lib_Abr"), nRow(0)("Lib_Function"))
                .TextAlign = ContentAlignment.MiddleCenter
                Dim lesize As SizeF = gr.MeasureString(.Text, .Font, New PointF(0, 0), New StringFormat(StringFormatFlags.MeasureTrailingSpaces))
                .MinimumSize = New Size(lesize.Width + 5, lesize.Height)
                .BorderStyle = BorderStyle.None
                .Cursor = Cursors.Hand
                AddHandler .DoubleClick, AddressOf dblClickEv
                '  AddHandler .Click, AddressOf ClickEv
                AddHandler .MouseDown, AddressOf lb_MouseDown
                AddHandler .MouseMove, AddressOf lb_MouseMove
                AddHandler .MouseUp, AddressOf lb_MouseUp
                infobulle.SetToolTip(lb, IsNull(nRow(0)("Cod_Function"), "") & vbCrLf & IsNull(nRow(0)("Lib_Function"), "") & vbCrLf & IsNull(nRow(0)("Lib_Typ_Function"), ""))
                AddHandler .Paint, AddressOf LblBordure
                If StrEP.Contains(.Name) Then
                    lb.Dock = DockStyle.Fill
                    dicED(StrED(Array.IndexOf(StrEP, .Name))).Child = lb
                Else
                    Pnl.Controls.Add(lb)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub ClickEv(sender As Label, e As EventArgs)

    End Sub
    Sub dblClickEv(sender As Label, e As EventArgs)
        Return
        If Not sender.Parent Is Nothing Then
            If Not sender.Parent Is PnlPlan Then
                PnlPlan.Controls.Add(sender)
                sender.Dock = DockStyle.Top
                sender.AutoSize = True
                ReorrganiserRub(PnlPlan)
            End If
        End If
    End Sub
    Sub LblBordure(sender As Label, e As PaintEventArgs)
        Dim nRow() As DataRow = TblFunction.Select("Cod_Function='" & sender.Name & "'")
        If nRow.Length = 0 Then Return
        Dim Color1 As Color = dicColor(IsNull(nRow(0)("Groupe_Function"), ""))(0)
        Dim Color2 As Color = dicColor(IsNull(nRow(0)("Groupe_Function"), ""))(1)
        sender.BackColor = Color1
        ControlPaint.DrawBorder(e.Graphics, sender.DisplayRectangle, Color2, ButtonBorderStyle.Solid)
    End Sub
    Sub Saving()
        Try
            If Cod_Declaration_txt.Text = "" Then
                ShowMessageBox("Code de déclaration vide", "Erreur", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
            If Cod_Plan_Paie_Text.Text = "" And Not Saisie_Libre_chk.Checked Then
                MessageBoxRHP(700)
                Exit Sub
            End If
            If Saisie_Libre_chk.Checked Then Cod_Plan_Paie_Text.Text = ""
            Dim strEP As String = ""
            Dim strED As String = ""
            Dim oDat As String = CnExecuting("select getdate()").Fields(0).Value
            Dim rs As New ADODB.Recordset
            If Not Saisie_Libre_chk.Checked Then
                Dim nRow() As DataRow = TblEleDec.Select("Cod_Declaration='" & Cod_Declaration_txt.Text & "'")
                For i = 0 To nRow.Length - 1
                    If Not dicED.ContainsKey(nRow(i)("Cod_Element")) Then
                        ShowMessageBox("L'élément : " & nRow(i)("Cod_Element") & " n'est pas reseigné", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                        Return
                    End If
                    If dicED(nRow(i)("Cod_Element")).Child Is Nothing Then
                        If nRow(i)("Obligatoire") = True And Not Saisie_Libre_chk.Checked Then
                            ShowMessageBox("L'élément : " & nRow(i)("Cod_Element") & " est obligatoire, veuillez lui affecter une rubrique", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                            Return
                        End If
                    Else
                        strEP &= IIf(strEP = "", "", ";") & dicED(nRow(i)("Cod_Element")).Child.Name
                        strED &= IIf(strED = "", "", ";") & nRow(i)("Cod_Element")
                    End If
                Next
                If strEP = "" Or strED = "" Then
                    ShowMessageBox("Rien à enreigstrer, aucune rubrique n'a été affecté à des éléments de la déclaration", "Erreur", MessageBoxButtons.OK, msgIcon.Stop)
                    Return
                End If
            End If
            rs.Open("select * from RH_Param_Declarations where Cod_Declaration='" & Cod_Declaration_txt.Text & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("Cod_Declaration").Value = Cod_Declaration_txt.Text
                rs("id_Societe").Value = Societe.id_Societe
                rs("Dat_Crea").Value = oDat
                rs("Created_By").Value = theUser.Login
            Else
                rs.Update()
            End If
            rs("Cod_Plan_Paie").Value = Cod_Plan_Paie_Text.Text
            rs("Element_Declaration").Value = strED
            rs("Element_Plan").Value = strEP
            rs("Saisie_Libre").Value = Saisie_Libre_chk.Checked
            rs("Dat_Modif").Value = oDat
            rs("Modified_By").Value = theUser.Login
            rs.Update()
            rs.Close()
            Cod_Declaration_txt_TextChanged(Nothing, Nothing)
            ShowMessageBox("Enregistré avec succès", "Enregistrer", MessageBoxButtons.OK, msgIcon.Information)
        Catch ex As Exception
            ShowMessageBox(ex.Message, "Erreur", MessageBoxButtons.OK, msgIcon.Error)
        End Try
    End Sub
#Region "MouseEv"
    Private Sub lb_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim lb As Label = sender ' Object = sender.parent.GetChildAtPoint(New Point(e.X + sender.location.x, e.Y + sender.location.y))
        If Not lb Is Nothing Then
            If Not lb.Parent Is Nothing Then
                If lb.Parent Is PnlPlan Then
                    EnMvt = True
                    P0 = New Point(e.X, e.Y)
                    Indx = PnlPlan.Controls.GetChildIndex(lb)
                    Me.Controls.Add(lb)
                    lb.BringToFront()
                Else
                    EnMvt = False
                End If
                Cursor.Current = Cursors.Default
            End If
        End If
    End Sub
    Sub Nouveau()
        Reset_Form(Plan_Grp)
    End Sub
    Private Sub lb_MouseMove(sender As Object, e As MouseEventArgs)
        Cursor.Current = Cursors.Hand
        Dim Strtrace As String = ""
        If Not EnMvt Then Return
        Dim lb As Label = sender '.parent.GetChildAtPoint(New Point(e.X + sender.location.x, e.Y + sender.location.y))
        '     If lb Is lblM Then Return
        lb.Location = New Point(e.X + sender.location.x - P0.X, e.Y + sender.location.y - P0.Y)
    End Sub
    Private Sub lb_MouseUp(sender As Label, e As MouseEventArgs)
        Dim Xx, Yy As Integer
        Xx = SplitContainer2.Location.X + Grp_ED.Location.X
        Yy = SplitContainer2.Location.Y + Grp_ED.Location.Y
        Dim gp As Object = Pnl_ED.GetChildAtPoint(New Point(e.X + sender.Location.X - Xx, e.Y + sender.Location.Y - Yy))
        sender.Dock = DockStyle.None
        If gp Is Nothing Then
            sender.Location = P0
            PnlPlan.Controls.Add(sender)
        ElseIf gp.GetType Is GetType(ud_9421_old) Then
            gp.child = (sender)
        Else
            sender.Location = P0
            PnlPlan.Controls.Add(sender)
        End If
        ReorrganiserRub(PnlPlan)
        EnMvt = False
    End Sub
    Private Sub Saisie_Libre_chk_CheckedChanged(sender As Object, e As EventArgs) Handles Saisie_Libre_chk.CheckedChanged
        If Cod_Plan_Paie_Text.Text <> "" And Saisie_Libre_chk.Checked Then
            If ShowMessageBox("Si vous choisissez l'option [Saisie Libre], votre déclaration ne sera pas liée à la paie.", "Saisie libre", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then
                Saisie_Libre_chk.Checked = False
            Else
                Cod_Plan_Paie_Text.Text = ""
            End If
        End If
    End Sub
    Sub ReorrganiserRub(Pnl As Panel)
        Dim LastLbl, lb As New Label
        For i = 0 To Pnl.Controls.Count - 1
            lb = Pnl.Controls(i)
            If i = 0 Then
                lb.Location = New Point(dist, dist - Pnl.VerticalScroll.Value)
            Else
                If (LastLbl.Location.X + LastLbl.Size.Width + lb.Width + dist <= Pnl.Width - dist) Then
                    lb.Location = New Point(LastLbl.Location.X + LastLbl.Size.Width + dist, LastLbl.Location.Y)
                Else
                    lb.Location = New Point(dist, LastLbl.Location.Y + LastLbl.Size.Height + dist)
                End If
            End If
            LastLbl = lb
        Next
    End Sub
#End Region

End Class