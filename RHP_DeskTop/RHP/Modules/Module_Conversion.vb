Module Module_Conversion
    Public Function EstDate(ByVal oDate As Object) As Boolean
        oDate = IsNull(oDate, "")
        If IsDate(oDate) Then
            If CDate(oDate).Year >= 1753 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Public Function EstBool(ByVal obj As Object) As Boolean
        Try
            obj = CBool(obj)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function EstEntier(ByVal obj As Object) As Boolean
        obj = IsNull(obj, "")
        Try
            obj = CInt(obj)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function ConvertEntier(obj As Object) As Integer
        '   obj = IsNull(obj, 0)
        If EstEntier(obj) Then
            Return CInt(obj)
        Else
            Return 0
        End If
    End Function
    Function ConvertNombre(obj As Object) As Double
        ' obj = IsNull(obj, 0)
        If IsNumeric(obj) Then
            Return CDbl(obj)
        Else
            Return 0
        End If
    End Function
    Function ConvertDate(obj As Object) As Date
        obj = IsNull(obj, "01/01/1753")
        If EstDate(obj) Then
            Return CDate(obj)
        Else
            Return "01/01/1753"
        End If
    End Function
    Function ConvertBoolean(obj As Object) As Boolean
        If EstBool(obj) Then
            Return CBool(obj)
        Else
            Return False
        End If
    End Function
    Function FormatDeNombre(Nombre As Double, Optional nbdecimal As Integer = -999) As String
        Nombre = ConvertNombre(Nombre)
        If nbdecimal = -999 Then
            nbdecimal = Math.Max(CStr(Nombre).IndexOf(","), 0)
            If nbdecimal > 0 Then
                nbdecimal = Math.Max(CStr(Nombre).Length - nbdecimal - 1, 0)
            Else
                nbdecimal = 2
            End If
            Return FormatNumber(IsNull(Nombre, 0), nbdecimal)
        Else
            Return FormatNumber(Nombre, nbdecimal)
        End If
    End Function
    Function convertTextToRTF(ByVal textToConvertToRtf As String) As String
        Dim rt As New RichTextBox
        rt.Text = textToConvertToRtf
        Return rt.Rtf
    End Function
    Function convertRtfToText(ByVal RtfToConvertToText As String) As String
        Dim rt As New RichTextBox
        rt.Rtf = RtfToConvertToText
        Return rt.Text
    End Function
End Module
