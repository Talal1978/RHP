Imports System.ComponentModel
Imports System.Net
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json

Module Module_FonctionRubrique
    Dim WithEvents Bgk1, Bgk2 As New System.ComponentModel.BackgroundWorker
    Dim CodRubrique As String = ""
    Public fsRows As New List(Of rhp_functions_system)
    Public rbRows As New List(Of rhp_rubriques_system)
    Public epRows As New List(Of rhp_elements_paie)
    Public Class rhp_elements_paie
        Public Property Cod_Function As String
        Public Property Typ_Function As String
        Public Property Lib_Function As String
        Public Property Lib_Abr As String
        Public Property Abr_Function As String
        Public Property Groupe_Function As String
        Public Property Formule_Function As String
        Public Property Regex As String
        Public Property Typ_Retour As String
        Public Property Nb_Decimal As Integer
        Public Property Est_Pourcentage As Boolean
        Public Property estSysteme As Boolean
        Public Property lastVersion As Integer
    End Class
    Public Class rhp_functions_system
        Public Property Cod_Function As String
        Public Property Typ_Function As String
        Public Property Lib_Function As String
        Public Property Lib_Abr As String
        Public Property Abr_Function As String
        Public Property Source As String
        Public Property Groupe_Function As String
        Public Property Formule_Function As String
        Public Property Regex As String
        Public Property Rang As Integer
        Public Property Typ_Retour As String
        Public Property Nb_Decimal As Integer
        Public Property Est_Pourcentage As Boolean
        Public Property lastVersion As Integer

    End Class
    Public Class rhp_rubriques_system
        Public Property Cod_Rubrique As String
        Public Property Lib_Rubrique As String
        Public Property Abr_Rubrique As String
        Public Property EV As Boolean
        Public Property EC As Boolean
        Public Property EB As Boolean
        Public Property CS As Boolean
        Public Property Cumulable As Boolean
        Public Property Ventilable As Boolean
        Public Property Nb As String
        Public Property Base As String
        Public Property Tx As String
        Public Property Relation As String
        Public Property Relation_VBS As String
        Public Property Typ_Retour As String
        Public Property Nb_Decimal As Integer
        Public Property Est_Pourcentage As Boolean
        Public Property Gain_Retenue As String
        Public Property lastVersion As Integer
        Public Property Salarial As Boolean
        Public Property Patronal As Boolean
        Public Property Val_Defaut As String
        Public Property Typ_Rubrique_Paie As String
        Public Property Nature_Element_Exonere As String
        Public Property Imposable_IR As Boolean
        Public Property Imposable_CNSS As Boolean
        Public Property Deductible_IR As Boolean
        Public Property Deductible_CNSS As Boolean
        Public Property Rubrique_Globale As Boolean
        Public Property Commentaire As String
        Public Property estOptionnel As Boolean

    End Class
    Sub check_rhp_functions_system()
        If Not Bgk1.IsBusy Then
            Bgk1.RunWorkerAsync()
        End If
    End Sub
    Dim allOk As Boolean = False
    Sub bgk1run() Handles Bgk1.DoWork
        If Not estConnecte(UriStr0 & "/index.html") Then
            allOk = False
            Return
        End If
        Try
            Dim TblFuctionSys As DataTable = DATA_READER_GRD("select Cod_Function,isnull(lastVersion,-1) as lastVersion  from RH_Param_Functions_Sys")
            Dim TblRubriqueSys As DataTable = DATA_READER_GRD("select Cod_Rubrique,isnull(lastVersion,-1) as lastVersion, isnull(Proteger,'false') as Proteger from RH_Paie_Rubrique where ISNULL(estSysteme,'false')='true'")
            Dim TblRubriqueOptionnal As DataTable = DATA_READER_GRD("select Cod_Rubrique,isnull(lastVersion,-1) as lastVersion from RH_Paie_Rubrique_Predefinie")
            Dim TblElementsPaieSys As DataTable = DATA_READER_GRD("select Cod_Function,isnull(lastVersion,-1) as lastVersion from RH_Elements_Paie e
where ISNULL(estSysteme,0)=1
and not exists(select Cod_Function from RH_Param_Functions_Sys where Cod_Function=e.Cod_Function)
and Not exists (select Cod_Rubrique from RH_Paie_Rubrique where Cod_Rubrique=e.Cod_Function)
and Typ_Function !='RC'")
            fsRows.Clear()
            rbRows.Clear()
            epRows.Clear()
            Dim url As String = UriStr0 & "/rhp_functions_system.php"
            Dim client As New WebClient()
            Dim response As String = client.DownloadString(url).Trim()

            ' Deserialize the JSON response into a list of objects
            fsRows = JsonConvert.DeserializeObject(Of List(Of rhp_functions_system))(response)
            For i = fsRows.Count - 1 To 0 Step -1
                If TblFuctionSys.Select("Cod_Function='" & fsRows(i).Cod_Function & "' and isnull(lastVersion,-1)=" & fsRows(i).lastVersion).Length > 0 Then
                    fsRows.RemoveAt(i)
                End If
            Next
            url = UriStr0 & "/rhp_rubriques_system.php"
            response = client.DownloadString(url)
            ' Deserialize the JSON response into a list of objects
            rbRows = JsonConvert.DeserializeObject(Of List(Of rhp_rubriques_system))(response)
            Dim rs As New ADODB.Recordset
            For i = rbRows.Count - 1 To 0 Step -1
                If rbRows(i).estOptionnel Then
                    If TblRubriqueOptionnal.Select("Cod_Rubrique='" & rbRows(i).Cod_Rubrique & "' and isnull(lastVersion,-1)=" & rbRows(i).lastVersion).Length = 0 Then
                        rs.Open("select *  from RH_Paie_Rubrique_Predefinie where Cod_Rubrique='" & rbRows(i).Cod_Rubrique & "'", cn, 2, 2)
                        If rs.EOF Then
                            rs.AddNew()
                            rs("Cod_Rubrique").Value = rbRows(i).Cod_Rubrique
                        Else
                            rs.Update()
                        End If
                        rs("Lib_Rubrique").Value = rbRows(i).Lib_Rubrique
                        rs("Abr_Rubrique").Value = rbRows(i).Abr_Rubrique
                        rs("EV").Value = rbRows(i).EV
                        rs("EC").Value = rbRows(i).EC
                        rs("EB").Value = rbRows(i).EB
                        rs("CS").Value = rbRows(i).CS
                        rs("Cumulable").Value = rbRows(i).Cumulable
                        rs("Ventilable").Value = rbRows(i).Ventilable
                        rs("Nb").Value = rbRows(i).Nb
                        rs("Base").Value = rbRows(i).Base
                        rs("Tx").Value = rbRows(i).Tx
                        rs("Relation").Value = rbRows(i).Relation
                        rs("Relation_VBS").Value = rbRows(i).Relation_VBS
                        rs("Typ_Retour").Value = rbRows(i).Typ_Retour
                        rs("Nb_Decimal").Value = rbRows(i).Nb_Decimal
                        rs("Est_Pourcentage").Value = rbRows(i).Est_Pourcentage
                        rs("Gain_Retenue").Value = rbRows(i).Gain_Retenue
                        rs("lastVersion").Value = rbRows(i).lastVersion
                        rs("Salarial").Value = rbRows(i).Salarial
                        rs("Patronal").Value = rbRows(i).Patronal
                        rs("Val_Defaut").Value = rbRows(i).Val_Defaut
                        rs("Typ_Rubrique_Paie").Value = rbRows(i).Typ_Rubrique_Paie
                        rs("Nature_Element_Exonere").Value = rbRows(i).Nature_Element_Exonere
                        rs("Imposable_IR").Value = rbRows(i).Imposable_IR
                        rs("Imposable_CNSS").Value = rbRows(i).Imposable_CNSS
                        rs("Deductible_IR").Value = rbRows(i).Deductible_IR
                        rs("Deductible_CNSS").Value = rbRows(i).Deductible_CNSS
                        rs("Rubrique_Globale").Value = rbRows(i).Rubrique_Globale
                        rs("Commentaire").Value = rbRows(i).Commentaire
                        rs.Update()
                        rs.Close()
                    End If
                    rbRows.RemoveAt(i)
                Else
                    If TblRubriqueSys.Select("Cod_Rubrique='" & rbRows(i).Cod_Rubrique & "' and (isnull(lastVersion,-1)=" & rbRows(i).lastVersion & " or Proteger='true')").Length > 0 Then
                        rbRows.RemoveAt(i)
                    End If
                End If

            Next
            url = UriStr0 & "/rhp_elements_paie.php"
            response = client.DownloadString(url)
            ' Deserialize the JSON response into a list of objects
            epRows = JsonConvert.DeserializeObject(Of List(Of rhp_elements_paie))(response)
            For i = epRows.Count - 1 To 0 Step -1
                If TblElementsPaieSys.Select("Cod_Function='" & epRows(i).Cod_Function & "' and isnull(lastVersion,-1)=" & epRows(i).lastVersion).Length > 0 Then
                    epRows.RemoveAt(i)
                End If
            Next
            allOk = True
        Catch ex As Exception
            ShowMessageBox("Erreur de mise à jour des fonctions système." & vbCrLf & ex.Message, "Importation des fonctions système", MessageBoxButtons.OK, msgIcon.Error)
            allOk = False
        End Try

    End Sub
    Private Sub Bgk1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Bgk1.RunWorkerCompleted
        If (rbRows.Count > 0 Or fsRows.Count > 0 Or epRows.Count > 0) And allOk Then
            If ShowMessageBox("Certaines formules et fonctions système de la paie ont été mises à jour. Voulez-vous appliquer cette mise à jour", "Mise à jour des fonctions et rubriques système", MessageBoxButtons.OKCancel, msgIcon.Question, MessageBoxDefaultButton.Button3) = DialogResult.OK Then
                Dim f As New Zoom_FsRb
                f.ShowDialog()
            End If
        End If

    End Sub
    Function estMajAuto(codRubrique As String) As Boolean
        Dim str As String = "declare @s varchar(max), @rub nvarchar(50)
set @rub ='" & codRubrique & "'
select @s=isnull(@s+' or ','')+' isnull('+Rubrique+','''')='''+@rub+'''' 
from RH_Param_Plan_Paie_Rubriques where isnull(estMajAuto,'false')='true' and exists(select Column_Name from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='RH_Param_Plan_Paie' and COLUMN_NAME=Rubrique)
exec ('select count(*) from RH_Param_Plan_Paie where id_Societe=" & Societe.id_Societe & " and ('+@s+')')"
        Return CnExecuting(str).Fields(0).Value > 0
    End Function
    Function RubriqueUtilise(codRubrique As String, estGlobale As Boolean) As String
        '  Dim Tbl As DataTable = DATA_READER_GRD("select Cod_Rubrique from RH_Paie_Rubrique where (Cod_Rubrique='" & codRubrique & "' or Cod_Rubrique='Cumul_" & codRubrique & "') and (id_Societe=" & Societe.id_Societe & " or id_Societe=-1)")
        'If Tbl.Rows.Count = 0 Then
        '    Return ""
        'End If
        Dim Tbl As New DataTable
        If CnExecuting("Select count(*) from RH_Preparation_Paie_Detail where (Cod_Rubrique='" & codRubrique & "' or Cod_Rubrique='Cumul_" & codRubrique & "') " & IIf(estGlobale, "", " and id_Societe=" & Societe.id_Societe)).Fields(0).Value > 0 Then
            Return "Rubrique utilisée dans un calcul de paie précédent"
        End If
        Tbl = DATA_READER_GRD("Select Cod_Function, Formule_Function from RH_Param_Functions where isnull(Formule_Function,'') like '%" & codRubrique & "%' " & IIf(estGlobale, "", " and id_Societe=" & Societe.id_Societe))
        Dim rg As New Regex("\b(" & codRubrique & ")\b|\b(Cumul_" & codRubrique & ")\b")
        With Tbl
            For i = 0 To .Rows.Count - 1
                If rg.IsMatch(.Rows(i)("Formule_Function")) Then
                    Return "Rubrique utilisée dans la fonction de calcul de paie : " & .Rows(i)("Cod_Function")
                End If
            Next
        End With
        Tbl = DATA_READER_GRD("select Cod_Rubrique,Tx,Nb,Base, Relation, Relation_VBS from RH_Paie_Rubrique where isnull(estMajAuto,'false')='false' and isnull(EC,0)=1 " & IIf(estGlobale, "", " and id_Societe=" & Societe.id_Societe))
        rg = New Regex("\b(" & codRubrique & ")\b|\b(Cumul_" & codRubrique & ")\b")
        With Tbl
            For i = 0 To .Rows.Count - 1
                If rg.IsMatch(IsNull(.Rows(i)("Relation_VBS"), "")) Or rg.IsMatch(IsNull(.Rows(i)("Relation"), "")) Or rg.IsMatch(IsNull(.Rows(i)("Nb"), "")) Or rg.IsMatch(IsNull(.Rows(i)("Tx"), "")) Or rg.IsMatch(IsNull(.Rows(i)("Base"), "")) Then
                    Return "Rubrique utilisée dans une relation de calcul de la rubrique : " & .Rows(i)("Cod_Rubrique")
                End If
            Next
        End With
        Tbl = DATA_READER_GRD("select * from RH_Param_Plan_Paie p outer apply (select Den from Param_Societe where id_Societe=p.id_Societe)s where (';'+Element_Paie+';' like '%;" & codRubrique & ";%' or ';'+Element_Paie+';' like '%;Cumul_" & codRubrique & ";%') " & IIf(estGlobale, "", " and id_Societe=" & Societe.id_Societe))

        If Tbl.Rows.Count > 0 Then
            Return "Rubrique utilisée dans un plan de paie : " & Tbl.Rows(0)("Cod_Plan_Paie") & ", " & Tbl.Rows(0)("Lib_Plan_Paie") & ", Société: " & Tbl.Rows(0)("Den")
        End If
        Tbl = DATA_READER_GRD("select Cod_Plan_Paie,Lib_Plan_Paie,isnull(Element_Paie,'') as Element_Paie from RH_Param_Plan_Paie where isnull(Element_Paie,'')<>'' and id_Societe=" & Societe.id_Societe)
        Dim EP() As String
        With Tbl
            For i = 0 To .Rows.Count - 1
                EP = .Rows(i)("Element_Paie").ToString.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                If EP.Contains(codRubrique) Or EP.Contains("Cumul_" & codRubrique) Then
                    Return "Rubrique utilisée dans le plan de paie : " & .Rows(i)("Cod_Plan_Paie") & ", " & .Rows(i)("Lib_Plan_Paie")
                End If
            Next
        End With
        Return ""
    End Function
    Function getFunctionColor(typFunction As String) As Color
        Select Case typFunction
            Case "EV"
                Return Color.Gray
            Case "CS"
                Return Color.Red
            Case "FU"
                Return Color.Goldenrod
            Case "EB"
                Return Color.Brown
            Case "EC", "RC"
                Return Color.DeepPink
            Case "FS"
                Return Color.Blue
            Case "FP"
                Return Color.DarkTurquoise
            Case "EP"
                Return Color.GreenYellow
            Case "AB"
                Return Color.FromArgb(158, 74, 22)
            Case "AG"
                Return Color.FromArgb(22, 158, 151)
            Case Else
                Return Color.Black
        End Select
    End Function
    Function setTypRubriqueColor() As Dictionary(Of String, ArrayList)
        Dim dicColor As New Dictionary(Of String, ArrayList)
        Dim R0, G0, B0 As Integer
        R0 = 197
        G0 = 10
        B0 = 255
        dicColor.Add("C01", New ArrayList({Color.FromArgb(50, R0, G0, B0), Color.FromArgb(R0, G0, B0)}))
        R0 = 0
        G0 = 255
        B0 = 0
        dicColor.Add("C02", New ArrayList({Color.FromArgb(50, R0, G0, B0), Color.FromArgb(R0, G0, B0)}))
        R0 = 255
        G0 = 0
        B0 = 0
        dicColor.Add("C03", New ArrayList({Color.FromArgb(50, R0, G0, B0), Color.FromArgb(R0, G0, B0)}))
        R0 = 0
        G0 = 0
        B0 = 255
        dicColor.Add("C04", New ArrayList({Color.FromArgb(50, R0, G0, B0), Color.FromArgb(R0, G0, B0)}))
        R0 = 29
        G0 = 196
        B0 = 255
        dicColor.Add("C05", New ArrayList({Color.FromArgb(50, R0, G0, B0), Color.FromArgb(R0, G0, B0)}))
        R0 = 255
        G0 = 135
        B0 = 7
        dicColor.Add("C06", New ArrayList({Color.FromArgb(70, 220, 220, 220), Color.FromArgb(220, 220, 220)}))
        Return dicColor
    End Function
    Function setGroupFunctionColor() As Dictionary(Of String, ArrayList)
        Dim dicColor As New Dictionary(Of String, ArrayList)
        Dim R0, G0, B0 As Integer
        R0 = 245
        G0 = 27
        B0 = 65
        dicColor.Add("RB_Const", New ArrayList({Color.FromArgb(50, R0, G0, B0), Color.FromArgb(R0, G0, B0)}))
        R0 = 22
        G0 = 52
        B0 = 192
        dicColor.Add("RB_ElVar", New ArrayList({Color.FromArgb(50, R0, G0, B0), Color.FromArgb(R0, G0, B0)}))
        R0 = 75
        G0 = 224
        B0 = 83
        dicColor.Add("RB_ElBase", New ArrayList({Color.FromArgb(50, R0, G0, B0), Color.FromArgb(R0, G0, B0)}))
        R0 = 128
        G0 = 0
        B0 = 128
        dicColor.Add("RB_ElCal", New ArrayList({Color.FromArgb(50, R0, G0, B0), Color.FromArgb(R0, G0, B0)}))
        R0 = 255
        G0 = 143
        B0 = 32
        dicColor.Add("FU_FoncU", New ArrayList({Color.FromArgb(50, R0, G0, B0), Color.FromArgb(R0, G0, B0)}))
        R0 = 0
        G0 = 159
        B0 = 236
        dicColor.Add("AG_Agent", New ArrayList({Color.FromArgb(50, R0, G0, B0), Color.FromArgb(R0, G0, B0)}))
        R0 = 255
        G0 = 255
        B0 = 128
        dicColor.Add("FU_Cumul", New ArrayList({Color.FromArgb(50, R0, G0, B0), Color.FromArgb(R0, G0, B0)}))
        R0 = 255
        G0 = 128
        B0 = 64
        dicColor.Add("EP_ElPaie", New ArrayList({Color.FromArgb(50, R0, G0, B0), Color.FromArgb(R0, G0, B0)}))
        R0 = 62
        G0 = 245
        B0 = 255
        dicColor.Add("FS_Paie", New ArrayList({Color.FromArgb(50, R0, G0, B0), Color.FromArgb(R0, G0, B0)}))
        R0 = 96
        G0 = 122
        B0 = 199
        dicColor.Add("RB_EBCal", New ArrayList({Color.FromArgb(50, R0, G0, B0), Color.FromArgb(R0, G0, B0)}))
        Return dicColor
    End Function

End Module
