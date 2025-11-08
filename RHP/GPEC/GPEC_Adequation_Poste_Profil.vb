Public Class GPEC_Adequation_Poste_Profil
    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If rd_CV.Checked Then
            Appel_Zoom1("MS161", Matricule_txt, Me)
        Else
            Appel_Zoom1("MS018", Matricule_txt, Me)
        End If
    End Sub
    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Dim Tbl As New DataTable
        If rd_CV.Checked Then
            Tbl = DATA_READER_GRD("select isnull(Nom+' '+Prenom,'') as Nom, Cod_Poste,Lib_Poste, Cod_Grade,Lib_Grade,'' Cod_Entite,Lib_Entite, Titre 
from CVTheque a
outer apply (select Lib_Poste from Org_Poste where id_Societe=a.id_Societe and Cod_Poste=a.Cod_Poste)p
outer apply (select Lib_Grade from Org_Grade where id_Societe=a.id_Societe and Cod_Grade=a.Cod_Grade)g
outer apply (select Lib_Entite from Org_Entite where id_Societe=a.id_Societe and Cod_Entite=a.Cod_Entite)e
where id_Societe=" & Societe.id_Societe & " and Matricule='" & Matricule_txt.Text & "'")
        Else
            Tbl = DATA_READER_GRD("select isnull(Nom_Agent+' '+Prenom_Agent,'') as Nom, Cod_Poste,Lib_Poste, Cod_Grade,Lib_Grade, Cod_Entite,Lib_Entite, Titre 
from RH_Agent a
outer apply (select Lib_Poste from Org_Poste where id_Societe=a.id_Societe and Cod_Poste=a.Cod_Poste)p
outer apply (select Lib_Grade from Org_Grade where id_Societe=a.id_Societe and Cod_Grade=a.Cod_Grade)g
outer apply (select Lib_Entite from Org_Entite where id_Societe=a.id_Societe and Cod_Entite=a.Cod_Entite)e
where id_Societe=" & Societe.id_Societe & " and Matricule='" & Matricule_txt.Text & "'")
        End If
        With Tbl
            If .Rows.Count > 0 Then
                Poste_Text.Text = IsNull(.Rows(0)("Cod_Poste"), "")
                Nom_Agent_Text.Text = IsNull(.Rows(0)("Nom"), "")
                Lib_Poste_Text.Text = IsNull(.Rows(0)("Lib_Poste"), "")
                Grade_Text.Text = IsNull(.Rows(0)("Cod_Grade"), "")
                Lib_Grade_Text.Text = IsNull(.Rows(0)("Lib_Grade"), "")
                Cod_Entite_txt.Text = IsNull(.Rows(0)("Cod_Entite"), "")
                Lib_Entite_txt.Text = IsNull(.Rows(0)("Lib_Entite"), "")
                Titre_txt.Text = IsNull(.Rows(0)("Titre"), "")
            Else
                Poste_Text.Text = ""
                Nom_Agent_Text.Text = ""
                Lib_Poste_Text.Text = ""
                Grade_Text.Text = ""
                Lib_Grade_Text.Text = ""
                Cod_Entite_txt.Text = ""
                Lib_Entite_txt.Text = ""
                Titre_txt.Text = ""
            End If
        End With
        Tbl = DATA_READER_GRD("exec Sys_Rh_Adequation_Poste_Profil '" & Matricule_txt.Text & "'," & Societe.id_Societe)
        With Tbl
            Grille.Rows.Clear()
            For i = 0 To .Rows.Count - 1
                Grille.Rows.Add(.Rows(i)("Lib_Domaines_Competence"), .Rows(i)("NoteRequise"), .Rows(i)("NoteObtenue"), .Rows(i)("Ecart"))
                Grille.Rows(i).Tag = .Rows(i)("Pourcentage")
            Next
        End With
    End Sub

    Private Sub Grille_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles Grille.CellPainting
        If e.ColumnIndex = Pourcentage.Index AndAlso e.RowIndex >= 0 Then
            ' Stop default cell painting
            e.Handled = True

            ' Get the progress value
            Dim progressValue As Integer = CInt(Grille.Rows(e.RowIndex).Tag)
            Dim w = e.CellBounds.Width - 4
            Dim h = e.CellBounds.Height - 6
            ' Calculate the percentage of the progress
            Dim percentage As Single = CSng(progressValue / 100.0F)

            ' Paint the background of the cell
            e.Graphics.FillRectangle(Brushes.White, e.CellBounds)

            ' Draw the progress bar (light green)
            Dim progressBarWidth As Integer = CInt(percentage * w)
            Dim _color As Color = Color.LightGreen
            If progressValue < 33 Then
                _color = Color.FromArgb(240, 72, 94)
            ElseIf progressValue < 66 Then
                _color = Color.FromArgb(240, 208, 0)
            End If
            Dim brush As New SolidBrush(_color)
            e.Graphics.FillRectangle(brush, e.CellBounds.X + 2, e.CellBounds.Y + 3, progressBarWidth, h)

            ' Draw the cell border
            Dim borderColor As Color = e.CellStyle.BackColor
            ' Draw the cell border with the current cell's border color
            Using pen As New Pen(borderColor, 2)
                e.Graphics.DrawRectangle(pen, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height)
            End Using


            ' Draw the progress text
            Dim text As String = progressValue.ToString() & "%"
            Dim textSize As SizeF = e.Graphics.MeasureString(text, e.CellStyle.Font)
            Dim textX As Single = e.CellBounds.X + (w - textSize.Width) / 2
            Dim textY As Single = e.CellBounds.Y + (h - textSize.Height) / 2 + 1

            ' Draw the percentage text in the center
            e.Graphics.DrawString(text, e.CellStyle.Font, If(progressValue > 45, Brushes.Black, brush), New PointF(textX, textY))
        End If
    End Sub
End Class