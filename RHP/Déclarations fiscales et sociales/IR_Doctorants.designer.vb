Imports System.ComponentModel
Imports System.Runtime.CompilerServices

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IR_Doctorants
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
        Me.Grd = New ud_Grd
        Me.Contenu_Grp = New System.Windows.Forms.GroupBox()
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Contenu_Grp.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grd
        '
        Me.Grd.AllowUserToAddRows = False
        Me.Grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grd.Location = New System.Drawing.Point(3, 16)
        Me.Grd.Name = "Grd"
        Me.Grd.Size = New System.Drawing.Size(1185, 687)
        Me.Grd.TabIndex = 178
        '
        'Contenu_Grp
        '
        Me.Contenu_Grp.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Contenu_Grp.Controls.Add(Me.Grd)
        Me.Contenu_Grp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Contenu_Grp.Location = New System.Drawing.Point(0, 0)
        Me.Contenu_Grp.Name = "Contenu_Grp"
        Me.Contenu_Grp.Size = New System.Drawing.Size(1191, 706)
        Me.Contenu_Grp.TabIndex = 179
        Me.Contenu_Grp.TabStop = False
        Me.Contenu_Grp.Text = "Année de la déclaration : "
        '
        'IR_Doctorants
        '
        Me.ClientSize = New System.Drawing.Size(1191, 706)
        Me.Controls.Add(Me.Contenu_Grp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IR_Doctorants"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Liste des doctorants"
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Contenu_Grp.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grd As ud_Grd
    Friend WithEvents Contenu_Grp As GroupBox
End Class
