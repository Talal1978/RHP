Imports System.Data.OleDb
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Agent_Import
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
        Me.components = New System.ComponentModel.Container()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.pnlChamps = New System.Windows.Forms.Panel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActualiserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Actualiser_pb = New System.Windows.Forms.PictureBox()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.New_pb = New System.Windows.Forms.PictureBox()
        Me.Affect_pb = New System.Windows.Forms.PictureBox()
        Me.Modele_pb = New System.Windows.Forms.PictureBox()
        Me.Importer_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.ExcelSheets_cbo = New RHP.ud_ComboBox()
        Me.ControlContainerItem2 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.BKW_ChargerFeuilleExcel = New System.ComponentModel.BackgroundWorker()
        Me.BKW_Import = New System.ComponentModel.BackgroundWorker()
        Me.oTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Personnal_pnl.SuspendLayout()
        CType(Me.Actualiser_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.New_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Affect_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Modele_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Importer_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 46)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlChamps)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SplitContainer1.Size = New System.Drawing.Size(1391, 730)
        Me.SplitContainer1.SplitterDistance = 182
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 173
        '
        'pnlChamps
        '
        Me.pnlChamps.AutoScroll = True
        Me.pnlChamps.BackColor = System.Drawing.Color.White
        Me.pnlChamps.ContextMenuStrip = Me.ContextMenuStrip1
        Me.pnlChamps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlChamps.Location = New System.Drawing.Point(0, 0)
        Me.pnlChamps.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlChamps.Name = "pnlChamps"
        Me.pnlChamps.Size = New System.Drawing.Size(1391, 182)
        Me.pnlChamps.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualiserToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(158, 28)
        '
        'ActualiserToolStripMenuItem
        '
        Me.ActualiserToolStripMenuItem.Name = "ActualiserToolStripMenuItem"
        Me.ActualiserToolStripMenuItem.Size = New System.Drawing.Size(157, 24)
        Me.ActualiserToolStripMenuItem.Text = "Réorganiser"
        '
        'Personnal_pnl
        '
        Me.Personnal_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Personnal_pnl.ColumnCount = 9
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.Personnal_pnl.Controls.Add(Me.Actualiser_pb, 2, 0)
        Me.Personnal_pnl.Controls.Add(Me.Save_pb, 1, 0)
        Me.Personnal_pnl.Controls.Add(Me.New_pb, 0, 0)
        Me.Personnal_pnl.Controls.Add(Me.Affect_pb, 4, 0)
        Me.Personnal_pnl.Controls.Add(Me.Modele_pb, 5, 0)
        Me.Personnal_pnl.Controls.Add(Me.Importer_pb, 6, 0)
        Me.Personnal_pnl.Controls.Add(Me.Close_pb, 8, 0)
        Me.Personnal_pnl.Controls.Add(Me.ExcelSheets_cbo, 7, 0)
        Me.Personnal_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Personnal_pnl.Location = New System.Drawing.Point(2, 2)
        Me.Personnal_pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(1391, 44)
        Me.Personnal_pnl.TabIndex = 175
        '
        'Actualiser_pb
        '
        Me.Actualiser_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Actualiser_pb.Image = Global.RHP.My.Resources.Resources.btn_request_w
        Me.Actualiser_pb.InitialImage = Nothing
        Me.Actualiser_pb.Location = New System.Drawing.Point(80, 4)
        Me.Actualiser_pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Actualiser_pb.Name = "Actualiser_pb"
        Me.Actualiser_pb.Size = New System.Drawing.Size(30, 36)
        Me.Actualiser_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SuperTooltip1.SetSuperTooltip(Me.Actualiser_pb, New DevComponents.DotNetBar.SuperTooltipInfo("Importation", "", "Raffraichir", Global.RHP.My.Resources.Resources.btn_request, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.Actualiser_pb.TabIndex = 5
        Me.Actualiser_pb.TabStop = False
        '
        'Save_pb
        '
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save_w
        Me.Save_pb.InitialImage = Nothing
        Me.Save_pb.Location = New System.Drawing.Point(42, 4)
        Me.Save_pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(30, 36)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SuperTooltip1.SetSuperTooltip(Me.Save_pb, New DevComponents.DotNetBar.SuperTooltipInfo("Importation", "", "Lancer l'importation", Global.RHP.My.Resources.Resources.btn_save, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.Save_pb.TabIndex = 4
        Me.Save_pb.TabStop = False
        '
        'New_pb
        '
        Me.New_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.New_pb.Image = Global.RHP.My.Resources.Resources.btn_add_w1
        Me.New_pb.InitialImage = Nothing
        Me.New_pb.Location = New System.Drawing.Point(4, 4)
        Me.New_pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.New_pb.Name = "New_pb"
        Me.New_pb.Size = New System.Drawing.Size(30, 36)
        Me.New_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SuperTooltip1.SetSuperTooltip(Me.New_pb, New DevComponents.DotNetBar.SuperTooltipInfo("Importation", "", "Nouveau", Global.RHP.My.Resources.Resources.btn_add, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.New_pb.TabIndex = 3
        Me.New_pb.TabStop = False
        '
        'Affect_pb
        '
        Me.Affect_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Affect_pb.Image = Global.RHP.My.Resources.Resources.btn_affect_w
        Me.Affect_pb.InitialImage = Nothing
        Me.Affect_pb.Location = New System.Drawing.Point(156, 4)
        Me.Affect_pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Affect_pb.Name = "Affect_pb"
        Me.Affect_pb.Size = New System.Drawing.Size(30, 36)
        Me.Affect_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SuperTooltip1.SetSuperTooltip(Me.Affect_pb, New DevComponents.DotNetBar.SuperTooltipInfo("Importation", "", "Affectation automatique des champs", Global.RHP.My.Resources.Resources.btn_affect, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.Affect_pb.TabIndex = 6
        Me.Affect_pb.TabStop = False
        '
        'Modele_pb
        '
        Me.Modele_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Modele_pb.Image = Global.RHP.My.Resources.Resources.btn_model_excel_w
        Me.Modele_pb.InitialImage = Nothing
        Me.Modele_pb.Location = New System.Drawing.Point(194, 4)
        Me.Modele_pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Modele_pb.Name = "Modele_pb"
        Me.Modele_pb.Size = New System.Drawing.Size(30, 36)
        Me.Modele_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SuperTooltip1.SetSuperTooltip(Me.Modele_pb, New DevComponents.DotNetBar.SuperTooltipInfo("Importation", "", "Exporter le modèle d'import Excel", Global.RHP.My.Resources.Resources.btn_model_excel, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.Modele_pb.TabIndex = 6
        Me.Modele_pb.TabStop = False
        '
        'Importer_pb
        '
        Me.Importer_pb.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Importer_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Importer_pb.Image = Global.RHP.My.Resources.Resources.btn_import_w
        Me.Importer_pb.InitialImage = Nothing
        Me.Importer_pb.Location = New System.Drawing.Point(319, 4)
        Me.Importer_pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Importer_pb.Name = "Importer_pb"
        Me.Importer_pb.Size = New System.Drawing.Size(30, 36)
        Me.Importer_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SuperTooltip1.SetSuperTooltip(Me.Importer_pb, New DevComponents.DotNetBar.SuperTooltipInfo("Importation", "", "Charger le fichier Excel", Global.RHP.My.Resources.Resources.btn_import, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.Importer_pb.TabIndex = 6
        Me.Importer_pb.TabStop = False
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close_w
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(1357, 4)
        Me.Close_pb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(30, 36)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SuperTooltip1.SetSuperTooltip(Me.Close_pb, New DevComponents.DotNetBar.SuperTooltipInfo("Importation", "", "Fermer", Global.RHP.My.Resources.Resources.btn_close, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.Close_pb.TabIndex = 8
        Me.Close_pb.TabStop = False
        '
        'ExcelSheets_cbo
        '
        Me.ExcelSheets_cbo.DataSource = Nothing
        Me.ExcelSheets_cbo.DisplayMember = ""
        Me.ExcelSheets_cbo.DroppedDown = False
        Me.ExcelSheets_cbo.Location = New System.Drawing.Point(358, 5)
        Me.ExcelSheets_cbo.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ExcelSheets_cbo.Name = "ExcelSheets_cbo"
        Me.ExcelSheets_cbo.SelectedIndex = -1
        Me.ExcelSheets_cbo.SelectedItem = Nothing
        Me.ExcelSheets_cbo.SelectedValue = Nothing
        Me.ExcelSheets_cbo.Size = New System.Drawing.Size(432, 31)
        Me.ExcelSheets_cbo.TabIndex = 7
        Me.ExcelSheets_cbo.ValueMember = ""
        '
        'ControlContainerItem2
        '
        Me.ControlContainerItem2.AllowItemResize = False
        Me.ControlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem2.Name = "ControlContainerItem2"
        '
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = False
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
        '
        'BKW_ChargerFeuilleExcel
        '
        Me.BKW_ChargerFeuilleExcel.WorkerReportsProgress = True
        Me.BKW_ChargerFeuilleExcel.WorkerSupportsCancellation = True
        '
        'BKW_Import
        '
        Me.BKW_Import.WorkerReportsProgress = True
        Me.BKW_Import.WorkerSupportsCancellation = True
        '
        'oTimer
        '
        '
        'RH_Agent_Import
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1395, 778)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Personnal_pnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "RH_Agent_Import"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Importation des fiches agent"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Personnal_pnl.ResumeLayout(False)
        CType(Me.Actualiser_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Save_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.New_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Affect_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Modele_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Importer_pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Close_pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ControlContainerItem2 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents pnlChamps As Panel
    Friend WithEvents BKW_ChargerFeuilleExcel As BackgroundWorker
    Friend WithEvents BKW_Import As BackgroundWorker
    Friend WithEvents oTimer As Timer
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ActualiserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Personnal_pnl As TableLayoutPanel
    Friend WithEvents Actualiser_pb As PictureBox
    Friend WithEvents Save_pb As PictureBox
    Friend WithEvents New_pb As PictureBox
    Friend WithEvents Affect_pb As PictureBox
    Friend WithEvents Modele_pb As PictureBox
    Friend WithEvents Importer_pb As PictureBox
    Friend WithEvents Close_pb As PictureBox
    Friend WithEvents ExcelSheets_cbo As ud_ComboBox
End Class
