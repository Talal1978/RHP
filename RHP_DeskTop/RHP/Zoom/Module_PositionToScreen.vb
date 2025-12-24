Module Module_PositionToScreen
    Function getPositionToScreen(ByVal control As Object, ByVal FrmParent As Form) As Point
        Dim p As New Point
        Select Case control.GetType.Name
            Case "TextBox", "LinkLabel", "ComboBox", "ud_TextBox", "ud_ComboBox"
                p.X = control.Location.X
                p.Y = control.Location.Y + control.Height
                p = PointLocation(FrmParent, control, p)
            Case "DataGridViewTextBoxCell", "DataGridViewComboBoxCell"
                Dim GrdCell As New DataGridViewTextBoxCell
                GrdCell = CType(control, DataGridViewTextBoxCell)
                Dim r, c As Integer
                r = GrdCell.RowIndex
                c = GrdCell.ColumnIndex
                Dim _pointCell As Point
                With GrdCell.DataGridView
                    _pointCell = .GetCellDisplayRectangle(c, r, True).Location
                    _pointCell.X += .Location.X
                    _pointCell.Y += .Location.Y
                End With
                Dim _pointGrid As Point = PointLocation(FrmParent, GrdCell.DataGridView, New Point(0, 0))
                p.X = (_pointGrid).X + _pointCell.X
                p.Y = (_pointGrid).Y + _pointCell.Y + GrdCell.OwningRow.Height
            Case "PictureBox"
                p.X = control.Location.X
                p.Y = control.Location.Y + control.Height
                p = PointLocation(FrmParent, control, p)
        End Select
        Return p
    End Function
    Sub ShowDialogToPosition(ByVal control As Object, ByVal FrmParent As Form, ByVal FrmChild As Form)
        Dim p As Point = getPositionToScreen(control, FrmParent)
        If FrmParent.Parent IsNot Nothing Then
            If p.X + FrmChild.Width > FrmParent.Width Then p.X = FrmParent.Width - FrmChild.Width
            If p.Y + FrmChild.Height > FrmParent.Height Then p.Y = FrmParent.Height - FrmChild.Height
        End If

        p = FrmParent.PointToScreen(p)
        With FrmChild
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(p.X, p.Y - 1)
            .ShowDialog()
        End With
    End Sub
    Function PointLocation(ByVal Frm As Form, ByVal ZObject As Object, oPoint As Point) As Point
        If ZObject.parent IsNot Frm Then
            oPoint.X += ZObject.parent.location.X
            oPoint.Y += ZObject.parent.location.Y
            Return PointLocation(Frm, ZObject.parent, oPoint)
        Else
            Return oPoint
        End If
    End Function
End Module
