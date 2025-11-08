Module Module_Societe
    Public TblSociete As New DataTable
    Public Societe As SocieteModel
    Public Structure SocieteModel
        Public id_Societe As Integer
        Public Denomination As String
        Public FJ As String
        Public Regime As String
        Public Activite As String
        Public IdentFisc As String
        Public RC As String
        Public TP As String
        Public CNSS As String
        Public Adresse As String
        Public Cp As String
        Public Ville As String
        Public Cod_Pays As String
        Public Tel As String
        Public Fax As String
        Public Email As String
        Public Cod_TFP As String
        Public Cod_Commune As String
        Public Moyen_Paiement As String
        Public CNSS_Agence As String
        Public LeMatricule As String
        Public Racine As String
        Public Compteur_Auto As Boolean
        Public Sequence As Integer
        Public DateDebPaie As DateTime
        Public DateFinPaie As DateTime
        Public JourOuvrables As String
        Public Masquer_Element_Paie_Agent As Boolean
        Public Obliger_Demande_Pret As Boolean
        Public Mis_Sml As Boolean
    End Structure
    Function ChargerSociete(Optional swhere As String = "") As Integer
        Dim CodSql As String = "select   * from Param_Societe " & oFiltreSociete & IIf(swhere = "", "", IIf(oFiltreSociete <> "", " and ", " where ") & swhere) & " order by id_Societe"
        TblSociete = DATA_READER_GRD(CodSql)
        Dim nbSoc As Integer = TblSociete.Rows.Count
        If (Droits.NbMaxSoc - nbSoc) < 0 And theUser.Typ_Role <> "Agent" Then
            ShowMessageBox("Vous avez droit uniquement à " & Droits.NbMaxSoc & ", que vous avez dépassé de " & (nbSoc - Droits.NbMaxSoc) & vbCrLf & " Certains sociétés créées peuvent ne pas s'afficher", "Attention", MessageBoxButtons.OK, msgIcon.Error)
            If TblSociete.Rows.Count > 0 And Droits.NbMaxSoc > 0 Then TblSociete = TblSociete.AsEnumerable.Take(Droits.NbMaxSoc).CopyToDataTable
        End If
        Return TblSociete.Rows.Count
    End Function
    Function OuvrirSociete(idSociete As Integer, Optional checkOpenForms As Boolean = True) As Boolean
        leMenu.Navigator_ud.path_pnl.Controls.Clear()
        Dim oldIdSoc As Integer = Societe.id_Societe
        Dim sRw() As DataRow = TblSociete.Select("id_Societe=" & idSociete)
        If checkOpenForms Then
            Dim frmN As String = ""
            For Each frm As Form In Application.OpenForms
                If Not "Menu_Societes;leMenu;Login;Login_Demarrage;Menu_System;DB_Societe;Menu_Operationnel;leMenu;Wait".Split(";").Contains(frm.Name) Then
                    frmN = frm.Name
                    Exit For
                End If
            Next
            If frmN <> "" Then
                ShowMessageBox("Veuillez sortir des écrans ouverts avant de changer de société : " & frmN, "Controle", MessageBoxButtons.OK, msgIcon.Stop)
                Return False
            End If
        End If
        If sRw.Length > 0 Then
            _localParams.currentIdSoc = idSociete
            Societe.id_Societe = idSociete
            Societe.Denomination = sRw(0).Item("Den")
            leMenu.Navigator_ud.DB_lbl.Text = sRw(0).Item("Den")
            Societe.FJ = sRw(0).Item("FJ")
            Societe.Regime = IsNull(sRw(0).Item("Regime"), "")
            Societe.Activite = IsNull(sRw(0).Item("Activite"), "")
            Societe.IdentFisc = IsNull(sRw(0).Item("IdentFisc"), "")
            Societe.RC = IsNull(sRw(0).Item("RC"), "")
            Societe.TP = IsNull(sRw(0).Item("TP"), "")
            Societe.CNSS = IsNull(sRw(0).Item("CNSS"), "")
            Societe.Adresse = IsNull(sRw(0).Item("Adresse"), "")
            Societe.Cp = IsNull(sRw(0).Item("Cp"), "")
            Societe.Ville = IsNull(sRw(0).Item("Ville"), "CASAB")
            Societe.Cod_Pays = IsNull(sRw(0).Item("Cod_Pays"), "MAR")
            Societe.Tel = IsNull(sRw(0).Item("Tel"), "")
            Societe.Fax = IsNull(sRw(0).Item("Fax"), "")
            Societe.Email = IsNull(sRw(0).Item("Email"), "")
            Societe.Cod_TFP = IsNull(sRw(0).Item("Cod_TFP"), "")
            Societe.Cod_Commune = IsNull(sRw(0).Item("Cod_Commune"), "")
            Societe.Moyen_Paiement = IsNull(sRw(0).Item("Moyen_Paiement"), "")
            Societe.CNSS_Agence = IsNull(sRw(0).Item("CNSS_Agence"), "")
            Societe.LeMatricule = ""
            Societe.Racine = IsNull(sRw(0).Item("Racine"), "")
            Societe.Sequence = IsNull(sRw(0).Item("Sequence"), 20)
            Societe.Compteur_Auto = IsNull(sRw(0).Item("Compteur_Auto"), True)
            Societe.DateDebPaie = IsNull(sRw(0).Item("Dat_Deb_Paie"), "01/01/1810")
            Societe.DateFinPaie = IsNull(sRw(0).Item("Dat_Fin_Paie"), "31/12/2050")
            Societe.JourOuvrables = IsNull(sRw(0).Item("JourOuvrables"), "1;1;1;1;1;1;0")
            Societe.Masquer_Element_Paie_Agent = IsNull(sRw(0).Item("Masquer_Element_Paie_Agent"), False)
            Societe.Obliger_Demande_Pret = IsNull(sRw(0).Item("Obliger_Demande_Pret"), False)
            Societe.Mis_Sml = IsNull(sRw(0).Item("Mis_Sml"), False)
            InfoSoc = 1
            Tbl_Org_Entite = DATA_READER_GRD(" select * from Sys_Org_Entite where id_Societe=" & Societe.id_Societe)
        Else
            Societe.id_Societe = -1
            Societe.Denomination = ""
            Societe.FJ = ""
            Societe.Regime = ""
            Societe.Activite = ""
            Societe.IdentFisc = ""
            Societe.RC = ""
            Societe.TP = ""
            Societe.CNSS = ""
            Societe.Adresse = ""
            Societe.Cp = ""
            Societe.Ville = ""
            Societe.Tel = ""
            Societe.Fax = ""
            Societe.Email = ""
            Societe.Cod_TFP = ""
            Societe.Cod_Commune = ""
            Societe.Moyen_Paiement = ""
            Societe.CNSS_Agence = ""
            Societe.LeMatricule = ""
            Societe.Racine = ""
            Societe.Sequence = 0
            Societe.Compteur_Auto = True
            Societe.DateDebPaie = "01/01/1810"
            Societe.DateFinPaie = "31/12/2050"
            Societe.JourOuvrables = "1;1;1;1;1;1;0"
            Societe.Obliger_Demande_Pret = False
            Societe.Masquer_Element_Paie_Agent = False
            Societe.Mis_Sml = False
            InfoSoc = 0
        End If
        With Menu_Societes
            Dim obj() = .Controls.Find(oldIdSoc, True)
            If obj.Length > 0 Then
                CType(obj(0), Object).isSelected = False
            End If
            obj = .Controls.Find(idSociete, True)
            If obj.Length > 0 Then
                CType(obj(0), Object).isSelected = True
            End If
        End With
        Building_Sys_RH_Agent_AG()
        Return True
    End Function
End Module
