Public Class Ecran
    Inherits Form
    Friend dictButtons As New Dictionary(Of String, ud_btn)
    Friend Path As String = ""
    Dim show_btn_PJ As Boolean = False
    Dim show_btn_Info As Boolean = False
    Friend estModal As Boolean = False
    Dim _nom As String = ""
    Public Sub New()

    End Sub
    Public Sub TriggerFormClosing(e As FormClosingEventArgs)
        ' Appelle la méthode protégée OnFormClosing
        MyBase.OnFormClosing(e)
    End Sub
    Public Shadows Property [Name] As String
        Get
            Return _nom
        End Get
        Set(value As String)
            If _nom <> value Then
                _nom = value
                Dim REcran() As DataRow = Tbl_Controle_Def_Ecran.Select("Name_Ecran='" & Me.Name & "'")
                If REcran.Length > 0 Then
                    show_btn_PJ = IsNull(REcran(0)("PJ"), False)
                    show_btn_Info = IsNull(REcran(0)("Info"), False)
                    estModal = IsNull(REcran(0)("Modal"), False)
                End If
                dictButtons.Clear()
                Dim nrw As DataRow() = Tbl_Controle_Def_Ecran_Button.Select("Name_Ecran='" & Me.Name & "'", "Rang asc")
                If nrw.Length > 0 Then
                    For i = 0 To nrw.Length - 1
                        Dim btn As New ud_btn(Me, nrw(i)("Cod_Button"), nrw(i)("ProcName"), nrw(i)("Img"))
                        With btn
                            .Size = New Size(CInt(nrw(i)("Width")), CInt(nrw(i)("Height")))
                            .ToolTip = nrw(i)("Lib_Button")
                            dictButtons.Add(.Name, btn)
                        End With
                    Next
                End If
                ' Gestion des signatures en Workflow 
                Dim btn_Sign = GenererSignaturesWorkflow()
                If btn_Sign IsNot Nothing Then
                    With btn_Sign
                        dictButtons.Add(.Name, btn_Sign)
                    End With
                End If
                'Accessibilité
                If dictButtons.Count > 0 Then
                    Dim btn_Acceess = GererAccessibilite()
                    If btn_Acceess IsNot Nothing Then
                        With btn_Acceess
                            dictButtons.Add(.Name, btn_Acceess)
                        End With
                    End If
                End If
                'Pièces jointes
                If show_btn_PJ And theUser.Typ_Role <> "Agent" Then
                    Dim Index As String = FindLibelle("Index_Ecran", "Name_Ecran", Me.Name, "Controle_Def_Ecran")
                    If Index?.Trim <> "" Then
                        Dim btn_pj = GenererPJ()
                        If btn_pj IsNot Nothing Then
                            With btn_pj
                                dictButtons.Add(.Name, btn_pj)
                            End With
                        End If
                    End If
                End If

                ' information Propriétés
                If show_btn_Info And theUser.Typ_Role <> "Agent" Then
                    Dim btn_info = GenererInformation()
                    If btn_info IsNot Nothing Then
                        With btn_info
                            dictButtons.Add(.Name, btn_info)
                        End With
                    End If
                End If

                'Générer les traiement specifiques
                If theUser.Typ_Role <> "Agent" Then
                    If CnExecuting("select count(*) from  Controle_Def_Tunel where Name_Ecran='" & Me.Name & "'").Fields(0).Value > 0 Then
                        Dim btn_ts = GenererTraitementSpe()
                        If btn_ts IsNot Nothing Then
                            With btn_ts
                                dictButtons.Add(.Name, btn_ts)
                            End With
                        End If
                    End If
                End If
                '   If theUser.Typ_Role <> "Agent" Then
                'Génération des Reports
                If CnExecuting("select count(*) from Controle_Def_Ecran_Mod_Edition where Name_Ecran='" & Me.Name & "'").Fields(0).Value > 0 Then
                    Dim btn_rpt = GenererModEditions()
                    If btn_rpt IsNot Nothing Then
                        With btn_rpt
                            dictButtons.Add(.Name, btn_rpt)
                        End With
                    End If
                End If
                '  End If
            End If

        End Set
    End Property
    Sub setButtons()
        If estModal And Me.Parent IsNot Nothing Then
            With CType(Me.Parent.FindForm, Ecran_Container).pnl_sideBarL
                .Controls.Clear()
                Dim Xx As Integer = 0
                Dim Yy As Integer = 20
                For Each _btn In dictButtons.Values
                    With _btn
                        Xx = (CType(Me.Parent.FindForm, Ecran_Container).pnl_sideBarL.Width - .Width - 2) / 2
                        .Location = New Point(Xx, Yy)
                        Yy += .Height + 14
                        .BringToFront()
                    End With
                    .Controls.Add(_btn)
                Next
            End With
        ElseIf theUser.Typ_Role = "Agent" Then
            With Menu_Agent.pnl_sideBarL
                .Controls.Clear()
                .Visible = True
                If dictButtons.Values.Count > 0 Then
                    Dim Xx As Integer = 20
                    Dim Yy As Integer = 0
                    For Each _btn In dictButtons.Values
                        With _btn
                            Yy = (Menu_Agent.pnl_sideBarL.Height - .Height - 2) / 2
                            .Location = New Point(Xx, Yy)
                            Xx += .Width + 14
                            .BringToFront()
                        End With
                        .Controls.Add(_btn)
                    Next
                End If
                Dim btn As New ud_btn(Me, "Close_D", "", "btn_close")
                With btn
                    .Size = New Size(25, 25)
                    .ToolTip = "Fermer"
                    .Location = New Point(Menu_Agent.menuPnl.Width - 200, (Menu_Agent.pnl_sideBarL.Height - .Height) / 2)
                    AddHandler .Click, Sub()
                                           Me.Close()
                                           Menu_Agent.pnl_sideBarL.Visible = False
                                           Menu_Agent.pnl_sideBarL.Controls.Clear()
                                           Menu_Agent.chemin_lbl.ResetText()
                                       End Sub
                End With
                .Controls.Add(btn)
            End With
        Else
            With leMenu.pnl_sideBarL
                .Controls.Clear()
                .Visible = True
                If dictButtons.Values.Count > 0 Then
                    Dim Xx As Integer = 0
                    Dim Yy As Integer = 20
                    For Each _btn In dictButtons.Values
                        With _btn
                            Xx = (leMenu.pnl_sideBarL.Width - .Width - 2) / 2
                            .Location = New Point(Xx, Yy)
                            Yy += .Height + 14
                            .BringToFront()
                        End With
                        .Controls.Add(_btn)
                    Next
                Else
                    .Visible = False
                End If
            End With
        End If


    End Sub
    Private Sub Ecran_Layout(sender As Object, e As LayoutEventArgs) Handles MyBase.Layout
        If Not e.AffectedControl Is Me Then Return
        Dim obj = Me.Controls.Find("TabControl1", True)
        If obj.Length > 0 Then
            If TypeOf obj(0) Is TabControl Then
                Dim TabCtrl As TabControl = DirectCast(obj(0), TabControl)
                With TabCtrl
                    .DrawMode = TabDrawMode.OwnerDrawFixed
                    AddHandler .DrawItem, AddressOf TabControl_DrawItem
                End With
                For Each tb As TabPage In TabCtrl.TabPages
                    AddHandler tb.Paint, AddressOf TabPage_Paint
                Next
            End If
        End If

    End Sub
    Private Sub Ecran_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If leMenu.currentEcran Is Me Then
            leMenu.currentEcran = Nothing
        End If
    End Sub
    Private Sub TabControl_DrawItem(ByVal sender As TabControl, ByVal e As System.Windows.Forms.DrawItemEventArgs)
        Try
            Dim tabPage As TabPage = sender.TabPages(e.Index)
            Dim tabText As String = tabPage.Text
            Dim stringFlags As TextFormatFlags = TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter

            If e.Index = sender.SelectedIndex Then
                Using brush As New SolidBrush(colorBase01)
                    e.Graphics.FillRectangle(brush, e.Bounds)
                End Using
                TextRenderer.DrawText(e.Graphics, tabText, e.Font, e.Bounds, Color.White, stringFlags)
            Else
                Using brush As New SolidBrush(colorBase04)
                    e.Graphics.FillRectangle(brush, New Rectangle(e.Bounds.X - 2, e.Bounds.Y, e.Bounds.Width + 4, e.Bounds.Height + 4))
                End Using
                TextRenderer.DrawText(e.Graphics, tabText, e.Font, e.Bounds, tabPage.ForeColor, stringFlags)
            End If
        Catch ex As Exception
            ShowMessageBox("Error in custom drawing: " & ex.Message)
        End Try

    End Sub
    Private Sub TabPage_Paint(sender As TabPage, e As PaintEventArgs)
        e.Graphics.DrawRectangle(New Pen(colorBase01, 2), 1, 1, sender.Width - 2, 2)
    End Sub
    Private Function GenererSignaturesWorkflow() As mybtn_Signature
        '    If Not CBool(LicenceJson.WorkFlow) Then Return
        Dim Dv As DataView = Tbl_Workflow_ParamDocuments.DefaultView
        Dv.RowFilter = "Name_Ecran='" & Me.Name & "' and isnull(Gere_Signature,'false')='true'"
        If Dv.Count = 0 Then Return Nothing
        Dim Dt As DataTable = Dv.ToTable
        Dv.RowFilter = "Condition_Ecran<>''"
        Dt.Columns("Condition_Ecran").ReadOnly = False
        If Dv.Count > 0 Then
            For i = 0 To Dt.Rows.Count - 1
                If VerifierCondition(Me, Dt.Rows(i)("Condition_Ecran")) Then
                    Dt.Rows(i)("Condition_Ecran") = "OK"
                Else
                    Dt.Rows(i)("Condition_Ecran") = "NO"
                End If
            Next
        End If
        Dv = Dt.DefaultView
        Dv.RowFilter = "Condition_Ecran='OK' or Condition_Ecran='' or Condition_Ecran is null"
        Dt = Dv.ToTable
        If Dt.Rows.Count = 0 Then Return Nothing
        Dim objs = Me.Controls.Find(Dt.Rows(0)("Index_Ecran"), True)
        If objs.Count = 0 Then Return Nothing
        Dim fName As String = Me.Name
        Dim btn_Signature As New mybtn_Signature(Me, "Signer_D", "", "btn_sign")
        With btn_Signature
            .Image = My.Resources.Resources.Signer_D
            .Name = "Signer_D"
            .tbl = Dt
            .frm = Me
            .valeurIndex = objs(0).Text.Trim()
            .Statut = ""
            .Visible = (estGereEnSignature(Dt.Rows(0)("Typ_Document")) And (.valeurIndex <> ""))
            .ToolTip = "Signatures"
            .Size = New Size(.Width * 1.2, .Height * 1.2)
            AddHandler .Click, AddressOf SubSignatures
        End With
        If dictButtons.ContainsKey("Valide_D") Then
            dictButtons("Valide_D").Visible = Not estGereEnSignature(Dt.Rows(0)("Typ_Document"))
        End If
        If objs(0).GetType Is GetType(ud_TextBox) Then
            AddHandler CType(objs(0), ud_TextBox).TextChanged, Sub(sender, e)
                                                                   GestionDesSignatures(Me, CType(objs(0), ud_TextBox).Text)
                                                               End Sub
        ElseIf objs(0).GetType Is GetType(TextBox) Then
            AddHandler CType(objs(0), TextBox).TextChanged, Sub(sender, e)
                                                                GestionDesSignatures(Me, CType(objs(0), TextBox).Text)
                                                            End Sub
        End If

        Return btn_Signature
    End Function
