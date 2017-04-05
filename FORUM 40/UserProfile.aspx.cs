using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class UserProfile : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    EditView.Visible = false;
    ProfileCommon CurrentProfile = Profile;
    if (Request.Params["UserName"] != null)
    {
      string UserName = Request.Params["UserName"];
      CurrentProfile = Profile.GetProfile(UserName);
      PozaFU.Visible = false;
      EditProfileButton.Visible = false;
    }

    InitProfileHTML(CurrentProfile);

    if (!Page.IsPostBack)
    {
      NumeTB.Text = CurrentProfile.Nume.ToString();
      PrenumeTB.Text = CurrentProfile.Prenume.ToString();
      DataNasteriiTB.Text = CurrentProfile.DataNasterii.ToShortDateString();
      SexRBL.SelectedValue = CurrentProfile.Sex.ToString();
      OrasTB.Text = CurrentProfile.Oras.ToString();
      SemnaturaTB.Text = CurrentProfile.Semnatura.ToString();
    }
  }

  protected void InitProfileHTML(ProfileCommon CurrentProfile)
  {
    string username = CurrentProfile.UserName.ToString();
    string role = Roles.GetRolesForUser(username)[0];

    UserNameLabel.Text = "<h1>" + username + " (" + role + ") </h1>";

    string path = HttpRuntime.AppDomainAppPath;
    string picture_path = path + "/Uploads/" + username + "_picture.jpg";

    if (!File.Exists(picture_path))
      PozaImg.ImageUrl = "~/Uploads/anonymous.jpg";
    else
      PozaImg.ImageUrl = "~/Uploads/" + username + "_picture.jpg";

    ProfileLastName.Text = CurrentProfile.Nume.ToString();
    ProfileFirstName.Text = CurrentProfile.Prenume.ToString();
    ProfileDOB.Text = CurrentProfile.DataNasterii.ToShortDateString();
    ProfileSex.Text = CurrentProfile.Sex.ToString();
    ProfileCity.Text = CurrentProfile.Oras.ToString();
    ProfileSignature.Text = CurrentProfile.Semnatura.ToString();
  }

  protected void ShowEditProfile(object source, EventArgs e)
  {
    ProfileView.Visible = false;
    EditView.Visible = true;
  }

  protected void HideEditProfile(object source, EventArgs e)
  {
    EditView.Visible = false;
    ProfileView.Visible = true;
  }

  protected void SaveProfileButton_Click(object sender, EventArgs e)
  {
    Profile.Nume = NumeTB.Text.ToString();
    Profile.Prenume = PrenumeTB.Text.ToString();
    Profile.DataNasterii = DateTime.Parse(DataNasteriiTB.Text);
    Profile.Sex = SexRBL.SelectedValue.ToString();
    Profile.Oras = OrasTB.Text.ToString();
    Profile.Semnatura = SemnaturaTB.Text.ToString();

    if (PozaFU.HasFile == true)
    {
      string path = HttpRuntime.AppDomainAppPath;
      string save_path = path + "/Uploads/" + Profile.UserName.ToString() + "_picture.jpg";

      if (File.Exists(save_path) == true)
        File.Delete(save_path);
      PozaFU.SaveAs(save_path);
    }
    Response.Redirect("~/UserProfile.aspx");
  }
}