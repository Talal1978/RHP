<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ud_RichTextBox
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ud_RichTextBox))
        Me.Rtb_Menus = New System.Windows.Forms.ToolStrip()
        Me.Ouvrir = New System.Windows.Forms.ToolStripButton()
        Me.Enregistrer = New System.Windows.Forms.ToolStripButton()
        Me.FontToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.FontColorToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.BoldToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.UnderlineToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.LeftToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CenterToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.RightToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BulletsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SpellcheckToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PasteToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.rtb = New System.Windows.Forms.RichTextBox()
        Me.FontDlg = New System.Windows.Forms.FontDialog()
        Me.ColorDlg = New System.Windows.Forms.ColorDialog()
        Me.SpellChecker = New NetSpell.SpellChecker.Spelling(Me.components)
        Me.Rtb_Menus.SuspendLayout()
        Me.SuspendLayout()
        '
        'Rtb_Menus
        '
        Me.Rtb_Menus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Rtb_Menus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Ouvrir, Me.Enregistrer, Me.FontToolStripButton, Me.FontColorToolStripButton, Me.BoldToolStripButton, Me.UnderlineToolStripButton, Me.ToolStripSeparator4, Me.LeftToolStripButton, Me.CenterToolStripButton, Me.RightToolStripButton, Me.ToolStripSeparator3, Me.BulletsToolStripButton, Me.SpellcheckToolStripButton, Me.ToolStripSeparator2, Me.CutToolStripButton, Me.CopyToolStripButton, Me.PasteToolStripButton, Me.toolStripSeparator1, Me.toolStripSeparator})
        Me.Rtb_Menus.Location = New System.Drawing.Point(0, 0)
        Me.Rtb_Menus.Name = "Rtb_Menus"
        Me.Rtb_Menus.Size = New System.Drawing.Size(532, 25)
        Me.Rtb_Menus.TabIndex = 2
        Me.Rtb_Menus.Text = "ToolStrip2"
        '
        'Ouvrir
        '
        Me.Ouvrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Ouvrir.Image = CType(resources.GetObject("Ouvrir.Image"), System.Drawing.Image)
        Me.Ouvrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Ouvrir.Name = "Ouvrir"
        Me.Ouvrir.Size = New System.Drawing.Size(23, 22)
        Me.Ouvrir.Text = "ToolStripButton1"
        Me.Ouvrir.ToolTipText = "Ouvrir"
        '
        'Enregistrer
        '
        Me.Enregistrer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Enregistrer.Image = CType(resources.GetObject("Enregistrer.Image"), System.Drawing.Image)
        Me.Enregistrer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Enregistrer.Name = "Enregistrer"
        Me.Enregistrer.Size = New System.Drawing.Size(23, 22)
        Me.Enregistrer.Text = "&Enregistrer"
        Me.Enregistrer.Visible = False
        '
        'FontToolStripButton
        '
        Me.FontToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FontToolStripButton.Image = CType(resources.GetObject("FontToolStripButton.Image"), System.Drawing.Image)
        Me.FontToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FontToolStripButton.Name = "FontToolStripButton"
        Me.FontToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.FontToolStripButton.Text = "Font"
        '
        'FontColorToolStripButton
        '
        Me.FontColorToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FontColorToolStripButton.Image = CType(resources.GetObject("FontColorToolStripButton.Image"), System.Drawing.Image)
        Me.FontColorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FontColorToolStripButton.Name = "FontColorToolStripButton"
        Me.FontColorToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.FontColorToolStripButton.Text = "Font Color"
        '
        'BoldToolStripButton
        '
        Me.BoldToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BoldToolStripButton.Image = CType(resources.GetObject("BoldToolStripButton.Image"), System.Drawing.Image)
        Me.BoldToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BoldToolStripButton.Name = "BoldToolStripButton"
        Me.BoldToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.BoldToolStripButton.Text = "Bold"
        '
        'UnderlineToolStripButton
        '
        Me.UnderlineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UnderlineToolStripButton.Image = CType(resources.GetObject("UnderlineToolStripButton.Image"), System.Drawing.Image)
        Me.UnderlineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UnderlineToolStripButton.Name = "UnderlineToolStripButton"
        Me.UnderlineToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.UnderlineToolStripButton.Text = "Underline"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'LeftToolStripButton
        '
        Me.LeftToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LeftToolStripButton.Image = CType(resources.GetObject("LeftToolStripButton.Image"), System.Drawing.Image)
        Me.LeftToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LeftToolStripButton.Name = "LeftToolStripButton"
        Me.LeftToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.LeftToolStripButton.Text = "Left"
        '
        'CenterToolStripButton
        '
        Me.CenterToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CenterToolStripButton.Image = CType(resources.GetObject("CenterToolStripButton.Image"), System.Drawing.Image)
        Me.CenterToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CenterToolStripButton.Name = "CenterToolStripButton"
        Me.CenterToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CenterToolStripButton.Text = "Center"
        '
        'RightToolStripButton
        '
        Me.RightToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RightToolStripButton.Image = CType(resources.GetObject("RightToolStripButton.Image"), System.Drawing.Image)
        Me.RightToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RightToolStripButton.Name = "RightToolStripButton"
        Me.RightToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.RightToolStripButton.Text = "Right"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BulletsToolStripButton
        '
        Me.BulletsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BulletsToolStripButton.Image = CType(resources.GetObject("BulletsToolStripButton.Image"), System.Drawing.Image)
        Me.BulletsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BulletsToolStripButton.Name = "BulletsToolStripButton"
        Me.BulletsToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.BulletsToolStripButton.Text = "Bullets"
        '
        'SpellcheckToolStripButton
        '
        Me.SpellcheckToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SpellcheckToolStripButton.Image = CType(resources.GetObject("SpellcheckToolStripButton.Image"), System.Drawing.Image)
        Me.SpellcheckToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SpellcheckToolStripButton.Name = "SpellcheckToolStripButton"
        Me.SpellcheckToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SpellcheckToolStripButton.Text = "Spell Check"
        Me.SpellcheckToolStripButton.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutToolStripButton.Image = CType(resources.GetObject("CutToolStripButton.Image"), System.Drawing.Image)
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CutToolStripButton.Text = "C&ut"
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CopyToolStripButton.Text = "&Copy"
        '
        'PasteToolStripButton
        '
        Me.PasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PasteToolStripButton.Image = CType(resources.GetObject("PasteToolStripButton.Image"), System.Drawing.Image)
        Me.PasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripButton.Name = "PasteToolStripButton"
        Me.PasteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PasteToolStripButton.Text = "&Paste"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'rtb
        '
        Me.rtb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb.Location = New System.Drawing.Point(0, 25)
        Me.rtb.Name = "rtb"
        Me.rtb.Size = New System.Drawing.Size(532, 338)
        Me.rtb.TabIndex = 3
        Me.rtb.Text = ""
        '
        'SpellChecker
        '
        Me.SpellChecker.Dictionary = Nothing
        '
        'ud_RichTextBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.rtb)
        Me.Controls.Add(Me.Rtb_Menus)
        Me.Name = "ud_RichTextBox"
        Me.Size = New System.Drawing.Size(532, 363)
        Me.Rtb_Menus.ResumeLayout(False)
        Me.Rtb_Menus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Rtb_Menus As ToolStrip
    Friend WithEvents FontToolStripButton As ToolStripButton
    Friend WithEvents FontColorToolStripButton As ToolStripButton
    Friend WithEvents BoldToolStripButton As ToolStripButton
    Friend WithEvents UnderlineToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents LeftToolStripButton As ToolStripButton
    Friend WithEvents CenterToolStripButton As ToolStripButton
    Friend WithEvents RightToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BulletsToolStripButton As ToolStripButton
    Friend WithEvents SpellcheckToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents CutToolStripButton As ToolStripButton
    Friend WithEvents CopyToolStripButton As ToolStripButton
    Friend WithEvents PasteToolStripButton As ToolStripButton
    Friend WithEvents toolStripSeparator1 As ToolStripSeparator
    Friend WithEvents rtb As RichTextBox
    Friend WithEvents FontDlg As FontDialog
    Friend WithEvents ColorDlg As ColorDialog
    Friend WithEvents SpellChecker As NetSpell.SpellChecker.Spelling
    Friend WithEvents Enregistrer As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents Ouvrir As ToolStripButton
End Class
