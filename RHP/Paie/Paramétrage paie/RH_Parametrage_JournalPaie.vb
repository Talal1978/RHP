Imports System.ComponentModel

Public Class RH_Parametrage_JournalPaie
    Dim strEP As String = ""
    Dim dRw As DataGridViewRow = Nothing
    Dim WithEvents context_copy As New ContextMenuStrip
    Dim oMenu1, oMenu2, oMenu3, oMenu4, oMenu5, oMenu6, oMenu7 As New ToolStripMenuItem
    Sub Chargement()
        If Format.Items.Count = 0 Then Combo_GRD(Format)
    End Sub
    Private Sub RH_Parametrage_JournalPaie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chargement()
        With oMenu1
            .Text = "Insérer une ligne"
            .Image = My.Resources.insert
            AddHandler .Click, AddressOf InsererLig
        End With
        With oMenu2
            .Text = "Copier"
            .Image = My.Resources.Copier
            AddHandler .Click, AddressOf CopierLig
        End With
        With oMenu3
            .Text = "Couper"
            .Image = My.Resources.Couper
            AddHandler .Click, AddressOf CouperLig
        End With
        With oMenu4
            .Text = "Coller"
            .Image = My.Resources.paste
            AddHandler .Click, AddressOf CollerLig
        End With
        With oMenu5
            .Text = "Insérer la ligne copiée"
            .Image = My.Resources.login
            AddHandler .Click, AddressOf insererColler
        End With
        With oMenu6
            .Text = "Exporter le contenu vers Excel"
            .Image = My.Resources.icone_excel
            AddHandler .Click, AddressOf ToExcel
        End With
        With oMenu7
            .Text = "Supprimer la ligne"
            .Image = My.Resources.supprimerligne
            AddHandler .Click, AddressOf SupprimerLig
        End With

        context_copy.Items.AddRange(New System.Windows.Forms.ToolStripItem() {oMenu1, oMenu2, oMenu3, oMenu4, oMenu5, oMenu6, oMenu7})
        MyGrd.ContextMenuStrip = context_copy
    End Sub
    Sub Request()
        Chargement()
        MyGrd.Rows.Clear()
        If Cod_Plan_txt.Text = "" Then Return
        Dim SqlStr As String = ""
        Dim nb As Integer = CnExecuting("select count(*) from Rh_JournalPaie where Cod_Plan='" & Cod_Plan_txt.Text & "' and id_Societe=" & Societe.id_Societe).Fields(0).Value
        Dim C1, C2, C3, C4, C5 As Object
        If nb = 0 Then
            SqlStr = "declare @EP varchar(max), @EM varchar(max),@idSoc int
declare @t0 table (RowId int, Cod_Rubrique nvarchar(50),Abr_Rubrique nvarchar(50),Propriete nvarchar(50))
declare @t1 table (Lig int, Cod_Champs nvarchar(50), Format nvarchar(50))
set @idSoc=" & Societe.id_Societe & "
select @EP=Element_Paie,@EM = Element_Masques    
from RH_Param_Plan_Paie 
where id_Societe =@idSoc and Cod_Plan_Paie ='" & Cod_Plan_txt.Text & "'
insert into @t0
select ROW_NUMBER () over(order by indx) as RowId, items as Cod_Rubrique, Lib_Abr  Abr_Rubrique, 'Valeur' as Valeur from dbo.Splitfn(@EP,';') i
outer apply (select * from RH_Elements_Paie e where Cod_Function =i.items and isnull(nullif(id_Societe,-1),@idSoc)=@idSoc) r
where items not in (select items from dbo.Splitfn(@EM,';'))
insert into @t1 
select Row_number() over (order by RowId) as Lig,Valeur as Cod_Champs,'Float' as Format from Param_Rubriques where Nom_Controle='JournalPaie'  
select t1.Lig , t1.Cod_Champs , t0.Abr_Rubrique as Lib_Champs , t0.Cod_Rubrique , t0.Propriete, t1.Format   from @t1 t1 left join @t0 t0 on t1.Lig =t0.RowId 
order by RowId"
        Else
            SqlStr = "select Membre as Cod_Champs, isnull(Lib_Champs,'') as Lib_Champs,isnull(Cod_Rubrique,'') Cod_Rubrique,isnull(Propriete,'Valeur') as Propriete, isnull(Format,'Float') as Format
