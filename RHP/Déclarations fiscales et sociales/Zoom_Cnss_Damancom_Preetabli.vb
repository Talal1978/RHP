Imports System.IO

Public Class Zoom_Cnss_Damancom_Preetabli
    Friend frm As New Cnss_DamanCom
    Dim CheminPretabliStr As String
    Sub importFichierPreetabli()
        Dim OpenFileDialog As New OpenFileDialog
        Dim FichierExp As String = ""
        OpenFileDialog.InitialDirectory = importPath
        OpenFileDialog.Filter = "Fichiers Excel (*.txt)|*.txt"

        If (OpenFileDialog.ShowDialog(Me) = DialogResult.OK) Then
            Dim fi As New FileInfo(OpenFileDialog.FileName)
            Dim FileName As String = OpenFileDialog.FileName
            CheminPretabliStr = fi.FullName
        End If
        If CheminPretabliStr = "" Then
            Return
        End If
        Importation()
    End Sub

    Sub Importation()

        If Not IO.File.Exists(CheminPretabliStr) Then
            ShowMessageBox("Fichier à importer inexistant.", "Importation", MessageBoxButtons.OK, msgIcon.Warning)
            Return
        End If
        If Not CheminPretabliStr.ToUpper.EndsWith(".TXT") Then
            ShowMessageBox("Fichier à importer n'est pas de type texte.", "Importation", MessageBoxButtons.OK, msgIcon.Warning)
            Return
        End If
        Dim TblBrut As New DataTable
        With TblBrut
            .Columns.Add("Type_Enreg")
            .Columns.Add("Donnee")
        End With
        Dim rd As New IO.StreamReader(CheminPretabliStr.Trim)
        Dim str As String = ""
        Do Until rd.Peek = -1
            str = rd.ReadLine()
            If IsNull(str, "").Trim <> "" Then
                If str.Length > 257 Then
                    TblBrut.Rows.Add(str.Substring(0, 3), str.Substring(3, 257))
                End If
            End If
        Loop
        rd.Close()
        'A00
        Dim rw0() As DataRow = TblBrut.Select("Type_Enreg='A00'")
        Dim rw1() As DataRow = TblBrut.Select("Type_Enreg='A01'")
        Dim rw2() As DataRow = TblBrut.Select("Type_Enreg='A02'")
        Dim rw3() As DataRow = TblBrut.Select("Type_Enreg='A03'")
        If rw0.Length = 0 Or rw1.Length = 0 Or rw2.Length = 0 Or rw3.Length = 0 Then
            ' Dim f As New Zoom_Libre
            '     With f
            '  .Libre_GRD.DataSource = TblBrut
            ' newShowEcran(f, True)
            '  End With
            ShowMessageBox("Erreur fichier préétabli (ne comporte pas les initiaux 'A00','A01','A02' ou ,'A03').", "Importation", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        Identif_Transfert_Text.Text = rw0(0).Item("Donnee").ToString.Substring(0, 14)

        Num_Affilie_txt.Text = rw1(0).Item("Donnee").ToString.Substring(0, 7)
        Annee_Value.Value = rw1(0).Item("Donnee").ToString.Substring(7, 4)
        Periode_Combo.SelectedValue = rw1(0).Item("Donnee").ToString.Substring(11, 2)
        Raison_Sociale_txt.Text = rw1(0).Item("Donnee").ToString.Substring(13, 40)
        Activite_txt.Text = rw1(0).Item("Donnee").ToString.Substring(53, 40)
        Adresse_txt.Text = rw1(0).Item("Donnee").ToString.Substring(93, 120)
        Ville_txt.Text = rw1(0).Item("Donnee").ToString.Substring(213, 20)
        CP_txt.Text = rw1(0).Item("Donnee").ToString.Substring(233, 6)
        Agence_txt.Text = rw1(0).Item("Donnee").ToString.Substring(239, 2).Trim
        Lib_Agence_txt.Text = CnExecuting("select isnull((select Nom_Agence_Cnss from Param_DamanCom_Agence where Cod_Agence_Cnss='" & Agence_txt.Text & "'),'')").Fields(0).Value
        Date_Emission_txt.Text = rw1(0).Item("Donnee").ToString.Substring(247, 2) & "/" & rw1(0).Item("Donnee").ToString.Substring(245, 2) & "/" & rw1(0).Item("Donnee").ToString.Substring(241, 4)
        Date_Exig_txt.Text = rw1(0).Item("Donnee").ToString.Substring(255, 2) & "/" & rw1(0).Item("Donnee").ToString.Substring(253, 2) & "/" & rw1(0).Item("Donnee").ToString.Substring(249, 4)

        Dim TblAssure As New DataTable
        With TblAssure
            .Columns.Add("Num_Assure")
            .Columns.Add("Nom")
            .Columns.Add("Prenom")
            .Columns.Add("Enfants")
            .Columns.Add("AF_A_Payer")
            .Columns.Add("AF_A_Deduire")
            .Columns.Add("AF_Net_A_Payer")
            .Columns("Num_Assure").ColumnName = "N° Assuré"
            .Columns("Prenom").ColumnName = "Prénom"
            .Columns("Enfants").ColumnName = "Nbre Enfants"
            .Columns("AF_A_Payer").ColumnName = "Allocations à payer"
            .Columns("AF_A_Deduire").ColumnName = "Allocations à déduire"
            .Columns("AF_Net_A_Payer").ColumnName = "Allocations nettes à payer"
        End With
        Dim C1, C2, C3, C4, C5, C6, C7 As Object
        str = ""
        Dim strIndx As Integer = -1
        For i = 0 To rw2.Length - 1
            C1 = rw2(i).Item("Donnee").ToString.Substring(13, 9)
            str = rw2(i).Item("Donnee").ToString.Substring(22, 60)
            strIndx = str.IndexOf("  ")
            If strIndx > 0 Then
                C2 = str.Substring(0, strIndx).Trim
                C3 = str.Substring(strIndx, 60 - strIndx).Trim
            Else
                C2 = str
                C3 = ""
            End If

            C4 = rw2(i).Item("Donnee").ToString.Substring(82, 2)
            C5 = rw2(i).Item("Donnee").ToString.Substring(84, 4) & "," & rw2(i).Item("Donnee").ToString.Substring(88, 2)
            C6 = rw2(i).Item("Donnee").ToString.Substring(90, 4) & "," & rw2(i).Item("Donnee").ToString.Substring(94, 2)
            C7 = rw2(i).Item("Donnee").ToString.Substring(96, 4) & "," & rw2(i).Item("Donnee").ToString.Substring(100, 2)
            TblAssure.Rows.Add(C1, C2, C3, C4, C5, C6)
        Next
        With Grd
            .DataSource = TblAssure
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub

    Private Sub Zoom_Cnss_Damancom_Preetabli_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Periode_Combo.FromSQL("select Cod_Periode, Lib_Periode from Param_DamnCom_Periode order by Cod_Periode")

    End Sub

    Sub Actualiser()
        Reset_Form(Me)
        CheminPretabliStr = ""
    End Sub

    Sub Saving()
        Try
            Dim TblPaie As DataTable = DATA_READER_GRD("exec Sys_Declaration " & Societe.id_Societe & ",'Damancom_Ent'," & Annee_Value.Value & "," & Periode_Combo.SelectedValue)
            If TblPaie.Columns.Count <= 1 Then
                ShowMessageBox("Merci de paramétrer la déclaration CNSS DamanCom d'abord.", "DamanCom", MessageBoxButtons.OK, msgIcon.Error)
                Return
            End If

            With TblPaie
                .Columns.Add("Existe")
                .Columns("Existe").ReadOnly = False
                For i = 0 To .Rows.Count - 1
                    .Rows(i)("Existe") = 0
                Next
            End With
            Dim nrw() As DataRow = Nothing
            With frm
                .initialiserDamancom()
                .Identif_Transfert_Text.Text = Identif_Transfert_Text.Text
                .Num_Affilie_txt.Text = Num_Affilie_txt.Text
                .Annee.Value = Annee_Value.Value
                .Periode_Cbo.SelectedValue = Periode_Combo.SelectedValue
                .Raison_Sociale_txt.Text = Raison_Sociale_txt.Text
                .Activite_txt.Text = Activite_txt.Text
                .Adresse_txt.Text = Adresse_txt.Text
                .Ville_txt.Text = Ville_txt.Text
                .CP_txt.Text = CP_txt.Text
                .Agence_txt.Text = Agence_txt.Text
                .Lib_Agence_txt.Text = Lib_Agence_txt.Text
                .Date_Emission_txt.Text = Date_Emission_txt.Text
                .Date_Exig_txt.Text = Date_Exig_txt.Text
                .Source_Preetabli_chk.Checked = True
                .Dat_Import_Preetabli_txt.Text = Now
                .Grd_Permanent.Rows.Clear()
                Dim C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, c12 As Object
                With Grd
                    For i = 0 To .Rows.Count - 1
                        C1 = IsNull(.Item("N° Assuré", i).Value, "").Trim
                        nrw = TblPaie.Select("Num_Assure='" & C1 & "'")
                        C2 = IsNull(.Item("Nom", i).Value, "")
                        C3 = IsNull(.Item("Prénom", i).Value, "")
                        C4 = FormatNumber(IsNull(.Item("Nbre Enfants", i).Value, 0), 0)
                        C5 = FormatNumber(IsNull(.Item("Allocations à payer", i).Value, 0), 2)
                        C6 = FormatNumber(IsNull(.Item("Allocations à déduire", i).Value, 0), 2)
                        C7 = FormatNumber(IsNull(.Item("Allocations nettes à payer", i).Value, 0), 2)
                        C8 = "0,00"
                        If nrw.Length > 0 Then
                            C9 = FormatNumber(IsNull(nrw(0)("Jours_Declares"), 0), 2)
                            C10 = FormatNumber(IsNull(nrw(0)("Salaire_Reel"), 0), 2)
                            C11 = FormatNumber(IsNull(nrw(0)("Salaire_Plaf"), 0), 2)
                            c12 = If(C11 = 0, "SO", "")
                            nrw(0)("Existe") = 1
                        Else
                            C9 = "0,00"
                            C10 = "0,00"
                            C11 = "0,00"
                            c12 = "SO"
                        End If
                        frm.Grd_Permanent.Rows.Add(C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, c12)
                    Next
                End With
            End With
            nrw = TblPaie.Select("Existe=0")
            With nrw
                For i = 0 To .Length - 1
                    Dim C1, C2, C3, C4, C5, C6, C7 As Object
                    C1 = IsNull(nrw(i)("Num_Assure"), "")
                    C2 = IsNull(nrw(i)("Nom"), "")
                    C3 = IsNull(nrw(i)("Prenom"), "")
                    C4 = IsNull(nrw(i)("CIN"), "")
                    C5 = FormatNumber(IsNull(nrw(i)("Jours_Declares"), 0), 2)
                    C6 = FormatNumber(IsNull(nrw(i)("Salaire_Reel"), 0), 2)
                    C7 = FormatNumber(IsNull(nrw(i)("Salaire_Plaf"), 0), 2)
                    frm.Grd_Entrants.Rows.Add(C1, C2, C3, C4, C5, C6, C7)
                Next
            End With
            Me.Close()
        Catch ex As Exception
            ErrorMsg(ex)
        End Try

    End Sub

    Sub Nouveau()

    End Sub
End Class