Imports DevExpress.XtraPivotGrid
Public Class Zoom_PivotAjouterChamps
    inherits Ecran

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Property PivotGrid() As PivotGridControl

    Private Sub teBonusName_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles teBonusName.EditValueChanging
        If String.IsNullOrEmpty(teBonusName.Text) Then
            Save_ud.Enabled = False
            beExpression.Enabled = False
        Else
            Save_ud.Enabled = True
            beExpression.Enabled = True
        End If
    End Sub

    Private Function GetNewInvisibleBonusField() As PivotGridField
        Dim newBonusField As New PivotGridField(teBonusName.Text, PivotArea.DataArea)
        newBonusField.Name = "field_" & teBonusName.Text
        newBonusField.Visible = False
        newBonusField.UnboundExpressionMode = UnboundExpressionMode.UseAggregateFunctions
        newBonusField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
        newBonusField.UnboundExpression = beExpression.Text
        newBonusField.Options.ShowUnboundExpressionMenu = True
        Return newBonusField
    End Function

    Private Sub beExpression_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles beExpression.ButtonClick
        Dim newBonus As PivotGridField = GetNewInvisibleBonusField()
        PivotGrid.Fields.Add(newBonus)
        PivotGrid.ShowUnboundExpressionEditor(newBonus)
        beExpression.Text = newBonus.UnboundExpression
        PivotGrid.Fields.Remove(newBonus)
    End Sub

    Private Sub buttonOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Save_ud.Click
        Dim newBonus As PivotGridField = GetNewInvisibleBonusField()
        newBonus.Visible = True
        newBonus.UnboundExpressionMode = UnboundExpressionMode.UseAggregateFunctions
        newBonus.Tag = "removable"
        PivotGrid.Fields.Add(newBonus)
        teBonusName.Text = String.Empty
        Save_ud.Enabled = False
        beExpression.Text = String.Empty
        beExpression.Enabled = False
        DialogResult = DialogResult.OK
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        Me.Close()
    End Sub
End Class