Imports System.Data.OleDb
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Cnss_DamanCom_Import
    Inherits Ecran

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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Importer_btn = New RHP.ud_button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Combo_oModeleImport = New RHP.ud_ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ExcelSheets = New RHP.ud_ComboBox()
        Me.txtFichier = New RHP.ud_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BKW_Import = New System.ComponentModel.BackgroundWorker()
        Me.pnlChamps = New System.Windows.Forms.Panel()
        Me.oTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ud_Pnl = New RHP.ud_Panel()
        Me.entete_pnl = New System.Windows.Forms.Panel()
        Me.Titre_lbl = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.entete_pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Importer_btn)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Combo_oModeleImport)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.ExcelSheets)
        Me.GroupBox2.Controls.Add(Me.txtFichier)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(256, 38)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1010, 102)
        Me.GroupBox2.TabIndex = 156
        Me.GroupBox2.TabStop = False
        '
        'Importer_btn
        '
        Me.Importer_btn.AutoSize = True
        Me.Importer_btn.Border = RHP.ud_button.BorderStyle.None
        Me.Importer_btn.BorderColor = System.Drawing.Color.Empty
        Me.Importer_btn.BorderSize = 0
        Me.Importer_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Importer_btn.Image = Global.RHP.My.Resources.Resources.btn_import
        Me.Importer_btn.Location = New System.Drawing.Point(613, 47)
        Me.Importer_btn.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Importer_btn.Name = "Importer_btn"
        Me.Importer_btn.Size = New System.Drawing.Size(25, 25)
        Me.Importer_btn.TabIndex = 180
        Me.Importer_btn.ToolTip = "Importer les données depuis Excel"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(55, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 16)
        Me.Label3.TabIndex = 179
        Me.Label3.Text = "A importer"
        '
        'Combo_oModeleImport
        '
        Me.Combo_oModeleImport.DataSource = Nothing
        Me.Combo_oModeleImport.DisplayMember = ""
        Me.Combo_oModeleImport.DroppedDown = True
        Me.Combo_oModeleImport.Location = New System.Drawing.Point(121, 21)
        Me.Combo_oModeleImport.Name = "Combo_oModeleImport"
        Me.Combo_oModeleImport.SelectedIndex = -1
        Me.Combo_oModeleImport.SelectedItem = Nothing
        Me.Combo_oModeleImport.SelectedValue = Nothing
        Me.Combo_oModeleImport.Size = New System.Drawing.Size(486, 22)
        Me.Combo_oModeleImport.TabIndex = 178
        Me.Combo_oModeleImport.ValueMember = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(78, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 177
        Me.Label2.Text = "Feuille"
        '
        'ExcelSheets
        '
        Me.ExcelSheets.DataSource = Nothing
        Me.ExcelSheets.DisplayMember = ""
        Me.ExcelSheets.DroppedDown = True
        Me.ExcelSheets.Location = New System.Drawing.Point(121, 73)
        Me.ExcelSheets.Name = "ExcelSheets"
        Me.ExcelSheets.SelectedIndex = -1
        Me.ExcelSheets.SelectedItem = Nothing
        Me.ExcelSheets.SelectedValue = Nothing
        Me.ExcelSheets.Size = New System.Drawing.Size(486, 22)
        Me.ExcelSheets.TabIndex = 176
        Me.ExcelSheets.ValueMember = ""
        '
        'txtFichier
        '
        Me.txtFichier.BackColor = System.Drawing.SystemColors.Control
        Me.txtFichier.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtFichier.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFichier.Location = New System.Drawing.Point(121, 46)
        Me.txtFichier.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFichier.MaxLength = 32767
        Me.txtFichier.Multiline = False
        Me.txtFichier.Name = "txtFichier"
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
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(37, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 16)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Chemin Excel"
        '
        'BKW_Import
        '
        Me.BKW_Import.WorkerReportsProgress = True
        Me.BKW_Import.WorkerSupportsCancellation = True
        '
        'pnlChamps
        '
        Me.pnlChamps.AutoScroll = True
        Me.pnlChamps.BackColor = System.Drawing.Color.White
        Me.pnlChamps.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlChamps.Location = New System.Drawing.Point(0, 38)
        Me.pnlChamps.Name = "pnlChamps"
        Me.pnlChamps.Size = New System.Drawing.Size(256, 687)
        Me.pnlChamps.TabIndex = 0
        '
        'oTimer
        '
        '
        'ud_Pnl
        '
        Me.ud_Pnl.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ud_Pnl.BorderSize = 2
        Me.ud_Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ud_Pnl.Location = New System.Drawing.Point(256, 140)
        Me.ud_Pnl.Name = "ud_Pnl"
        Me.ud_Pnl.Size = New System.Drawing.Size(1010, 585)
        Me.ud_Pnl.TabIndex = 157
        '
        'entete_pnl
        '
        Me.entete_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.entete_pnl.Controls.Add(Me.Titre_lbl)
        Me.entete_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.entete_pnl.Location = New System.Drawing.Point(0, 0)
        Me.entete_pnl.Name = "entete_pnl"
        Me.entete_pnl.Size = New System.Drawing.Size(1266, 38)
        Me.entete_pnl.TabIndex = 158
        '
        'Titre_lbl
        '
        Me.Titre_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Titre_lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Titre_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Titre_lbl.ForeColor = System.Drawing.Color.White
        Me.Titre_lbl.Location = New System.Drawing.Point(0, 0)
        Me.Titre_lbl.Name = "Titre_lbl"
        Me.Titre_lbl.Size = New System.Drawing.Size(1266, 38)
        Me.Titre_lbl.TabIndex = 33
        Me.Titre_lbl.Text = "Importation des données de la déclaration"
        Me.Titre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cnss_DamanCom_Import
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1266, 725)
        Me.Controls.Add(Me.ud_Pnl)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.pnlChamps)
        Me.Controls.Add(Me.entete_pnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Cnss_DamanCom_Import"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importation TVA Déduction"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.entete_pnl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents GroupBox2 As GroupBox
    Private WithEvents Label1 As Label
    Friend WithEvents ExcelSheets As ud_ComboBox
    Private WithEvents Label2 As Label
    Friend WithEvents BKW_Import As BackgroundWorker
    Friend WithEvents pnlChamps As Panel
    Friend WithEvents oTimer As Timer
    Friend WithEvents Combo_oModeleImport As ud_ComboBox
    Private WithEvents Label3 As Label
    Friend WithEvents ud_Pnl As ud_Panel
    Friend WithEvents txtFichier As ud_TextBox
    Friend WithEvents Importer_btn As ud_button
    Friend WithEvents entete_pnl As Panel
    Friend WithEvents Titre_lbl As Label
End Class
