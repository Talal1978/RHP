Public Class ud_Domaine_Competence
    Dim otoolTip As New ToolTip
    Dim _showRating As Boolean = True
    Friend canRate As Boolean = False
    Dim _rating As Double = 5
    Dim ratingList As New List(Of PictureBox)
    Public Property Rating As Double
        Get
            Return _rating
        End Get
        Set(value As Double)
            _rating = Math.Max(0, value)
            _rating = Math.Min(5, value)
            With rating_lbl
                .Text = FormatNumber(_rating, 1)
                .Refresh()
            End With
            Dim nb As Int16 = -1
            For i = 0 To Math.Floor(_rating) - 1
                ratingList(i).Image = My.Resources.star_2
                nb += 1
            Next
            If nb < 4 Then
                If _rating - Math.Floor(_rating) > 0 Then
                    ratingList(nb + 1).Image = My.Resources.star_1
                    nb += 1
                End If
            End If
            If nb < 4 Then
                For i = nb + 1 To 4
                    ratingList(i).Image = My.Resources.star_0
                Next
            End If

        End Set
    End Property
    Public Property ShowRating As Boolean
        Get
            Return _showRating
        End Get
        Set(value As Boolean)
            _showRating = value
            '     rating_pnl.Visible = False
            If Not value Then
                layout_pnl.RowStyles(1) = New RowStyle(SizeType.Absolute, 0!)
                Me.Height = 25
            Else
                layout_pnl.RowStyles(1) = New RowStyle(SizeType.Absolute, 17.0!)
                Me.Height = 38
            End If
        End Set
    End Property
    Sub New()
        InitializeComponent()
        Me.Parent = Nothing
        ShowRating = _showRating
        ratingList.Add(pbStar_01)
        ratingList.Add(pbStar_02)
        ratingList.Add(pbStar_03)
        ratingList.Add(pbStar_04)
        ratingList.Add(pbStar_05)
        Cursor.Current = Cursors.Default
        If Not canRate Then
            pbStar_01.Cursor = Cursors.Default
            pbStar_02.Cursor = Cursors.Default
            pbStar_03.Cursor = Cursors.Default
            pbStar_04.Cursor = Cursors.Default
            pbStar_05.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub Close_pb_Click(sender As Object, e As EventArgs) Handles Close_pb.Click
        CallByName(Me.FindForm, "SuppressionDomaine", CallType.Method, {Me})
    End Sub
    Public Property Nom
        Get
            Return Competence_lbl.Name
        End Get
        Set(value)
            Dim Tbl As DataTable = DATA_READER_GRD("select Domaines_Competence as Competence,Lib_Domaines_Competence as Intitule,isnull(Domaine,'') Domaine 
from GPEC_Domaines_Competence c
outer apply(select Lib_Domaines_Competence as Domaine
from GPEC_Domaines_Competence g  where Domaines_Competence=isnull(c.Parent,'')  and g.id_Societe=c.id_Societe)d
where id_Societe=" & Societe.id_Societe & " and Domaines_Competence='" & value & "'")
            Dim _competence = ""
            Dim _domaine = ""
            If Tbl.Rows.Count > 0 Then
                _competence = Tbl.Rows(0)("Intitule")
                _domaine = Tbl.Rows(0)("Domaine")
            End If
            With Competence_lbl
                .Name = value
                .Text = _competence
                otoolTip.SetToolTip(Competence_lbl, _domaine & If(Not String.IsNullOrWhiteSpace(_domaine), vbCrLf, "") & .Text)
                .Refresh()
            End With
            Me.Text = _competence
            Me.Name = value
        End Set
    End Property
    Private Sub Competence_lbl_TextChanged(sender As Object, e As EventArgs) Handles Competence_lbl.TextChanged
        ' Calcul de la taille nécessaire pour le texte, en ajoutant une marge pour ne pas coller aux bords
        Dim textWidth As Integer = TextRenderer.MeasureText(Competence_lbl.Text, Competence_lbl.Font).Width
        Dim totalWidth As Integer = textWidth + Close_pb.Width + 20 ' Ajoutez une marge supplémentaire pour l'espacement

        ' Assurez-vous que le contrôle peut s'ajuster pour être au moins aussi large que le texte + le bouton de fermeture
        If totalWidth > Me.MinimumSize.Width Then
            Me.Width = totalWidth
        Else
            Me.Width = Me.MinimumSize.Width
        End If

        Me.Invalidate() ' Force le contrôle à se redessiner
    End Sub

    Private Sub pbStar_Click(sender As PictureBox, e As EventArgs) Handles pbStar_01.Click, pbStar_02.Click, pbStar_03.Click, pbStar_04.Click, pbStar_05.Click
        If Not canRate Then Return
        Dim ind = ratingList.IndexOf(sender)
        If Rating > Math.Floor(Rating) And ind = Math.Floor(Rating) Then
            Rating += 0.5
        Else
            Rating = ind + 0.5
        End If

    End Sub
End Class
