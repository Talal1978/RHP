Imports System.ComponentModel
Public Structure savingResult
    Public message As String
    Public result As Boolean
End Structure
Public Class CongeDemande
    Public Property Pid As Integer
    Sub New()
        Dim rnd As New Random
        Pid = rnd.Next(1000, 562655)
    End Sub
    Class entDemande
        Sub New(myParent As CongeDemande)
            parent = myParent
        End Sub
        Private _datdeb, _datfin As Date
        Private parent As CongeDemande
        Private _typConge As String = "CAD"

        Private _datDebampm, _datFinampm, _numConge, _matricule, _codplan As String
        Public Property Num_Conge As String
            Get
                Return _numConge
            End Get
            Set(value As String)
                If value <> _numConge Then
                    _numConge = value
                    parent.Request()
                End If
            End Set
        End Property
        Public Property Matricule As String
            Get
                Return _matricule
            End Get
            Set(value As String)
                If value <> _matricule Then
                    _matricule = value
                    parent.agt.Matricule = value
                End If
            End Set
        End Property
        Public Property Cod_Plan_Paie As String
            Get
                Return _codplan
            End Get
            Set(value As String)
                If value <> _codplan Then
                    _codplan = value
                    parent.ent.JourPaie = FindLibelle("JourPaie", "Cod_Plan_Paie", _codplan, "RH_Param_Plan_Paie")
                    parent.ent.LastDatePaie = FindLibelle("DatDernierePaie", "Cod_Plan_Paie", _codplan, "RH_Param_Plan_Paie")
                End If
            End Set
        End Property
        Public Property Dat_Deb_Conge As Date
            Get
                Return _datdeb
            End Get
            Set(value As Date)
                If value.ToShortDateString() <> _datdeb.ToShortDateString Then
                    _datdeb = value.ToShortDateString()
                    parent.agt.requestMatricule()
                    parent.Calcul()
                End If
            End Set
        End Property
        Public Property Dat_Deb_am_pm As String
            Get
                Return _datDebampm
            End Get
            Set(value As String)
                If value <> _datDebampm Then
                    _datDebampm = value
                    parent.Calcul()
                End If
            End Set
        End Property
        Public Property Dat_Fin_am_pm As String
            Get
                Return _datFinampm
            End Get
            Set(value As String)
                If value <> _datFinampm Then
                    _datFinampm = value
                    parent.Calcul()
                End If
            End Set
        End Property
        Public Property Dat_Fin_Conge As Date
            Get
                Return _datfin
            End Get
            Set(value As Date)
                If value.ToShortDateString() <> _datfin.ToShortDateString Then
                    _datfin = value.ToShortDateString()
                    parent.Calcul()
                End If
            End Set
        End Property
        Public Property Typ_Conge As String
            Get
                Return _typConge
            End Get
            Set(value As String)
                If value <> _typConge Then
                    Me.parent.Tbl_RH_Conge_Type = DATA_READER_GRD("select * from RH_Conge_Type where Typ_Conge='" & IsNull(value, "CAD") & "'")
                    _typConge = value
                    parent.Calcul()
                End If
            End Set
        End Property
        Public Property LastDatePaie As String
        Public Property Duree_Conge As Double
        Public Property Duree_Globale As Double
        Public Property Repos_Hebdomadaire As Double
        Public Property Jours_Feries As Double
        Public Property Commentaire As String
        Public Property JourPaie As String
        Public Property Statut As String
        Public Property Cod_Poste As String
        Public Property Cod_Grade As String
        Public Property Cod_Entite As String
        Public Property Titre As String
    End Class
    Class situationAgentConge
        Private _matricule As String = ""
        Protected parent As CongeDemande
        Sub New(myParent As CongeDemande)
            parent = myParent
        End Sub
        ' Define an event
        '   Public Event MatriculeChanged()
        Public Property Matricule As String
            Get
                Return _matricule
            End Get
            Set(value As String)
                If _matricule <> value Then
                    _matricule = value
                    parent.ent.Matricule = value
                    requestMatricule()
                End If

            End Set
        End Property
        Public Property Conge_Annuel As Double
        Public Property Acquis_Anciennete As Double
        Public Property Droit_Conge As Double
        Public Property Reliquat_Anterieurs As Double
        Public Property Conge_Pris As Double
        Public Property Solde_Conge As Double
        Public Property Cod_Poste As String
        Public Property Cod_Grade As String
        Public Property Cod_Entite As String
        Public Property Titre As String
        Public Property Cod_Plan_Paie As String
        Sub requestMatricule()
            Dim SqlStr As String = "select * from dbo.Sys_Rh_Conge(" & Societe.id_Societe & ",'" & parent.ent.Dat_Deb_Conge & "') where Matricule='" & Me.Matricule & "'   "
            Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
            With Tbl
                If .Rows.Count > 0 Then
                    Me.Conge_Annuel = IsNull(.Rows(0)("Conge_Annuel"), 0)
                    Me.Acquis_Anciennete = IsNull(.Rows(0)("Acquis_Anciennete"), 0)
                    Me.Droit_Conge = IsNull(.Rows(0)("Droit_Conge"), 0)
                    Me.Reliquat_Anterieurs = IsNull(.Rows(0)("Reliquat_Anterieurs"), 0)
                    Me.Conge_Pris = IsNull(.Rows(0)("Conge_Pris"), 0)
                    Me.Solde_Conge = IsNull(.Rows(0)("Solde_Conge"), 0)
                    Me.Cod_Poste = IsNull(.Rows(0)("Cod_Poste"), "")
                    Me.Cod_Grade = IsNull(.Rows(0)("Cod_Grade"), "")
                    Me.Cod_Entite = IsNull(.Rows(0)("Cod_Entite"), "")
                    Titre = IsNull(.Rows(0)("Titre"), "")
                    Cod_Plan_Paie = IsNull(.Rows(0)("Cod_Plan_Paie"), "")
                Else
                    Me.Conge_Annuel = 0
                    Me.Acquis_Anciennete = 0
                    Me.Droit_Conge = 0
                    Me.Reliquat_Anterieurs = 0
                    Me.Conge_Pris = 0
                    Me.Solde_Conge = 0
                    Me.Cod_Poste = ""
                    Me.Cod_Grade = ""
                    Me.Cod_Entite = ""
                    Me.Titre = ""
                    Me.Cod_Plan_Paie = ""
                End If
                parent.ent.Cod_Entite = Cod_Entite
                parent.ent.Cod_Poste = Cod_Poste
                parent.ent.Cod_Grade = Cod_Grade
                parent.ent.Cod_Plan_Paie = Cod_Plan_Paie
                parent.ent.Titre = Titre
            End With
        End Sub
    End Class
    Public Class ligDemande
        Public Property Dat_Deb As Date
        Public Property Dat_Fin As Date
        Public Property Duree_Globale As Double
        Public Property Repos_Hebdomadaire As Double
        Public Property Jours_Feries As Double
        Public Property Duree_Conge As Double
    End Class
    Friend ent As New entDemande(Me)
    Friend lig As New BindingList(Of ligDemande)
    Friend agt As New situationAgentConge(Me)
    Friend setCalcul As Boolean = True
    Friend Tbl_RH_Conge_Type As DataTable = DATA_READER_GRD("select * from RH_Conge_Type where Typ_Conge='" & IsNull(ent.Typ_Conge, "CAD") & "'")
    Function Request() As Boolean
        setCalcul = False
        Dim SqlStr As String = "SELECT * FROM RH_Conge_Suivi where  Num_Conge='" & ent.Num_Conge & "' and id_Societe=" & Societe.id_Societe
        Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
        lig.Clear()
        With Tbl
            If .Rows.Count > 0 Then

                ent.Matricule = IsNull(.Rows(0)("Matricule"), "")
                ent.Dat_Deb_Conge = IsNull(.Rows(0)("Dat_Deb_Conge"), Now.ToShortDateString)
                ent.Dat_Fin_Conge = IsNull(.Rows(0)("Dat_Fin_Conge"), Now.ToShortDateString)
                ent.Dat_Deb_am_pm = IsNull(.Rows(0)("Dat_Deb_Am_Pm"), "am")
                ent.Dat_Fin_am_pm = IsNull(.Rows(0)("Dat_Fin_Am_Pm"), "am")
                ent.Cod_Plan_Paie = IsNull(.Rows(0)("Cod_Plan_Paie"), "")
                ent.JourPaie = IsNull(.Rows(0)("JourPaie"), 1)
                ent.Duree_Globale = IsNull(.Rows(0)("Duree_Globale"), 0)
                ent.Repos_Hebdomadaire = IsNull(.Rows(0)("Repos_Hebdomadaire"), 0)
                ent.Jours_Feries = IsNull(.Rows(0)("Jours_Feries"), 0)
                ent.LastDatePaie = IsNull(.Rows(0)("DatDernierePaie"), 0)
                ent.Duree_Conge = IsNull(.Rows(0)("Duree_Conge"), 0)
                ent.Commentaire = IsNull(.Rows(0)("Commentaire"), "")
                ent.Typ_Conge = IsNull(.Rows(0)("Typ_Conge"), "CAD")
                ent.Cod_Poste = IsNull(.Rows(0)("Cod_Poste"), "")
                ent.Cod_Grade = IsNull(.Rows(0)("Cod_Grade"), "")
                ent.Cod_Entite = IsNull(.Rows(0)("Cod_Entite"), "")
                ent.Titre = IsNull(.Rows(0)("Titre"), "")
                ent.Statut = IsNull(Tbl.Rows(0)("Statut"), "")
                SqlStr = "SELECT   *
                            FROM RH_Conge_Suivi_Detail where  isnull(nullif(Num_Conge,''),'xyzer')='" & ent.Num_Conge & "' and id_Societe=" & Societe.id_Societe
                Tbl = DATA_READER_GRD(SqlStr)
                With Tbl
                    For i = 0 To .Rows.Count - 1
                        lig.Add(New ligDemande With {.Dat_Deb = CDate(Tbl.Rows(i)("Dat_Deb")).ToShortDateString,
                                                 .Dat_Fin = CDate(Tbl.Rows(i)("Dat_Fin")).ToShortDateString,
                                                .Duree_Globale = Tbl.Rows(i)("Duree_Globale"),
                                               .Repos_Hebdomadaire = Tbl.Rows(i)("Repos_Hebdomadaire"),
                                                 .Jours_Feries = Tbl.Rows(i)("Jours_Feries"),
                                                .Duree_Conge = Tbl.Rows(i)("Duree_Conge")})
                    Next
                End With

            Else
                ent.Matricule = ""
                ent.Dat_Deb_Conge = Now.ToShortDateString
                ent.Dat_Fin_Conge = Now.ToShortDateString
                ent.Duree_Globale = 0
                ent.Repos_Hebdomadaire = 0
                ent.JourPaie = 1
                ent.Jours_Feries = 0
                ent.Duree_Conge = 0
                ent.Commentaire = ""
                ent.Typ_Conge = "CAD"
                ent.Dat_Deb_am_pm = "am"
                ent.Dat_Fin_am_pm = "am"
                ent.Statut = ""
                ent.Cod_Poste = ""
                ent.Cod_Grade = ""
                ent.Cod_Entite = ""
                ent.Titre = ""
                ent.Cod_Plan_Paie = ""
                ent.LastDatePaie = ""
            End If
        End With
        setCalcul = True
        Return Calcul()
    End Function
    Public Function Saving(statut As String) As savingResult
        Try
            If CnExecuting("Select count(*) from Controle_Access where Name_Ecran='RH_Preparation_Paie' and id_Societe=" & Societe.id_Societe).Fields(0).Value > 0 Then
                Return New savingResult With {.message = "Une préparation de la paie est en cours. Réessayez plus tard.", .result = False}
            End If
            If ent.Matricule = "" Then
                Return New savingResult With {.message = "Matricule non renseigné", .result = False}
            End If
            If ent.Cod_Plan_Paie = "" Then
                Return New savingResult With {.message = "Plan non renseigné", .result = False}
            End If
            If ent.Dat_Deb_Conge > ent.Dat_Fin_Conge Then
                Return New savingResult With {.message = "Incohérence dates début et fin de congé", .result = False}
            End If
            '  traiter le cas des congés pour des périodes déjà passées et cloturées
            If CnExecuting("select dbo.Sys_Conge_CheckPeriode (" & Societe.id_Societe & ",'" & ent.Dat_Deb_Conge.ToShortDateString() & "','" & ent.Dat_Deb_Conge.ToShortDateString() & "')").Fields(0).Value > 0 Then
                Return New savingResult With {.message = "Dates de congé correspondant à une période clôturée", .result = False}
            End If
            If EstDate(ent.LastDatePaie) And (FindParam("Autoriser_SaisieCongeApresPaie") <> "O") Then
                If ent.Dat_Deb_Conge <= CDate(ent.LastDatePaie) Then
                    Return New savingResult With {.message = "La date de début du congé doit être postérieure à la date de la dernière paie", .result = False}
                End If
            End If
            Dim Tbl As DataTable = DATA_READER_GRD("exec Sys_Conge_Check '" & ent.Num_Conge & "','" & ent.Dat_Deb_Conge.ToShortDateString() & "','" & ent.Dat_Fin_Conge.ToShortDateString() & "','" & ent.Matricule & "'," & Societe.id_Societe)
            If Tbl.Rows.Count > 0 Then
                Return New savingResult With {.message = "Il existe au moins un congé en chevauchement avec cette demande : " & Tbl.Rows(0)("Num_Conge"), .result = False}
            End If
            If Not Calcul() Then
                Return New savingResult With {.message = "Erreur calcul de congé", .result = False}
            End If
            If ent.Duree_Conge = 0 Then
                Return New savingResult With {.message = "Aucun congé à déduire", .result = False}
            End If
            Dim NumConge As String = ent.Num_Conge
            If NumConge = "" Then
                Dim Cp As New ADODB.Recordset
                Cp = CnExecuting("select isnull(max(convert(int,right(Num_Conge,6))),0) from RH_Conge_Suivi where id_Societe=" & Societe.id_Societe & " and year(Dat_Crea)=" & Now.Year)
                If Not Cp.EOF Then
                    NumConge = "C" & Societe.id_Societe & "-" & CDate(ent.Dat_Deb_Conge).Year & Droite("000000" & CInt(Cp.Fields(0).Value + 1), 6)
                Else
                    NumConge = "C" & Societe.id_Societe & "-" & CDate(ent.Dat_Deb_Conge).Year & "000001"
                End If
            End If
            Dim oDat As Date = Now
            Dim rs As New ADODB.Recordset
            rs.Open("select * from RH_Conge_Suivi where Num_Conge='" & NumConge & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            If rs.EOF Then
                rs.AddNew()
                rs("Num_Conge").Value = NumConge
                rs("id_Societe").Value = Societe.id_Societe
                rs("Matricule").Value = ent.Matricule
                rs("Dat_Crea").Value = oDat
                rs("Created_By").Value = theUser.Login
            Else
                rs.Update()
            End If
            rs("Dat_Deb_Conge").Value = ent.Dat_Deb_Conge.ToShortDateString()
            rs("Dat_Fin_Conge").Value = ent.Dat_Fin_Conge.ToShortDateString()
            rs("Duree_Globale").Value = ent.Duree_Globale
            rs("Repos_Hebdomadaire").Value = ent.Repos_Hebdomadaire
            rs("Jours_Feries").Value = ent.Jours_Feries
            rs("Duree_Conge").Value = ent.Duree_Conge
            rs("Commentaire").Value = ent.Commentaire
            rs("Typ_Conge").Value = IIf(ent.Typ_Conge = "", "CAD", ent.Typ_Conge)
            rs("Dat_Deb_Am_Pm").Value = ent.Dat_Deb_am_pm
            rs("Dat_Fin_Am_Pm").Value = ent.Dat_Fin_am_pm
            rs("Statut").Value = statut
            rs("Cod_Entite").Value = ent.Cod_Entite
            rs("Cod_Poste").Value = ent.Cod_Poste
            rs("Cod_Grade").Value = ent.Cod_Grade
            rs("Titre").Value = ent.Titre
            rs("Cod_Plan_Paie").Value = ent.Cod_Plan_Paie
            rs("JourPaie").Value = ent.JourPaie
            rs("DatDernierePaie").Value = If(EstDate(ent.LastDatePaie), ent.LastDatePaie, Nothing)
            rs("Commentaire").Value = ent.Commentaire
            rs("Dat_Modif").Value = oDat
            rs("Modified_By").Value = theUser.Login
            rs.Update()
            rs.Close()
            CnExecuting("delete from RH_Conge_Suivi_Detail where Num_Conge='" & NumConge & "' and id_Societe=" & Societe.id_Societe)
            rs.Open("select * from RH_Conge_Suivi_Detail where Num_Conge='" & NumConge & "' and id_Societe=" & Societe.id_Societe, cn, 2, 2)
            With lig
                For i = 0 To .Count - 1
                    rs.AddNew()
                    rs("Num_Conge").Value = NumConge
                    rs("id_Societe").Value = Societe.id_Societe
                    rs("Matricule").Value = ent.Matricule
                    rs("Dat_Deb").Value = lig(i).Dat_Deb
                    rs("Dat_Fin").Value = lig(i).Dat_Fin
                    rs("Duree_Globale").Value = lig(i).Duree_Globale
                    rs("Repos_Hebdomadaire").Value = lig(i).Repos_Hebdomadaire
                    rs("Jours_Feries").Value = lig(i).Jours_Feries
                    rs("Duree_Conge").Value = lig(i).Duree_Conge
                    rs.Update()
                Next
            End With
            rs.Close()
            If ent.Num_Conge = "" Then ent.Num_Conge = NumConge
            Return New savingResult With {.message = "Enregistré avec succès", .result = True}
        Catch ex As Exception
            Return New savingResult With {.message = ex.Message, .result = False}
        End Try
    End Function
    Function Calcul() As Boolean
        If Not setCalcul Then Return True
        If ent.Statut <> "" Then Return True
        lig.Clear()
        ent.Duree_Globale = 0
        ent.Repos_Hebdomadaire = 0
        ent.Jours_Feries = 0
        ent.Duree_Conge = 0
        If Not IsNumeric(ent.JourPaie) Then Return False
        If Not EstDate(ent.Dat_Deb_Conge.ToShortDateString()) Then Return False
        If Not EstDate(ent.Dat_Fin_Conge.ToShortDateString()) Then Return False
        If Not EstDate(ent.JourPaie & "/" & Month(ent.Dat_Deb_Conge.ToShortDateString()) & "/" & Year(ent.Dat_Deb_Conge.ToShortDateString())) Then Return False
        Dim DureeGlobal As Double = 0
        Dim DureeDetail As Double = 0
        If ent.Dat_Deb_Conge > ent.Dat_Fin_Conge Then
            Return False
        End If
        DureeGlobal = DateDiff(DateInterval.Day, ent.Dat_Deb_Conge, ent.Dat_Fin_Conge) + 1
        If ent.Dat_Deb_am_pm = "pm" Then DureeGlobal -= 0.5
        If ent.Dat_Fin_am_pm = "am" Then DureeGlobal -= 0.5
        Dim JoursOuvres() As String = Societe.JourOuvrables.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
        Dim nbrp, nbfr As Integer
        Dim oDate As New Date
        Dim TblJourFeries As DataTable = DATA_READER_GRD("select * from dbo.Sys_JourFeries ('" & ent.Dat_Deb_Conge.ToShortDateString() & "' , " & Societe.id_Societe & ")")
        Dim DatFinPaie As Date = ent.Dat_Deb_Conge.AddMonths(1).AddDays(ent.JourPaie - ent.Dat_Deb_Conge.Day) 'CDate(ent.JourPaie & "/" & Month(ent.Dat_Deb_Conge.ToShortDateString()) + IIf(ent.JourPaie = "1", 1, 0) & "/" & Year(ent.Dat_Deb_Conge.ToShortDateString()))
        DatFinPaie = DateAdd(DateInterval.Day, -1, DatFinPaie)
        Dim DatDebPaie As Date = ent.Dat_Deb_Conge
        Dim k As Integer = 0
        With lig
            Do While DatFinPaie >= DatDebPaie And DatFinPaie < ent.Dat_Fin_Conge
                'objectif de cette boucle est de traiter les dates s'étalant sur des périodes couvrant différentes période
                If DatDebPaie = ent.Dat_Deb_Conge And ent.Dat_Deb_am_pm = "pm" Then
                    .Add(New ligDemande With {.Dat_Deb = DatDebPaie, .Dat_Fin = DatFinPaie, .Duree_Globale = DateDiff(DateInterval.Day, DatDebPaie, DatFinPaie) + 0.5, .Repos_Hebdomadaire = 0, .Jours_Feries = 0, .Duree_Conge = 0})
                Else
                    .Add(New ligDemande With {.Dat_Deb = DatDebPaie, .Dat_Fin = DatFinPaie, .Duree_Globale = DateDiff(DateInterval.Day, DatDebPaie, DatFinPaie) + 1, .Repos_Hebdomadaire = 0, .Jours_Feries = 0, .Duree_Conge = 0})
                End If
                DureeDetail += lig(k).Duree_Globale
                DatDebPaie = DatFinPaie.AddDays(1)
                DatFinPaie = DatDebPaie.AddMonths(1).AddDays(-1)
                k += 1
            Loop
            .Add(New ligDemande With {.Dat_Deb = DatDebPaie, .Dat_Fin = ent.Dat_Fin_Conge, .Duree_Globale = DureeGlobal - DureeDetail, .Repos_Hebdomadaire = 0, .Jours_Feries = 0, .Duree_Conge = 0})
            nbrp = 0
            nbfr = 0
            For i = 0 To .Count - 1
                Dim lng As ligDemande = lig(i)
                oDate = lng.Dat_Deb
                Do Until oDate = lng.Dat_Fin
                    'Calcul du nombre de jours de repos
                    If JoursOuvres.Length = 7 Then
                        If CInt(JoursOuvres(IIf(oDate.DayOfWeek = 0, 7, oDate.DayOfWeek) - 1)) = 0 Then
                            lng.Repos_Hebdomadaire += 1
                            nbrp += 1
                        End If
                    End If
                    'Calcul du nombre de jours fériés
                    If TblJourFeries.Select("'" & oDate & "'>=[DatDeb] and '" & oDate & "'<=[DatFin]").Length > 0 Then
                        lng.Jours_Feries += 1
                        nbfr += 1
                    End If
                    oDate = oDate.AddDays(1)
                Loop
                lng.Duree_Conge = Math.Max(0, lng.Duree_Globale - lng.Jours_Feries - lng.Repos_Hebdomadaire)

            Next
            ent.Duree_Globale = DureeGlobal

            If Tbl_RH_Conge_Type.Rows.Count > 0 Then
                If CBool(Tbl_RH_Conge_Type.Rows(0)("deductibleDuConge")) Then
                    ent.Repos_Hebdomadaire = nbrp
                    ent.Jours_Feries = nbfr
                    ent.Duree_Conge = Math.Max(0, DureeGlobal - nbrp - nbfr)
                Else
                    ent.Repos_Hebdomadaire = 0
                    ent.Jours_Feries = 0
                    ent.Duree_Conge = 0
                End If
            Else
                ent.Repos_Hebdomadaire = 0
                ent.Jours_Feries = 0
                ent.Duree_Conge = 0
            End If
        End With
        Return True
    End Function
End Class
