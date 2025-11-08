<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Parametrage_JournalPaie
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
        'Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        'Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        'Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        'Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MyGrd = New RHP.ud_Grd()
        Me.Cod_Champs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Champs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cod_Rubrique = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Propriete = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Format = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Cod_Plan_txt = New RHP.ud_TextBox()
        Me.Cod_Plan_Paie_ = New System.Windows.Forms.LinkLabel()
        Me.Lib_Plan_Paie_Text = New RHP.ud_TextBox()
        CType(Me.MyGrd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Personnal_pnl.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MyGrd
        '
        Me.MyGrd.AllowUserToAddRows = False
        Me.MyGrd.AllowUserToDeleteRows = False
        Me.MyGrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.MyGrd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.MyGrd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MyGrd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.MyGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MyGrd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cod_Champs, Me.Lib_Champs, Me.Cod_Rubrique, Me.Propriete, Me.Format})
        Me.MyGrd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyGrd.EnableHeadersVisualStyles = False
        Me.MyGrd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.MyGrd.Location = New System.Drawing.Point(0, 46)
        Me.MyGrd.Name = "MyGrd"
        Me.MyGrd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.MyGrd.Size = New System.Drawing.Size(788, 591)
        Me.MyGrd.TabIndex = 2
        '
        'Cod_Champs
        '
        Me.Cod_Champs.HeaderText = "Champs"
        Me.Cod_Champs.MinimumWidth = 120
        Me.Cod_Champs.Name = "Cod_Champs"
        Me.Cod_Champs.Width = 120
        '
        'Lib_Champs
        '
        Me.Lib_Champs.HeaderText = "Intitulé"
        Me.Lib_Champs.MaxInputLength = 50
        Me.Lib_Champs.MinimumWidth = 150
        Me.Lib_Champs.Name = "Lib_Champs"
        Me.Lib_Champs.Width = 150
        '
        'Cod_Rubrique
        '
        Me.Cod_Rubrique.HeaderText = "Rubrique"
        Me.Cod_Rubrique.MinimumWidth = 120
        Me.Cod_Rubrique.Name = "Cod_Rubrique"
        Me.Cod_Rubrique.ReadOnly = True
        Me.Cod_Rubrique.Width = 120
        '
        'Propriete
        '
        Me.Propriete.HeaderText = "Propriété"
        Me.Propriete.Items.AddRange(New Object() {"Valeur", "Nb", "Tx", "Base", "Cumul"})
        Me.Propriete.Name = "Propriete"
        Me.Propriete.Width = 61
        '
        'Format
        '
        Me.Format.HeaderText = "Format"
        Me.Format.Name = "Format"
        Me.Format.Width = 50
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Cod_Plan_txt)
        Me.Panel1.Controls.Add(Me.Cod_Plan_Paie_)
        Me.Panel1.Controls.Add(Me.Lib_Plan_Paie_Text)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(788, 46)
        Me.Panel1.TabIndex = 3
        '
        'Cod_Plan_txt
        '
        Me.Cod_Plan_txt.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Cod_Plan_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Plan_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Plan_txt.Location = New System.Drawing.Point(117, 6)
        Me.Cod_Plan_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cod_Plan_txt.MaxLength = 10
        Me.Cod_Plan_txt.Multiline = False
        Me.Cod_Plan_txt.Name = "Cod_Plan_txt"
        Me.Cod_Plan_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Plan_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Plan_txt.ReadOnly = False
        Me.Cod_Plan_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Plan_txt.SelectionStart = 0
        Me.Cod_Plan_txt.Size = New System.Drawing.Size(102, 21)
        Me.Cod_Plan_txt.TabIndex = 18
        Me.Cod_Plan_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Plan_txt.UseSystemPasswordChar = False
        '
        'Cod_Plan_Paie_
        '
        Me.Cod_Plan_Paie_.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Plan_Paie_.AutoSize = True
        Me.Cod_Plan_Paie_.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Cod_Plan_Paie_.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Cod_Plan_Paie_.Location = New System.Drawing.Point(81, 8)
        Me.Cod_Plan_Paie_.Name = "Cod_Plan_Paie_"
        Me.Cod_Plan_Paie_.Size = New System.Drawing.Size(32, 16)
        Me.Cod_Plan_Paie_.TabIndex = 20
        Me.Cod_Plan_Paie_.TabStop = True
        Me.Cod_Plan_Paie_.Text = "Plan"
        Me.Cod_Plan_Paie_.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'Lib_Plan_Paie_Text
        '
        Me.Lib_Plan_Paie_Text.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lib_Plan_Paie_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Lib_Plan_Paie_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Lib_Plan_Paie_Text.Location = New System.Drawing.Point(221, 6)
        Me.Lib_Plan_Paie_Text.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lib_Plan_Paie_Text.MaxLength = 32767
        Me.Lib_Plan_Paie_Text.Multiline = False
        Me.Lib_Plan_Paie_Text.Name = "Lib_Plan_Paie_Text"
        Me.Lib_Plan_Paie_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Lib_Plan_Paie_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Lib_Plan_Paie_Text.ReadOnly = False
        Me.Lib_Plan_Paie_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Lib_Plan_Paie_Text.SelectionStart = 0
        Me.Lib_Plan_Paie_Text.Size = New System.Drawing.Size(385, 21)
        Me.Lib_Plan_Paie_Text.TabIndex = 19
        Me.Lib_Plan_Paie_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Lib_Plan_Paie_Text.UseSystemPasswordChar = False
        '
        'RH_Parametrage_JournalPaie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(788, 637)
        Me.Controls.Add(Me.MyGrd)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RH_Parametrage_JournalPaie"
        Me.Tag = "ECR"
        Me.Text = "Paramétrage du journal de paie"
        CType(Me.MyGrd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Personnal_pnl.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Personnal_pnl As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents MyGrd As ud_Grd
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Cod_Plan_txt As ud_TextBox
    Friend WithEvents Cod_Plan_Paie_ As LinkLabel
    Friend WithEvents Lib_Plan_Paie_Text As ud_TextBox
    Friend WithEvents Cod_Champs As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Champs As DataGridViewTextBoxColumn
    Friend WithEvents Cod_Rubrique As DataGridViewTextBoxColumn
    Friend WithEvents Propriete As DataGridViewComboBoxColumn
    Friend WithEvents Format As DataGridViewComboBoxColumn
End Class
