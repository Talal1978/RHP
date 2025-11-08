Module Module_GPEC
    Function stringToDictionary(strGPEC As String) As Dictionary(Of String, Double)
        Return strGPEC.Split(";"c).
         Select(Function(item) item.Split("$"c)).
         Select(Function(parts) New With {
             .Key = parts(0),
             .Value = If(parts.Length > 1 AndAlso Double.TryParse(parts(1), New Double), Double.Parse(parts(1)), 1)
         }).
         GroupBy(Function(p) p.Key).
         Select(Function(g) g.First()).
         ToDictionary(Function(p) p.Key, Function(p) p.Value)

    End Function
    Function dictionaryToString(dictionary As Dictionary(Of String, Double)) As String
        Return String.Join(";", dictionary.Select(Function(x) x.Key & "$" & x.Value).ToList())
    End Function

End Module
