Public Class Org_Organigram_Element
    Friend CodEntite As String
    Friend frm As New Org_Organigramme
    Private Sub Org_Element_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Name = CodEntite
        GetElementOrganigrame("E")
    End Sub
    Private Sub Expand_lbl_MouseClick(sender As Object, e As MouseEventArgs) Handles Expand_lbl.MouseClick
        frm.TblOrg.Select("Cod_Entite='" & CodEntite & "'")(0)("Visible") = Not frm.TblOrg.Select("Cod_Entite='" & CodEntite & "'")(0)("Visible")
        frm.GenererOrganigrame(frm.Cod_Entite_txt.Text)
    End Sub
    Sub Expand(Expanded As Boolean)
        If Expanded Then
            Expand_lbl.Text = "[-]"
        Else
            Expand_lbl.Text = "[+]"
        End If
        Expand_lbl.Refresh()
    End Sub
    Sub ShowExpandBouton(YesNo As Boolean)
        Expand_lbl.Visible = YesNo
    End Sub
    Sub GetElementOrganigrame(Entite_Man As String)
        Dim nrw() As DataRow = frm.Tbl_Org_Entite.Select("Cod_Entite='" & CodEntite & "'")
        Dim erw() As DataRow = Nothing
        Dim rh() As DataRow = Nothing
        Dim cat() As DataRow = Nothing
        Dim InfoStr As String = ""
        If Entite_Man = "E" Then
            If nrw.Length > 0 Then
                Entite_Org.Text = nrw(0)("Lib_Entite")
                erw = frm.Tbl_Org_Typ_Entite.Select("Typ_Entite='" & nrw(0)("Typ_Entite") & "'")
                If erw.Length > 0 Then
                    Typ_Entite_lbl.Text = "(" & erw(0)("Intitule") & ")"
                    Dim oCol() As String = IsNull(erw(0)("Couleur"), "").Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                    If oCol.Length = 3 Then
                        setColor(Color.FromArgb(CInt(oCol(0)), CInt(oCol(1)), CInt(oCol(2))))
                    Else
                        setColor(Color.FromArgb(55, 155, 255))
                    End If
                Else
                    Typ_Entite_lbl.Text = "(Entité)"
                    Me.BackColor = Color.FromArgb(55, 155, 255)
                End If
            End If
        Else
            If nrw.Length > 0 Then
                rh = frm.Tbl_RH_Agent.Select("Matricule ='" & nrw(0)("Responsable") & "'")
                erw = frm.Tbl_Org_Typ_Entite.Select("Typ_Entite='" & nrw(0)("Typ_Entite") & "'")
                If rh.Length > 0 Then
                    Entite_Org.Text = rh(0)("Civilite") & " " & rh(0)("Nom")
                    Typ_Entite_lbl.Text = rh(0)("Poste")
                    If erw.Length > 0 Then
                        Dim oCol() As String = IsNull(erw(0)("Couleur"), "").Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                        If oCol.Length = 3 Then
                            setColor(Color.FromArgb(CInt(oCol(0)), CInt(oCol(1)), CInt(oCol(2))))
                        Else
                            setColor(Color.FromArgb(55, 155, 255))
                        End If
                    End If
                ElseIf erw.Length > 0 Then
                    Typ_Entite_lbl.Text = "(" & erw(0)("Intitule") & ")"
                    Dim oCol() As String = IsNull(erw(0)("Couleur"), "").Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                    If oCol.Length = 3 Then
                        setColor(Color.FromArgb(CInt(oCol(0)), CInt(oCol(1)), CInt(oCol(2))))
                    Else
                        setColor(Color.FromArgb(55, 155, 255))
                    End If
                Else
                    Typ_Entite_lbl.Text = "(Entité)"
                    setColor(Color.FromArgb(55, 155, 255))
                End If
            End If
        End If
    End Sub
    Public Sub setColor(coleur As Color)
        Me.BackColor = coleur
        ForeColor = coleur
        Pnl.BackColor = Color.White
        content_pnl.BackColor = Color.FromArgb(40, coleur.R, coleur.G, coleur.B)
    End Sub


End Class
