Imports System.Data.OleDb
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RH_Conge_Provision_Import_EV
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
    Private Shared Sub ENCAddToList(ByVal value As Object)
        Dim list As List(Of WeakReference) = RH_Conge_Provision_Import_EV.ENCList
        SyncLock list
            If (RH_Conge_Provision_Import_EV.ENCList.Count = RH_Conge_Provision_Import_EV.ENCList.Capacity) Then
                Dim index As Integer = 0
                Dim num3 As Integer = (RH_Conge_Provision_Import_EV.ENCList.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num3)
                    Dim reference As WeakReference = RH_Conge_Provision_Import_EV.ENCList.Item(i)
                    If reference.IsAlive Then
                        If (i <> index) Then
                            RH_Conge_Provision_Import_EV.ENCList.Item(index) = RH_Conge_Provision_Import_EV.ENCList.Item(i)
                        End If
                        index += 1
                    End If
                    i += 1
                Loop
                RH_Conge_Provision_Import_EV.ENCList.RemoveRange(index, (RH_Conge_Provision_Import_EV.ENCList.Count - index))
                RH_Conge_Provision_Import_EV.ENCList.Capacity = RH_Conge_Provision_Import_EV.ENCList.Count
            End If
            RH_Conge_Provision_Import_EV.ENCList.Add(New WeakReference(RuntimeHelpers.GetObjectValue(value)))
        End SyncLock
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
        Me.ControlContainerItem2 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.BKW_ChargerFeuilleExcel = New System.ComponentModel.BackgroundWorker()
        Me.BKW_Import = New System.ComponentModel.BackgroundWorker()
        Me.oTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.Personnal_pnl = New System.Windows.Forms.TableLayoutPanel()
        Me.Actualiser_pb = New System.Windows.Forms.PictureBox()
        Me.Save_pb = New System.Windows.Forms.PictureBox()
        Me.New_pb = New System.Windows.Forms.PictureBox()
        Me.Affect_pb = New System.Windows.Forms.PictureBox()
        Me.Modele_pb = New System.Windows.Forms.PictureBox()
        Me.Importer_pb = New System.Windows.Forms.PictureBox()
        Me.Close_pb = New System.Windows.Forms.PictureBox()
        Me.ExcelSheets_cbo = New RHP.ud_ComboBox()
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
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 37)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(1112, 583)
        Me.SplitContainer1.SplitterDistance = 58
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
        Me.pnlChamps.Name = "pnlChamps"
        Me.pnlChamps.Size = New System.Drawing.Size(1112, 58)
        Me.pnlChamps.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualiserToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(137, 26)
        '
        'ActualiserToolStripMenuItem
        '
        Me.ActualiserToolStripMenuItem.Name = "ActualiserToolStripMenuItem"
        Me.ActualiserToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ActualiserToolStripMenuItem.Text = "Réorganiser"
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
        'Personnal_pnl
        '
        Me.Personnal_pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Personnal_pnl.ColumnCount = 9
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
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
        Me.Personnal_pnl.Name = "Personnal_pnl"
        Me.Personnal_pnl.RowCount = 1
        Me.Personnal_pnl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Personnal_pnl.Size = New System.Drawing.Size(1112, 35)
        Me.Personnal_pnl.TabIndex = 174
        '
        'Actualiser_pb
        '
        Me.Actualiser_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Actualiser_pb.Image = Global.RHP.My.Resources.Resources.btn_request_w
        Me.Actualiser_pb.InitialImage = Nothing
        Me.Actualiser_pb.Location = New System.Drawing.Point(63, 3)
        Me.Actualiser_pb.Name = "Actualiser_pb"
        Me.Actualiser_pb.Size = New System.Drawing.Size(24, 29)
        Me.Actualiser_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Actualiser_pb.TabIndex = 5
        Me.Actualiser_pb.TabStop = False
        '
        'Save_pb
        '
        Me.Save_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_pb.Image = Global.RHP.My.Resources.Resources.btn_save_w
        Me.Save_pb.InitialImage = Nothing
        Me.Save_pb.Location = New System.Drawing.Point(33, 3)
        Me.Save_pb.Name = "Save_pb"
        Me.Save_pb.Size = New System.Drawing.Size(24, 29)
        Me.Save_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Save_pb.TabIndex = 4
        Me.Save_pb.TabStop = False
        '
        'New_pb
        '
        Me.New_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.New_pb.Image = Global.RHP.My.Resources.Resources.btn_add_w
        Me.New_pb.InitialImage = Nothing
        Me.New_pb.Location = New System.Drawing.Point(3, 3)
        Me.New_pb.Name = "New_pb"
        Me.New_pb.Size = New System.Drawing.Size(24, 29)
        Me.New_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.New_pb.TabIndex = 3
        Me.New_pb.TabStop = False
        '
        'Affect_pb
        '
        Me.Affect_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Affect_pb.Image = Global.RHP.My.Resources.Resources.btn_affect_w
        Me.Affect_pb.InitialImage = Nothing
        Me.Affect_pb.Location = New System.Drawing.Point(123, 3)
        Me.Affect_pb.Name = "Affect_pb"
        Me.Affect_pb.Size = New System.Drawing.Size(24, 29)
        Me.Affect_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Affect_pb.TabIndex = 6
        Me.Affect_pb.TabStop = False
        '
        'Modele_pb
        '
        Me.Modele_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Modele_pb.Image = Global.RHP.My.Resources.Resources.btn_model_excel_w
        Me.Modele_pb.InitialImage = Nothing
        Me.Modele_pb.Location = New System.Drawing.Point(153, 3)
        Me.Modele_pb.Name = "Modele_pb"
        Me.Modele_pb.Size = New System.Drawing.Size(24, 29)
        Me.Modele_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Modele_pb.TabIndex = 6
        Me.Modele_pb.TabStop = False
        '
        'Importer_pb
        '
        Me.Importer_pb.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Importer_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Importer_pb.Image = Global.RHP.My.Resources.Resources.btn_import_w
        Me.Importer_pb.InitialImage = Nothing
        Me.Importer_pb.Location = New System.Drawing.Point(253, 3)
        Me.Importer_pb.Name = "Importer_pb"
        Me.Importer_pb.Size = New System.Drawing.Size(24, 29)
        Me.Importer_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Importer_pb.TabIndex = 6
        Me.Importer_pb.TabStop = False
        '
        'Close_pb
        '
        Me.Close_pb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Close_pb.Image = Global.RHP.My.Resources.Resources.btn_close_w
        Me.Close_pb.InitialImage = Nothing
        Me.Close_pb.Location = New System.Drawing.Point(1085, 3)
        Me.Close_pb.Name = "Close_pb"
        Me.Close_pb.Size = New System.Drawing.Size(24, 29)
        Me.Close_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Close_pb.TabIndex = 8
        Me.Close_pb.TabStop = False
        '
        'ExcelSheets_cbo
        '
        Me.ExcelSheets_cbo.DataSource = Nothing
        Me.ExcelSheets_cbo.DisplayMember = ""
        Me.ExcelSheets_cbo.DroppedDown = True
        Me.ExcelSheets_cbo.Location = New System.Drawing.Point(283, 3)
        Me.ExcelSheets_cbo.Name = "ExcelSheets_cbo"
        Me.ExcelSheets_cbo.SelectedIndex = -1
        Me.ExcelSheets_cbo.SelectedItem = Nothing
        Me.ExcelSheets_cbo.SelectedValue = Nothing
        Me.ExcelSheets_cbo.Size = New System.Drawing.Size(346, 25)
        Me.ExcelSheets_cbo.TabIndex = 7
        Me.ExcelSheets_cbo.ValueMember = ""
        '
        'RH_Conge_Provision_Import_EV
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1116, 622)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Personnal_pnl)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RH_Conge_Provision_Import_EV"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ECR"
        Me.Text = "Import des congés"
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

    Private Shared ENCList As List(Of WeakReference) = New List(Of WeakReference)
    '<accessedThroughProperty("lblCompte")> 
    '<accessedThroughProperty("lblCredit")> 
    '<accessedThroughProperty("lblDebit")> 
    '<accessedThroughProperty("lblH1")> 
    '<accessedThroughProperty("lblH2")> 
    '<accessedThroughProperty("lblLibelle")> 
    '<accessedThroughProperty("lblSolde")> 
    '<accessedThroughProperty("lblV1")> 
    '<accessedThroughProperty("lblV2")> 
    '<accessedThroughProperty("OFDialog")> 
    Private WithEvents OFDialog As OpenFileDialog
    Private blnImport As Boolean
    Private blnLoad As Boolean
    Private blnSolde As Boolean
    Private CGrille As String()
    Private CoinX As Integer
    Private CoinY As Integer
    'Private  components As IContainer
    Private CompteWidth As Integer
    Private CreditWidth As Integer
    Private DebitWidth As Integer
    Private Extention As String
    Private FeuilleName As String
    Private FichierExp As String
    Private Gauche As Integer()
    Private HPanl As Integer
    Private HSepar As Integer
    Private ICompte As SByte
    Private ICredit As SByte
    Private IDebit As SByte
    Private Ilibelle As SByte
    Private ISolde As SByte
    Private LargCol As Integer()
    Private lblT As Label()
    Private leDsXls As Integer
    Private LibelleWidth As Integer
    Private Lmax As Integer
    Private Lmin As Integer
    Private Messag As String
    Private NbCol As Byte
    Private pnlT As Panel()
    Private SitStade As Byte
    Private SoldeWidth As Integer
    Private TGrille As String()
    Private Tmax As Integer
    Private Tmin As Integer
    Private WPanl As Integer
    Private WSepar As Integer
    Private XyCompte As Point
    Private XyCredit As Point
    Private XyDebit As Point
    Private XyLibelle As Point
    Private XySolde As Point
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
