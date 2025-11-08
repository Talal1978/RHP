Imports System.ComponentModel
Imports System.Runtime.CompilerServices
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IR_Import
    inherits Ecran

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IR_Import))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Importer_btn = New RHP.ud_button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Combo_oModeleImport = New RHP.ud_ComboBox()
        Me.lblnb = New System.Windows.Forms.Label()
        Me.lblnbstr = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ExcelSheets = New RHP.ud_ComboBox()
        Me.txtFichier = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAvancement = New System.Windows.Forms.Label()
        Me.pnlChamps = New System.Windows.Forms.Panel()
        Me.BKW_ChargerFeuilleExcel = New System.ComponentModel.BackgroundWorker()
        Me.BKW_Import = New System.ComponentModel.BackgroundWorker()
        Me.oTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.ud_Pnl = New RHP.ud_Panel()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Importer_btn)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Combo_oModeleImport)
        Me.GroupBox2.Controls.Add(Me.lblnb)
        Me.GroupBox2.Controls.Add(Me.lblnbstr)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.ExcelSheets)
        Me.GroupBox2.Controls.Add(Me.txtFichier)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.lblAvancement)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(336, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1002, 120)
        Me.GroupBox2.TabIndex = 156
        Me.GroupBox2.TabStop = False
        '
        'Importer_btn
        '
        Me.Importer_btn.AutoSize = True
        Me.Importer_btn.bgColor = System.Drawing.Color.White
        Me.Importer_btn.Border = RHP.ud_button.BorderStyle.None
        Me.Importer_btn.BorderColor = System.Drawing.Color.Empty
        Me.Importer_btn.BorderSize = 0
        Me.Importer_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Importer_btn.Image = Global.RHP.My.Resources.Resources.btn_import
        Me.Importer_btn.isDefault = False
        Me.Importer_btn.Location = New System.Drawing.Point(656, 38)
        Me.Importer_btn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Importer_btn.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Importer_btn.Name = "Importer_btn"
        Me.Importer_btn.Size = New System.Drawing.Size(25, 25)
        Me.Importer_btn.TabIndex = 183
        Me.Importer_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Importer_btn.ToolTip = "Importer les données depuis Excel"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(71, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 19)
        Me.Label4.TabIndex = 182
        Me.Label4.Text = "A importer"
        '
        'Combo_oModeleImport
        '
        Me.Combo_oModeleImport.DataSource = Nothing
        Me.Combo_oModeleImport.DisplayMember = ""
        Me.Combo_oModeleImport.DroppedDown = True
        Me.Combo_oModeleImport.Location = New System.Drawing.Point(166, 13)
        Me.Combo_oModeleImport.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Combo_oModeleImport.Name = "Combo_oModeleImport"
        Me.Combo_oModeleImport.SelectedIndex = -1
        Me.Combo_oModeleImport.SelectedItem = Nothing
        Me.Combo_oModeleImport.SelectedValue = Nothing
        Me.Combo_oModeleImport.Size = New System.Drawing.Size(486, 22)
        Me.Combo_oModeleImport.TabIndex = 181
        Me.Combo_oModeleImport.ValueMember = ""
        '
        'lblnb
        '
        Me.lblnb.AutoSize = True
        Me.lblnb.BackColor = System.Drawing.Color.Transparent
        Me.lblnb.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.lblnb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblnb.Location = New System.Drawing.Point(140, 84)
        Me.lblnb.Name = "lblnb"
        Me.lblnb.Size = New System.Drawing.Size(17, 19)
        Me.lblnb.TabIndex = 180
        Me.lblnb.Text = "0"
        Me.lblnb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblnbstr
        '
        Me.lblnbstr.AutoSize = True
        Me.lblnbstr.BackColor = System.Drawing.Color.Transparent
        Me.lblnbstr.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.lblnbstr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblnbstr.Location = New System.Drawing.Point(62, 84)
        Me.lblnbstr.Name = "lblnbstr"
        Me.lblnbstr.Size = New System.Drawing.Size(95, 19)
        Me.lblnbstr.TabIndex = 165
        Me.lblnbstr.Text = "Total lignes : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(86, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 19)
        Me.Label3.TabIndex = 179
        Me.Label3.Text = "Feuille"
        '
        'ExcelSheets
        '
        Me.ExcelSheets.DataSource = Nothing
        Me.ExcelSheets.DisplayMember = ""
        Me.ExcelSheets.DroppedDown = True
        Me.ExcelSheets.Location = New System.Drawing.Point(166, 61)
        Me.ExcelSheets.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ExcelSheets.Name = "ExcelSheets"
        Me.ExcelSheets.SelectedIndex = -1
        Me.ExcelSheets.SelectedItem = Nothing
        Me.ExcelSheets.SelectedValue = Nothing
        Me.ExcelSheets.Size = New System.Drawing.Size(486, 22)
        Me.ExcelSheets.TabIndex = 178
        Me.ExcelSheets.ValueMember = ""
        '
        'txtFichier
        '
        Me.txtFichier.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtFichier.ContextMenuStrip = Nothing
        Me.txtFichier.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFichier.Location = New System.Drawing.Point(166, 38)
        Me.txtFichier.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFichier.MaxLength = 32767
        Me.txtFichier.Multiline = False
        Me.txtFichier.Name = "txtFichier"
        Me.txtFichier.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtFichier.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtFichier.ReadOnly = True
        Me.txtFichier.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtFichier.SelectionStart = 0
        Me.txtFichier.Size = New System.Drawing.Size(486, 21)
        Me.txtFichier.TabIndex = 116
        Me.txtFichier.TabStop = False
        Me.txtFichier.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtFichier.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(44, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 19)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Chemin Excel"
        '
        'lblAvancement
        '
        Me.lblAvancement.AutoSize = True
        Me.lblAvancement.Location = New System.Drawing.Point(465, 94)
        Me.lblAvancement.Name = "lblAvancement"
        Me.lblAvancement.Size = New System.Drawing.Size(0, 16)
        Me.lblAvancement.TabIndex = 170
        '
        'pnlChamps
        '
        Me.pnlChamps.AutoScroll = True
        Me.pnlChamps.BackColor = System.Drawing.Color.White
        Me.pnlChamps.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlChamps.Location = New System.Drawing.Point(0, 0)
        Me.pnlChamps.Name = "pnlChamps"
        Me.pnlChamps.Size = New System.Drawing.Size(336, 753)
        Me.pnlChamps.TabIndex = 0
        '
        'BKW_ChargerFeuilleExcel
        '
        Me.BKW_ChargerFeuilleExcel.WorkerReportsProgress = True
        Me.BKW_ChargerFeuilleExcel.WorkerSupportsCancellation = True
        '
        'BKW_Import
        '
        Me.BKW_Import.WorkerReportsProgress = True
        Me.BKW_Import.WorkerSupportsCancellation = True
        '
        'oTimer
        '
        '
        'ud_Pnl
        '
        Me.ud_Pnl.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ud_Pnl.BorderSize = 2
        Me.ud_Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ud_Pnl.Location = New System.Drawing.Point(336, 120)
        Me.ud_Pnl.Name = "ud_Pnl"
        Me.ud_Pnl.Size = New System.Drawing.Size(1002, 633)
        Me.ud_Pnl.TabIndex = 158
        '
        'IR_Import
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1338, 753)
        Me.Controls.Add(Me.ud_Pnl)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.pnlChamps)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IR_Import"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importation des déclarations fiscales"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblnbstr As System.Windows.Forms.Label
    Friend WithEvents lblAvancement As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents pnlChamps As Panel
    Private WithEvents Label3 As Label
    Friend WithEvents ExcelSheets As ud_ComboBox
    Friend WithEvents BKW_ChargerFeuilleExcel As BackgroundWorker
    Friend WithEvents BKW_Import As BackgroundWorker
    Friend WithEvents oTimer As Timer
    Friend WithEvents lblnb As Label
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Private WithEvents Label4 As Label
    Friend WithEvents Combo_oModeleImport As ud_ComboBox
    Friend WithEvents ud_Pnl As ud_Panel
    Friend WithEvents Importer_btn As ud_button
    Friend txtFichier As ud_TextBox
    Friend Label1 As System.Windows.Forms.Label
End Class
