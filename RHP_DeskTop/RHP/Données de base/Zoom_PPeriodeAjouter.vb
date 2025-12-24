Public Class Zoom_PPeriodeAjouter
    Friend lAnnee As Integer = 0
    Friend ActDu As String = "01/01/" & Now.Year
    Friend ActAu As String = "31/12/" & Now.Year
    Friend PreDu As String = ""
    Friend PreAu As String = ""
    Friend f As New Param_Periode_Paie
    Private Sub Zoom_PPeriodeAjouter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpDu.Value = ActDu
        dtpAu.Value = ActAu
    End Sub

    Private Sub btEnregistrer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_ud.Click

        If Not IsDate(dtpDu.Value) Then
            dtpDu.Select()
            Exit Sub
        End If
        If Not IsDate(dtpAu.Value) Then
            dtpAu.Select()
            Exit Sub
        End If
        If CDate(dtpDu.Value) >= CDate(dtpAu.Value) Then
            ShowMessageBox("Incohérence de dates")
            Exit Sub
        End If
        Dim DatTbl As DataTable = DATA_READER_GRD("select isnull(min(Dat_Deb),'01/01/1900') as MinDat,isnull(max(Dat_Fin),'01/01/1900') as MaxDat from Param_Periode_Paie 
                                  where Annee <>'" & lAnnee & "' and id_Societe=" & Societe.id_Societe)
        If (CDate(dtpDu.Value) <= CDate(DatTbl.Rows(0).Item("MaxDat"))) Or
     (CDate(dtpAu.Value) <= CDate(DatTbl.Rows(0).Item("MaxDat"))) Then
            ShowMessageBox("Risque de chauvauchement de dates avec des périodes déjà ouverte" & vbCrLf & "Voulez-vous continuer?", "Attention", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        Dim rs As New ADODB.Recordset
        rs.Open("select * from Param_Periode_Paie where Annee='" & lAnnee & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
            rs("Cloture").Value = False
            rs("Conge_Genere").Value = False
            rs("id_Societe").Value = Societe.id_Societe
        Else
            rs.Update()
        End If
        rs("Mois").Value = CDate(dtpDu.Value).Month
        rs("Annee").Value = CDate(dtpAu.Value).Year
        rs("Dat_Deb").Value = CDate(dtpDu.Value)
        rs("Dat_Fin").Value = CDate(dtpAu.Value)
        Dim Tbl As DataTable = DATA_READER_GRD("select Top 1 * from Param_Periode_Paie where Annee='" & CDate(dtpAu.Value).Year - 1 & "' and id_Societe='" & Societe.id_Societe & "' order by Annee desc")
        If Tbl.Rows.Count > 0 Then
            rs("Pre_Dat_Deb").Value = Tbl.Rows(0).Item("Dat_Deb")
            rs("Pre_Dat_Fin").Value = Tbl.Rows(0).Item("Dat_Fin")
            rs("Pre_Annee").Value = Tbl.Rows(0).Item("Annee")
            rs("Pre_Mois").Value = Tbl.Rows(0).Item("Mois")
        End If
        rs.Update()
        rs.Close()
        f.Request()
        Me.Close()
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Annuler_ud.Click
        Me.Close()
    End Sub

    Private Sub dtpDu_ValueChanged(sender As Object, e As EventArgs) Handles dtpDu.ValueChanged
        dtpAu.Value = "31/12/" & dtpDu.Value.Year
    End Sub
End Class