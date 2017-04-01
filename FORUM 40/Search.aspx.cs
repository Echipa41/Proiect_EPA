using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    string filter = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        CategoryDDL.AppendDataBoundItems = true;
        CategoryDDL.Items.Insert(0, new ListItem("Toate categoriile", string.Empty));
               
        string autor = Request.Params["username"];
        string content = Request.Params["content"];
        string table = Request.Params["table"];
        string order = Request.Params["order"];
        string cat_id = Request.Params["cat_id"];

        if (autor != null && content != null && table != null && order != null && cat_id != null)
        {
            autor = Server.UrlDecode(autor).ToString();
            content = Server.UrlDecode(content).ToString();
            table = Server.UrlDecode(table).ToString();
            order = Server.UrlDecode(order).ToString();
            cat_id = Server.UrlDecode(cat_id).ToString();

            SearchCmd(autor, content, table, order, cat_id);

        }
    }

    protected string GetContentColumn(string table)
    {
        switch (table)
        {
          //  case "Subject": return "Title";
            case "Message": return "Description";
        }

        return "";
    }

   /* protected string SubjectCmd(string cat_id)
    {
        string cmd = "SELECT Pictures.PictureId as [SubjectId], [Nume] as [Content], [Data_adaugare], [Last_update], [UserName], [Name] as [CategoryName], Category.Id as [CategoryId]"
            + " FROM [Pictures]"
            + " INNER JOIN [aspnet_Users] on UserId = [AutorId]"
            + " INNER JOIN [Category] on Category.Id = [CategoryId]"
            + " WHERE [Nume] LIKE @ContentFilter"
            + " AND [UserName] LIKE @UserFilter";

        if (cat_id != string.Empty)
            cmd += " AND Category.Id = @CatId";
        
        cmd += " ORDER BY [Data_adaugare]";
        return cmd;
    }
    */
    protected string MessageCmd(string cat_id)
    {
        string cmd = "SELECT [IdPicture], [Description] as [Content], Message.Date as [Date], Message.LastUpdate as [LastUpdate], [UserName], [Name] as [CategoryName], Category.Id as [CategoryId]"
            + " FROM [Message]"
            + " INNER JOIN [aspnet_Users] on UserId = Message.AuthorId"
            + " INNER JOIN [Pictures] on Pictures.PictureId = [IdPicture]"
            + " INNER JOIN [Category] on Category.Id = [CategoryId]"
            + " WHERE [Description] LIKE @ContentFilter"
            + " AND [UserName] LIKE @UserFilter";
        
        if (cat_id != string.Empty)
            cmd += " AND Category.Id = @CatId";
        
        cmd += " ORDER BY [Date]";
        return cmd;
    }

    protected void SearchButton_Click(object sender, EventArgs e) 
    {
        string content = Server.UrlEncode(ContentTB.Text.ToLower());
        string table = Server.UrlEncode(ElementRBL.SelectedValue.ToString());
        string order = Server.UrlEncode(DateRBL.SelectedValue.ToString());
        string autor = Server.UrlEncode(AutorTB.Text.ToLower());
        string cat_id = Server.UrlEncode(CategoryDDL.SelectedValue.ToString());

        Response.Redirect("~/Search.aspx?username="+autor+"&content="+content+"&table="+table+"&order="+order+"&cat_id="+cat_id);
    }

    protected void SearchCmd(string autor, string content, string table, string order, string cat_id)
    {
        string column = GetContentColumn(table);

        string cmd = "";
    //    if (table == "Pictures") cmd = SubjectCmd(cat_id);
        if (table == "Message") cmd = MessageCmd(cat_id);
        if (order == "Descrescator")
            cmd += " DESC";

        SearchSqlDataSource.SelectCommand = cmd;
        SearchSqlDataSource.SelectParameters.Clear();
        SearchSqlDataSource.SelectParameters.Add("ContentFilter", "%" + content + "%");
        SearchSqlDataSource.SelectParameters.Add("UserFilter", "%" + autor + "%");
        if (cat_id != string.Empty)
            SearchSqlDataSource.SelectParameters.Add("CatId", cat_id);
        SearchSqlDataSource.DataBind();

    }

    protected void SearchListView_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        CategoryDDL.Items.Clear();
        CategoryDDL.Items.Insert(0, new ListItem("Toate categoriile", string.Empty));
    }
}