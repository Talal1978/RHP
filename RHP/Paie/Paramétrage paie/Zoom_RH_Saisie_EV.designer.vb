<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Zoom_RH_Saisie_EV
    Inherits Ecran

    'Form rEmplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.EV_GRD = New RHP.ud_Grd()
        Me.Cod_Rubrique = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Function = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Typ_Param = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Valeur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nom_Matricule_txt = New RHP.ud_TextBox()
        Me.LeMatricule_txt = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Actualiser_pb = New System.Windows.Forms.PictureBox()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.EV_GRD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.Actualiser_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'EV_GRD
        '
        Me.EV_GRD.AllowUserToAddRows = False
        Me.EV_GRD.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.EV_GRD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.EV_GRD.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.EV_GRD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.EV_GRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EV_GRD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.EV_GRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EV_GRD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cod_Rubrique, Me.Lib_Function, Me.Typ_Param, Me.Valeur})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(117, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EV_GRD.DefaultCellStyle = DataGridViewCellStyle3
        Me.EV_GRD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EV_GRD.EnableHeadersVisualStyles = False
        Me.EV_GRD.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.EV_GRD.Location = New System.Drawing.Point(2, 62)
        Me.EV_GRD.Name = "EV_GRD"
        Me.EV_GRD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.EV_GRD.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.EV_GRD.RowHeadersVisible = False
        Me.EV_GRD.Size = New System.Drawing.Size(646, 351)
        Me.EV_GRD.TabIndex = 0
        '
        'Cod_Rubrique
        '
        Me.Cod_Rubrique.HeaderText = "Variable"
        Me.Cod_Rubrique.Name = "Cod_Rubrique"
        '
        'Lib_Function
        '
        Me.Lib_Function.HeaderText = "Libellé"
        Me.Lib_Function.Name = "Lib_Function"
        Me.Lib_Function.Width = 300
        '
        'Typ_Param
        '
        Me.Typ_Param.HeaderText = "Type"
        Me.Typ_Param.Name = "Typ_Param"
        '
        'Valeur
        '
        Me.Valeur.HeaderText = "Valeur"
        Me.Valeur.MaxInputLength = 50
        Me.Valeur.Name = "Valeur"
        Me.Valeur.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Valeur.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Nom_Matricule_txt
        '
        Me.Nom_Matricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Matricule_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Nom_Matricule_txt.Location = New System.Drawing.Point(253, 4)
        Me.Nom_Matricule_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Nom_Matricule_txt.MaxLength = 32767
        Me.Nom_Matricule_txt.Multiline = False
        Me.Nom_Matricule_txt.Name = "Nom_Matricule_txt"
        Me.Nom_Matricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Matricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Matricule_txt.ReadOnly = True
        Me.Nom_Matricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Matricule_txt.SelectionStart = 0
        Me.Nom_Matricule_txt.Size = New System.Drawing.Size(335, 21)
        Me.Nom_Matricule_txt.TabIndex = 2
        Me.Nom_Matricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Matricule_txt.UseSystemPasswordChar = False
        '
        'LeMatricule_txt
        '
        Me.LeMatricule_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.LeMatricule_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.LeMatricule_txt.Location = New System.Drawing.Point(133, 4)
        Me.LeMatricule_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LeMatricule_txt.MaxLength = 32767
        Me.LeMatricule_txt.Multiline = False
        Me.LeMatricule_txt.Name = "LeMatricule_txt"
        Me.LeMatricule_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.LeMatricule_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.LeMatricule_txt.ReadOnly = True
        Me.LeMatricule_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.LeMatricule_txt.SelectionStart = 0
        Me.LeMatricule_txt.Size = New System.Drawing.Size(114, 21)
        Me.LeMatricule_txt.TabIndex = 1
        Me.LeMatricule_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.LeMatricule_txt.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(68, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Matricule"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Personnal_pnl.ColumnCount = 4
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.Personnal_pnl.Controls.Add(Me.Titre_lbl, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.Actualiser_pb, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.Save_pb, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.Close_pb, 3, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Personnal_pnl.Location = New System.Drawing.Point(2, 2)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(646, 30)
        Me.Personnal_pnl.TabIndex = 3
        '
        'Actualiser_pb
        '
        Me.Actualiser_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Actualiser_pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Actualiser_pb.Image = Global.RHP.My.Resources.Resources.btn_request
        Me.Actualiser_pb.InitialImage = Nothing
        Me.Actualiser_pb.Location = New System.Drawing.Point(33, 3)
        Me.Actualiser_pb.Name = "Actualiser_pb"
        Me.Actualiser_pb.Size = New System.Drawing.Size(24, 24)
        Me.Actualiser_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Actualiser_pb.TabIndex = 3
        Me.Actualiser_pb.TabStop = False
        '
        'Save_pb
        '
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_pb.InitialImage = Nothing
        Me.Save_pb.Location = New System.Drawing.Point(3, 3)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(24, 24)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Save_pb.TabIndex = 2
        Me.Save_pb.TabStop = False
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(619, 3)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(24, 24)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 4
        Me.Close_pb.TabStop = False
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Location = New System.Drawing.Point(63, 0)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(550, 28)
        Me.Titre_lbl.TabIndex = 34
        Me.Titre_lbl.Text = "Saisie des éléments Variables"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Nom_Matricule_txt, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LeMatricule_txt, 3, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(2, 32)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(646, 30)
        Me.TableLayoutPanel2.TabIndex = 35
        '
        'Zoom_RH_Saisie_EV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(650, 415)
        Me.ControlBox = False
        Me.Controls.Add(Me.EV_GRD)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.Personnal_pnl)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Zoom_RH_Saisie_EV"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saisie des éléments Variables"
        CType(Me.EV_GRD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.Actualiser_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EV_GRD As ud_Grd
    Friend WithEvents Cod_Rubrique As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lib_Function As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Typ_Param As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Valeur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nom_Matricule_txt As ud_TextBox
    Friend WithEvents LeMatricule_txt As ud_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents Actualiser_pb As PictureBox
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents Titre_lbl As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
End Class
