using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


public partial class UserPermissions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void UsersRoleListView_ItemBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            LoginView UsersRoleLoginView = (LoginView)e.Item.FindControl("UsersRoleLoginView");
            HiddenField ItemUserNameHF = (HiddenField)e.Item.FindControl("ItemUserNameHF");   

            var dataItem = e.Item.DataItem;
            string ItemUserName = DataBinder.Eval(dataItem, "UserName").ToString();

            if (ItemUserNameHF != null)
                ItemUserNameHF.Value = ItemUserName;
            SetLoginViewActions(UsersRoleLoginView);
        }
    }

    protected void UserRoleListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        Button b = (Button)e.CommandSource;
        DropDownList UserRoles = (DropDownList)b.Parent.FindControl("RolesDropDownList");
        Literal EditUserRoleResponse = (Literal)b.Parent.FindControl("EditUserRoleResponse");
        
        string user = e.CommandArgument.ToString();
        string old_role = Roles.GetRolesForUser(user)[0];
        string new_role = UserRoles.SelectedValue.ToString();

        try
        {
            Roles.RemoveUserFromRole(user, old_role);
            Roles.AddUserToRole(user, new_role);
            Response.Redirect("~/UserPermissions.aspx");
        }
        catch (Exception ex)
        {
            EditUserRoleResponse.Text = ex.Message;
        }

    }

    protected void UsersRoleLoginView_ViewChanged(object source, EventArgs e)
    {
        SetLoginViewActions((LoginView)source);        
    }

    protected void SetLoginViewActions(LoginView UsersRoleLoginView)
    {
        Button EditUserRoleButton = (Button)UsersRoleLoginView.FindControl("EditUserRoleButton");
        HiddenField ItemUserNameHF = (HiddenField)UsersRoleLoginView.Parent.FindControl("ItemUserNameHF");

        string username = ItemUserNameHF.Value.ToString();

        if (EditUserRoleButton != null)
        {
            EditUserRoleButton.CommandArgument = username;
        }
    }
}