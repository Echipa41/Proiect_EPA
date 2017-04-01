using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class Category : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
         // Label1.Text = "0 Users have rated this Product";
        // Label2.Text = "Average rating for this Product is 0";

        if (Request.Params["cat_id"] != null)
        {
            Session["cat_id"] = Request.Params["cat_id"];
            string cat_id = Session["cat_id"].ToString();
            string author_id = Guid.Empty.ToString();
            try { author_id = Membership.GetUser().ProviderUserKey.ToString(); }
            catch (Exception ex) { }


            string cmd = "SELECT [Name] FROM [Category]"
                        + " WHERE [Id] = @CatId";
            CurrentCategorySqlDataSource.SelectCommand = cmd;
            CurrentCategorySqlDataSource.SelectParameters.Clear();
            CurrentCategorySqlDataSource.SelectParameters.Add("CatId", cat_id);
            CurrentCategorySqlDataSource.DataBind();

            string cmd2 = "select [Nume],[Descriere],[Data_adaugare],[Locatie],[UserName],[PictureId] from [Pictures]"
                  + " INNER JOIN [aspnet_Users] on [AutorId] = [UserId]"
                  + "where [CategoryId]=@CatId";
            PicturesDataSource.SelectCommand = cmd2;
            PicturesDataSource.SelectParameters.Clear();
            PicturesDataSource.SelectParameters.Add("CatId", cat_id);
            // PicturesDataSource.SelectParameters.Add("User", author_id);
            PicturesDataSource.DataBind();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}


