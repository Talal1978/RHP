Module Module_Profile_User
    Public Tbl_Org_Entite As DataTable
    Public filtreUser As String = ""
    Public filtreEntite As String = ""
    Public Structure Typ_Role
        Public Agent As String
        Public Tech As String
        Public Ops As String
        Public Admin As String
    End Structure
    Public Structure Utilisateur
        Public id_User As Integer
        Public Cod_Profile As Integer
        Public Login As String
        Public Typ_Role As String
        Public Cod_Poste As String
        Public Cod_Entite As String
        Public Matricule As String
        Public Nom As String
        Public Mail As String
        Public id_Societe As Integer
        Public TeamLeader As Boolean
        Public RacineHierarchique As String
        Public is_AD As Boolean
        Public Pwd_User As String
    End Structure
    Public theUser As New Utilisateur
    Public typRole As New Typ_Role
End Module
