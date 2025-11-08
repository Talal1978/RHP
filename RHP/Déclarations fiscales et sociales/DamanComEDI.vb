Module DamanComEDI
    Public Sub GenererEDI_DamanCom(ByVal FichierXmlH As String, AnneeT As String, PeriodeT As String, id_Transfert As String)

        Dim TblEntete As DataTable = DATA_READER_GRD("SELECT isnull(CP,'') as CP,isnull(Agence,'') as Agence,isnull(Ville,'') as Ville,isnull(Adresse,'') as Adresse,isnull(Activite,'') as Activite,isnull(Raison_Sociale,'') as Raison_Sociale,Convert(nvarchar(4),e.Annee)+e.Periode as L_Periode, e.Identif_Transfert,
REPLACE(CONVERT(nvarchar(10), e.Date_Emission, 102), '.', '') AS Date_Emission, REPLACE(CONVERT(nvarchar(10), e.Date_Exig, 102), '.', '') AS Date_Exig
FROM  Damancom_Ent e  where Identif_Transfert='" & id_Transfert & "'")
        If TblEntete.Rows.Count = 0 Then Return

        Dim N_Nbr_Salaries, N_T_Num_Imma, N_T_Jours_Declares, N_T_Salaire_Reel, N_T_Salaire_Plaf, N_T_Ctr As Double
        N_Nbr_Salaries = 0
        N_T_Num_Imma = 0
        N_T_Jours_Declares = 0
        N_T_Salaire_Reel = 0
        N_T_Salaire_Plaf = 0
        N_T_Ctr = 0
        Dim sw As New IO.StreamWriter(FichierXmlH, True)

        With TblEntete
            '2.1. Enregistrement type 1 « Nature du fichier communiqué »
            sw.WriteLine("B00" & BDS_Str(.Rows(0).Item("Identif_Transfert"), 14) & "B0" & StrDup(241, Chr(32)))
            '2.2. Enregistrement type 2 « Entête Globale de la déclaration»
            sw.WriteLine("B01" & BDS_Str(Societe.CNSS, 7) & BDS_Str(.Rows(0).Item("L_Periode"), 6) &
            BDS_Str(.Rows(0).Item("Raison_Sociale"), 40) & BDS_Str(.Rows(0).Item("Activite"), 40) &
             BDS_Str(.Rows(0).Item("Adresse"), 120) & BDS_Str(.Rows(0).Item("Ville"), 20) &
              BDS_Str(.Rows(0).Item("CP"), 6) & BDS_Str(.Rows(0).Item("Agence"), 2) &
             BDS_Str(.Rows(0).Item("Date_Emission"), 8) & BDS_Str(.Rows(0).Item("Date_Exig"), 8))
        End With


        Dim Tbl_P As DataTable = DATA_READER_GRD("Select Convert(nvarchar(4),e.Annee)+e.Periode As L_Periode, e.Identif_Transfert,l.Num_Assure, l.Nom+ ' ' +l.Prenom as Nom_Prenom, right('00'+ convert(nvarchar(2),l.N_Enfants),2) as N_Enfants, round(100*l.AF_A_Payer,2) as AF_A_Payer,
round(100*l.AF_A_Deduire,2) as AF_A_Deduire, round(100*l.AF_Net_A_Payer,2) as AF_Net_A_Payer , 
round(100*l.AF_A_Reverser,2) as AF_A_Reverser, ceiling(l.Jours_Declares) as Jours_Declares, 
round(100*l.Salaire_Reel,2) as Salaire_Reel, round(100*isnull(l.Salaire_Plaf,0),2) Salaire_Plaf, l.Situation, l.Num_Assure+round(100*l.AF_A_Reverser,2)+ceiling(l.Jours_Declares)+round(100*isnull(l.Salaire_Reel,0),2)+round(100*isnull(l.Salaire_Plaf,0),2)+s.Rang as S_Ctr
FROM  Damancom_Ent e left join Damancom_Lig l on e.Identif_Transfert=l.Identif_Transfert 
outer apply (select Rang from Param_DamanCom_Situation where Cod_Situation=isnull(l.Situation,'')) s
where e.Identif_Transfert='" & id_Transfert & "' and isnull(Typ_Assure,'')='B02' order by l.Rang")
        With Tbl_P
            '2.3. Enregistrement type 3 « Détail de la déclaration des salaires sur préétabli»
            For i = 0 To .Rows.Count - 1
                sw.WriteLine("B02" & BDS_Str(Societe.CNSS, 7) & BDS_Str(.Rows(i).Item("L_Periode"), 6) &
                    BDS_Str(.Rows(i).Item("Num_Assure"), 9, True) & BDS_Str(.Rows(i).Item("Nom_Prenom"), 60) & BDS_Str(.Rows(i).Item("N_Enfants"), 2, True) &
                   BDS_Str(.Rows(i).Item("AF_A_Payer"), 6, True) & BDS_Str(.Rows(i).Item("AF_A_Deduire"), 6, True) &
                    BDS_Str(.Rows(i).Item("AF_Net_A_Payer"), 6, True) & BDS_Str(.Rows(i).Item("AF_A_Reverser"), 6, True) & BDS_Str(.Rows(i).Item("Jours_Declares"), 2, True) &
                    BDS_Str(.Rows(i).Item("Salaire_Reel"), 13, True) & BDS_Str(.Rows(i).Item("Salaire_Plaf"), 9, True) & BDS_Str(.Rows(i).Item("Situation"), 2) &
                    BDS_Str(.Rows(i).Item("S_Ctr"), 19, True) & BDS_Str(Chr(32), 104))
            Next
        End With

        '2.4. Enregistrement type 4 « Récapitulatif de la déclaration des salaires sur préétabli»
        Tbl_P = DATA_READER_GRD("SELECT Convert(nvarchar(4),e.Annee)+e.Periode as L_Periode,count(*) as N_Nbr_Salaries, sum(N_Enfants) as N_T_Enfants,
sum(round(100*AF_A_Payer,2)) as N_T_AF_A_Payer,
sum(round(100*AF_A_Deduire,2)) as N_T_AF_A_Deduire, sum(round(100*AF_Net_A_Payer,2)) as N_T_AF_Net_A_Payer , 
sum(Num_Assure) as N_T_Num_Imma,
sum(round(100*AF_A_Reverser,2)) as N_T_AF_A_Reverser, sum(ceiling(Jours_Declares)) as N_T_Jours_Declares, 
sum(round(100*isnull(Salaire_Reel,0),2)) as N_T_Salaire_Reel, sum(round(100*isnull(Salaire_Plaf,0),2)) N_T_Salaire_Plaf, 
sum(Num_Assure+round(100*AF_A_Reverser,2)+ceiling(Jours_Declares)+round(100*isnull(Salaire_Reel,0),2)+round(100*isnull(Salaire_Plaf,0),2)+s.Rang) as N_T_Ctr
FROM   Damancom_Ent e left join Damancom_Lig l on e.Identif_Transfert=l.Identif_Transfert  
outer apply (select Rang from Param_DamanCom_Situation where Cod_Situation=isnull(Situation,'')) s
where e.Identif_Transfert='" & id_Transfert & "' and isnull(Typ_Assure,'')='B02'
group by isnull(Num_Affilie,0),Convert(nvarchar(4),Annee)+Periode")
        With Tbl_P
            If Tbl_P.Rows.Count > 0 Then
                sw.WriteLine("B03" & BDS_Str(Societe.CNSS, 7) & BDS_Str(.Rows(0).Item("L_Periode"), 6) &
BDS_Str(.Rows(0).Item("N_Nbr_Salaries"), 6, True) & BDS_Str(.Rows(0).Item("N_T_Enfants"), 6, True) & BDS_Str(.Rows(0).Item("N_T_AF_A_Payer"), 12, True) &
 BDS_Str(.Rows(0).Item("N_T_AF_A_Deduire"), 12, True) & BDS_Str(.Rows(0).Item("N_T_AF_Net_A_Payer"), 12, True) & BDS_Str(.Rows(0).Item("N_T_Num_Imma"), 15, True) &
 BDS_Str(.Rows(0).Item("N_T_AF_A_Reverser"), 12, True) & BDS_Str(.Rows(0).Item("N_T_Jours_Declares"), 6, True) & BDS_Str(.Rows(0).Item("N_T_Salaire_Reel"), 15, True) &
BDS_Str(.Rows(0).Item("N_T_Salaire_Plaf"), 13, True) & BDS_Str(IsNull(.Rows(0).Item("N_T_Ctr"), "0"), 19, True) & BDS_Str(Chr(32), 116))

                N_Nbr_Salaries = .Rows(0).Item("N_Nbr_Salaries")
                N_T_Num_Imma = .Rows(0).Item("N_T_Num_Imma")
                N_T_Jours_Declares = .Rows(0).Item("N_T_Jours_Declares")
                N_T_Salaire_Reel = .Rows(0).Item("N_T_Salaire_Reel")
                N_T_Salaire_Plaf = .Rows(0).Item("N_T_Salaire_Plaf")
                N_T_Ctr = .Rows(0).Item("N_T_Ctr")
            End If
        End With

        '2.5. Enregistrement type 5 « Détail déclaration des salaires pour les Entrants»
        Tbl_P = DATA_READER_GRD("Select Num_Assure, Nom+' '+Prenom as 'Nom_Prenom', CIN, ceiling(Jours_Declares) as Jours_Declares,round(100*isnull(Salaire_Reel,0),2)  as Salaire_Reel,round(100*isnull(Salaire_Plaf,0),2) Salaire_Plaf,
Num_Assure+ceiling(Jours_Declares)+round(100*isnull(Salaire_Reel,0),2)+round(100*isnull(Salaire_Plaf,0),2) as S_Ctr
 From Damancom_Ent e left join Damancom_Lig l on e.Identif_Transfert=l.Identif_Transfert
Where e.Identif_Transfert='" & id_Transfert & "' and isnull(Typ_Assure,'')='B04'")
        With Tbl_P
            For i = 0 To .Rows.Count - 1
                sw.WriteLine("B04" & BDS_Str(Societe.CNSS, 7) & AnneeT & PeriodeT &
                BDS_Str(.Rows(i).Item("Num_Assure"), 9, True) & BDS_Str(.Rows(i).Item("Nom_Prenom"), 60) & BDS_Str(.Rows(i).Item("CIN"), 8) &
                    BDS_Str(.Rows(i).Item("Jours_Declares"), 2, True) &
                    BDS_Str(.Rows(i).Item("Salaire_Reel"), 13, True) & BDS_Str(.Rows(i).Item("Salaire_Plaf"), 9, True) &
                    BDS_Str(.Rows(i).Item("S_Ctr"), 19, True) & BDS_Str(Chr(32), 124))
            Next
            If .Rows.Count = 0 Then
                sw.WriteLine("B04" & BDS_Str(Societe.CNSS, 7) & AnneeT & PeriodeT &
               BDS_Str(Chr(32), 9) & BDS_Str(Chr(32), 60) & BDS_Str(Chr(32), 8) &
                   BDS_Str(0, 2, True) &
                   BDS_Str(0, 13, True) & BDS_Str(0, 9, True) &
                   BDS_Str(0, 19, True) & BDS_Str(Chr(32), 124))
            End If
        End With


        '2.6. Enregistrement type 6 « Récap de la déclaration des salaires entrants»
        Tbl_P = DATA_READER_GRD("Select count(*) as N_Nbr_Salaries, isnull(sum(isnull(Num_Assure,0)),0) N_T_Num_Imma, isnull(sum(isnull(Jours_Declares,0)),0) N_T_Jours_Declares,
isnull(sum(round(100*isnull(Salaire_Reel,0),2)),0)  as N_T_Salaire_Reel,isnull(sum(round(100*isnull(Salaire_Plaf,0),2)),0) N_T_Salaire_Plaf,
isnull(sum(isnull(Num_Assure,0)+isnull(ceiling(Jours_Declares),0)+round(100*isnull(Salaire_Reel,0),2)+round(100*isnull(Salaire_Plaf,0),2)),0) as N_T_Ctr
 From Damancom_Ent e left join Damancom_Lig l on e.Identif_Transfert=l.Identif_Transfert
Where  e.Identif_Transfert='" & id_Transfert & "' and isnull(Typ_Assure,'')='B04'")
        With Tbl_P
            If Tbl_P.Rows.Count > 0 Then
                sw.WriteLine("B05" & BDS_Str(Societe.CNSS, 7) & AnneeT & PeriodeT &
BDS_Str(.Rows(0).Item("N_Nbr_Salaries"), 6, True) & BDS_Str(.Rows(0).Item("N_T_Num_Imma"), 15, True) &
BDS_Str(.Rows(0).Item("N_T_Jours_Declares"), 6, True) & BDS_Str(.Rows(0).Item("N_T_Salaire_Reel"), 15, True) &
BDS_Str(.Rows(0).Item("N_T_Salaire_Plaf"), 13, True) & BDS_Str(IsNull(.Rows(0).Item("N_T_Ctr"), "0"), 19, True) & BDS_Str(Chr(32), 170))
                N_Nbr_Salaries += .Rows(0).Item("N_Nbr_Salaries")
                N_T_Num_Imma += .Rows(0).Item("N_T_Num_Imma")
                N_T_Jours_Declares += .Rows(0).Item("N_T_Jours_Declares")
                N_T_Salaire_Reel += .Rows(0).Item("N_T_Salaire_Reel")
                N_T_Salaire_Plaf += .Rows(0).Item("N_T_Salaire_Plaf")
                N_T_Ctr += .Rows(0).Item("N_T_Ctr")
            End If
        End With

        '2.7. Enregistrement type 7 « Récapitulatif Globale de la déclaration des salaires»
        Tbl_P = DATA_READER_GRD("Select count(*) as N_Nbr_Salaries, sum(Num_Assure) N_T_Num_Imma, sum(ceiling(Jours_Declares)) N_T_Jours_Declares,
sum(round(100*isnull(Salaire_Reel,0),2))  as N_T_Salaire_Reel,sum(round(100*isnull(Salaire_Plaf,0),2)) N_T_Salaire_Plaf,
sum(Num_Assure+ceiling(Jours_Declares)+round(100*isnull(Salaire_Reel,0),2)+round(100*isnull(Salaire_Plaf,0),2)) as N_T_Ctr
 From Damancom_Ent e left join Damancom_Lig l on e.Identif_Transfert=l.Identif_Transfert
Where  e.Identif_Transfert='" & id_Transfert & "'")
        With Tbl_P
            If Tbl_P.Rows.Count > 0 Then
                sw.WriteLine("B06" & BDS_Str(Societe.CNSS, 7) & AnneeT & PeriodeT &
BDS_Str(N_Nbr_Salaries, 6, True) & BDS_Str(N_T_Num_Imma, 15, True) &
BDS_Str(N_T_Jours_Declares, 6, True) & BDS_Str(N_T_Salaire_Reel, 15, True) &
BDS_Str(N_T_Salaire_Plaf, 13, True) & BDS_Str(N_T_Ctr, 19, True) & BDS_Str(Chr(32), 170))
            End If
        End With

        sw.Close()

        ShowMessageBox("Exportation terminée")
    End Sub

    Function BDS_Str(Str As Object, NbChar As Integer, Optional EstNumeric As Boolean = False) As String
        If Not EstNumeric Then
            Return Gauche(IsNull(Str, "").Replace(Chr(13), Chr(32)) & StrDup(NbChar, Chr(32)), NbChar)
        Else
            Return Droite(StrDup(NbChar, "0") & IsNull(Str, 0), NbChar)
        End If

    End Function

End Module


