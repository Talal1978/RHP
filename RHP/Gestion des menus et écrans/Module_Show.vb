Module Module_Show
    Sub newShowEcran(frm As Ecran, Optional AfficherModal As Boolean = False)
        frm.AutoScaleMode = AutoScaleMode.Dpi
        If Not AfficherModal Then
            Try
                CnExecuting("Delete from Controle_Access where Name_Ecran='RH_Preparation_Paie' and id_Societe=" & Societe.id_Societe & " and Process_Id=" & ProcessId)
                If leMenu.pnl_PersonnalContent.Controls.Contains(RH_Preparation_Paie) Then leMenu.pnl_PersonnalContent.Controls.Remove(RH_Preparation_Paie)
            Catch ex As Exception

            End Try

        End If
        If Not EstLicConforme(oKle) Or Not Droits.EstAuthentic Then
            frm = Accueil_LicenceNC
            frm.Dock = DockStyle.Fill
            GoTo suite
        End If
        If theUser.Typ_Role <> "Agent" Then
            If getCurrentEcran() IsNot Nothing Then
                If getCurrentEcran().Name = "Accueil_LicenceNC" Then
                    Cursor.Current = Cursors.Default
                    Accueil_LicenceNC.Close()
                End If
            End If
        End If
        Dim mVisible As String = IIf(theUser.Cod_Profile = 1 Or theUser.Typ_Role = "Agent", "'True'", "Visible")
        If cn.Execute("Select count(*) from Controle_Traitement where Termine='N'").Fields(0).Value > 0 Then
            MessageBoxRHP(521)
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        If CStr(theUser.Cod_Profile) <> "1" And theUser.Typ_Role <> "Agent" Then
            If CnExecuting("select count(*) from Controle_TreeView where Name_Ecran='" & frm.Name & "'").Fields(0).Value > 0 And IsNull(frm.Tag, "") = "ECR" Then
                If CnExecuting("select count(*) from Controle_Droit where Cod_Profile='" & theUser.Cod_Profile & "' and Name_Ecran='" & frm.Name & "' and " & mVisible & "='True' ").Fields(0).Value = 0 Then
                    MessageBoxRHP(522)
                    Cursor.Current = Cursors.Default
                    Exit Sub
                End If
            End If
        End If
        'DamanCom
        Select Case frm.Name
            Case "Cnss_DamanCom"
                If Not Droits.DamanCom Then
                    ShowMessageBox("DamanCom n'est pas une option activée pour votre licence.", "RHP", MessageBoxButtons.OK, msgIcon.Stop)
                    Cursor.Current = Cursors.Default
                    Exit Sub
                End If
            Case "IR_XML", "IR_Permanents", "IR_Exoneres", "IR_Permanents_Exonore", "IR_Stagiaires", "IR_Doctorants", "IR_Occasionnel", "IR_Benefeciaires"
                If Not Droits.IR_9421 Then
                    ShowMessageBox("La télédéclaraion de l'IR n'est pas une option activée pour votre licence.", "RHP", MessageBoxButtons.OK, msgIcon.Stop)
                    Cursor.Current = Cursors.Default
                    Exit Sub
                End If
            Case "Zoom_GED", "TC_GED"
                If Not Droits.GED Then
                    ShowMessageBox("La gestion électronique des documents n'est pas une option activée pour votre licence.", "RHP", MessageBoxButtons.OK, msgIcon.Stop)
                    Cursor.Current = Cursors.Default
                    Exit Sub
                End If
            Case "Org_Affectation_RH", "Org_Poste", "Org_Grade", "Org_Organigramme"
                If Not Droits.ORG Then
                    ShowMessageBox("La gestion organisationnelle n'est pas une option activée pour votre licence.", "RHP", MessageBoxButtons.OK, msgIcon.Stop)
                    Cursor.Current = Cursors.Default
                    Exit Sub
                End If

            Case "Zoom_Ana", "Ctb_Plan_Ana"
                If Not Droits.ANA Then
                    ShowMessageBox("L'analytique n'est pas une option activée pour votre licence.", "RHP", MessageBoxButtons.OK, msgIcon.Stop)
                    Cursor.Current = Cursors.Default
                    Exit Sub
                End If
        End Select
        'Vérifier les Postes 
        If theUser.Cod_Profile <> 1 Then
            Dim nrw() As DataRow = Tbl_Function_Security.Select("Ecrans like '%;" & frm.Name & ";%' and  Visible ='false'")
            If nrw.Length > 0 Then
                ShowMessageBox("La fonction de sécurité [" & nrw(0)("Lib_Function") & "], n'est pas activée pour votre profil.", "RHP", MessageBoxButtons.OK, msgIcon.Stop)
                Cursor.Current = Cursors.Default
                Exit Sub
            Else
                nrw = Tbl_Function_Security.Select("Ecrans like '%;" & frm.Name & ";%' and Actif ='false'")
                If nrw.Length > 0 Then
                    Dim saveD = GetControlByName("Save_D", frm)
                    Dim delD = GetControlByName("Del_D", frm)
                    If saveD IsNot Nothing Then
                        saveD.visible = False
                    End If
                    If delD IsNot Nothing Then
                        delD.visible = False
                    End If
                End If
            End If
        End If
        If theUser.Typ_Role <> "Agent" And IsNull(Societe.id_Societe, 0) <= 0 And Not "Admin_Profile;Admin_Users;DB_Societe;leMenu;Menu_Societes;Menu_System;Menu_Agent;Accueil_LicenceNC".Split(";").Contains(frm.Name) Then
            ShowMessageBox("Aucune Société choisie", "Société non sélectionnée", MessageBoxButtons.OK, msgIcon.Error)
            If leMenu.pnl_PersonnalContent.Controls.Contains(Menu_Societes) Then
                Menu_Societes.BringToFront()
            Else
                newShowEcran(Menu_Societes)
            End If
            Cursor.Current = Cursors.Default
            Return
        End If
        frm.estModal = frm.estModal Or AfficherModal
        If frm.estModal Then
            Dim nrw As DataRow() = Tbl_Controle_Def_Ecran_Button.Select("Name_Ecran='" & frm.Name & "'", "Rang asc")
            If nrw.Length = 0 Then
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.ShowDialog()
                Return
            End If
        End If
