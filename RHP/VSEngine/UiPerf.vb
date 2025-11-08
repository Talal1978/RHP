Imports System.Reflection

Module UiPerf
    <System.Runtime.CompilerServices.Extension()>
    Public Sub EnableDoubleBuffer(Of T As Control)(c As T)
        Dim pi = GetType(Control).GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        If pi IsNot Nothing Then pi.SetValue(c, True, Nothing)
    End Sub

    Public Sub BatchLayout(container As Control, build As Action)
        container.SuspendLayout()
        Try
            build()
        Finally
            container.ResumeLayout(True)
        End Try
    End Sub
End Module

