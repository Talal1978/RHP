Imports System.Text.RegularExpressions
Public Class RH_Parametrage_Declarations_Fiscales_Sociales
    Dim Save_D As ud_btn
    Friend Code As String = ""
    Dim ArrTypFunc, ArrTypFuncColor As New ArrayList
    Friend TblFunction As DataTable = DATA_READER_GRD("select Typ_Function,Cod_Function,Lib_Function,Lib_Abr ,Lib_Typ_Function,Groupe_Function,Typ_Retour
from dbo.RH_Elements_Paie e
outer apply(select Membre as Lib_Typ_Function from Param_Rubriques where Nom_Controle='Typ_Function' and Valeur=e.Typ_Function) f
where  Typ_Function<>'FS' and isnull(nullif(id_Societe,-1)," & Societe.id_Societe & ")= " & Societe.id_Societe & " order by Lib_Function")
    Dim TblEleDec As New DataTable
    Dim TblD As New DataTable
    Dim dicColor As New Dictionary(Of String, ArrayList)
    Dim dicED As New Dictionary(Of String, ud_9421)
    Dim dist As Integer = 5
    Dim _width As Integer = 140
    Dim _height As Integer = 160
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Reset_Form(Me)
    End Sub
    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Save_D = dictButtons("Save_D")
        If dicColor.Count = 0 Then dicColor = setGroupFunctionColor()
    End Sub
#Region "Element Declarations"
    Private Sub CodDeclaration_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Appel_Zoom1("MS017", Cod_Declaration_txt, Me)
    End Sub
    Private Sub Cod_Declaration_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Declaration_txt.TextChanged
        Dim TblD As DataTable = DATA_READER_GRD("select Lib_Declaration,Saisie_Libre ,Filtre
from RH_Def_Declaration d 
outer apply(select   Saisie_Libre,Filtre from RH_Param_Declarations where Cod_Declaration=d.Cod_Declaration and id_Societe=" & Societe.id_Societe & ") f  
where Cod_Declaration='" & Cod_Declaration_txt.Text & "'")
        With TblD
            If .Rows.Count > 0 Then
                Lib_Declaration_txt.Text = IsNull(.Rows(0)("Lib_Declaration"), "")
                Filtre_txt.Text = IsNull(.Rows(0)("Filtre"), "")
                Saisie_Libre_chk.Checked = IsNull(.Rows(0)("Saisie_Libre"), False)
            Else
                Lib_Declaration_txt.Text = ""
                Filtre_txt.Text = ""
                Saisie_Libre_chk.Checked = False
            End If
        End With
        RequestDeclaration()
    End Sub
    Sub RequestDeclaration()
        TblEleDec = DATA_READER_GRD($"SELECT     Cod_Declaration, Cod_Element, Lib_Element,isnull(Valeur,'') Valeur, Typ_Data, Def_Valeur, Obligatoire,isnull(Aggregation,'') Aggregation, Rang
FROM   RH_Def_Declaration_Element e
outer apply (select Top 1 Valeur, isnull(Aggregation,'sum') as Aggregation from RH_Param_Declarations_Detail t where id_Societe={Societe.id_Societe} and Cod_Declaration=e.Cod_Declaration and t.Cod_Element=e.Cod_Element)d
where isnull(Flag,1)in (1,-1) and Cod_Declaration='" & Cod_Declaration_txt.Text & "'
ORDER BY Cod_Declaration, Rang")
        Dim Xx, Yy As Integer
        Xx = dist
        Yy = dist
        dicED.Clear()
        Pnl_ED.Controls.Clear()
        With TblEleDec
            For i = 0 To .Rows.Count - 1
                Dim dl As New ud_9421
                With dl
                    .Name = TblEleDec.Rows(i)("Cod_Element")
                    .Text = TblEleDec.Rows(i)("Lib_Element")
                    .Tag = TblEleDec.Rows(i)("Typ_Data")
                    .Valeur = TblEleDec.Rows(i)("Valeur")

                    .Size = New System.Drawing.Size(_width, _height)
                    .TabIndex = 0
                    If Xx + _width + dist > Pnl_ED.Width - 300 - IIf(Pnl_ED.HorizontalScroll.Visible, 20, 0) Then
                        Xx = dist
                        Yy += _height + dist
                    End If
                    .Location = New Point(Xx, Yy)
                    Xx += _width + dist
                    Pnl_ED.Controls.Add(dl)
                    dicED.Add(.Name, dl)
                    .Aggregation = TblEleDec.Rows(i)("Aggregation")
                    .MiseEnforme()
                End With
            Next
        End With

    End Sub
#End Region
    Sub Saving()
        Try
            If Cod_Declaration_txt.Text = "" Then
                ShowMessageBox("Code de déclaration vide", "Erreur", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
            Dim rg As New Regex(sql_injection, RegexOptions.IgnoreCase)
            If rg.IsMatch(Filtre_txt.Text.Trim) Then
                ShowMessageBox("Votre expression de filtre contient des expressions intérdites", "Injection", MessageBoxButtons.OK, msgIcon.Error)
                Return
            End If
            If Filtre_txt.Text.Trim <> "" Then
                Try
                    cn.Execute("select top 1 Matricule from RH_Agent," & IIf(Cod_Declaration_txt.Text = "Damancom_Ent", "Damancom_Ent,DamanCom_Lig", Cod_Declaration_txt.Text) & "  where " & Filtre_txt.Text)
                Catch ex As Exception
                    ShowMessageBox("votre expression de filtre contient des erreurs" & vbCrLf & ex.Message, "filtre", MessageBoxButtons.OK, msgIcon.Error)
                    Return
                End Try
            End If
            Dim oDat As String = CnExecuting("select getdate()").Fields(0).Value
            Dim rs As New ADODB.Recordset
            Dim ElementsDeclaration As String = ""
            rg = New Regex("\b(\w+)\b", RegexOptions.IgnoreCase)
            If Not Saisie_Libre_chk.Checked Then
                Dim nRow() As DataRow = TblEleDec.Select("Cod_Declaration='" & Cod_Declaration_txt.Text & "'")
                For i = 0 To nRow.Length - 1
                    If Not dicED.ContainsKey(nRow(i)("Cod_Element")) Then
                        ShowMessageBox("L'élément : " & nRow(i)("Cod_Element") & " n'est pas reseigné", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                        Return
                    End If
                    If Not dicED(nRow(i)("Cod_Element")).VerifierFormule() Then
                        If nRow(i)("Obligatoire") = True And Not Saisie_Libre_chk.Checked Then
                            ShowMessageBox("L'élément : " & nRow(i)("Cod_Element") & " est obligatoire.", "Vérification", MessageBoxButtons.OK, msgIcon.Stop)
                            Return
                        End If
                    End If
                    For Each c As Match In rg.Matches(dicED(nRow(i)("Cod_Element")).Valeur)
                        If TblFunction.Select("[Cod_Function] = '" & c.Value & "'").Length > 0 Then
                            If Not ElementsDeclaration.Split(";").Contains(c.Value) Then
                                ElementsDeclaration &= IIf(ElementsDeclaration = "", "", ";") & c.Value.Trim
                            End If
                        End If
                    Next
                Next
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
            rs("Saisie_Libre").Value = Saisie_Libre_chk.Checked
            rs("Element_Declaration").Value = ElementsDeclaration
            rs("Filtre").Value = Filtre_txt.Text
            rs("Dat_Modif").Value = oDat
            rs("Modified_By").Value = theUser.Login
            rs.Update()
            rs.Close()
            For Each a In dicED.Values
                rs.Open("select * from RH_Param_Declarations_Detail where Cod_Declaration='" & Cod_Declaration_txt.Text & "' and Cod_Element='" & a.Name & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
                If rs.EOF Then
                    rs.AddNew()
                    rs("Cod_Declaration").Value = Cod_Declaration_txt.Text
                    rs("id_Societe").Value = Societe.id_Societe
                    rs("Dat_Crea").Value = oDat
                    rs("Created_By").Value = theUser.Login
                Else
                    rs.Update()
                End If
                rs("Cod_Element").Value = a.Name
                rs("Aggregation").Value = a.Aggregation
                rs("Rang").Value = Pnl_ED.Controls.IndexOf(a)
                rs("Valeur").Value = a.Valeur
                rs("Dat_Modif").Value = oDat
                rs("Modified_By").Value = theUser.Login
                rs.Update()
                rs.Close()
            Next

            Cod_Declaration_txt_TextChanged(Nothing, Nothing)
            ShowMessageBox("Enregistré avec succès", "Enregistrer", MessageBoxButtons.OK, msgIcon.Information)
        Catch ex As Exception
            ShowMessageBox(ex.Message, "Erreur", MessageBoxButtons.OK, msgIcon.Error)
        End Try
    End Sub

    Private Sub SélectionnerUnChampsDeFiltreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SélectionnerUnChampsDeFiltreToolStripMenuItem.Click
        Dim sqlStr As String = ""
        Appel_Zoom("Column_Name", "Table_Name", "INFORMATION_SCHEMA.COLUMNS", "TABLE_NAME in ('" & IIf(Cod_Declaration_txt.Text = "Damancom_Ent", "DamanCom_Ent','DamanCom_Lig", Cod_Declaration_txt.Text) & "','RH_Agent')", zoom_txt, Me)
        With Filtre_txt
            .Select()
            Dim SelPos As Integer = .SelectionStart
            .Text = .Text.Insert(SelPos, " " & zoom_txt.Text & " ")
            .Select()
            .SelectionStart = SelPos + (" " & zoom_txt.Text & " ").Length
        End With
        zoom_txt.ResetText()
    End Sub

    Sub Nouveau()
        Reset_Form(entete_Grp)
    End Sub
End Class