Public Class ud_pattern
    Inherits UserControl
    Public laquestion As String = ""
    Public repDic As New Dictionary(Of String, String)
    Public Obligatoire As Boolean = False
    Public noteManuelle As Double = 0
    Public avecNote As Boolean = False
    Public maxScore As Double = 0
    Public modeScoring As String = "na"
    Public funcScoring As String = ""
    Public coef As Double = 1
    Public codQuestion As String = ""
    Public Typ_Reponse As String
    Public noteDic As New Dictionary(Of String, Double)
    Public colonnes As String = ""
    Public lignes As String = ""
    Public nbLig As Integer = 1
    Public DefaultRep As String = ""
    Public numQuestion As String = ""
    Public Overridable Sub Saving()

    End Sub
    Public Overridable Sub CalculNote()

    End Sub
    Public Overridable Sub Chargement()

    End Sub
End Class
