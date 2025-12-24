Imports System.Xml
Module Module_Xml_Dictionnary
    Function XmlToDictionnary(xmlFile As String) As Dictionary(Of String, Object)
        Dim dict As New Dictionary(Of String, Object)
        If IO.File.Exists(xmlFile) Then
            Dim dcxml As New XmlDocument
            dcxml.Load(xmlFile)
            For Each elm As XmlElement In dcxml.ChildNodes
                XmlToDictionnaryDetail(elm, dict)
            Next
        End If
        Return dict
    End Function

    Sub XmlToDictionnaryDetail(Elm As XmlElement, dicto As Dictionary(Of String, Object))
        For Each el As XmlElement In Elm.ChildNodes
            If hasXmlChildElements(el) Then
                dicto.Add(el.Name, New Dictionary(Of String, Object))
                XmlToDictionnaryDetail(el, dicto(el.Name))
            Else
                dicto.Add(el.Name, el.InnerText)
            End If
        Next
    End Sub
    Function hasXmlChildElements(ByVal node As XmlNode) As Boolean
        If node.HasChildNodes AndAlso node.ChildNodes.Count = 1 AndAlso node.FirstChild.GetType.Name.ToUpper = "XMLTEXT" Then
            Return False
        End If
        Return node.HasChildNodes
    End Function
    Sub DictionnaryToXmlDetail(nod As XmlElement, dict As Object)
        If dict.GetType Is GetType(Dictionary(Of String, Object)) Then
            For Each k In CType(dict, Dictionary(Of String, Object))
                Dim elm As XmlElement = nod.OwnerDocument.CreateElement(k.Key.Replace("""", ""))
                DictionnaryToXmlDetail(elm, k.Value)
                nod.AppendChild(elm)
            Next
        Else
            '  Try
            nod.InnerText = dict
            '     Catch ex As Exception

            '      End Try

        End If
    End Sub
End Module
