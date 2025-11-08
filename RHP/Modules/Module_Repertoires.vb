Module Module_Repertoires
    Sub CopierRepertoires(ByVal Src As String, ByVal Dst As String)
        Dim Files As String()

        If Dst(Dst.Length - 1) <> IO.Path.DirectorySeparatorChar Then
            Dst += IO.Path.DirectorySeparatorChar
        End If
        If Not IO.Directory.Exists(Dst) Then
            IO.Directory.CreateDirectory(Dst)
        End If

        Files = IO.Directory.GetFileSystemEntries(Src)

        For Each Element As String In Files
            ' Sub directories
            If IO.Directory.Exists(Element) Then
                CopierRepertoires(Element, Dst & IO.Path.GetFileName(Element))
            Else
                ' Files in directory
                IO.File.Copy(Element, Dst & IO.Path.GetFileName(Element), True)
            End If
        Next

    End Sub
    Public Function DirSize(ByVal d As IO.DirectoryInfo) As Long
        Dim Size As Long = 0
        ' File sizes
        Dim fis As IO.FileInfo() = d.GetFiles()
        For Each fi As IO.FileInfo In fis
            Size += fi.Length
        Next
        ' Subdirectory sizes
        Dim dis As IO.DirectoryInfo() = d.GetDirectories()
        For Each di As IO.DirectoryInfo In dis
            Size += DirSize(di)
        Next
        Return (Size)
    End Function

    Sub OngletColore(ByVal sender As Object)
        Dim e As System.Windows.Forms.DrawItemEventArgs = Nothing
        Dim tabControl As System.Windows.Forms.TabControl = DirectCast(sender, System.Windows.Forms.TabControl)
        tabControl.DrawMode = TabDrawMode.OwnerDrawFixed
        Dim brushBack As Brush
        Dim brushFore As Brush
        If e.Index = tabControl.SelectedIndex Then
            brushBack = New System.Drawing.SolidBrush(tabControl.TabPages(e.Index).BackColor)
            brushFore = New SolidBrush(tabControl.TabPages(e.Index).ForeColor)
        Else
            brushBack = New SolidBrush(Color.FromKnownColor(KnownColor.Control))
            brushFore = New SolidBrush(tabControl.TabPages(e.Index).ForeColor)
        End If
        e.Graphics.FillRectangle(brushBack, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
        e.Graphics.DrawString(tabControl.TabPages(e.Index).Text, tabControl.TabPages(e.Index).Font, brushFore, CSng(e.Bounds.X + 3), CSng(e.Bounds.Y + 3))
        brushBack.Dispose()
        brushFore.Dispose()
    End Sub


End Module
