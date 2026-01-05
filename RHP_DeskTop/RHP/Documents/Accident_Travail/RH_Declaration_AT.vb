Public Class RH_Declaration_AT
    Dim Code As String = ""
    Dim New_D As ud_btn
    Dim Save_D As ud_btn
    Dim Del_D As ud_btn
    Dim Valide_D As ud_btn
    Dim valideStr As String = "✔"
    Dim statutDoc As String = ""
    Public ReadOnly Property AllowUploadInReadOnly As Boolean
        Get
            Return True
        End Get
    End Property
    Sub Chargement()
        If New_D Is Nothing Then
            New_D = dictButtons("New_D")
            Save_D = dictButtons("Save_D")
            Del_D = dictButtons("Del_D")
            Valide_D = dictButtons("Valide_D")
        End If
        If Nature_Lesion_cbo.Items.Count = 0 Then Nature_Lesion_cbo.fromRubrique("Nature_Lesion")
        If Siege_Lesion_cbo.Items.Count = 0 Then Siege_Lesion_cbo.fromRubrique("Siege_Lesion_AT")
        If Typ_Certificat.Items.Count = 0 Then Combo_GRD(Typ_Certificat, "Typ_Certificat_AT")
    End Sub

    Private Sub RH_Declaration_AT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        If Matricule_txt.Text = "" And IsNull(theUser.Matricule, "") <> "" Then Matricule_txt.Text = theUser.Matricule
        If Not EstDate(Dat_Accident_txt.Text) Then Dat_Accident_txt.Text = Now.ToShortDateString
        With Grd_Certificats
            .DefaultCellStyle.SelectionBackColor = colorBase04
        End With
    End Sub
    Sub Request()
        Chargement()
        pb_Valide.Visible = False
        Dim canModify As Boolean = True
        Dim SqlStr As String = "SELECT * FROM RH_Declaration_AT where Num_Declaration='" & Num_Declaration_txt.Text & "' and id_Societe=" & Societe.id_Societe
        Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
        statutDoc = ""
        With Tbl
            If .Rows.Count > 0 Then
                Dat_Accident_txt.Text = IsNull(.Rows(0)("Dat_Accident"), "")
                Heure_Accident.Value = DateTime.ParseExact(IsNull(.Rows(0)("Heure_Accident"), "00:00"), "HH:mm",
                                              Globalization.CultureInfo.InvariantCulture)
                Lieu_Accident_txt.Text = IsNull(.Rows(0)("Lieu_Accident"), "")
                Circonstances_txt.Text = IsNull(.Rows(0)("Circonstances"), "")
                Matricule_txt.Text = IsNull(.Rows(0)("Matricule"), "")


                Nature_Lesion_cbo.SelectedValue = IsNull(.Rows(0)("Nature_Lesion"), "")
                Siege_Lesion_cbo.SelectedValue = IsNull(.Rows(0)("Siege_Lesion"), "")
                Temoins_txt.Text = IsNull(.Rows(0)("Temoins"), "")
                Tiers_Responsable_txt.Text = IsNull(.Rows(0)("Tiers_Responsable"), "")
                Num_Assurance_txt.Text = IsNull(.Rows(0)("Num_Assurance"), "")
                Commentaire_txt.Text = IsNull(.Rows(0)("Commentaire"), "")
                statutDoc = If("VA;SG;RJ".Split(";").Contains(IsNull(Tbl.Rows(0)("Statut"), "")), "VA", If(IsNull(Tbl.Rows(0)("Cloture"), False), "CL", ""))
                With pb_Valide
                    .Tag = ""
                    .Image = If(IsNull(Tbl.Rows(0)("Cloture"), False) = True, My.Resources.stamp_cloture, My.Resources.valide01)
                    Select Case IsNull(Tbl.Rows(0)("Statut"), "")
                        Case "SG"
                            .Image = My.Resources.valide01
                            .Tag = "SG"
                        Case "RJ"
                            .Image = My.Resources.refuse
                            .Tag = "RJ"
                    End Select
                    .Visible = ("VA;SG;RJ".Split(";").Contains(IsNull(Tbl.Rows(0)("Statut"), "")) Or IsNull(Tbl.Rows(0)("Cloture"), False) = True)
                    If IsNull(Tbl.Rows(0)("Statut"), "") <> "" Or IsNull(Tbl.Rows(0)("Cloture"), False) = True Then
                        Save_D.Enabled = False
                        Del_D.Enabled = False
                        Valide_D.Enabled = False
                        canModify = False
                    Else
                        canModify = True
                    End If

                    If .Visible Then
                        ' Lock Header fields
                        Matricule_.Enabled = False
                        Dat_Accident_txt.ReadOnly = True
                        Heure_Accident.Enabled = False
                        Lieu_Accident_txt.ReadOnly = True
                        Circonstances_txt.ReadOnly = True
                        Nature_Lesion_cbo.Enabled = False
                        Siege_Lesion_cbo.Enabled = False
                        Temoins_txt.ReadOnly = True
                        Tiers_Responsable_txt.ReadOnly = True
                        Num_Assurance_txt.ReadOnly = True

                        Valide_D.Enabled = False
                        Del_D.Enabled = False ' Cannot delete validated declaration
                    Else
                        ' Unlock Header fields
                        Matricule_.Enabled = True
                        Dat_Accident_txt.ReadOnly = False
                        Heure_Accident.Enabled = True
                        Lieu_Accident_txt.ReadOnly = False
                        Circonstances_txt.ReadOnly = False
                        Nature_Lesion_cbo.Enabled = True
                        Siege_Lesion_cbo.Enabled = True
                        Temoins_txt.ReadOnly = False
                        Tiers_Responsable_txt.ReadOnly = False
                        Num_Assurance_txt.ReadOnly = False

                        Valide_D.Enabled = True
                        Del_D.Enabled = True
                    End If
                End With
            Else
                ' New
                If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
                Matricule_.Enabled = True
            End If

            ' Load Details
            Dim TblCert = DATA_READER_GRD("select Typ_Certificat, Dat_Certificat, Dat_Debut_Arret, Dat_Fin_Arret, Nbr_Jours, Valide, Commentaire as Comment, RowId " &
                                          "from RH_Declaration_AT_Detail " &
                                          "where Num_Declaration='" & Num_Declaration_txt.Text & "' and id_Societe=" & Societe.id_Societe)
            With TblCert
                Grd_Certificats.Rows.Clear()
                If Grd_Certificats.Columns.Count > 0 Then
                    For i = 0 To .Rows.Count - 1
                        Grd_Certificats.Rows.Add(.Rows(i)("Typ_Certificat"), .Rows(i)("Dat_Certificat"), .Rows(i)("Dat_Debut_Arret"), .Rows(i)("Dat_Fin_Arret"), .Rows(i)("Nbr_Jours"), .Rows(i)("Valide"), .Rows(i)("Comment"))
                        Grd_Certificats.Rows(i).Tag = .Rows(i)("RowId")

                        Dim isValide As Boolean = IsNull(.Rows(i)("Valide"), False)
                        Grd_Certificats.Item(Valide.Index, i).Value = If(isValide, valideStr, "--")
                        Grd_Certificats.Item(Valide.Index, i).Tag = isValide
                        If isValide Then
                            Grd_Certificats.Rows(i).ReadOnly = True
                            Grd_Certificats.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                        End If

                        Dim typeCert As String = IsNull(.Rows(i)("Typ_Certificat"), "")
                        Dim isAbsenceType As Boolean = (typeCert = "INITIAL" Or typeCert = "PROLONGATION" Or typeCert = "RECHUTE")
                        If Not isAbsenceType Then
                            Grd_Certificats.Rows(i).Cells(Dat_Debut_Arret.Index).Style.BackColor = Color.LightGray
                            Grd_Certificats.Rows(i).Cells(Dat_Fin_Arret.Index).Style.BackColor = Color.LightGray
                            Grd_Certificats.Rows(i).Cells(Nbr_Jours.Index).Style.BackColor = Color.LightGray

                            Grd_Certificats.Rows(i).Cells(Dat_Debut_Arret.Index).ReadOnly = True
                            Grd_Certificats.Rows(i).Cells(Dat_Fin_Arret.Index).ReadOnly = True
                            Grd_Certificats.Rows(i).Cells(Nbr_Jours.Index).ReadOnly = True
                        End If
                    Next
                End If

                ' Constraints for Adding Rows
                Dim canAdd As Boolean = False
                Dim statutDoc As String = ""
                Dim isCloture As Boolean = False

                If Tbl.Rows.Count > 0 Then
                    statutDoc = IsNull(Tbl.Rows(0)("Statut"), "")
                    isCloture = IsNull(Tbl.Rows(0)("Cloture"), False)
                End If
                Dim rowCount As Integer = Grd_Certificats.RowCount
                Dim lastRow As DataGridViewRow = Nothing
                If rowCount > 1 Then lastRow = Grd_Certificats.Rows(rowCount - 2) ' -1 is NewRow, -2 is last data row ?? DataGridView includes NewRow in RowCount

                ' Actually simpler: Loop again to find last real row
                Dim lastValide As Boolean = True ' Start true for empty
                If rowCount > 1 Then
                    lastValide = IsNull(Grd_Certificats.Rows(rowCount - 2).Cells(Valide.Index).Tag, False)
                End If

                If isCloture Then
                    canAdd = False
                ElseIf rowCount <= 1 Then ' Only NewRow exists
                    canAdd = True ' Can always add Initial
                Else
                    ' Existing rows
                    If (statutDoc = "VA" Or statutDoc = "SG") And lastValide Then
                        canAdd = True
                    Else
                        canAdd = False
                    End If
                End If

                Grd_Certificats.AllowUserToAddRows = canAdd

                If statutDoc <> "VA" And statutDoc <> "SG" Then
                    Grd_Certificats.Columns(Valide.Index).Visible = False
                Else
                    Grd_Certificats.Columns(Valide.Index).Visible = True
                End If
            End With

            Save_D.Enabled = canModify
        End With
    End Sub

    Sub UpdateRowState()
        ' Recalculate canAdd without reloading everything
        Dim canAdd As Boolean = False
        Dim isCloture As Boolean = False

        ' We need to read from grid directly or cached values because Tbl might be out of scope or stale if we don't reload.
        ' But Statut_AT.Text is available.

        ' Cloture: can we check pb_Valide image? or tag?
        If pb_Valide.Image Is My.Resources.stamp_cloture Then isCloture = True

        Dim rowCount As Integer = Grd_Certificats.RowCount
        Dim lastValide As Boolean = True
        If rowCount > 1 Then
            lastValide = IsNull(Grd_Certificats.Rows(rowCount - 2).Cells(Valide.Index).Tag, False)
        End If

        If isCloture Then
            canAdd = False
        ElseIf rowCount <= 1 Then
            canAdd = True
        Else
            If (statutDoc = "VA" Or statutDoc = "SG") And lastValide Then
                canAdd = True
            Else
                canAdd = False
            End If
        End If

        Grd_Certificats.AllowUserToAddRows = canAdd
    End Sub

    Private Sub Grd_Certificats_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Certificats.CellContentClick
        Grd_Certificats.EndEdit()
        If e.RowIndex < 0 Or e.ColumnIndex <> Valide.Index Then Return
        If Grd_Certificats.Rows(e.RowIndex).IsNewRow Then Return

        ' Check if already validated
        If IsNull(Grd_Certificats.Rows(e.RowIndex).Cells(Valide.Index).Tag, False) Then Return

        ' Validate
        ValiderLigne(e.RowIndex)
    End Sub

    Sub ValiderLigne(i As Integer)
        ' Check if previous is validated
        If i > 0 Then
            Dim prevValide As Boolean = IsNull(Grd_Certificats.Item(Valide.Index, i - 1).Tag, False)
            If Not prevValide Then
                ShowMessageBox("Impossible de valider cette ligne car la précédente n'est pas validée.", "Erreur", MessageBoxButtons.OK, msgIcon.Stop)
                Return
            End If
        End If

        ' Confirm
        If ShowMessageBox("Voulez-vous valider ce certificat ? Impossible de modifier après.", "Validation", MessageBoxButtons.YesNo, msgIcon.Question) = DialogResult.Yes Then
            Dim rsl As savingResult = Saving("")
            If IsNull(rsl.message, "") <> "" Then ShowMessageBox(rsl.message, "Validation de la ligne", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))

            Dim rid = IsNull(Grd_Certificats.Rows(i).Tag, "")
            If rid <> "" Then
                CnExecuting("Update RH_Declaration_AT_Detail set Valide=1 where RowId=" & rid)
                Grd_Certificats.Item(Valide.Index, i).Value = valideStr
                Grd_Certificats.Item(Valide.Index, i).Tag = True
                Grd_Certificats.Rows(i).ReadOnly = True
                Grd_Certificats.Rows(i).DefaultCellStyle.BackColor = Color.LightGray

                ' Check Cloture
                Dim typ As String = IsNull(Grd_Certificats.Item(Typ_Certificat.Index, i).Value, "")
                If typ = "GUERISON" Or typ = "DECES" Then
                    CnExecuting("Update RH_Declaration_AT set Cloture='true' where Num_Declaration='" & Num_Declaration_txt.Text & "' and id_Societe=" & Societe.id_Societe)
                    pb_Valide.Image = My.Resources.stamp_cloture
                    pb_Valide.Visible = True

                    If typ = "DECES" Then
                        CnExecuting("Update RH_Agent set Droit_Paie='False' where Matricule='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe)
                    End If
                ElseIf typ = "RECHUTE" Then
                    CnExecuting("Update RH_Declaration_AT set Cloture='false' where Num_Declaration='" & Num_Declaration_txt.Text & "' and id_Societe=" & Societe.id_Societe)
                    pb_Valide.Visible = False
                End If
                UpdateRowState() ' Update add constraint locally to avoid crash
            End If
        End If
    End Sub
    Sub requestMatricule()
        Dim SqlStr As String = "Select * from RH_Agent where Matricule='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe
        Dim CltTbl As DataTable = DATA_READER_GRD(SqlStr)
        If CltTbl.Rows.Count > 0 Then
            Nom_Agent_Text.Text = IsNull(CltTbl.Rows(0)("Nom_Agent"), "") & " " & IsNull(CltTbl.Rows(0)("Prenom_Agent"), "")
            Num_Assurance_txt.Text = IsNull(CltTbl.Rows(0)("Organisme"), "")
        Else
            Nom_Agent_Text.Text = ""
            Num_Assurance_txt.Text = ""
        End If
    End Sub

    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        requestMatricule()
    End Sub

    Function Valider()
        If ShowMessageBox("Etes-vous sûr de vouloir valider cette déclaration ? Elle ne sera plus modifiable.", "Validation", MessageBoxButtons.OKCancel, msgIcon.Question) = DialogResult.Cancel Then Return False
        Dim rs = Saving("VA")
        If rs.result Then
            Request()
        End If
        Return rs.result
    End Function

    Sub Enregistrer()
        Dim rsl As savingResult = Saving("")
        If IsNull(rsl.message, "") <> "" Then ShowMessageBox(rsl.message, "Enregistrer", MessageBoxButtons.OK, IIf(rsl.result, msgIcon.Information, msgIcon.Stop))
    End Sub

    Function Saving(statut As String) As savingResult
        If Matricule_txt.Text = "" Then
            Return New savingResult With {.result = False, .message = "Matricule non renseigné"}
        End If

        If Num_Declaration_txt.Text = "" Then
            Dim checkSql As String = "select count(*) from RH_Declaration_AT where Matricule='" & Matricule_txt.Text & "' and id_Societe=" & Societe.id_Societe & " and (Cloture is null or Cloture=0)"
            Dim dtCheck As DataTable = DATA_READER_GRD(checkSql)
            If dtCheck.Rows.Count > 0 AndAlso CInt(dtCheck.Rows(0)(0)) > 0 Then
                Return New savingResult With {.result = False, .message = "Cet agent a déjà une déclaration d'accident en cours. Impossible d'en créer une nouvelle tant que la précédente n'est pas clôturée (Guérison/Décès)."}
            End If
        End If

        Grd_Certificats.EndEdit()

        ' Hierarchy Validation
        Dim hasInitial As Boolean = False
        Dim hasTerminus As Boolean = False
        Dim lastEndDate As Date = Date.MinValue

        For i = 0 To Grd_Certificats.RowCount - 1
            If Grd_Certificats.Rows(i).IsNewRow Then Continue For

            Dim typeCert As String = IsNull(Grd_Certificats.Item(Typ_Certificat.Index, i).Value, "")
            ' Safe Date Reading
            Dim obD = Grd_Certificats.Item(Dat_Debut_Arret.Index, i).Value
            Dim dateDebut As Date = Date.MinValue
            If IsDate(obD) Then dateDebut = CDate(obD)

            Dim obF = Grd_Certificats.Item(Dat_Fin_Arret.Index, i).Value
            Dim dateFin As Date = Date.MinValue
            If IsDate(obF) Then dateFin = CDate(obF)

            Dim isValidated As Boolean = (IsNull(Grd_Certificats.Item(Valide.Index, i).Value, "") = valideStr)

            ' Check Previous Validation
            If i > 0 Then
                Dim prevValide As Boolean = (IsNull(Grd_Certificats.Item(Valide.Index, i - 1).Value, "") = valideStr)
                If Not prevValide Then
                    Return New savingResult With {.result = False, .message = "Ligne " & (i + 1) & " : Le certificat précédent (Ligne " & i & ") doit être validé avant d'ajouter le suivant."}
                End If
            End If

            ' Check if closed
            If hasTerminus Then
                ' Exception: Allow RECHUTE after Guerison/Deces (Re-opening the case)
                If typeCert <> "RECHUTE" Then
                    Return New savingResult With {.result = False, .message = "Impossible d'ajouter des certificats après une GUERISON ou un DECES, sauf en cas de RECHUTE."}
                End If
                ' If it is RECHUTE, we reset terminus to allow future prolongations
                hasTerminus = False
            End If

            If typeCert = "INITIAL" Then
                If i > 0 Then Return New savingResult With {.result = False, .message = "Le certificat INITIAL doit être le premier."}
                hasInitial = True
            ElseIf typeCert = "PROLONGATION" Then
                If Not hasInitial Then Return New savingResult With {.result = False, .message = "Impossible d'ajouter une PROLONGATION sans certificat INITIAL."}
            ElseIf typeCert = "RECHUTE" Then
                If Not hasInitial Then Return New savingResult With {.result = False, .message = "Impossible d'ajouter une RECHUTE sans certificat INITIAL."}
                ' RECHUTE behaves like an absence period start, but linked to initial
            ElseIf typeCert = "GUERISON" Then
                If Not hasInitial Then Return New savingResult With {.result = False, .message = "Impossible d'ajouter une GUERISON sans certificat INITIAL."}
                hasTerminus = True
            ElseIf typeCert = "DECES" Then
                If Not hasInitial Then Return New savingResult With {.result = False, .message = "Impossible d'ajouter un DECES sans certificat INITIAL."}
                hasTerminus = True
            End If

            Dim isAbsenceType As Boolean = (typeCert = "INITIAL" Or typeCert = "PROLONGATION" Or typeCert = "RECHUTE")

            If isAbsenceType Then
                Dim dateCert As Date = CDate(IsNull(Grd_Certificats.Item(Dat_Certificat.Index, i).Value, Date.MinValue))
                If dateCert = Date.MinValue Then
                    Return New savingResult With {.result = False, .message = "Ligne " & (i + 1) & " : La date du certificat est obligatoire."}
                End If

                ' Date check
                If dateDebut > dateFin Then
                    Return New savingResult With {.result = False, .message = "Ligne " & (i + 1) & " : La date de début d'arrêt ne peut pas être postérieure à la date de fin."}
                End If

                If i > 0 AndAlso dateDebut <= lastEndDate Then
                    Return New savingResult With {.result = False, .message = "Ligne " & (i + 1) & " : La date de début chevauche ou est égale à la fin du précédent (Fin: " & lastEndDate.ToShortDateString & ")."}
                End If
                ' Validate Nbr_Jours
                Dim calcDays As Integer = DateDiff(DateInterval.Day, dateDebut, dateFin) + 1
                Dim inputDays As Integer = IsNull(Grd_Certificats.Item(Nbr_Jours.Index, i).Value, 0)

                If inputDays <= 0 Then
                    Return New savingResult With {.result = False, .message = "Ligne " & (i + 1) & " : Le nombre de jours doit être supérieur à 0."}
                End If
                If inputDays > calcDays Then
                    Return New savingResult With {.result = False, .message = "Ligne " & (i + 1) & " : Le nombre de jours (" & inputDays & ") ne peut pas être supérieur à la durée calculée (" & calcDays & " jours)."}
                End If
                lastEndDate = dateFin
            End If
        Next
        Dim numDecl As String = Num_Declaration_txt.Text
        If numDecl = "" Then
            ' Generate Num
            Dim Cp As New ADODB.Recordset
            Dim SqlStr As String = "select isnull(max(racine),0) as racine from (select convert(int,case when isnumeric(ISNULL(racine,''))!=1 then 0 else racine end ) as Racine from RH_Declaration_AT " &
                                    "outer apply(select charindex('_',Num_Declaration,1)-1 aa)a " &
                                    "outer apply(select case when aa<0 then RIGHT(Num_Declaration,6) else RIGHT(left(Num_Declaration,aa),6) end as racine)n " &
                                    "where id_Societe=" & Societe.id_Societe & " and year(Dat_Accident)=" & CDate(Dat_Accident_txt.Text).Year & ")f"
            Cp = CnExecuting(SqlStr)
            numDecl = "AT" & Societe.id_Societe & "-" & CDate(Dat_Accident_txt.Text).Year & Droite("000000" & CInt(Cp.Fields(0).Value + 1), 6)
        End If

        Dim oDat As Date = Now
        Dim rs As New ADODB.Recordset
        ' Update Master ONLY if not validated or being created
        ' BUT if we are validating (status arg = 'VA'), we must allow update to set Status
        If (statut <> "VA" And statut <> "SG") And Num_Declaration_txt.Text <> "" Then
            ' Prevent modifying master if already VA/SG
        Else
            rs.Open("select * from RH_Declaration_AT where Num_Declaration='" & numDecl & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("Num_Declaration").Value = numDecl
                rs("id_Societe").Value = Societe.id_Societe
                rs("Matricule").Value = Matricule_txt.Text
                rs("Dat_Crea").Value = oDat
                rs("Created_By").Value = theUser.Login
            End If

            rs("Dat_Accident").Value = Dat_Accident_txt.Text
            rs("Heure_Accident").Value = Heure_Accident.Value.ToString("HH:mm")
            rs("Lieu_Accident").Value = Lieu_Accident_txt.Text
            rs("Circonstances").Value = Circonstances_txt.Text
            rs("Nature_Lesion").Value = Nature_Lesion_cbo.SelectedValue
            rs("Siege_Lesion").Value = Siege_Lesion_cbo.SelectedValue
            rs("Temoins").Value = Temoins_txt.Text
            rs("Tiers_Responsable").Value = Tiers_Responsable_txt.Text
            rs("Num_Assurance").Value = Num_Assurance_txt.Text
            rs("Commentaire").Value = Commentaire_txt.Text

            If statut <> "" Then
                rs("Statut").Value = statut
                rs("Cloture").Value = IIf((statut = "VA" Or statut = "SG") And hasTerminus, True, False)
            End If

            rs("Dat_Modif").Value = oDat
            rs("Modified_By").Value = theUser.Login
            rs.Update()
            rs.Close()
        End If
        ' Save Details - always allowed
        With Grd_Certificats
            Dim swhere = ""
            For i = 0 To .RowCount - 1
                If .Rows(i).IsNewRow Then Continue For
                If Not IsNull(.Rows(i).Tag, "") = "" Then
                    swhere &= IIf(swhere = "", "", ",") & .Rows(i).Tag
                End If
            Next
            If Not swhere.Trim = "" Then
                ' Prevent deleting Validated rows
                Dim validCheck = DATA_READER_GRD("Select count(*) from RH_Declaration_AT_Detail where Num_Declaration='" & numDecl & "' and id_Societe='" & Societe.id_Societe & "' and RowId not in (" & swhere & ") and Valide=1")
                If CInt(validCheck.Rows(0)(0)) > 0 Then
                    Return New savingResult With {.result = False, .message = "Impossible de supprimer des certificats déjà validés."}
                End If
                CnExecuting("delete from RH_Declaration_AT_Detail where Num_Declaration='" & numDecl & "' and id_Societe='" & Societe.id_Societe & "' and RowId not in (" & swhere & ")")
            End If
            For i = 0 To .RowCount - 1
                If .Rows(i).IsNewRow Then Continue For
                If IsNull(.Item(Typ_Certificat.Index, i).Value, "") <> "" Then
                    ' Skip saving if row is ReadOnly (meaning it was already there and we are in VA mode)
                    If .Rows(i).ReadOnly Then Continue For

                    Try
                        Dim tagId As String = IsNull(.Rows(i).Tag, "")
                        Dim sqlDetail As String
                        If tagId = "" Then
                            sqlDetail = "select * from RH_Declaration_AT_Detail where 1=0"
                        Else
                            sqlDetail = "select * from RH_Declaration_AT_Detail where Num_Declaration='" & numDecl & "' and id_Societe='" & Societe.id_Societe & "' and RowId =" & tagId
                        End If

                        rs.Open(sqlDetail, cn, 2, 2)
                        If rs.EOF Then
                            rs.AddNew()
                            rs("Num_Declaration").Value = numDecl
                            rs("id_Societe").Value = Societe.id_Societe
                        End If
                        Dim typeCert As String = IsNull(.Item(Typ_Certificat.Index, i).Value, "")
                        Dim isAbsenceType As Boolean = (typeCert = "INITIAL" Or typeCert = "PROLONGATION" Or typeCert = "RECHUTE")

                        rs("Typ_Certificat").Value = typeCert

                        If isAbsenceType Then
                            rs("Dat_Certificat").Value = .Item(Dat_Certificat.Index, i).Value
                            rs("Dat_Debut_Arret").Value = .Item(Dat_Debut_Arret.Index, i).Value
                            rs("Dat_Fin_Arret").Value = .Item(Dat_Fin_Arret.Index, i).Value
                            rs("Nbr_Jours").Value = IsNull(.Item(Nbr_Jours.Index, i).Value, 0)
                        Else
                            rs("Dat_Certificat").Value = .Item(Dat_Certificat.Index, i).Value
                            rs("Dat_Debut_Arret").Value = DBNull.Value
                            rs("Dat_Fin_Arret").Value = DBNull.Value
                            rs("Nbr_Jours").Value = 0
                        End If

                        rs("Commentaire").Value = IsNull(.Item(Comment.Index, i).Value, "")
                        rs("Valide").Value = ((statut = "VA" Or statut = "SG") And (IsNull(.Item(Typ_Certificat.Index, i).Value, "") = "INITIAL"))
                        rs.Update()
                        rs.Close()
                    Catch ex As Exception
                        ShowMessageBox("Erreur lors de l'enregistrement de la ligne " & (i + 1) & " : " & ex.Message, "Erreur", MessageBoxButtons.OK, msgIcon.Error)
                    End Try
                End If
            Next
        End With
        If Num_Declaration_txt.Text <> "" Then
            Request()
        Else
            Num_Declaration_txt.Text = numDecl
        End If
        Return New savingResult With {.result = True, .message = "Enregistré avec succès"}
    End Function

    Sub Deleting()
        If statutDoc = "VA" Or statutDoc = "CL" Then
            ShowMessageBox("Impossible de supprimer une déclaration validée ou clôturée.", "Stop", MessageBoxButtons.OK, msgIcon.Stop)
            Return
        End If
        If ShowMessageBox("Etes-vous sûr de vouloir supprimer cette déclaration ?", "Suppression", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from RH_Declaration_AT where Num_Declaration='" & Num_Declaration_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        Reset_Form(Me)
        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
    End Sub

    Sub Nouveau()
        Reset_Form(Me)
        Request()
        If Matricule_txt.Text = "" Then Matricule_txt.Text = theUser.Matricule
        Dat_Accident_txt.Text = Now.ToShortDateString

        ' Unlock everything
        Matricule_.Enabled = True
        Heure_Accident.Enabled = True
        Lieu_Accident_txt.ReadOnly = False
        Circonstances_txt.ReadOnly = False
        Nature_Lesion_cbo.Enabled = True
        Siege_Lesion_cbo.Enabled = True
        Temoins_txt.ReadOnly = False
        Tiers_Responsable_txt.ReadOnly = False
        Num_Assurance_txt.ReadOnly = False
        Valide_D.Enabled = True
        Del_D.Enabled = True
        Grd_Certificats.ReadOnly = False
    End Sub

    Private Sub Dat_Accident_Link_Click(sender As Object, e As EventArgs)
        If Dat_Accident_txt.ReadOnly Then Return
        Appel_Calender(Dat_Accident_txt, Me)
    End Sub

    Private Sub Grd_Certificats_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Certificats.CellValidated
        If e.RowIndex < 0 Then Return

        If e.ColumnIndex = Dat_Debut_Arret.Index Or e.ColumnIndex = Dat_Fin_Arret.Index Then
            Dim dateDebut As Object = Grd_Certificats.Rows(e.RowIndex).Cells(Dat_Debut_Arret.Index).Value
            Dim dateFin As Object = Grd_Certificats.Rows(e.RowIndex).Cells(Dat_Fin_Arret.Index).Value

            If Not IsDBNull(dateDebut) AndAlso Not IsDBNull(dateFin) AndAlso IsDate(dateDebut) AndAlso IsDate(dateFin) Then
                Dim d1 As Date = CDate(dateDebut)
                Dim d2 As Date = CDate(dateFin)
                If d2 >= d1 Then
                    Dim days As Integer = DateDiff(DateInterval.Day, d1, d2) + 1
                    Grd_Certificats.Rows(e.RowIndex).Cells(Nbr_Jours.Index).Value = days
                End If
            End If
        End If
    End Sub

    Private Sub Grd_Certificats_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Grd_Certificats.CellValueChanged
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex = Typ_Certificat.Index Then
            Dim typeCert As String = IsNull(Grd_Certificats.Rows(e.RowIndex).Cells(Typ_Certificat.Index).Value, "")
            Dim isAbsenceType As Boolean = (typeCert = "INITIAL" Or typeCert = "PROLONGATION" Or typeCert = "RECHUTE")

            With Grd_Certificats.Rows(e.RowIndex)
                .Cells(Dat_Debut_Arret.Index).ReadOnly = Not isAbsenceType
                .Cells(Dat_Fin_Arret.Index).ReadOnly = Not isAbsenceType
                .Cells(Nbr_Jours.Index).ReadOnly = Not isAbsenceType

                If Not isAbsenceType Then
                    .Cells(Dat_Debut_Arret.Index).Style.BackColor = Color.LightGray
                    .Cells(Dat_Fin_Arret.Index).Style.BackColor = Color.LightGray
                    .Cells(Nbr_Jours.Index).Style.BackColor = Color.LightGray
                    .Cells(Dat_Debut_Arret.Index).Value = DBNull.Value
                    .Cells(Dat_Fin_Arret.Index).Value = DBNull.Value
                    .Cells(Nbr_Jours.Index).Value = 0
                Else
                    .Cells(Dat_Debut_Arret.Index).Style.BackColor = Color.White
                    .Cells(Dat_Fin_Arret.Index).Style.BackColor = Color.White
                    .Cells(Nbr_Jours.Index).Style.BackColor = Color.White
                End If
            End With
        End If
    End Sub

    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If Num_Declaration_txt.Text <> "" Then
            If Not ShowMessageBox("Modification impossible.", "Info", MessageBoxButtons.OK) = DialogResult.OK Then Return
            Return
        End If
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS018", Matricule_txt, Me, String.Format(filtreUser, {"RH_Agent"}))
            End If
        Else
            Appel_Zoom1("MS018", Matricule_txt, Me)
        End If
    End Sub
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If theUser.Typ_Role = "Agent" Then
            If theUser.TeamLeader Then
                Appel_Zoom1("MS035", Num_Declaration_txt, Me, " Matricule = '" & Matricule_txt.Text & "'")
            End If
        Else
            Appel_Zoom1("MS035", Num_Declaration_txt, Me)
        End If

    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Appel_Calender(Dat_Accident_txt, Me)
    End Sub

    Private Sub Num_Declaration_txt_TextChanged(sender As Object, e As EventArgs) Handles Num_Declaration_txt.TextChanged
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
        DroitAcces(Me, DroitModify_Fiche(Num_Declaration_txt.Text, Me))
        Request()
        If Save_D.Enabled = True Then
            Check_Accessible(Me.Name, Num_Declaration_txt.Text)
            Code = Num_Declaration_txt.Text
        End If
    End Sub
    Private Sub RH_Demande_Conge_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CnExecuting("delete from Controle_Access where Name_Ecran='" & Me.Name & "' and value='" & Code & "' and Process_Id= " & ProcessId)
    End Sub
#Region "Signature"
    Function SoumettreEnSignature() As savingResult
        Return Saving("SG")
    End Function
    Function requestAfterSignature() As Boolean
        Request()
        Return True
    End Function
#End Region
End Class
