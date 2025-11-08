Module Module_ElementFacturation

    Function ElementFacturation(ByVal CodElmFac As String, ByVal Num_Pie As String, ByVal TableRef As String, ByVal Typ As String) As Double
        Dim Remise As Double = 0
        Dim ks As New ADODB.Recordset
        Dim ValChamps As Double = 0
        ks.Open("select * from Param_Element_Facturation where Cod_ElmFac='" & CodElmFac & "' and Table_Ref='" & TableRef & "' and Element='" & Typ & "' order by Rang asc", cn, 3, 3)
        Do While Not ks.EOF
            If CnExecuting("Select count(*) from " & TableRef & " where Num_Pie='" & Num_Pie & "' and " & IsNull(ks("Condition").Value, "1=1")).Fields(0).Value > 0 Then
                If ks("Typ_ElmFac").Value = "Valeur" And IsNumeric(ks("Valeur").Value) Then
                    Remise = CDbl(ks("Valeur").Value)
                ElseIf ks("Typ_ElmFac").Value = "Pourcentage" And IsNumeric(ks("Valeur").Value) Then
                    ValChamps = IsNull(CnExecuting("select " & ks("Champs_Ref").Value & " from " & TableRef & " where Num_Pie='" & Num_Pie & "'").Fields(0).Value, 0)
                    Remise = Math.Round(CDbl(ks("Valeur").Value) * CDbl(ValChamps), NbDecimalVen) / 100
                End If
            End If
            ks.MoveNext()
        Loop
        ks.Close()
        Return Remise
    End Function

    Function TblTarifier(ByVal NumOrd As Integer, ByVal Modul As String, ByVal ElmArt As String, ByVal QteCmd As Double) As String
        Dim TblName As String = IIf(Modul = "A", "Achat", "Vente")
        Dim Tiers As String = IIf(Modul = "A", "Fou", "Clt")
        Dim oModule As String = IIf(Modul = "A", "Ach", "Ven")
        Dim CodPlan As Integer = FindLibelle("Trf_" & Tiers & "_Fac", "Num_Ord", NumOrd, TblName & "_Ent_Pie")
        Dim TypElementTiers As String = FindLibelle("Typ_Element_Tiers", "Cod_Plan", CodPlan, "Part_Plan_Tarif")
        Dim TypElementArt As String = FindLibelle("Typ_Element_Art", "Cod_Plan", CodPlan, "Part_Plan_Tarif")
        Dim SqlStr As String = " ; with " & oModule & " " & _
                               " as ( " & _
                               " select Dat_Pie,Trf_" & Tiers & "_Fac,Cod_" & Tiers & "_Fac," & TblName & "_Lig_Pie.Cod_Art,Num_Ord_Lig," & TblName & "_Lig_Pie.Prx_" & oModule & "_Brut,Rem1," & _
                               " Rem2,Produit_Art." & TypElementArt & " as ElmentArt,Part_" & Tiers & "." & TypElementTiers & " as ElmentTiers,Qte_Cmd_Uni_Ref " & _
                               " from " & TblName & "_Ent_Pie left join " & TblName & "_Lig_Pie " & _
                               " on " & TblName & "_Ent_Pie.Num_Ord=" & TblName & "_Lig_Pie.Num_Ord " & _
                               " left join Part_" & Tiers & " on " & TblName & "_Ent_Pie.Cod_" & Tiers & "_Fac=Part_" & Tiers & ".Cod_" & Tiers & " " & _
                               " left join Produit_Art on " & TblName & "_Lig_Pie.Cod_Art=Produit_Art.Cod_Art " & _
                               " where Typ_Lig='L' and " & TblName & "_Ent_Pie.Num_Ord=" & NumOrd & _
                               " Union All " & _
                               " select Dat_Pie,Trf_" & Tiers & "_Fac,Cod_" & Tiers & "_Fac,'',Null ,0,0,0,'" & ElmArt & "',Part_" & Tiers & "." & TypElementTiers & " ," & QteCmd & _
                               " from " & TblName & "_Ent_Pie left join Part_" & Tiers & " on " & TblName & "_Ent_Pie.Cod_" & Tiers & "_Fac=Part_" & Tiers & ".Cod_" & Tiers & _
                               " where Num_Ord =" & NumOrd & _
                               ") ,RecapV as ( " & _
                               " select Trf_" & Tiers & "_Fac,Dat_Pie,ElmentArt,ElmentTiers,sum(Qte_Cmd_Uni_Ref) as Qte " & _
                               " from " & oModule & "" & _
                               " Group by Dat_Pie,Trf_" & Tiers & "_Fac,ElmentArt,ElmentTiers)," & _
                               " Trf as " & _
                               " (select Trf_" & Tiers & "_Fac,o.Cod_Trf,Dat_Pie,ElmentArt,ElmentTiers,Qte,isnull(o.Prx_Brut,0) as Prx,isnull(o.Rem1,0) as REM1,isnull(o.Rem2,0) as REM2" & _
                               " from RecapV f " & _
                               " outer apply (select top 1 * from Part_Plan_Tarif_Detail " & _
                               " where(Element_Art = f.ElmentArt And Element_Tiers = f.ElmentTiers)" & _
                               " and Cod_Plan=f.Trf_" & Tiers & "_Fac and convert(smalldatetime,f.Dat_Pie) between convert(smalldatetime,Dat_Deb) and convert(smalldatetime,Dat_Fin) " & _
                               " and Qte_Min<=f.Qte  and isnull(Actif,'False')='True' order by Qte_Min desc) o ) " & _
                               " select Num_Ord_Lig,Qte_Cmd_Uni_Ref, " & _
                               " isnull(nullif(Trf.Prx,0),isnull(isnull(Nullif(Produit_Art_" & Tiers & ".Prx_" & oModule & "_Brut,0),Nullif(Produit_Art.Prx_" & oModule & "_Brut,0))," & oModule & ".Prx_" & oModule & "_Brut)) as Prx" & oModule & "Brut," & _
                               " isnull(Trf.Rem1,0) as R1," & _
                               " isnull(Trf.Rem2,0) as R2" & _
                               " from " & oModule & " left join Trf " & _
                               " on " & oModule & ".ElmentArt=Trf.ElmentArt and Trf.ElmentTiers=" & oModule & ".ElmentTiers " & _
                               " Left join Produit_Art_" & Tiers & " on " & oModule & ".Cod_" & Tiers & "_Fac=Produit_Art_" & Tiers & ".Cod_" & Tiers & " and " & oModule & ".Cod_Art=Produit_Art_" & Tiers & ".Cod_Art" & _
                               " left join Produit_Art on " & oModule & ".Cod_Art=Produit_Art.Cod_Art " & _
                               " order by Num_Ord_Lig"
        Return SqlStr
    End Function
End Module
