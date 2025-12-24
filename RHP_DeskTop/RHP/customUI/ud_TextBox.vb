Imports System.ComponentModel
Public Class ud_TextBox
    Public Shadows Event TextChanged As EventHandler
    Public Shadows Event KeyUp As EventHandler
    Public Shadows Event KeyPress As EventHandler
    Public Shadows Event KeyDown As EventHandler
    Public Shadows Sub ResetText()
        innerTextBox.ResetText()
    End Sub
    Public Property TextAlign As System.Windows.Forms.HorizontalAlignment
        Get
            Return innerTextBox.TextAlign
        End Get
        Set(value As HorizontalAlignment)
            innerTextBox.TextAlign = value
            innerTextBox.Invalidate()
        End Set
    End Property
    Public Shadows Property PasswordChar As String
        Get
            Return innerTextBox.PasswordChar
        End Get
        Set(value As String)
            innerTextBox.PasswordChar = value
        End Set
    End Property
    Public Shadows Property ScrollBars As ScrollBars
        Get
            Return innerTextBox.ScrollBars
        End Get
        Set(value As ScrollBars)
            innerTextBox.ScrollBars = value
        End Set
    End Property
    Public Shadows Property UseSystemPasswordChar As Boolean
        Get
            Return innerTextBox.UseSystemPasswordChar
        End Get
        Set(value As Boolean)
            innerTextBox.UseSystemPasswordChar = value
        End Set
    End Property
    Sub SelectAll()
        innerTextBox.SelectAll()
        innerTextBox.Invalidate()
    End Sub
    Public Shadows Sub [Select]()
        innerTextBox.Select()
    End Sub
    <Browsable(True),
 DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
 DefaultValue("")> ' Default value to ensure serialization when non-default
    Public Shadows Property ContextMenuStrip As ContextMenuStrip
        Get
            Return innerTextBox.ContextMenuStrip
        End Get
        Set(value As ContextMenuStrip)
            innerTextBox.ContextMenuStrip = value
        End Set
    End Property
    <Browsable(True),
 DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
 DefaultValue("")> ' Default value to ensure serialization when non-default
    Public Shadows Property Text As String
        Get
            Return innerTextBox.Text
        End Get
        Set(value As String)
            innerTextBox.Text = value
        End Set
    End Property
    Public Shadows Property MaxLength As Integer
        Get
            Return innerTextBox.MaxLength
        End Get
        Set(value As Integer)
            innerTextBox.MaxLength = value
        End Set
    End Property
    Public Shadows Property SelectionStart As Integer
        Get
            Return innerTextBox.SelectionStart
        End Get
        Set(value As Integer)
            innerTextBox.SelectionStart = value
        End Set
    End Property
    Public Shadows Property BackColor As Color
        Get
            Return innerTextBox.BackColor
        End Get
        Set(value As Color)
            innerTextBox.BackColor = value
        End Set
    End Property
    Public Shadows Property ForeColor As Color
        Get
            Return innerTextBox.ForeColor
        End Get
        Set(value As Color)
            innerTextBox.ForeColor = value
        End Set
    End Property
    Public Property [ReadOnly] As Boolean
        Get
            Return innerTextBox.ReadOnly
        End Get
        Set(value As Boolean)
            innerTextBox.ReadOnly = value
            If Not value Then
                Pnl.BackColor = Color.White
            Else
                Pnl.BackColor = Color.FromArgb(240, 240, 240)
            End If
            innerTextBox.BackColor = Pnl.BackColor
        End Set
    End Property
    Public Shadows Property Multiline As Boolean
        Get
            Return innerTextBox.Multiline
        End Get
        Set(value As Boolean)
            innerTextBox.Multiline = value
        End Set
    End Property
    Public Shadows Property CharacterCasing As System.Windows.Forms.CharacterCasing
        Get
            Return innerTextBox.CharacterCasing
        End Get
        Set(value As System.Windows.Forms.CharacterCasing)
            innerTextBox.CharacterCasing = value
        End Set
    End Property
    Private Sub innerTextBox_TextChanged(sender As Object, e As EventArgs) Handles innerTextBox.TextChanged
        RaiseEvent TextChanged(Me, e)
    End Sub
    'Sub Resizing()
    '    With innerTextBox
    '        .Size = New Size(Me.Width - 3, Me.Height - LB_lbl.Height - 2)
    '        .Location = New Point(0, 0)
    '    End With
    'End Sub
    Private Sub innerTextBox_GotFocus(sender As Object, e As EventArgs) Handles innerTextBox.GotFocus
        '  If [ReadOnly] Then Return
        LB_lbl.BackColor = colorBase03

    End Sub

    Private Sub innerTextBox_LostFocus(sender As Object, e As EventArgs) Handles innerTextBox.LostFocus
        LB_lbl.BackColor = colorBase01
    End Sub

    Private Sub innerTextBox_KeyUp(sender As Object, e As KeyEventArgs) Handles innerTextBox.KeyUp
        RaiseEvent KeyUp(sender, e)
    End Sub

    Private Sub innerTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles innerTextBox.KeyPress
        RaiseEvent KeyPress(sender, e)
    End Sub

    Private Sub innerTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles innerTextBox.KeyDown
        RaiseEvent KeyDown(sender, e)
    End Sub
End Class
