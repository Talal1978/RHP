Public Class Survey_render
    Friend CodSurvey As String
    Private Sub Survey_render_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cod_Survey_lbl.Text = CodSurvey
        Lib_Survey_lbl.Text = FindLibelle("Lib_Survey", "Cod_Survey", CodSurvey, "Survey").ToString.ToUpper
        Preambule_rtb.Rtf = FindLibelle("Preambule", "Cod_Survey", CodSurvey, "Survey")
        Generate_QuestionnaireNew(CodSurvey, pnl_Content, -1, "", "", "")
    End Sub

End Class