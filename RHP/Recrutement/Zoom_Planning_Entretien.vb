Public Class Zoom_Planning_Entretien
    Friend numRC As String = ""
    Friend EntretienTbl As New DataTable
    Private Sub Zoom_Planning_Entretien_Load(sender As Object, e As EventArgs) Handles Me.Load
        With Entretiens_Grd
            .AlternatingRowsDefaultCellStyle = Nothing
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .AllowUserToAddRows = False
        End With
        Request()
    End Sub
    Sub Request()
        Entretiens_Grd.Rows.Clear()
        Entretiens_Grd.Columns.Clear()
        Dim TblCandidat = DATA_READER_GRD($"select Matricule as Cod_Candidat,isnull(m.Nom,v.Nom) Nom_Candidat,Interne from Recrutement_Candidats c
outer apply (select Nom_Agent+' '+Prenom_Agent as Nom from RH_Agent where id_Societe=c.id_Societe and Matricule=c.Matricule)m
outer apply (select Nom+' '+Prenom as Nom from CVTheque where id_Societe=c.id_Societe and Matricule=c.Matricule)v
where id_Societe={Societe.id_Societe} and Num_RC='{numRC}'")
        Dim TblEvaluateurs = DATA_READER_GRD($"select Matricule as Cod_Evaluateur, m.Nom  Nom_Evaluateur from Recrutement_Evaluateurs c
outer apply (select Nom_Agent+' '+Prenom_Agent as Nom from RH_Agent where id_Societe=c.id_Societe and Matricule=c.Matricule)m
where id_Societe={Societe.id_Societe} and Num_RC='{numRC}'")
        Dim TblEntretien = DATA_READER_GRD($"select Candidat,Evaluateur, Dat_Entretien_Prevue, Dat_Entretien_Realise from Recrutement_Entretiens 
where id_Societe={Societe.id_Societe} and Num_RC='{numRC}'")
        Dim oW As Integer = 0
        With TblEvaluateurs
            Dim cl = New DataGridViewTextBoxColumn()

            cl.Name = "Candidats"
            cl.HeaderText = "Candidats"
            cl.DefaultCellStyle.BackColor = colorBase01
            cl.DefaultCellStyle.ForeColor = Color.White
            cl.DefaultCellStyle.SelectionBackColor = colorBase01
            cl.DefaultCellStyle.SelectionForeColor = Color.White
            cl.MinimumWidth = 250
            Entretiens_Grd.Columns.Add(cl)
            For i = 0 To .Rows.Count - 1
                Dim column = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
                column.CustomFormat = "dd/MM/yyyy HH:mm"
                column.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
                column.Name = .Rows(i)("Cod_Evaluateur")
                column.HeaderText = .Rows(i)("Nom_Evaluateur")
                column.MinimumWidth = 100
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Entretiens_Grd.Columns.Add(column)
                oW = Math.Max(oW, column.Width)
            Next
        End With
        With TblCandidat
            For i = 0 To .Rows.Count - 1
                Entretiens_Grd.Rows.Add()
                Entretiens_Grd.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Entretiens_Grd.Item(0, i).Value = CStr(.Rows(i)("Nom_Candidat")) & vbCrLf & "(" & .Rows(i)("Cod_Candidat") & ")"
                Entretiens_Grd.Item(0, i).Tag = .Rows(i)("Cod_Candidat")
                For j = 1 To Entretiens_Grd.Columns.Count - 1
                    Dim nrw() = TblEntretien.Select($"Candidat='{ .Rows(i)("Cod_Candidat")}' and Evaluateur='{Entretiens_Grd.Columns(j).Name}'")
                    If nrw.Length > 0 Then
                        Entretiens_Grd.Item(j, i).Value = nrw(0)("Dat_Entretien_Prevue")
                        Entretiens_Grd.Item(j, i).ReadOnly = IsDate(nrw(0)("Dat_Entretien_Realise"))
                        If Entretiens_Grd.Item(j, i).ReadOnly Then
                            Entretiens_Grd.Item(j, i).Style.BackColor = colorBase04
                        End If
                        Entretiens_Grd.Item(j, i).Style.Format = "dd/MM/yyyy HH:mm"
                    End If
                Next
            Next
        End With
        With Entretiens_Grd
            For Each cl As DataGridViewColumn In .Columns
                If cl.Name <> "Candidats" Then
                    cl.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    cl.Width = oW
                End If
            Next
        End With

    End Sub
    Sub Saving()
        With Entretiens_Grd
            CnExecuting($"delete from Recrutement_Entretiens where id_Societe={Societe.id_Societe} and Num_RC='{numRC}' and isdate(Dat_Entretien_Realise)=0")
            Dim rs As New ADODB.Recordset
            rs.Open($"select * from Recrutement_Entretiens where id_Societe={Societe.id_Societe} and Num_RC='{numRC}'", cn, 2, 2)
            For i = 0 To .Rows.Count - 1
                For j = 0 To .Columns.Count - 1
                    If IsDate(.Item(j, i).Value) And .Item(j, i).ReadOnly = False Then
                        rs.AddNew()
                        rs("Num_RC").Value = numRC
                        rs("id_Societe").Value = Societe.id_Societe
                        rs("Candidat").Value = .Item(0, i).Tag
                        rs("Evaluateur").Value = .Columns(j).Name
                        rs("Dat_Entretien_Prevue").Value = .Item(j, i).Value
                        rs.Update()
                    End If
                Next
            Next
            rs.Close()
        End With
        Request()
    End Sub

    Private Sub Save_pb_Click(sender As Object, e As EventArgs) Handles Save_pb.Click
        Saving()
        Me.Close()
    End Sub

    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        Me.Close()
    End Sub
End Class