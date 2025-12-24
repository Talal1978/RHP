Public Class Org_FichePoste
    Dim _TblAgent As DataTable = DATA_READER_GRD(" select Matricule, Nom_Agent+' '+Prenom_Agent as Nom, Cod_Entite,Lib_Entite, RH_Agent.Cod_Poste,Lib_Poste, f.Cod_Grade,Lib_Grade, Titre, isnull(JobDescription,'') as JobDescription from RH_Agent  
 outer apply (select Lib_Poste,Cod_Grade, isnull(JobDescription,'') as JobDescription from Org_Poste where id_Societe=RH_Agent.id_Societe and Cod_Poste=RH_Agent.Cod_Poste)f
 outer apply (select Lib_Entite from Org_Entite o where o.id_Societe=RH_Agent.id_Societe and Cod_Entite=RH_Agent.Cod_Entite)o
 outer apply (select Lib_Grade from Org_Grade where RH_Agent.Cod_Grade=Cod_Grade and RH_Agent.id_Societe=id_Societe)g
 where id_Societe=" & Societe.id_Societe & " and exists(
 select * from Sys_Org_Entite s where 
 ';'+isnull(Racine+';'+s.Cod_Entite,'')+';' like '%;'+isnull(nullif('" & theUser.Cod_Entite & "',''),'8787uhuhunjj')+';%' and id_Societe=" & Societe.id_Societe & " and RH_Agent.Cod_Entite=s.Cod_Entite)
 ")
    Private Sub Org_FichePoste_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Matricule_txt.Text = theUser.Matricule
    End Sub
    Sub LireJobDiscription(NumLig As Integer)

    End Sub

    Private Sub Matricule__LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Matricule_.LinkClicked
        If Not theUser.TeamLeader Then Return
        Appel_Zoom1("MS018", Matricule_txt, Me, String.Format(filtreUser, {"RH_Agent"}))
    End Sub

    Private Sub Matricule_txt_TextChanged(sender As Object, e As EventArgs) Handles Matricule_txt.TextChanged
        Dim mRw As DataRow() = _TblAgent.Select("Matricule='" & Matricule_txt.Text & "'")
        If mRw.Length > 0 Then
            Nom_Agent_Text.Text = mRw(0)("Nom")
            Cod_Entite_txt.Text = IsNull(mRw(0)("Cod_Entite"), "")
            Lib_Entite_txt.Text = IsNull(mRw(0)("Lib_Entite"), "")
            Cod_Poste_txt.Text = IsNull(mRw(0)("Cod_Poste"), "")
            Lib_Poste_txt.Text = IsNull(mRw(0)("Lib_Poste"), "")
            Cod_Grade_txt.Text = IsNull(mRw(0)("Cod_Grade"), "")
            Lib_Grade_txt.Text = IsNull(mRw(0)("Lib_Grade"), "")
            Titre_txt.Text = IsNull(mRw(0)("Titre"), "")
            JobDescription_rtb.Rtb.RtfText = IsNull(mRw(0)("JobDescription"), "")
        Else
            Nom_Agent_Text.Text = ""
            Cod_Entite_txt.Text = ""
            Lib_Entite_txt.Text = ""
            Cod_Poste_txt.Text = ""
            Lib_Poste_txt.Text = ""
            Cod_Grade_txt.Text = ""
            Lib_Grade_txt.Text = ""
            Titre_txt.Text = ""
            JobDescription_rtb.Rtb.Text = ""
        End If

    End Sub
End Class