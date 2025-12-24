<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Param_Query_Saisi
    Inherits Ecran

    'Form rEmplace la méthode Dispose pour nettoyer la liste des composants.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DoughnutSeriesLabel1 As DevExpress.XtraCharts.DoughnutSeriesLabel = New DevExpress.XtraCharts.DoughnutSeriesLabel()
        Dim DoughnutSeriesView1 As DevExpress.XtraCharts.DoughnutSeriesView = New DevExpress.XtraCharts.DoughnutSeriesView()
        Dim SeriesTitle1 As DevExpress.XtraCharts.SeriesTitle = New DevExpress.XtraCharts.SeriesTitle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Criteres_Grd = New RHP.ud_Grd()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.tb_Source = New DevExpress.XtraTab.XtraTabPage()
        Me.MyGrdSource = New DevExpress.XtraGrid.GridControl()
        Me.GrdViewSource = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tb_Pivot = New DevExpress.XtraTab.XtraTabPage()
        Me.MyPivot = New DevExpress.XtraPivotGrid.PivotGridControl()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.pivot_Champs = New System.Windows.Forms.TableLayoutPanel()
        Me._Pnl = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_Detail = New DevExpress.XtraTab.XtraTabPage()
        Me.MyGrdDetail = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AfficherTousLesGroupesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RaffraichirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrdViewDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tb_Graph = New DevExpress.XtraTab.XtraTabPage()
        Me.ChartControl1 = New DevExpress.XtraCharts.ChartControl()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Excel_pb = New System.Windows.Forms.PictureBox()
        Me.Pdf_pb = New System.Windows.Forms.PictureBox()
        Me.SumCol_pb = New System.Windows.Forms.PictureBox()
        Me.SumLig_pb = New System.Windows.Forms.PictureBox()
        Me.ChampsCalcule_pb = New System.Windows.Forms.PictureBox()
        Me.InverserEntete_pb = New System.Windows.Forms.PictureBox()
        Me.LoadPivot_pb = New System.Windows.Forms.PictureBox()
        Me.SavePivot_pb = New System.Windows.Forms.PictureBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TypeDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SommeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NombreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoyenneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormatDeNombreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AfficherLesTopToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Print_D = New DevComponents.DotNetBar.ButtonItem()
        Me.entpnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Run_pb = New System.Windows.Forms.PictureBox()
        Me.Nom_Query_txt = New RHP.ud_TextBox()
        Me.Cod_Query_txt = New RHP.ud_TextBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Critere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lib_Critere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valeur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Criteres_Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        CType(Me.MyGrdSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrdViewSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyPivot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pivot_Champs.SuspendLayout()
        CType(Me.MyGrdDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.GrdViewDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(DoughnutSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(DoughnutSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.Excel_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pdf_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SumCol_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SumLig_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChampsCalcule_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InverserEntete_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoadPivot_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SavePivot_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.entpnl.SuspendLayout()
        CType(Me.Run_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 30)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(886, 525)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Criteres_Grd)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(878, 496)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Saisi des Paramètres de la requête"
        '
        'Criteres_Grd
        '
        Me.Criteres_Grd.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Criteres_Grd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Criteres_Grd.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Criteres_Grd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Criteres_Grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Criteres_Grd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Criteres_Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Criteres_Grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Critere, Me.Lib_Critere, Me.Valeur, Me.Type})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(36, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Criteres_Grd.DefaultCellStyle = DataGridViewCellStyle4
        Me.Criteres_Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Criteres_Grd.EnableHeadersVisualStyles = False
        Me.Criteres_Grd.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Criteres_Grd.Location = New System.Drawing.Point(3, 3)
        Me.Criteres_Grd.Name = "Criteres_Grd"
        Me.Criteres_Grd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Criteres_Grd.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Criteres_Grd.RowHeadersVisible = False
        Me.Criteres_Grd.Size = New System.Drawing.Size(872, 490)
        Me.Criteres_Grd.TabIndex = 82
        '
        'TabPage2
        '
        Me.TabPage2.AutoScroll = True
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.XtraTabControl1)
        Me.TabPage2.Controls.Add(Me.Personnal_pnl)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(878, 496)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Résultat de la requête"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.[False]
        Me.XtraTabControl1.HeaderButtons = DevExpress.XtraTab.TabButtons.None
        Me.XtraTabControl1.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.WhenNeeded
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl1.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XtraTabControl1.Location = New System.Drawing.Point(3, 33)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.tb_Source
        Me.XtraTabControl1.Size = New System.Drawing.Size(872, 460)
        Me.XtraTabControl1.TabIndex = 1
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tb_Source, Me.tb_Pivot, Me.tb_Detail, Me.tb_Graph})
        '
        'tb_Source
        '
        Me.tb_Source.Controls.Add(Me.MyGrdSource)
        Me.tb_Source.Enabled = True
        Me.tb_Source.Name = "tb_Source"
        Me.tb_Source.Size = New System.Drawing.Size(870, 435)
        Me.tb_Source.Text = "Source"
        '
        'MyGrdSource
        '
        Me.MyGrdSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyGrdSource.Location = New System.Drawing.Point(0, 0)
        Me.MyGrdSource.MainView = Me.GrdViewSource
        Me.MyGrdSource.Name = "MyGrdSource"
        Me.MyGrdSource.Size = New System.Drawing.Size(870, 435)
        Me.MyGrdSource.TabIndex = 0
        Me.MyGrdSource.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GrdViewSource})
        '
        'GrdViewSource
        '
        Me.GrdViewSource.DetailHeight = 284
        Me.GrdViewSource.GridControl = Me.MyGrdSource
        Me.GrdViewSource.Name = "GrdViewSource"
        Me.GrdViewSource.OptionsView.ShowFooter = True
        '
        'tb_Pivot
        '
        Me.tb_Pivot.Controls.Add(Me.MyPivot)
        Me.tb_Pivot.Controls.Add(Me.Splitter1)
        Me.tb_Pivot.Controls.Add(Me.pivot_Champs)
        Me.tb_Pivot.Enabled = True
        Me.tb_Pivot.Name = "tb_Pivot"
        Me.tb_Pivot.Size = New System.Drawing.Size(870, 435)
        Me.tb_Pivot.Text = "Tableau croisé dynamique"
        '
        'MyPivot
        '
        Me.MyPivot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyPivot.Location = New System.Drawing.Point(0, 0)
        Me.MyPivot.Name = "MyPivot"
        Me.MyPivot.OptionsChartDataSource.SelectionOnly = False
        Me.MyPivot.OptionsCustomization.CustomizationFormStyle = DevExpress.XtraPivotGrid.Customization.CustomizationFormStyle.Excel2007
        Me.MyPivot.OptionsMenu.EnableFieldValueMenu = False
        Me.MyPivot.OptionsMenu.EnableHeaderAreaMenu = False
        Me.MyPivot.OptionsMenu.EnableHeaderMenu = False
        Me.MyPivot.OptionsView.ShowCustomTotalsForSingleValues = True
        Me.MyPivot.OptionsView.ShowGrandTotalsForSingleValues = True
        Me.MyPivot.Size = New System.Drawing.Size(517, 435)
        Me.MyPivot.TabIndex = 0
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter1.Location = New System.Drawing.Point(517, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 435)
        Me.Splitter1.TabIndex = 87
        Me.Splitter1.TabStop = False
        '
        'pivot_Champs
        '
        Me.pivot_Champs.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pivot_Champs.ColumnCount = 1
        Me.pivot_Champs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pivot_Champs.Controls.Add(Me._Pnl, 0, 1)
        Me.pivot_Champs.Controls.Add(Me.Label1, 0, 0)
        Me.pivot_Champs.Dock = System.Windows.Forms.DockStyle.Right
        Me.pivot_Champs.Location = New System.Drawing.Point(520, 0)
        Me.pivot_Champs.Name = "pivot_Champs"
        Me.pivot_Champs.RowCount = 2
        Me.pivot_Champs.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.pivot_Champs.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pivot_Champs.Size = New System.Drawing.Size(350, 435)
        Me.pivot_Champs.TabIndex = 1
        '
        '_Pnl
        '
        Me._Pnl.BackColor = System.Drawing.Color.White
        Me._Pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me._Pnl.Location = New System.Drawing.Point(3, 33)
        Me._Pnl.Name = "_Pnl"
        Me._Pnl.Size = New System.Drawing.Size(344, 399)
        Me._Pnl.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.25!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(344, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Liste des champs"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tb_Detail
        '
        Me.tb_Detail.Controls.Add(Me.MyGrdDetail)
        Me.tb_Detail.Enabled = True
        Me.tb_Detail.Name = "tb_Detail"
        Me.tb_Detail.Size = New System.Drawing.Size(870, 435)
        Me.tb_Detail.Text = "Détail"
        '
        'MyGrdDetail
        '
        Me.MyGrdDetail.ContextMenuStrip = Me.ContextMenuStrip2
        Me.MyGrdDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyGrdDetail.Location = New System.Drawing.Point(0, 0)
        Me.MyGrdDetail.MainView = Me.GrdViewDetail
        Me.MyGrdDetail.Name = "MyGrdDetail"
        Me.MyGrdDetail.Size = New System.Drawing.Size(870, 435)
        Me.MyGrdDetail.TabIndex = 0
        Me.MyGrdDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GrdViewDetail})
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AfficherTousLesGroupesToolStripMenuItem, Me.RaffraichirToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(206, 48)
        '
        'AfficherTousLesGroupesToolStripMenuItem
        '
        Me.AfficherTousLesGroupesToolStripMenuItem.Name = "AfficherTousLesGroupesToolStripMenuItem"
        Me.AfficherTousLesGroupesToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.AfficherTousLesGroupesToolStripMenuItem.Text = "Afficher tous les groupes"
        '
        'RaffraichirToolStripMenuItem
        '
        Me.RaffraichirToolStripMenuItem.Name = "RaffraichirToolStripMenuItem"
        Me.RaffraichirToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.RaffraichirToolStripMenuItem.Text = "Rafraîchir"
        '
        'GrdViewDetail
        '
        Me.GrdViewDetail.GridControl = Me.MyGrdDetail
        Me.GrdViewDetail.Name = "GrdViewDetail"
        '
        'tb_Graph
        '
        Me.tb_Graph.Controls.Add(Me.ChartControl1)
        Me.tb_Graph.Enabled = True
        Me.tb_Graph.Name = "tb_Graph"
        Me.tb_Graph.Size = New System.Drawing.Size(870, 435)
        Me.tb_Graph.Text = "Graphique"
        '
        'ChartControl1
        '
        Me.ChartControl1.DataSource = Me.MyPivot
        Me.ChartControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartControl1.Legend.MaxHorizontalPercentage = 30.0R
        Me.ChartControl1.Legend.Name = "Default Legend"
        Me.ChartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.ChartControl1.Location = New System.Drawing.Point(0, 0)
        Me.ChartControl1.Name = "ChartControl1"
        Me.ChartControl1.SeriesDataMember = "Series"
        Me.ChartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.ChartControl1.SeriesTemplate.ArgumentDataMember = "Arguments"
        Me.ChartControl1.SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative
        DoughnutSeriesLabel1.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.TwoColumns
        Me.ChartControl1.SeriesTemplate.Label = DoughnutSeriesLabel1
        Me.ChartControl1.SeriesTemplate.LegendTextPattern = "{A}"
        Me.ChartControl1.SeriesTemplate.SeriesDataMember = "Series"
        Me.ChartControl1.SeriesTemplate.ValueDataMembersSerializable = "Values"
        DoughnutSeriesView1.Titles.AddRange(New DevExpress.XtraCharts.SeriesTitle() {SeriesTitle1})
        Me.ChartControl1.SeriesTemplate.View = DoughnutSeriesView1
        Me.ChartControl1.Size = New System.Drawing.Size(870, 435)
        Me.ChartControl1.TabIndex = 0
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Personnal_pnl.ColumnCount = 10
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 602.0!))
        Me.Personnal_pnl.Controls.Add(Me.Excel_pb, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.Pdf_pb, 1, 0)
        Me.Personnal_pnl.Controls.Add(Me.SumCol_pb, 2, 0)
        Me.Personnal_pnl.Controls.Add(Me.SumLig_pb, 3, 0)
        Me.Personnal_pnl.Controls.Add(Me.ChampsCalcule_pb, 4, 0)
        Me.Personnal_pnl.Controls.Add(Me.InverserEntete_pb, 5, 0)
        Me.Personnal_pnl.Controls.Add(Me.LoadPivot_pb, 6, 0)
        Me.Personnal_pnl.Controls.Add(Me.SavePivot_pb, 7, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Personnal_pnl.Location = New System.Drawing.Point(3, 3)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(872, 30)
        Me.Personnal_pnl.TabIndex = 86
        '
        'Excel_pb
        '
        Me.Excel_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Excel_pb.Image = Global.RHP.My.Resources.Resources.btn_excel_w
        Me.Excel_pb.InitialImage = Nothing
        Me.Excel_pb.Location = New System.Drawing.Point(3, 3)
        Me.Excel_pb.Name = "Excel_pb"
        Me.Excel_pb.Size = New System.Drawing.Size(24, 20)
        Me.Excel_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Excel_pb.TabIndex = 11
        Me.Excel_pb.TabStop = False
        '
        'Pdf_pb
        '
        Me.Pdf_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Pdf_pb.Image = Global.RHP.My.Resources.Resources.btn_pdf_w
        Me.Pdf_pb.InitialImage = Nothing
        Me.Pdf_pb.Location = New System.Drawing.Point(33, 3)
        Me.Pdf_pb.Name = "Pdf_pb"
        Me.Pdf_pb.Size = New System.Drawing.Size(24, 20)
        Me.Pdf_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Pdf_pb.TabIndex = 11
        Me.Pdf_pb.TabStop = False
        '
        'SumCol_pb
        '
        Me.SumCol_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SumCol_pb.Image = Global.RHP.My.Resources.Resources.btn_sum_col_w
        Me.SumCol_pb.InitialImage = Nothing
        Me.SumCol_pb.Location = New System.Drawing.Point(63, 3)
        Me.SumCol_pb.Name = "SumCol_pb"
        Me.SumCol_pb.Size = New System.Drawing.Size(24, 20)
        Me.SumCol_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SumCol_pb.TabIndex = 11
        Me.SumCol_pb.TabStop = False
        '
        'SumLig_pb
        '
        Me.SumLig_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SumLig_pb.Image = Global.RHP.My.Resources.Resources.btn_sum_col_r
        Me.SumLig_pb.InitialImage = Nothing
        Me.SumLig_pb.Location = New System.Drawing.Point(93, 3)
        Me.SumLig_pb.Name = "SumLig_pb"
        Me.SumLig_pb.Size = New System.Drawing.Size(24, 20)
        Me.SumLig_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SumLig_pb.TabIndex = 11
        Me.SumLig_pb.TabStop = False
        '
        'ChampsCalcule_pb
        '
        Me.ChampsCalcule_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChampsCalcule_pb.Image = Global.RHP.My.Resources.Resources.btn_champsCalcule_w
        Me.ChampsCalcule_pb.InitialImage = Nothing
        Me.ChampsCalcule_pb.Location = New System.Drawing.Point(123, 3)
        Me.ChampsCalcule_pb.Name = "ChampsCalcule_pb"
        Me.ChampsCalcule_pb.Size = New System.Drawing.Size(24, 20)
        Me.ChampsCalcule_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ChampsCalcule_pb.TabIndex = 12
        Me.ChampsCalcule_pb.TabStop = False
        '
        'InverserEntete_pb
        '
        Me.InverserEntete_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.InverserEntete_pb.Image = Global.RHP.My.Resources.Resources.btn_reverse_w
        Me.InverserEntete_pb.InitialImage = Nothing
        Me.InverserEntete_pb.Location = New System.Drawing.Point(153, 3)
        Me.InverserEntete_pb.Name = "InverserEntete_pb"
        Me.InverserEntete_pb.Size = New System.Drawing.Size(24, 20)
        Me.InverserEntete_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.InverserEntete_pb.TabIndex = 13
        Me.InverserEntete_pb.TabStop = False
        '
        'LoadPivot_pb
        '
        Me.LoadPivot_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LoadPivot_pb.Image = Global.RHP.My.Resources.Resources.btn_load_w
        Me.LoadPivot_pb.InitialImage = Nothing
        Me.LoadPivot_pb.Location = New System.Drawing.Point(183, 3)
        Me.LoadPivot_pb.Name = "LoadPivot_pb"
        Me.LoadPivot_pb.Size = New System.Drawing.Size(24, 20)
        Me.LoadPivot_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LoadPivot_pb.TabIndex = 14
        Me.LoadPivot_pb.TabStop = False
        '
        'SavePivot_pb
        '
        Me.SavePivot_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SavePivot_pb.Image = Global.RHP.My.Resources.Resources.btn_save_w
        Me.SavePivot_pb.InitialImage = Nothing
        Me.SavePivot_pb.Location = New System.Drawing.Point(213, 3)
        Me.SavePivot_pb.Name = "SavePivot_pb"
        Me.SavePivot_pb.Size = New System.Drawing.Size(24, 20)
        Me.SavePivot_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SavePivot_pb.TabIndex = 15
        Me.SavePivot_pb.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Chart1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(878, 496)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Graphe"
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(3, 3)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(872, 490)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TypeDeToolStripMenuItem, Me.FormatDeNombreToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(176, 48)
        '
        'TypeDeToolStripMenuItem
        '
        Me.TypeDeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SommeToolStripMenuItem, Me.NombreToolStripMenuItem, Me.MinToolStripMenuItem, Me.MaxToolStripMenuItem, Me.MoyenneToolStripMenuItem})
        Me.TypeDeToolStripMenuItem.Name = "TypeDeToolStripMenuItem"
        Me.TypeDeToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.TypeDeToolStripMenuItem.Text = "Type de résumé"
        '
        'SommeToolStripMenuItem
        '
        Me.SommeToolStripMenuItem.Name = "SommeToolStripMenuItem"
        Me.SommeToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.SommeToolStripMenuItem.Text = "Somme"
        '
        'NombreToolStripMenuItem
        '
        Me.NombreToolStripMenuItem.Name = "NombreToolStripMenuItem"
        Me.NombreToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.NombreToolStripMenuItem.Text = "Nombre"
        '
        'MinToolStripMenuItem
        '
        Me.MinToolStripMenuItem.Name = "MinToolStripMenuItem"
        Me.MinToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.MinToolStripMenuItem.Text = "Min"
        '
        'MaxToolStripMenuItem
        '
        Me.MaxToolStripMenuItem.Name = "MaxToolStripMenuItem"
        Me.MaxToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.MaxToolStripMenuItem.Text = "Max"
        '
        'MoyenneToolStripMenuItem
        '
        Me.MoyenneToolStripMenuItem.Name = "MoyenneToolStripMenuItem"
        Me.MoyenneToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.MoyenneToolStripMenuItem.Text = "Moyenne"
        '
        'FormatDeNombreToolStripMenuItem
        '
        Me.FormatDeNombreToolStripMenuItem.Name = "FormatDeNombreToolStripMenuItem"
        Me.FormatDeNombreToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.FormatDeNombreToolStripMenuItem.Text = "Format de Nombre"
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AfficherLesTopToolStripMenuItem1})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(167, 26)
        '
        'AfficherLesTopToolStripMenuItem1
        '
        Me.AfficherLesTopToolStripMenuItem1.Name = "AfficherLesTopToolStripMenuItem1"
        Me.AfficherLesTopToolStripMenuItem1.Size = New System.Drawing.Size(166, 22)
        Me.AfficherLesTopToolStripMenuItem1.Text = "Afficher les top ..."
        '
        'Print_D
        '
        Me.Print_D.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_D.Image = Global.RHP.My.Resources.Resources.Printer
        Me.Print_D.Name = "Print_D"
        Me.Print_D.Text = "ButtonItem1"
        Me.Print_D.Tooltip = "Imprimer"
        '
        'entpnl
        '
        Me.entpnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.entpnl.ColumnCount = 4
        Me.entpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.entpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.entpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.entpnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.entpnl.Controls.Add(Me.Run_pb, 2, 0)
        Me.entpnl.Controls.Add(Me.Nom_Query_txt, 1, 0)
        Me.entpnl.Controls.Add(Me.Cod_Query_txt, 0, 0)
        Me.entpnl.Controls.Add(Me.Close_pb, 3, 0)
        Me.entpnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.entpnl.Location = New System.Drawing.Point(0, 0)
        Me.entpnl.Name = "entpnl"
        Me.entpnl.RowCount = 1
        Me.entpnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.entpnl.Size = New System.Drawing.Size(886, 30)
        Me.entpnl.TabIndex = 85
        '
        'Run_pb
        '
        Me.Run_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Run_pb.Image = Global.RHP.My.Resources.Resources.btn_netToBrut_w
        Me.Run_pb.InitialImage = Nothing
        Me.Run_pb.Location = New System.Drawing.Point(829, 3)
        Me.Run_pb.Name = "Run_pb"
        Me.Run_pb.Size = New System.Drawing.Size(24, 20)
        Me.Run_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Run_pb.TabIndex = 11
        Me.Run_pb.TabStop = False
        '
        'Nom_Query_txt
        '
        Me.Nom_Query_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Nom_Query_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Nom_Query_txt.Location = New System.Drawing.Point(253, 4)
        Me.Nom_Query_txt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Nom_Query_txt.MaxLength = 32767
        Me.Nom_Query_txt.Multiline = False
        Me.Nom_Query_txt.Name = "Nom_Query_txt"
        Me.Nom_Query_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Nom_Query_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Nom_Query_txt.ReadOnly = True
        Me.Nom_Query_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Nom_Query_txt.SelectionStart = 0
        Me.Nom_Query_txt.Size = New System.Drawing.Size(570, 22)
        Me.Nom_Query_txt.TabIndex = 12
        Me.Nom_Query_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Nom_Query_txt.UseSystemPasswordChar = False
        '
        'Cod_Query_txt
        '
        Me.Cod_Query_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cod_Query_txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cod_Query_txt.Location = New System.Drawing.Point(3, 5)
        Me.Cod_Query_txt.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Cod_Query_txt.MaxLength = 32767
        Me.Cod_Query_txt.Multiline = False
        Me.Cod_Query_txt.Name = "Cod_Query_txt"
        Me.Cod_Query_txt.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Cod_Query_txt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Cod_Query_txt.ReadOnly = True
        Me.Cod_Query_txt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Cod_Query_txt.SelectionStart = 0
        Me.Cod_Query_txt.Size = New System.Drawing.Size(244, 20)
        Me.Cod_Query_txt.TabIndex = 12
        Me.Cod_Query_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Cod_Query_txt.UseSystemPasswordChar = False
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close_w
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(859, 3)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(24, 20)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 13
        Me.Close_pb.TabStop = False
        '
        'Critere
        '
        Me.Critere.HeaderText = "Code Critère"
        Me.Critere.MinimumWidth = 200
        Me.Critere.Name = "Critere"
        Me.Critere.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Critere.Visible = False
        Me.Critere.Width = 200
        '
        'Lib_Critere
        '
        Me.Lib_Critere.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        Me.Lib_Critere.DefaultCellStyle = DataGridViewCellStyle3
        Me.Lib_Critere.HeaderText = "Critère"
        Me.Lib_Critere.Name = "Lib_Critere"
        Me.Lib_Critere.ReadOnly = True
        Me.Lib_Critere.Width = 77
        '
        'Valeur
        '
        Me.Valeur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Valeur.HeaderText = "Valeur"
        Me.Valeur.MinimumWidth = 400
        Me.Valeur.Name = "Valeur"
        Me.Valeur.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Valeur.Width = 400
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.Visible = False
        '
        'Param_Query_Saisi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(886, 555)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.entpnl)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Name = "Param_Query_Saisi"
        Me.Tag = ""
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.Criteres_Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        CType(Me.MyGrdSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrdViewSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyPivot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pivot_Champs.ResumeLayout(False)
        Me.pivot_Champs.PerformLayout()
        CType(Me.MyGrdDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.GrdViewDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(DoughnutSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(DoughnutSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.Excel_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pdf_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SumCol_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SumLig_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChampsCalcule_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InverserEntete_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoadPivot_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SavePivot_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.entpnl.ResumeLayout(False)
        CType(Me.Run_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Criteres_Grd As ud_Grd
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents TypeDeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SommeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NombreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MinToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MaxToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MoyenneToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FormatDeNombreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip3 As ContextMenuStrip
    Friend WithEvents AfficherLesTopToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents AfficherTousLesGroupesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RaffraichirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Print_D As DevComponents.DotNetBar.ButtonItem
    Private WithEvents MyGrdSource As DevExpress.XtraGrid.GridControl
    Private WithEvents GrdViewSource As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Private WithEvents tb_Pivot As DevExpress.XtraTab.XtraTabPage
    Private WithEvents MyPivot As DevExpress.XtraPivotGrid.PivotGridControl
    Private WithEvents tb_Source As DevExpress.XtraTab.XtraTabPage
    Private WithEvents tb_Detail As DevExpress.XtraTab.XtraTabPage
    Private WithEvents MyGrdDetail As DevExpress.XtraGrid.GridControl
    Private WithEvents GrdViewDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents tb_Graph As DevExpress.XtraTab.XtraTabPage
    Private WithEvents ChartControl1 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents entpnl As TableLayoutPanel
    Friend WithEvents Run_pb As PictureBox
    Friend WithEvents Nom_Query_txt As ud_TextBox
    Friend WithEvents Cod_Query_txt As ud_TextBox
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents Pdf_pb As PictureBox
    Friend WithEvents Excel_pb As PictureBox
    Friend WithEvents SumCol_pb As PictureBox
    Friend WithEvents SumLig_pb As PictureBox
    Friend WithEvents ChampsCalcule_pb As PictureBox
    Friend WithEvents InverserEntete_pb As PictureBox
    Friend WithEvents LoadPivot_pb As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents SavePivot_pb As PictureBox
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents pivot_Champs As TableLayoutPanel
    Friend WithEvents _Pnl As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents Critere As DataGridViewTextBoxColumn
    Friend WithEvents Lib_Critere As DataGridViewTextBoxColumn
    Friend WithEvents Valeur As DataGridViewTextBoxColumn
    Friend WithEvents Type As DataGridViewTextBoxColumn
End Class