#Region "Accessibilite"
    Function GererAccessibilite() As ud_btn
        If dictButtons.ContainsKey("Accessible_D") Then Return dictButtons("Accessible_D")
        Dim obtn As New ud_btn(Me, "Accessible_D", "AccessibilieHandle", "btn_eye")
        With obtn
            .Tag = ""
            .Text = ""
            .Visible = False
            .ToolTip = "Accessibilité"
            AddHandler .Click, AddressOf AccessibilieHandle
        End With
        Return obtn
    End Function
    Private Sub AccessibilieHandle(btn, e)
        ShowMessageBox(btn.text, "Accessibilité", MessageBoxButtons.OK, msgIcon.Stop)
    End Sub
#End Region
#Region "Propriétés de l'écran"
    Private Function GenererInformation() As ud_btn
        Dim Tbl As DataTable = DATA_READER_GRD("select Lib_champs,convert(nvarchar(500),'') as info,DATA_TYPE,Champs
                                       from Controle_Def_Ecran_Proprietes p outer apply (select DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME=Table_Ref and COLUMN_NAME=Champs) s
                                       where Name_Ecran='" & Me.Name & "'")
        If Tbl.Rows.Count = 0 Then Return Nothing
        Dim btn As New ud_btn(Me, "ProprietesInfo", "", "btn_information")
        With btn
            .Visible = True
            AddHandler .Click, AddressOf GetProprietesInfo
        End With
        Return btn
    End Function
    Private Sub GetProprietesInfo()
        Try
            Dim Array1 As New ArrayList
            Dim frmN As String = Me.Name
            Dim Index As String = FindLibelle("Index_Ecran", "Name_Ecran", frmN, "Controle_Def_Ecran")
            Dim oTbl As String = FindLibelle("Table_Ref", "Name_Ecran", frmN, "Controle_Def_Ecran")
            Dim oTblIdx As String = FindLibelle("Index_Table", "Name_Ecran", frmN, "Controle_Def_Ecran")
            Dim obj As Object = Nothing
            Dim indexList As String() = Index.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
            Dim Index_Value As String = ""
            For i = 0 To indexList.Length - 1
                obj = GetControlByName(indexList(i), Me)
                If Not obj Is Nothing Then
                    Select Case obj.GetType.Name
                        Case "TextBox"
                            Index_Value &= IIf(Index_Value <> "", ";", "") & CType(obj, TextBox).Text
                        Case "LinkLabel"
                            Index_Value &= IIf(Index_Value <> "", ";", "") & CType(obj, LinkLabel).Text
                        Case "ComboBox"
                            Index_Value &= IIf(Index_Value <> "", ";", "") & CType(obj, ComboBox).SelectedValue
                        Case "NumericUpDown"
                            Index_Value &= IIf(Index_Value <> "", ";", "") & CType(obj, NumericUpDown).Value
                    End Select

                End If
            Next
            If Not Index_Value = "" Then
                Dim Tbl As DataTable = DATA_READER_GRD("select Lib_champs,convert(nvarchar(500),'') as info,DATA_TYPE,Champs
                                       from Controle_Def_Ecran_Proprietes p outer apply (select DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME=Table_Ref and COLUMN_NAME=Champs) s
                                       where Name_Ecran='" & frmN & "'")
                With Tbl
                    .Columns("Info").ReadOnly = False
                End With

                Dim Z As New Zoom_Libre
                With Z
                    .Text = "Propriétés de l'objet"
                    With .Libre_GRD
                        .DataSource = Tbl
                        .Columns("DATA_TYPE").Visible = False
                        .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                        .ColumnHeadersVisible = False
                        .Columns("Lib_champs").MinimumWidth = 350
                        .Columns("info").MinimumWidth = 300
                        .AllowUserToAddRows = False
                        .AllowUserToDeleteRows = False
                        .RowHeadersVisible = False
                        .Columns("Champs").Visible = False
                        For i = 0 To .RowCount - 1
                            .Item("Info", i).Value = FindLibelle(.Item("Champs", i).Value, oTblIdx, Index_Value, oTbl)
                            Select Case .Item("DATA_TYPE", i).Value
                                Case "int", "float", "real", "bigint"
                                    .Item("Info", i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                                Case "datetime", "smalldatetime", "bit"
                                    .Item("Info", i).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                                Case Else
                                    .Item("Info", i).Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                            End Select
                        Next
                    End With
                    .ShowDialog()
                End With
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
#End Region
End Class

