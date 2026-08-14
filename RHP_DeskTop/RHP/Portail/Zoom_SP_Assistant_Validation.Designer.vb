<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Zoom_SP_Assistant_Validation
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
    'le fichier .vb ne contient que la logique — génération des syntaxes json,
    'chargement d'une règle existante, événements — et l'alimentation des
    'données). Disposition fixe, formulaire non redimensionnable.
    'Les listes déroulantes (type de règle, opérateurs, modèles, gravité,
    'colonnes de la grille de conditions) sont alimentées au chargement dans le
    '.vb depuis les listes de référence.
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
        Me.grpType = New System.Windows.Forms.GroupBox()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.lblTypeAide = New System.Windows.Forms.Label()
        Me.grpChamp = New System.Windows.Forms.GroupBox()
        Me.cmbChamp = New System.Windows.Forms.ComboBox()
        Me.grpParams = New System.Windows.Forms.GroupBox()
        Me.pnlHost = New System.Windows.Forms.Panel()
        Me.pnlAucun = New System.Windows.Forms.Panel()
        Me.lblAucun = New System.Windows.Forms.Label()
        Me.pnlValeur = New System.Windows.Forms.Panel()
        Me.lblValeur = New System.Windows.Forms.Label()
        Me.numValeur = New System.Windows.Forms.NumericUpDown()
        Me.lblValeurAide = New System.Windows.Forms.Label()
        Me.pnlBetween = New System.Windows.Forms.Panel()
        Me.lblEntre = New System.Windows.Forms.Label()
        Me.lblEt = New System.Windows.Forms.Label()
        Me.lblBornes = New System.Windows.Forms.Label()
        Me.numMin = New System.Windows.Forms.NumericUpDown()
        Me.numMax = New System.Windows.Forms.NumericUpDown()
        Me.pnlIn = New System.Windows.Forms.Panel()
        Me.lblValeurs = New System.Windows.Forms.Label()
        Me.lblValeursEx = New System.Windows.Forms.Label()
        Me.txtValeurs = New System.Windows.Forms.TextBox()
        Me.pnlRegex = New System.Windows.Forms.Panel()
        Me.lblPreset = New System.Windows.Forms.Label()
        Me.lblPattern = New System.Windows.Forms.Label()
        Me.lblPatternAide = New System.Windows.Forms.Label()
        Me.cmbPreset = New System.Windows.Forms.ComboBox()
        Me.txtPattern = New System.Windows.Forms.TextBox()
        Me.pnlCompare = New System.Windows.Forms.Panel()
        Me.lblCompare = New System.Windows.Forms.Label()
        Me.lblCelleDe = New System.Windows.Forms.Label()
        Me.lblCompareAide = New System.Windows.Forms.Label()
        Me.cmbOperateur = New System.Windows.Forms.ComboBox()
        Me.cmbAutreChamp = New System.Windows.Forms.ComboBox()
        Me.pnlCompareConst = New System.Windows.Forms.Panel()
        Me.lblCompare2 = New System.Windows.Forms.Label()
        Me.lblLaValeur = New System.Windows.Forms.Label()
        Me.lblCompareConstAide = New System.Windows.Forms.Label()
        Me.cmbOperateur2 = New System.Windows.Forms.ComboBox()
        Me.txtConstante = New System.Windows.Forms.TextBox()
        Me.pnlUnique = New System.Windows.Forms.Panel()
        Me.lblUniqueAide = New System.Windows.Forms.Label()
        Me.txtColonnes = New System.Windows.Forms.TextBox()
        Me.pnlNbLignes = New System.Windows.Forms.Panel()
        Me.lblLignes = New System.Windows.Forms.Label()
        Me.lblNbLignesAide = New System.Windows.Forms.Label()
        Me.chkNbMin = New System.Windows.Forms.CheckBox()
        Me.numNbMin = New System.Windows.Forms.NumericUpDown()
        Me.chkNbMax = New System.Windows.Forms.CheckBox()
        Me.numNbMax = New System.Windows.Forms.NumericUpDown()
        Me.grpCondition = New System.Windows.Forms.GroupBox()
        Me.rbToujours = New System.Windows.Forms.RadioButton()
        Me.rbSi = New System.Windows.Forms.RadioButton()
        Me.rbCustom = New System.Windows.Forms.RadioButton()
        Me.txtCustomCond = New System.Windows.Forms.TextBox()
        Me.grdCond = New System.Windows.Forms.DataGridView()
        Me.colCondChamp = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colCondOp = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colCondValeur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rbEt = New System.Windows.Forms.RadioButton()
        Me.rbOu = New System.Windows.Forms.RadioButton()
        Me.lblCondAide = New System.Windows.Forms.Label()
        Me.grpMessage = New System.Windows.Forms.GroupBox()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.cmbNiveau = New System.Windows.Forms.ComboBox()
        Me.lblGravite = New System.Windows.Forms.Label()
        Me.grpApercu = New System.Windows.Forms.GroupBox()
        Me.txtParamJson = New System.Windows.Forms.TextBox()
        Me.txtCondJson = New System.Windows.Forms.TextBox()
        Me.lblParamJson = New System.Windows.Forms.Label()
        Me.lblCondJson = New System.Windows.Forms.Label()
        Me.ent_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Zoom_lbl = New System.Windows.Forms.Label()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.main.SuspendLayout()
        Me.grpType.SuspendLayout()
        Me.grpChamp.SuspendLayout()
        Me.grpParams.SuspendLayout()
        Me.pnlHost.SuspendLayout()
        Me.pnlAucun.SuspendLayout()
        Me.pnlValeur.SuspendLayout()
        CType(Me.numValeur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBetween.SuspendLayout()
        CType(Me.numMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlIn.SuspendLayout()
        Me.pnlRegex.SuspendLayout()
        Me.pnlCompare.SuspendLayout()
        Me.pnlCompareConst.SuspendLayout()
        Me.pnlUnique.SuspendLayout()
        Me.pnlNbLignes.SuspendLayout()
        CType(Me.numNbMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNbMax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCondition.SuspendLayout()
        CType(Me.grdCond, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMessage.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(888, 682)
        Me.Panel1.TabIndex = 1
        '
        'main
        '
        Me.main.ColumnCount = 1
        Me.main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.main.Controls.Add(Me.lblIntro, 0, 0)
        Me.main.Controls.Add(Me.grpType, 0, 1)
        Me.main.Controls.Add(Me.grpChamp, 0, 2)
        Me.main.Controls.Add(Me.grpParams, 0, 3)
        Me.main.Controls.Add(Me.grpCondition, 0, 4)
        Me.main.Controls.Add(Me.grpMessage, 0, 5)
        Me.main.Controls.Add(Me.grpApercu, 0, 6)
        Me.main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.main.Location = New System.Drawing.Point(0, 0)
        Me.main.Name = "main"
        Me.main.Padding = New System.Windows.Forms.Padding(10, 8, 10, 8)
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 122.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 216.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66.0!))
        Me.main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94.0!))
        Me.main.Size = New System.Drawing.Size(888, 682)
        Me.main.TabIndex = 0
        '
        'lblIntro
        '
        Me.lblIntro.AutoSize = False
        Me.lblIntro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIntro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblIntro.Location = New System.Drawing.Point(0, 0)
        Me.lblIntro.Name = "lblIntro"
        Me.lblIntro.Size = New System.Drawing.Size(858, 20)
        Me.lblIntro.TabIndex = 1
        Me.lblIntro.Text = "Décrivez la règle en français : les syntaxes json des colonnes ""Paramètres"" et ""Condition"" de la grille sont générées automatiquement (aucun code à écrire)."
        '
        'grpType
        '
        Me.grpType.Controls.Add(Me.cmbType)
        Me.grpType.Controls.Add(Me.lblTypeAide)
        Me.grpType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpType.Location = New System.Drawing.Point(0, 0)
        Me.grpType.Name = "grpType"
        Me.grpType.Size = New System.Drawing.Size(862, 70)
        Me.grpType.TabIndex = 2
        Me.grpType.TabStop = False
        Me.grpType.Text = "1. Que voulez-vous vérifier ?"
        '
        'cmbType
        '
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.Location = New System.Drawing.Point(10, 20)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(640, 24)
        Me.cmbType.TabIndex = 0
        '
        'lblTypeAide
        '
        Me.lblTypeAide.AutoSize = False
        Me.lblTypeAide.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblTypeAide.Location = New System.Drawing.Point(10, 48)
        Me.lblTypeAide.Name = "lblTypeAide"
        Me.lblTypeAide.Size = New System.Drawing.Size(830, 20)
        Me.lblTypeAide.TabIndex = 1
        '
        'grpChamp
        '
        Me.grpChamp.Controls.Add(Me.cmbChamp)
        Me.grpChamp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpChamp.Location = New System.Drawing.Point(0, 0)
        Me.grpChamp.Name = "grpChamp"
        Me.grpChamp.Size = New System.Drawing.Size(862, 56)
        Me.grpChamp.TabIndex = 3
        Me.grpChamp.TabStop = False
        Me.grpChamp.Text = "2. Champ concerné"
        '
        'cmbChamp
        '
        Me.cmbChamp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChamp.Location = New System.Drawing.Point(10, 24)
        Me.cmbChamp.Name = "cmbChamp"
        Me.cmbChamp.Size = New System.Drawing.Size(640, 24)
        Me.cmbChamp.TabIndex = 0
        '
        'grpParams
        '
        Me.grpParams.Controls.Add(Me.pnlHost)
        Me.grpParams.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpParams.Location = New System.Drawing.Point(0, 0)
        Me.grpParams.Name = "grpParams"
        Me.grpParams.Size = New System.Drawing.Size(862, 116)
        Me.grpParams.TabIndex = 4
        Me.grpParams.TabStop = False
        Me.grpParams.Text = "3. Paramètres de la règle"
        '
        'pnlHost
        '
        Me.pnlHost.Controls.Add(Me.pnlAucun)
        Me.pnlHost.Controls.Add(Me.pnlValeur)
        Me.pnlHost.Controls.Add(Me.pnlBetween)
        Me.pnlHost.Controls.Add(Me.pnlIn)
        Me.pnlHost.Controls.Add(Me.pnlRegex)
        Me.pnlHost.Controls.Add(Me.pnlCompare)
        Me.pnlHost.Controls.Add(Me.pnlCompareConst)
        Me.pnlHost.Controls.Add(Me.pnlUnique)
        Me.pnlHost.Controls.Add(Me.pnlNbLignes)
        Me.pnlHost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHost.Location = New System.Drawing.Point(3, 19)
        Me.pnlHost.Name = "pnlHost"
        Me.pnlHost.Size = New System.Drawing.Size(856, 94)
        Me.pnlHost.TabIndex = 0
        '
        'pnlAucun
        '
        Me.pnlAucun.Controls.Add(Me.lblAucun)
        Me.pnlAucun.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAucun.Location = New System.Drawing.Point(0, 0)
        Me.pnlAucun.Name = "pnlAucun"
        Me.pnlAucun.Size = New System.Drawing.Size(856, 94)
        Me.pnlAucun.TabIndex = 0
        Me.pnlAucun.Visible = False
        '
        'lblAucun
        '
        Me.lblAucun.AutoSize = False
        Me.lblAucun.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblAucun.Location = New System.Drawing.Point(10, 34)
        Me.lblAucun.Name = "lblAucun"
        Me.lblAucun.Size = New System.Drawing.Size(810, 40)
        Me.lblAucun.TabIndex = 0
        Me.lblAucun.Text = "Aucun paramètre nécessaire."
        '
        'pnlValeur
        '
        Me.pnlValeur.Controls.Add(Me.lblValeur)
        Me.pnlValeur.Controls.Add(Me.numValeur)
        Me.pnlValeur.Controls.Add(Me.lblValeurAide)
        Me.pnlValeur.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlValeur.Location = New System.Drawing.Point(0, 0)
        Me.pnlValeur.Name = "pnlValeur"
        Me.pnlValeur.Size = New System.Drawing.Size(856, 94)
        Me.pnlValeur.TabIndex = 1
        Me.pnlValeur.Visible = False
        '
        'lblValeur
        '
        Me.lblValeur.AutoSize = False
        Me.lblValeur.Location = New System.Drawing.Point(10, 14)
        Me.lblValeur.Name = "lblValeur"
        Me.lblValeur.Size = New System.Drawing.Size(260, 20)
        Me.lblValeur.TabIndex = 0
        Me.lblValeur.Text = "Valeur :"
        '
        'numValeur
        '
        Me.numValeur.DecimalPlaces = 2
        Me.numValeur.Location = New System.Drawing.Point(10, 34)
        Me.numValeur.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numValeur.Minimum = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.numValeur.Name = "numValeur"
        Me.numValeur.Size = New System.Drawing.Size(120, 24)
        Me.numValeur.TabIndex = 1
        '
        'lblValeurAide
        '
        Me.lblValeurAide.AutoSize = False
        Me.lblValeurAide.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblValeurAide.Location = New System.Drawing.Point(145, 36)
        Me.lblValeurAide.Name = "lblValeurAide"
        Me.lblValeurAide.Size = New System.Drawing.Size(680, 20)
        Me.lblValeurAide.TabIndex = 2
        '
        'pnlBetween
        '
        Me.pnlBetween.Controls.Add(Me.lblEntre)
        Me.pnlBetween.Controls.Add(Me.numMin)
        Me.pnlBetween.Controls.Add(Me.lblEt)
        Me.pnlBetween.Controls.Add(Me.numMax)
        Me.pnlBetween.Controls.Add(Me.lblBornes)
        Me.pnlBetween.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBetween.Location = New System.Drawing.Point(0, 0)
        Me.pnlBetween.Name = "pnlBetween"
        Me.pnlBetween.Size = New System.Drawing.Size(856, 94)
        Me.pnlBetween.TabIndex = 2
        Me.pnlBetween.Visible = False
        '
        'numMin
        '
        Me.numMin.DecimalPlaces = 2
        Me.numMin.Location = New System.Drawing.Point(55, 34)
        Me.numMin.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numMin.Minimum = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.numMin.Name = "numMin"
        Me.numMin.Size = New System.Drawing.Size(110, 24)
        Me.numMin.TabIndex = 0
        '
        'numMax
        '
        Me.numMax.DecimalPlaces = 2
        Me.numMax.Location = New System.Drawing.Point(215, 34)
        Me.numMax.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numMax.Minimum = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.numMax.Name = "numMax"
        Me.numMax.Size = New System.Drawing.Size(110, 24)
        Me.numMax.TabIndex = 1
        '
        'lblEntre
        '
        Me.lblEntre.AutoSize = False
        Me.lblEntre.Location = New System.Drawing.Point(10, 36)
        Me.lblEntre.Name = "lblEntre"
        Me.lblEntre.Size = New System.Drawing.Size(45, 20)
        Me.lblEntre.Text = "Entre"
        '
        'lblEt
        '
        Me.lblEt.AutoSize = False
        Me.lblEt.Location = New System.Drawing.Point(175, 36)
        Me.lblEt.Name = "lblEt"
        Me.lblEt.Size = New System.Drawing.Size(30, 20)
        Me.lblEt.Text = "et"
        '
        'lblBornes
        '
        Me.lblBornes.AutoSize = False
        Me.lblBornes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblBornes.Location = New System.Drawing.Point(340, 36)
        Me.lblBornes.Name = "lblBornes"
        Me.lblBornes.Size = New System.Drawing.Size(300, 20)
        Me.lblBornes.Text = "(bornes incluses)"
        '
        'pnlIn
        '
        Me.pnlIn.Controls.Add(Me.lblValeurs)
        Me.pnlIn.Controls.Add(Me.txtValeurs)
        Me.pnlIn.Controls.Add(Me.lblValeursEx)
        Me.pnlIn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlIn.Location = New System.Drawing.Point(0, 0)
        Me.pnlIn.Name = "pnlIn"
        Me.pnlIn.Size = New System.Drawing.Size(856, 94)
        Me.pnlIn.TabIndex = 3
        Me.pnlIn.Visible = False
        '
        'txtValeurs
        '
        Me.txtValeurs.Location = New System.Drawing.Point(10, 32)
        Me.txtValeurs.Name = "txtValeurs"
        Me.txtValeurs.Size = New System.Drawing.Size(620, 24)
        Me.txtValeurs.TabIndex = 0
        '
        'lblValeurs
        '
        Me.lblValeurs.AutoSize = False
        Me.lblValeurs.Location = New System.Drawing.Point(10, 10)
        Me.lblValeurs.Name = "lblValeurs"
        Me.lblValeurs.Size = New System.Drawing.Size(500, 20)
        Me.lblValeurs.Text = "Valeurs autorisées, séparées par des points-virgules :"
        '
        'lblValeursEx
        '
        Me.lblValeursEx.AutoSize = False
        Me.lblValeursEx.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblValeursEx.Location = New System.Drawing.Point(10, 62)
        Me.lblValeursEx.Name = "lblValeursEx"
        Me.lblValeursEx.Size = New System.Drawing.Size(700, 20)
        Me.lblValeursEx.Text = "Ex : CDI ; CDD ; INTERIM     (nombres acceptés : 1 ; 2 ; 3)"
        '
        'pnlRegex
        '
        Me.pnlRegex.Controls.Add(Me.lblPreset)
        Me.pnlRegex.Controls.Add(Me.cmbPreset)
        Me.pnlRegex.Controls.Add(Me.lblPattern)
        Me.pnlRegex.Controls.Add(Me.txtPattern)
        Me.pnlRegex.Controls.Add(Me.lblPatternAide)
        Me.pnlRegex.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRegex.Location = New System.Drawing.Point(0, 0)
        Me.pnlRegex.Name = "pnlRegex"
        Me.pnlRegex.Size = New System.Drawing.Size(856, 94)
        Me.pnlRegex.TabIndex = 4
        Me.pnlRegex.Visible = False
        '
        'cmbPreset
        '
        Me.cmbPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPreset.Location = New System.Drawing.Point(10, 30)
        Me.cmbPreset.Name = "cmbPreset"
        Me.cmbPreset.Size = New System.Drawing.Size(240, 24)
        Me.cmbPreset.TabIndex = 0
        '
        'txtPattern
        '
        Me.txtPattern.Location = New System.Drawing.Point(270, 30)
        Me.txtPattern.Name = "txtPattern"
        Me.txtPattern.Size = New System.Drawing.Size(560, 24)
        Me.txtPattern.TabIndex = 1
        '
        'lblPreset
        '
        Me.lblPreset.AutoSize = False
        Me.lblPreset.Location = New System.Drawing.Point(10, 10)
        Me.lblPreset.Name = "lblPreset"
        Me.lblPreset.Size = New System.Drawing.Size(240, 20)
        Me.lblPreset.Text = "Modèle prédéfini :"
        '
        'lblPattern
        '
        Me.lblPattern.AutoSize = False
        Me.lblPattern.Location = New System.Drawing.Point(270, 10)
        Me.lblPattern.Name = "lblPattern"
        Me.lblPattern.Size = New System.Drawing.Size(300, 20)
        Me.lblPattern.Text = "Expression régulière :"
        '
        'lblPatternAide
        '
        Me.lblPatternAide.AutoSize = False
        Me.lblPatternAide.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblPatternAide.Location = New System.Drawing.Point(10, 62)
        Me.lblPatternAide.Name = "lblPatternAide"
        Me.lblPatternAide.Size = New System.Drawing.Size(700, 20)
        Me.lblPatternAide.Text = "Le texte saisi devra correspondre entièrement au modèle."
        '
        'pnlCompare
        '
        Me.pnlCompare.Controls.Add(Me.lblCompare)
        Me.pnlCompare.Controls.Add(Me.cmbOperateur)
        Me.pnlCompare.Controls.Add(Me.lblCelleDe)
        Me.pnlCompare.Controls.Add(Me.cmbAutreChamp)
        Me.pnlCompare.Controls.Add(Me.lblCompareAide)
        Me.pnlCompare.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCompare.Location = New System.Drawing.Point(0, 0)
        Me.pnlCompare.Name = "pnlCompare"
        Me.pnlCompare.Size = New System.Drawing.Size(856, 94)
        Me.pnlCompare.TabIndex = 5
        Me.pnlCompare.Visible = False
        '
        'cmbOperateur
        '
        Me.cmbOperateur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperateur.Location = New System.Drawing.Point(10, 34)
        Me.cmbOperateur.Name = "cmbOperateur"
        Me.cmbOperateur.Size = New System.Drawing.Size(180, 24)
        Me.cmbOperateur.TabIndex = 0
        '
        'cmbAutreChamp
        '
        Me.cmbAutreChamp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAutreChamp.Location = New System.Drawing.Point(280, 34)
        Me.cmbAutreChamp.Name = "cmbAutreChamp"
        Me.cmbAutreChamp.Size = New System.Drawing.Size(400, 24)
        Me.cmbAutreChamp.TabIndex = 1
        '
        'lblCompare
        '
        Me.lblCompare.AutoSize = False
        Me.lblCompare.Location = New System.Drawing.Point(10, 12)
        Me.lblCompare.Name = "lblCompare"
        Me.lblCompare.Size = New System.Drawing.Size(300, 20)
        Me.lblCompare.Text = "La valeur du champ doit être :"
        '
        'lblCelleDe
        '
        Me.lblCelleDe.AutoSize = False
        Me.lblCelleDe.Location = New System.Drawing.Point(200, 36)
        Me.lblCelleDe.Name = "lblCelleDe"
        Me.lblCelleDe.Size = New System.Drawing.Size(75, 20)
        Me.lblCelleDe.Text = "celle de :"
        '
        'lblCompareAide
        '
        Me.lblCompareAide.AutoSize = False
        Me.lblCompareAide.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblCompareAide.Location = New System.Drawing.Point(10, 66)
        Me.lblCompareAide.Name = "lblCompareAide"
        Me.lblCompareAide.Size = New System.Drawing.Size(700, 20)
        Me.lblCompareAide.Text = "La comparaison porte sur les valeurs des deux champs (dates, montants, nombres...)."
        '
        'pnlCompareConst
        '
        Me.pnlCompareConst.Controls.Add(Me.lblCompare2)
        Me.pnlCompareConst.Controls.Add(Me.cmbOperateur2)
        Me.pnlCompareConst.Controls.Add(Me.lblLaValeur)
        Me.pnlCompareConst.Controls.Add(Me.txtConstante)
        Me.pnlCompareConst.Controls.Add(Me.lblCompareConstAide)
        Me.pnlCompareConst.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCompareConst.Location = New System.Drawing.Point(0, 0)
        Me.pnlCompareConst.Name = "pnlCompareConst"
        Me.pnlCompareConst.Size = New System.Drawing.Size(856, 94)
        Me.pnlCompareConst.TabIndex = 6
        Me.pnlCompareConst.Visible = False
        '
        'cmbOperateur2
        '
        Me.cmbOperateur2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperateur2.Location = New System.Drawing.Point(10, 34)
        Me.cmbOperateur2.Name = "cmbOperateur2"
        Me.cmbOperateur2.Size = New System.Drawing.Size(180, 24)
        Me.cmbOperateur2.TabIndex = 0
        '
        'txtConstante
        '
        Me.txtConstante.Location = New System.Drawing.Point(285, 34)
        Me.txtConstante.Name = "txtConstante"
        Me.txtConstante.Size = New System.Drawing.Size(160, 24)
        Me.txtConstante.TabIndex = 1
        '
        'lblCompare2
        '
        Me.lblCompare2.AutoSize = False
        Me.lblCompare2.Location = New System.Drawing.Point(10, 12)
        Me.lblCompare2.Name = "lblCompare2"
        Me.lblCompare2.Size = New System.Drawing.Size(300, 20)
        Me.lblCompare2.Text = "La valeur du champ doit être :"
        '
        'lblLaValeur
        '
        Me.lblLaValeur.AutoSize = False
        Me.lblLaValeur.Location = New System.Drawing.Point(200, 36)
        Me.lblLaValeur.Name = "lblLaValeur"
        Me.lblLaValeur.Size = New System.Drawing.Size(80, 20)
        Me.lblLaValeur.Text = "la valeur :"
        '
        'lblCompareConstAide
        '
        Me.lblCompareConstAide.AutoSize = False
        Me.lblCompareConstAide.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblCompareConstAide.Location = New System.Drawing.Point(10, 66)
        Me.lblCompareConstAide.Name = "lblCompareConstAide"
        Me.lblCompareConstAide.Size = New System.Drawing.Size(700, 20)
        Me.lblCompareConstAide.Text = "Ex : 0 ; 100 ; 01/01/2026 ; ACTIF"
        '
        'pnlUnique
        '
        Me.pnlUnique.Controls.Add(Me.lblUniqueAide)
        Me.pnlUnique.Controls.Add(Me.txtColonnes)
        Me.pnlUnique.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlUnique.Location = New System.Drawing.Point(0, 0)
        Me.pnlUnique.Name = "pnlUnique"
        Me.pnlUnique.Size = New System.Drawing.Size(856, 94)
        Me.pnlUnique.TabIndex = 7
        Me.pnlUnique.Visible = False
        '
        'txtColonnes
        '
        Me.txtColonnes.Location = New System.Drawing.Point(10, 60)
        Me.txtColonnes.Name = "txtColonnes"
        Me.txtColonnes.Size = New System.Drawing.Size(500, 24)
        Me.txtColonnes.TabIndex = 0
        '
        'lblUniqueAide
        '
        Me.lblUniqueAide.AutoSize = False
        Me.lblUniqueAide.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblUniqueAide.Location = New System.Drawing.Point(10, 8)
        Me.lblUniqueAide.Name = "lblUniqueAide"
        Me.lblUniqueAide.Size = New System.Drawing.Size(810, 44)
        Me.lblUniqueAide.Text = "Le contrôle de doublon porte sur le champ choisi. Pour interdire les doublons sur une combinaison" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
            "de champs, ajoutez ci-dessous les codes des autres champs (séparés par des points-virgules)."
        '
        'pnlNbLignes
        '
        Me.pnlNbLignes.Controls.Add(Me.chkNbMin)
        Me.pnlNbLignes.Controls.Add(Me.numNbMin)
        Me.pnlNbLignes.Controls.Add(Me.chkNbMax)
        Me.pnlNbLignes.Controls.Add(Me.numNbMax)
        Me.pnlNbLignes.Controls.Add(Me.lblLignes)
        Me.pnlNbLignes.Controls.Add(Me.lblNbLignesAide)
        Me.pnlNbLignes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlNbLignes.Location = New System.Drawing.Point(0, 0)
        Me.pnlNbLignes.Name = "pnlNbLignes"
        Me.pnlNbLignes.Size = New System.Drawing.Size(856, 94)
        Me.pnlNbLignes.TabIndex = 8
        Me.pnlNbLignes.Visible = False
        '
        'chkNbMin
        '
        Me.chkNbMin.Checked = True
        Me.chkNbMin.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNbMin.Location = New System.Drawing.Point(10, 12)
        Me.chkNbMin.Name = "chkNbMin"
        Me.chkNbMin.Size = New System.Drawing.Size(90, 24)
        Me.chkNbMin.TabIndex = 0
        Me.chkNbMin.Text = "au moins"
        '
        'numNbMin
        '
        Me.numNbMin.Location = New System.Drawing.Point(105, 12)
        Me.numNbMin.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numNbMin.Name = "numNbMin"
        Me.numNbMin.Size = New System.Drawing.Size(70, 24)
        Me.numNbMin.TabIndex = 1
        Me.numNbMin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkNbMax
        '
        Me.chkNbMax.Location = New System.Drawing.Point(200, 12)
        Me.chkNbMax.Name = "chkNbMax"
        Me.chkNbMax.Size = New System.Drawing.Size(80, 24)
        Me.chkNbMax.TabIndex = 2
        Me.chkNbMax.Text = "au plus"
        '
        'numNbMax
        '
        Me.numNbMax.Location = New System.Drawing.Point(280, 12)
        Me.numNbMax.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numNbMax.Name = "numNbMax"
        Me.numNbMax.Size = New System.Drawing.Size(70, 24)
        Me.numNbMax.TabIndex = 3
        Me.numNbMax.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'lblLignes
        '
        Me.lblLignes.AutoSize = False
        Me.lblLignes.Location = New System.Drawing.Point(360, 14)
        Me.lblLignes.Name = "lblLignes"
        Me.lblLignes.Size = New System.Drawing.Size(200, 20)
        Me.lblLignes.Text = "ligne(s) dans le tableau."
        '
        'lblNbLignesAide
        '
        Me.lblNbLignesAide.AutoSize = False
        Me.lblNbLignesAide.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblNbLignesAide.Location = New System.Drawing.Point(10, 48)
        Me.lblNbLignesAide.Name = "lblNbLignesAide"
        Me.lblNbLignesAide.Size = New System.Drawing.Size(700, 20)
        Me.lblNbLignesAide.Text = "Cochez uniquement la ou les bornes à contrôler."
        '
        'grpCondition
        '
        Me.grpCondition.Controls.Add(Me.rbToujours)
        Me.grpCondition.Controls.Add(Me.rbSi)
        Me.grpCondition.Controls.Add(Me.grdCond)
        Me.grpCondition.Controls.Add(Me.rbCustom)
        Me.grpCondition.Controls.Add(Me.txtCustomCond)
        Me.grpCondition.Controls.Add(Me.lblCondAide)
        Me.grpCondition.Controls.Add(Me.rbEt)
        Me.grpCondition.Controls.Add(Me.rbOu)
        Me.grpCondition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpCondition.Location = New System.Drawing.Point(0, 0)
        Me.grpCondition.Name = "grpCondition"
        Me.grpCondition.Size = New System.Drawing.Size(862, 210)
        Me.grpCondition.TabIndex = 5
        Me.grpCondition.TabStop = False
        Me.grpCondition.Text = "4. Quand la règle doit-elle s'appliquer ? (facultatif)"
        '
        'rbToujours
        '
        Me.rbToujours.Checked = True
        Me.rbToujours.Location = New System.Drawing.Point(10, 18)
        Me.rbToujours.Name = "rbToujours"
        Me.rbToujours.Size = New System.Drawing.Size(560, 20)
        Me.rbToujours.TabIndex = 0
        Me.rbToujours.TabStop = True
        Me.rbToujours.Text = "Toujours (la règle s'applique à chaque enregistrement)"
        '
        'rbSi
        '
        Me.rbSi.Location = New System.Drawing.Point(10, 40)
        Me.rbSi.Name = "rbSi"
        Me.rbSi.Size = New System.Drawing.Size(560, 20)
        Me.rbSi.TabIndex = 1
        Me.rbSi.Text = "Seulement si les conditions ci-dessous sont réunies"
        '
        'rbCustom
        '
        Me.rbCustom.Location = New System.Drawing.Point(10, 64)
        Me.rbCustom.Name = "rbCustom"
        Me.rbCustom.Size = New System.Drawing.Size(560, 20)
        Me.rbCustom.TabIndex = 2
        Me.rbCustom.Text = "Condition personnalisée existante (conservée telle quelle) :"
        Me.rbCustom.Visible = False
        '
        'txtCustomCond
        '
        Me.txtCustomCond.Location = New System.Drawing.Point(10, 88)
        Me.txtCustomCond.Multiline = True
        Me.txtCustomCond.Name = "txtCustomCond"
        Me.txtCustomCond.ReadOnly = True
        Me.txtCustomCond.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCustomCond.Size = New System.Drawing.Size(660, 104)
        Me.txtCustomCond.TabIndex = 3
        Me.txtCustomCond.Visible = False
        '
        'grdCond
        '
        Me.grdCond.AllowUserToDeleteRows = True
        Me.grdCond.AutoGenerateColumns = False
        Me.grdCond.BackgroundColor = System.Drawing.Color.White
        Me.grdCond.ColumnHeadersDefaultCellStyle.BackColor = colorBase01
        Me.grdCond.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.grdCond.ColumnHeadersDefaultCellStyle.Font = Me.Font
        Me.grdCond.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCondChamp, Me.colCondOp, Me.colCondValeur})
        Me.grdCond.EnableHeadersVisualStyles = False
        Me.grdCond.Location = New System.Drawing.Point(10, 64)
        Me.grdCond.Name = "grdCond"
        Me.grdCond.RowHeadersVisible = False
        Me.grdCond.Size = New System.Drawing.Size(660, 128)
        Me.grdCond.TabIndex = 4
        '
        'colCondChamp
        '
        Me.colCondChamp.HeaderText = "Champ"
        Me.colCondChamp.Name = "colCondChamp"
        Me.colCondChamp.Width = 250
        '
        'colCondOp
        '
        Me.colCondOp.HeaderText = "Condition"
        Me.colCondOp.Name = "colCondOp"
        Me.colCondOp.Width = 170
        '
        'colCondValeur
        '
        Me.colCondValeur.HeaderText = "Valeur (ou nom d'un champ)"
        Me.colCondValeur.Name = "colCondValeur"
        Me.colCondValeur.Width = 240
        '
        'rbEt
        '
        Me.rbEt.Checked = True
        Me.rbEt.Location = New System.Drawing.Point(680, 126)
        Me.rbEt.Name = "rbEt"
        Me.rbEt.Size = New System.Drawing.Size(175, 20)
        Me.rbEt.TabIndex = 5
        Me.rbEt.TabStop = True
        Me.rbEt.Text = "Toutes les conditions (ET)"
        '
        'rbOu
        '
        Me.rbOu.Location = New System.Drawing.Point(680, 148)
        Me.rbOu.Name = "rbOu"
        Me.rbOu.Size = New System.Drawing.Size(175, 20)
        Me.rbOu.TabIndex = 6
        Me.rbOu.Text = "Au moins une (OU)"
        '
        'lblCondAide
        '
        Me.lblCondAide.AutoSize = False
        Me.lblCondAide.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.lblCondAide.Location = New System.Drawing.Point(680, 64)
        Me.lblCondAide.Name = "lblCondAide"
        Me.lblCondAide.Size = New System.Drawing.Size(175, 56)
        Me.lblCondAide.Text = "Dans 'Valeur', tapez une valeur" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
            "ou le nom d'un champ pour" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "le référencer."
        '
        'grpMessage
        '
        Me.grpMessage.Controls.Add(Me.txtMessage)
        Me.grpMessage.Controls.Add(Me.lblGravite)
        Me.grpMessage.Controls.Add(Me.cmbNiveau)
        Me.grpMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpMessage.Location = New System.Drawing.Point(0, 0)
        Me.grpMessage.Name = "grpMessage"
        Me.grpMessage.Size = New System.Drawing.Size(862, 60)
        Me.grpMessage.TabIndex = 6
        Me.grpMessage.TabStop = False
        Me.grpMessage.Text = "5. Message affiché si la règle n'est pas respectée"
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(10, 24)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(560, 24)
        Me.txtMessage.TabIndex = 0
        '
        'cmbNiveau
        '
        Me.cmbNiveau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNiveau.Location = New System.Drawing.Point(648, 24)
        Me.cmbNiveau.Name = "cmbNiveau"
        Me.cmbNiveau.Size = New System.Drawing.Size(205, 24)
        Me.cmbNiveau.TabIndex = 1
        '
        'lblGravite
        '
        Me.lblGravite.AutoSize = False
        Me.lblGravite.Location = New System.Drawing.Point(585, 26)
        Me.lblGravite.Name = "lblGravite"
        Me.lblGravite.Size = New System.Drawing.Size(60, 20)
        Me.lblGravite.Text = "Gravité :"
        '
        'grpApercu
        '
        Me.grpApercu.Controls.Add(Me.lblParamJson)
        Me.grpApercu.Controls.Add(Me.txtParamJson)
        Me.grpApercu.Controls.Add(Me.lblCondJson)
        Me.grpApercu.Controls.Add(Me.txtCondJson)
        Me.grpApercu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpApercu.Location = New System.Drawing.Point(0, 0)
        Me.grpApercu.Name = "grpApercu"
        Me.grpApercu.Size = New System.Drawing.Size(862, 88)
        Me.grpApercu.TabIndex = 7
        Me.grpApercu.TabStop = False
        Me.grpApercu.Text = "Aperçu de la syntaxe générée (automatique — rien à saisir)"
        '
        'txtParamJson
        '
        Me.txtParamJson.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtParamJson.Location = New System.Drawing.Point(145, 22)
        Me.txtParamJson.Name = "txtParamJson"
        Me.txtParamJson.ReadOnly = True
        Me.txtParamJson.Size = New System.Drawing.Size(700, 24)
        Me.txtParamJson.TabIndex = 0
        '
        'txtCondJson
        '
        Me.txtCondJson.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtCondJson.Location = New System.Drawing.Point(145, 54)
        Me.txtCondJson.Name = "txtCondJson"
        Me.txtCondJson.ReadOnly = True
        Me.txtCondJson.Size = New System.Drawing.Size(700, 24)
        Me.txtCondJson.TabIndex = 1
        '
        'lblParamJson
        '
        Me.lblParamJson.AutoSize = False
        Me.lblParamJson.Location = New System.Drawing.Point(10, 24)
        Me.lblParamJson.Name = "lblParamJson"
        Me.lblParamJson.Size = New System.Drawing.Size(130, 20)
        Me.lblParamJson.Text = "Paramètres (json) :"
        '
        'lblCondJson
        '
        Me.lblCondJson.AutoSize = False
        Me.lblCondJson.Location = New System.Drawing.Point(10, 56)
        Me.lblCondJson.Name = "lblCondJson"
        Me.lblCondJson.Size = New System.Drawing.Size(130, 20)
        Me.lblCondJson.Text = "Condition (json) :"
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
        Me.ent_pnl.Size = New System.Drawing.Size(888, 45)
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
        Me.Zoom_lbl.Size = New System.Drawing.Size(792, 39)
        Me.Zoom_lbl.TabIndex = 0
        Me.Zoom_lbl.Text = "Assistant de règle de validation"
        Me.Zoom_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Save_pb
        '
        Me.Save_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save
        Me.Save_pb.Location = New System.Drawing.Point(804, 4)
        Me.Save_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(36, 37)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Save_pb.TabIndex = 1
        Me.Save_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Save_pb, "Insérer la règle")
        '
        'Close_pb
        '
        Me.Close_pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close
        Me.Close_pb.Location = New System.Drawing.Point(848, 4)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(36, 37)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Close_pb.TabIndex = 2
        Me.Close_pb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Close_pb, "Annuler")
        '
        'Zoom_SP_Assistant_Validation
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(892, 731)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ent_pnl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Zoom_SP_Assistant_Validation"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Assistant de règle de validation"
        Me.Panel1.ResumeLayout(False)
        Me.main.ResumeLayout(False)
        Me.grpType.ResumeLayout(False)
        Me.grpChamp.ResumeLayout(False)
        Me.grpParams.ResumeLayout(False)
        Me.pnlHost.ResumeLayout(False)
        Me.pnlAucun.ResumeLayout(False)
        Me.pnlValeur.ResumeLayout(False)
        CType(Me.numValeur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBetween.ResumeLayout(False)
        CType(Me.numMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlIn.ResumeLayout(False)
        Me.pnlIn.PerformLayout()
        Me.pnlRegex.ResumeLayout(False)
        Me.pnlRegex.PerformLayout()
        Me.pnlCompare.ResumeLayout(False)
        Me.pnlCompareConst.ResumeLayout(False)
        Me.pnlCompareConst.PerformLayout()
        Me.pnlUnique.ResumeLayout(False)
        Me.pnlUnique.PerformLayout()
        Me.pnlNbLignes.ResumeLayout(False)
        CType(Me.numNbMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNbMax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCondition.ResumeLayout(False)
        Me.grpCondition.PerformLayout()
        CType(Me.grdCond, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMessage.ResumeLayout(False)
        Me.grpMessage.PerformLayout()
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
    Friend WithEvents grpType As GroupBox
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents lblTypeAide As Label
    Friend WithEvents grpChamp As GroupBox
    Friend WithEvents cmbChamp As ComboBox
    Friend WithEvents grpParams As GroupBox
    Friend WithEvents pnlHost As Panel
    Friend WithEvents pnlAucun As Panel
    Friend WithEvents lblAucun As Label
    Friend WithEvents pnlValeur As Panel
    Friend WithEvents lblValeur As Label
    Friend WithEvents numValeur As NumericUpDown
    Friend WithEvents lblValeurAide As Label
    Friend WithEvents pnlBetween As Panel
    Friend WithEvents numMin As NumericUpDown
    Friend WithEvents numMax As NumericUpDown
    Friend WithEvents lblEntre As Label
    Friend WithEvents lblEt As Label
    Friend WithEvents lblBornes As Label
    Friend WithEvents pnlIn As Panel
    Friend WithEvents txtValeurs As TextBox
    Friend WithEvents lblValeurs As Label
    Friend WithEvents lblValeursEx As Label
    Friend WithEvents pnlRegex As Panel
    Friend WithEvents cmbPreset As ComboBox
    Friend WithEvents txtPattern As TextBox
    Friend WithEvents lblPreset As Label
    Friend WithEvents lblPattern As Label
    Friend WithEvents lblPatternAide As Label
    Friend WithEvents pnlCompare As Panel
    Friend WithEvents cmbOperateur As ComboBox
    Friend WithEvents cmbAutreChamp As ComboBox
    Friend WithEvents lblCompare As Label
    Friend WithEvents lblCelleDe As Label
    Friend WithEvents lblCompareAide As Label
    Friend WithEvents pnlCompareConst As Panel
    Friend WithEvents cmbOperateur2 As ComboBox
    Friend WithEvents txtConstante As TextBox
    Friend WithEvents lblCompare2 As Label
    Friend WithEvents lblLaValeur As Label
    Friend WithEvents lblCompareConstAide As Label
    Friend WithEvents pnlUnique As Panel
    Friend WithEvents txtColonnes As TextBox
    Friend WithEvents lblUniqueAide As Label
    Friend WithEvents pnlNbLignes As Panel
    Friend WithEvents chkNbMin As CheckBox
    Friend WithEvents numNbMin As NumericUpDown
    Friend WithEvents chkNbMax As CheckBox
    Friend WithEvents numNbMax As NumericUpDown
    Friend WithEvents lblLignes As Label
    Friend WithEvents lblNbLignesAide As Label
    Friend WithEvents grpCondition As GroupBox
    Friend WithEvents rbToujours As RadioButton
    Friend WithEvents rbSi As RadioButton
    Friend WithEvents rbCustom As RadioButton
    Friend WithEvents txtCustomCond As TextBox
    Friend WithEvents grdCond As DataGridView
    Friend WithEvents colCondChamp As DataGridViewComboBoxColumn
    Friend WithEvents colCondOp As DataGridViewComboBoxColumn
    Friend WithEvents colCondValeur As DataGridViewTextBoxColumn
    Friend WithEvents rbEt As RadioButton
    Friend WithEvents rbOu As RadioButton
    Friend WithEvents lblCondAide As Label
    Friend WithEvents grpMessage As GroupBox
    Friend WithEvents txtMessage As TextBox
    Friend WithEvents cmbNiveau As ComboBox
    Friend WithEvents lblGravite As Label
    Friend WithEvents grpApercu As GroupBox
    Friend WithEvents txtParamJson As TextBox
    Friend WithEvents txtCondJson As TextBox
    Friend WithEvents lblParamJson As Label
    Friend WithEvents lblCondJson As Label
    Friend WithEvents ent_pnl As TableLayoutPanel
    Friend WithEvents Zoom_lbl As Label
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
