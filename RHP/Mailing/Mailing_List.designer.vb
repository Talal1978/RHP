<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Mailing_List
    Inherits Ecran

    'Form rEmplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.COD = New System.Windows.Forms.LinkLabel()
        Me.Cod_list_Text = New RHP.ud_TextBox()
        Me.Lib_List_Text = New RHP.ud_TextBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Grd_Destinataire = New RHP.ud_Grd()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.Grd_Destinataire, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Personnal_pnl.ColumnCount = 2
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Personnal_pnl.Controls.Add(Me.ButtonX1, 0, 0)
        Me.Personnal_pnl.Location = New System.Drawing.Point(0, 0)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(200, 100)
        Me.Personnal_pnl.TabIndex = 0
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonX1.Location = New System.Drawing.Point(16, 38)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(67, 23)
        Me.ButtonX1.TabIndex = 0
        Me.ButtonX1.Text = "OK"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonX2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX2.Location = New System.Drawing.Point(36, 3)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(28, 8)
        Me.ButtonX2.TabIndex = 1
        Me.ButtonX2.Text = "Annuler"
        '
        'COD
        '
        Me.COD.AutoSize = True
        Me.COD.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.COD.Location = New System.Drawing.Point(41, 19)
        Me.COD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.COD.Name = "COD"
        Me.COD.Size = New System.Drawing.Size(37, 19)
        Me.COD.TabIndex = 0
        Me.COD.TabStop = True
        Me.COD.Tag = ""
        Me.COD.Text = "Liste"
        '
        'Cod_list_Text
        '
        Me.Cod_list_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_list_Text.ContextMenuStrip = Nothing
        Me.Cod_list_Text.Location = New System.Drawing.Point(86, 15)
        Me.Cod_list_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Cod_list_Text.MaxLength = 32767
        Me.Cod_list_Text.Multiline = False
        Me.Cod_list_Text.Name = "Cod_list_Text"
        Me.Cod_list_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_list_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_list_Text.ReadOnly = True
        Me.Cod_list_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_list_Text.SelectionStart = 0
        Me.Cod_list_Text.Size = New System.Drawing.Size(204, 26)
        Me.Cod_list_Text.TabIndex = 71
        Me.Cod_list_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_list_Text.UseSystemPasswordChar = False
        '
        'Lib_List_Text
        '
        Me.Lib_List_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_List_Text.ContextMenuStrip = Nothing
        Me.Lib_List_Text.Location = New System.Drawing.Point(298, 15)
        Me.Lib_List_Text.Margin = New System.Windows.Forms.Padding(5)
        Me.Lib_List_Text.MaxLength = 50
        Me.Lib_List_Text.Multiline = False
        Me.Lib_List_Text.Name = "Lib_List_Text"
        Me.Lib_List_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_List_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_List_Text.ReadOnly = False
        Me.Lib_List_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_List_Text.SelectionStart = 0
        Me.Lib_List_Text.Size = New System.Drawing.Size(815, 26)
        Me.Lib_List_Text.TabIndex = 72
        Me.Lib_List_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_List_Text.UseSystemPasswordChar = False
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Cod_list_Text)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Lib_List_Text)
        Me.SplitContainer2.Panel1.Controls.Add(Me.COD)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Grd_Destinataire)
        Me.SplitContainer2.Size = New System.Drawing.Size(1128, 796)
        Me.SplitContainer2.SplitterDistance = 54
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 73
        '
        'Grd_Destinataire
        '
        Me.Grd_Destinataire.AfficherLesEntetesLignes = True
        Me.Grd_Destinataire.AllowUserToAddRows = False
        Me.Grd_Destinataire.AllowUserToDeleteRows = False
        Me.Grd_Destinataire.AllowUserToOrderColumns = True
        Me.Grd_Destinataire.AlternerLesLignes = False
        Me.Grd_Destinataire.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd_Destinataire.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grd_Destinataire.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grd_Destinataire.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grd_Destinataire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grd_Destinataire.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grd_Destinataire.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Destinataire.EnableHeadersVisualStyles = False
        Me.Grd_Destinataire.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd_Destinataire.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Destinataire.Margin = New System.Windows.Forms.Padding(4)
        Me.Grd_Destinataire.Name = "Grd_Destinataire"
        Me.Grd_Destinataire.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Grd_Destinataire.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grd_Destinataire.RowHeadersVisible = False
        Me.Grd_Destinataire.RowHeadersWidth = 51
        Me.Grd_Destinataire.Size = New System.Drawing.Size(1128, 737)
        Me.Grd_Destinataire.TabIndex = 85
        '
        'Mailing_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1128, 796)
        Me.Controls.Add(Me.SplitContainer2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Mailing_List"
        Me.Tag = "ECR"
        Me.Text = "Mailing list"
        Me.Personnal_pnl.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.Grd_Destinataire, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Personnal_pnl As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents COD As System.Windows.Forms.LinkLabel
    Friend WithEvents Cod_list_Text As ud_TextBox
    Friend WithEvents Lib_List_Text As ud_TextBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents Grd_Destinataire As ud_Grd
End Class
