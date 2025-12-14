Imports System.Threading
Public Class Sys_GenerationGlobale
    Dim MenuTbl As New DataTable
    Dim TreeTbl As New DataTable
    Dim ControlTbl As New DataTable
    Dim LblTbl As New DataTable
    Dim oRow() As DataRow
    Friend Flag_Maj As Integer = 0
    Dim WithEvents oTimer As New System.Windows.Forms.Timer
    Dim strState As String = ""
    Dim workerThread As Thread
    Class STD_Btn
        Sub New()

        End Sub
        Public Name As String
        Public tooltip As String
        Public Text As String
        Public Tag As String
    End Class
    Sub ListControlGereSecurity(ByVal frm As Object, ByVal oForm As String)

        Try

            For Each c As Object In frm.Controls
                strState = frm.FindForm.Name & "\" & frm.Name
                If c.GetType.Name = "TreeView" Then
                    For Each oNode As TreeNode In CType(c, TreeView).Nodes
                        GetMenuParent(oNode)
                    Next
                ElseIf c.GetType.Name = "Bar" Then
                    For Each it As Object In CType(c, DevComponents.DotNetBar.Bar).Items
                        SavingControles(it, oForm, "ToolTip")
                    Next
                Else

                    SavingControles(c, oForm)

                End If
            Next
        Catch ex As Exception
            ErrorMsg(ex)
        End Try
    End Sub
    Sub SavingControles(ByVal c As Object, ByVal oform As String, Optional ByVal oText As String = "Text")
        Dim rs, rs3 As New ADODB.Recordset
        '  If c.Tag = "SN" Or c.Tag = "SC" Or c.Tag = "NC" Or c.Tag = "NN" Then


        rs.Open("Select * From Controle_Menu_Avance where Name_Ecran='" & oform & "' and name_Controle='" & c.Name & "'", cn, 2, 2)
        If rs.EOF Then
            rs.AddNew()
        Else
            rs.Update()
        End If
        rs("Name_Ecran").Value = oform
        rs("Name_Controle").Value = c.Name

        If c.GetType.Name = "ButtonX" Then
            rs("Text_Controle").Value = c.tooltip
        ElseIf oText = "Text" Then
            rs("Text_Controle").Value = Gauche(c.Text, 100)
        ElseIf c.GetType.Name = "ButtonItem" Then

            If c.image Is Nothing Then
                rs("Text_Controle").Value = c.Text
            Else
                rs("Text_Controle").Value = c.tooltip
            End If
        Else
            rs("Text_Controle").Value = c.tooltip

        End If

        rs("Typ_Controle").Value = c.GetType.Name
        rs("Source").Value = "S"
        rs("Typ_Security").Value = IIf(c.Tag = "SN" Or c.Tag = "SC" Or c.Tag = "NC" Or c.Tag = "NN", c.tag, "")
        rs("Gere_Security").Value = IIf(Gauche(c.Tag, 1) = "S", "True", "False")
        rs("Flag_Maj").Value = Flag_Maj

        rs.Update()
        rs.Close()


        If c.GetType.Name = "LinkLabel" Or c.GetType.Name = "Label" Then
            rs3.Open("select * from Controle_Def_Label where Name_Ecran='" & oform & "' and Name_Label='" & c.Name & "'", cn, 2, 2)
            If rs3.EOF Then
                rs3.AddNew()
            Else
                rs3.Update()
            End If
            rs3("Name_Ecran").Value = oform
            rs3("Name_Label").Value = c.Name
            rs3("Text_Label_Origine").Value = Gauche(c.Text, 150)
            rs3("Typ_Label").Value = c.GetType.Name
            rs3.Update()
            rs3.Close()
        End If

        If Not TryCast(c, Control) Is Nothing Then
            If TryCast(c, Control).HasChildren And TypeOf c IsNot UserControl Then ListControlGereSecurity(c, oform)
        End If

    End Sub
    Sub GetMenuParent(ByVal oNode As TreeNode)

        If oNode.Nodes.Count = 0 Then
            CnExecuting("Update Controle_Menu set Menu_Parent='" & oNode.TreeView.FindForm.Name & "' where Name_Ecran='" & oNode.Name & "'")
        Else
            For Each aNode As TreeNode In oNode.Nodes
                GetMenuParent(aNode)
            Next
        End If

    End Sub
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ud_button1.Click

        Annuler_ud.Enabled = False
        Dim Rnd As New Random
        Flag_Maj = Rnd.Next(19049, 1905678)
        oTimer.Start()
        Lbl1.Text = "Traitement en cours.  Merci de patienter..."
        Lbl1.Refresh()
        ProgressBar1.Visible = True
        ' Créer un thread STA
        workerThread = New Thread(AddressOf ProcessForms)
        workerThread.SetApartmentState(ApartmentState.STA)
        workerThread.IsBackground = True
        workerThread.Start()
    End Sub

    Sub Sys_GenerationGlobale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MenuTbl = DATA_READER_GRD("select * from Controle_Menu")
        TreeTbl = DATA_READER_GRD("select * from Controle_TreeView")
        ControlTbl = DATA_READER_GRD("select * from Controle_Menu_Avance")
        LblTbl = DATA_READER_GRD("select * from Controle_Def_Label")
        With oTimer
            .Interval = 200
            AddHandler .Tick, Sub()
                                  With Lbl
                                      .Text = strState
                                      .Refresh()
                                      Me.Refresh()
                                  End With
                                  ProgressBar1.Refresh()
                              End Sub
        End With
    End Sub

    Private Sub Ud_button2_Load(sender As Object, e As EventArgs) Handles Annuler_ud.Click
        Me.Close()
    End Sub

    Sub ProcessForms()
        Dim a As Reflection.Assembly = System.Reflection.Assembly.GetAssembly(Me.GetType)
        Dim rs1 As New ADODB.Recordset
        Try
            For Each T As Type In a.GetTypes
                If GetType(Ecran).IsAssignableFrom(T) Then
                    Dim Frm = CType(Activator.CreateInstance(T), Ecran)
                    Frm.SuspendLayout()
                    If Frm.Tag = "ECR" Then
                        strState = Frm.Text & "(" & Frm.Name & ")"
                        rs1.Open("select * from Controle_Menu where Name_Ecran='" & Frm.Name & "'", cn, 2, 2)
                        If rs1.EOF Then
                            rs1.AddNew()
                        Else
                            rs1.Update()
                        End If
                        rs1("Name_Ecran").Value = Frm.Name
                        rs1("Text_Ecran").Value = Frm.Text
                        rs1("Typ_Ecran").Value = Frm.Tag
                        rs1("Flag_Maj").Value = Flag_Maj

                        rs1.Update()
                        rs1.Close()

                        'Insertion dans Controle_TreeView
                        rs1.Open("select * from Controle_TreeView where Name_Ecran='" & Frm.Name & "'", cn, 2, 2)
                        If rs1.EOF Then
                            rs1.AddNew()
                        Else
                            rs1.Update()
                        End If
                        rs1("Name_Ecran").Value = Frm.Name
                        rs1("Text_Ecran").Value = Frm.Text
                        rs1("Typ_Ecran").Value = Frm.Tag
                        rs1("Tag").Value = "Form"
                        rs1("Flag_Maj").Value = Flag_Maj

                        rs1.Update()
                        rs1.Close()

                        'Insertion des Contrôles Child de Chaque Form

                        ListControlGereSecurity(Frm, Frm.Name)

                        'Insertion des buttons des écrans
                        Dim tbl As DataTable = DATA_READER_GRD($"select * from Controle_Def_Ecran_Button where Name_Ecran='{Frm.Name}' and isnull(Typ_Security,'')!=''")
                        With tbl
                            For i = 0 To .Rows.Count - 1
                                Dim btn As New STD_Btn
                                btn.Name = .Rows(i)("Cod_Button")
                                btn.Text = .Rows(i)("Lib_Button")
                                btn.tooltip = btn.Text
                                btn.Tag = .Rows(i)("Typ_Security")
                                SavingControles(btn, Frm.Name, btn.Text)
                            Next
                        End With

                        If Frm IsNot Nothing Then
                            Frm.Dispose()
                        End If
                    End If
                End If
            Next
            Me.Invoke(Sub() FinalizeProcess())
        Catch ex As Exception
            Me.Invoke(Sub() ErrorMsg(ex))
        End Try
    End Sub

    Sub FinalizeProcess()
        strState = "Mise à jour des images..."
        strState = "Supression des écrans obsolètes..."

        CnExecuting("Delete from Controle_Menu where Typ_Ecran in ('ECR') and   isnull(Flag_Maj,0)<>'" & Flag_Maj & "'")
        CnExecuting("delete from Controle_Menu_Avance where  isnull(Flag_Maj,0)<>'" & Flag_Maj & "'  and isnull(Source,'')<>'U'")
        CnExecuting("Delete from Controle_TreeView where Typ_Ecran in ('ECR') and   isnull(Flag_Maj,0)<>'" & Flag_Maj & "'")
        CnExecuting("delete from Controle_Menu where Typ_Ecran in ('RPT') and Name_Ecran not in (select Cod_Report from Param_Mod_Edition)")
        CnExecuting("delete from Controle_Menu where Typ_Ecran in ('QRY') and Name_Ecran not in (select Cod_Query from Param_Query)")
        InitialisationGlobale()
        Me.Close()
    End Sub

End Class