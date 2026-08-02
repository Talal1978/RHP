''' <summary>
''' Sélecteur d'icône Material UI pour la déclaration des widgets portail
''' (onglet "Widget portail" de Param_Query). Liste recherchable de noms
''' d'icônes ; le nom choisi est retourné dans SelectedIcone.
''' </summary>
Public Class Widget_Icones_Picker
    Inherits Form

    Public SelectedIcone As String = ""

    Private txtSearch As TextBox
    Private lst As ListBox

    Private Shared ReadOnly ICONES As String() = {
        "AccountBalance", "AccountCircle", "AccountCircleOutlined", "AccessTime", "Add",
        "AdminPanelSettings", "Air", "Alarm", "Analytics", "Apartment",
        "Apps", "ArrowForward", "Article", "Assessment", "Assignment",
        "AssignmentInd", "AttachFile", "AttachMoney", "Badge", "BarChart",
        "BeachAccess", "Bolt", "Bookmark", "Build", "Business",
        "CalendarMonth", "Cancel", "CardGiftcard", "Category", "Celebration",
        "CheckCircle", "CheckCircleOutline", "ChevronRight", "ChildCare", "Cloud",
        "CloudDone", "CloudOutlined", "Coffee", "Computer", "Construction",
        "ContactMail", "CreditCard", "Dashboard", "DataUsage", "DateRange",
        "Delete", "Description", "DirectionsCar", "Diversity3", "Domain",
        "DonutLarge", "DonutSmall", "Download", "Eco", "Edit",
        "Elderly", "ElectricBolt", "EmojiEvents", "EmojiPeople", "Engineering",
        "Error", "Event", "EventAvailable", "EventBusy", "ExpandMore",
        "FactCheck", "Factory", "Favorite", "FilterList", "Fingerprint",
        "FitnessCenter", "Flag", "Flight", "Folder", "FolderShared",
        "Forest", "Gavel", "GridView", "GroupWork", "Groups",
        "Groups2", "Handyman", "HealthAndSafety", "HelpOutline", "History",
        "Home", "Hotel", "HourglassEmpty", "Image", "Info",
        "Insights", "Inventory", "Inventory2", "Leaderboard", "LibraryBooks",
        "Lightbulb", "Link", "List", "LocalHospital", "LocalShipping",
        "LocationOn", "Lock", "LockOutlined", "Mail", "ManageAccounts",
        "Map", "MedicalServices", "MeetingRoom", "Menu", "MilitaryTech",
        "MonitorHeart", "Money", "MoreVert", "MultilineChart", "MusicNote",
        "Newspaper", "NotificationsOutlined", "OpenInNew", "Park", "PendingActions",
        "People", "Person", "PersonAdd", "PersonSearch", "Pets",
        "Phone", "PhotoCamera", "PieChart", "Print", "Psychology",
        "Public", "QueryStats", "Receipt", "Recycling", "Redeem",
        "Refresh", "Remove", "Restaurant", "Rule", "Save",
        "Schedule", "School", "Search", "Security", "SentimentSatisfied",
        "Settings", "Share", "ShoppingCart", "ShowChart", "Sick",
        "Smartphone", "Sort", "Speed", "SportsSoccer", "StackedBarChart",
        "Star", "StarOutline", "Storage", "Store", "SupervisorAccount",
        "Sync", "TableChart", "Tablet", "TaskAlt", "Thermostat",
        "ThumbUp", "Timeline", "Timer", "Today", "Topic",
        "TravelExplore", "TrendingDown", "TrendingUp", "Update", "Upload",
        "Vaccines", "VerifiedUser", "Videocam", "ViewList", "ViewModule",
        "Visibility", "VisibilityOff", "VpnKey", "Warehouse", "Warning",
        "Watch", "WbSunnyOutlined", "Widgets", "Work", "WorkOutline",
        "WorkspacePremium", "ZoomIn"
    }

    Sub New()
        Me.Text = "Choisir une icône (Material UI)"
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Size = New Size(380, 420)
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        txtSearch = New TextBox
        With txtSearch
            .Dock = DockStyle.Top
        End With
        AddHandler txtSearch.TextChanged, AddressOf Filtrer

        Dim btnOk As New Button
        With btnOk
            .Text = "OK"
            .Dock = DockStyle.Bottom
            .Height = 30
            .DialogResult = DialogResult.OK
        End With
        AddHandler btnOk.Click, AddressOf Valider

        lst = New ListBox
        With lst
            .Dock = DockStyle.Fill
        End With
        AddHandler lst.DoubleClick, AddressOf Valider

        Me.Controls.Add(lst)
        Me.Controls.Add(btnOk)
        Me.Controls.Add(txtSearch)
        Me.AcceptButton = btnOk

        Remplir("")
    End Sub

    Private Sub Remplir(ByVal filtre As String)
        lst.Items.Clear()
        For Each ic In ICONES
            If filtre = "" OrElse ic.ToLower().Contains(filtre.ToLower()) Then
                lst.Items.Add(ic)
            End If
        Next
        If lst.Items.Count > 0 Then lst.SelectedIndex = 0
    End Sub

    Private Sub Filtrer(ByVal sender As Object, ByVal e As EventArgs)
        Remplir(txtSearch.Text.Trim)
    End Sub

    Private Sub Valider(ByVal sender As Object, ByVal e As EventArgs)
        If lst.SelectedItem IsNot Nothing Then
            SelectedIcone = lst.SelectedItem.ToString()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

End Class
