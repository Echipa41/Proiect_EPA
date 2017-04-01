using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    protected void InitJs()
    {
        Button AddCategoryButton = (Button)AddCategoryLoginView.FindControl("AddCategoryButton");
        Button EditCategoryButton = (Button)AddCategoryLoginView.FindControl("EditCategoryButton");
        Button CancelEditButton = (Button)AddCategoryLoginView.FindControl("CancelEdit");

        try
        {
            string AddCategoryDivID = AddCategoryLoginView.FindControl("AddCategoryDiv").ClientID.ToString();
            string EditCategoryDivID = AddCategoryLoginView.FindControl("EditCategoryDiv").ClientID.ToString();

            if (EditCategoryButton != null)
                EditCategoryButton.OnClientClick = "return CheckNotNull(" + AddCategoryLoginView.FindControl("EditCategoryTB").ClientID.ToString() + ")";
            if (CancelEditButton != null)
                CancelEditButton.OnClientClick = "return CancelEdit('" + EditCategoryDivID + "','" + AddCategoryDivID + "')";

        }
        catch (Exception ex) { }
        //if (AddCategoryButton != null)
        //    AddCategoryButton.OnClientClick = "Encode(" + AddCategoryLoginView.FindControl("NameTB").ClientID.ToString() + ")";

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        InitJs();
    }

    protected string CheckCategory(string name)
    {
        try
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = CategorySqlDataSource.ConnectionString;
            connection.Open();

            String cmd = "SELECT * FROM [Category] WHERE [Name] = @Name";
            SqlCommand command = new SqlCommand(cmd, connection);
            command.Parameters.AddWithValue("Name", name);

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    return "Categoria exista deja!";
            }
            catch (SqlException sqex)
            {
                return sqex.Message.ToString();
            }

            connection.Close();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

        return string.Empty;
    }
    protected void AddCategory(object sender, EventArgs e)
    {
        Literal AddCategoryResponse = (Literal)AddCategoryLoginView.FindControl("AddCategoryResponse");
        TextBox NameTB = (TextBox)AddCategoryLoginView.FindControl("NameTB");
        FileUpload PozaCat = (FileUpload)AddCategoryLoginView.FindControl("PozaCat");

        string check = CheckCategory(NameTB.Text.ToString());
        if (check != string.Empty)
        {
            AddCategoryResponse.Text = check;
            return;
        }

        try
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = CategorySqlDataSource.ConnectionString;
            connection.Open();
         
            String cmd = "INSERT INTO [Category] ([Name] , [Poza]) VALUES (@Name, @Poza)";
            SqlCommand command = new SqlCommand(cmd, connection);
            command.Parameters.AddWithValue("Name", NameTB.Text);
            command.Parameters.AddWithValue("Poza", "UplCat/"+PozaCat.FileName);

            try
            {
                command.ExecuteNonQuery();
                Response.Redirect("~/Gallery.aspx?");
            }
            catch (SqlException sqex)
            {
                AddCategoryResponse.Text = sqex.Message;
            }

            connection.Close();
        }
        catch (Exception ex)
        {
            AddCategoryResponse.Text = ex.Message;
        }

    }

    protected void CategoryListView_ItemBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            LoginView CategoryLoginView = (LoginView)e.Item.FindControl("CategoryLoginView");
            HiddenField ItemIdHF = (HiddenField)e.Item.FindControl("ItemId");
            HiddenField ItemContentHF = (HiddenField)e.Item.FindControl("ItemContent");

            var dataItem = e.Item.DataItem;
            string ItemId = Guid.Parse(DataBinder.Eval(dataItem, "Id").ToString()).ToString();
            string ItemContent = DataBinder.Eval(dataItem, "Name").ToString();

            if (ItemIdHF != null)
                ItemIdHF.Value = ItemId.ToString();
            if (ItemContentHF != null)
                ItemContentHF.Value = ItemContent.ToString();

            SetLoginViewActions(CategoryLoginView);
        }
    }

    protected void CategoryListView_ItemCommand(object source, ListViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "DeleteCategory")
            DeleteCategory(source, e);
    }

    protected void DeleteCategory(object source, ListViewCommandEventArgs e)
    {
        Button b = (Button)e.CommandSource;
        Literal DeleteCategoryResponse = (Literal)b.Parent.FindControl("DeleteCategoryResponse");

        string cat_id = e.CommandArgument.ToString();

        try
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = CategorySqlDataSource.ConnectionString;
            connection.Open();

            String cmd = "DELETE FROM [Category] WHERE [Id] = @Id";
            SqlCommand command = new SqlCommand(cmd, connection);
            command.Parameters.AddWithValue("Id", cat_id);

            try
            {
                command.ExecuteNonQuery();
                Response.Redirect("~/Gallery.aspx?");
            }
            catch (SqlException sqex)
            {
                DeleteCategoryResponse.Text = sqex.Message + " " + cat_id;
            }

            connection.Close();
        }
        catch (Exception ex)
        {
            DeleteCategoryResponse.Text = ex.Message + " " + cat_id;
        }
    }

    protected void EditCategory(object source, EventArgs e)
    {
        HiddenField h = (HiddenField)AddCategoryLoginView.FindControl("EditCategoryID");
        TextBox t = (TextBox)AddCategoryLoginView.FindControl("EditCategoryTB");
        Literal EditCategoryResponse = (Literal)AddCategoryLoginView.FindControl("EditCategoryResponse");

        if (t == null) { return; }

        string cat_id = Guid.Parse(h.Value.ToString()).ToString();
        string name = t.Text;

        try
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = CategorySqlDataSource.ConnectionString;
            connection.Open();

            String cmd = "UPDATE [Category] SET [Name] = @Name WHERE [Id] = @Id";
            SqlCommand command = new SqlCommand(cmd, connection);
            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("Id", cat_id);

            try
            {
                command.ExecuteNonQuery();
                Response.Redirect("~/Gallery.aspx?");
            }
            catch (SqlException sqex)
            {
                EditCategoryResponse.Text = sqex.Message;
            }

            connection.Close();
        }
        catch (Exception ex)
        {
            EditCategoryResponse.Text = ex.Message;
        }
    }

    protected void CategoryLoginView_ChangedView(object source, EventArgs e)
    {
        SetLoginViewActions((LoginView)source);        
    }

    protected void SetLoginViewActions(LoginView CategoryLoginView)
    {
        Button EditCategoryButton = (Button)CategoryLoginView.FindControl("EditCategoryButton");
        Button DeleteCategoryButton = (Button)CategoryLoginView.FindControl("DeleteCategoryButton");
        
        HiddenField ItemIdHF = (HiddenField)CategoryLoginView.Parent.FindControl("ItemId");
        HiddenField ItemContentHF = (HiddenField)CategoryLoginView.Parent.FindControl("ItemContent");

        string ItemId = Guid.Parse((ItemIdHF.Value).ToString()).ToString();
        string ItemContent = ItemContentHF.Value.ToString();

        if (EditCategoryButton != null)
        {
            string EditDiv = AddCategoryLoginView.FindControl("EditCategoryDiv").ClientID.ToString();
            string EditTB = AddCategoryLoginView.FindControl("EditCategoryTB").ClientID.ToString();
            string EditID = AddCategoryLoginView.FindControl("EditCategoryID").ClientID.ToString();
            string AddID = AddCategoryLoginView.FindControl("AddCategoryDiv").ClientID.ToString();
            EditCategoryButton.OnClientClick = "return ShowEdit('" + EditDiv + "','" + EditID + "','" + ItemId + "','" + EditTB + "','" + ItemContent + "','" + AddID + "')";
        }
        if (DeleteCategoryButton != null)
            DeleteCategoryButton.CommandArgument = ItemId;
    }

}

