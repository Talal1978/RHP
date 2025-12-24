Imports System.Text

Public Class Zoom_FsRb
    Dim TblEPUsed As DataTable = DATA_READER_GRD("select Cod_Function, Typ_Function from RH_Elements_Paie where isnull(estSysteme,'false')='false'")
    Private Sub Zoom_FsRb_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each f As rhp_functions_system In fsRows
            Dim nrw As DataRow() = TblEPUsed.Select("Cod_Function='" & f.Cod_Function & "'")
            Dim itm As New ListViewItem
            With itm
                .Name = f.Cod_Function
                .Text = f.Cod_Function
                .SubItems.Add(f.Lib_Abr)
                If nrw.Length > 0 Then
                    .SubItems.Add("Nom de fonction système réservé utilisé dans une " & IIf(nrw(0)("Typ_Function").StartsWith("F"), "fonction", "rubrique") & " de paie.")
                    .ForeColor = Color.Red
                Else
                    .SubItems.Add(f.Lib_Function)
                End If
            End With
            lv.Items.Add(itm)
        Next
        For Each r As rhp_rubriques_system In rbRows
            Dim nrw As DataRow() = TblEPUsed.Select("Cod_Function='" & r.Cod_Rubrique & "'")
            Dim itm As New ListViewItem
            With itm
                .Name = r.Cod_Rubrique
                .Text = r.Cod_Rubrique
                .SubItems.Add(r.Lib_Rubrique)
                If nrw.Length > 0 And r.estOptionnel = False Then
                    .SubItems.Add("Nom de fonction système réservé utilisé dans une " & IIf(nrw(0)("Typ_Function").StartsWith("F"), "fonction", "rubrique") & " de paie.")
                    .ForeColor = Color.Red
                Else
                    .SubItems.Add(r.Commentaire)
                End If
            End With
            lv.Items.Add(itm)
        Next
        For Each p As rhp_elements_paie In epRows
            Dim nrw As DataRow() = TblEPUsed.Select("Cod_Function='" & p.Cod_Function & "'")
            Dim itm As New ListViewItem
            With itm
                .Name = p.Cod_Function
                .Text = p.Cod_Function
                .SubItems.Add(p.Lib_Abr)
                If nrw.Length > 0 Then
                    .SubItems.Add("Nom de fonction système réservé utilisé dans une " & IIf(nrw(0)("Typ_Function").StartsWith("F"), "fonction", "rubrique") & " de paie.")
                    .ForeColor = Color.Red
                Else
                    .SubItems.Add(p.Lib_Function)
                End If
            End With
            lv.Items.Add(itm)
        Next
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles Save_ud.Click
        Cursor = Cursors.WaitCursor
        '   Try
        '        Dim TblFuctionSys As DataTable = DATA_READER_GRD("select * from RH_Param_Functions_Sys")
        '            Dim TblRubriqueSys As DataTable = DATA_READER_GRD("select * from RH_Paie_Rubrique where ISNULL(estSysteme,'false')='true'")
        '            Dim TblElementsPaieSys As DataTable = DATA_READER_GRD("select * from RH_Elements_Paie e
        'where ISNULL(estSysteme,0)=1
        'and not exists(select Cod_Function from RH_Param_Functions_Sys where Cod_Function=e.Cod_Function)
        'and Not exists (select Cod_Rubrique from RH_Paie_Rubrique where Cod_Rubrique=e.Cod_Function)
        'and Typ_Function !='RC'")

        Dim rs As New ADODB.Recordset
        For Each row As rhp_elements_paie In epRows
            Dim nrw As DataRow() = TblEPUsed.Select("Cod_Function='" & row.Cod_Function & "'")
            If nrw.Length = 0 Then
                CnExecuting("
                     delete from RH_Param_Functions_Sys where Cod_Function='" & row.Cod_Function & "'
                     delete from RH_Paie_Rubrique where Cod_Rubrique='" & row.Cod_Function & "' and isnull(Proteger,'false')='false'")
                rs.Open("select *  from RH_Elements_Paie where Cod_Function='" & row.Cod_Function & "'  and isnull(Proteger,'false')='false' ", cn, 2, 2)
                If rs.EOF Then
                    rs.AddNew()
                    rs("Cod_Function").Value = row.Cod_Function
                    rs("id_Societe").Value = -1
                    rs("estSysteme").Value = True
                Else
                    rs.Update()
                End If
                rs("Cod_Function").Value = row.Cod_Function
                rs("Typ_Function").Value = row.Typ_Function
                rs("Lib_Function").Value = row.Lib_Function
                rs("Lib_Abr").Value = row.Lib_Abr
                rs("Abr_Function").Value = row.Abr_Function
                rs("Groupe_Function").Value = row.Groupe_Function
                rs("Formule_Function").Value = row.Formule_Function
                rs("Regex").Value = row.Regex
                rs("Typ_Retour").Value = row.Typ_Retour
                rs("Nb_Decimal").Value = row.Nb_Decimal
                rs("Est_Pourcentage").Value = row.Est_Pourcentage
                rs("lastVersion").Value = row.lastVersion
                rs("Proteger").Value = False
                rs.Update()
                rs.Close()
            End If

        Next
        For Each row As rhp_functions_system In fsRows
            Dim nrw As DataRow() = TblEPUsed.Select("Cod_Function='" & row.Cod_Function & "'")
            If nrw.Length = 0 Then
                CnExecuting("
                     delete from RH_Elements_Paie where Cod_Function='" & row.Cod_Function & "'  and isnull(Proteger,'false')='false' 
                     delete from RH_Paie_Rubrique where Cod_Rubrique='" & row.Cod_Function & "'  and isnull(Proteger,'false')='false'")
                rs.Open("select *  from RH_Param_Functions_Sys where Cod_Function='" & row.Cod_Function & "'", cn, 2, 2)
                If rs.EOF Then
                    rs.AddNew()
                    rs("Cod_Function").Value = row.Cod_Function
                    rs("Dat_Crea").Value = Now
                    rs("Created_By").Value = theUser.Login
                Else
                    rs.Update()
                End If
                rs("Typ_Function").Value = row.Typ_Function
                rs("Lib_Function").Value = row.Lib_Function
                rs("Lib_Abr").Value = row.Lib_Abr
                rs("Abr_Function").Value = row.Abr_Function
                rs("Source").Value = row.Source
                rs("Groupe_Function").Value = row.Groupe_Function
                rs("Formule_Function").Value = row.Formule_Function
                rs("Regex").Value = row.Regex
                rs("Rang").Value = row.Rang
                rs("Typ_Retour").Value = row.Typ_Retour
                rs("Nb_Decimal").Value = row.Nb_Decimal
                rs("Est_Pourcentage").Value = row.Est_Pourcentage
                rs("lastVersion").Value = row.lastVersion
                rs("Dat_Modif").Value = Now
                rs("Modified_By").Value = theUser.Login
                rs.Update()
                rs.Close()
            End If
        Next
        For Each row As rhp_rubriques_system In rbRows
            Dim nrw As DataRow() = TblEPUsed.Select("Cod_Function='" & row.Cod_Rubrique & "'")
            If nrw.Length = 0 Or row.estOptionnel = False Then
                CnExecuting("
                    delete from RH_Elements_Paie where Cod_Function='" & row.Cod_Rubrique & "' and isnull(Proteger,'false')='false'
                    delete from RH_Param_Functions_Sys where Cod_Function='" & row.Cod_Rubrique & "'")
                rs.Open("select *  from RH_Paie_Rubrique where Cod_Rubrique='" & row.Cod_Rubrique & "'  and isnull(Proteger,'false')='false'", cn, 2, 2)
                If rs.EOF Then
                    rs.AddNew()
                    rs("Cod_Rubrique").Value = row.Cod_Rubrique
                    rs("id_Societe").Value = -1
                    rs("estSysteme").Value = True
                    rs("Dat_Crea").Value = Now
                    rs("Created_By").Value = theUser.Login
                Else
                    rs.Update()
                End If
                rs("Lib_Rubrique").Value = row.Lib_Rubrique
                rs("Abr_Rubrique").Value = row.Abr_Rubrique
                rs("EV").Value = row.EV
                rs("EC").Value = row.EC
                rs("EB").Value = row.EB
                rs("CS").Value = row.CS
                rs("Cumulable").Value = row.Cumulable
                rs("Ventilable").Value = row.Ventilable
                rs("Nb").Value = row.Nb
                rs("Base").Value = row.Base
                rs("Tx").Value = row.Tx
                rs("Relation").Value = row.Relation
                rs("Relation_VBS").Value = row.Relation_VBS
                rs("Typ_Retour").Value = row.Typ_Retour
                rs("Nb_Decimal").Value = row.Nb_Decimal
                rs("Est_Pourcentage").Value = row.Est_Pourcentage
                rs("Gain_Retenue").Value = row.Gain_Retenue
                rs("lastVersion").Value = row.lastVersion
                rs("Salarial").Value = row.Salarial
                rs("Patronal").Value = row.Patronal
                rs("Val_Defaut").Value = row.Val_Defaut
                rs("Typ_Rubrique_Paie").Value = row.Typ_Rubrique_Paie
                rs("Nature_Element_Exonere").Value = row.Nature_Element_Exonere
                rs("Imposable_IR").Value = row.Imposable_IR
                rs("Imposable_CNSS").Value = row.Imposable_CNSS
                rs("Deductible_IR").Value = row.Deductible_IR
                rs("Deductible_CNSS").Value = row.Deductible_CNSS
                rs("Rubrique_Globale").Value = row.Rubrique_Globale
                rs("Commentaire").Value = row.Commentaire
                rs("Dat_Modif").Value = Now
                rs("Modified_By").Value = theUser.Login
                rs("Proteger").Value = False
                rs.Update()
                rs.Close()
            End If
        Next
        lv.Items.Clear()
        fsRows.Clear()
        rbRows.Clear()
        epRows.Clear()
        '  Catch ex As Exception
        '  ShowMessageBox(ex.Message)
        '   End Try
        Cursor = Cursors.Default
        Me.Close()
    End Sub
    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        Me.Close()
    End Sub
    Private Sub CopyListViewToClipboard(listView As ListView)
        ' Create a StringBuilder to build the clipboard content
        Dim sb As New StringBuilder()

        ' Add column headers (optional)
        If listView.Columns.Count > 0 Then
            For Each column As ColumnHeader In listView.Columns
                sb.Append(column.Text)
                sb.Append(";") ' Tab separator between columns
            Next
            sb.Length -= 1 ' Remove the last tab
            sb.AppendLine() ' New line after headers
        End If

        ' Add items and subitems
        For Each item As ListViewItem In listView.Items
            ' Add the main item text
            sb.Append(item.Text)

            ' Add subitems if they exist
            For i As Integer = 1 To item.SubItems.Count - 1
                sb.Append(";")
                sb.Append(item.SubItems(i).Text)
            Next

            sb.AppendLine() ' New line after each row
        Next

        ' Copy the content to the clipboard
        If sb.Length > 0 Then
            Clipboard.SetText(sb.ToString())
        End If
    End Sub

    Private Sub Copy_ud_Click(sender As Object, e As EventArgs) Handles Copy_ud.Click
        CopyListViewToClipboard(lv)
    End Sub


End Class