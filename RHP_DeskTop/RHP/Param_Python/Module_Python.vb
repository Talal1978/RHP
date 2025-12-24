Imports System.IO
Module Module_Python
    Function setPythonConn(pythonCode As String, showPwd As Boolean) As String
        Return "
import pyodbc 
from datetime import datetime
conn_str = 'DRIVER={ODBC Driver 17 for SQL Server};SERVER=" & Serveur.Replace("\", "\\") & ";DATABASE=" & DB & ";UID=" & IIf(showPwd, ConnectionSQL, "[user]") & ";PWD=" & IIf(showPwd, PWDConnectionSQL, "[sqlPassword]") & "'
conn = pyodbc.connect(conn_str)" & vbCrLf & pythonCode & vbCrLf & "conn.close()" & vbCrLf
    End Function
    Function executerCodePython(pythonCode As String, Message As System.Text.StringBuilder, Optional withConn As Boolean = True) As pyResult

        Try
            If withConn Then pythonCode = setPythonConn(pythonCode, True)
            Dim rg As New System.Text.RegularExpressions.Regex("(?<!\\)\""", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            ' Escape double quotes within the python code
            Dim escapedPythonCode As String = pythonCode.Replace("""", "\""")
            ' Prepare the command line argument
            Dim commandLineArg As String = "-c """ & escapedPythonCode & """"
            'Dim f As New Zoom_SqlText
            'With f
            '    .Sql_Text.Text = pythonCode
            '    .ShowDialog()
            'End With
            Dim psi As New ProcessStartInfo()
            psi.FileName = FindParam("chemin_python") ' Provide the full path if not in PATH
            psi.Arguments = commandLineArg
            psi.UseShellExecute = False
            psi.RedirectStandardOutput = True
            psi.RedirectStandardError = True
            psi.CreateNoWindow = True

            Dim process As New Process()
            process.StartInfo = psi
            process.Start()
            Dim noError As Boolean = True
            While Not process.StandardOutput.EndOfStream
                Message.AppendLine(process.StandardOutput.ReadLine())
                ' Optionally, handle the line for real-time output here
            End While
            While Not process.StandardError.EndOfStream
                Message.AppendLine(process.StandardError.ReadLine())  ' Corrected to read from StandardError
                noError = False
            End While
            process.WaitForExit()
            Return New pyResult With {.result = True, .CodeCompiled = pythonCode, .Erreur = ""}
        Catch ex As Exception
            Message.AppendLine(ex.Message)
            Return New pyResult With {.result = False, .CodeCompiled = pythonCode, .Erreur = ex.Message}
        End Try

    End Function
    Public Structure pyResult
        Public result As Boolean
        Public CodeCompiled As String
        Public Erreur As String
    End Structure

    Function codePythonChecker(pythonCode As String, Message As System.Text.StringBuilder) As pyResult
        Dim rnd As New Random
        If Not IO.Directory.Exists("TMP") Then IO.Directory.CreateDirectory("TMP")
        Dim rndv = rnd.Next(12000, 1569221)
        Dim tmp = My.Application.Info.DirectoryPath.Replace("\", "/") & "/TMP/py_" & rndv & ".py"
        Dim sw As New IO.StreamWriter(tmp, True)
        sw.Write(setPythonConn(pythonCode, True))
        sw.Close()
        Dim pythonExePath As String = FindParam("chemin_python")
        If Not IO.File.Exists(pythonExePath) Then
            pythonExePath = "python.exe"
        End If
        ' Assuming pylint is installed in the same Python environment,
        ' its path would typically be in the Scripts folder.
        Dim pylintPath As String = Path.Combine(Path.GetDirectoryName(pythonExePath), "Scripts\pylint.exe")
        ' Check if the pylint executable exists at the computed path
        If Not File.Exists(pylintPath) Then
            pylintPath = "pylint"
        End If
        pythonCode = $"
import subprocess, sys

def codeChecking():
    result = subprocess.run(
        [r'{pylintPath}',
        '--disable=C0301,C0303,W0311,C0103,C0102,C0114,C0115,C0116,C0411,I1101,C0410,W0611',
        r'{tmp}'],
        stdout=subprocess.PIPE,
        stderr=subprocess.PIPE,
        text=True
    )

    if result.returncode in (0, 4, 8, 16, 32):
        print('ok')
    else:
        raise ValueError(result.stdout + '\n' + result.stderr)

codeChecking()
"
        Dim rsl = executerCodePython(pythonCode, Message, False)
        If IO.File.Exists(tmp) Then IO.File.Delete(tmp)
        Return rsl
    End Function
    Function TesterPython(Message As System.Text.StringBuilder) As pyResult
        Dim codeTest As String =
    "import sys
print('Python OK')
print('Version :', sys.version, flush=True)
"

        ' Ici on n’utilise PAS la connexion SQL ni pyodbc
        Return executerCodePython(codeTest, Message, False)
    End Function
End Module
