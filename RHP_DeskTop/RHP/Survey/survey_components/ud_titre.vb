Public Class ud_titre

    Private _titre As String = ""
    Private _style As String = "default"

    Public Property Titre() As String
        Get
            Return _titre
        End Get
        Set(ByVal value As String)
            _titre = value
            lblTitre.Text = _titre
        End Set
    End Property

    Public Property Style() As String
        Get
            Return _style
        End Get
        Set(ByVal value As String)
            _style = value
            ApplyStyle()
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub ApplyStyle()
        ' Reset default styles
        Dim pd As Integer = 15
        Me.BackColor = Color.Transparent
        lblTitre.BackColor = Color.Transparent
        lblTitre.ForeColor = Color.Black
        lblTitre.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
        lblTitre.TextAlign = ContentAlignment.MiddleLeft
        Me.AutoSize = True
        lblTitre.AutoSize = True
        Me.Height = 35
        lblTitre.ForeColor = colorBase01
        Select Case _style.ToLower()
            Case "h1"
                ' H1: Width 100%, BackgroundColor colorbase01, ForeColor white, Bold
                Me.BackColor = colorBase01
                lblTitre.BackColor = Color.Transparent
                lblTitre.ForeColor = Color.White
                lblTitre.Font = New Font(Me.Font.FontFamily, 16, FontStyle.Bold) ' Grand titre
                ' Pour width 100%, on désactive l'auto-size et on force la hauteur
                Me.AutoSize = False
                lblTitre.AutoSize = False


                lblTitre.Dock = DockStyle.Fill
                lblTitre.TextAlign = ContentAlignment.MiddleLeft
                lblTitre.Padding = New Padding(5)


            Case "h2"
                Me.BackColor = Color.Transparent
                lblTitre.BackColor = Color.Transparent
                lblTitre.Font = New Font(Me.Font.FontFamily, 14, FontStyle.Bold)
                lblTitre.Padding = New Padding(pd * 2, 5, 5, 5)
            Case "h3"
                Me.BackColor = Color.Transparent
                lblTitre.BackColor = Color.Transparent
                lblTitre.Font = New Font(Me.Font.FontFamily, 12, FontStyle.Bold)
                lblTitre.Padding = New Padding(pd * 3, 5, 5, 5)
            Case "h4"
                Me.BackColor = Color.Transparent
                lblTitre.BackColor = Color.Transparent
                lblTitre.Font = New Font(Me.Font.FontFamily, 11, FontStyle.Bold)
                lblTitre.Padding = New Padding(pd * 4, 5, 5, 5)
            Case "h5"
                Me.BackColor = Color.Transparent
                lblTitre.BackColor = Color.Transparent
                lblTitre.Font = New Font(Me.Font.FontFamily, 10, FontStyle.Bold)
                lblTitre.Padding = New Padding(pd * 5, 5, 5, 5)
            Case "h6"
                ' H6: Plus petit, colorbase02, gras italic et underlined
                Me.BackColor = Color.Transparent
                lblTitre.BackColor = Color.Transparent
                lblTitre.ForeColor = colorBase02
                lblTitre.Font = New Font(Me.Font.FontFamily, 8, FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
                lblTitre.Padding = New Padding(pd * 6, 5, 5, 5)
            Case Else
                ' Default to normal text if unknown
                Me.BackColor = Color.Transparent
                lblTitre.BackColor = Color.Transparent
                lblTitre.Font = New Font(Me.Font.FontFamily, 9, FontStyle.Bold)

        End Select
    End Sub

    Private Sub ud_titre_Load(sender As Object, e As EventArgs) Handles Me.Load
        ApplyStyle()
    End Sub

End Class
