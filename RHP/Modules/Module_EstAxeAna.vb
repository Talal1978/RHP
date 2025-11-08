Module Module_EstAxeAna

    Sub EstAxeAna(ByVal NameEcran As String)
        Try
            Dim rs5 As New ADODB.Recordset
            If CnExecuting("Select count(*) from Controle_Def_Ecran where Name_Ecran='" & NameEcran & "'").Fields(0).Value = 0 Then
                MessageBoxRHP(544)
                Exit Sub
            End If

            Dim AxeCode As String = FindLibelle("Table_Ref", "Name_Ecran", NameEcran, "Controle_Def_Ecran")
            Dim IdxTbl As String = FindLibelle("Index_Table", "Name_Ecran", NameEcran, "Controle_Def_Ecran")
            Dim DesTbl As String = FindLibelle("Description", "Name_Ecran", NameEcran, "Controle_Def_Ecran")
            Dim AxeLib As String = FindLibelle("Text_Ecran", "Name_Ecran", NameEcran, "Controle_Menu")
            If CnExecuting("Select count(*) from Compta_Axe_Ana where Cod_Axe='" & AxeCode & "'").Fields(0).Value = 0 Then
                rs5.Open("Select * from  Compta_Axe_Ana", cn, 2, 2)
                rs5.AddNew()
                rs5("Cod_Axe").Value = AxeCode
                rs5("Lib_Axe").Value = AxeLib
                rs5("Mis_Sml").Value = "False"
                rs5("Obligatoire").Value = "False"
                rs5("Mouvemente").Value = "False"
                rs5("Created_By").Value = theUser.id_User
                rs5("Dat_Crea").Value = CnExecuting("select getdate()").Fields(0).Value
                rs5("Modified_By").Value = theUser.id_User
                rs5("Dat_Modif").Value = CnExecuting("select getdate()").Fields(0).Value
                rs5.Update()
                rs5.Close()

            End If

            Dim CodSql As String = "  insert into Compta_Plan_Ana (Cod_Axe, Sec_Ana, Nom_Sec, Groupe_analytique, Typ_Section, UO, Qte_UO, Actif, Mouvemente, Dat_Crea, Created_By, Dat_Modif, Modified_By)" & _
    "  SELECT     '" & AxeCode & "', " & IdxTbl & ", " & DesTbl & ",null,null,null,1,1, 0, getdate(), 1, getdate(), 1" & _
    "  FROM         " & AxeCode & " where " & IdxTbl & " not in (select Sec_Ana from Compta_Plan_Ana where Cod_Axe='" & AxeCode & "')" & _
    "  update Compta_Plan_Ana set Nom_Sec=" & DesTbl & " from " & AxeCode & " where " & IdxTbl & "=Sec_Ana and Cod_Axe='" & AxeCode & "'"

            rs5.Open("select * from Param_Query where Cod_Query='R_" & AxeCode & "'", cn, 2, 2)
            If rs5.EOF Then
                rs5.AddNew()
            Else
                rs5.Update()
            End If
            rs5("Cod_Query").Value = "R_" & AxeCode
            rs5("Nom_Query").Value = AxeLib
            rs5("Cod_Sql").Value = CodSql
            rs5("HeaderVisible").Value = False
            rs5("Resume").Value = False
            rs5("Typ_Query").Value = "U"
            rs5("Dat_Crea").Value = CnExecuting("select getdate()").Fields(0).Value
            rs5("Created_By").Value = 1
            rs5("Dat_Modif").Value = rs5("Dat_Crea").Value
            rs5("Modified_By").Value = 1
            rs5.Update()
            rs5.Close()

            CodSql = "  if (Select count(*) from Param_Abonnement where Ref_Abonnement='R_" & AxeCode & "')=0" &
    "  begin" &
    "  insert into Param_Abonnement (Lib_Abonnement, Source_Abonnement, Ref_Abonnement,Typ_Pie_Abonnement, Actif, Dat_Mis_Application, Heure_Abonnement, Typ_Frequence, " &
    "                        Frequence, Statut, Dat_Fin_Application, Dat_Next, Lundi, Mardi, Mercredi, Jeudi, Vendredi, Samedi, Dimanche, Dat_Crea, Created_By, Dat_Modif, Modified_By)" &
    "  SELECT      '" & AxeLib & "', 'Param_Query', 'R_" & AxeCode & "', 'QRY', 1, convert(nvarchar(10),getdate(),103), convert(nvarchar(10),getdate(),8), 'Second', " &
    "                        1, 0, '31/12/2099', null, 1, 1, 1, 1, 1, 1, 1, getdate(), 1, getdate(), 1" &
    "  end"

            CnExecuting(CodSql)
            MessageBoxRHP(348)
        Catch ex As Exception

        End Try
    End Sub

End Module
