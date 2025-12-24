<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GrdFilter_Simulation
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.search_txt = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.SelectAll_pb = New System.Windows.Forms.PictureBox()
        Me.New_pb = New System.Windows.Forms.PictureBox()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Del_pb = New System.Windows.Forms.PictureBox()
        Me.FilterList = New RHP.ud_CheckedListBox()
        Me.ModeleSaisie_cbo = New RHP.ud_ComboBox()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.SelectAll_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.New_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Del_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'search_txt
        '
        '
        '
        '
        Me.search_txt.Border.Class = "TextBoxBorder"
        Me.search_txt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Personnal_pnl.SetColumnSpan(Me.search_txt, 6)
        Me.search_txt.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.search_txt.Location = New System.Drawing.Point(4, 74)
        Me.search_txt.Margin = New System.Windows.Forms.Padding(4)
        Me.search_txt.Name = "search_txt"
        Me.search_txt.Size = New System.Drawing.Size(585, 26)
        Me.search_txt.TabIndex = 4
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Personnal_pnl.ColumnCount = 6
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.Personnal_pnl.Controls.Add(Me.SelectAll_pb, 3, 0)
        Me.Personnal_pnl.Controls.Add(Me.New_pb, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.Save_pb, 1, 0)
        Me.Personnal_pnl.Controls.Add(Me.ModeleSaisie_cbo, 0, 1)
        Me.Personnal_pnl.Controls.Add(Me.Close_pb, 5, 0)
        Me.Personnal_pnl.Controls.Add(Me.Label1, 4, 0)
        Me.Personnal_pnl.Controls.Add(Me.search_txt, 0, 2)
        Me.Personnal_pnl.Controls.Add(Me.Del_pb, 2, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Personnal_pnl.Location = New System.Drawing.Point(0, 0)
        Me.Personnal_pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 3
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.9434!))
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.0566!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(593, 102)
        Me.Personnal_pnl.TabIndex = 210
        '
        'SelectAll_pb
        '
        Me.SelectAll_pb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SelectAll_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SelectAll_pb.Image = Global.RHP.My.Resources.Resources.btn_selectAll_w
        Me.SelectAll_pb.InitialImage = Nothing
        Me.SelectAll_pb.Location = New System.Drawing.Point(124, 4)
        Me.SelectAll_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.SelectAll_pb.Name = "SelectAll_pb"
        Me.SelectAll_pb.Size = New System.Drawing.Size(32, 29)
        Me.SelectAll_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SelectAll_pb.TabIndex = 8
        Me.SelectAll_pb.TabStop = False
        '
        'New_pb
        '
        Me.New_pb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.New_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.New_pb.Image = Global.RHP.My.Resources.Resources.btn_add_w1
        Me.New_pb.InitialImage = Nothing
        Me.New_pb.Location = New System.Drawing.Point(4, 4)
        Me.New_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.New_pb.Name = "New_pb"
        Me.New_pb.Size = New System.Drawing.Size(32, 29)
        Me.New_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.New_pb.TabIndex = 5
        Me.New_pb.TabStop = False
        '
        'Save_pb
        '
        Me.Save_pb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save_w
        Me.Save_pb.InitialImage = Nothing
        Me.Save_pb.Location = New System.Drawing.Point(44, 4)
        Me.Save_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(32, 29)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Save_pb.TabIndex = 5
        Me.Save_pb.TabStop = False
        '
        'Close_pb
        '
        Me.Close_pb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close_w
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(557, 4)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(32, 29)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 5
        Me.Close_pb.TabStop = False
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(164, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(385, 37)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Filtre avancé"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Del_pb
        '
        Me.Del_pb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Del_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Del_pb.Image = Global.RHP.My.Resources.Resources.btn_delete_w
        Me.Del_pb.InitialImage = Nothing
        Me.Del_pb.Location = New System.Drawing.Point(84, 4)
        Me.Del_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Del_pb.Name = "Del_pb"
        Me.Del_pb.Size = New System.Drawing.Size(32, 29)
        Me.Del_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Del_pb.TabIndex = 5
        Me.Del_pb.TabStop = False
        '
        'FilterList
        '
        Me.FilterList.AutoScroll = True
        Me.FilterList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FilterList.Location = New System.Drawing.Point(0, 102)
        Me.FilterList.Margin = New System.Windows.Forms.Padding(4)
        Me.FilterList.Name = "FilterList"
        Me.FilterList.Size = New System.Drawing.Size(593, 478)
        Me.FilterList.TabIndex = 0
        '
        'ModeleSaisie_cbo
        '
        Me.Personnal_pnl.SetColumnSpan(Me.ModeleSaisie_cbo, 6)
        Me.ModeleSaisie_cbo.DataSource = Nothing
        Me.ModeleSaisie_cbo.DisplayMember = "Text"
        Me.ModeleSaisie_cbo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ModeleSaisie_cbo.DroppedDown = True
        Me.ModeleSaisie_cbo.Location = New System.Drawing.Point(5, 42)
        Me.ModeleSaisie_cbo.Margin = New System.Windows.Forms.Padding(5)
        Me.ModeleSaisie_cbo.Name = "ModeleSaisie_cbo"
        Me.ModeleSaisie_cbo.SelectedIndex = -1
        Me.ModeleSaisie_cbo.SelectedItem = Nothing
        Me.ModeleSaisie_cbo.SelectedValue = Nothing
        Me.ModeleSaisie_cbo.Size = New System.Drawing.Size(583, 23)
        Me.ModeleSaisie_cbo.TabIndex = 0
        Me.ModeleSaisie_cbo.ValueMember = ""
        '
        'GrdFilter_Simulation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.FilterList)
        Me.Controls.Add(Me.Personnal_pnl)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "GrdFilter_Simulation"
        Me.Size = New System.Drawing.Size(593, 580)
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.SelectAll_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.New_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Del_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FilterList As ud_CheckedListBox
    Friend WithEvents search_txt As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ModeleSaisie_cbo As ud_ComboBox
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents New_pb As PictureBox
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Del_pb As PictureBox
    Friend WithEvents SelectAll_pb As PictureBox
End Class
