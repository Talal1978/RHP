Module Module_GestionReliquat
    Sub GestionReliquat(ByVal NumLigOrg As Integer, ByVal Origine As String)


        If Origine.ToUpper = "V" Then
            'Gestion des reliquats
            If NumLigOrg > 0 Then
                Dim NumOrdOrg As Integer = CnExecuting("select Num_Ord from Vente_Lig_Pie where Num_Ord_Lig=" & NumLigOrg).Fields(0).Value
                Dim TypPieOrg As String = CnExecuting("select Typ_Pie from Vente_Ent_Pie where Num_Ord=" & NumOrdOrg).Fields(0).Value
                If TypPieOrg = "CO" Or TypPieOrg = "DV" Then
                    Dim QteCmdUniRef As Double = Math.Round(CnExecuting("select isnull((select sum(isnull(Qte_Cmd_Uni_Ref,0)) from Vente_Lig_Pie where Num_Lig_Org='" & NumLigOrg & "'),0)").Fields(0).Value, NbDecimalStk)
                    Dim QteCmd As Double = Math.Round(CnExecuting("select isnull((select sum(isnull(Qte_Cmd_Uni_Ref,0)) from Vente_Lig_Pie where Num_Lig_Org='" & NumLigOrg & "'),0)").Fields(0).Value, NbDecimalStk)
                    CnExecuting("Update Vente_Lig_Pie set Qte_Liv_Uni_Ref=round(" & CStr(QteCmdUniRef).Replace(",", ".") & "," & NbDecimalStk & ") ,Qte_Liv=round(" & CStr(QteCmd).Replace(",", ".") & "/Coef_Conver," & NbDecimalStk & "),Qte_Rlq_Uni_Ref=case when round(Qte_Cmd_Uni_Ref-" & CStr(QteCmdUniRef).Replace(",", ".") & "," & NbDecimalStk & ") >0 then round(Qte_Cmd_Uni_Ref-" & CStr(QteCmdUniRef).Replace(",", ".") & "," & NbDecimalStk & ") else 0 end where Num_Ord_Lig='" & NumLigOrg & "'" &
                    "Update Vente_Ent_Pie set Flag_Transf= " &
                    "case when round(isnull((select sum(isnull(Qte_Rlq_Uni_Ref,0)) from Vente_Lig_Pie where  Typ_Lig='L' and Vente_lig_Pie.Num_Ord=" & NumOrdOrg & "),0)," & NbDecimalStk & ")= 0 then 'T' when round(isnull((select sum(isnull(Qte_Rlq_Uni_Ref,0))-sum(isnull(Qte_Cmd_Uni_Ref,0)) from Vente_lig_Pie where Typ_Lig='L' and Vente_lig_Pie.Num_Ord=" & NumOrdOrg & "),0)," & NbDecimalStk & ") < 0 then 'P'  else  '' end Where Num_Ord=" & NumOrdOrg)
                ElseIf TypPieOrg = "BL" Then
                    CnExecuting("Update Vente_Ent_Pie set Flag_Transf= case " & _
                     "when round(isnull((select sum(isnull(Qte_Liv_Uni_Ref,0)-isnull(QTE_Retour,0)) from Vente_Lig_Pie where  Typ_Lig='L' and Vente_lig_Pie.Num_Ord=" & NumOrdOrg & "),0)," & NbDecimalStk & ") <=0 then 'S' " & _
                    " when round(isnull((select sum(isnull(Qte_Liv_Uni_Ref,0)-isnull(QTE_Retour,0)) from Vente_Lig_Pie where  Typ_Lig='L' and Vente_lig_Pie.Num_Ord=" & NumOrdOrg & "),0)," & NbDecimalStk & ")<= round(isnull((select sum(isnull(Qte_Liv_Uni_Ref,0)) from Vente_Lig_Pie where  Typ_Lig='L' and Vente_lig_Pie.Num_Ord_Org=" & NumOrdOrg & " and Num_Ord in (Select Num_Ord from Vente_Ent_Pie where Typ_Pie='FA')),0)," & NbDecimalStk & ") then 'T'" & _
                    " when round(isnull((select sum(isnull(Qte_Liv_Uni_Ref,0)) from Vente_Lig_Pie where  Typ_Lig='L' and Vente_lig_Pie.Num_Ord_Org=" & NumOrdOrg & "),0)," & NbDecimalStk & ") <= 0 then ''  else  'P' end Where Num_Ord=" & NumOrdOrg)
                ElseIf TypPieOrg = "FA" Then
                    CnExecuting("Update Vente_Ent_Pie set Flag_Transf= " &
                     "case when round(isnull((select sum(isnull(Qte_Liv_Uni_Ref,0)) from Vente_Lig_Pie where  Typ_Lig='L' and Vente_lig_Pie.Num_Ord=" & NumOrdOrg & " and Typ_Pie<>'AC'),0)," & NbDecimalStk & ")<= round(isnull((select sum(isnull(Qte_Liv_Uni_Ref,0)) from Vente_Lig_Pie where  Typ_Lig='L' and Vente_lig_Pie.Num_Ord_Org=" & NumOrdOrg & " and   Typ_Pie<>'AC'),0)," & NbDecimalStk & ") then 'T' when round(isnull((select sum(isnull(Qte_Liv_Uni_Ref,0)) from Vente_Lig_Pie where  Typ_Lig='L' and Vente_lig_Pie.Num_Ord_Org=" & NumOrdOrg & "),0)," & NbDecimalStk & ") <= 0 then ''  else  'P' end Where Num_Ord=" & NumOrdOrg)
                End If
            End If

        ElseIf Origine.ToUpper = "A" Then
            'Gestion des reliquats
            If NumLigOrg > 0 Then
                Dim NumOrdOrg As Integer = CnExecuting("select Num_Ord from Achat_Lig_Pie where Num_Ord_Lig=" & NumLigOrg).Fields(0).Value
                Dim TypPieOrg As String = CnExecuting("select Typ_Pie from Achat_Ent_Pie where Num_Ord=" & NumOrdOrg).Fields(0).Value

                If TypPieOrg = "CF" Or TypPieOrg = "DF" Then
                    Dim QteCmdUniRef As Double = Math.Round(CnExecuting("select isnull((select sum(isnull(Qte_Cmd_Uni_Ref,0)) from Achat_Lig_Pie where Num_Lig_Org='" & NumLigOrg & "'),0)").Fields(0).Value, NbDecimalStk)
                    Dim QteCmd As Double = Math.Round(CnExecuting("select isnull((select sum(isnull(Qte_Cmd_Uni_Ref,0)) from Achat_Lig_Pie where Num_Lig_Org='" & NumLigOrg & "'),0)").Fields(0).Value, NbDecimalStk)
                    Dim CodSql As String = "Update Achat_Lig_Pie set Qte_Liv_Uni_Ref=round(" & CStr(QteCmdUniRef).Replace(",", ".") & "," & NbDecimalStk & "),Qte_Liv=round(" & CStr(QteCmd).Replace(",", ".") & "/Coef_Conver," & NbDecimalStk & "),Qte_Rlq_Uni_Ref=case when round(Qte_Cmd_Uni_Ref-" & CStr(QteCmdUniRef).Replace(",", ".") & "," & NbDecimalStk & ") >0 then round(Qte_Cmd_Uni_Ref-" & CStr(QteCmdUniRef).Replace(",", ".") & "," & NbDecimalStk & ") else 0 end  where Num_Ord_Lig='" & NumLigOrg & "'" & _
                    "Update Achat_Ent_Pie set Flag_Transf= " & _
                    "case when round(isnull((select sum(isnull(Qte_Rlq_Uni_Ref,0)) from Achat_Lig_Pie where  Typ_Lig='L' and Achat_lig_Pie.Num_Ord=" & NumOrdOrg & "),0)," & NbDecimalStk & ")= 0 then 'T' when round(isnull((select sum(isnull(Qte_Rlq_Uni_Ref,0))-sum(isnull(Qte_Cmd_Uni_Ref,0)) from Achat_lig_Pie where Typ_Lig='L' and Achat_lig_Pie.Num_Ord=" & NumOrdOrg & "),0)," & NbDecimalStk & ") < 0 then 'P'  else  '' end Where Num_Ord=" & NumOrdOrg
                    CnExecuting(CodSql)
                ElseIf TypPieOrg = "BF" Then
                    Dim SqlStr As String = "Update Achat_Ent_Pie set Flag_Transf= case " & _
                    "when round(isnull((select sum(isnull(Qte_Liv_Uni_Ref,0)-isnull(QTE_Retour,0)) from Achat_Lig_Pie where  Typ_Lig='L' and Achat_lig_Pie.Num_Ord=" & NumOrdOrg & "),0)," & NbDecimalStk & ") <=0 then 'S' " & _
                   " when round(isnull((select sum(isnull(Qte_Liv_Uni_Ref,0)-isnull(QTE_Retour,0)) from Achat_Lig_Pie where  Typ_Lig='L' and Achat_lig_Pie.Num_Ord=" & NumOrdOrg & "),0)," & NbDecimalStk & ")<= round(isnull((select sum(isnull(Qte_Liv_Uni_Ref,0)) from Achat_Lig_Pie where  Typ_Lig='L' and Achat_lig_Pie.Num_Ord_Org=" & NumOrdOrg & " and Num_Ord in (Select Num_Ord from Achat_Ent_Pie where Typ_Pie='FF')),0)," & NbDecimalStk & ") then 'T'" & _
                   " when round(isnull((select sum(isnull(Qte_Liv_Uni_Ref,0)) from Achat_Lig_Pie where  Typ_Lig='L' and Achat_lig_Pie.Num_Ord_Org=" & NumOrdOrg & "),0)," & NbDecimalStk & ") <= 0 then ''  else  'P' end Where Num_Ord=" & NumOrdOrg
                    CnExecuting(SqlStr)
                ElseIf TypPieOrg = "FF" Then
                    CnExecuting("Update Achat_Ent_Pie set Flag_Transf= " &
                     "case when round(isnull((select sum(isnull(Qte_Liv_Uni_Ref,0)) from Achat_Lig_Pie where  Typ_Lig='L' and Achat_lig_Pie.Num_Ord=" & NumOrdOrg & "  and Typ_Pie<>'AD'),0)," & NbDecimalStk & ")<= round(isnull((select sum(isnull(Qte_Liv_Uni_Ref,0)) from Achat_Lig_Pie where  Typ_Lig='L' and Achat_lig_Pie.Num_Ord_Org=" & NumOrdOrg & "  and Typ_Pie<>'AD'),0)," & NbDecimalStk & ") then 'T' when round(isnull((select sum(isnull(Qte_Liv_Uni_Ref,0)) from Achat_Lig_Pie where  Typ_Lig='L' and Achat_lig_Pie.Num_Ord_Org=" & NumOrdOrg & "  and Typ_Pie<>'AD'),0)," & NbDecimalStk & ") <= 0 then ''  else  'P' end Where Num_Ord=" & NumOrdOrg)
                End If
            End If

        ElseIf Origine.ToUpper = "S" Then


            If NumLigOrg > 0 Then
                Dim NumOrdOrg As Integer = CnExecuting("select Num_Ord from Stock_DP_Lig where Num_Ord_Lig=" & NumLigOrg).Fields(0).Value
                Dim QteCmdUniRef As Double = CnExecuting("select isnull((select sum(isnull(Qte_Liv_Uni_Ref,0)) from Stock_Lig_Pie where isnull(Num_Lig_Org,0)='" & NumLigOrg & "'),0)").Fields(0).Value
                Dim QteCmd As Double = CnExecuting("select isnull((select sum(isnull(Qte_Liv,0)) from Stock_Lig_Pie where Num_Lig_Org='" & NumLigOrg & "'),0)").Fields(0).Value
                CnExecuting("Update Stock_DP_Lig set Qte_Liv_Uni_Ref=" & CStr(QteCmdUniRef).Replace(",", ".") & ",Qte_Liv=" & CStr(QteCmd).Replace(",", ".") & ",Qte_Rlq_Uni_Ref=case when Qte_Cmd_Uni_Ref-" & CStr(QteCmdUniRef).Replace(",", ".") & " >0 then Qte_Cmd_Uni_Ref-" & CStr(QteCmdUniRef).Replace(",", ".") & " else 0 end where Num_Ord_Lig='" & NumLigOrg & "'")
                CnExecuting("Update Stock_DP_Ent set Flag_Transf= " & _
                "case when isnull((select sum(isnull(Qte_Rlq_Uni_Ref,0)) from Stock_DP_Lig where Stock_DP_Lig.Num_Ord=" & NumOrdOrg & "),0)= 0 then 'T' when isnull((select sum(isnull(Qte_Rlq_Uni_Ref,0))-sum(isnull(Qte_Cmd_Uni_Ref,0)) from Stock_DP_Lig where Stock_DP_Lig.Num_Ord=" & NumOrdOrg & "),0) < 0 then 'P'  else  '' end Where Num_Ord=" & NumOrdOrg)
            End If
        End If
    End Sub
End Module
