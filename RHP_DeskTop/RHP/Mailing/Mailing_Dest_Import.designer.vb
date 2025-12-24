Imports System.Data.OleDb
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Mailing_Dest_Import
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtFichier = New RHP.ud_TextBox()
        Me.Grille = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Grille, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.LinkLabel1)
        Me.GroupBox2.Controls.Add(Me.txtFichier)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(757, 46)
        Me.GroupBox2.TabIndex = 156
        Me.GroupBox2.TabStop = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(35, 17)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(71, 14)
        Me.LinkLabel1.TabIndex = 170
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Chemin Excel"
        '
        'txtFichier
        '
        Me.txtFichier.BackColor = System.Drawing.SystemColors.Control
        Me.txtFichier.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtFichier.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFichier.Location = New System.Drawing.Point(112, 14)
        Me.txtFichier.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFichier.MaxLength = 32767
        Me.txtFichier.Multiline = False
        Me.txtFichier.Name = "txtFichier"
        Me.txtFichier.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.txtFichier.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtFichier.ReadOnly = True
        Me.txtFichier.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtFichier.SelectionStart = 0
        Me.txtFichier.Size = New System.Drawing.Size(625, 21)
        Me.txtFichier.TabIndex = 116
        Me.txtFichier.TabStop = False
        Me.txtFichier.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtFichier.UseSystemPasswordChar = False
        '
        'Grille
        '
        Me.Grille.BackgroundColor = System.Drawing.Color.White
        Me.Grille.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Grille.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grille.EnableHeadersVisualStyles = False
        Me.Grille.Location = New System.Drawing.Point(3, 55)
        Me.Grille.Name = "Grille"
        Me.Grille.RowHeadersWidth = 20
        Me.Grille.Size = New System.Drawing.Size(757, 600)
        Me.Grille.TabIndex = 157
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(819, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(174, 16)
        Me.Label3.TabIndex = 169
        Me.Label3.Text = "Liste des champs d'importation"
        '
        'Mailing_Dest_Import
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1223, 697)
        Me.Controls.Add(Me.Grille)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Mailing_Dest_Import"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = ""
        Me.Text = "Importer liste des destinataires"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Grille, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grille As DataGridView
    Friend WithEvents txtFichier As ud_TextBox
    Private WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
End Class