from Param_Rubriques 
outer apply (select * from Rh_JournalPaie p where Cod_Plan='" & Cod_Plan_txt.Text & "' and id_Societe=" & Societe.id_Societe & " and p.Cod_Champs=Membre)j
where Nom_Controle ='JournalPaie' order by Cod_Champs"
        End If
        Dim Tbl As DataTable = DATA_READER_GRD(SqlStr)
        With Tbl
            For i = 0 To .Rows.Count - 1
                C1 = IsNull(.Rows(i)("Cod_Champs"), "")
                C2 = IsNull(.Rows(i)("Lib_Champs"), "")
                C3 = IsNull(.Rows(i)("Cod_Rubrique"), "")
                C4 = IsNull(.Rows(i)("Propriete"), "")
                C5 = IsNull(.Rows(i)("Format"), "")
                MyGrd.Rows.Add(C1, C2, C3, C4, C5)
            Next
        End With
        strEP = FindLibelle("Element_Paie", "Cod_Plan_Paie", Cod_Plan_txt.Text, "RH_Param_Plan_Paie")
        If Not strEP.Trim = "" Then
            strEP = "'" & String.Join("','", strEP.Trim.Split({";"}, StringSplitOptions.RemoveEmptyEntries)) & "'"
        End If


    End Sub
    Sub Saving()
        If Cod_Plan_txt.Text = "" Then
            ShowMessageBox("Aucun plan choisi.", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
            Return
        End If
        Dim str As String = ""
        Dim strL As String = ""
        With MyGrd
            For i = 0 To .RowCount - 1
                If IsNull(.Item(Cod_Rubrique.Index, i).Value, "") <> "" And str = "" Then
                    str = .Item(Cod_Rubrique.Index, i).Value
                End If
                If IsNull(.Item(Lib_Champs.Index, i).Value, "") <> "" And strL = "" Then
                    strL = .Item(Lib_Champs.Index, i).Value
                End If
            Next
            If str = "" Or strL = "" Then
                ShowMessageBox("Intitulé ou Rubrique non renseigné.", "Vérification", MessageBoxButtons.OK, msgIcon.Error)
                Return
            End If
        End With
        Dim rs As New ADODB.Recordset
        With MyGrd
            For i = 0 To .RowCount - 1
                rs.Open("select * from Rh_JournalPaie where Cod_Plan='" & Cod_Plan_txt.Text & "' and id_Societe=" & Societe.id_Societe & " and Cod_Champs='" & .Item(Cod_Champs.Index, i).Value & "'", cn, 2, 2)
                If rs.EOF Then
                    rs.AddNew()
                    rs("id_Societe").Value = Societe.id_Societe
                    rs("Cod_Champs").Value = .Item(Cod_Champs.Index, i).Value
                    rs("Cod_Plan").Value = Cod_Plan_txt.Text
                Else
                    rs.Update()
                End If
                rs("Lib_Champs").Value = .Item(Lib_Champs.Index, i).Value
                rs("Cod_Rubrique").Value = .Item(Cod_Rubrique.Index, i).Value
                rs("Propriete").Value = IsNull(.Item(Propriete.Index, i).Value, "Valeur")
                rs("Format").Value = IsNull(.Item(Format.Index, i).Value, "Float")
                rs("RowId").Value = i
                rs.Update()
                rs.Close()
            Next
        End With
        ShowMessageBox("Enregistré")
        Request()
    End Sub
    Sub enregistrer()
        Saving()
    End Sub
    Private Sub MyGrd_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles MyGrd.CellMouseMove
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then Return
        With MyGrd
            If e.ColumnIndex = Cod_Rubrique.Index Then
                .Cursor = Cursors.Hand
            Else
                .Cursor = Cursors.Default
            End If
        End With
    End Sub
    Private Sub MyGrd_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles MyGrd.CellDoubleClick
        With MyGrd
            If e.ColumnIndex = Cod_Rubrique.Index Then
                Dim str As String = IsNull(.Item(e.ColumnIndex, e.RowIndex).Value, "")
                Dim strwhere As String = IIf(strEP = "", "1=1", "Cod_Function in (" & strEP & ")")
                Appel_Zoom1("MS007", .Item(e.ColumnIndex, e.RowIndex), Me, strwhere)
                If IsNull(.Item(e.ColumnIndex, e.RowIndex).Value, "") <> str Then
                    .Item(Lib_Champs.Index, e.RowIndex).Value = FindLibelle("Lib_Abr", "Cod_Function", .Item(e.ColumnIndex, e.RowIndex).Value, "RH_Elements_Paie")
                    .Item(Propriete.Index, e.RowIndex).Value = "Valeur"
                End If
            End If
        End With
    End Sub
    Private Sub Cod_Plan_Paie__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Cod_Plan_Paie_.LinkClicked
        Appel_Zoom1("MS012", Cod_Plan_txt, Me)
    End Sub

    Private Sub Cod_Plan_txt_TextChanged(sender As Object, e As EventArgs) Handles Cod_Plan_txt.TextChanged
        Lib_Plan_Paie_Text.Text = FindLibelle("Lib_Plan_Paie", "Cod_Plan_Paie", Cod_Plan_txt.Text, "RH_Param_Plan_Paie")
        Request()
    End Sub

    Sub Actualiser()
        If ShowMessageBox("Etes-vous sûr de vouloir réinitialiser le journal de la paie?", "RéInitialisation", MessageBoxButtons.OKCancel, msgIcon.Warning) = DialogResult.Cancel Then Return
        CnExecuting("delete from Rh_JournalPaie where Cod_Plan='" & Cod_Plan_txt.Text & "' and id_Societe=" & Societe.id_Societe)
        Request()
    End Sub

    Sub Decaler()
        If Cod_Plan_txt.Text = "" Then Return
        If MyGrd.Rows.Count = 0 Then Return
        CnExecuting("with Tbl as 
(select Cod_Champs , Lib_Champs , RowId , ROW_NUMBER() over(order by case when isnull(Cod_Rubrique,'')='' then 9999 else RowId end)-1 as Num from Rh_JournalPaie where id_Societe='" & Societe.id_Societe & "'),
Tbl0 as (select Cod_Champs , Lib_Champs , RowId as old,Num, 'C'+right('00'+convert(nvarchar(10),floor((Num / 3)+1)),2)+'L'+right('00'+convert(nvarchar(10),(Num % 3)+1),2) as NewChamps from Tbl)
update Rh_JournalPaie set Cod_Champs =newChamps,RowId =Num  from Tbl0 t where id_Societe='" & Societe.id_Societe & "' and t.old =RowId")
        Request()
    End Sub
    Sub InsererLig()
        With MyGrd
            Dim ind As Integer = .CurrentCell.RowIndex
            If ind < 0 Then Return
            If .RowCount = 0 Then Return
            If .RowCount = 39 Then .Rows.RemoveAt(38)
            .Rows.Insert(ind, "")
            MiseAjourChamps()
        End With
    End Sub
    Sub SupprimerLig()
        With MyGrd
            Dim ind As Integer = .CurrentCell.RowIndex
            If ind < 0 Then Return
            If .RowCount = 0 Then Return
            If .RowCount > ind Then .Rows.RemoveAt(ind)
            .Rows.Add("")
            MiseAjourChamps()
        End With
    End Sub
    Function CopierLig() As Integer
        Try

            With MyGrd
                If .CurrentRow Is Nothing Then Return -1
                Dim ind As Integer = .CurrentCell.RowIndex
                If ind < 0 Then Return -1
                If .RowCount = 0 Then Return -1
                If dRw Is Nothing Then
                    dRw = .CurrentRow.Clone
                End If
                For Each c As DataGridViewCell In .CurrentRow.Cells
                    dRw.Cells(c.ColumnIndex).Value = c.Value
                Next
                Return ind
            End With
        Catch ex As Exception
            Return -1
        End Try
    End Function
    Sub CouperLig()
        Try
            With MyGrd
                Dim ind As Integer = CopierLig()
                If ind = -1 Then Return
                .Rows.RemoveAt(ind)
                .Rows.Add("")
                MiseAjourChamps()
            End With
        Catch ex As Exception
            '   ErrorMsg(ex)
        End Try
    End Sub
    Sub CollerLig()
        Try
            With MyGrd
                If .CurrentRow Is Nothing Then Return
                Dim ind As Integer = .CurrentCell.RowIndex
                If ind < 0 Then Return
                If .RowCount = 0 Then Return
                If dRw.Cells.Count = 0 Then Return
                For Each c As DataGridViewCell In .CurrentRow.Cells
                    c.Value = dRw.Cells(c.ColumnIndex).Value
                Next
                dRw = Nothing
                MiseAjourChamps()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub insererColler()
        Try
            With MyGrd
                If dRw.Cells.Count = 0 Then Return
                Dim ind As Integer = .CurrentCell.RowIndex
                If ind < 0 Then Return
                If .RowCount = 0 Then Return
                If .RowCount = 39 Then .Rows.RemoveAt(38)
                .Rows.Insert(ind, dRw)
                dRw = Nothing
                MiseAjourChamps()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub MiseAjourChamps()
        Try
            With MyGrd
                For i = 0 To .RowCount - 1
                    .Item(Cod_Champs.Index, i).Value = "C" & Droite("00" & Math.Floor(i / 3 + 1), 2) & "L" & Droite("00" & ((i Mod 3) + 1), 2)
                Next
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub context_copy_Opening(sender As Object, e As CancelEventArgs) Handles context_copy.Opening

        With oMenu4
            .Enabled = Not (dRw Is Nothing)
        End With
        With oMenu5
            .Enabled = Not (dRw Is Nothing)
        End With

    End Sub
End Class