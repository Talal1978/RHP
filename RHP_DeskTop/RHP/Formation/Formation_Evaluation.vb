Public Class Formation_Evaluation
    Friend CodSurvey As String = ""
    Friend CodRepose As Integer = -1
    Dim Tbl_Question As New DataTable
    Dim lb1, lb2, lb3, lb4 As New Label
    Private Sub Survey_render_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Matricule_txt.Text = theUser.Matricule
        Cod_Formation_txt.Text = CnExecuting("select isnull((select top 1 Cod_Formation from Formation where isnull(Statut_Formation,'')='Cloturee' and id_Societe=" & Societe.id_Societe & " and Cod_Formation in (select Cod_Formation from Formation_Participants where id_Societe=" & Societe.id_Societe & " and isnull(Present,'false')='true' and Matricule like '" & Matricule_txt.Text & "%')),'')").Fields(0).Value
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS018", Matricule_txt, Me, "Matricule in (select Matricule from Formation_Participants where id_Societe=" & Societe.id_Societe & " and isnull(Present,'false')='true' and Cod_Formation in (select Cod_Formation from Formation where Cod_Formation like '" & Cod_Formation_txt.Text & "%' and id_Societe=" & Societe.id_Societe & " and isnull(Statut_Formation,'')='Cloturee'))")
    End Sub

    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Nom_Agent_Text.Text = FindLibelle("Nom_Agent+' '+Prenom_Agent", "Matricule", Matricule_txt.Text, "RH_Agent")
        Request()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Appel_Zoom1("MS157", Cod_Formation_txt, Me, " isnull(Statut_Formation,'')='Cloturee' and Cod_Formation in (select Cod_Formation from Formation_Participants where id_Societe=" & Societe.id_Societe & " and isnull(Present,'false')='true' and Matricule like '" & Matricule_txt.Text & "%')", Matricule_txt.Text)
    End Sub
    Private Sub Cod_Formation_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Formation_txt.TextChanged
        Request()
    End Sub
    Sub Request()
        Save_pb.Enabled = True
        Cloture_pb.Enabled = True
        Lib_Formation_txt.Text = FindLibelle("Lib_Formation", "Cod_Formation", Cod_Formation_txt.Text, "Formation")
        CodSurvey = FindLibelle("Cod_Survey", "Cod_Formation", Cod_Formation_txt.Text, "Formation")
        Lib_Survey_lbl.Text = CodSurvey & " : " & FindLibelle("Lib_Survey", "Cod_Survey", CodSurvey, "Survey").ToString.ToUpper
        CodRepose = CnExecuting("select isnull((select Top 1 Cod_Reply from Survey_Reply where Cod_Survey='" & CodSurvey & "' and Evaluateur='" & Matricule_txt.Text & "' and Evalue='" & Cod_Formation_txt.Text & "' and id_Societe=" & Societe.id_Societe & "),-1)").Fields(0).Value
        Preambule_rtb.Rtf = FindLibelle("Preambule", "Cod_Survey", CodSurvey, "Survey")
        If CodSurvey <> "" Then
            Tbl_Question = Generate_QuestionnaireNew(CodSurvey, pnl_Content, CodRepose, Cod_Formation_txt.Text, Matricule_txt.Text, "F")
        Else
            pnl_Content.Controls.Clear()
        End If
        If CodRepose > -1 Then
            Dim estValide As Boolean = CnExecuting("select isnull((select isnull(Valide,'false') from Survey_Reply where Cod_Reply='" & CodRepose & "' and id_Societe=" & Societe.id_Societe & "),'false')").Fields(0).Value
            Save_pb.Enabled = Not estValide
            Cloture_pb.Enabled = Not estValide
        End If

    End Sub

    Sub New_pb_Click(sender As Object, e As EventArgs) Handles New_pb.Click
        Reset_Form(Me)
        Matricule_txt.Text = theUser.Matricule
        Cod_Formation_txt.Text = CnExecuting("select isnull((select top 1 Cod_Formation from Formation where isnull(Statut_Formation,'')='Cloturee' and id_Societe=" & Societe.id_Societe & " and Cod_Formation in (select Cod_Formation from Formation_Participants where id_Societe=" & Societe.id_Societe & " and isnull(Present,'false')='true' and Matricule like '" & Matricule_txt.Text & "%')),'')").Fields(0).Value
    End Sub

    Private Sub Cloture_pb_Click(sender As Object, e As EventArgs) Handles Cloture_pb.Click
        Dim resp() As Integer = Saving(CodRepose, True)
        If resp(1) = 1 Then
            CodRepose = resp(0)
            Request()
        End If
    End Sub

    Private Sub Save_pb_Click(sender As Object, e As EventArgs) Handles Save_pb.Click, New_pb.Click
        Dim resp() As Integer = Saving(CodRepose)
        If resp(1) = 1 Then
            CodRepose = resp(0)
            Request()
        End If
    End Sub
    Private Sub Print_D_Click(sender As Object, e As EventArgs) Handles Print_pb.Click

    End Sub
    Function Saving(CodReply As Integer, Optional avecValidation As Boolean = False) As Integer()
        If Cod_Formation_txt.Text = "" Then Return {CodReply, 0}
        If Matricule_txt.Text = "" Then Return {CodReply, 0}
        If CodSurvey = "" Then Return {CodReply, 0}
        If pnl_Content.Tag Is Nothing Then Return {CodReply, 0}
        Dim dictQ As New Dictionary(Of UserControl, Dictionary(Of String, String))
        dictQ = pnl_Content.Tag
        If lb1.Parent IsNot Nothing Then
            Dim obj As UserControl = lb1.Parent
            If obj.Controls.Contains(lb1) Then obj.Controls.Remove(lb1)
            If obj.Controls.Contains(lb2) Then obj.Controls.Remove(lb2)
            If obj.Controls.Contains(lb3) Then obj.Controls.Remove(lb3)
            If obj.Controls.Contains(lb4) Then obj.Controls.Remove(lb4)
        End If
        Dim Arr As New ArrayList
        Dim nrw() As DataRow = Nothing
        For Each c In dictQ
            Arr.Add(c)
        Next
        For i = Arr.Count - 1 To 0 Step -1
            nrw = Tbl_Question.Select("Cod_Question=" & Arr(i).key.Name)
            If nrw.Length > 0 Then
                Select Case nrw(0)("Typ_Reponse")
                    Case "paragraph"
                        With CType(Arr(i).key, ud_paragraph)
                            .Saving()
                            If .Obligatoire Then
                                If .repDic("0").Trim = "" Then
                                    estErreur(Arr(i).key)
                                    Return {CodReply, 0}
                                End If
                            End If
                        End With
                    Case "date", "dateTime", "heure", "liste", "alpha", "entier", "numerique"
                        With CType(Arr(i).key, ud_valeur_unique)
                            .Grd.EndEdit(True)
                            .Saving()
                            If .Obligatoire Then
                                If IsNull(.repDic("0"), "").Trim = "" Then
                                    estErreur(Arr(i).key)
                                    Return {CodReply, 0}
                                End If
                            End If
                        End With
                    Case "grille_choix", "choix"
                        With CType(Arr(i).key, ud_grille_choix)
                            .Grd.EndEdit(True)
                            .saving()
                            If .Obligatoire Then
                                Dim rspse As String = Gauche(String.Join("", Enumerable.Repeat("0;", (.Grd.ColumnCount - 1))), (.Grd.ColumnCount - 1) * 2 - 1)
                                For j = 0 To .Grd.RowCount - 1
                                    If IsNull(.repDic(CStr(j)), "").Trim = "" Then
                                        estErreur(Arr(i).key)
                                        Return {CodReply, 0}
                                    ElseIf .repDic(CStr(j)).Trim = rspse Then
                                        estErreur(Arr(i).key)
                                        Return {CodReply, 0}
                                    End If
                                Next
                            End If
                        End With
                    Case "grille_cases", "cocher", "oui_non", "vrai_faux", "echelle"
                        With CType(Arr(i).key, ud_grille_cases)
                            .Grd.EndEdit(True)
                            .Saving()
                            If .Obligatoire Then
                                Dim rspse As String = Gauche(String.Join("", Enumerable.Repeat("0;", (.Grd.ColumnCount - 1))), (.Grd.ColumnCount - 1) * 2 - 1)
                                For j = 0 To .Grd.RowCount - 1
                                    If IsNull(.repDic(CStr(j)), "").Trim = "" Then
                                        estErreur(Arr(i).key)
                                        Return {CodReply, 0}
                                    ElseIf .repDic(CStr(j)).Trim = rspse Then
                                        estErreur(Arr(i).key)
                                        Return {CodReply, 0}
                                    End If
                                Next
                            End If
                        End With
                    Case "grille_libre"
                        With CType(Arr(i).key, ud_grille_libre)
                            .Grd.EndEdit(True)
                            .Saving()
                            If .Obligatoire Then
                                For j = 0 To .Grd.RowCount - 1
                                    If IsNull(.Grd.Item(0, j).Value, "").Trim <> "" Then
                                        If IsNull(.repDic(CStr(j)), "").Trim = "" Then
                                            estErreur(Arr(i).key)
                                            Return {CodReply, 0}
                                        ElseIf .repDic(CStr(j)).Trim = .DefaultRep Then
                                            estErreur(Arr(i).key)
                                            Return {CodReply, 0}
                                        End If
                                    End If
                                Next
                            End If
                        End With
                End Select
            End If
        Next
        Dim rs As New ADODB.Recordset
        rs.Open("select * from Survey_Reply where Cod_Reply=" & CodReply, cn, 1, 3)
        If rs.EOF Then
            rs.AddNew()
            rs("id_Societe").Value = Societe.id_Societe
            rs("Cod_Survey").Value = CodSurvey
            rs("Dat_Crea").Value = Now
            rs("Created_By").Value = theUser.Login
        Else
            rs.Update()

        End If
        rs("Evaluateur").Value = Matricule_txt.Text
        rs("Typ_Evalue").Value = "F"
        rs("Evalue").Value = Cod_Formation_txt.Text
        If avecValidation Then
            rs("Valide").Value = True
            rs("Valide_Par").Value = theUser.Login
            rs("Dat_Valide").Value = Now
        End If
        rs("Dat_Modif").Value = Now
        rs("Modified_By").Value = theUser.Login
        rs.Update()
        If CodReply <= 0 Then CodReply = rs("Cod_Reply").Value
        rs.Close()
        Dim nb As Integer = 0
        Dim Reponse As String = ""
        Dim rsp() As String = Nothing

        CnExecuting("delete from Survey_Reply_Detail where Cod_Reply=" & CodReply)
        For Each c In dictQ
            nrw = Tbl_Question.Select("Cod_Question=" & c.Key.Name)
            If nrw.Length > 0 Then
                For Each v In c.Value
                    rs.Open("select * from Survey_Reply_Detail where Cod_Reply=" & CodReply, cn, 2, 2)
                    rs.AddNew()
                    rs("Cod_Reply").Value = CodReply
                    rs("Cod_Question").Value = c.Key.Name
                    rs("Question").Value = nrw(0)("Question")
                    rs("Obligatoire").Value = nrw(0)("Obligatoire")
                    rs("Typ_Reponse").Value = nrw(0)("Typ_Reponse")
                    rs("Num_Sous_Question").Value = v.Key
                    rs("Reponses").Value = v.Value
                    If nrw(0)("Sous_Question").ToString.Split({";"}, StringSplitOptions.RemoveEmptyEntries).Length > 0 And IsNumeric(v.Key) Then
                        Dim sq As String = nrw(0)("Sous_Question").ToString
                        rs("Sous_Question").Value = sq.Split({";"}, StringSplitOptions.RemoveEmptyEntries)(v.Key)
                        Reponse = ""
                        Select Case nrw(0)("Typ_Reponse")
                            Case "grille_cases", "cocher", "oui_non", "vrai_faux", "echelle", "grille_choix", "choix"
                                rsp = v.Key.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                                For n = 0 To rsp.Length - 1
                                    If rsp(n).Trim = "1" Then
                                        Reponse &= IIf(Reponse = "", "", ";") & nrw(0)("Reponses_Possibles").ToString.Split({";"}, StringSplitOptions.RemoveEmptyEntries)(n)
                                    End If
                                Next
                            Case Else
                                Reponse = v.Value
                        End Select
                        rs("Valeur_Reponse").Value = Reponse
                    End If
                    rs("Rang").Value = nb
                    nb += 1
                    rs.Update()
                    rs.Close()
                Next
            End If
        Next
        Return {CodReply, 1}
    End Function
    Sub estErreur(ud As UserControl)
        Dim oX As Integer = 3
        Dim oY As Integer = 3
        Dim oH As Integer = ud.Height - 2 * oY
        Dim oW As Integer = ud.Width - 2 * oX
        Dim epaiss As Integer = 3
        pnl_Content.Select()
        ud.Select()
        ud.Controls(0).Select()
        ud.Controls.AddRange({lb1, lb2, lb3, lb4})
        ud.Refresh()
        With lb1
            .AutoSize = False
            .BorderStyle = BorderStyle.None
            .BackColor = Color.Red
            .Size = New Size(oW, epaiss)
            .Location = New Point(oX, oY)
            .BringToFront()
        End With
        With lb2
            .AutoSize = False
            .BorderStyle = BorderStyle.None
            .BackColor = Color.Red
            .Size = New Size(epaiss, oH)
            .Location = New Point(oW, oY)
            .BringToFront()
        End With
        With lb3
            .AutoSize = False
            .BorderStyle = BorderStyle.None
            .BackColor = Color.Red
            .Size = New Size(oW, epaiss)
            .Location = New Point(oX, oH)
            .BringToFront()
        End With
        With lb4
            .AutoSize = False
            .BorderStyle = BorderStyle.None
            .BackColor = Color.Red
            .Size = New Size(epaiss, oH)
            .Location = New Point(oX, oY)
            .BringToFront()
        End With

    End Sub

    Private Sub Survey_Reply_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub
End Class