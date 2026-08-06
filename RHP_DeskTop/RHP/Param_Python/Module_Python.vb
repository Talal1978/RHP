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
        Dim tmp As String = ""
        Try
            If withConn Then pythonCode = setPythonConn(pythonCode, True)
            ' Ecrire le code dans un fichier temporaire : evite la limite de 32767 caracteres
            ' de la ligne de commande (-c) et les problemes d'echappement des guillemets
            If Not IO.Directory.Exists("TMP") Then IO.Directory.CreateDirectory("TMP")
            Dim rnd As New Random
            tmp = IO.Path.Combine(My.Application.Info.DirectoryPath, "TMP\py_exec_" & rnd.Next(12000, 1569221) & ".py")
            IO.File.WriteAllText(tmp, pythonCode, New System.Text.UTF8Encoding(False))
            Dim psi As New ProcessStartInfo()
            psi.FileName = FindParam("chemin_python") ' Provide the full path if not in PATH
            If Not IO.File.Exists(psi.FileName) Then
                psi.FileName = "python.exe"
            End If
            psi.Arguments = """" & tmp & """"
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
            If IO.File.Exists(tmp) Then IO.File.Delete(tmp)
            Return New pyResult With {.result = True, .CodeCompiled = pythonCode, .Erreur = ""}
        Catch ex As Exception
            If tmp <> "" AndAlso IO.File.Exists(tmp) Then IO.File.Delete(tmp)
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
    Sub RafraichirFicheAgent(strMsg As System.Text.StringBuilder)
        ' Rafraichit la fiche RH_Agent ouverte quand un traitement python signale
        ' l'enregistrement d'un agent (ligne "AGENT_ENREGISTRE:<matricule>")
        Try
            Dim mat As String = ""
            For Each line As String In strMsg.ToString().Split({vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
                If line.StartsWith("AGENT_ENREGISTRE:") Then
                    mat = line.Substring(17).Trim()
                    Exit For
                End If
            Next
            If mat = "" Then Return
            For Each ctrl As Control In leMenu.pnl_PersonnalContent.Controls
                If TypeOf ctrl Is RH_Agent Then
                    Dim f As RH_Agent = CType(ctrl, RH_Agent)
                    f.Matricule_Text.Text = mat
                    f.request()
                    Exit For
                End If
            Next
        Catch ex As Exception
            ' Rafraichissement de confort : ne jamais bloquer le traitement
        End Try
    End Sub
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
