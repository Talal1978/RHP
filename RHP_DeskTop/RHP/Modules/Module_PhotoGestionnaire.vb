Imports System.Drawing.Imaging
Module Module_PhotoGestionnaire

    Public Function LireFichierPhoto(ByVal mImageFilePath As String) As Byte()
        Dim img As Byte()
        img = Nothing
        Try
            Dim fs As IO.FileStream = New IO.FileStream(mImageFilePath.ToString(), IO.FileMode.Open)
            img = New Byte(fs.Length) {}
            fs.Read(img, 0, fs.Length)
            fs.Close()

            'Redimensionner 
        Catch ex As Exception
            ErrorMsg(ex)
        End Try


        Return img
    End Function
    Public Function AffichagePhoto(ByVal ImageData) As Image
        Dim newImage As Image = Nothing
        ' Try
        If Not IsDBNull(ImageData) Then
            Dim ms As New IO.MemoryStream(ImageData, 0, ImageData.Length)
            ms.Write(ImageData, 0, ImageData.Length)
            newImage = Image.FromStream(ms, True)
        End If
        '    catch ex As Exception
        '      ErrorMsg(ex)
        '   end Try

        Return newImage
    End Function
    Sub ChargerPhoto(ByVal PBox As PictureBox)
        Try
            Dim OpenFileDialog As New OpenFileDialog
            OpenFileDialog.AutoUpgradeEnabled = False
            OpenFileDialog.InitialDirectory = importPath
            OpenFileDialog.Filter = "Fichiers images (*.png)|*.png|images (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|Gif (*.gif)|*.gif"
            If (OpenFileDialog.ShowDialog(PBox.FindForm) = System.Windows.Forms.DialogResult.OK) Then
                importPath = System.IO.Path.GetFullPath(OpenFileDialog.FileName)
                Dim FileName As String = OpenFileDialog.FileName
                Dim Info As New IO.FileInfo(FileName)
                If Info.Extension.ToUpper.Contains("JPG") Or
                Info.Extension.ToUpper.Contains("BMP") Or
                Info.Extension.ToUpper.Contains("PNG") Or
                Info.Extension.ToUpper.Contains("GIF") Then


                    'charger la photo en image
                    Dim Img As Image = AffichagePhoto(LireFichierPhoto(FileName))
                    Dim h As Integer = Img.Height
                    Dim w As Integer = Img.Width
                    Dim Rap As Double = h / w

                    If Rap > 1 Then
                        h = PBox.Height
                        If CInt(Math.Floor(h / Rap)) > PBox.Width Then
                            w = PBox.Width
                            h = Math.Min(h, CInt(Math.Floor(h * Rap)))
                        Else
                            w = CInt(Math.Floor(h / Rap))
                        End If
                    Else
                        w = PBox.Width
                        If CInt(Math.Floor(w * Rap)) > PBox.Height Then
                            h = PBox.Height
                            w = Math.Min(w, CInt(Math.Floor(h / Rap)))
                        Else
                            h = CInt(Math.Floor(w * Rap))
                        End If
                    End If
                    Dim bm_source As New Bitmap(Img)
                    Dim bm_dest As New Bitmap(w, h)
                    Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)
                    ' Copy the source image into the destination bitmap.
                    gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width, bm_dest.Height)

                    PBox.Image = bm_dest
                    PBox.SizeMode = PictureBoxSizeMode.CenterImage
                Else
                    MessageBoxRHP(547)
                End If
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try

    End Sub
    Public Function PhotoToByte(ByVal Photo As System.Drawing.Image) As Byte()
        Dim Rst As Byte()
        Rst = Nothing
        Try
            If Not Photo Is Nothing Then
                Using ms As New IO.MemoryStream()
                    Photo.Save(ms, ImageFormat.Png)
                    Rst = ms.ToArray()
                End Using
            End If
        Catch ex As Exception
            ErrorMsg(ex)
        End Try

        Return Rst
    End Function

End Module
