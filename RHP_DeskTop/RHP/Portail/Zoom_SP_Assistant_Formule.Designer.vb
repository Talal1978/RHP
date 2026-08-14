<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_SP_Assistant_Formule
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

    'REMARQUE : la procédure suivante construit toute l'interface de l'assistant
    '(convention permanente : tout le code de design est dans ce .Designer.vb ;
    'le fichier .vb ne contient que la logique — parser, évaluateur miroir,
    'événements, résultat — et l'alimentation des données au chargement).
    'Disposition fixe, formulaire non redimensionnable.
    'Thème visuel des écrans exclusivement modaux (instruction permanente) :
    'identique à Zoom_SP_SqlSource — formulaire sans bordure cadré colorBase01,
    'bandeau titre gris clair (ent_pnl : Zoom_lbl + boutons icônes PictureBox),
    'panel de contenu clair.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.main = New System.Windows.Forms.TableLayoutPanel()
        Me.lblIntro = New System.Windows.Forms.Label()
        Me.grpElem = New System.Windows.Forms.GroupBox()
        Me.lstChamps = New System.Windows.Forms.ListBox()
        Me.btnInsererChamp = New System.Windows.Forms.Button()
        Me.lstGV = New System.Windows.Forms.ListBox()
        Me.btnInsererGV = New System.Windows.Forms.Button()
        Me.cmbExemples = New System.Windows.Forms.ComboBox()
        Me.lblChamps = New System.Windows.Forms.Label()
        Me.lblGV = New System.Windows.Forms.Label()
        Me.lblExemples = New System.Windows.Forms.Label()
        Me.btnOpPlus = New System.Windows.Forms.Button()
        Me.btnOpMoins = New System.Windows.Forms.Button()
        Me.btnOpMul = New System.Windows.Forms.Button()
        Me.btnOpDiv = New System.Windows.Forms.Button()
        Me.btnOpParenO = New System.Windows.Forms.Button()
        Me.btnOpParenF = New System.Windows.Forms.Button()
        Me.btnOpEgal = New System.Windows.Forms.Button()
        Me.btnOpDiff = New System.Windows.Forms.Button()
        Me.btnOpSup = New System.Windows.Forms.Button()
        Me.btnOpSupEgal = New System.Windows.Forms.Button()
        Me.btnOpInf = New System.Windows.Forms.Button()
        Me.btnOpInfEgal = New System.Windows.Forms.Button()
        Me.btnOpEt = New System.Windows.Forms.Button()
        Me.btnOpOu = New System.Windows.Forms.Button()
        Me.btnOpNon = New System.Windows.Forms.Button()
        Me.btnTexte = New System.Windows.Forms.Button()
        Me.btnDates = New System.Windows.Forms.Button()
        Me.btnNombres = New System.Windows.Forms.Button()
        Me.btnCondition = New System.Windows.Forms.Button()
        Me.btnAgregat = New System.Windows.Forms.Button()
        Me.btnAide = New System.Windows.Forms.Button()
        Me.grpFormule = New System.Windows.Forms.GroupBox()
        Me.txtFormule = New System.Windows.Forms.TextBox()
        Me.lblStatut = New System.Windows.Forms.Label()
        Me.grpTest = New System.Windows.Forms.GroupBox()
        Me.grdTest = New System.Windows.Forms.DataGridView()
        Me.colEl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCalculer = New System.Windows.Forms.Button()
        Me.lblResultat = New System.Windows.Forms.Label()
        Me.lblAideGV = New System.Windows.Forms.Label()
        Me.lblAideDates = New System.Windows.Forms.Label()
        Me.grpApercu = New System.Windows.Forms.GroupBox()
        Me.txtJson = New System.Windows.Forms.TextBox()
        Me.menuTexte = New System.Windows.Forms.ContextMenuStrip()
        Me.menuDates = New System.Windows.Forms.ContextMenuStrip()
        Me.menuNombres = New System.Windows.Forms.ContextMenuStrip()
        Me.menuCondition = New System.Windows.Forms.ContextMenuStrip()
        Me.menuAgregat = New System.Windows.Forms.ContextMenuStrip()
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Zoom_lbl = New System.Windows.Forms.Label()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.main.SuspendLayout()
        Me.grpElem.SuspendLayout()
        Me.grpFormule.SuspendLayout()
        Me.grpTest.SuspendLayout()
        CType(Me.grdTest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpApercu.SuspendLayout()
        Me.ent_pnl.SuspendLayout()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.main)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 47)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(896, 648)
        Me.Panel1.TabIndex = 1
        '
        'main
        '
        Me.main.ColumnCount = 1
        Me.main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.main.Controls.Add(Me.lblIntro, 0, 0)
        Me.main.Controls.Add(Me.grpElem, 0, 1)
        Me.main.Controls.Add(Me.grpFormule, 0, 2)
        Me.main.Controls.Add(Me.grpTest, 0, 3)
        Me.main.Controls.Add(Me.grpApercu, 0, 4)
        Me.main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.main.Location = New System.Drawing.Point(0, 0)
        Me.main.Name = "main"
        Me.main.Padding = New System.Windows.Forms.Padding(10, 8, 10, 8)
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.main.Size = New System.Drawing.Size(896, 648)
        Me.main.TabIndex = 0
        '
        'lblIntro
        '
        Me.lblIntro.AutoSize = False
        Me.lblIntro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIntro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblIntro.Location = New System.Drawing.Point(0, 0)
        Me.lblIntro.Name = "lblIntro"
        Me.lblIntro.Size = New System.Drawing.Size(870, 20)
        Me.lblIntro.TabIndex = 1
        Me.lblIntro.Text = "Composez la formule en cliquant : aucun code à écrire. Seuls les champs de la page, les variables GV_ et les opérateurs autorisés sont acceptés ; la syntaxe json du moteur est générée automatiquement."
        '
        'grpElem
        '
        Me.grpElem.Controls.Add(Me.lblChamps)
        Me.grpElem.Controls.Add(Me.lstChamps)
        Me.grpElem.Controls.Add(Me.btnInsererChamp)
        Me.grpElem.Controls.Add(Me.lblGV)
        Me.grpElem.Controls.Add(Me.lstGV)
        Me.grpElem.Controls.Add(Me.btnInsererGV)
        Me.grpElem.Controls.Add(Me.lblExemples)
        Me.grpElem.Controls.Add(Me.cmbExemples)
        Me.grpElem.Controls.Add(Me.btnOpPlus)
        Me.grpElem.Controls.Add(Me.btnOpMoins)
        Me.grpElem.Controls.Add(Me.btnOpMul)
        Me.grpElem.Controls.Add(Me.btnOpDiv)
        Me.grpElem.Controls.Add(Me.btnOpParenO)
        Me.grpElem.Controls.Add(Me.btnOpParenF)
        Me.grpElem.Controls.Add(Me.btnOpEgal)
        Me.grpElem.Controls.Add(Me.btnOpDiff)
        Me.grpElem.Controls.Add(Me.btnOpSup)
        Me.grpElem.Controls.Add(Me.btnOpSupEgal)
        Me.grpElem.Controls.Add(Me.btnOpInf)
        Me.grpElem.Controls.Add(Me.btnOpInfEgal)
        Me.grpElem.Controls.Add(Me.btnOpEt)
        Me.grpElem.Controls.Add(Me.btnOpOu)
        Me.grpElem.Controls.Add(Me.btnOpNon)
        Me.grpElem.Controls.Add(Me.btnTexte)
        Me.grpElem.Controls.Add(Me.btnDates)
        Me.grpElem.Controls.Add(Me.btnNombres)
        Me.grpElem.Controls.Add(Me.btnCondition)
        Me.grpElem.Controls.Add(Me.btnAgregat)
        Me.grpElem.Controls.Add(Me.btnAide)
        Me.grpElem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpElem.Location = New System.Drawing.Point(0, 0)
        Me.grpElem.Name = "grpElem"
        Me.grpElem.Size = New System.Drawing.Size(870, 244)
        Me.grpElem.TabIndex = 2
        Me.grpElem.TabStop = False
        Me.grpElem.Text = "1. Choisissez les éléments (double-clic pour insérer à la position du curseur)"
        '
        'lstChamps
        '
        Me.lstChamps.Location = New System.Drawing.Point(10, 36)
        Me.lstChamps.Name = "lstChamps"
        Me.lstChamps.Size = New System.Drawing.Size(330, 142)
        Me.lstChamps.TabIndex = 0
        '
        'btnInsererChamp
        '
        Me.btnInsererChamp.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnInsererChamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInsererChamp.Location = New System.Drawing.Point(10, 182)
        Me.btnInsererChamp.Name = "btnInsererChamp"
        Me.btnInsererChamp.Size = New System.Drawing.Size(330, 26)
        Me.btnInsererChamp.TabIndex = 1
        Me.btnInsererChamp.Text = "Insérer le champ sélectionné"
        '
        'lstGV
        '
        Me.lstGV.Location = New System.Drawing.Point(350, 36)
        Me.lstGV.Name = "lstGV"
        Me.lstGV.Size = New System.Drawing.Size(240, 142)
        Me.lstGV.TabIndex = 2
        '
        'btnInsererGV
        '
        Me.btnInsererGV.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnInsererGV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInsererGV.Location = New System.Drawing.Point(350, 182)
        Me.btnInsererGV.Name = "btnInsererGV"
        Me.btnInsererGV.Size = New System.Drawing.Size(240, 26)
        Me.btnInsererGV.TabIndex = 3
        Me.btnInsererGV.Text = "Insérer la variable"
        '
        'cmbExemples
        '
        Me.cmbExemples.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbExemples.Location = New System.Drawing.Point(150, 214)
        Me.cmbExemples.Name = "cmbExemples"
        Me.cmbExemples.Size = New System.Drawing.Size(440, 24)
        Me.cmbExemples.TabIndex = 4
        '
        'lblChamps
        '
        Me.lblChamps.AutoSize = False
        Me.lblChamps.Location = New System.Drawing.Point(10, 16)
        Me.lblChamps.Name = "lblChamps"
        Me.lblChamps.Size = New System.Drawing.Size(330, 20)
        Me.lblChamps.Text = "Champs de la page :"
        '
        'lblGV
        '
        Me.lblGV.AutoSize = False
        Me.lblGV.Location = New System.Drawing.Point(350, 16)
        Me.lblGV.Name = "lblGV"
        Me.lblGV.Size = New System.Drawing.Size(240, 20)
        Me.lblGV.Text = "Variables globales (automatiques) :"
        '
        'lblExemples
        '
        Me.lblExemples.AutoSize = False
        Me.lblExemples.Location = New System.Drawing.Point(10, 216)
        Me.lblExemples.Name = "lblExemples"
        Me.lblExemples.Size = New System.Drawing.Size(135, 20)
        Me.lblExemples.Text = "Partir d'un exemple :"
        '
        'Boutons opérateurs (le texte inséré est dans Tag ; géré par BtnOperateur_Click)
        '
        Me.btnOpPlus.Location = New System.Drawing.Point(600, 20)
        Me.btnOpPlus.Name = "btnOpPlus"
        Me.btnOpPlus.Tag = " + "
        Me.btnOpPlus.Text = "+"
        Me.btnOpPlus.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnOpPlus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnOpPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpPlus.Size = New System.Drawing.Size(62, 26)
        Me.btnOpMoins.Location = New System.Drawing.Point(668, 20)
        Me.btnOpMoins.Name = "btnOpMoins"
        Me.btnOpMoins.Tag = " - "
        Me.btnOpMoins.Text = "-"
        Me.btnOpMoins.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnOpMoins.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnOpMoins.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpMoins.Size = New System.Drawing.Size(62, 26)
        Me.btnOpMul.Location = New System.Drawing.Point(736, 20)
        Me.btnOpMul.Name = "btnOpMul"
        Me.btnOpMul.Tag = " * "
        Me.btnOpMul.Text = "*"
        Me.btnOpMul.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnOpMul.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnOpMul.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpMul.Size = New System.Drawing.Size(62, 26)
        Me.btnOpDiv.Location = New System.Drawing.Point(804, 20)
        Me.btnOpDiv.Name = "btnOpDiv"
        Me.btnOpDiv.Tag = " / "
        Me.btnOpDiv.Text = "/"
        Me.btnOpDiv.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnOpDiv.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnOpDiv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpDiv.Size = New System.Drawing.Size(62, 26)
        Me.btnOpParenO.Location = New System.Drawing.Point(600, 50)
        Me.btnOpParenO.Name = "btnOpParenO"
        Me.btnOpParenO.Tag = "("
        Me.btnOpParenO.Text = "("
        Me.btnOpParenO.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnOpParenO.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnOpParenO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpParenO.Size = New System.Drawing.Size(62, 26)
        Me.btnOpParenF.Location = New System.Drawing.Point(668, 50)
        Me.btnOpParenF.Name = "btnOpParenF"
        Me.btnOpParenF.Tag = ")"
        Me.btnOpParenF.Text = ")"
        Me.btnOpParenF.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnOpParenF.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnOpParenF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpParenF.Size = New System.Drawing.Size(62, 26)
        Me.btnOpEgal.Location = New System.Drawing.Point(736, 50)
        Me.btnOpEgal.Name = "btnOpEgal"
        Me.btnOpEgal.Tag = " = "
        Me.btnOpEgal.Text = "="
        Me.btnOpEgal.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnOpEgal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnOpEgal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpEgal.Size = New System.Drawing.Size(62, 26)
        Me.btnOpDiff.Location = New System.Drawing.Point(804, 50)
        Me.btnOpDiff.Name = "btnOpDiff"
        Me.btnOpDiff.Tag = " <> "
        Me.btnOpDiff.Text = "<>"
        Me.btnOpDiff.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnOpDiff.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnOpDiff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpDiff.Size = New System.Drawing.Size(62, 26)
        Me.btnOpSup.Location = New System.Drawing.Point(600, 80)
        Me.btnOpSup.Name = "btnOpSup"
        Me.btnOpSup.Tag = " > "
        Me.btnOpSup.Text = ">"
        Me.btnOpSup.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnOpSup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnOpSup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpSup.Size = New System.Drawing.Size(62, 26)
        Me.btnOpSupEgal.Location = New System.Drawing.Point(668, 80)
        Me.btnOpSupEgal.Name = "btnOpSupEgal"
        Me.btnOpSupEgal.Tag = " >= "
        Me.btnOpSupEgal.Text = ">="
        Me.btnOpSupEgal.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnOpSupEgal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnOpSupEgal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpSupEgal.Size = New System.Drawing.Size(62, 26)
        Me.btnOpInf.Location = New System.Drawing.Point(736, 80)
        Me.btnOpInf.Name = "btnOpInf"
        Me.btnOpInf.Tag = " < "
        Me.btnOpInf.Text = "<"
        Me.btnOpInf.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnOpInf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnOpInf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpInf.Size = New System.Drawing.Size(62, 26)
        Me.btnOpInfEgal.Location = New System.Drawing.Point(804, 80)
        Me.btnOpInfEgal.Name = "btnOpInfEgal"
        Me.btnOpInfEgal.Tag = " <= "
        Me.btnOpInfEgal.Text = "<="
        Me.btnOpInfEgal.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnOpInfEgal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnOpInfEgal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpInfEgal.Size = New System.Drawing.Size(62, 26)
        Me.btnOpEt.Location = New System.Drawing.Point(600, 110)
        Me.btnOpEt.Name = "btnOpEt"
        Me.btnOpEt.Tag = " ET "
        Me.btnOpEt.Text = "ET"
        Me.btnOpEt.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnOpEt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnOpEt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpEt.Size = New System.Drawing.Size(62, 26)
        Me.btnOpOu.Location = New System.Drawing.Point(668, 110)
        Me.btnOpOu.Name = "btnOpOu"
        Me.btnOpOu.Tag = " OU "
        Me.btnOpOu.Text = "OU"
        Me.btnOpOu.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnOpOu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnOpOu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpOu.Size = New System.Drawing.Size(62, 26)
        Me.btnOpNon.Location = New System.Drawing.Point(736, 110)
        Me.btnOpNon.Name = "btnOpNon"
        Me.btnOpNon.Tag = "NON "
        Me.btnOpNon.Text = "NON"
        Me.btnOpNon.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnOpNon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnOpNon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpNon.Size = New System.Drawing.Size(62, 26)
        '
        'Boutons des familles de fonctions (menus déroulants, alimentés au chargement)
        '
        Me.btnTexte.Location = New System.Drawing.Point(600, 144)
        Me.btnTexte.Name = "btnTexte"
        Me.btnTexte.Text = "Texte ▾"
        Me.btnTexte.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnTexte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnTexte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTexte.Size = New System.Drawing.Size(129, 26)
        Me.btnDates.Location = New System.Drawing.Point(737, 144)
        Me.btnDates.Name = "btnDates"
        Me.btnDates.Text = "Dates ▾"
        Me.btnDates.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnDates.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnDates.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDates.Size = New System.Drawing.Size(129, 26)
        Me.btnNombres.Location = New System.Drawing.Point(600, 174)
        Me.btnNombres.Name = "btnNombres"
        Me.btnNombres.Text = "Nombres ▾"
        Me.btnNombres.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnNombres.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnNombres.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNombres.Size = New System.Drawing.Size(129, 26)
        Me.btnCondition.Location = New System.Drawing.Point(737, 174)
        Me.btnCondition.Name = "btnCondition"
        Me.btnCondition.Text = "Condition ▾"
        Me.btnCondition.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnCondition.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCondition.Size = New System.Drawing.Size(129, 26)
        Me.btnAgregat.Location = New System.Drawing.Point(600, 204)
        Me.btnAgregat.Name = "btnAgregat"
        Me.btnAgregat.Text = "Tableau (somme…) ▾"
        Me.btnAgregat.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnAgregat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnAgregat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregat.Size = New System.Drawing.Size(129, 26)
        '
        'btnAide
        '
        Me.btnAide.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnAide.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAide.Location = New System.Drawing.Point(737, 204)
        Me.btnAide.Name = "btnAide"
        Me.btnAide.Size = New System.Drawing.Size(129, 26)
        Me.btnAide.TabIndex = 5
        Me.btnAide.Text = "? Guide pas à pas"
        '
        'grpFormule
        '
        Me.grpFormule.Controls.Add(Me.txtFormule)
        Me.grpFormule.Controls.Add(Me.lblStatut)
        Me.grpFormule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpFormule.Location = New System.Drawing.Point(0, 0)
        Me.grpFormule.Name = "grpFormule"
        Me.grpFormule.Size = New System.Drawing.Size(870, 100)
        Me.grpFormule.TabIndex = 3
        Me.grpFormule.TabStop = False
        Me.grpFormule.Text = "2. Votre formule"
        '
        'txtFormule
        '
        Me.txtFormule.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.txtFormule.Location = New System.Drawing.Point(10, 20)
        Me.txtFormule.Multiline = True
        Me.txtFormule.Name = "txtFormule"
        Me.txtFormule.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFormule.Size = New System.Drawing.Size(856, 44)
        Me.txtFormule.TabIndex = 0
        '
        'lblStatut
        '
        Me.lblStatut.AutoSize = False
        Me.lblStatut.Location = New System.Drawing.Point(10, 68)
        Me.lblStatut.Name = "lblStatut"
        Me.lblStatut.Size = New System.Drawing.Size(856, 32)
        Me.lblStatut.TabIndex = 1
        '
        'grpTest
        '
        Me.grpTest.Controls.Add(Me.grdTest)
        Me.grpTest.Controls.Add(Me.btnCalculer)
        Me.grpTest.Controls.Add(Me.lblResultat)
        Me.grpTest.Controls.Add(Me.lblAideGV)
        Me.grpTest.Controls.Add(Me.lblAideDates)
        Me.grpTest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpTest.Location = New System.Drawing.Point(0, 0)
        Me.grpTest.Name = "grpTest"
        Me.grpTest.Size = New System.Drawing.Size(870, 184)
        Me.grpTest.TabIndex = 4
        Me.grpTest.TabStop = False
        Me.grpTest.Text = "3. Testez la formule avec des valeurs (facultatif)"
        '
        'grdTest
        '
        Me.grdTest.AllowUserToAddRows = False
        Me.grdTest.AllowUserToDeleteRows = False
        Me.grdTest.AutoGenerateColumns = False
        Me.grdTest.BackgroundColor = System.Drawing.Color.White
        Me.grdTest.ColumnHeadersDefaultCellStyle.BackColor = colorBase01
        Me.grdTest.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.grdTest.ColumnHeadersDefaultCellStyle.Font = Me.Font
        Me.grdTest.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colEl, Me.colVal})
        Me.grdTest.EnableHeadersVisualStyles = False
        Me.grdTest.Location = New System.Drawing.Point(10, 20)
        Me.grdTest.Name = "grdTest"
        Me.grdTest.RowHeadersVisible = False
        Me.grdTest.Size = New System.Drawing.Size(560, 132)
        Me.grdTest.TabIndex = 0
        '
        'colEl
        '
        Me.colEl.HeaderText = "Élément de la formule"
        Me.colEl.Name = "colEl"
        Me.colEl.ReadOnly = True
        Me.colEl.Width = 350
        '
        'colVal
        '
        Me.colVal.HeaderText = "Valeur de test"
        Me.colVal.Name = "colVal"
        Me.colVal.Width = 190
        '
        'btnCalculer
        '
        Me.btnCalculer.BackColor = colorBase01
        Me.btnCalculer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCalculer.ForeColor = System.Drawing.Color.White
        Me.btnCalculer.Location = New System.Drawing.Point(580, 20)
        Me.btnCalculer.Name = "btnCalculer"
        Me.btnCalculer.Size = New System.Drawing.Size(140, 28)
        Me.btnCalculer.TabIndex = 1
        Me.btnCalculer.Text = "Calculer"
        '
        'lblResultat
        '
        Me.lblResultat.AutoSize = False
        Me.lblResultat.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblResultat.Location = New System.Drawing.Point(580, 56)
        Me.lblResultat.Name = "lblResultat"
        Me.lblResultat.Size = New System.Drawing.Size(286, 56)
        Me.lblResultat.TabIndex = 2
        Me.lblResultat.Text = "Résultat : —"
        '
        'lblAideGV
        '
        Me.lblAideGV.AutoSize = False
        Me.lblAideGV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblAideGV.Location = New System.Drawing.Point(580, 116)
        Me.lblAideGV.Name = "lblAideGV"
        Me.lblAideGV.Size = New System.Drawing.Size(286, 36)
        Me.lblAideGV.Text = "Les variables GV_ sont évaluées" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "automatiquement (date du jour…)."
        '
        'lblAideDates
        '
        Me.lblAideDates.AutoSize = False
        Me.lblAideDates.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblAideDates.Location = New System.Drawing.Point(10, 158)
        Me.lblAideDates.Name = "lblAideDates"
        Me.lblAideDates.Size = New System.Drawing.Size(850, 20)
        Me.lblAideDates.Text = "Dates au format jj/mm/aaaa ; pour une colonne de tableau, saisissez les valeurs des lignes séparées par des points-virgules (ex : 10 ; 20,5 ; 3)."
        '
        'grpApercu
        '
        Me.grpApercu.Controls.Add(Me.txtJson)
        Me.grpApercu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpApercu.Location = New System.Drawing.Point(0, 0)
        Me.grpApercu.Name = "grpApercu"
        Me.grpApercu.Size = New System.Drawing.Size(870, 50)
        Me.grpApercu.TabIndex = 5
        Me.grpApercu.TabStop = False
        Me.grpApercu.Text = "Syntaxe générée (automatique — rien à saisir)"
        '
        'txtJson
        '
        Me.txtJson.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtJson.Location = New System.Drawing.Point(10, 20)
        Me.txtJson.Name = "txtJson"
        Me.txtJson.ReadOnly = True
        Me.txtJson.Size = New System.Drawing.Size(856, 24)
        Me.txtJson.TabIndex = 0
        '
        'ent_pnl
        '
        Me.ent_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ent_pnl.ColumnCount = 3
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.ent_pnl.Controls.Add(Me.Zoom_lbl, 0, 0)
        Me.ent_pnl.Controls.Add(Me.Save_pb, 1, 0)
        Me.ent_pnl.Controls.Add(Me.Close_pb, 2, 0)
        Me.ent_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.ent_pnl.Location = New System.Drawing.Point(2, 2)
        Me.ent_pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.ent_pnl.Name = "ent_pnl"
        Me.ent_pnl.RowCount = 1
        Me.ent_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ent_pnl.Size = New System.Drawing.Size(896, 45)
        Me.ent_pnl.TabIndex = 0
        '
        'Zoom_lbl
        '
        Me.Zoom_lbl.BackColor = System.Drawing.Color.Transparent
        Me.Zoom_lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Zoom_lbl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Zoom_lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Zoom_lbl.Location = New System.Drawing.Point(4, 0)
        Me.Zoom_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Zoom_lbl.Name = "Zoom_lbl"
        Me.Zoom_lbl.Size = New System.Drawing.Size(800, 39)
        Me.Zoom_lbl.TabIndex = 0
        Me.Zoom_lbl.Text = "Assistant de formule — champ calculé"
        Me.Zoom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Save_pb
        '
        Me.Save_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_pb.Location = New System.Drawing.Point(812, 4)
        Me.Save_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(36, 37)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Save_pb.TabIndex = 1
        Me.Save_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Save_pb, "Enregistrer la formule")
        '
        'Close_pb
        '
        Me.Close_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.Location = New System.Drawing.Point(856, 4)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(36, 37)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Close_pb.TabIndex = 2
        Me.Close_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Close_pb, "Annuler")
        '
        'Zoom_SP_Assistant_Formule
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(900, 697)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ent_pnl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Zoom_SP_Assistant_Formule"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Assistant de formule (champ calculé)"
        Me.Panel1.ResumeLayout(False)
        Me.main.ResumeLayout(False)
        Me.grpElem.ResumeLayout(False)
        Me.grpFormule.ResumeLayout(False)
        Me.grpFormule.PerformLayout()
        Me.grpTest.ResumeLayout(False)
        CType(Me.grdTest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpApercu.ResumeLayout(False)
        Me.grpApercu.PerformLayout()
        Me.ent_pnl.ResumeLayout(False)
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents main As TableLayoutPanel
    Friend WithEvents lblIntro As Label
    Friend WithEvents grpElem As GroupBox
    Friend WithEvents lstChamps As ListBox
    Friend WithEvents btnInsererChamp As Button
    Friend WithEvents lstGV As ListBox
    Friend WithEvents btnInsererGV As Button
    Friend WithEvents cmbExemples As ComboBox
    Friend WithEvents lblChamps As Label
    Friend WithEvents lblGV As Label
    Friend WithEvents lblExemples As Label
    Friend WithEvents btnOpPlus As Button
    Friend WithEvents btnOpMoins As Button
    Friend WithEvents btnOpMul As Button
    Friend WithEvents btnOpDiv As Button
    Friend WithEvents btnOpParenO As Button
    Friend WithEvents btnOpParenF As Button
    Friend WithEvents btnOpEgal As Button
    Friend WithEvents btnOpDiff As Button
    Friend WithEvents btnOpSup As Button
    Friend WithEvents btnOpSupEgal As Button
    Friend WithEvents btnOpInf As Button
    Friend WithEvents btnOpInfEgal As Button
    Friend WithEvents btnOpEt As Button
    Friend WithEvents btnOpOu As Button
    Friend WithEvents btnOpNon As Button
    Friend WithEvents btnTexte As Button
    Friend WithEvents btnDates As Button
    Friend WithEvents btnNombres As Button
    Friend WithEvents btnCondition As Button
    Friend WithEvents btnAgregat As Button
    Friend WithEvents btnAide As Button
    Friend WithEvents grpFormule As GroupBox
    Friend WithEvents txtFormule As TextBox
    Friend WithEvents lblStatut As Label
    Friend WithEvents grpTest As GroupBox
    Friend WithEvents grdTest As DataGridView
    Friend WithEvents colEl As DataGridViewTextBoxColumn
    Friend WithEvents colVal As DataGridViewTextBoxColumn
    Friend WithEvents btnCalculer As Button
    Friend WithEvents lblResultat As Label
    Friend WithEvents lblAideGV As Label
    Friend WithEvents lblAideDates As Label
    Friend WithEvents grpApercu As GroupBox
    Friend WithEvents txtJson As TextBox
    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Zoom_lbl As Label
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend menuTexte As ContextMenuStrip
    Friend menuDates As ContextMenuStrip
    Friend menuNombres As ContextMenuStrip
    Friend menuCondition As ContextMenuStrip
    Friend menuAgregat As ContextMenuStrip
End Class
