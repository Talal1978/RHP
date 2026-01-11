<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Communication_Blogs
    Inherits Ecran

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Communication_Blogs))
        Me.Num_Blog_txt = New RHP.ud_TextBox()
        Me.Titre_Blog_Text = New RHP.ud_TextBox()
        Me.Categorie_Combo = New RHP.ud_ComboBox()
        Me.Tags_Text = New RHP.ud_TextBox()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.ToolsBar = New System.Windows.Forms.ToolStrip()
        Me.TBtn_Bold = New System.Windows.Forms.ToolStripButton()
        Me.TBtn_Italic = New System.Windows.Forms.ToolStripButton()
        Me.TBtn_Underline = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TBtn_Left = New System.Windows.Forms.ToolStripButton()
        Me.TBtn_Center = New System.Windows.Forms.ToolStripButton()
        Me.TBtn_Right = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TBtn_UnorderedList = New System.Windows.Forms.ToolStripButton()
        Me.TBtn_OrderedList = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TBtn_Image = New System.Windows.Forms.ToolStripButton()
        Me.TBtn_Link = New System.Windows.Forms.ToolStripButton()
        Me.TBtn_Color = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CompteGeneralLink = New System.Windows.Forms.LinkLabel()
        Me.Publier_chk = New RHP.ud_CheckBox()
        Me.ToolsBar.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Num_Blog_txt
        '
        Me.Num_Blog_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Num_Blog_txt.ContextMenuStrip = Nothing
        Me.Num_Blog_txt.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Num_Blog_txt.Location = New System.Drawing.Point(99, 39)
        Me.Num_Blog_txt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Num_Blog_txt.MaxLength = 32767
        Me.Num_Blog_txt.Multiline = False
        Me.Num_Blog_txt.Name = "Num_Blog_txt"
        Me.Num_Blog_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Num_Blog_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Num_Blog_txt.ReadOnly = True
        Me.Num_Blog_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Num_Blog_txt.SelectionStart = 0
        Me.Num_Blog_txt.Size = New System.Drawing.Size(289, 26)
        Me.Num_Blog_txt.TabIndex = 1
        Me.Num_Blog_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Num_Blog_txt.UseSystemPasswordChar = False
        '
        'Titre_Blog_Text
        '
        Me.Titre_Blog_Text.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Titre_Blog_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Titre_Blog_Text.ContextMenuStrip = Nothing
        Me.Titre_Blog_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Titre_Blog_Text.Location = New System.Drawing.Point(99, 70)
        Me.Titre_Blog_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Titre_Blog_Text.MaxLength = 32767
        Me.Titre_Blog_Text.Multiline = True
        Me.Titre_Blog_Text.Name = "Titre_Blog_Text"
        Me.Titre_Blog_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Titre_Blog_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Titre_Blog_Text.ReadOnly = False
        Me.Titre_Blog_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Titre_Blog_Text.SelectionStart = 0
        Me.Titre_Blog_Text.Size = New System.Drawing.Size(1012, 59)
        Me.Titre_Blog_Text.TabIndex = 2
        Me.Titre_Blog_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Titre_Blog_Text.UseSystemPasswordChar = False
        '
        'Categorie_Combo
        '
        Me.Categorie_Combo.DataSource = Nothing
        Me.Categorie_Combo.DisplayMember = ""
        Me.Categorie_Combo.DroppedDown = False
        Me.Categorie_Combo.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Categorie_Combo.Location = New System.Drawing.Point(99, 132)
        Me.Categorie_Combo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Categorie_Combo.Name = "Categorie_Combo"
        Me.Categorie_Combo.SelectedIndex = -1
        Me.Categorie_Combo.SelectedItem = Nothing
        Me.Categorie_Combo.SelectedValue = Nothing
        Me.Categorie_Combo.Size = New System.Drawing.Size(289, 26)
        Me.Categorie_Combo.TabIndex = 3
        Me.Categorie_Combo.ValueMember = ""
        '
        'Tags_Text
        '
        Me.Tags_Text.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tags_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Tags_Text.ContextMenuStrip = Nothing
        Me.Tags_Text.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Tags_Text.Location = New System.Drawing.Point(99, 163)
        Me.Tags_Text.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Tags_Text.MaxLength = 32767
        Me.Tags_Text.Multiline = False
        Me.Tags_Text.Name = "Tags_Text"
        Me.Tags_Text.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Tags_Text.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Tags_Text.ReadOnly = False
        Me.Tags_Text.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Tags_Text.SelectionStart = 0
        Me.Tags_Text.Size = New System.Drawing.Size(1012, 26)
        Me.Tags_Text.TabIndex = 4
        Me.Tags_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Tags_Text.UseSystemPasswordChar = False
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 232)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(1144, 491)
        Me.WebBrowser1.TabIndex = 5
        '
        'ToolsBar
        '
        Me.ToolsBar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolsBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TBtn_Bold, Me.TBtn_Italic, Me.TBtn_Underline, Me.ToolStripSeparator1, Me.TBtn_Left, Me.TBtn_Center, Me.TBtn_Right, Me.ToolStripSeparator2, Me.TBtn_UnorderedList, Me.TBtn_OrderedList, Me.ToolStripSeparator3, Me.TBtn_Image, Me.TBtn_Link, Me.TBtn_Color})
        Me.ToolsBar.Location = New System.Drawing.Point(0, 201)
        Me.ToolsBar.Name = "ToolsBar"
        Me.ToolsBar.Size = New System.Drawing.Size(1144, 31)
        Me.ToolsBar.TabIndex = 15
        Me.ToolsBar.Text = "ToolsBar"
        '
        'TBtn_Bold
        '
        Me.TBtn_Bold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TBtn_Bold.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TBtn_Bold.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TBtn_Bold.Name = "TBtn_Bold"
        Me.TBtn_Bold.Size = New System.Drawing.Size(29, 28)
        Me.TBtn_Bold.Text = "G"
        Me.TBtn_Bold.ToolTipText = "Gras"
        '
        'TBtn_Italic
        '
        Me.TBtn_Italic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TBtn_Italic.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.TBtn_Italic.Image = Global.RHP.My.Resources.Resources.ef_e
        Me.TBtn_Italic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TBtn_Italic.Name = "TBtn_Italic"
        Me.TBtn_Italic.Size = New System.Drawing.Size(29, 28)
        Me.TBtn_Italic.Text = "i"
        Me.TBtn_Italic.ToolTipText = "Italique"
        '
        'TBtn_Underline
        '
        Me.TBtn_Underline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TBtn_Underline.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline)
        Me.TBtn_Underline.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TBtn_Underline.Name = "TBtn_Underline"
        Me.TBtn_Underline.Size = New System.Drawing.Size(29, 28)
        Me.TBtn_Underline.Text = "S"
        Me.TBtn_Underline.ToolTipText = "Souligné"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'TBtn_Left
        '
        Me.TBtn_Left.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TBtn_Left.Image = CType(resources.GetObject("TBtn_Left.Image"), System.Drawing.Image)
        Me.TBtn_Left.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TBtn_Left.Name = "TBtn_Left"
        Me.TBtn_Left.Size = New System.Drawing.Size(29, 28)
        Me.TBtn_Left.Text = "L"
        Me.TBtn_Left.ToolTipText = "Aligner à gauche"
        '
        'TBtn_Center
        '
        Me.TBtn_Center.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TBtn_Center.Image = CType(resources.GetObject("TBtn_Center.Image"), System.Drawing.Image)
        Me.TBtn_Center.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TBtn_Center.Name = "TBtn_Center"
        Me.TBtn_Center.Size = New System.Drawing.Size(29, 28)
        Me.TBtn_Center.Text = "C"
        Me.TBtn_Center.ToolTipText = "Centrer"
        '
        'TBtn_Right
        '
        Me.TBtn_Right.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TBtn_Right.Image = CType(resources.GetObject("TBtn_Right.Image"), System.Drawing.Image)
        Me.TBtn_Right.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TBtn_Right.Name = "TBtn_Right"
        Me.TBtn_Right.Size = New System.Drawing.Size(29, 28)
        Me.TBtn_Right.Text = "R"
        Me.TBtn_Right.ToolTipText = "Aligner à droite"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'TBtn_UnorderedList
        '
        Me.TBtn_UnorderedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TBtn_UnorderedList.Image = CType(resources.GetObject("TBtn_UnorderedList.Image"), System.Drawing.Image)
        Me.TBtn_UnorderedList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TBtn_UnorderedList.Name = "TBtn_UnorderedList"
        Me.TBtn_UnorderedList.Size = New System.Drawing.Size(29, 28)
        Me.TBtn_UnorderedList.Text = "•"
        Me.TBtn_UnorderedList.ToolTipText = "Liste à puces"
        '
        'TBtn_OrderedList
        '
        Me.TBtn_OrderedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TBtn_OrderedList.Image = CType(resources.GetObject("TBtn_OrderedList.Image"), System.Drawing.Image)
        Me.TBtn_OrderedList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TBtn_OrderedList.Name = "TBtn_OrderedList"
        Me.TBtn_OrderedList.Size = New System.Drawing.Size(29, 28)
        Me.TBtn_OrderedList.Text = "1."
        Me.TBtn_OrderedList.ToolTipText = "Liste numérotée"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'TBtn_Image
        '
        Me.TBtn_Image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TBtn_Image.Image = CType(resources.GetObject("TBtn_Image.Image"), System.Drawing.Image)
        Me.TBtn_Image.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TBtn_Image.Name = "TBtn_Image"
        Me.TBtn_Image.Size = New System.Drawing.Size(29, 28)
        Me.TBtn_Image.Text = "IMG"
        Me.TBtn_Image.ToolTipText = "Insérer Image"
        '
        'TBtn_Link
        '
        Me.TBtn_Link.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TBtn_Link.Image = Global.RHP.My.Resources.Resources.Link
        Me.TBtn_Link.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TBtn_Link.Name = "TBtn_Link"
        Me.TBtn_Link.Size = New System.Drawing.Size(29, 28)
        Me.TBtn_Link.Text = "LINK"
        Me.TBtn_Link.ToolTipText = "Insérer Lien"
        '
        'TBtn_Color
        '
        Me.TBtn_Color.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TBtn_Color.Image = CType(resources.GetObject("TBtn_Color.Image"), System.Drawing.Image)
        Me.TBtn_Color.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TBtn_Color.Name = "TBtn_Color"
        Me.TBtn_Color.Size = New System.Drawing.Size(29, 28)
        Me.TBtn_Color.Text = "A"
        Me.TBtn_Color.ToolTipText = "Couleur du texte"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(61, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 19)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Titre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 19)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Catégorie"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 167)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 19)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Tags"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CompteGeneralLink)
        Me.GroupBox1.Controls.Add(Me.Publier_chk)
        Me.GroupBox1.Controls.Add(Me.Num_Blog_txt)
        Me.GroupBox1.Controls.Add(Me.Titre_Blog_Text)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Categorie_Combo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Tags_Text)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 15, 3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1144, 201)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Détails du Blog"
        '
        'CompteGeneralLink
        '
        Me.CompteGeneralLink.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CompteGeneralLink.AutoSize = True
        Me.CompteGeneralLink.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CompteGeneralLink.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CompteGeneralLink.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CompteGeneralLink.Location = New System.Drawing.Point(36, 41)
        Me.CompteGeneralLink.Name = "CompteGeneralLink"
        Me.CompteGeneralLink.Size = New System.Drawing.Size(60, 19)
        Me.CompteGeneralLink.TabIndex = 14
        Me.CompteGeneralLink.TabStop = True
        Me.CompteGeneralLink.Tag = ""
        Me.CompteGeneralLink.Text = "N° blog"
        '
        'Publier_chk
        '
        Me.Publier_chk.AutoSize = True
        Me.Publier_chk.Checked = False
        Me.Publier_chk.Location = New System.Drawing.Point(407, 33)
        Me.Publier_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Publier_chk.MaximumSize = New System.Drawing.Size(0, 30)
        Me.Publier_chk.MinimumSize = New System.Drawing.Size(133, 30)
        Me.Publier_chk.Name = "Publier_chk"
        Me.Publier_chk.Size = New System.Drawing.Size(133, 30)
        Me.Publier_chk.TabIndex = 13
        Me.Publier_chk.Text = "Publier"
        '
        'Communication_Blogs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1144, 723)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.ToolsBar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Communication_Blogs"
        Me.Tag = "ECR"
        Me.Text = "Communication Blogs"
        Me.ToolsBar.ResumeLayout(False)
        Me.ToolsBar.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Num_Blog_txt As RHP.ud_TextBox
    Friend WithEvents Titre_Blog_Text As RHP.ud_TextBox
    Friend WithEvents Categorie_Combo As RHP.ud_ComboBox
    Friend WithEvents Tags_Text As RHP.ud_TextBox
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents ToolsBar As System.Windows.Forms.ToolStrip
    Friend WithEvents TBtn_Bold As System.Windows.Forms.ToolStripButton
    Friend WithEvents TBtn_Italic As System.Windows.Forms.ToolStripButton
    Friend WithEvents TBtn_Underline As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TBtn_Left As System.Windows.Forms.ToolStripButton
    Friend WithEvents TBtn_Center As System.Windows.Forms.ToolStripButton
    Friend WithEvents TBtn_Right As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TBtn_UnorderedList As System.Windows.Forms.ToolStripButton
    Friend WithEvents TBtn_OrderedList As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TBtn_Image As System.Windows.Forms.ToolStripButton
    Friend WithEvents TBtn_Link As System.Windows.Forms.ToolStripButton
    Friend WithEvents TBtn_Color As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Publier_chk As ud_CheckBox
    Friend WithEvents CompteGeneralLink As LinkLabel
End Class