suite:
        With frm
            .TopMost = False
            .TopLevel = False
            .FormBorderStyle = FormBorderStyle.None
            .WindowState = FormWindowState.Normal
            .Dock = DockStyle.Fill
            KeyPressForm(frm)
            GestionDesVues(frm)
        End With
        If Not frm.estModal Then
            If theUser.Typ_Role = "Agent" Then
                Menu_Agent.menuPnl.Controls.Add(frm)
            Else
                leMenu.pnl_PersonnalContent.Controls.Add(frm)
            End If
            frm.setButtons()
            If Societe.Mis_Sml And frm.Name <> "DB_Societe" Then
                Dim nrw() = TblAccess.Select($"Name_Ecran='{frm.Name}' and Typ_Security='SC'")
                For i = 0 To nrw.Length - 1
                    If frm.dictButtons.ContainsKey(nrw(i)("Name_Controle")) Then
                        Enabling(frm.dictButtons(nrw(i)("Name_Controle")), False)
                    End If
                Next

            End If
            frm.BringToFront()
            frm.Visible = True
            For Each c In Menu_Agent.menuPnl.Controls
                If c IsNot frm Then c.close
            Next
        Else
            Dim f As New Ecran_Container
            With f
                .Icon = leMenu.Icon
                .pnl_Content.Controls.Add(frm)
                frm.setButtons()
                If Societe.Mis_Sml Then
                    Dim nrw() = TblAccess.Select($"Name_Ecran='{frm.Name}' and Typ_Security='SC'")
                    For i = 0 To nrw.Length - 1
                        If frm.dictButtons.ContainsKey(nrw(i)("Name_Controle")) Then
                            Enabling(frm.dictButtons(nrw(i)("Name_Controle")), False)
                        End If
                    Next

                End If
                frm.BringToFront()
                frm.Visible = True
                .ShowDialog()
            End With
        End If
        Cursor.Current = Cursors.Default
    End Sub
    Function ConvertToTargetColor(original As Bitmap, isActif As Boolean, Optional defColor As Color = Nothing) As Bitmap
        If original Is Nothing Then Return original
        Dim colorized As Bitmap = New Bitmap(original.Width, original.Height)
        Dim targetColor As Color = IIf(isActif, If(defColor = Nothing, colorBase02, defColor), Color.FromArgb(141, 141, 141))
        For y As Integer = 0 To original.Height - 1
            For x As Integer = 0 To original.Width - 1
                Dim pixelColor As Color = original.GetPixel(x, y)
                ' Calculate the new color components
                Dim newR As Integer = targetColor.R
                Dim newG As Integer = targetColor.G
                Dim newB As Integer = targetColor.B
                Dim newColor As Color = Color.FromArgb(pixelColor.A, newR, newG, newB) ' Preserve alpha channel
                colorized.SetPixel(x, y, newColor)
            Next
        Next
        Return colorized
    End Function
    Sub goBack()
        With leMenu
            Dim currentfrm As Ecran = .currentEcran
            If .currentEcran Is Menu_Societes Then
                Return
            ElseIf .pnl_PersonnalContent.Controls.Count >= 2 Then
                ' Raise the FormClosing event
                Dim formClosingArgs As New FormClosingEventArgs(CloseReason.UserClosing, False)
                currentfrm.TriggerFormClosing(formClosingArgs)

                ' Check if the operation is canceled
                If formClosingArgs.Cancel Then
                    Exit Sub ' Exit the method if the close operation is canceled
                End If

                ' Proceed with going back
                Dim prevForm As New Ecran
                prevForm = .pnl_PersonnalContent.Controls(1)
                prevForm.BringToFront()
                Dim btns As Dictionary(Of String, ud_btn) = prevForm.dictButtons
                If btns IsNot Nothing Then
                    For Each v In btns.Values
                        v.Parent = .pnl_sideBarL
                    Next
                End If
                .pnl_sideBarL.Refresh()
                .currentEcran = prevForm
                currentfrm.Close()
            Else
                newShowEcran(Menu_Societes)
            End If
        End With
    End Sub

    Function getCurrentEcran() As Ecran
        If theUser.Typ_Role = "Agent" Then
            If Menu_Agent.menuPnl.Controls.Count > 0 Then
                Return Menu_Agent.menuPnl.Controls(0)
            End If
            Return Nothing
        End If
        Dim isModal = False
        Dim fModal As New Ecran_Container
        For Each f In Application.OpenForms
            If TypeOf f Is Ecran_Container Then
                ' Form1 is open
                isModal = True
                fModal = f
                Exit For
            End If
        Next
        If isModal Then
            Return fModal.pnl_Content.Controls(0)
        Else
            Return leMenu.currentEcran
        End If
    End Function
