Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

''' <summary>
''' Assistant de création / modification d'une règle de validation déclarative
''' (onglet "Comportement" du SP_Page_Designer).
''' L'utilisateur décrit la règle en français (type, champ, paramètres, conditions)
''' et les syntaxes json attendues par le moteur (colonnes Parametres et
''' Condition_Regle de SP_Page_Validation) sont générées automatiquement :
''' aucune saisie de code n'est nécessaire.
''' Le formulaire est entièrement construit dans le code (à l'abri de la
''' régénération du Designer par Visual Studio).
''' </summary>
Public Class SP_Assistant_Validation
    Inherits Form

    '---------------- Résultat (lu par l'appelant après DialogResult.OK) ----------------
    Public Portee As String = "CHAMP"
    Public CodTable As String = "ENT"
    Public CodChamp As String = ""
    Public TypRegle As String = "REQUIRED"
    Public Parametres As String = ""
    Public Condition As String = ""
    Public Message As String = ""
    Public Niveau As String = "B"

    '---------------- Données de référence (champs et tables de la page) ----------------
    Private Class ChampInfo
        Public CodChamp As String
        Public NomColonne As String
        Public CodTable As String
        Public Libelle As String
        Public Overrides Function ToString() As String
            Return CodChamp & If(Libelle <> "", " — " & Libelle, "") & If(CodTable <> "ENT", "   [" & CodTable & "]", "")
        End Function
    End Class
    Private Class TableInfo
        Public CodTable As String
        Public Libelle As String
        Public Overrides Function ToString() As String
            Return CodTable & If(Libelle <> "", " — " & Libelle, "")
        End Function
    End Class
    Private Class ItemTypeRegle
        Public Key As String
        Public Label As String
        Public Aide As String
        Public Overrides Function ToString() As String
            Return Label
        End Function
    End Class
    Private Class ItemOp
        Public Label As String
        Public Code As String
        Public Phrase As String   ' tournure utilisée dans le message suggéré
        Public Overrides Function ToString() As String
            Return Label
        End Function
    End Class
    Private Class ItemNiveau
        Public Label As String
        Public Code As String
        Public Overrides Function ToString() As String
            Return Label
        End Function
    End Class
    Private Class ItemRegex
        Public Label As String
        Public Pattern As String
        Public Overrides Function ToString() As String
            Return Label
        End Function
    End Class

    Private _champs As New List(Of ChampInfo)
    Private _tablesDet As New List(Of TableInfo)
    Private _types As New List(Of ItemTypeRegle)
    Private _opsCompare As New List(Of ItemOp)
    Private _niveaux As New List(Of ItemNiveau)
    Private _regex As New List(Of ItemRegex)
    Private _enMaj As Boolean = False          ' true pendant le chargement initial (pas de régénération)
    Private _uiPrete As Boolean = False        ' true une fois l'interface construite (bloque les événements intempestifs)
    Private _messageTouche As Boolean = False  ' true dès que l'utilisateur modifie le message
    Private _jsonCustom As JToken = Nothing    ' condition/expression existante non représentable (conservée)
    Private _jsonCustomTexte As String = ""

    ' Conditions élémentaires de l'assistant (libellé français -> opérateur moteur)
    Private Shared ReadOnly OPS_CONDITIONS As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
        {"est renseigné", "NOTEMPTY"}, {"est vide", "EMPTY"},
        {"est égal à", "EQ"}, {"est différent de", "NE"},
        {"est supérieur à", "GT"}, {"est supérieur ou égal à", "GE"},
        {"est inférieur à", "LT"}, {"est inférieur ou égal à", "LE"},
        {"contient", "CONTIENT"}}
    Private Shared ReadOnly OPS_INVERSE As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
        {"NOTEMPTY", "est renseigné"}, {"EMPTY", "est vide"},
        {"EQ", "est égal à"}, {"NE", "est différent de"},
        {"GT", "est supérieur à"}, {"GE", "est supérieur ou égal à"},
        {"LT", "est inférieur à"}, {"LE", "est inférieur ou égal à"},
        {"CONTIENT", "contient"}}

    '---------------- Contrôles (déclarés WithEvents : créés dans ConstruireUI) ----------------
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents lblTypeAide As Label
    Friend WithEvents grpChamp As GroupBox
    Friend WithEvents cmbChamp As ComboBox
    Friend WithEvents grpParams As GroupBox
    Friend WithEvents lblAucun As Label
    Friend WithEvents pnlAucun As Panel
    Friend WithEvents pnlValeur As Panel
    Friend WithEvents lblValeur As Label
    Friend WithEvents numValeur As NumericUpDown
    Friend WithEvents lblValeurAide As Label
    Friend WithEvents pnlBetween As Panel
    Friend WithEvents numMin As NumericUpDown
    Friend WithEvents numMax As NumericUpDown
    Friend WithEvents pnlIn As Panel
    Friend WithEvents txtValeurs As TextBox
    Friend WithEvents pnlRegex As Panel
    Friend WithEvents cmbPreset As ComboBox
    Friend WithEvents txtPattern As TextBox
    Friend WithEvents pnlCompare As Panel
    Friend WithEvents cmbOperateur As ComboBox
    Friend WithEvents cmbAutreChamp As ComboBox
    Friend WithEvents pnlCompareConst As Panel
    Friend WithEvents cmbOperateur2 As ComboBox
    Friend WithEvents txtConstante As TextBox
    Friend WithEvents pnlUnique As Panel
    Friend WithEvents txtColonnes As TextBox
    Friend WithEvents pnlNbLignes As Panel
    Friend WithEvents chkNbMin As CheckBox
    Friend WithEvents numNbMin As NumericUpDown
    Friend WithEvents chkNbMax As CheckBox
    Friend WithEvents numNbMax As NumericUpDown
    Friend WithEvents grpCondition As GroupBox
    Friend WithEvents rbToujours As RadioButton
    Friend WithEvents rbSi As RadioButton
    Friend WithEvents rbCustom As RadioButton
    Friend WithEvents txtCustomCond As TextBox
    Friend WithEvents grdCond As DataGridView
    Friend WithEvents rbEt As RadioButton
    Friend WithEvents rbOu As RadioButton
    Friend WithEvents txtMessage As TextBox
    Friend WithEvents cmbNiveau As ComboBox
    Friend WithEvents txtParamJson As TextBox
    Friend WithEvents txtCondJson As TextBox
    Friend WithEvents btnInserer As Button
    Friend WithEvents btnAnnuler As Button
    Private _panelsParams As New Dictionary(Of String, Panel)

    '---------------- Construction ----------------

    ''' <summary>Crée l'assistant. Si ligne est fournie, l'assistant se pré-remplit
    ''' depuis la règle existante (modification) ; sinon il propose une nouvelle règle.</summary>
    Public Sub New(tblChamps As DataTable, tblTables As DataTable, Optional ligne As DataRow = Nothing)
        Me.Font = New Font("Century Gothic", 8.25!)
        Me.Text = "Assistant de règle de validation"
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False : Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ClientSize = New Size(880, 752)
        Me.BackColor = Color.White
        Me.ShowInTaskbar = False
        ChargerReferences(tblChamps, tblTables)
        ConstruireUI()
        MajSections()
        If ligne IsNot Nothing Then
            btnInserer.Text = "Mettre à jour la règle"
            ChargerLigne(ligne)
        Else
            cmbNiveau.SelectedIndex = 0
            Regenerer()
        End If
    End Sub

    ''' <summary>Extrait les champs (Cod_Champ / Nom_Colonne / table) et les tables
    ''' de détail depuis les grilles du designer (lignes supprimées ignorées).</summary>
    Private Sub ChargerReferences(tblChamps As DataTable, tblTables As DataTable)
        If tblChamps IsNot Nothing Then
            For Each r As DataRow In tblChamps.Rows
                If r.RowState = DataRowState.Deleted Then Continue For
                Dim cc As String = IsNull(r("Cod_Champ"), "").Trim
                If cc = "" Then Continue For
                Dim nc As String = IsNull(r("Nom_Colonne"), "").Trim
                If nc = "" Then nc = cc
                _champs.Add(New ChampInfo With {.CodChamp = cc, .NomColonne = nc,
                            .CodTable = If(IsNull(r("Cod_Table"), "ENT").Trim = "", "ENT", IsNull(r("Cod_Table"), "ENT").Trim),
                            .Libelle = IsNull(r("Libelle"), "").Trim})
            Next
        End If
        If tblTables IsNot Nothing Then
            For Each r As DataRow In tblTables.Rows
                If r.RowState = DataRowState.Deleted Then Continue For
                Dim ct As String = IsNull(r("Cod_Table"), "").Trim
                If ct = "" OrElse ct.Equals("ENT", StringComparison.OrdinalIgnoreCase) Then Continue For
                _tablesDet.Add(New TableInfo With {.CodTable = ct, .Libelle = IsNull(r("Libelle"), "").Trim})
            Next
        End If
    End Sub

    Private Function Lbl(texte As String, x As Integer, y As Integer, w As Integer, Optional hauteur As Integer = 20) As Label
        Return New Label With {.Text = texte, .Location = New Point(x, y), .Size = New Size(w, hauteur), .AutoSize = False}
    End Function
    Private Function LblAide(texte As String, x As Integer, y As Integer, w As Integer, Optional hauteur As Integer = 20) As Label
        Return New Label With {.Text = texte, .Location = New Point(x, y), .Size = New Size(w, hauteur),
                               .ForeColor = Color.FromArgb(110, 110, 110), .AutoSize = False}
    End Function
    Private Function Cmb(x As Integer, y As Integer, w As Integer) As ComboBox
        Return New ComboBox With {.Location = New Point(x, y), .Size = New Size(w, 24), .DropDownStyle = ComboBoxStyle.DropDownList}
    End Function
    Private Function Txt(x As Integer, y As Integer, w As Integer) As TextBox
        Return New TextBox With {.Location = New Point(x, y), .Size = New Size(w, 24)}
    End Function
    Private Function Num(x As Integer, y As Integer, w As Integer, Optional decimales As Integer = 0) As NumericUpDown
        Return New NumericUpDown With {.Location = New Point(x, y), .Size = New Size(w, 24),
                                       .Minimum = -999999999, .Maximum = 999999999, .DecimalPlaces = decimales}
    End Function

    ''' <summary>Construit toute l'interface (disposition fixe, formulaire non redimensionnable).</summary>
    Private Sub ConstruireUI()
        '---------------- Listes de référence ----------------
        _types.AddRange(New ItemTypeRegle() {
            New ItemTypeRegle With {.Key = "REQUIRED", .Label = "Un champ doit être renseigné (obligatoire)", .Aide = "Le champ devra obligatoirement être renseigné avant l'enregistrement."},
            New ItemTypeRegle With {.Key = "COMPARE", .Label = "Comparer deux champs entre eux (ex : date de fin >= date de début)", .Aide = "La valeur du champ sera comparée à celle d'un autre champ (dates, montants, nombres...)."},
            New ItemTypeRegle With {.Key = "COMPARE_CONST", .Label = "Comparer un champ à une valeur fixe (ex : montant > 0)", .Aide = "La valeur du champ sera comparée à la valeur indiquée."},
            New ItemTypeRegle With {.Key = "IN", .Label = "La valeur doit faire partie d'une liste autorisée", .Aide = "Seules les valeurs de la liste seront acceptées."},
            New ItemTypeRegle With {.Key = "MIN", .Label = "Valeur minimale autorisée", .Aide = "La valeur du champ devra être supérieure ou égale au minimum indiqué."},
            New ItemTypeRegle With {.Key = "MAX", .Label = "Valeur maximale autorisée", .Aide = "La valeur du champ devra être inférieure ou égale au maximum indiqué."},
            New ItemTypeRegle With {.Key = "BETWEEN", .Label = "Valeur comprise entre deux bornes", .Aide = "La valeur du champ devra être comprise entre les deux bornes (incluses)."},
            New ItemTypeRegle With {.Key = "MINLEN", .Label = "Longueur minimale du texte", .Aide = "Le texte devra contenir au moins le nombre de caractères indiqué."},
            New ItemTypeRegle With {.Key = "MAXLEN", .Label = "Longueur maximale du texte", .Aide = "Le texte devra contenir au plus le nombre de caractères indiqué."},
            New ItemTypeRegle With {.Key = "REGEX", .Label = "Format du texte à respecter (modèle prédéfini ou personnalisé)", .Aide = "Le texte devra respecter le format choisi (ex : e-mail, téléphone)."},
            New ItemTypeRegle With {.Key = "UNIQUE", .Label = "Interdire les doublons dans un tableau", .Aide = "Deux lignes du tableau ne pourront pas avoir la même valeur."},
            New ItemTypeRegle With {.Key = "NB_LIGNES", .Label = "Nombre de lignes d'un tableau (minimum / maximum)", .Aide = "Ex : exiger au moins une ligne dans le tableau avant l'enregistrement."},
            New ItemTypeRegle With {.Key = "EXPR", .Label = "Règle personnalisée (combinaison de conditions)", .Aide = "Cas particuliers : décrivez la règle comme une combinaison de conditions à respecter."}})
        _opsCompare.AddRange(New ItemOp() {
            New ItemOp With {.Label = "supérieure à", .Code = "GT", .Phrase = "strictement supérieure à"},
            New ItemOp With {.Label = "supérieure ou égale à", .Code = "GE", .Phrase = "supérieure ou égale à"},
            New ItemOp With {.Label = "inférieure à", .Code = "LT", .Phrase = "strictement inférieure à"},
            New ItemOp With {.Label = "inférieure ou égale à", .Code = "LE", .Phrase = "inférieure ou égale à"},
            New ItemOp With {.Label = "égale à", .Code = "EQ", .Phrase = "égale à"},
            New ItemOp With {.Label = "différente de", .Code = "NE", .Phrase = "différente de"}})
        _niveaux.AddRange(New ItemNiveau() {
            New ItemNiveau With {.Label = "Bloquant (empêche l'enregistrement)", .Code = "B"},
            New ItemNiveau With {.Label = "Avertissement (l'utilisateur est prévenu)", .Code = "W"},
            New ItemNiveau With {.Label = "Information simple", .Code = "I"}})
        _regex.AddRange(New ItemRegex() {
            New ItemRegex With {.Label = "E-mail", .Pattern = "^[^@\s]+@[^@\s]+\.[^@\s]+$"},
            New ItemRegex With {.Label = "Téléphone FR (10 chiffres)", .Pattern = "^0\d{9}$"},
            New ItemRegex With {.Label = "Code postal (5 chiffres)", .Pattern = "^\d{5}$"},
            New ItemRegex With {.Label = "Chiffres uniquement", .Pattern = "^\d+$"},
            New ItemRegex With {.Label = "Lettres uniquement", .Pattern = "^[A-Za-zÀ-ÿ\s'\-]+$"},
            New ItemRegex With {.Label = "Personnalisé (saisie libre ci-dessous)", .Pattern = ""}})

        '---------------- Disposition générale ----------------
        Dim main As New TableLayoutPanel With {.Dock = DockStyle.Fill, .ColumnCount = 1, .Padding = New Padding(10, 8, 10, 8)}
        main.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
        For Each h As Single In New Single() {24, 30, 76, 62, 122, 216, 66, 94, 42}
            main.RowStyles.Add(New RowStyle(SizeType.Absolute, h))
        Next
        Me.Controls.Add(main)

        Dim lblTitre As Label = Lbl("Assistant de règle de validation", 0, 0, 800)
        lblTitre.Font = New Font("Century Gothic", 11.0!, FontStyle.Bold)
        lblTitre.ForeColor = colorBase01
        main.Controls.Add(lblTitre, 0, 0)
        Dim lblIntro As Label = LblAide("Décrivez la règle en français : les syntaxes json des colonnes ""Paramètres"" et ""Condition"" de la grille sont générées automatiquement (aucun code à écrire).", 0, 0, 860)
        lblIntro.Dock = DockStyle.Fill
        main.Controls.Add(lblIntro, 0, 1)

        '---------------- 1. Type de règle ----------------
        Dim grpType As New GroupBox With {.Text = "1. Que voulez-vous vérifier ?", .Dock = DockStyle.Fill}
        cmbType = Cmb(10, 20, 640)
        For Each t In _types : cmbType.Items.Add(t) : Next
        cmbType.SelectedIndex = 0
        lblTypeAide = LblAide("", 10, 48, 830)
        grpType.Controls.Add(cmbType)
        grpType.Controls.Add(lblTypeAide)
        main.Controls.Add(grpType, 0, 2)

        '---------------- 2. Champ / tableau concerné ----------------
        grpChamp = New GroupBox With {.Text = "2. Champ concerné", .Dock = DockStyle.Fill}
        cmbChamp = Cmb(10, 24, 640)
        grpChamp.Controls.Add(cmbChamp)
        main.Controls.Add(grpChamp, 0, 3)

        '---------------- 3. Paramètres (panneau dépendant du type) ----------------
        grpParams = New GroupBox With {.Text = "3. Paramètres de la règle", .Dock = DockStyle.Fill}
        Dim pnlHost As New Panel With {.Dock = DockStyle.Fill}
        grpParams.Controls.Add(pnlHost)

        pnlAucun = New Panel With {.Dock = DockStyle.Fill}
        lblAucun = LblAide("Aucun paramètre nécessaire.", 10, 34, 810, 40)
        pnlAucun.Controls.Add(lblAucun)

        pnlValeur = New Panel With {.Dock = DockStyle.Fill}
        lblValeur = Lbl("Valeur :", 10, 14, 260)
        numValeur = Num(10, 34, 120, 2)
        lblValeurAide = LblAide("", 145, 36, 680)
        pnlValeur.Controls.Add(lblValeur) : pnlValeur.Controls.Add(numValeur) : pnlValeur.Controls.Add(lblValeurAide)

        pnlBetween = New Panel With {.Dock = DockStyle.Fill}
        numMin = Num(55, 34, 110, 2)
        numMax = Num(215, 34, 110, 2)
        pnlBetween.Controls.Add(Lbl("Entre", 10, 36, 45))
        pnlBetween.Controls.Add(numMin)
        pnlBetween.Controls.Add(Lbl("et", 175, 36, 30))
        pnlBetween.Controls.Add(numMax)
        pnlBetween.Controls.Add(LblAide("(bornes incluses)", 340, 36, 300))

        pnlIn = New Panel With {.Dock = DockStyle.Fill}
        txtValeurs = Txt(10, 32, 620)
        pnlIn.Controls.Add(Lbl("Valeurs autorisées, séparées par des points-virgules :", 10, 10, 500))
        pnlIn.Controls.Add(txtValeurs)
        pnlIn.Controls.Add(LblAide("Ex : CDI ; CDD ; INTERIM     (nombres acceptés : 1 ; 2 ; 3)", 10, 62, 700))

        pnlRegex = New Panel With {.Dock = DockStyle.Fill}
        cmbPreset = Cmb(10, 30, 240)
        For Each pr In _regex : cmbPreset.Items.Add(pr) : Next
        cmbPreset.SelectedIndex = 0
        txtPattern = Txt(270, 30, 560)
        pnlRegex.Controls.Add(Lbl("Modèle prédéfini :", 10, 10, 240))
        pnlRegex.Controls.Add(cmbPreset)
        pnlRegex.Controls.Add(Lbl("Expression régulière :", 270, 10, 300))
        pnlRegex.Controls.Add(txtPattern)
        pnlRegex.Controls.Add(LblAide("Le texte saisi devra correspondre entièrement au modèle.", 10, 62, 700))

        pnlCompare = New Panel With {.Dock = DockStyle.Fill}
        cmbOperateur = Cmb(10, 34, 180)
        For Each o In _opsCompare : cmbOperateur.Items.Add(o) : Next
        cmbOperateur.SelectedIndex = 1
        cmbAutreChamp = Cmb(280, 34, 400)
        pnlCompare.Controls.Add(Lbl("La valeur du champ doit être :", 10, 12, 300))
        pnlCompare.Controls.Add(cmbOperateur)
        pnlCompare.Controls.Add(Lbl("celle de :", 200, 36, 75))
        pnlCompare.Controls.Add(cmbAutreChamp)
        pnlCompare.Controls.Add(LblAide("La comparaison porte sur les valeurs des deux champs (dates, montants, nombres...).", 10, 66, 700))

        pnlCompareConst = New Panel With {.Dock = DockStyle.Fill}
        cmbOperateur2 = Cmb(10, 34, 180)
        For Each o In _opsCompare : cmbOperateur2.Items.Add(o) : Next
        cmbOperateur2.SelectedIndex = 1
        txtConstante = Txt(285, 34, 160)
        pnlCompareConst.Controls.Add(Lbl("La valeur du champ doit être :", 10, 12, 300))
        pnlCompareConst.Controls.Add(cmbOperateur2)
        pnlCompareConst.Controls.Add(Lbl("la valeur :", 200, 36, 80))
        pnlCompareConst.Controls.Add(txtConstante)
        pnlCompareConst.Controls.Add(LblAide("Ex : 0 ; 100 ; 01/01/2026 ; ACTIF", 10, 66, 700))

        pnlUnique = New Panel With {.Dock = DockStyle.Fill}
        txtColonnes = Txt(10, 60, 500)
        pnlUnique.Controls.Add(LblAide("Le contrôle de doublon porte sur le champ choisi. Pour interdire les doublons sur une combinaison" & vbCrLf &
                                       "de champs, ajoutez ci-dessous les codes des autres champs (séparés par des points-virgules).", 10, 8, 810, 44))
        pnlUnique.Controls.Add(txtColonnes)

        pnlNbLignes = New Panel With {.Dock = DockStyle.Fill}
        chkNbMin = New CheckBox With {.Text = "au moins", .Location = New Point(10, 12), .Size = New Size(90, 24), .Checked = True}
        numNbMin = New NumericUpDown With {.Location = New Point(105, 12), .Size = New Size(70, 24), .Minimum = 0, .Maximum = 99999, .Value = 1}
        chkNbMax = New CheckBox With {.Text = "au plus", .Location = New Point(200, 12), .Size = New Size(80, 24)}
        numNbMax = New NumericUpDown With {.Location = New Point(280, 12), .Size = New Size(70, 24), .Minimum = 0, .Maximum = 99999, .Value = 10}
        pnlNbLignes.Controls.Add(chkNbMin) : pnlNbLignes.Controls.Add(numNbMin)
        pnlNbLignes.Controls.Add(chkNbMax) : pnlNbLignes.Controls.Add(numNbMax)
        pnlNbLignes.Controls.Add(Lbl("ligne(s) dans le tableau.", 360, 14, 200))
        pnlNbLignes.Controls.Add(LblAide("Cochez uniquement la ou les bornes à contrôler.", 10, 48, 700))

        _panelsParams.Clear()
        _panelsParams("AUCUN") = pnlAucun
        _panelsParams("VALEUR") = pnlValeur
        _panelsParams("BETWEEN") = pnlBetween
        _panelsParams("IN") = pnlIn
        _panelsParams("REGEX") = pnlRegex
        _panelsParams("COMPARE") = pnlCompare
        _panelsParams("COMPARE_CONST") = pnlCompareConst
        _panelsParams("UNIQUE") = pnlUnique
        _panelsParams("NB_LIGNES") = pnlNbLignes
        For Each p In _panelsParams.Values
            p.Visible = False
            pnlHost.Controls.Add(p)
        Next
        main.Controls.Add(grpParams, 0, 4)

        '---------------- 4. Conditions d'application ----------------
        grpCondition = New GroupBox With {.Text = "4. Quand la règle doit-elle s'appliquer ? (facultatif)", .Dock = DockStyle.Fill}
        rbToujours = New RadioButton With {.Text = "Toujours (la règle s'applique à chaque enregistrement)", .Location = New Point(10, 18), .Size = New Size(560, 20), .Checked = True}
        rbSi = New RadioButton With {.Text = "Seulement si les conditions ci-dessous sont réunies", .Location = New Point(10, 40), .Size = New Size(560, 20)}
        rbCustom = New RadioButton With {.Text = "Condition personnalisée existante (conservée telle quelle) :", .Location = New Point(10, 62), .Size = New Size(560, 20), .Visible = False}
        txtCustomCond = New TextBox With {.Location = New Point(10, 88), .Size = New Size(660, 104), .Multiline = True,
                                          .ScrollBars = ScrollBars.Vertical, .ReadOnly = True, .Visible = False}
        grdCond = New DataGridView With {.Location = New Point(10, 64), .Size = New Size(660, 128),
                                         .AllowUserToDeleteRows = True, .RowHeadersVisible = False, .AutoGenerateColumns = False,
                                         .EnableHeadersVisualStyles = False, .BackgroundColor = Color.White,
                                         .ColumnHeadersDefaultCellStyle = New DataGridViewCellStyle With {.BackColor = colorBase01, .ForeColor = Color.White, .Font = Me.Font}}
        Dim colChamp As New DataGridViewComboBoxColumn With {.Name = "colCondChamp", .HeaderText = "Champ", .Width = 250}
        For Each c In _champs : colChamp.Items.Add(c.CodChamp) : Next
        grdCond.Columns.Add(colChamp)
        Dim colOp As New DataGridViewComboBoxColumn With {.Name = "colCondOp", .HeaderText = "Condition", .Width = 170}
        For Each k In OPS_CONDITIONS.Keys : colOp.Items.Add(k) : Next
        grdCond.Columns.Add(colOp)
        Dim colVal As New DataGridViewTextBoxColumn With {.Name = "colCondValeur", .HeaderText = "Valeur (ou nom d'un champ)", .Width = 240}
        grdCond.Columns.Add(colVal)
        rbEt = New RadioButton With {.Text = "Toutes les conditions (ET)", .Location = New Point(680, 126), .Size = New Size(175, 20), .Checked = True}
        rbOu = New RadioButton With {.Text = "Au moins une (OU)", .Location = New Point(680, 148), .Size = New Size(175, 20)}
        grpCondition.Controls.Add(rbToujours)
        grpCondition.Controls.Add(rbSi)
        grpCondition.Controls.Add(rbCustom)
        grpCondition.Controls.Add(txtCustomCond)
        grpCondition.Controls.Add(grdCond)
        grpCondition.Controls.Add(LblAide("Dans 'Valeur', tapez une valeur" & vbCrLf & "ou le nom d'un champ pour" & vbCrLf & "le référencer.", 680, 64, 175, 56))
        grpCondition.Controls.Add(rbEt)
        grpCondition.Controls.Add(rbOu)
        main.Controls.Add(grpCondition, 0, 5)

        '---------------- 5. Message et gravité ----------------
        Dim grpMessage As New GroupBox With {.Text = "5. Message affiché si la règle n'est pas respectée", .Dock = DockStyle.Fill}
        txtMessage = Txt(10, 24, 560)
        cmbNiveau = Cmb(648, 24, 205)
        For Each n In _niveaux : cmbNiveau.Items.Add(n) : Next
        cmbNiveau.SelectedIndex = 0
        grpMessage.Controls.Add(txtMessage)
        grpMessage.Controls.Add(Lbl("Gravité :", 585, 26, 60))
        grpMessage.Controls.Add(cmbNiveau)
        main.Controls.Add(grpMessage, 0, 6)

        '---------------- 6. Aperçu de la syntaxe générée ----------------
        Dim grpApercu As New GroupBox With {.Text = "Aperçu de la syntaxe générée (automatique — rien à saisir)", .Dock = DockStyle.Fill}
        txtParamJson = Txt(145, 22, 700)
        txtParamJson.ReadOnly = True
        txtParamJson.BackColor = Color.FromArgb(240, 243, 245)
        txtCondJson = Txt(145, 54, 700)
        txtCondJson.ReadOnly = True
        txtCondJson.BackColor = Color.FromArgb(240, 243, 245)
        grpApercu.Controls.Add(Lbl("Paramètres (json) :", 10, 24, 130))
        grpApercu.Controls.Add(txtParamJson)
        grpApercu.Controls.Add(Lbl("Condition (json) :", 10, 56, 130))
        grpApercu.Controls.Add(txtCondJson)
        main.Controls.Add(grpApercu, 0, 7)

        '---------------- Boutons ----------------
        Dim pnlBoutons As New FlowLayoutPanel With {.Dock = DockStyle.Fill, .FlowDirection = FlowDirection.RightToLeft}
        btnAnnuler = New Button With {.Text = "Annuler", .Size = New Size(110, 30)}
        btnInserer = New Button With {.Text = "Insérer la règle", .Size = New Size(190, 30), .FlatStyle = FlatStyle.Flat,
                                      .BackColor = colorBase01, .ForeColor = Color.White}
        pnlBoutons.Controls.Add(btnAnnuler)
        pnlBoutons.Controls.Add(btnInserer)
        main.Controls.Add(pnlBoutons, 0, 8)
        Me.CancelButton = btnAnnuler
        _uiPrete = True
    End Sub

    '---------------- Sélections courantes ----------------

    Private Function TypeCourant() As ItemTypeRegle
        Return TryCast(cmbType.SelectedItem, ItemTypeRegle)
    End Function
    Private Function ChampCourant() As ChampInfo
        Return TryCast(cmbChamp.SelectedItem, ChampInfo)
    End Function
    Private Function TableChoisie() As TableInfo
        Return TryCast(cmbChamp.SelectedItem, TableInfo)
    End Function
    Private Function TrouverChampParCod(cod As String) As ChampInfo
        For Each c In _champs
            If c.CodChamp.Equals(cod, StringComparison.OrdinalIgnoreCase) Then Return c
        Next
        Return Nothing
    End Function
    Private Function TrouverChampParNom(nom As String) As ChampInfo
        For Each c In _champs
            If c.NomColonne.Equals(nom, StringComparison.OrdinalIgnoreCase) OrElse
               c.CodChamp.Equals(nom, StringComparison.OrdinalIgnoreCase) Then Return c
        Next
        Return Nothing
    End Function
    Private Sub ChoisirChamp(cod As String)
        For i As Integer = 0 To cmbChamp.Items.Count - 1
            Dim c = TryCast(cmbChamp.Items(i), ChampInfo)
            If c IsNot Nothing AndAlso c.CodChamp.Equals(cod, StringComparison.OrdinalIgnoreCase) Then
                cmbChamp.SelectedIndex = i : Return
            End If
        Next
    End Sub
    Private Sub ChoisirTable(cod As String)
        For i As Integer = 0 To cmbChamp.Items.Count - 1
            Dim t = TryCast(cmbChamp.Items(i), TableInfo)
            If t IsNot Nothing AndAlso t.CodTable.Equals(cod, StringComparison.OrdinalIgnoreCase) Then
                cmbChamp.SelectedIndex = i : Return
            End If
        Next
    End Sub

    '---------------- Mise à jour de l'interface selon le type ----------------

    Private Sub MajSections()
        Dim t = TypeCourant()
        If t Is Nothing Then Return
        lblTypeAide.Text = t.Aide
        ' Champ / tableau concerné
        If t.Key = "EXPR" Then
            grpChamp.Visible = False
        Else
            grpChamp.Visible = True
            If t.Key = "NB_LIGNES" Then
                grpChamp.Text = "2. Tableau concerné"
                RemplirTables()
            Else
                grpChamp.Text = "2. Champ concerné"
                RemplirChamps(t.Key = "UNIQUE")
            End If
        End If
        ' Panneau de paramètres
        For Each p In _panelsParams.Values : p.Visible = False : Next
        Dim cle As String = t.Key
        Select Case t.Key
            Case "MIN", "MAX", "MINLEN", "MAXLEN" : cle = "VALEUR"
            Case "REQUIRED", "EXPR" : cle = "AUCUN"
        End Select
        If _panelsParams.ContainsKey(cle) Then _panelsParams(cle).Visible = True
        Select Case t.Key
            Case "MIN"
                lblValeur.Text = "Valeur minimale :" : numValeur.DecimalPlaces = 2 : numValeur.Minimum = -999999999
                lblValeurAide.Text = "La valeur saisie devra être supérieure ou égale à ce minimum."
            Case "MAX"
                lblValeur.Text = "Valeur maximale :" : numValeur.DecimalPlaces = 2 : numValeur.Minimum = -999999999
                lblValeurAide.Text = "La valeur saisie devra être inférieure ou égale à ce maximum."
            Case "MINLEN"
                lblValeur.Text = "Nombre minimal de caractères :" : numValeur.DecimalPlaces = 0
                If numValeur.Value < 0 Then numValeur.Value = 0
                numValeur.Minimum = 0
                lblValeurAide.Text = "Le texte devra contenir au moins ce nombre de caractères."
            Case "MAXLEN"
                lblValeur.Text = "Nombre maximal de caractères :" : numValeur.DecimalPlaces = 0
                If numValeur.Value < 0 Then numValeur.Value = 0
                numValeur.Minimum = 0
                lblValeurAide.Text = "Le texte devra contenir au plus ce nombre de caractères."
            Case "REQUIRED"
                lblAucun.Text = "Aucun paramètre : le champ devra simplement être renseigné."
            Case "EXPR"
                lblAucun.Text = "Décrivez la règle à l'étape 4 ci-dessous : elle est respectée quand les conditions sont vraies."
        End Select
        ' Section conditions
        If t.Key = "EXPR" Then
            grpCondition.Text = "4. Définissez la règle (les conditions ci-dessous doivent être vraies)"
            rbToujours.Visible = False
            If Not rbCustom.Checked Then rbSi.Checked = True
        Else
            grpCondition.Text = "4. Quand la règle doit-elle s'appliquer ? (facultatif)"
            rbToujours.Visible = True
        End If
        MajEtatCondition()
    End Sub

    Private Sub MajEtatCondition()
        ' En mode "condition personnalisée existante" (modification d'une forme non
        ' représentable), le texte json remplace visuellement la grille de conditions.
        If rbCustom.Visible Then
            grdCond.SetBounds(10, 88, 660, 104)
            txtCustomCond.SetBounds(10, 88, 660, 104)
        Else
            grdCond.SetBounds(10, 64, 660, 128)
        End If
        grdCond.Visible = Not rbCustom.Checked
        grdCond.Enabled = rbSi.Checked
        rbEt.Enabled = rbSi.Checked
        rbOu.Enabled = rbSi.Checked
        txtCustomCond.Visible = rbCustom.Checked
    End Sub

    ''' <summary>Remplit la liste des champs (tous, ou uniquement ceux des tableaux
    ''' de détail pour la règle UNIQUE) en préservant la sélection si possible.</summary>
    Private Sub RemplirChamps(uniquementDetail As Boolean)
        Dim sel As String = If(ChampCourant() IsNot Nothing, ChampCourant().CodChamp, "")
        cmbChamp.Items.Clear()
        For Each c In _champs
            If uniquementDetail AndAlso c.CodTable = "ENT" Then Continue For
            cmbChamp.Items.Add(c)
        Next
        If sel <> "" Then ChoisirChamp(sel)
        If cmbChamp.SelectedIndex < 0 AndAlso cmbChamp.Items.Count > 0 Then cmbChamp.SelectedIndex = 0
        RemplirAutresChamps()
    End Sub

    Private Sub RemplirTables()
        Dim sel As String = If(TableChoisie() IsNot Nothing, TableChoisie().CodTable, "")
        cmbChamp.Items.Clear()
        For Each t In _tablesDet
            cmbChamp.Items.Add(t)
        Next
        If sel <> "" Then ChoisirTable(sel)
        If cmbChamp.SelectedIndex < 0 AndAlso cmbChamp.Items.Count > 0 Then cmbChamp.SelectedIndex = 0
    End Sub

    ''' <summary>Champs comparables (même table que le champ cible + champs de l'entête).</summary>
    Private Sub RemplirAutresChamps()
        Dim c = ChampCourant()
        cmbAutreChamp.Items.Clear()
        If c Is Nothing Then Return
        For Each x In _champs
            If x Is c Then Continue For
            If x.CodTable = c.CodTable OrElse x.CodTable = "ENT" Then cmbAutreChamp.Items.Add(x)
        Next
        If cmbAutreChamp.Items.Count > 0 Then cmbAutreChamp.SelectedIndex = 0
    End Sub

    '---------------- Génération de la syntaxe json ----------------

    ''' <summary>Nombre json : entier si possible (lisibilité), double sinon.</summary>
    Private Function JNum(v As Decimal) As JValue
        If v = Decimal.Truncate(v) AndAlso v >= Integer.MinValue AndAlso v <= Integer.MaxValue Then
            Return New JValue(Convert.ToInt32(v))
        End If
        Return New JValue(Convert.ToDouble(v))
    End Function

    ''' <summary>Parse un nombre saisi (séparateur ',' ou '.' accepté).</summary>
    Private Function ParseDec(txt As String, ByRef ok As Boolean) As Decimal
        Dim d As Decimal
        ok = Decimal.TryParse(IsNull(txt, "").Trim.Replace(","c, "."c),
                              Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, d)
        Return d
    End Function

    ''' <summary>Opérande json d'une valeur saisie : référence si le texte est un nom
    ''' de champ connu (sauf si autoriserRef = false), constante numérique si
    ''' numérique, constante texte sinon.</summary>
    Private Function ConstOuRef(txt As String, Optional autoriserRef As Boolean = True) As JToken
        Dim t As String = IsNull(txt, "").Trim
        Dim ch = If(autoriserRef, TrouverChampParNom(t), Nothing)
        If ch IsNot Nothing Then
            Dim r As New JObject()
            r("ref") = ch.NomColonne
            Return r
        End If
        Dim ok As Boolean
        Dim d = ParseDec(t, ok)
        If ok Then Return JNum(d)
        Return New JValue(t)
    End Function

    Private Function CodeOperateur() As String
        Dim cmb As ComboBox = If(TypeCourant() IsNot Nothing AndAlso TypeCourant().Key = "COMPARE_CONST", cmbOperateur2, cmbOperateur)
        Dim o = TryCast(cmb.SelectedItem, ItemOp)
        Return If(o IsNot Nothing, o.Code, "GE")
    End Function

    ''' <summary>Construit le json 'Paramètres' selon le type de règle et les saisies.</summary>
    Private Function ConstruireParametres() As String
        Dim t = TypeCourant()
        If t Is Nothing Then Return ""
        Select Case t.Key
            Case "REQUIRED"
                Return ""
            Case "IN"
                Dim vals = txtValeurs.Text.Split(";"c).Select(Function(s) s.Trim()).Where(Function(s) s <> "").ToList()
                Dim arr As New JArray()
                For Each s In vals
                    Dim ok As Boolean
                    Dim d = ParseDec(s, ok)
                    If ok Then
                        ' Valeur numérique : ajoutée en nombre ET en texte (la comparaison
                        ' du moteur est stricte : le champ peut arriver en nombre ou en texte)
                        arr.Add(JNum(d))
                        arr.Add(New JValue(d.ToString(Globalization.CultureInfo.InvariantCulture)))
                    Else
                        arr.Add(New JValue(s))
                    End If
                Next
                Dim p As New JObject()
                p("valeurs") = arr
                Return p.ToString(Formatting.None)
            Case "MIN", "MAX", "MINLEN", "MAXLEN"
                Dim p As New JObject()
                p("valeur") = JNum(numValeur.Value)
                Return p.ToString(Formatting.None)
            Case "BETWEEN"
                Dim p As New JObject()
                p("min") = JNum(numMin.Value)
                p("max") = JNum(numMax.Value)
                Return p.ToString(Formatting.None)
            Case "REGEX"
                Dim p As New JObject()
                p("pattern") = txtPattern.Text
                Return p.ToString(Formatting.None)
            Case "COMPARE"
                Dim autre = TryCast(cmbAutreChamp.SelectedItem, ChampInfo)
                If autre Is Nothing Then Return ""
                Dim p As New JObject()
                p("operateur") = CodeOperateur()
                p("autre") = autre.NomColonne
                Return p.ToString(Formatting.None)
            Case "COMPARE_CONST"
                Dim p As New JObject()
                p("operateur") = CodeOperateur()
                p("constante") = ConstOuRef(txtConstante.Text, False)
                Return p.ToString(Formatting.None)
            Case "UNIQUE"
                Dim arr As New JArray()
                Dim c = ChampCourant()
                If c IsNot Nothing Then arr.Add(New JValue(c.NomColonne))
                For Each s In txtColonnes.Text.Split(";"c)
                    Dim n As String = s.Trim()
                    If n = "" Then Continue For
                    Dim ch = TrouverChampParNom(n)
                    Dim col As String = If(ch IsNot Nothing, ch.NomColonne, n)
                    Dim deja As Boolean = False
                    For Each v In arr
                        If v.ToString().Equals(col, StringComparison.OrdinalIgnoreCase) Then deja = True : Exit For
                    Next
                    If Not deja Then arr.Add(New JValue(col))
                Next
                Dim p As New JObject()
                p("colonnes") = arr
                Return p.ToString(Formatting.None)
            Case "NB_LIGNES"
                Dim p As New JObject()
                If chkNbMin.Checked Then p("min") = JNum(numNbMin.Value)
                If chkNbMax.Checked Then p("max") = JNum(numNbMax.Value)
                Return p.ToString(Formatting.None)
            Case "EXPR"
                Dim expr As JToken = ConstruireNoeudExpression()
                If expr Is Nothing Then Return ""
                Dim p As New JObject()
                p("expr") = expr
                Return p.ToString(Formatting.None)
        End Select
        Return ""
    End Function

    ''' <summary>Lit les lignes de la grille de conditions. Les lignes vides sont
    ''' ignorées ; les lignes partiellement remplies sont comptées dans incompletes.</summary>
    Private Function LireLignesConditions(ByRef incompletes As Integer) As List(Of JObject)
        Dim lst As New List(Of JObject)
        incompletes = 0
        For Each r As DataGridViewRow In grdCond.Rows
            If r.IsNewRow Then Continue For
            Dim cc As String = IsNull(r.Cells("colCondChamp").Value, "").Trim
            Dim op As String = IsNull(r.Cells("colCondOp").Value, "").Trim
            Dim val As String = IsNull(r.Cells("colCondValeur").Value, "").Trim
            If cc = "" AndAlso op = "" AndAlso val = "" Then Continue For
            Dim code As String = ""
            If cc = "" OrElse op = "" OrElse Not OPS_CONDITIONS.TryGetValue(op, code) Then
                incompletes += 1
                Continue For
            End If
            If code <> "EMPTY" AndAlso code <> "NOTEMPTY" AndAlso val = "" Then
                incompletes += 1
                Continue For
            End If
            Dim ch = TrouverChampParCod(cc)
            Dim arg0 As New JObject()
            arg0("ref") = If(ch IsNot Nothing, ch.NomColonne, cc)
            Dim args As New JArray()
            args.Add(arg0)
            If code <> "EMPTY" AndAlso code <> "NOTEMPTY" Then args.Add(ConstOuRef(val))
            Dim node As New JObject()
            node("op") = code
            node("args") = args
            lst.Add(node)
        Next
        Return lst
    End Function

    ''' <summary>Assemble les lignes de conditions (ET/OU) en un seul nœud json.</summary>
    Private Function ConstruireNoeudExpression() As JToken
        If rbCustom.Checked AndAlso _jsonCustom IsNot Nothing Then Return _jsonCustom.DeepClone()
        Dim incompletes As Integer
        Dim lignes = LireLignesConditions(incompletes)
        If lignes.Count = 0 Then Return Nothing
        If lignes.Count = 1 Then Return lignes(0)
        Dim n As New JObject()
        n("op") = If(rbOu.Checked, "OR", "AND")
        Dim arr As New JArray()
        For Each l In lignes : arr.Add(l) : Next
        n("args") = arr
        Return n
    End Function

    ''' <summary>Construit le json 'Condition' (vide si la règle s'applique toujours).</summary>
    Private Function ConstruireCondition() As String
        Dim t = TypeCourant()
        If t IsNot Nothing AndAlso t.Key = "EXPR" Then Return ""   ' l'expression est dans Parametres
        If rbToujours.Checked Then Return ""
        If rbCustom.Checked Then Return _jsonCustomTexte
        Dim node = ConstruireNoeudExpression()
        Return If(node Is Nothing, "", node.ToString(Formatting.None))
    End Function

    '---------------- Message suggéré ----------------

    Private Function LibelleChamp(c As ChampInfo) As String
        If c Is Nothing Then Return ""
        Return If(c.Libelle <> "", c.Libelle, c.CodChamp)
    End Function

    Private Function PhraseOperateur() As String
        Dim cmb As ComboBox = If(TypeCourant() IsNot Nothing AndAlso TypeCourant().Key = "COMPARE_CONST", cmbOperateur2, cmbOperateur)
        Dim o = TryCast(cmb.SelectedItem, ItemOp)
        Return If(o IsNot Nothing, o.Phrase, "supérieure ou égale à")
    End Function

    Private Function SuggererMessage() As String
        Dim t = TypeCourant()
        If t Is Nothing Then Return ""
        Dim libCh As String = LibelleChamp(ChampCourant())
        Select Case t.Key
            Case "REQUIRED" : Return "Le champ '" & libCh & "' est obligatoire."
            Case "COMPARE"
                Dim autre = TryCast(cmbAutreChamp.SelectedItem, ChampInfo)
                Return "La valeur de '" & libCh & "' doit être " & PhraseOperateur() & " celle de '" & LibelleChamp(autre) & "'."
            Case "COMPARE_CONST"
                Return "La valeur de '" & libCh & "' doit être " & PhraseOperateur() & " " & txtConstante.Text.Trim & "."
            Case "IN" : Return "La valeur de '" & libCh & "' ne fait pas partie des valeurs autorisées."
            Case "MIN" : Return "'" & libCh & "' doit être supérieur ou égal à " & numValeur.Value.ToString() & "."
            Case "MAX" : Return "'" & libCh & "' doit être inférieur ou égal à " & numValeur.Value.ToString() & "."
            Case "BETWEEN" : Return "'" & libCh & "' doit être compris entre " & numMin.Value.ToString() & " et " & numMax.Value.ToString() & "."
            Case "MINLEN" : Return "'" & libCh & "' doit contenir au moins " & numValeur.Value.ToString() & " caractère(s)."
            Case "MAXLEN" : Return "'" & libCh & "' doit contenir au plus " & numValeur.Value.ToString() & " caractère(s)."
            Case "REGEX" : Return "Le format de '" & libCh & "' est invalide."
            Case "UNIQUE" : Return "Doublon interdit sur '" & libCh & "' : cette valeur existe déjà dans une autre ligne."
            Case "NB_LIGNES"
                Dim tabc = TableChoisie()
                Dim nom As String = If(tabc IsNot Nothing, tabc.CodTable, "")
                If chkNbMin.Checked AndAlso chkNbMax.Checked Then
                    Return "Le tableau '" & nom & "' doit contenir entre " & numNbMin.Value.ToString() & " et " & numNbMax.Value.ToString() & " ligne(s)."
                ElseIf chkNbMin.Checked Then
                    Return "Le tableau '" & nom & "' doit contenir au moins " & numNbMin.Value.ToString() & " ligne(s)."
                Else
                    Return "Le tableau '" & nom & "' doit contenir au plus " & numNbMax.Value.ToString() & " ligne(s)."
                End If
            Case "EXPR" : Return "La règle personnalisée n'est pas respectée."
        End Select
        Return ""
    End Function

    ''' <summary>Régénère l'aperçu json et (tant que l'utilisateur ne l'a pas
    ''' modifié) le message suggéré.</summary>
    Private Sub Regenerer()
        If _enMaj Then Return
        Try
            txtParamJson.Text = ConstruireParametres()
            txtCondJson.Text = ConstruireCondition()
            If Not _messageTouche Then
                _enMaj = True
                txtMessage.Text = SuggererMessage()
                _enMaj = False
            End If
        Catch
        End Try
    End Sub

    '---------------- Chargement d'une règle existante (modification) ----------------

    Private Function PStr(p As JObject, cle As String) As String
        If p Is Nothing OrElse p(cle) Is Nothing Then Return ""
        Return p(cle).ToString()
    End Function
    Private Function PDecNum(p As JObject, cle As String) As Decimal
        Dim ok As Boolean
        Dim d = ParseDec(PStr(p, cle), ok)
        Return If(ok, d, 0D)
    End Function
    Private Function BornerNum(v As Decimal, num As NumericUpDown) As Decimal
        If v < num.Minimum Then Return num.Minimum
        If v > num.Maximum Then Return num.Maximum
        Return v
    End Function
    Private Sub ChoisirOperateur(cmb As ComboBox, code As String)
        For i As Integer = 0 To cmb.Items.Count - 1
            Dim o = TryCast(cmb.Items(i), ItemOp)
            If o IsNot Nothing AndAlso o.Code.Equals(code, StringComparison.OrdinalIgnoreCase) Then
                cmb.SelectedIndex = i : Return
            End If
        Next
    End Sub

    Private Sub ChargerLigne(r As DataRow)
        _enMaj = True
        Dim typ As String = IsNull(r("Typ_Regle"), "").Trim
        Dim p As JObject = Nothing
        Try
            p = CType(JToken.Parse(IsNull(r("Parametres"), "")), JObject)
        Catch
            p = Nothing
        End Try
        Dim cle As String = typ
        If typ = "COMPARE" AndAlso p IsNot Nothing AndAlso p("constante") IsNot Nothing Then cle = "COMPARE_CONST"
        For i As Integer = 0 To cmbType.Items.Count - 1
            If DirectCast(cmbType.Items(i), ItemTypeRegle).Key = cle Then cmbType.SelectedIndex = i : Exit For
        Next
        MajSections()
        ' Champ / tableau
        Dim codChamp As String = IsNull(r("Cod_Champ"), "").Trim
        If cle = "NB_LIGNES" Then
            ChoisirTable(IsNull(r("Cod_Table"), "").Trim)
        ElseIf codChamp <> "" Then
            ChoisirChamp(codChamp)
        End If
        RemplirAutresChamps()
        ' Paramètres
        Select Case cle
            Case "IN"
                If p IsNot Nothing AndAlso TryCast(p("valeurs"), JArray) IsNot Nothing Then
                    Dim parts As New List(Of String)
                    For Each v In CType(p("valeurs"), JArray)
                        ' (les valeurs numériques sont stockées en double exemplaire : nombre + texte)
                        Dim s As String = v.ToString()
                        If Not parts.Contains(s, StringComparer.OrdinalIgnoreCase) Then parts.Add(s)
                    Next
                    txtValeurs.Text = String.Join(" ; ", parts)
                End If
            Case "MIN", "MAX", "MINLEN", "MAXLEN"
                numValeur.Value = BornerNum(PDecNum(p, "valeur"), numValeur)
            Case "BETWEEN"
                numMin.Value = BornerNum(PDecNum(p, "min"), numMin)
                numMax.Value = BornerNum(PDecNum(p, "max"), numMax)
            Case "REGEX"
                txtPattern.Text = PStr(p, "pattern")
                Dim trouve As Boolean = False
                For i As Integer = 0 To cmbPreset.Items.Count - 1
                    If DirectCast(cmbPreset.Items(i), ItemRegex).Pattern = txtPattern.Text Then
                        cmbPreset.SelectedIndex = i : trouve = True : Exit For
                    End If
                Next
                If Not trouve Then cmbPreset.SelectedIndex = cmbPreset.Items.Count - 1   ' Personnalisé
            Case "COMPARE"
                ChoisirOperateur(cmbOperateur, PStr(p, "operateur"))
                Dim ch = TrouverChampParNom(PStr(p, "autre"))
                If ch IsNot Nothing Then
                    For i As Integer = 0 To cmbAutreChamp.Items.Count - 1
                        If DirectCast(cmbAutreChamp.Items(i), ChampInfo).NomColonne.Equals(ch.NomColonne, StringComparison.OrdinalIgnoreCase) Then
                            cmbAutreChamp.SelectedIndex = i : Exit For
                        End If
                    Next
                End If
            Case "COMPARE_CONST"
                ChoisirOperateur(cmbOperateur2, PStr(p, "operateur"))
                txtConstante.Text = PStr(p, "constante")
            Case "UNIQUE"
                Dim cols As New List(Of String)
                If p IsNot Nothing AndAlso TryCast(p("colonnes"), JArray) IsNot Nothing Then
                    For Each v In CType(p("colonnes"), JArray) : cols.Add(v.ToString()) : Next
                End If
                Dim c = ChampCourant()
                If c IsNot Nothing AndAlso cols.Count > 0 AndAlso
                   cols(0).Equals(c.NomColonne, StringComparison.OrdinalIgnoreCase) Then cols.RemoveAt(0)
                txtColonnes.Text = String.Join(" ; ", cols)
            Case "NB_LIGNES"
                chkNbMin.Checked = (p IsNot Nothing AndAlso p("min") IsNot Nothing)
                chkNbMax.Checked = (p IsNot Nothing AndAlso p("max") IsNot Nothing)
                numNbMin.Value = BornerNum(PDecNum(p, "min"), numNbMin)
                numNbMax.Value = BornerNum(PDecNum(p, "max"), numNbMax)
        End Select
        ' Condition d'application (ou expression pour EXPR)
        Dim src As String = IsNull(r("Condition_Regle"), "").Trim
        If cle = "EXPR" Then
            src = ""
            If p IsNot Nothing AndAlso p("expr") IsNot Nothing Then src = p("expr").ToString(Formatting.None)
        End If
        If src = "" Then
            If cle = "EXPR" Then rbSi.Checked = True Else rbToujours.Checked = True
        ElseIf EssayerChargerConditions(src) Then
            rbSi.Checked = True
        Else
            ' Forme non représentable par l'assistant : conservée telle quelle
            _jsonCustomTexte = src
            Try
                _jsonCustom = JToken.Parse(src)
            Catch
                _jsonCustom = Nothing
            End Try
            txtCustomCond.Text = src
            rbCustom.Visible = True
            rbCustom.Checked = True
        End If
        MajEtatCondition()
        ' Message et gravité existants (conservés : jamais écrasés par la suggestion)
        txtMessage.Text = IsNull(r("Message"), "")
        _messageTouche = True
        Dim nv As String = IsNull(r("Niveau"), "B")
        For i As Integer = 0 To cmbNiveau.Items.Count - 1
            If DirectCast(cmbNiveau.Items(i), ItemNiveau).Code = nv Then cmbNiveau.SelectedIndex = i : Exit For
        Next
        _enMaj = False
        Regenerer()
    End Sub

    ''' <summary>Traduit une condition json existante en lignes de la grille.
    ''' Retourne False si la forme n'est pas représentable par l'assistant.</summary>
    Private Function EssayerChargerConditions(src As String) As Boolean
        Dim node As JObject = Nothing
        Try
            node = CType(JToken.Parse(src), JObject)
        Catch
            Return False
        End Try
        If node Is Nothing OrElse node("op") Is Nothing Then Return False
        Dim ops As New List(Of JObject)
        Dim combiner As String = "AND"
        Dim top As String = node("op").ToString().ToUpper()
        If top = "AND" OrElse top = "OR" Then
            combiner = top
            Dim ja = TryCast(node("args"), JArray)
            If ja Is Nothing OrElse ja.Count = 0 Then Return False
            For Each a In ja
                Dim o = TryCast(a, JObject)
                If o Is Nothing Then Return False
                ops.Add(o)
            Next
        Else
            ops.Add(node)
        End If
        Dim lignes As New List(Of String())
        For Each o In ops
            Dim l = LireLigneCondition(o)
            If l Is Nothing Then Return False
            lignes.Add(l)
        Next
        grdCond.Rows.Clear()
        For Each l In lignes
            grdCond.Rows.Add(l(0), l(1), l(2))
        Next
        If combiner = "OR" Then rbOu.Checked = True Else rbEt.Checked = True
        Return True
    End Function

    ''' <summary>Traduit un opérateur json élémentaire en ligne {champ, condition, valeur}.</summary>
    Private Function LireLigneCondition(o As JObject) As String()
        If o("op") Is Nothing Then Return Nothing
        Dim code As String = o("op").ToString().ToUpper()
        If Not OPS_INVERSE.ContainsKey(code) Then Return Nothing
        Dim ja = TryCast(o("args"), JArray)
        If ja Is Nothing OrElse ja.Count < 1 Then Return Nothing
        Dim a0 = TryCast(ja(0), JObject)
        If a0 Is Nothing OrElse a0("ref") Is Nothing Then Return Nothing
        Dim ch = TrouverChampParNom(a0("ref").ToString())
        If ch Is Nothing Then Return Nothing   ' référence inconnue : hors périmètre de l'assistant
        Dim valTxt As String = ""
        If code <> "EMPTY" AndAlso code <> "NOTEMPTY" Then
            If ja.Count < 2 Then Return Nothing
            valTxt = TexteVersValeurCellule(ja(1))
            If valTxt Is Nothing Then Return Nothing
        End If
        Return New String() {ch.CodChamp, OPS_INVERSE(code), valTxt}
    End Function

    ''' <summary>Traduit un opérande json (const/ref/littéral) en texte de cellule.</summary>
    Private Function TexteVersValeurCellule(t As JToken) As String
        If t Is Nothing Then Return Nothing
        Dim o = TryCast(t, JObject)
        If o IsNot Nothing Then
            If o("const") IsNot Nothing Then Return o("const").ToString()
            If o("ref") IsNot Nothing Then
                Dim ch = TrouverChampParNom(o("ref").ToString())
                If ch Is Nothing Then Return Nothing
                Return ch.CodChamp
            End If
            Return Nothing
        End If
        Return t.ToString()
    End Function

    '---------------- Validation et insertion ----------------

    Private Function ValiderSaisie() As List(Of String)
        Dim erreurs As New List(Of String)
        Dim t = TypeCourant()
        Dim c = ChampCourant()
        Select Case t.Key
            Case "NB_LIGNES"
                If TableChoisie() Is Nothing Then erreurs.Add("Choisissez le tableau concerné (étape 2).")
                If Not chkNbMin.Checked AndAlso Not chkNbMax.Checked Then erreurs.Add("Cochez au moins une borne 'au moins' ou 'au plus' (étape 3).")
                If chkNbMin.Checked AndAlso chkNbMax.Checked AndAlso numNbMin.Value > numNbMax.Value Then
                    erreurs.Add("Le nombre minimal de lignes est supérieur au nombre maximal (étape 3).")
                End If
            Case "EXPR"
                If Not rbCustom.Checked Then
                    Dim inc As Integer
                    If LireLignesConditions(inc).Count = 0 Then erreurs.Add("Décrivez au moins une condition (étape 4).")
                    If inc > 0 Then erreurs.Add("Certaines conditions sont incomplètes : complétez-les ou supprimez-les (étape 4).")
                End If
            Case Else
                If c Is Nothing Then erreurs.Add("Choisissez le champ concerné (étape 2).")
                Select Case t.Key
                    Case "COMPARE"
                        If cmbAutreChamp.SelectedItem Is Nothing Then erreurs.Add("Choisissez le champ de comparaison (étape 3).")
                    Case "COMPARE_CONST"
                        If txtConstante.Text.Trim = "" Then erreurs.Add("Indiquez la valeur de comparaison (étape 3).")
                    Case "IN"
                        If txtValeurs.Text.Split(";"c).Where(Function(s) s.Trim() <> "").Count() = 0 Then
                            erreurs.Add("Indiquez au moins une valeur autorisée (étape 3).")
                        End If
                    Case "BETWEEN"
                        If numMin.Value > numMax.Value Then erreurs.Add("La borne minimale est supérieure à la borne maximale (étape 3).")
                    Case "REGEX"
                        If txtPattern.Text.Trim = "" Then
                            erreurs.Add("Indiquez l'expression régulière (étape 3).")
                        Else
                            Try
                                Dim re As New System.Text.RegularExpressions.Regex(txtPattern.Text)
                            Catch
                                erreurs.Add("L'expression régulière est invalide (étape 3).")
                            End Try
                        End If
                End Select
                If rbSi.Checked Then
                    Dim inc As Integer
                    LireLignesConditions(inc)
                    If inc > 0 Then erreurs.Add("Certaines conditions sont incomplètes : complétez-les ou supprimez-les (étape 4).")
                End If
        End Select
        If txtMessage.Text.Trim = "" Then erreurs.Add("Le message affiché à l'utilisateur est obligatoire (étape 5).")
        Return erreurs
    End Function

    Private Sub btnInserer_Click(sender As Object, e As EventArgs) Handles btnInserer.Click
        Dim erreurs = ValiderSaisie()
        If erreurs.Count > 0 Then
            ShowMessageBox("Corrigez les points suivants :" & vbCrLf & " - " & String.Join(vbCrLf & " - ", erreurs),
                           "Assistant", MessageBoxButtons.OK, msgIcon.Warning)
            Return
        End If
        Dim t = TypeCourant()
        Dim c = ChampCourant()
        Me.TypRegle = If(t.Key = "COMPARE_CONST", "COMPARE", t.Key)
        Me.Parametres = ConstruireParametres()
        Me.Condition = ConstruireCondition()
        Me.Message = txtMessage.Text.Trim
        Me.Niveau = DirectCast(cmbNiveau.SelectedItem, ItemNiveau).Code
        Select Case t.Key
            Case "NB_LIGNES"
                Me.Portee = "DETAIL"
                Me.CodTable = TableChoisie().CodTable
                Me.CodChamp = ""
            Case "UNIQUE"
                Me.Portee = "DETAIL"
                Me.CodTable = c.CodTable
                Me.CodChamp = c.CodChamp
            Case "EXPR"
                Me.Portee = "DOCUMENT"
                Me.CodTable = ""
                Me.CodChamp = ""
            Case Else
                Me.CodChamp = c.CodChamp
                If c.CodTable = "ENT" Then
                    Me.Portee = "CHAMP"
                    Me.CodTable = "ENT"
                Else
                    Me.Portee = "LIGNE"
                    Me.CodTable = c.CodTable
                End If
        End Select
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    '---------------- Événements : régénération automatique de l'aperçu ----------------

    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        If Not _uiPrete Then Return
        MajSections()
        Regenerer()
    End Sub

    Private Sub cmbChamp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbChamp.SelectedIndexChanged
        If Not _uiPrete Then Return
        RemplirAutresChamps()
        Regenerer()
    End Sub

    Private Sub Params_Changed(sender As Object, e As EventArgs) _
        Handles numValeur.ValueChanged, numMin.ValueChanged, numMax.ValueChanged,
                numNbMin.ValueChanged, numNbMax.ValueChanged, chkNbMin.CheckedChanged, chkNbMax.CheckedChanged,
                txtValeurs.TextChanged, txtPattern.TextChanged, txtConstante.TextChanged, txtColonnes.TextChanged,
                cmbOperateur.SelectedIndexChanged, cmbOperateur2.SelectedIndexChanged, cmbAutreChamp.SelectedIndexChanged
        If Not _uiPrete Then Return
        Regenerer()
    End Sub

    Private Sub cmbPreset_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPreset.SelectedIndexChanged
        If Not _uiPrete Then Return
        Dim pr = TryCast(cmbPreset.SelectedItem, ItemRegex)
        If pr IsNot Nothing AndAlso pr.Pattern <> "" Then txtPattern.Text = pr.Pattern
        Regenerer()
    End Sub

    Private Sub Condition_Changed(sender As Object, e As EventArgs) _
        Handles rbToujours.CheckedChanged, rbSi.CheckedChanged, rbCustom.CheckedChanged,
                rbEt.CheckedChanged, rbOu.CheckedChanged
        If Not _uiPrete Then Return
        MajEtatCondition()
        Regenerer()
    End Sub

    Private Sub grdCond_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles grdCond.DefaultValuesNeeded
        e.Row.Cells("colCondOp").Value = "est renseigné"
        If _champs.Count > 0 Then e.Row.Cells("colCondChamp").Value = _champs(0).CodChamp
    End Sub

    Private Sub grdCond_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles grdCond.CurrentCellDirtyStateChanged
        ' Valide immédiatement les listes déroulantes (sinon la valeur reste en cours d'édition)
        If grdCond.IsCurrentCellDirty Then grdCond.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub grdCond_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grdCond.CellValueChanged
        Regenerer()
    End Sub

    Private Sub grdCond_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles grdCond.RowsRemoved
        Regenerer()
    End Sub

    ''' <summary>Une valeur hors liste (données anciennes) ne doit pas interrompre l'assistant.</summary>
    Private Sub grdCond_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles grdCond.DataError
        e.ThrowException = False
    End Sub

    Private Sub txtMessage_TextChanged(sender As Object, e As EventArgs) Handles txtMessage.TextChanged
        If Not _enMaj Then _messageTouche = True
    End Sub

End Class
