Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

''' <summary>
''' Assistant de création / modification d'une formule de champ calculé
''' (colonne "Formule (json)" de l'onglet "Champs de la page" du SP_Page_Designer).
''' L'utilisateur non technique compose la formule en cliquant : champs de la page,
''' variables globales GV_*, opérateurs autorisés (+ - * / parenthèses, comparaisons)
''' et fonctions regroupées par familles : texte (GAUCHE, DROITE, STXT, POSITION,
''' LONGUEUR, MAJUSCULE, MINUSCULE, SUPPRESPACE, REMPLACE, CONCAT, CONTIENT),
''' dates (DUREE, AJOUTDATE, ANNEE, MOIS, JOUR, PARTDATE, JOURSEM),
''' nombres (ARRONDI, ABS, ENT, PLAFOND, PLANCHER, MIN, MAX),
''' conditions (SI, VIDE, REMPLI) et agrégats de tableau (SOMME, MOYENNE, MIN, MAX, NB).
''' Un parser dédié (AUCUNE évaluation dynamique de code) convertit le texte en json
''' déclaratif attendu par le moteur (module_sp_engine.ts / dynamicEngine.ts) : seuls
''' les champs connus, les GV_* connues et les opérateurs whitelistés peuvent être
''' produits — aucune injection n'est possible. Un évaluateur miroir (VB) permet de
''' tester la formule avec des valeurs d'essai avant enregistrement.
''' Le formulaire est entièrement construit dans le code (à l'abri de la
''' régénération du Designer par Visual Studio).
''' </summary>
Public Class Zoom_SP_Assistant_Formule
    Inherits Form

    '---------------- Résultat (lu par l'appelant après DialogResult.OK) ----------------
    Public FormuleJson As String = ""

    '---------------- Données de référence ----------------
    Private Class ChampInfo
        Public CodChamp As String
        Public NomColonne As String
        Public CodTable As String
        Public Libelle As String
        Public TypControle As String
        Public Overrides Function ToString() As String
            Return CodChamp & If(Libelle <> "", " — " & Libelle, "") & If(CodTable <> "ENT", "   [" & CodTable & "]", "")
        End Function
    End Class
    Private Class GvInfo
        Public Nom As String
        Public Libelle As String
        Public Overrides Function ToString() As String
            Return Nom & " — " & Libelle
        End Function
    End Class
    Private Class ItemExemple
        Public Label As String
        Public Texte As String        ' Nothing pour la ligne d'invite
        Public Overrides Function ToString() As String
            Return Label
        End Function
    End Class

    '---------------- Tokens du parser ----------------
    Private Enum TT As Integer
        Nombre
        Ident
        Chaine
        Op
        Fin
    End Enum
    Private Class Tok
        Public Type As TT
        Public Texte As String
        Public Pos As Integer
    End Class
    Private Class ErreurFormule
        Inherits Exception
        Public Pos As Integer
        Public Sub New(msg As String, pos As Integer)
            MyBase.New(msg)
            Me.Pos = pos
        End Sub
    End Class

    '---------------- Correspondances (langage français -> opérateurs moteur) ----------------
    Private Shared ReadOnly OPS_COMP As New Dictionary(Of String, String) From {
        {"=", "EQ"}, {"<>", "NE"}, {">", "GT"}, {">=", "GE"}, {"<", "LT"}, {"<=", "LE"}}
    Private Shared ReadOnly OPS_COMP_INVERS As New Dictionary(Of String, String) From {
        {"EQ", " = "}, {"NE", " <> "}, {"GT", " > "}, {"GE", " >= "}, {"LT", " < "}, {"LE", " <= "}}
    Private Shared ReadOnly FONCTIONS As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) From {
        "ARRONDI", "ABS", "SI", "DUREE", "SOMME", "MOYENNE", "MIN", "MAX", "NB", "VIDE", "REMPLI",
        "GAUCHE", "DROITE", "STXT", "POSITION", "LONGUEUR", "MAJUSCULE", "MINUSCULE", "SUPPRESPACE",
        "REMPLACE", "CONCAT", "CONTIENT",
        "AJOUTDATE", "PARTDATE", "ANNEE", "MOIS", "JOUR", "JOURSEM",
        "ENT", "PLAFOND", "PLANCHER"}
    Private Shared ReadOnly AGREGATS As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
        {"SOMME", "SUM"}, {"MOYENNE", "AVG"}, {"MIN", "MIN"}, {"MAX", "MAX"}, {"NB", "COUNT"}}
    Private Shared ReadOnly AGREGATS_INVERS As New Dictionary(Of String, String) From {
        {"SUM", "SOMME"}, {"AVG", "MOYENNE"}, {"MIN", "MIN"}, {"MAX", "MAX"}, {"COUNT", "NB"}}
    Private Shared ReadOnly TYP_NUMERIQUES As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) From {
        "INT", "DEC", "MNT"}
    ' Whitelist miroir de validerExpression() du moteur (contrôle final avant enregistrement)
    Private Shared ReadOnly OPS_VALIDES As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) From {
        "AND", "OR", "NOT", "EQ", "NE", "GT", "GE", "LT", "LE", "IN", "EMPTY", "NOTEMPTY", "CONTIENT",
        "ADD", "SUB", "MUL", "DIVSAFE", "COND", "SUM", "AVG", "MIN", "MAX", "COUNT", "ROUND", "ABS",
        "REF", "CONST", "DATEDIFF",
        "LEFT", "RIGHT", "SUBSTRING", "INDEXOF", "LEN", "UPPER", "LOWER", "TRIM", "REPLACE", "CONCAT",
        "INT", "CEIL", "FLOOR", "DATEADD", "DATEPART", "DAYOFWEEK"}

    Private _champs As New List(Of ChampInfo)
    Private _gvs As New List(Of GvInfo)
    Private _gvNoms As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
    Private _nomCible As String = ""             ' Nom_Colonne du champ calculé (auto-référence interdite)
    Private _codCible As String = ""
    Private _jsonInitial As String = ""
    Private _nonRepresentable As Boolean = False ' formule existante hors périmètre de l'assistant
    Private _enMaj As Boolean = False
    Private _uiPrete As Boolean = False
    Private _ast As JToken = Nothing             ' dernier arbre valide (pour le test)

    ' État du parser
    Private _toks As List(Of Tok)
    Private _p As Integer
    Private _prof As Integer

    ' Valeurs du test (étape 3)
    Private _valChamps As New Dictionary(Of String, Object)(StringComparer.OrdinalIgnoreCase)
    Private _valAgg As New Dictionary(Of String, List(Of Double))(StringComparer.OrdinalIgnoreCase)
    Private _valCnt As New Dictionary(Of String, Double)(StringComparer.OrdinalIgnoreCase)

    '---------------- Contrôles (déclarés WithEvents : créés dans ConstruireUI) ----------------
    Private WithEvents lstChamps As ListBox
    Private WithEvents lstGV As ListBox
    Private WithEvents btnInsererChamp As Button
    Private WithEvents btnInsererGV As Button
    Private WithEvents cmbExemples As ComboBox
    Private WithEvents txtFormule As TextBox
    Private WithEvents lblStatut As Label
    Private WithEvents grdTest As DataGridView
    Private WithEvents btnCalculer As Button
    Private WithEvents lblResultat As Label
    Private WithEvents txtJson As TextBox
    Private WithEvents btnAide As Button
    Private WithEvents btnEnregistrer As Button
    Private WithEvents btnAnnuler As Button
    Private menuTexte As ContextMenuStrip
    Private menuDates As ContextMenuStrip
    Private menuNombres As ContextMenuStrip
    Private menuCondition As ContextMenuStrip
    Private menuAgregat As ContextMenuStrip

    '---------------- Construction ----------------

    ''' <summary>Crée l'assistant. nomColonneCible / codChampCible identifient le champ
    ''' calculé en cours d'édition (exclu de la liste : auto-référence interdite) ;
    ''' formuleExistante (json) est reconvertie en texte français si représentable.</summary>
    Public Sub New(tblChamps As DataTable, nomColonneCible As String, codChampCible As String, formuleExistante As String)
        Me.Font = New Font("Century Gothic", 8.25!)
        Me.Text = "Assistant de formule (champ calculé)"
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False : Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ClientSize = New Size(900, 718)
        Me.BackColor = Color.White
        Me.ShowInTaskbar = False
        _nomCible = IsNull(nomColonneCible, "").Trim
        _codCible = IsNull(codChampCible, "").Trim
        _jsonInitial = IsNull(formuleExistante, "").Trim
        ChargerReferences(tblChamps)
        ConstruireUI()
        If _jsonInitial <> "" Then
            Dim txt As String = TexteDepuisJson(_jsonInitial)
            If txt IsNot Nothing Then
                _enMaj = True : txtFormule.Text = txt : _enMaj = False
            Else
                ' Formule existante hors périmètre : conservée telle quelle, affichée en aperçu
                _nonRepresentable = True
                txtJson.Text = _jsonInitial
            End If
        End If
        AnalyserEtAfficher()
    End Sub

    ''' <summary>Extrait les champs de la page (le champ calculé en cours est exclu)
    ''' et prépare la liste des variables globales résolues par le moteur.</summary>
    Private Sub ChargerReferences(tblChamps As DataTable)
        If tblChamps IsNot Nothing Then
            For Each r As DataRow In tblChamps.Rows
                If r.RowState = DataRowState.Deleted Then Continue For
                Dim cc As String = IsNull(r("Cod_Champ"), "").Trim
                If cc = "" Then Continue For
                If cc.Equals(_codCible, StringComparison.OrdinalIgnoreCase) Then Continue For
                Dim nc As String = IsNull(r("Nom_Colonne"), "").Trim
                If nc = "" Then nc = cc
                _champs.Add(New ChampInfo With {.CodChamp = cc, .NomColonne = nc,
                            .CodTable = If(IsNull(r("Cod_Table"), "ENT").Trim = "", "ENT", IsNull(r("Cod_Table"), "ENT").Trim),
                            .Libelle = IsNull(r("Libelle"), "").Trim,
                            .TypControle = IsNull(r("Typ_Controle"), "TEXT").Trim})
            Next
        End If
        ' Variables globales : exactement celles résolues par variableGlobale() du moteur
        _gvs.AddRange(New GvInfo() {
            New GvInfo With {.Nom = "GV_NOW", .Libelle = "Date et heure du moment"},
            New GvInfo With {.Nom = "GV_DEBMOIS", .Libelle = "Premier jour du mois en cours"},
            New GvInfo With {.Nom = "GV_FINMOIS", .Libelle = "Dernier jour du mois en cours"},
            New GvInfo With {.Nom = "GV_DEBYEAR", .Libelle = "Premier jour de l'année en cours"},
            New GvInfo With {.Nom = "GV_YEAR", .Libelle = "Année en cours (ex : 2026)"},
            New GvInfo With {.Nom = "GV_MONTH", .Libelle = "Mois en cours (1 à 12)"},
            New GvInfo With {.Nom = "GV_DAY", .Libelle = "Jour du mois en cours (1 à 31)"}})
        For Each g In _gvs : _gvNoms.Add(g.Nom) : Next
    End Sub

    Private Function Lbl(texte As String, x As Integer, y As Integer, w As Integer, Optional hauteur As Integer = 20) As Label
        Return New Label With {.Text = texte, .Location = New Point(x, y), .Size = New Size(w, hauteur), .AutoSize = False}
    End Function
    Private Function LblAide(texte As String, x As Integer, y As Integer, w As Integer, Optional hauteur As Integer = 20) As Label
        Return New Label With {.Text = texte, .Location = New Point(x, y), .Size = New Size(w, hauteur),
                               .ForeColor = Color.FromArgb(110, 110, 110), .AutoSize = False}
    End Function
    ''' <summary>Bouton plat de la zone opérateurs / fonctions.</summary>
    Private Function BtnOp(texte As String, insere As String, x As Integer, y As Integer, Optional w As Integer = 62) As Button
        Dim b As New Button With {.Text = texte, .Location = New Point(x, y), .Size = New Size(w, 26),
                                  .FlatStyle = FlatStyle.Flat, .BackColor = Color.FromArgb(245, 248, 250)}
        b.FlatAppearance.BorderColor = Color.FromArgb(200, 210, 215)
        If insere <> "" Then AddHandler b.Click, Sub() InsererAuCurseur(insere)
        Return b
    End Function
    ''' <summary>Construit toute l'interface (disposition fixe, formulaire non redimensionnable).</summary>
    Private Sub ConstruireUI()
        Dim main As New TableLayoutPanel With {.Dock = DockStyle.Fill, .ColumnCount = 1, .Padding = New Padding(10, 8, 10, 8)}
        main.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
        For Each h As Single In New Single() {24, 30, 250, 106, 190, 56, 46}
            main.RowStyles.Add(New RowStyle(SizeType.Absolute, h))
        Next
        Me.Controls.Add(main)

        Dim lblTitre As Label = Lbl("Assistant de formule — champ calculé", 0, 0, 800)
        lblTitre.Font = New Font("Century Gothic", 11.0!, FontStyle.Bold)
        lblTitre.ForeColor = colorBase01
        main.Controls.Add(lblTitre, 0, 0)
        Dim lblIntro As Label = LblAide("Composez la formule en cliquant : aucun code à écrire. Seuls les champs de la page, les variables GV_ et les opérateurs autorisés sont acceptés ; la syntaxe json du moteur est générée automatiquement.", 0, 0, 870)
        lblIntro.Dock = DockStyle.Fill
        main.Controls.Add(lblIntro, 0, 1)

        '---------------- 1. Éléments à insérer ----------------
        Dim grpElem As New GroupBox With {.Text = "1. Choisissez les éléments (double-clic pour insérer à la position du curseur)", .Dock = DockStyle.Fill}
        grpElem.Controls.Add(Lbl("Champs de la page :", 10, 16, 330))
        lstChamps = New ListBox With {.Location = New Point(10, 36), .Size = New Size(330, 142)}
        For Each c In _champs : lstChamps.Items.Add(c) : Next
        grpElem.Controls.Add(lstChamps)
        btnInsererChamp = New Button With {.Text = "Insérer le champ sélectionné", .Location = New Point(10, 182), .Size = New Size(330, 26),
                                           .FlatStyle = FlatStyle.Flat, .BackColor = Color.FromArgb(245, 248, 250)}
        grpElem.Controls.Add(btnInsererChamp)
        grpElem.Controls.Add(Lbl("Variables globales (automatiques) :", 350, 16, 240))
        lstGV = New ListBox With {.Location = New Point(350, 36), .Size = New Size(240, 142)}
        For Each g In _gvs : lstGV.Items.Add(g) : Next
        grpElem.Controls.Add(lstGV)
        btnInsererGV = New Button With {.Text = "Insérer la variable", .Location = New Point(350, 182), .Size = New Size(240, 26),
                                        .FlatStyle = FlatStyle.Flat, .BackColor = Color.FromArgb(245, 248, 250)}
        grpElem.Controls.Add(btnInsererGV)
        grpElem.Controls.Add(Lbl("Partir d'un exemple :", 10, 216, 135))
        cmbExemples = New ComboBox With {.Location = New Point(150, 214), .Size = New Size(440, 24), .DropDownStyle = ComboBoxStyle.DropDownList}
        grpElem.Controls.Add(cmbExemples)

        ' Zone opérateurs (x = 600..866)
        Dim ops1 As String() = {"+", "-", "*", "/"}
        For i As Integer = 0 To 3 : grpElem.Controls.Add(BtnOp(ops1(i), " " & ops1(i) & " ", 600 + i * 68, 20)) : Next
        grpElem.Controls.Add(BtnOp("(", "(", 600, 50))
        grpElem.Controls.Add(BtnOp(")", ")", 668, 50))
        grpElem.Controls.Add(BtnOp("=", " = ", 736, 50))
        grpElem.Controls.Add(BtnOp("<>", " <> ", 804, 50))
        Dim ops3 As String() = {">", ">=", "<", "<="}
        For i As Integer = 0 To 3 : grpElem.Controls.Add(BtnOp(ops3(i), " " & ops3(i) & " ", 600 + i * 68, 80)) : Next
        grpElem.Controls.Add(BtnOp("ET", " ET ", 600, 110))
        grpElem.Controls.Add(BtnOp("OU", " OU ", 668, 110))
        grpElem.Controls.Add(BtnOp("NON", "NON ", 736, 110))

        ' Zone fonctions : menus par famille ; chaque élément insère un modèle
        ' avec le paramètre à compléter présélectionné
        Dim btnTexte As Button = BtnOp("Texte ▾", "", 600, 144, 129)
        grpElem.Controls.Add(btnTexte)
        Dim btnDates As Button = BtnOp("Dates ▾", "", 737, 144, 129)
        grpElem.Controls.Add(btnDates)
        Dim btnNombres As Button = BtnOp("Nombres ▾", "", 600, 174, 129)
        grpElem.Controls.Add(btnNombres)
        Dim btnCondition As Button = BtnOp("Condition ▾", "", 737, 174, 129)
        grpElem.Controls.Add(btnCondition)
        Dim btnAgregat As Button = BtnOp("Tableau (somme…) ▾", "", 600, 204, 129)
        grpElem.Controls.Add(btnAgregat)
        btnAide = New Button With {.Text = "? Guide pas à pas", .Location = New Point(737, 204), .Size = New Size(129, 26),
                                   .FlatStyle = FlatStyle.Flat, .BackColor = Color.FromArgb(245, 248, 250)}
        grpElem.Controls.Add(btnAide)

        ' Menu "Texte" : traitement des chaînes de caractères
        menuTexte = New ContextMenuStrip()
        menuTexte.Items.Add(ItemModele("GAUCHE : les n premiers caractères", "GAUCHE(texte; 3)", 7, 5))
        menuTexte.Items.Add(ItemModele("DROITE : les n derniers caractères", "DROITE(texte; 3)", 7, 5))
        menuTexte.Items.Add(ItemModele("STXT : extrait une partie du texte", "STXT(texte; 2; 3)", 5, 5))
        menuTexte.Items.Add(ItemModele("POSITION : rang d'un texte dans un autre (0 = absent)", "POSITION(morceau; texte)", 9, 7))
        menuTexte.Items.Add(ItemModele("LONGUEUR : nombre de caractères", "LONGUEUR(texte)", 9, 5))
        menuTexte.Items.Add(New ToolStripSeparator())
        menuTexte.Items.Add(ItemModele("MAJUSCULE", "MAJUSCULE(texte)", 10, 5))
        menuTexte.Items.Add(ItemModele("MINUSCULE", "MINUSCULE(texte)", 10, 5))
        menuTexte.Items.Add(ItemModele("SUPPRESPACE : retire les espaces du début et de la fin", "SUPPRESPACE(texte)", 12, 5))
        menuTexte.Items.Add(ItemModele("REMPLACE : remplace un texte par un autre", "REMPLACE(texte; ""ancien""; ""nouveau"")", 9, 5))
        menuTexte.Items.Add(New ToolStripSeparator())
        menuTexte.Items.Add(ItemModele("CONCAT : assemble plusieurs textes", "CONCAT(texte1; texte2)", 7, 6))
        menuTexte.Items.Add(ItemModele("CONTIENT : vrai si le texte contient…", "CONTIENT(texte; ""morceau"")", 9, 5))
        AddHandler btnTexte.Click, Sub() menuTexte.Show(btnTexte, New Point(0, btnTexte.Height))

        ' Menu "Dates" : durées, ajout d'unités, extraction de parties (choix guidé)
        menuDates = New ContextMenuStrip()
        Dim mDuree As New ToolStripMenuItem("Durée entre 2 dates (fin − début)")
        For Each u In New String()() {New String() {"en secondes", "S"}, New String() {"en minutes", "MI"},
                                      New String() {"en heures", "H"}, New String() {"en jours", "J"}}
            mDuree.DropDownItems.Add(ItemModele("Durée " & u(0), "DUREE(date_de_fin; date_de_debut; """ & u(1) & """)", 6, 11))
        Next
        menuDates.Items.Add(mDuree)
        Dim mAjout As New ToolStripMenuItem("Ajouter à une date")
        For Each u In New String()() {New String() {"des secondes", "S"}, New String() {"des minutes", "MI"},
                                      New String() {"des heures", "H"}, New String() {"des jours", "J"},
                                      New String() {"des mois", "MO"}, New String() {"des années", "A"}}
            mAjout.DropDownItems.Add(ItemModele("Ajouter " & u(0), "AJOUTDATE(date; nombre; """ & u(1) & """)", 10, 4))
        Next
        menuDates.Items.Add(mAjout)
        menuDates.Items.Add(New ToolStripSeparator())
        menuDates.Items.Add(ItemModele("Année d'une date (ex : 2026)", "ANNEE(date)", 6, 4))
        menuDates.Items.Add(ItemModele("Mois d'une date (1 à 12)", "MOIS(date)", 5, 4))
        menuDates.Items.Add(ItemModele("Jour du mois (1 à 31)", "JOUR(date)", 5, 4))
        menuDates.Items.Add(ItemModele("Heure (0 à 23)", "PARTDATE(date; ""H"")", 9, 4))
        menuDates.Items.Add(ItemModele("Minute (0 à 59)", "PARTDATE(date; ""MI"")", 9, 4))
        menuDates.Items.Add(ItemModele("Seconde (0 à 59)", "PARTDATE(date; ""S"")", 9, 4))
        menuDates.Items.Add(ItemModele("Jour de la semaine (1 = lundi … 7 = dimanche)", "JOURSEM(date)", 8, 4))
        AddHandler btnDates.Click, Sub() menuDates.Show(btnDates, New Point(0, btnDates.Height))

        ' Menu "Nombres" : arrondis et comparaisons de valeurs
        menuNombres = New ContextMenuStrip()
        menuNombres.Items.Add(ItemModele("ARRONDI : arrondit (ici à 2 décimales)", "ARRONDI(valeur; 2)", 8, 6))
        menuNombres.Items.Add(ItemModele("ABS : valeur absolue", "ABS(valeur)", 4, 6))
        menuNombres.Items.Add(New ToolStripSeparator())
        menuNombres.Items.Add(ItemModele("ENT : partie entière (arrondi vers le bas)", "ENT(valeur)", 4, 6))
        menuNombres.Items.Add(ItemModele("PLAFOND : entier supérieur", "PLAFOND(valeur)", 8, 6))
        menuNombres.Items.Add(ItemModele("PLANCHER : entier inférieur", "PLANCHER(valeur)", 8, 6))
        menuNombres.Items.Add(New ToolStripSeparator())
        menuNombres.Items.Add(ItemModele("MIN : la plus petite de plusieurs valeurs", "MIN(a; b)", 4, 1))
        menuNombres.Items.Add(ItemModele("MAX : la plus grande de plusieurs valeurs", "MAX(a; b)", 4, 1))
        AddHandler btnNombres.Click, Sub() menuNombres.Show(btnNombres, New Point(0, btnNombres.Height))

        ' Menu "Condition" : si/alors/sinon et tests de présence
        menuCondition = New ContextMenuStrip()
        menuCondition.Items.Add(ItemModele("SI : si / alors / sinon", "SI(condition; valeur_si_vrai; valeur_si_faux)", 3, 9))
        menuCondition.Items.Add(ItemModele("VIDE : vrai si le champ est vide", "VIDE(champ)", 5, 5))
        menuCondition.Items.Add(ItemModele("REMPLI : vrai si le champ est rempli", "REMPLI(champ)", 7, 5))
        AddHandler btnCondition.Click, Sub() menuCondition.Show(btnCondition, New Point(0, btnCondition.Height))

        ' Menu "Tableau" : agrégats sur les lignes d'un tableau de détail
        menuAgregat = New ContextMenuStrip()
        menuAgregat.Items.Add(ItemModele("Somme des lignes", "SOMME(colonne)", 6, 7))
        menuAgregat.Items.Add(ItemModele("Moyenne des lignes", "MOYENNE(colonne)", 8, 7))
        menuAgregat.Items.Add(ItemModele("Valeur minimale des lignes", "MIN(colonne)", 4, 7))
        menuAgregat.Items.Add(ItemModele("Valeur maximale des lignes", "MAX(colonne)", 4, 7))
        menuAgregat.Items.Add(ItemModele("Nombre de lignes", "NB()", 3, 0))
        AddHandler btnAgregat.Click, Sub() menuAgregat.Show(btnAgregat, New Point(0, btnAgregat.Height))
        main.Controls.Add(grpElem, 0, 2)

        '---------------- 2. Formule ----------------
        Dim grpFormule As New GroupBox With {.Text = "2. Votre formule", .Dock = DockStyle.Fill}
        txtFormule = New TextBox With {.Location = New Point(10, 20), .Size = New Size(856, 44), .Multiline = True,
                                       .ScrollBars = ScrollBars.Vertical, .Font = New Font("Consolas", 10.0!)}
        lblStatut = Lbl("", 10, 68, 856, 32)
        grpFormule.Controls.Add(txtFormule)
        grpFormule.Controls.Add(lblStatut)
        main.Controls.Add(grpFormule, 0, 3)

        '---------------- 3. Test avec des valeurs ----------------
        Dim grpTest As New GroupBox With {.Text = "3. Testez la formule avec des valeurs (facultatif)", .Dock = DockStyle.Fill}
        grdTest = New DataGridView With {.Location = New Point(10, 20), .Size = New Size(560, 132),
                                         .AllowUserToAddRows = False, .AllowUserToDeleteRows = False, .RowHeadersVisible = False,
                                         .AutoGenerateColumns = False, .EnableHeadersVisualStyles = False, .BackgroundColor = Color.White,
                                         .ColumnHeadersDefaultCellStyle = New DataGridViewCellStyle With {.BackColor = colorBase01, .ForeColor = Color.White, .Font = Me.Font}}
        grdTest.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colEl", .HeaderText = "Élément de la formule", .Width = 350, .ReadOnly = True})
        grdTest.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colVal", .HeaderText = "Valeur de test", .Width = 190})
        btnCalculer = New Button With {.Text = "Calculer", .Location = New Point(580, 20), .Size = New Size(140, 28),
                                       .FlatStyle = FlatStyle.Flat, .BackColor = colorBase01, .ForeColor = Color.White}
        lblResultat = Lbl("Résultat : —", 580, 56, 286, 56)
        lblResultat.Font = New Font("Century Gothic", 9.0!, FontStyle.Bold)
        grpTest.Controls.Add(grdTest)
        grpTest.Controls.Add(btnCalculer)
        grpTest.Controls.Add(lblResultat)
        grpTest.Controls.Add(LblAide("Les variables GV_ sont évaluées" & vbCrLf & "automatiquement (date du jour…).", 580, 116, 286, 36))
        grpTest.Controls.Add(LblAide("Dates au format jj/mm/aaaa ; pour une colonne de tableau, saisissez les valeurs des lignes séparées par des points-virgules (ex : 10 ; 20,5 ; 3).", 10, 158, 850))
        main.Controls.Add(grpTest, 0, 4)

        '---------------- Aperçu json ----------------
        Dim grpApercu As New GroupBox With {.Text = "Syntaxe générée (automatique — rien à saisir)", .Dock = DockStyle.Fill}
        txtJson = New TextBox With {.Location = New Point(10, 20), .Size = New Size(856, 24), .ReadOnly = True,
                                    .BackColor = Color.FromArgb(240, 243, 245)}
        grpApercu.Controls.Add(txtJson)
        main.Controls.Add(grpApercu, 0, 5)

        '---------------- Boutons ----------------
        Dim pnlBoutons As New FlowLayoutPanel With {.Dock = DockStyle.Fill, .FlowDirection = FlowDirection.RightToLeft}
        btnAnnuler = New Button With {.Text = "Annuler", .Size = New Size(110, 30)}
        btnEnregistrer = New Button With {.Text = "Enregistrer la formule", .Size = New Size(200, 30), .FlatStyle = FlatStyle.Flat,
                                          .BackColor = colorBase01, .ForeColor = Color.White}
        pnlBoutons.Controls.Add(btnAnnuler)
        pnlBoutons.Controls.Add(btnEnregistrer)
        main.Controls.Add(pnlBoutons, 0, 6)
        Me.CancelButton = btnAnnuler
        ChargerExemples()
        _uiPrete = True
    End Sub

    ''' <summary>Exemples construits à partir des champs réels de la page : ils sont
    ''' donc toujours valides (guide pas-à-pas par l'exemple).</summary>
    Private Sub ChargerExemples()
        cmbExemples.Items.Clear()
        cmbExemples.Items.Add(New ItemExemple With {.Label = "— Insérer un exemple… —", .Texte = Nothing})
        Dim nums = _champs.Where(Function(c) c.CodTable = "ENT" AndAlso TYP_NUMERIQUES.Contains(c.TypControle)).ToList()
        Dim dates = _champs.Where(Function(c) c.CodTable = "ENT" AndAlso
                                  (c.TypControle.Equals("DATE", StringComparison.OrdinalIgnoreCase) OrElse
                                   c.TypControle.Equals("DATETIME", StringComparison.OrdinalIgnoreCase))).ToList()
        Dim numDet = _champs.Where(Function(c) c.CodTable <> "ENT" AndAlso TYP_NUMERIQUES.Contains(c.TypControle)).ToList()
        Dim textes = _champs.Where(Function(c) c.CodTable = "ENT" AndAlso
                                  (c.TypControle.Equals("TEXT", StringComparison.OrdinalIgnoreCase) OrElse
                                   c.TypControle.Equals("MEMO", StringComparison.OrdinalIgnoreCase) OrElse
                                   c.TypControle.Equals("COMBO", StringComparison.OrdinalIgnoreCase))).ToList()
        If nums.Count >= 2 Then
            cmbExemples.Items.Add(New ItemExemple With {
                .Label = "Produit : " & nums(0).NomColonne & " × " & nums(1).NomColonne & " (arrondi à 2 décimales)",
                .Texte = "ARRONDI(" & nums(0).NomColonne & " * " & nums(1).NomColonne & "; 2)"})
        End If
        If dates.Count >= 2 Then
            Dim fin = dates.FirstOrDefault(Function(d) d.NomColonne.ToUpperInvariant().IndexOf("FIN") >= 0)
            Dim deb = dates.FirstOrDefault(Function(d) d.NomColonne.ToUpperInvariant().IndexOf("DEB") >= 0)
            If fin Is Nothing Then fin = dates(1)
            If deb Is Nothing Then deb = dates(0)
            If fin IsNot deb Then
                cmbExemples.Items.Add(New ItemExemple With {
                    .Label = "Durée en secondes (" & fin.NomColonne & " − " & deb.NomColonne & ")",
                    .Texte = "DUREE(" & fin.NomColonne & "; " & deb.NomColonne & "; ""S"")"})
                cmbExemples.Items.Add(New ItemExemple With {
                    .Label = "Durée en jours (" & fin.NomColonne & " − " & deb.NomColonne & ")",
                    .Texte = "DUREE(" & fin.NomColonne & "; " & deb.NomColonne & "; ""J"")"})
            End If
        End If
        If dates.Count >= 1 Then
            cmbExemples.Items.Add(New ItemExemple With {
                .Label = "Date : " & dates(0).NomColonne & " + 30 jours (échéance)",
                .Texte = "AJOUTDATE(" & dates(0).NomColonne & "; 30; ""J"")"})
        End If
        If textes.Count >= 1 Then
            cmbExemples.Items.Add(New ItemExemple With {
                .Label = "Texte : " & textes(0).NomColonne & " en majuscules",
                .Texte = "MAJUSCULE(" & textes(0).NomColonne & ")"})
            cmbExemples.Items.Add(New ItemExemple With {
                .Label = "Texte : les 3 premiers caractères de " & textes(0).NomColonne,
                .Texte = "GAUCHE(" & textes(0).NomColonne & "; 3)"})
        End If
        If numDet.Count >= 1 Then
            cmbExemples.Items.Add(New ItemExemple With {
                .Label = "Total des lignes : somme de " & numDet(0).NomColonne,
                .Texte = "SOMME(" & numDet(0).NomColonne & ")"})
        End If
        If nums.Count >= 1 Then
            cmbExemples.Items.Add(New ItemExemple With {
                .Label = "Valeur conditionnelle : " & nums(0).NomColonne & " si positive, sinon 0",
                .Texte = "SI(" & nums(0).NomColonne & " > 0; " & nums(0).NomColonne & "; 0)"})
        End If
        cmbExemples.Items.Add(New ItemExemple With {.Label = "Valeur fixe (constante)", .Texte = "0"})
        cmbExemples.SelectedIndex = 0
    End Sub

    '---------------- Insertion dans la formule ----------------

    ''' <summary>Insère le texte à la position du curseur (remplace la sélection).</summary>
    Private Sub InsererAuCurseur(texte As String)
        Dim pos As Integer = txtFormule.SelectionStart
        txtFormule.SelectedText = texte
        txtFormule.SelectionStart = pos + texte.Length
        txtFormule.Focus()
    End Sub

    ''' <summary>Insère un modèle de fonction puis présélectionne le paramètre à compléter
    ''' (l'utilisateur le remplace en double-cliquant un champ de la liste).</summary>
    Private Sub InsererModele(texte As String, selDecal As Integer, selLong As Integer)
        Dim pos As Integer = txtFormule.SelectionStart
        txtFormule.SelectedText = texte
        txtFormule.SelectionStart = pos + selDecal
        txtFormule.SelectionLength = selLong
        txtFormule.Focus()
    End Sub

    ''' <summary>Élément de menu d'une famille de fonctions : insère le modèle et
    ''' présélectionne le paramètre à compléter (décalage/longueur dans le modèle).</summary>
    Private Function ItemModele(label As String, modele As String, selDecal As Integer, selLong As Integer) As ToolStripMenuItem
        Dim it As New ToolStripMenuItem(label)
        AddHandler it.Click, Sub() InsererModele(modele, selDecal, selLong)
        Return it
    End Function

    Private Sub InsererChampSelectionne()
        Dim c = TryCast(lstChamps.SelectedItem, ChampInfo)
        If c IsNot Nothing Then InsererAuCurseur(c.NomColonne)
    End Sub
    Private Sub InsererVariableSelectionnee()
        Dim g = TryCast(lstGV.SelectedItem, GvInfo)
        If g IsNot Nothing Then InsererAuCurseur(g.Nom)
    End Sub

    '---------------- Recherche de champs ----------------

    Private Function TrouverChamp(nom As String) As ChampInfo
        For Each c In _champs
            If c.NomColonne.Equals(nom, StringComparison.OrdinalIgnoreCase) OrElse
               c.CodChamp.Equals(nom, StringComparison.OrdinalIgnoreCase) Then Return c
        Next
        Return Nothing
    End Function
    Private Function TrouverChampDansTable(table As String, colonne As String) As ChampInfo
        For Each c In _champs
            If c.CodTable.Equals(table, StringComparison.OrdinalIgnoreCase) AndAlso
               c.NomColonne.Equals(colonne, StringComparison.OrdinalIgnoreCase) Then Return c
        Next
        Return Nothing
    End Function
    Private Function PremierChampDeTable(table As String) As ChampInfo
        For Each c In _champs
            If c.CodTable.Equals(table, StringComparison.OrdinalIgnoreCase) Then Return c
        Next
        Return Nothing
    End Function
    ''' <summary>Codes des tableaux de détail (hors entête ENT) ayant au moins un champ.</summary>
    Private Function TablesDetail() As List(Of String)
        Dim lst As New List(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each c In _champs
            If c.CodTable <> "ENT" AndAlso Not lst.Contains(c.CodTable) Then lst.Add(c.CodTable)
        Next
        Return lst
    End Function
    '=====================================================================================
    ' PARSER SÉCURISÉ : texte français -> json déclaratif du moteur.
    ' Aucune évaluation dynamique : seuls des nœuds {"op":...}/{"ref":...}/littéraux
    ' whitelistés sont produits. Toute entrée inattendue déclenche une ErreurFormule
    ' localisée (message clair + position), jamais une exécution.
    '=====================================================================================

    ''' <summary>Découpe le texte en tokens. La virgule n'est acceptée que comme
    ''' séparateur décimal à l'intérieur d'un nombre (les arguments se séparent par ';').</summary>
    Private Function Tokeniser(src As String) As List(Of Tok)
        Dim toks As New List(Of Tok)
        Dim i As Integer = 0
        While i < src.Length
            Dim c As Char = src(i)
            If Char.IsWhiteSpace(c) Then
                i += 1
            ElseIf Char.IsDigit(c) Then
                Dim p As Integer = i
                While i < src.Length AndAlso Char.IsDigit(src(i)) : i += 1 : End While
                If i + 1 < src.Length AndAlso (src(i) = "."c OrElse src(i) = ","c) AndAlso Char.IsDigit(src(i + 1)) Then
                    i += 1
                    While i < src.Length AndAlso Char.IsDigit(src(i)) : i += 1 : End While
                End If
                toks.Add(New Tok With {.Type = TT.Nombre, .Texte = src.Substring(p, i - p), .Pos = p})
            ElseIf Char.IsLetter(c) OrElse c = "_"c Then
                Dim p As Integer = i
                While i < src.Length AndAlso (Char.IsLetterOrDigit(src(i)) OrElse src(i) = "_"c) : i += 1 : End While
                Dim mot As String = src.Substring(p, i - p)
                Select Case mot.ToUpperInvariant()
                    Case "ET", "OU", "NON"
                        toks.Add(New Tok With {.Type = TT.Op, .Texte = mot.ToUpperInvariant(), .Pos = p})
                    Case Else
                        toks.Add(New Tok With {.Type = TT.Ident, .Texte = mot, .Pos = p})
                End Select
            ElseIf c = """"c Then
                Dim p As Integer = i
                i += 1
                Dim sb As New System.Text.StringBuilder()
                While i < src.Length AndAlso src(i) <> """"c
                    If src(i) = ChrW(13) OrElse src(i) = ChrW(10) Then
                        Throw New ErreurFormule("Guillemet fermant manquant pour le texte commencé ici.", p)
                    End If
                    sb.Append(src(i)) : i += 1
                End While
                If i >= src.Length Then Throw New ErreurFormule("Guillemet fermant manquant pour le texte commencé ici.", p)
                i += 1
                toks.Add(New Tok With {.Type = TT.Chaine, .Texte = sb.ToString(), .Pos = p})
            ElseIf "+-*/();".IndexOf(c) >= 0 Then
                toks.Add(New Tok With {.Type = TT.Op, .Texte = c, .Pos = i})
                i += 1
            ElseIf c = ","c Then
                Throw New ErreurFormule("La virgule ne sépare pas les arguments : utilisez le point-virgule ';'.", i)
            ElseIf c = "<"c OrElse c = ">"c OrElse c = "="c Then
                Dim p As Integer = i
                Dim op As String = c
                If i + 1 < src.Length AndAlso (src(i + 1) = "="c OrElse (c = "<"c AndAlso src(i + 1) = ">"c)) Then
                    op = op & src(i + 1) : i += 1
                End If
                toks.Add(New Tok With {.Type = TT.Op, .Texte = op, .Pos = p})
                i += 1
            Else
                Throw New ErreurFormule("Caractère inattendu '" & c & "'.", i)
            End If
        End While
        toks.Add(New Tok With {.Type = TT.Fin, .Texte = "", .Pos = src.Length})
        Return toks
    End Function

    Private Function Courant() As Tok
        Return _toks(_p)
    End Function
    Private Function EstOp(s As String) As Boolean
        Return Courant().Type = TT.Op AndAlso Courant().Texte = s
    End Function
    Private Sub Avancer()
        _p += 1
    End Sub
    Private Function NoeudOp(op As String, args As List(Of JToken)) As JObject
        Dim o As New JObject()
        o("op") = op
        Dim arr As New JArray()
        For Each a In args : arr.Add(a) : Next
        o("args") = arr
        Return o
    End Function

    ''' <summary>Point d'entrée du parser : retourne l'arbre json, ou Nothing + message/position.</summary>
    Private Function AnalyserFormule(texte As String, ByRef msgErreur As String, ByRef posErreur As Integer) As JToken
        msgErreur = Nothing : posErreur = -1
        Try
            _toks = Tokeniser(texte)
            _p = 0 : _prof = 0
            Dim r As JToken = ParseOu()
            If Courant().Type <> TT.Fin Then
                Throw New ErreurFormule("Contenu inattendu '" & Courant().Texte & "' : il manque peut-être un opérateur avant.", Courant().Pos)
            End If
            Return r
        Catch ex As ErreurFormule
            msgErreur = ex.Message : posErreur = ex.Pos
            Return Nothing
        End Try
    End Function

    ' OU (le moins prioritaire)
    Private Function ParseOu() As JToken
        Dim args As New List(Of JToken) From {ParseEt()}
        While EstOp("OU")
            Avancer() : args.Add(ParseEt())
        End While
        If args.Count = 1 Then Return args(0)
        Return NoeudOp("OR", args)
    End Function
    ' ET
    Private Function ParseEt() As JToken
        Dim args As New List(Of JToken) From {ParseNon()}
        While EstOp("ET")
            Avancer() : args.Add(ParseNon())
        End While
        If args.Count = 1 Then Return args(0)
        Return NoeudOp("AND", args)
    End Function
    ' NON x
    Private Function ParseNon() As JToken
        If EstOp("NON") Then
            Avancer()
            Return NoeudOp("NOT", New List(Of JToken) From {ParseNon()})
        End If
        Return ParseComparaison()
    End Function
    ' Comparaisons (non associatives : a = b = c est refusé, utilisez ET/OU)
    Private Function ParseComparaison() As JToken
        Dim g As JToken = ParseAdditif()
        If Courant().Type = TT.Op AndAlso OPS_COMP.ContainsKey(Courant().Texte) Then
            Dim t As Tok = Courant()
            Avancer()
            Dim d As JToken = ParseAdditif()
            If Courant().Type = TT.Op AndAlso OPS_COMP.ContainsKey(Courant().Texte) Then
                Throw New ErreurFormule("On ne peut pas enchaîner deux comparaisons : combinez-les avec ET / OU.", Courant().Pos)
            End If
            Return NoeudOp(OPS_COMP(t.Texte), New List(Of JToken) From {g, d})
        End If
        Return g
    End Function
    ' + - (associatifs à gauche ; les additions en chaîne sont fusionnées en un seul ADD)
    Private Function ParseAdditif() As JToken
        Dim acc As JToken = ParseMultiplicatif()
        While EstOp("+") OrElse EstOp("-")
            Dim t As Tok = Courant()
            Avancer()
            Dim d As JToken = ParseMultiplicatif()
            If t.Texte = "+" Then
                Dim jo = TryCast(acc, JObject)
                If jo IsNot Nothing AndAlso jo("args") IsNot Nothing AndAlso
                   jo("op") IsNot Nothing AndAlso jo("op").ToString() = "ADD" Then
                    CType(jo("args"), JArray).Add(d)
                Else
                    acc = NoeudOp("ADD", New List(Of JToken) From {acc, d})
                End If
            Else
                acc = NoeudOp("SUB", New List(Of JToken) From {acc, d})
            End If
        End While
        Return acc
    End Function
    ' * / (DIVSAFE : division sécurisée du moteur, retourne 0 si le diviseur est nul)
    Private Function ParseMultiplicatif() As JToken
        Dim acc As JToken = ParseUnaire()
        While EstOp("*") OrElse EstOp("/")
            Dim t As Tok = Courant()
            Avancer()
            Dim d As JToken = ParseUnaire()
            If t.Texte = "*" Then
                Dim jo = TryCast(acc, JObject)
                If jo IsNot Nothing AndAlso jo("args") IsNot Nothing AndAlso
                   jo("op") IsNot Nothing AndAlso jo("op").ToString() = "MUL" Then
                    CType(jo("args"), JArray).Add(d)
                Else
                    acc = NoeudOp("MUL", New List(Of JToken) From {acc, d})
                End If
            Else
                acc = NoeudOp("DIVSAFE", New List(Of JToken) From {acc, d})
            End If
        End While
        Return acc
    End Function
    ' Moins unaire : -x -> MUL(-1, x) ; replié en constante si x est un nombre
    Private Function ParseUnaire() As JToken
        If EstOp("-") Then
            Avancer()
            Dim v As JToken = ParseUnaire()
            Dim jv = TryCast(v, JValue)
            If jv IsNot Nothing AndAlso (jv.Type = JTokenType.Integer OrElse jv.Type = JTokenType.Float) Then
                If jv.Type = JTokenType.Integer Then Return New JValue(-Convert.ToInt64(jv.Value))
                Return New JValue(-Convert.ToDouble(jv.Value))
            End If
            Return NoeudOp("MUL", New List(Of JToken) From {New JValue(-1), v})
        End If
        Return ParsePrimaire()
    End Function

    Private Function ParsePrimaire() As JToken
        _prof += 1
        If _prof > 20 Then Throw New ErreurFormule("Formule trop complexe (plus de 20 niveaux de parenthèses ou de fonctions).", Courant().Pos)
        Try
            Dim t As Tok = Courant()
            Select Case t.Type
                Case TT.Nombre
                    Avancer()
                    Return ValeurNombre(t)
                Case TT.Chaine
                    Avancer()
                    Return New JValue(t.Texte)
                Case TT.Ident
                    Avancer()
                    If EstOp("(") Then Return ParseFonction(t)
                    Return ReferenceDepuisNom(t)
                Case TT.Op
                    If t.Texte = "(" Then
                        Avancer()
                        Dim e As JToken = ParseOu()
                        If Not EstOp(")") Then Throw New ErreurFormule("Parenthèse fermante ')' manquante.", Courant().Pos)
                        Avancer()
                        Return e
                    End If
                    Throw New ErreurFormule("'" & t.Texte & "' est inattendu ici : une valeur ou un champ est attendu.", t.Pos)
                Case Else
                    Throw New ErreurFormule("Fin de formule inattendue : il manque une valeur.", t.Pos)
            End Select
        Finally
            _prof -= 1
        End Try
    End Function

    ''' <summary>Nombre littéral : entier si possible, double sinon (séparateur ',' ou '.').</summary>
    Private Function ValeurNombre(t As Tok) As JValue
        Dim d As Double
        If Not Double.TryParse(t.Texte.Replace(","c, "."c), Globalization.NumberStyles.Any,
                               Globalization.CultureInfo.InvariantCulture, d) Then
            Throw New ErreurFormule("Nombre invalide : '" & t.Texte & "'.", t.Pos)
        End If
        If d = Math.Truncate(d) AndAlso d >= Integer.MinValue AndAlso d <= Integer.MaxValue Then
            Return New JValue(Convert.ToInt32(d))
        End If
        Return New JValue(d)
    End Function

    ''' <summary>Identifiant seul : champ de la page (Cod_Champ ou Nom_Colonne) ou variable GV_*
    ''' connue. Tout autre nom est refusé (protection contre l'injection de noms arbitraires).</summary>
    Private Function ReferenceDepuisNom(t As Tok) As JToken
        Dim nom As String = t.Texte
        If (_nomCible <> "" AndAlso nom.Equals(_nomCible, StringComparison.OrdinalIgnoreCase)) OrElse
           (_codCible <> "" AndAlso nom.Equals(_codCible, StringComparison.OrdinalIgnoreCase)) Then
            Throw New ErreurFormule("Une formule ne peut pas utiliser le champ qu'elle calcule ('" & nom & "').", t.Pos)
        End If
        Dim ch As ChampInfo = TrouverChamp(nom)
        Dim o As New JObject()
        If ch IsNot Nothing Then
            o("ref") = ch.NomColonne
            Return o
        End If
        If nom.Length > 3 AndAlso nom.Substring(0, 3).Equals("GV_", StringComparison.OrdinalIgnoreCase) Then
            Dim gvn As String = nom.ToUpperInvariant()
            If _gvNoms.Contains(gvn) Then
                o("ref") = gvn
                Return o
            End If
            Throw New ErreurFormule("Variable globale inconnue : '" & nom & "'. Disponibles : " & String.Join(", ", _gvNoms) & ".", t.Pos)
        End If
        Throw New ErreurFormule("'" & nom & "' n'est ni un champ de la page ni une variable GV_. Double-cliquez sur un champ de la liste pour l'insérer.", t.Pos)
    End Function

    ''' <summary>Appel de fonction : familles texte (GAUCHE, DROITE, STXT, POSITION, LONGUEUR,
    ''' MAJUSCULE, MINUSCULE, SUPPRESPACE, REMPLACE, CONCAT, CONTIENT), dates (DUREE, AJOUTDATE,
    ''' PARTDATE, ANNEE, MOIS, JOUR, JOURSEM), nombres (ARRONDI, ABS, ENT, PLAFOND, PLANCHER,
    ''' MIN/MAX scalaires), conditions (SI, VIDE, REMPLI) et agrégats de tableau.
    ''' Chaque fonction vérifie son nombre d'arguments et produit l'opérateur moteur associé.</summary>
    Private Function ParseFonction(t As Tok) As JToken
        Dim nom As String = t.Texte.ToUpperInvariant()
        If Not FONCTIONS.Contains(nom) Then
            Throw New ErreurFormule("Fonction inconnue : '" & t.Texte & "'. Fonctions autorisées : " &
                                    String.Join(", ", FONCTIONS.OrderBy(Function(f) f).ToArray()) & ".", t.Pos)
        End If
        Avancer() ' consomme '('
        Dim args As New List(Of JToken)
        Dim uniteTxt As String = Nothing   ' unité/partie saisie sans guillemets (ex : DUREE(..; ..; JOURS), PARTDATE(..; MOIS))
        If EstOp(")") Then
            Avancer()
        Else
            While True
                If ((nom = "DUREE" OrElse nom = "AJOUTDATE") AndAlso args.Count = 2 AndAlso Courant().Type = TT.Ident) OrElse
                   (nom = "PARTDATE" AndAlso args.Count = 1 AndAlso Courant().Type = TT.Ident) Then
                    uniteTxt = Courant().Texte : Avancer()
                Else
                    args.Add(ParseOu())
                End If
                If EstOp(";") Then
                    Avancer()
                Else
                    Exit While
                End If
            End While
            If Not EstOp(")") Then
                Throw New ErreurFormule("Parenthèse fermante ')' manquante après les arguments de " & nom & ".", Courant().Pos)
            End If
            Avancer()
        End If
        Select Case nom
            Case "ARRONDI"
                If args.Count < 1 OrElse args.Count > 2 Then
                    Throw New ErreurFormule("ARRONDI attend 1 ou 2 arguments : ARRONDI(valeur; nombre de décimales).", t.Pos)
                End If
                Return NoeudOp("ROUND", args)
            Case "ABS"
                If args.Count <> 1 Then Throw New ErreurFormule("ABS attend 1 argument : ABS(valeur).", t.Pos)
                Return NoeudOp("ABS", args)
            Case "SI"
                If args.Count <> 3 Then
                    Throw New ErreurFormule("SI attend 3 arguments : SI(condition; valeur si vrai; valeur si faux).", t.Pos)
                End If
                Return NoeudOp("COND", args)
            Case "VIDE"
                If args.Count <> 1 Then Throw New ErreurFormule("VIDE attend 1 argument : VIDE(champ).", t.Pos)
                Return NoeudOp("EMPTY", args)
            Case "REMPLI"
                If args.Count <> 1 Then Throw New ErreurFormule("REMPLI attend 1 argument : REMPLI(champ).", t.Pos)
                Return NoeudOp("NOTEMPTY", args)
            Case "DUREE"
                Return ConstruireDuree(t, args, uniteTxt)
            Case "GAUCHE"
                If args.Count <> 2 Then Throw New ErreurFormule("GAUCHE attend 2 arguments : GAUCHE(texte; nombre de caractères).", t.Pos)
                Return NoeudOp("LEFT", args)
            Case "DROITE"
                If args.Count <> 2 Then Throw New ErreurFormule("DROITE attend 2 arguments : DROITE(texte; nombre de caractères).", t.Pos)
                Return NoeudOp("RIGHT", args)
            Case "STXT"
                If args.Count < 2 OrElse args.Count > 3 Then
                    Throw New ErreurFormule("STXT attend 2 ou 3 arguments : STXT(texte; position de début; longueur facultative).", t.Pos)
                End If
                Return NoeudOp("SUBSTRING", args)
            Case "POSITION"
                If args.Count <> 2 Then Throw New ErreurFormule("POSITION attend 2 arguments : POSITION(texte cherché; texte).", t.Pos)
                Return NoeudOp("INDEXOF", args)
            Case "LONGUEUR"
                If args.Count <> 1 Then Throw New ErreurFormule("LONGUEUR attend 1 argument : LONGUEUR(texte).", t.Pos)
                Return NoeudOp("LEN", args)
            Case "MAJUSCULE"
                If args.Count <> 1 Then Throw New ErreurFormule("MAJUSCULE attend 1 argument : MAJUSCULE(texte).", t.Pos)
                Return NoeudOp("UPPER", args)
            Case "MINUSCULE"
                If args.Count <> 1 Then Throw New ErreurFormule("MINUSCULE attend 1 argument : MINUSCULE(texte).", t.Pos)
                Return NoeudOp("LOWER", args)
            Case "SUPPRESPACE"
                If args.Count <> 1 Then Throw New ErreurFormule("SUPPRESPACE attend 1 argument : SUPPRESPACE(texte).", t.Pos)
                Return NoeudOp("TRIM", args)
            Case "REMPLACE"
                If args.Count <> 3 Then Throw New ErreurFormule("REMPLACE attend 3 arguments : REMPLACE(texte; texte à remplacer; nouveau texte).", t.Pos)
                Return NoeudOp("REPLACE", args)
            Case "CONCAT"
                If args.Count < 2 Then Throw New ErreurFormule("CONCAT attend au moins 2 arguments : CONCAT(texte1; texte2; …).", t.Pos)
                Return NoeudOp("CONCAT", args)
            Case "CONTIENT"
                If args.Count <> 2 Then Throw New ErreurFormule("CONTIENT attend 2 arguments : CONTIENT(texte; morceau).", t.Pos)
                Return NoeudOp("CONTIENT", args)
            Case "AJOUTDATE"
                Return ConstruireAjoutDate(t, args, uniteTxt)
            Case "PARTDATE"
                Return ConstruirePartDate(t, args, uniteTxt)
            Case "ANNEE"
                Return NoeudPartDate(t, nom, "A", args)
            Case "MOIS"
                Return NoeudPartDate(t, nom, "M", args)
            Case "JOUR"
                Return NoeudPartDate(t, nom, "J", args)
            Case "JOURSEM"
                If args.Count <> 1 Then Throw New ErreurFormule("JOURSEM attend 1 argument : JOURSEM(date).", t.Pos)
                Return NoeudOp("DAYOFWEEK", args)
            Case "ENT"
                If args.Count <> 1 Then Throw New ErreurFormule("ENT attend 1 argument : ENT(valeur).", t.Pos)
                Return NoeudOp("INT", args)
            Case "PLAFOND"
                If args.Count <> 1 Then Throw New ErreurFormule("PLAFOND attend 1 argument : PLAFOND(valeur).", t.Pos)
                Return NoeudOp("CEIL", args)
            Case "PLANCHER"
                If args.Count <> 1 Then Throw New ErreurFormule("PLANCHER attend 1 argument : PLANCHER(valeur).", t.Pos)
                Return NoeudOp("FLOOR", args)
            Case "MIN", "MAX"
                ' 2 arguments ou plus -> forme scalaire ; 1 colonne de tableau -> agrégat
                If args.Count >= 2 Then Return NoeudOp(nom, args)
                Return ConstruireAgregat(t, nom, args)
            Case Else ' SOMME, MOYENNE, NB
                Return ConstruireAgregat(t, nom, args)
        End Select
    End Function

    ''' <summary>DUREE(date de fin; date de début; unité) -> {"op":"DATEDIFF","unite":...}.
    ''' Unité : "S" secondes, "MI" minutes, "H" heures, "J" jours (mots français acceptés).</summary>
    Private Function ConstruireDuree(t As Tok, args As List(Of JToken), uniteTxt As String) As JToken
        Dim u As String
        If uniteTxt IsNot Nothing Then
            If args.Count <> 2 Then
                Throw New ErreurFormule("DUREE attend 3 arguments : DUREE(date de fin; date de début; unité).", t.Pos)
            End If
            u = NormaliserUnite(uniteTxt, t.Pos)
        Else
            If args.Count <> 3 Then
                Throw New ErreurFormule("DUREE attend 3 arguments : DUREE(date de fin; date de début; ""S"", ""MI"", ""H"" ou ""J"").", t.Pos)
            End If
            Dim js = TryCast(args(2), JValue)
            If js Is Nothing OrElse js.Type <> JTokenType.String Then
                Throw New ErreurFormule("L'unité de DUREE doit être ""S"" (secondes), ""MI"" (minutes), ""H"" (heures) ou ""J"" (jours), entre guillemets.", t.Pos)
            End If
            u = NormaliserUnite(CStr(js.Value), t.Pos)
        End If
        Dim o As New JObject()
        o("op") = "DATEDIFF"
        o("unite") = u
        Dim arr As New JArray()
        arr.Add(args(0)) : arr.Add(args(1))
        o("args") = arr
        Return o
    End Function

    Private Function NormaliserUnite(u As String, pos As Integer) As String
        Select Case u.Trim.ToUpperInvariant()
            Case "S", "SECONDE", "SECONDES" : Return "S"
            Case "MI", "MINUTE", "MINUTES" : Return "MI"
            Case "H", "HEURE", "HEURES" : Return "H"
            Case "J", "JOUR", "JOURS" : Return "J"
        End Select
        Throw New ErreurFormule("Unité inconnue : '" & u & "'. Utilisez ""S"" (secondes), ""MI"" (minutes), ""H"" (heures) ou ""J"" (jours).", pos)
    End Function

    ''' <summary>AJOUTDATE(date; nombre; unité) -> {"op":"DATEADD","unite":...} : date + n unités.
    ''' Unité : "S" secondes, "MI" minutes, "H" heures, "J" jours, "MO" mois, "A" années
    ''' (mots français acceptés : JOURS, MOIS, ANNEES…).</summary>
    Private Function ConstruireAjoutDate(t As Tok, args As List(Of JToken), uniteTxt As String) As JToken
        Dim u As String
        If uniteTxt IsNot Nothing Then
            If args.Count <> 2 Then
                Throw New ErreurFormule("AJOUTDATE attend 3 arguments : AJOUTDATE(date; nombre; unité).", t.Pos)
            End If
            u = NormaliserUniteAjout(uniteTxt, t.Pos)
        Else
            If args.Count <> 3 Then
                Throw New ErreurFormule("AJOUTDATE attend 3 arguments : AJOUTDATE(date; nombre; ""S"", ""MI"", ""H"", ""J"", ""MO"" ou ""A"").", t.Pos)
            End If
            Dim js = TryCast(args(2), JValue)
            If js Is Nothing OrElse js.Type <> JTokenType.String Then
                Throw New ErreurFormule("L'unité d'AJOUTDATE doit être ""S"" (secondes), ""MI"" (minutes), ""H"" (heures), ""J"" (jours), ""MO"" (mois) ou ""A"" (années), entre guillemets.", t.Pos)
            End If
            u = NormaliserUniteAjout(CStr(js.Value), t.Pos)
        End If
        Dim o As New JObject()
        o("op") = "DATEADD"
        o("unite") = u
        Dim arr As New JArray()
        arr.Add(args(0)) : arr.Add(args(1))
        o("args") = arr
        Return o
    End Function

    Private Function NormaliserUniteAjout(u As String, pos As Integer) As String
        Select Case u.Trim.ToUpperInvariant()
            Case "S", "SECONDE", "SECONDES" : Return "S"
            Case "MI", "MINUTE", "MINUTES" : Return "MI"
            Case "H", "HEURE", "HEURES" : Return "H"
            Case "J", "JOUR", "JOURS" : Return "J"
            Case "MO", "MOIS" : Return "MO"
            Case "A", "AN", "ANS", "ANNEE", "ANNEES" : Return "A"
        End Select
        Throw New ErreurFormule("Unité inconnue : '" & u & "'. Utilisez ""S"" (secondes), ""MI"" (minutes), ""H"" (heures), ""J"" (jours), ""MO"" (mois) ou ""A"" (années).", pos)
    End Function

    ''' <summary>PARTDATE(date; partie) -> {"op":"DATEPART","partie":...} : extrait un nombre
    ''' d'une date. Partie : "A" année, "M" mois, "J" jour, "H" heure, "MI" minute, "S" seconde.</summary>
    Private Function ConstruirePartDate(t As Tok, args As List(Of JToken), partieTxt As String) As JToken
        Dim p As String
        If partieTxt IsNot Nothing Then
            If args.Count <> 1 Then
                Throw New ErreurFormule("PARTDATE attend 2 arguments : PARTDATE(date; partie).", t.Pos)
            End If
            p = NormaliserPartie(partieTxt, t.Pos)
        Else
            If args.Count <> 2 Then
                Throw New ErreurFormule("PARTDATE attend 2 arguments : PARTDATE(date; ""A"", ""M"", ""J"", ""H"", ""MI"" ou ""S"").", t.Pos)
            End If
            Dim js = TryCast(args(1), JValue)
            If js Is Nothing OrElse js.Type <> JTokenType.String Then
                Throw New ErreurFormule("La partie de PARTDATE doit être ""A"" (année), ""M"" (mois), ""J"" (jour), ""H"" (heure), ""MI"" (minute) ou ""S"" (seconde), entre guillemets.", t.Pos)
            End If
            p = NormaliserPartie(CStr(js.Value), t.Pos)
        End If
        Return NoeudPartDateBrut(p, args)
    End Function

    ''' <summary>ANNEE(date) / MOIS(date) / JOUR(date) : raccourcis de PARTDATE à partie fixe.</summary>
    Private Function NoeudPartDate(t As Tok, nom As String, partie As String, args As List(Of JToken)) As JToken
        If args.Count <> 1 Then Throw New ErreurFormule(nom & " attend 1 argument : " & nom & "(date).", t.Pos)
        Return NoeudPartDateBrut(partie, args)
    End Function
    Private Function NoeudPartDateBrut(partie As String, args As List(Of JToken)) As JObject
        Dim o As New JObject()
        o("op") = "DATEPART"
        o("partie") = partie
        Dim arr As New JArray()
        arr.Add(args(0))
        o("args") = arr
        Return o
    End Function

    Private Function NormaliserPartie(p As String, pos As Integer) As String
        Select Case p.Trim.ToUpperInvariant()
            Case "A", "AN", "ANS", "ANNEE", "ANNEES" : Return "A"
            Case "M", "MOIS" : Return "M"
            Case "J", "JOUR", "JOURS" : Return "J"
            Case "H", "HEURE", "HEURES" : Return "H"
            Case "MI", "MINUTE", "MINUTES" : Return "MI"
            Case "S", "SECONDE", "SECONDES" : Return "S"
        End Select
        Throw New ErreurFormule("Partie de date inconnue : '" & p & "'. Utilisez ""A"" (année), ""M"" (mois), ""J"" (jour), ""H"" (heure), ""MI"" (minute) ou ""S"" (seconde).", pos)
    End Function

    ''' <summary>SOMME/MOYENNE/MIN/MAX/NB(colonne d'un tableau) -> {"op":...,"table":...,"colonne":...}.
    ''' NB() sans argument est accepté si la page n'a qu'un seul tableau de détail.</summary>
    Private Function ConstruireAgregat(t As Tok, nom As String, args As List(Of JToken)) As JToken
        If nom = "NB" AndAlso args.Count = 0 Then
            Dim tables As List(Of String) = TablesDetail()
            If tables.Count <> 1 Then
                Throw New ErreurFormule("NB() sans argument exige un seul tableau dans la page ; sinon indiquez une colonne du tableau : NB(colonne).", t.Pos)
            End If
            Return NoeudAgregat("COUNT", tables(0), Nothing)
        End If
        If args.Count <> 1 Then
            Throw New ErreurFormule(nom & " attend 1 argument : une colonne d'un tableau (ex : " & nom & "(Mnt)).", t.Pos)
        End If
        Dim jo = TryCast(args(0), JObject)
        If jo Is Nothing OrElse jo("ref") Is Nothing Then
            Throw New ErreurFormule(nom & " s'applique directement à une colonne d'un tableau, pas à une expression.", t.Pos)
        End If
        Dim ch As ChampInfo = TrouverChamp(jo("ref").ToString())
        If ch Is Nothing Then Throw New ErreurFormule("Colonne inconnue : '" & jo("ref").ToString() & "'.", t.Pos)
        If ch.CodTable = "ENT" Then
            Throw New ErreurFormule(nom & " s'applique à une colonne d'un tableau de lignes ; '" & ch.CodChamp & "' est un champ d'entête.", t.Pos)
        End If
        Return NoeudAgregat(AGREGATS(nom), ch.CodTable, ch.NomColonne)
    End Function
    Private Function NoeudAgregat(op As String, table As String, colonne As String) As JObject
        Dim o As New JObject()
        o("op") = op
        o("table") = table
        If colonne IsNot Nothing Then o("colonne") = colonne
        Return o
    End Function
    '=====================================================================================
    ' ÉVALUATEUR MIROIR (étape 3 "Tester") : reproduit fidèlement la sémantique de
    ' evaluer() du moteur (coercition num(), comparaison intelligente cmp(), division
    ' sécurisée, DATEDIFF, variables GV_*) — aucun code dynamique, arbres whitelistés.
    '=====================================================================================

    ''' <summary>Coercition numérique du moteur : non numérique -> 0 (jamais d'erreur).</summary>
    Private Function Num(v As Object) As Double
        If v Is Nothing OrElse v Is DBNull.Value Then Return 0
        If TypeOf v Is Boolean Then Return If(CBool(v), 1, 0)
        If TypeOf v Is String Then Return NumTexte(CStr(v))
        If IsNumeric(v) Then Return CDbl(v)
        Return 0 ' DateTime et autres : comme num() du moteur (NaN -> 0)
    End Function
    Private Function NumTexte(s As String) As Double
        Dim d As Double
        If Double.TryParse(s.Replace(" ", "").Replace(","c, "."c), Globalization.NumberStyles.Any,
                           Globalization.CultureInfo.InvariantCulture, d) Then Return d
        Return 0
    End Function
    ''' <summary>Conversion en texte du moteur (fonctions de chaînes) : une date devient sa
    ''' lecture d'horloge littérale "aaaa-mm-jj hh:mm:ss", miroir de txt() des moteurs TS.</summary>
    Private Function Txt(v As Object) As String
        If v Is Nothing OrElse v Is DBNull.Value Then Return ""
        If TypeOf v Is Boolean Then Return If(CBool(v), "true", "false")
        If TypeOf v Is DateTime Then Return CDate(v).ToString("yyyy-MM-dd HH:mm:ss", Globalization.CultureInfo.InvariantCulture)
        Return v.ToString()
    End Function
    ''' <summary>Borne un nombre de caractères à [0, max] (les Substring .NET lèvent une
    ''' exception au-delà, contrairement à slice() en JavaScript que le moteur utilise).</summary>
    Private Function BorneLongueur(v As Double, max As Integer) As Integer
        If v <= 0 Then Return 0
        If v >= max Then Return max
        Return CInt(Math.Truncate(v))
    End Function
    ''' <summary>Conversion date stricte (miroir de versDate() du moteur) : DateTime direct,
    ''' ou texte ISO (aaaa-mm-jj[Thh:mm[:ss]]) ou français (jj/mm/aaaa[ hh:mm[:ss]]).
    ''' Un nombre ou un autre texte n'est JAMAIS deviné comme une date.</summary>
    Private Shared ReadOnly RX_DATE_ISO As New System.Text.RegularExpressions.Regex("^(\d{4})-(\d{2})-(\d{2})(?:[T ](\d{2}):(\d{2})(?::(\d{2}))?)?")
    Private Shared ReadOnly RX_DATE_FR As New System.Text.RegularExpressions.Regex("^(\d{2})/(\d{2})/(\d{4})(?:[ T](\d{2}):(\d{2})(?::(\d{2}))?)?")
    Private Shared Function GrpInt(g As System.Text.RegularExpressions.Group) As Integer
        Return If(g.Success AndAlso g.Value <> "", CInt(g.Value), 0)
    End Function
    Private Function DateStricte(v As Object, ByRef ok As Boolean) As DateTime
        ok = True
        If TypeOf v Is DateTime Then Return CDate(v)
        Dim s = TryCast(v, String)
        If s IsNot Nothing AndAlso s.Trim <> "" Then
            Dim m = RX_DATE_ISO.Match(s.Trim)
            If m.Success Then
                Return New DateTime(CInt(m.Groups(1).Value), CInt(m.Groups(2).Value), CInt(m.Groups(3).Value),
                                    GrpInt(m.Groups(4)), GrpInt(m.Groups(5)), GrpInt(m.Groups(6)))
            End If
            m = RX_DATE_FR.Match(s.Trim)
            If m.Success Then
                Return New DateTime(CInt(m.Groups(3).Value), CInt(m.Groups(2).Value), CInt(m.Groups(1).Value),
                                    GrpInt(m.Groups(4)), GrpInt(m.Groups(5)), GrpInt(m.Groups(6)))
            End If
        End If
        ok = False
        Return DateTime.MinValue
    End Function
    ''' <summary>Conversion date : DateTime direct, ou texte jj/mm/aaaa (fr) puis ISO/invariant.</summary>
    Private Function DateDe(v As Object, ByRef ok As Boolean) As DateTime
        ok = True
        If TypeOf v Is DateTime Then Return CDate(v)
        Dim s = TryCast(v, String)
        If s IsNot Nothing AndAlso s.Trim <> "" Then
            Dim d As DateTime
            If DateTime.TryParse(s.Trim, Globalization.CultureInfo.GetCultureInfo("fr-FR"),
                                 Globalization.DateTimeStyles.None, d) Then Return d
            If DateTime.TryParse(s.Trim, Globalization.CultureInfo.InvariantCulture,
                                 Globalization.DateTimeStyles.None, d) Then Return d
        End If
        ok = False
        Return DateTime.MinValue
    End Function
    ''' <summary>Comparaison intelligente du moteur : numérique si possible, dates sinon, texte en dernier.</summary>
    Private Function Cmp(a As Object, b As Object) As Integer
        Dim sa As String = If(a Is Nothing, "", a.ToString()).Trim
        Dim sb As String = If(b Is Nothing, "", b.ToString()).Trim
        Dim da As Double, db As Double
        Dim aNum As Boolean = sa <> "" AndAlso Double.TryParse(sa.Replace(","c, "."c), Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, da)
        Dim bNum As Boolean = sb <> "" AndAlso Double.TryParse(sb.Replace(","c, "."c), Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, db)
        If aNum AndAlso bNum Then Return da.CompareTo(db)
        Dim oka As Boolean, okb As Boolean
        Dim dta As DateTime = DateDe(a, oka)
        Dim dtb As DateTime = DateDe(b, okb)
        If oka AndAlso okb Then Return dta.CompareTo(dtb)
        Return String.Compare(sa, sb, StringComparison.OrdinalIgnoreCase)
    End Function
    Private Function EstVrai(v As Object) As Boolean
        If v Is Nothing OrElse v Is DBNull.Value Then Return False
        If TypeOf v Is Boolean Then Return CBool(v)
        If IsNumeric(v) Then Return CDbl(v) <> 0
        If TypeOf v Is DateTime Then Return True
        Return v.ToString().Trim <> ""
    End Function
    ''' <summary>Math.round de JavaScript (la moitié part vers +∞, pas bancaire).</summary>
    Private Function ArrondiJs(v As Double, dec As Integer) As Double
        Dim f As Double = Math.Pow(10, dec)
        Return Math.Floor(v * f + 0.5) / f
    End Function
    ''' <summary>Variables GV_* du test : miroir de variableGlobale() du moteur.</summary>
    Private Function VariableGlobale(nom As String) As Object
        Dim d As DateTime = DateTime.Now
        Select Case nom.ToUpperInvariant()
            Case "GV_NOW" : Return d
            Case "GV_YEAR" : Return d.Year
            Case "GV_MONTH" : Return d.Month
            Case "GV_DAY" : Return d.Day
            Case "GV_DEBMOIS" : Return New DateTime(d.Year, d.Month, 1)
            Case "GV_FINMOIS" : Return New DateTime(d.Year, d.Month, 1).AddMonths(1).AddDays(-1)
            Case "GV_DEBYEAR" : Return New DateTime(d.Year, 1, 1)
            Case Else : Return Nothing
        End Select
    End Function

    Private Function Evaluer(n As JToken) As Object
        Dim jv = TryCast(n, JValue)
        If jv IsNot Nothing Then Return jv.Value
        Dim o = TryCast(n, JObject)
        If o Is Nothing Then Return Nothing
        If o("ref") IsNot Nothing Then
            Dim r As String = o("ref").ToString()
            If r.StartsWith("GV_", StringComparison.OrdinalIgnoreCase) Then Return VariableGlobale(r)
            If _valChamps.ContainsKey(r) Then Return _valChamps(r)
            Return Nothing
        End If
        If o("const") IsNot Nothing Then Return CType(o("const"), JToken).Value(Of Object)()
        If o("op") Is Nothing Then Return Nothing
        Dim op As String = o("op").ToString().ToUpperInvariant()
        Dim arr = TryCast(o("args"), JArray)
        Dim args As New List(Of JToken)
        If arr IsNot Nothing Then For Each a In arr : args.Add(a) : Next
        Dim a0 As Object = If(args.Count > 0, Evaluer(args(0)), Nothing)
        Dim a1 As Object = If(args.Count > 1, Evaluer(args(1)), Nothing)
        Select Case op
            Case "ADD"
                Dim t As Double = 0
                For Each a In args : t += Num(Evaluer(a)) : Next
                Return t
            Case "SUB"
                ' Soustraction de deux dates -> durée en secondes ; sinon arithmétique classique
                Dim oksA As Boolean, oksB As Boolean
                Dim dsa As DateTime = DateStricte(a0, oksA)
                Dim dsb As DateTime = DateStricte(a1, oksB)
                If oksA AndAlso oksB Then Return (dsa - dsb).TotalSeconds
                Return Num(a0) - Num(a1)
            Case "MUL"
                Dim t As Double = 1
                For Each a In args : t *= Num(Evaluer(a)) : Next
                Return t
            Case "DIVSAFE"
                Dim d As Double = Num(a1)
                Return If(d = 0, 0, Num(a0) / d)
            Case "ROUND"
                Dim dec As Integer = If(args.Count > 1, CInt(Num(a1)), 2)
                Return ArrondiJs(Num(a0), dec)
            Case "ABS" : Return Math.Abs(Num(a0))
            ' ---- Fonctions texte (positions 1-based, convention tableur) ----
            Case "LEFT"
                Dim s As String = Txt(a0)
                Return s.Substring(0, BorneLongueur(Num(a1), s.Length))
            Case "RIGHT"
                Dim s As String = Txt(a0)
                Dim n2 As Integer = BorneLongueur(Num(a1), s.Length)
                Return s.Substring(s.Length - n2)
            Case "SUBSTRING"
                ' STXT(texte; début; longueur?) : début 1-based ; sans longueur -> jusqu'à la fin
                Dim s As String = Txt(a0)
                Dim d0 As Integer
                If Num(a1) < 1 Then
                    d0 = 1
                ElseIf Num(a1) > s.Length + 1 Then
                    d0 = s.Length + 1
                Else
                    d0 = CInt(Math.Truncate(Num(a1)))
                End If
                If d0 > s.Length Then Return ""
                If args.Count < 3 Then Return s.Substring(d0 - 1)
                Return s.Substring(d0 - 1, BorneLongueur(Num(Evaluer(args(2))), s.Length - (d0 - 1)))
            Case "INDEXOF"
                ' POSITION(morceau; texte) : position 1-based ; 0 si absent
                Dim cherche As String = Txt(a0)
                If cherche = "" Then Return 0
                Return Txt(a1).IndexOf(cherche, StringComparison.Ordinal) + 1
            Case "LEN" : Return Txt(a0).Length
            Case "UPPER" : Return Txt(a0).ToUpperInvariant()
            Case "LOWER" : Return Txt(a0).ToLowerInvariant()
            Case "TRIM" : Return Txt(a0).Trim()
            Case "REPLACE"
                Dim s As String = Txt(a0)
                Dim ancien As String = Txt(a1)
                If ancien = "" Then Return s
                Return s.Replace(ancien, Txt(Evaluer(args(2))))
            Case "CONCAT"
                Dim sb As New System.Text.StringBuilder()
                For Each a In args : sb.Append(Txt(Evaluer(a))) : Next
                Return sb.ToString()
            ' ---- Fonctions nombres ----
            Case "INT" : Return Math.Floor(Num(a0))   ' ENT tableur : vers -∞
            Case "CEIL" : Return Math.Ceiling(Num(a0))
            Case "FLOOR" : Return Math.Floor(Num(a0))
            Case "DATEDIFF"
                Dim oka As Boolean, okb As Boolean
                Dim dta As DateTime = DateStricte(a0, oka)
                Dim dtb As DateTime = DateStricte(a1, okb)
                If Not oka OrElse Not okb Then Return 0.0
                Dim ms As Double = (dta - dtb).TotalMilliseconds
                Select Case If(o("unite") IsNot Nothing, o("unite").ToString().ToUpperInvariant(), "J")
                    Case "S" : Return ms / 1000
                    Case "MI" : Return ms / 60000
                    Case "H" : Return ms / 3600000
                    Case Else : Return ms / 86400000
                End Select
            Case "DATEADD"
                ' Date + n unités (S/MI/H/J/MO/A) ; date invalide -> vide (null côté moteur)
                Dim okda As Boolean
                Dim da As DateTime = DateStricte(a0, okda)
                If Not okda Then Return Nothing
                Dim nda As Double = Num(a1)
                Select Case If(o("unite") IsNot Nothing, o("unite").ToString().ToUpperInvariant(), "J")
                    Case "S" : Return da.AddSeconds(nda)
                    Case "MI" : Return da.AddMinutes(nda)
                    Case "H" : Return da.AddHours(nda)
                    Case "MO" : Return da.AddMonths(CInt(Math.Truncate(nda)))
                    Case "A" : Return da.AddYears(CInt(Math.Truncate(nda)))
                    Case Else : Return da.AddDays(nda)
                End Select
            Case "DATEPART"
                ' Partie d'une date en nombre ; date invalide -> 0
                Dim okdp As Boolean
                Dim dp As DateTime = DateStricte(a0, okdp)
                If Not okdp Then Return 0
                Select Case If(o("partie") IsNot Nothing, o("partie").ToString().ToUpperInvariant(), "J")
                    Case "A" : Return dp.Year
                    Case "M" : Return dp.Month
                    Case "J" : Return dp.Day
                    Case "H" : Return dp.Hour
                    Case "MI" : Return dp.Minute
                    Case Else : Return dp.Second
                End Select
            Case "DAYOFWEEK"
                ' Jour de la semaine : 1 = lundi … 7 = dimanche ; date invalide -> 0
                Dim okjs As Boolean
                Dim js2 As DateTime = DateStricte(a0, okjs)
                If Not okjs Then Return 0
                Return (CInt(js2.DayOfWeek) + 6) Mod 7 + 1
            Case "COND"
                Return If(EstVrai(a0), a1, If(args.Count > 2, Evaluer(args(2)), Nothing))
            Case "AND"
                For Each a In args
                    If Not EstVrai(Evaluer(a)) Then Return False
                Next
                Return True
            Case "OR"
                For Each a In args
                    If EstVrai(Evaluer(a)) Then Return True
                Next
                Return False
            Case "NOT" : Return Not EstVrai(a0)
            Case "EQ" : Return Cmp(a0, a1) = 0
            Case "NE" : Return Cmp(a0, a1) <> 0
            Case "GT" : Return Cmp(a0, a1) > 0
            Case "GE" : Return Cmp(a0, a1) >= 0
            Case "LT" : Return Cmp(a0, a1) < 0
            Case "LE" : Return Cmp(a0, a1) <= 0
            Case "EMPTY"
                Return a0 Is Nothing OrElse a0.ToString().Trim = ""
            Case "NOTEMPTY"
                Return Not (a0 Is Nothing OrElse a0.ToString().Trim = "")
            Case "CONTIENT"
                Return If(a0 Is Nothing, "", a0.ToString()).IndexOf(If(a1 Is Nothing, "", a1.ToString()), StringComparison.Ordinal) >= 0
            Case "SUM", "AVG", "MIN", "MAX"
                ' Sans "table" : forme scalaire de MIN/MAX (plus petite / plus grande des arguments)
                If (op = "MIN" OrElse op = "MAX") AndAlso o("table") Is Nothing Then
                    Dim vals As New List(Of Double)
                    For Each a In args : vals.Add(Num(Evaluer(a))) : Next
                    If vals.Count = 0 Then Return 0.0
                    Return If(op = "MIN", vals.Min(), vals.Max())
                End If
                Dim cle As String = If(o("table") IsNot Nothing, o("table").ToString(), "") & "|" &
                                    If(o("colonne") IsNot Nothing, o("colonne").ToString(), "")
                Dim lst As List(Of Double) = Nothing
                If Not _valAgg.TryGetValue(cle, lst) OrElse lst.Count = 0 Then Return 0.0
                Select Case op
                    Case "SUM" : Return lst.Sum()
                    Case "AVG" : Return lst.Average()
                    Case "MIN" : Return lst.Min()
                    Case Else : Return lst.Max()
                End Select
            Case "COUNT"
                Dim t As String = If(o("table") IsNot Nothing, o("table").ToString(), "")
                Dim nb As Double
                If _valCnt.TryGetValue(t, nb) Then Return nb
                ' Repli : nombre de valeurs saisies pour une colonne agrégée du même tableau
                For Each kvp In _valAgg
                    If kvp.Key.StartsWith(t & "|", StringComparison.OrdinalIgnoreCase) Then Return CDbl(kvp.Value.Count)
                Next
                Return 0.0
            Case Else
                Throw New ErreurFormule("Opérateur non pris en charge par le test : '" & op & "'.", -1)
        End Select
    End Function

    '=====================================================================================
    ' JSON -> TEXTE (modification d'une formule existante) : retourne Nothing si la
    ' formule n'est pas représentable par le langage de l'assistant (elle est alors
    ' conservée telle quelle et l'utilisateur en compose une nouvelle).
    '=====================================================================================

    Private Function TexteDepuisJson(src As String) As String
        Dim t As JToken = Nothing
        Try
            t = JToken.Parse(src)
        Catch
            Return Nothing
        End Try
        Dim prec As Integer = 0
        Return JvtTexte(t, prec)
    End Function

    ''' <summary>Parenthèse le texte enfant si sa priorité est inférieure au seuil.</summary>
    Private Function ParSi(texte As String, precEnfant As Integer, seuil As Integer) As String
        Return If(precEnfant < seuil, "(" & texte & ")", texte)
    End Function

    ''' <summary>Sérialise un nœud json en texte français (priorités : OU=1, ET=2, NON=3,
    ''' comparaisons=4, +-=5, */=6, moins unaire=7, atomes=8).</summary>
    Private Function JvtTexte(n As JToken, ByRef prec As Integer) As String
        prec = 8
        Dim jv = TryCast(n, JValue)
        If jv IsNot Nothing Then
            Select Case jv.Type
                Case JTokenType.Integer
                    Return Convert.ToInt64(jv.Value).ToString(Globalization.CultureInfo.InvariantCulture)
                Case JTokenType.Float
                    Return Convert.ToDouble(jv.Value).ToString(Globalization.CultureInfo.InvariantCulture)
                Case JTokenType.String
                    Return """" & CStr(jv.Value) & """"
                Case Else
                    Return Nothing
            End Select
        End If
        Dim o = TryCast(n, JObject)
        If o Is Nothing Then Return Nothing
        If o("ref") IsNot Nothing Then Return o("ref").ToString()
        If o("const") IsNot Nothing Then
            Dim p2 As Integer = 0
            Return JvtTexte(o("const"), p2)
        End If
        If o("op") Is Nothing Then Return Nothing
        Dim op As String = o("op").ToString().ToUpperInvariant()
        If op = "REF" Then
            If o("colonne") Is Nothing Then Return Nothing
            Return o("colonne").ToString()
        End If
        If op = "CONST" Then
            If o("valeur") Is Nothing Then Return Nothing
            Dim p3 As Integer = 0
            Return JvtTexte(o("valeur"), p3)
        End If
        ' Agrégats : table + colonne -> fonction française sur la colonne du tableau.
        ' (Sans "table", MIN/MAX sont la forme scalaire : traitée plus bas avec les arguments.)
        If AGREGATS_INVERS.ContainsKey(op) AndAlso o("table") IsNot Nothing Then
            Dim table As String = If(o("table") IsNot Nothing, o("table").ToString(), "")
            Dim colonne As String = If(o("colonne") IsNot Nothing, o("colonne").ToString(), "")
            Dim ch As ChampInfo = Nothing
            If colonne <> "" Then ch = TrouverChampDansTable(table, colonne)
            If ch Is Nothing AndAlso op = "COUNT" Then ch = PremierChampDeTable(table)
            If ch Is Nothing Then Return Nothing
            Return AGREGATS_INVERS(op) & "(" & ch.NomColonne & ")"
        End If
        Dim args = TryCast(o("args"), JArray)
        If args Is Nothing Then Return Nothing
        Dim txts(args.Count - 1) As String
        Dim precs(args.Count - 1) As Integer
        For i As Integer = 0 To args.Count - 1
            txts(i) = JvtTexte(args(i), precs(i))
            If txts(i) Is Nothing Then Return Nothing
        Next
        Select Case op
            Case "ADD"
                If args.Count < 2 Then Return Nothing
                prec = 5
                Dim parts As New List(Of String)
                For i As Integer = 0 To args.Count - 1 : parts.Add(ParSi(txts(i), precs(i), 5)) : Next
                Return String.Join(" + ", parts)
            Case "SUB"
                If args.Count <> 2 Then Return Nothing
                prec = 5
                Return ParSi(txts(0), precs(0), 5) & " - " & ParSi(txts(1), precs(1), 6)
            Case "MUL"
                If args.Count < 2 Then Return Nothing
                ' MUL(-1, x) -> moins unaire
                Dim jv0 = TryCast(args(0), JValue)
                If args.Count = 2 AndAlso jv0 IsNot Nothing AndAlso
                   (jv0.Type = JTokenType.Integer OrElse jv0.Type = JTokenType.Float) AndAlso
                   Convert.ToDouble(jv0.Value) = -1 Then
                    prec = 7
                    Return "- " & ParSi(txts(1), precs(1), 7)
                End If
                prec = 6
                Dim parts As New List(Of String)
                For i As Integer = 0 To args.Count - 1 : parts.Add(ParSi(txts(i), precs(i), 6)) : Next
                Return String.Join(" * ", parts)
            Case "DIVSAFE"
                If args.Count <> 2 Then Return Nothing
                prec = 6
                Return ParSi(txts(0), precs(0), 6) & " / " & ParSi(txts(1), precs(1), 7)
            Case "EQ", "NE", "GT", "GE", "LT", "LE"
                If args.Count <> 2 Then Return Nothing
                prec = 4
                Return ParSi(txts(0), precs(0), 5) & OPS_COMP_INVERS(op) & ParSi(txts(1), precs(1), 5)
            Case "AND"
                If args.Count < 2 Then Return Nothing
                prec = 2
                Dim parts As New List(Of String)
                For i As Integer = 0 To args.Count - 1 : parts.Add(ParSi(txts(i), precs(i), 2)) : Next
                Return String.Join(" ET ", parts)
            Case "OR"
                If args.Count < 2 Then Return Nothing
                prec = 1
                Dim parts As New List(Of String)
                For i As Integer = 0 To args.Count - 1 : parts.Add(ParSi(txts(i), precs(i), 1)) : Next
                Return String.Join(" OU ", parts)
            Case "NOT"
                If args.Count <> 1 Then Return Nothing
                prec = 3
                Return "NON (" & txts(0) & ")"
            Case "COND"
                If args.Count <> 3 Then Return Nothing
                Return "SI(" & String.Join("; ", txts) & ")"
            Case "ROUND"
                If args.Count < 1 OrElse args.Count > 2 Then Return Nothing
                Return "ARRONDI(" & String.Join("; ", txts) & ")"
            Case "ABS"
                If args.Count <> 1 Then Return Nothing
                Return "ABS(" & txts(0) & ")"
            Case "EMPTY"
                If args.Count <> 1 Then Return Nothing
                Return "VIDE(" & txts(0) & ")"
            Case "NOTEMPTY"
                If args.Count <> 1 Then Return Nothing
                Return "REMPLI(" & txts(0) & ")"
            Case "DATEDIFF"
                If args.Count <> 2 OrElse o("unite") Is Nothing Then Return Nothing
                Return "DUREE(" & txts(0) & "; " & txts(1) & "; """ & o("unite").ToString().ToUpperInvariant() & """)"
            Case "MIN", "MAX"
                ' Forme scalaire (la forme agrégat est traitée plus haut, avec la table)
                If args.Count < 2 Then Return Nothing
                Return op & "(" & String.Join("; ", txts) & ")"
            Case "LEFT"
                If args.Count <> 2 Then Return Nothing
                Return "GAUCHE(" & String.Join("; ", txts) & ")"
            Case "RIGHT"
                If args.Count <> 2 Then Return Nothing
                Return "DROITE(" & String.Join("; ", txts) & ")"
            Case "SUBSTRING"
                If args.Count < 2 OrElse args.Count > 3 Then Return Nothing
                Return "STXT(" & String.Join("; ", txts) & ")"
            Case "INDEXOF"
                If args.Count <> 2 Then Return Nothing
                Return "POSITION(" & String.Join("; ", txts) & ")"
            Case "LEN"
                If args.Count <> 1 Then Return Nothing
                Return "LONGUEUR(" & txts(0) & ")"
            Case "UPPER"
                If args.Count <> 1 Then Return Nothing
                Return "MAJUSCULE(" & txts(0) & ")"
            Case "LOWER"
                If args.Count <> 1 Then Return Nothing
                Return "MINUSCULE(" & txts(0) & ")"
            Case "TRIM"
                If args.Count <> 1 Then Return Nothing
                Return "SUPPRESPACE(" & txts(0) & ")"
            Case "REPLACE"
                If args.Count <> 3 Then Return Nothing
                Return "REMPLACE(" & String.Join("; ", txts) & ")"
            Case "CONCAT"
                If args.Count < 2 Then Return Nothing
                Return "CONCAT(" & String.Join("; ", txts) & ")"
            Case "CONTIENT"
                If args.Count <> 2 Then Return Nothing
                Return "CONTIENT(" & String.Join("; ", txts) & ")"
            Case "INT"
                If args.Count <> 1 Then Return Nothing
                Return "ENT(" & txts(0) & ")"
            Case "CEIL"
                If args.Count <> 1 Then Return Nothing
                Return "PLAFOND(" & txts(0) & ")"
            Case "FLOOR"
                If args.Count <> 1 Then Return Nothing
                Return "PLANCHER(" & txts(0) & ")"
            Case "DAYOFWEEK"
                If args.Count <> 1 Then Return Nothing
                Return "JOURSEM(" & txts(0) & ")"
            Case "DATEADD"
                If args.Count <> 2 OrElse o("unite") Is Nothing Then Return Nothing
                Return "AJOUTDATE(" & txts(0) & "; " & txts(1) & "; """ & o("unite").ToString().ToUpperInvariant() & """)"
            Case "DATEPART"
                If args.Count <> 1 OrElse o("partie") Is Nothing Then Return Nothing
                Select Case o("partie").ToString().ToUpperInvariant()
                    Case "A" : Return "ANNEE(" & txts(0) & ")"
                    Case "M" : Return "MOIS(" & txts(0) & ")"
                    Case "J" : Return "JOUR(" & txts(0) & ")"
                    Case Else : Return "PARTDATE(" & txts(0) & "; """ & o("partie").ToString().ToUpperInvariant() & """)"
                End Select
            Case Else
                Return Nothing ' opérateur hors périmètre de l'assistant
        End Select
    End Function

    '=====================================================================================
    ' VALIDATION FINALE (miroir de validerExpression() du moteur) — défense en profondeur
    ' avant enregistrement : opérateurs whitelistés uniquement, profondeur 20 maximum.
    '=====================================================================================
    Private Function ValiderJson(n As JToken, prof As Integer, ByRef msg As String) As Boolean
        If prof > 20 Then
            msg = "Expression trop profonde (>20)"
            Return False
        End If
        If n Is Nothing Then Return True
        Dim arr = TryCast(n, JArray)
        If arr IsNot Nothing Then
            For Each x In arr
                If Not ValiderJson(x, prof + 1, msg) Then Return False
            Next
            Return True
        End If
        Dim o = TryCast(n, JObject)
        If o Is Nothing Then Return True
        If o("op") IsNot Nothing AndAlso Not OPS_VALIDES.Contains(o("op").ToString()) Then
            msg = "Opérateur non autorisé : '" & o("op").ToString() & "'"
            Return False
        End If
        For Each p In o.Properties()
            If Not ValiderJson(p.Value, prof + 1, msg) Then Return False
        Next
        Return True
    End Function
    '---------------- Analyse en direct (statut, aperçu json, grille de test) ----------------

    Private Sub AnalyserEtAfficher()
        If Not _uiPrete Then Return
        Dim txt As String = txtFormule.Text.Trim
        If txt = "" Then
            _ast = Nothing
            grdTest.Rows.Clear()
            If _nonRepresentable Then
                lblStatut.ForeColor = Color.FromArgb(180, 120, 20)
                lblStatut.Text = "La formule existante (json ci-dessous) n'est pas représentable par l'assistant : composez une nouvelle formule pour la remplacer, ou Annuler pour la conserver."
            Else
                lblStatut.ForeColor = Color.FromArgb(110, 110, 110)
                lblStatut.Text = "Composez la formule à l'aide des listes et boutons de l'étape 1."
                txtJson.Text = ""
            End If
            Return
        End If
        Dim err As String = Nothing, pos As Integer = -1
        Dim j As JToken = AnalyserFormule(txt, err, pos)
        If j Is Nothing Then
            _ast = Nothing
            grdTest.Rows.Clear()
            txtJson.Text = ""
            lblStatut.ForeColor = Color.FromArgb(200, 40, 40)
            lblStatut.Text = "✖ " & err & If(pos >= 0, "   (position " & (pos + 1) & ")", "")
        Else
            _ast = j
            txtJson.Text = j.ToString(Formatting.None)
            lblStatut.ForeColor = Color.FromArgb(20, 120, 60)
            lblStatut.Text = "✔ Formule valide — testez-la à l'étape 3 puis cliquez sur « Enregistrer la formule »."
            MajGrilleTest(j)
        End If
    End Sub

    ''' <summary>Recense les éléments à renseigner pour le test : références de champs
    ''' (hors GV_, résolues automatiquement), colonnes agrégées et tableaux comptés.</summary>
    Private Sub CollecterElements(n As JToken, refs As List(Of String), aggs As List(Of String), cnts As List(Of String))
        If n Is Nothing Then Return
        Dim arr = TryCast(n, JArray)
        If arr IsNot Nothing Then
            For Each x In arr : CollecterElements(x, refs, aggs, cnts) : Next
            Return
        End If
        Dim o = TryCast(n, JObject)
        If o Is Nothing Then Return
        If o("ref") IsNot Nothing Then
            Dim r As String = o("ref").ToString()
            If r <> "@result" AndAlso Not r.StartsWith("GV_", StringComparison.OrdinalIgnoreCase) AndAlso
               Not refs.Contains(r, StringComparer.OrdinalIgnoreCase) Then refs.Add(r)
        End If
        Dim op As String = If(o("op") IsNot Nothing, o("op").ToString().ToUpperInvariant(), "")
        If (op = "SUM" OrElse op = "AVG" OrElse op = "MIN" OrElse op = "MAX") AndAlso
           o("table") IsNot Nothing AndAlso o("colonne") IsNot Nothing Then
            Dim cle As String = o("table").ToString() & "|" & o("colonne").ToString()
            If Not aggs.Contains(cle, StringComparer.OrdinalIgnoreCase) Then aggs.Add(cle)
        ElseIf op = "COUNT" AndAlso o("table") IsNot Nothing Then
            Dim t As String = o("table").ToString()
            If Not cnts.Contains(t, StringComparer.OrdinalIgnoreCase) Then cnts.Add(t)
        End If
        For Each p In o.Properties()
            If p.Name <> "ref" Then CollecterElements(p.Value, refs, aggs, cnts)
        Next
    End Sub

    ''' <summary>Reconstruit la grille de test en préservant les valeurs déjà saisies.</summary>
    Private Sub MajGrilleTest(ast As JToken)
        Dim anciennes As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        For Each r As DataGridViewRow In grdTest.Rows
            anciennes(CStr(r.Tag)) = IsNull(r.Cells("colVal").Value, "")
        Next
        Dim refs As New List(Of String), aggs As New List(Of String), cnts As New List(Of String)
        CollecterElements(ast, refs, aggs, cnts)
        grdTest.Rows.Clear()
        For Each nom In refs
            Dim ch As ChampInfo = TrouverChamp(nom)
            AjouterLigneTest(anciennes, "REF|" & nom,
                             If(ch IsNot Nothing AndAlso ch.Libelle <> "", nom & " — " & ch.Libelle, nom), "ex : 12,5 ou 12/08/2026")
        Next
        For Each cle In aggs
            Dim parts As String() = cle.Split("|"c)
            AjouterLigneTest(anciennes, "AGG|" & cle,
                             parts(1) & " (lignes du tableau '" & parts(0) & "')", "valeurs des lignes, séparées par ;  ex : 10 ; 20,5 ; 3")
        Next
        For Each t In cnts
            ' Inutile de demander le nombre de lignes si une colonne du même tableau est déjà
            ' listée (le nombre de valeurs saisies fait office de nombre de lignes au test)
            Dim deja As Boolean = False
            For Each cle In aggs
                If cle.StartsWith(t & "|", StringComparison.OrdinalIgnoreCase) Then deja = True : Exit For
            Next
            If Not deja Then AjouterLigneTest(anciennes, "CNT|" & t, "Nombre de lignes du tableau '" & t & "'", "ex : 3")
        Next
    End Sub
    Private Sub AjouterLigneTest(anciennes As Dictionary(Of String, String), cle As String, libelle As String, aide As String)
        Dim i As Integer = grdTest.Rows.Add(libelle, If(anciennes.ContainsKey(cle), anciennes(cle), ""))
        grdTest.Rows(i).Tag = cle
        grdTest.Rows(i).Cells("colVal").ToolTipText = aide
    End Sub

    Private Function FormaterResultat(v As Object) As String
        If v Is Nothing Then Return "(vide)"
        If TypeOf v Is Boolean Then Return If(CBool(v), "Vrai", "Faux")
        If TypeOf v Is DateTime Then Return CDate(v).ToString("dd/MM/yyyy HH:mm:ss")
        If IsNumeric(v) Then Return CDbl(v).ToString("0.########")
        Return v.ToString()
    End Function

    '---------------- Événements ----------------

    Private Sub txtFormule_TextChanged(sender As Object, e As EventArgs) Handles txtFormule.TextChanged
        If _enMaj Then Return
        AnalyserEtAfficher()
    End Sub

    Private Sub lstChamps_DoubleClick(sender As Object, e As EventArgs) Handles lstChamps.DoubleClick
        InsererChampSelectionne()
    End Sub
    Private Sub btnInsererChamp_Click(sender As Object, e As EventArgs) Handles btnInsererChamp.Click
        InsererChampSelectionne()
    End Sub
    Private Sub lstGV_DoubleClick(sender As Object, e As EventArgs) Handles lstGV.DoubleClick
        InsererVariableSelectionnee()
    End Sub
    Private Sub btnInsererGV_Click(sender As Object, e As EventArgs) Handles btnInsererGV.Click
        InsererVariableSelectionnee()
    End Sub

    Private Sub cmbExemples_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbExemples.SelectedIndexChanged
        If _enMaj OrElse Not _uiPrete Then Return
        Dim ex = TryCast(cmbExemples.SelectedItem, ItemExemple)
        If ex Is Nothing OrElse ex.Texte Is Nothing Then Return
        _enMaj = True : cmbExemples.SelectedIndex = 0 : _enMaj = False
        txtFormule.Text = ex.Texte   ' déclenche l'analyse via TextChanged
        txtFormule.Focus()
        txtFormule.SelectionStart = txtFormule.TextLength
    End Sub

    Private Sub btnCalculer_Click(sender As Object, e As EventArgs) Handles btnCalculer.Click
        If _ast Is Nothing Then
            ShowMessageBox("La formule n'est pas encore valide : corrigez-la (message rouge à l'étape 2) avant de la tester.",
                           "Test", MessageBoxButtons.OK, msgIcon.Warning)
            Return
        End If
        grdTest.EndEdit()
        _valChamps.Clear() : _valAgg.Clear() : _valCnt.Clear()
        For Each r As DataGridViewRow In grdTest.Rows
            Dim cle As String = CStr(r.Tag)
            Dim brut As String = IsNull(r.Cells("colVal").Value, "").Trim
            If cle.StartsWith("REF|", StringComparison.Ordinal) Then
                _valChamps(cle.Substring(4)) = brut
            ElseIf cle.StartsWith("AGG|", StringComparison.Ordinal) Then
                Dim lst As New List(Of Double)
                For Each morceau In brut.Split(";"c)
                    If morceau.Trim <> "" Then lst.Add(NumTexte(morceau))
                Next
                _valAgg(cle.Substring(4)) = lst
            ElseIf cle.StartsWith("CNT|", StringComparison.Ordinal) Then
                _valCnt(cle.Substring(4)) = NumTexte(brut)
            End If
        Next
        Try
            Dim res As Object = Evaluer(_ast)
            lblResultat.ForeColor = Color.FromArgb(20, 120, 60)
            lblResultat.Text = "Résultat :" & vbCrLf & FormaterResultat(res)
        Catch ex As Exception
            lblResultat.ForeColor = Color.FromArgb(200, 40, 40)
            lblResultat.Text = "Calcul impossible : " & ex.Message
        End Try
    End Sub

    Private Sub btnEnregistrer_Click(sender As Object, e As EventArgs) Handles btnEnregistrer.Click
        Dim txt As String = txtFormule.Text.Trim
        If txt = "" Then
            ShowMessageBox(If(_nonRepresentable,
                              "La formule existante sera conservée : cliquez sur Annuler. Pour la remplacer, composez d'abord une nouvelle formule.",
                              "Composez d'abord une formule (étapes 1 et 2), ou cliquez sur Annuler."),
                           "Assistant de formule", MessageBoxButtons.OK, msgIcon.Warning)
            Return
        End If
        Dim err As String = Nothing, pos As Integer = -1
        Dim j As JToken = AnalyserFormule(txt, err, pos)
        If j Is Nothing Then
            ShowMessageBox("La formule n'est pas encore valide :" & vbCrLf & err,
                           "Assistant de formule", MessageBoxButtons.OK, msgIcon.Warning)
            Return
        End If
        Dim msg As String = ""
        If Not ValiderJson(j, 0, msg) Then
            ShowMessageBox("Contrôle de sécurité : " & msg, "Assistant de formule", MessageBoxButtons.OK, msgIcon.Warning)
            Return
        End If
        Me.FormuleJson = j.ToString(Formatting.None)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ''' <summary>Guide pas-à-pas + exemples autorisés + rappel sécurité (aide intégrée).</summary>
    Private Sub btnAide_Click(sender As Object, e As EventArgs) Handles btnAide.Click
        ShowMessageBox(
            "GUIDE PAS À PAS" & vbCrLf &
            "1. Double-cliquez sur un champ (ou une variable GV_) : il est inséré à la position du curseur." & vbCrLf &
            "2. Complétez avec les boutons +  -  *  /  et les parenthèses." & vbCrLf &
            "3. Les menus de fonctions (Texte, Dates, Nombres, Condition, Tableau) insèrent un modèle :" & vbCrLf &
            "   remplacez le mot présélectionné par un champ de la liste." & vbCrLf &
            "4. Testez à l'étape 3 avec des valeurs d'essai, puis « Enregistrer la formule »." & vbCrLf & vbCrLf &
            "FONCTIONS PAR FAMILLE" & vbCrLf &
            "- Texte : GAUCHE(t; n), DROITE(t; n), STXT(t; début; longueur), POSITION(morceau; t)," & vbCrLf &
            "  LONGUEUR(t), MAJUSCULE(t), MINUSCULE(t), SUPPRESPACE(t), REMPLACE(t; ancien; nouveau)," & vbCrLf &
            "  CONCAT(a; b; …), CONTIENT(t; morceau)" & vbCrLf &
            "- Dates : DUREE(fin; début; ""S""/""MI""/""H""/""J""), AJOUTDATE(date; nombre; ""J""/""MO""/""A""…)," & vbCrLf &
            "  ANNEE(d), MOIS(d), JOUR(d), PARTDATE(d; ""H""/""MI""/""S""), JOURSEM(d) : 1 = lundi … 7 = dimanche" & vbCrLf &
            "  Astuce : ""date de fin - date de début"" donne directement la durée en secondes (ex : (Dat_Fin - Dat_Deb) / 3600 = heures)" & vbCrLf &
            "- Nombres : ARRONDI(v; 2), ABS(v), ENT(v), PLAFOND(v), PLANCHER(v), MIN(a; b; …), MAX(a; b; …)" & vbCrLf &
            "- Conditions : SI(condition; valeur si vrai; valeur si faux), VIDE(champ), REMPLI(champ)" & vbCrLf &
            "- Tableau : SOMME(colonne), MOYENNE(colonne), MIN(colonne), MAX(colonne), NB() : calculs sur les lignes" & vbCrLf & vbCrLf &
            "EXEMPLES AUTORISÉS" & vbCrLf &
            "- ARRONDI(Km * Tx; 2)" & vbCrLf &
            "- DUREE(Dat_Fin_ABS; Dat_Deb_ABS; ""S"")  → durée d'absence en secondes" & vbCrLf &
            "- AJOUTDATE(Dat_Deb; 30; ""J"")  → échéance à 30 jours" & vbCrLf &
            "- CONCAT(GAUCHE(Code; 3); ""-""; ANNEE(GV_NOW))  → référence composée" & vbCrLf &
            "- SI(Montant > 1000; ARRONDI(Montant * 0,9; 2); Montant)" & vbCrLf &
            "- SOMME(Mnt) + SOMME(Frais)" & vbCrLf & vbCrLf &
            "SÉCURITÉ" & vbCrLf &
            "Seuls les champs de la page, les variables GV_, les nombres et les opérateurs ci-dessus sont acceptés :" & vbCrLf &
            "aucun code libre n'est exécuté (pas d'eval), côté assistant comme côté moteur.",
            "Aide — Assistant de formule", MessageBoxButtons.OK, msgIcon.Information)
    End Sub

End Class
