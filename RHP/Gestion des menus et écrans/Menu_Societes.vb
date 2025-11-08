Imports System.ComponentModel
Public Class Menu_Societes
    Friend _switch As Boolean = True
    Dim _sortMode As String = "Asc"
    Friend WithEvents BKG, BKG01 As New BackgroundWorker
    Dim noSocieteCreated As Boolean = False
    Dim _swhere As String = ""
#Region "Actions sur l'écran"
    Sub AjouterSociete()
        Dim f As New DB_Societe
        With f
            .idScociete_txt.Text = -1
            OuvrirSociete(-1, True)
            newShowEcran(f)
            .WindowState = FormWindowState.Maximized
            .txtDen.Select()
            .Requesting()
        End With
    End Sub
    Sub ModifSociete()
        Dim f As New DB_Societe
        With f
            .idScociete_txt.Text = Societe.id_Societe
            newShowEcran(f)
            .WindowState = FormWindowState.Maximized
            .txtDen.Select()
            .Requesting()
        End With
    End Sub
    Sub Raffraichir()
        If Not BKG.IsBusy Then BKG.RunWorkerAsync()
    End Sub
    Sub SortingA()
        Generer_Societe(_swhere, "Asc")
    End Sub
    Sub SortingD()
        Generer_Societe(_swhere, "Desc")
    End Sub
    Sub Switching()
        _switch = Not _switch
        With Me.dictButtons("Swith_D")
            .Image = If(_switch, My.Resources.btn_grid_on, My.Resources.btn_grid_off)
        End With
        Generer_Societe(_swhere)
    End Sub
#End Region
    Private Sub Menu_Browser_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DoubleBuffered = True
        BKG.RunWorkerAsync()
    End Sub
    Private Sub BKG_DoWork(sender As Object, e As DoWorkEventArgs) Handles BKG.DoWork
        ChargerSociete()
        If TblSociete.Rows.Count = 0 Then
            If ShowMessageBox("Aucune société créée, voulez-vous en créer une maintenant?", "Ajouter une nouvelle société", MessageBoxButtons.OKCancel, msgIcon.Information) = DialogResult.OK Then
                noSocieteCreated = True
            End If
        End If
    End Sub
    Private Sub BKG_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BKG.RunWorkerCompleted
        Dim idSoc As Integer = _localParams.currentIdSoc
        Generer_Societe()
        If idSoc > 0 Then
            OuvrirSociete(idSoc)
        End If
        If noSocieteCreated Then
            Dim f As New DB_Societe
            With f
                newShowEcran(f)
                .txtDen.Select()
            End With
        End If
    End Sub
    Sub Generer_Societe(Optional swhere As String = "", Optional sortMde As String = "Asc")
        _swhere = swhere
        If sortMde <> "" Then _sortMode = sortMde

        Ud_Content.SuspendLayout()
        Ud_Content.Controls.Clear()

        Dim nrw() As DataRow = TblSociete.Select(_swhere, "Den " & _sortMode)
        Dim Xx, Yy, nb, sp, nbMaxPerLine, w, h As Integer
        Dim controlsToAdd As New List(Of Control)
        sp = 5
        nb = 0

        If _switch Then
            Dim tempControl As New ud_CardSoc
            w = tempControl.Width
            h = tempControl.Height
            nbMaxPerLine = Math.Floor((Ud_Content.Width - 20) / (w + sp))
            sp += (Ud_Content.Width - 20 - (w + sp) * nbMaxPerLine) / (nbMaxPerLine + 1)
            For i = 0 To nrw.Length - 1
                Dim soc As New ud_CardSoc With {
                    .Name = nrw(i)("id_Societe").ToString(),
                    .Den = nrw(i)("Den").ToString(),
                    .idSoc = nrw(i)("id_Societe").ToString(),
                    .Tag = "Societe"
                }

                If nb = 0 Then
                    Xx = sp
                    Yy = sp
                ElseIf (nb + 1) > nbMaxPerLine Then
                    'saut de ligne
                    Yy += h + sp
                    Xx = sp
                    nb = 0
                Else
                    'continuer sur la ligne
                    Xx += w + sp
                End If
                soc.Location = New Point(Xx, Yy)
                controlsToAdd.Add(soc)
                nb += 1
            Next
        Else
            Dim tempControl As New ud_CardSoc_Small
            h = tempControl.Height
            For i = 0 To nrw.Length - 1
                Dim soc As New ud_CardSoc_Small With {
                    .Name = nrw(i)("id_Societe").ToString(),
                    .Den = nrw(i)("Den").ToString(),
                    .idSoc = nrw(i)("id_Societe").ToString(),
                    .Tag = "Societe"
                }

                If nb = 0 Then
                    Xx = sp
                    Yy = sp
                Else
                    Yy += h + sp
                End If
                soc.Location = New Point(Xx, Yy)
                controlsToAdd.Add(soc)
                nb += 1
            Next
        End If

        Ud_Content.Controls.AddRange(controlsToAdd.ToArray())
        Ud_Content.ResumeLayout(True)
    End Sub

End Class



