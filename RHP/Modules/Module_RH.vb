Module Module_RH
    Function CalculDroitConge() As Object
        Dim DrCg As Object = 0

        '    If ListCritere.Count > 0 Then
        '  If ListCritereValeur.Count > 0 Then
        ' Dim DrC As New ADODB.Recordset
        '  DrC = CnExecuting("select Droit_Conge from RH_Conge where Matricule='" & ListCritereValeur(ListCritere.IndexOf("OMATRICULE")) & "' and Annee=year(getdate())")
        '   If Not DrC.EOF Then
        '               DrCg = IsNull(DrC.Fields(0).Value, 0)
        '  Else
        '  Dim FuncDr As String = FindParam("Droit_Conge")
        '   DrCg = IsNull(ExtractionFonction(FuncDr, "", "", "X"), 0)
        '   End If
        '   End If
        '   End If

        Return DrCg
    End Function
    Function CalculSoldeCongeAnterieur() As Object
        Dim DrCg As Object = 0
        Dim FuncDr As String = FindParam("Nb_Annee_Droit_Conge")
        If Not IsNumeric(FuncDr) Then FuncDr = 2
        '  If ListCritere.Count > 0 Then
        '  If ListCritereValeur.Count > 0 Then
        '  Dim DrC As New ADODB.Recordset
        '   DrC = CnExecuting("select sum(isnull(Solde_Conge,0)) as Solde_Conge from RH_Conge where Matricule='" & ListCritereValeur(ListCritere.IndexOf("OMATRICULE")) & "' and Annee<year(getdate()) and Annee>=year(getdate())-" & FuncDr)
        '          If Not DrC.EOF Then
        '    DrCg = IsNull(DrC.Fields(0).Value, 0)
        '    End If
        '        End If
        '    End If
        Return DrCg
    End Function
End Module