#Region "Pièces Jointes"
    Function GenererPJ() As ud_btn
        Dim btn As New ud_btn(getCurrentEcran(), "PiecesJointes", "", "btn_clip")
        AddHandler btn.Click, Sub()
                                  GetPiecesJointes()
                              End Sub
        Return btn
    End Function
    Sub GetPiecesJointes()
        Try
            Dim ecr = getCurrentEcran()
            Dim Index As String = FindLibelle("Index_Ecran", "Name_Ecran", ecr.Name, "Controle_Def_Ecran")
            Dim obj As Object = Nothing
            Dim indexList As String() = Index.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
            Dim Index_Value As String = ""
            For i = 0 To indexList.Length - 1
                obj = GetControlByName(indexList(i), ecr)
                If Not obj Is Nothing Then
                    Select Case obj.GetType.Name
                        Case "TextBox", "ud_TextBox"
                            Index_Value &= IIf(Index_Value <> "", ";", "") & obj.Text
                        Case "LinkLabel"
                            Index_Value &= IIf(Index_Value <> "", ";", "") & CType(obj, LinkLabel).Text
                        Case "ComboBox", "ud_ComboBox"
                            Index_Value &= IIf(Index_Value <> "", ";", "") & obj.SelectedValue
                        Case "NumericUpDown"
                            Index_Value &= IIf(Index_Value <> "", ";", "") & CType(obj, NumericUpDown).Value
                    End Select
                End If
            Next
            If Not Index_Value = "" Then
                Dim Z As New Zoom_GED
                With Z
                    If ecr.dictButtons.ContainsKey("Save_D") Then
                        .LecteureSeule = Not (ecr.dictButtons("Save_D").Enabled And ecr.dictButtons("Save_D").Visible)
                    End If
                    .NameEcran = ecr.Name
                    .Text = "Pièces Jointes"
                    .IndexEcran = Index
                    .valeurIndex = Index_Value
                    .ShowDialog()
                End With
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
#End Region

    Function GenererTraitementSpe() As ud_btn
        Dim btn As New ud_btn(getCurrentEcran(), "TraitementSpe", "", "btn_specifique")
        With btn
            .Visible = True
            .ToolTip = "Traitements Spécifiques"
            AddHandler .Click, Sub()
                                   Dim f As New Zoom_TraitementsSpecifiques
                                   f.ShowDialog()
                               End Sub

        End With
        Return btn
    End Function
    Function GenererModEditions() As ud_btn
        Dim ecr = getCurrentEcran()
        Dim btn As New ud_btn(ecr, "Imprimer_D", "", "btn_printer")
        With btn
            .Name = "Imprimer_D"
            .Visible = True
            .ToolTip = "Impressions"
            AddHandler .Click, Sub()
                                   Dim f As New Zoom_Editions
                                   If btn.ParentForm.GetType Is GetType(Ecran_Container) Then
                                       f.ecr = CType(btn.ParentForm, Ecran_Container).pnl_Content.Controls(0)
                                   Else
                                       f.ecr = getCurrentEcran()
                                   End If
                                   f.ShowDialog()
                               End Sub
        End With
        Return btn
    End Function
    Sub GestionDesVues(frm As Ecran)
        Dim TypSecurity As String = ""
        Dim c As Object
        Dim nRows() As DataRow
        nRows = TblAccess.Select("[Name_Ecran]='" & frm.Name & "' and Typ_Security in ('SC','SN','NC')")
        Dim estVisible As Boolean = False
        Dim estActif As Boolean = False
        With nRows
            For i = 0 To .Length - 1
                TypSecurity = nRows(i)("Typ_Security")
                estVisible = CBool(nRows(i)("Visible"))
                estActif = CBool(nRows(i)("Actif"))
                c = GetControlByName(nRows(i)("Name_Controle"), frm)
                If c IsNot Nothing Then
                    Select Case TypSecurity
                        Case "NC"
                            If Not estActif Then
                                Enabling(c, False)
                            End If
                        Case "SC"
                            If Not estVisible Then
                                c.visible = False
                            ElseIf Not estActif Then
                                Enabling(c, False)
                                c.visible = True
                            End If
                        Case "SN"
                            If Not estVisible Then
                                c.visible = False
                            End If
                    End Select
                End If
            Next
        End With
        Return
    End Sub
    Function OuvrirFichier() As String
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.AutoUpgradeEnabled = False
        OpenFileDialog.InitialDirectory = importPath
        OpenFileDialog.Filter = "Tous les fichiers (*.*)|*.*|Fichiers Word (*.docx)|*.docx|Fichiers Excel (*.xlsx)|*.xlsx|Fichiers Pdf (*.pdf)|*.pdf|Fichiers JPEG (*.jpg)|*.jpg|Fichiers bmp (*.bmp)|*.bmp|Texte (*.txt)|*.txt"
        If (OpenFileDialog.ShowDialog(Login) = DialogResult.OK) Then
            importPath = System.IO.Path.GetFullPath(OpenFileDialog.FileName)
            Dim FileName As String = OpenFileDialog.FileName
            Return FileName
        Else
            Return ""
        End If
    End Function
    Function openLink(objName As String, objText As String, objTyp As String) As Boolean
        Select Case objTyp
            Case "ECR"
                Dim frm As Form = GetFormByName(objName)
                If frm Is Nothing Then Return False
                newShowEcran(frm)
            Case "RPT"
                Dim f As New Param_Modele_Edition_Saisi
                f.Text = objText
                f.Report_Generator(objName, objText)
                newShowEcran(f)
            Case "QRY", "CHR", "TRT", "EXP"
                Dim f As New Param_Query_Saisi
                f.Text = objText
                f.Query_Generator(objName, objText)
                newShowEcran(f)
            Case "SYS"
                Dim frm As Form = GetFormByName(objName)
                If frm Is Nothing Then Return False
                frm.ShowDialog()
        End Select
        _localParams.recents = objName & ";" & String.Join(";", IsNull(_localParams.recents, "").Split(";").Where(Function(x) x <> objName).Take(9).ToArray())
        _localParams.frequents = objName & ";" & String.Join(";", IsNull(_localParams.frequents, "").Split(";").Take(99).ToArray())
        Return True
    End Function
    Sub Quitter(mainfrm As Form)
        Try
            jsonObject(theUser.Login) = Newtonsoft.Json.Linq.JObject.FromObject(_localParams)
            If IO.File.Exists("db.json") Then IO.File.Delete("db.json")
            Dim sw As New IO.StreamWriter("db.json")
            sw.Write(jsonObject.ToString)
            sw.Close()
            Dim NumProcess = System.Diagnostics.Process.GetCurrentProcess().Id
            Dim NomMachine = My.Computer.Name
            ' Nettoyer les processus en cours
            CnExecuting("delete from Controle_Access where Process_Id = " & NumProcess)
            CnExecuting("update Controle_Users_Process set isConnected='false' where Process_Id='" & NumProcess & "' and hostname='" & NomMachine & "'")
            CnExecuting("delete from Controle_Access where Process_Id='" & NumProcess & "' and Taken_By_Machine='" & NomMachine & "'  and exists(select Name_Ecran from Controle_Menu where Name_Ecran=Controle_Access.Name_Ecran and Typ_Ecran='ECR')")
            CnExecuting("Update Param_Abonnement set Statut=0  where Process_Id='" & NumProcess & "' and Machine_Name='" & NomMachine & "'")

            ' Fermer toutes les connexions de base de données
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            If cn1 IsNot Nothing AndAlso cn1.State = ConnectionState.Open Then
                cn1.Close()
            End If

        Catch ex As Exception
            ' Ignorer toutes les erreurs
        Finally
            ' Forcer la fermeture directement sans essayer de fermer les formulaires
            Environment.Exit(0)
        End Try
    End Sub
End Module
