Imports System.Windows.Forms.DataVisualization.Charting
Module Module_Query
    Function Query_Converter(ByVal CodQuery As String, ByVal Variables As String) As String
        On Error Resume Next
        Dim qConn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim Declaration As String = ""
        Dim Affectation As String = ""
        Dim CodSql As String = ""
        qConn.ConnectionString = connectionString
        qConn.Open()
        rs.Open("Select * from Param_Query_Criteres where Cod_Query='" & CodQuery & "' order by Rang asc", qConn, 3, 3)
        Do While Not rs.EOF
            Declaration = Declaration & "Declare " & rs("Critere").Value & " " & rs("Typ_Critere").Value & vbCrLf
            rs.MoveNext()
        Loop
        rs.Close()
        Dim k As Integer = 0
        rs.Open("Select * from Param_Query_Criteres where Cod_Query='" & CodQuery & "' order by Rang asc", qConn, 3, 3)
        Do While Not rs.EOF
            Affectation = Affectation & "set " & rs("Critere").Value & " = " & Split(Variables, "#")(k) & vbCrLf
            k += 1
            rs.MoveNext()
        Loop
        rs.Close()
        CodSql = Declaration & Affectation & FindLibelle("Cod_Sql", "Cod_Query", CodQuery, "Param_Query")
        '    qConn.Close()
        Return CodSql
    End Function
    Sub ChargerChart(oChart As Chart, TblData As DataTable, IndxTyp_Graphe As Integer, AfficherValeur As Boolean, Optional Graph3D As Boolean = True)
        If TblData Is Nothing Then Return
        If TblData.Columns.Count = 0 Then Return
        IndxTyp_Graphe = IsNull(IndxTyp_Graphe, 0)
        If IndxTyp_Graphe < 0 Then IndxTyp_Graphe = 0
        oChart.Series.Clear()
        With TblData
            If CInt(Chart_NbSeries(IndxTyp_Graphe)) > 1 And .Columns.Count > 2 Then
                If .Columns(2).DataType.ToString.ToUpper.Contains("DOUBLE") Or .Columns(2).DataType.ToString.ToUpper.Contains("INT") Or .Columns(2).DataType.ToString.ToUpper.Contains("DECIMAL") Then
                    Dim TblSer As DataTable = TblData.DefaultView.ToTable(True, .Columns(1).ColumnName)
                    With TblSer
                        For i As Integer = 0 To .Rows.Count - 1
                            Dim oSerie As New System.Windows.Forms.DataVisualization.Charting.Series
                            With oSerie
                                .Name = CStr(TblSer.Rows(i).Item(0))
                                .ChartType = CType(Chart_Type(IndxTyp_Graphe), DataVisualization.Charting.SeriesChartType)
                                .IsValueShownAsLabel = AfficherValeur
                                .ToolTip = "#VAL"
                            End With
                            oChart.Series.Add(oSerie)
                        Next
                    End With

                    For i As Integer = 0 To .Rows.Count - 1
                        oChart.Series(CStr(.Rows(i).Item(.Columns(1).ColumnName))).Points.AddXY(.Rows(i).Item(0), .Rows(i).Item(2))
                    Next
                End If
            ElseIf .Columns.Count > 1 Then
                If .Columns(1).DataType.ToString.ToUpper.Contains("DOUBLE") Or .Columns(1).DataType.ToString.ToUpper.Contains("INT") Or .Columns(1).DataType.ToString.ToUpper.Contains("DECIMAL") Then
                    Dim oSerie As New System.Windows.Forms.DataVisualization.Charting.Series
                    With oSerie
                        .Name = CStr(TblData.Columns(0).ColumnName)
                        .ChartType = CType(Chart_Type(IndxTyp_Graphe), DataVisualization.Charting.SeriesChartType)
                        .IsValueShownAsLabel = AfficherValeur
                        .Enabled = True
                        .ToolTip = "#VAL"
                    End With
                    oChart.Series.Add(oSerie)
                    For i As Integer = 0 To .Rows.Count - 1
                        oChart.Series(CStr(TblData.Columns(0).ColumnName)).Points.AddXY(.Rows(i).Item(0), .Rows(i).Item(1))
                        oChart.ChartAreas(0).Area3DStyle.Enable3D = Graph3D
                        oChart.Palette = ChartColorPalette.Pastel
                    Next
                End If
            End If
        End With
    End Sub
    Function GetDefaultValue(ByVal CodQuery As String, ByVal Relation As String, Optional Typ As String = "SQL") As String
        Dim Variable As New ArrayList
        Dim ValeurVariable As New ArrayList
        Dim Indx, TblX As String
        If Typ = "RPT" Then
            Indx = "Cod_Report"
            TblX = "Param_Mod_Edition_Criteres"
        Else
            Indx = "Cod_Query"
            TblX = "Param_Query_Criteres"
        End If
        Dim TblCriteres As DataTable = DATA_READER_GRD("select Critere,Default_Value, Default_Value as Valeur from " & TblX & " where " & Indx & "='" & CodQuery & "'")
        TblCriteres.Columns("Valeur").ReadOnly = False
        Try
            ' Chargement des variables de critères et leurs valeurs
            If Microsoft.VisualBasic.Left(Relation, 1) = Chr(34) Then
                Relation = Relation.Replace(Chr(34), "")
            End If
            If Microsoft.VisualBasic.Left(Relation, 1) = "{" Then
                Relation = Relation.Replace("{", "").Replace("}", "")
                '   If Relation.Contains("#") Then
                '  Dim Tbl As String() = Relation.Split("#")
                '  For j = 1 To Tbl.Length - 1 Step 2
                '  Variable.Add("#" & Tbl(j).Split(" ")(0))
                '   ValeurVariable.Add(Sql_Grd.Item(CInt(Tbl(j).Split(" ")(0)), Sql_Grd.CurrentRow.Index).Value)
                ' Next
                '  End If
                If Relation.Contains("@") Then
                    With TblCriteres
                        For j = 0 To .Rows.Count - 1
                            If Relation.ToUpper.Contains(.Rows(j).Item("Critere").ToUpper) Then
                                Variable.Add(.Rows(j).Item("Critere").ToUpper)
                                ValeurVariable.Add(.Rows(j).Item("Valeur").ToUpper)
                            End If
                        Next
                    End With
                End If
                For j = 0 To Variable.Count - 1
                    If Relation.ToUpper.Contains(Variable(j).toupper) Then
                        Relation = Relation.Replace(Variable(j), "'" & ValeurVariable(j) & "'")
                    End If
                Next
                Relation = IsNull(CnExecuting(Relation).Fields(0).Value, "")
                'Cas des Variables Globales
            ElseIf Relation.ToString.Trim.ToUpper.Contains("GV_") Then
                Relation = GlobalVar(Relation.Trim.ToString)
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
        Return Relation
    End Function
End Module
