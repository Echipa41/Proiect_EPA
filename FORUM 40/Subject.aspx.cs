using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Sql;
using System.Data.SqlClient;


public partial class Subject : System.Web.UI.Page
{
    protected void InitJs()
    {
        Button AddMessageButton = (Button)AddMessageLoginView.FindControl("AddMessageButton");
        Button EditMessageButton = (Button)AddMessageLoginView.FindControl("EditMessageButton");
        Button CancelEditButton = (Button)AddMessageLoginView.FindControl("CancelEdit");

        try
        {
            string EditMessageID = AddMessageLoginView.FindControl("EditMessageDiv").ClientID.ToString();
            string AddMessageID = AddMessageLoginView.FindControl("AddMessageDiv").ClientID.ToString();

            if (CancelEditButton != null)
                CancelEditButton.OnClientClick = "return CancelEdit('" + EditMessageID + "','" + AddMessageID + "')";
        }
        catch (Exception ex) { }
        /*
        if (AddMessageButton != null)
            AddMessageButton.OnClientClick = "Encode(" + AddMessageLoginView.FindControl("MessageTB").ClientID.ToString() + ")";
        if (EditMessageButton != null)
            EditMessageButton.OnClientClick = "return Encode(" + AddMessageLoginView.FindControl("EditMessageTB").ClientID.ToString() + ")";
        */ 
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        InitJs();

        string autor = Request.Params["autor"];
        string content = Request.Params["content"];
        string order = Request.Params["order"];

        if (Request.Params["sub_id"] != null)
        {
            Session["sub_id"] = Request.Params["sub_id"];
            string sub_id = Session["sub_id"].ToString();
            string author_id = Guid.Empty.ToString();
            try { author_id = Membership.GetUser().ProviderUserKey.ToString(); }
            catch (Exception ex) { }
            
            string cmd = "SELECT Message.Id as [Id], [Description], Message.Date as [Date],"
                + " Message.LastUpdate as [LastUpdate], [UserName], [CategoryId], [Name] as [CategoryName], "
                + " CASE WHEN Message.AuthorId = @AuthorId THEN 'Author' ELSE 'NotAuthor' END as [Editable]"
                + " FROM [Message]"
                + " INNER JOIN [aspnet_Users] on [UserId] = Message.AuthorId"
                + " INNER JOIN [Pictures] on Pictures.PictureId = [IdPicture]"
                + " INNER JOIN [Category] on Pictures.CategoryId = Category.Id"
                + " WHERE [PictureId] = @SubId"
                + " ORDER BY [Date]";

            MessageSqlDataSource.SelectCommand = cmd;
            MessageSqlDataSource.SelectParameters.Clear();
            MessageSqlDataSource.SelectParameters.Add("SubId", sub_id);
            MessageSqlDataSource.SelectParameters.Add("AuthorId", author_id);
            MessageSqlDataSource.DataBind();

            if (autor != null && content != null && order != null)
            {
                autor = Server.UrlDecode(autor);
                content = Server.UrlDecode(content);
                order = Server.UrlDecode(order);
                SearchMessage(autor, content, order);
            }

            cmd = "SELECT [Nume], [Data_adaugare], [Last_update], [CategoryId], [UserName], [Name] as [CategoryName] FROM [Pictures]"
                + " INNER JOIN [aspnet_Users] on [UserId] = [AutorId]"
                + " INNER JOIN [Category] on Category.Id = [CategoryId]"
                + " WHERE Pictures.PictureId = @SubId";
            CurrentSubjectSqlDataSource.SelectCommand = cmd;
            CurrentSubjectSqlDataSource.SelectParameters.Clear();
            CurrentSubjectSqlDataSource.SelectParameters.Add("SubId", sub_id);
            CurrentSubjectSqlDataSource.DataBind();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    protected void AddMessage(object sender, EventArgs e)
    {
        string sub_id = Session["sub_id"].ToString();
        string author_id = Membership.GetUser().ProviderUserKey.ToString();
        TextBox MessageTB = (TextBox)AddMessageLoginView.FindControl("MessageTB");
        Literal AddMessageResponse = (Literal)AddMessageLoginView.FindControl("AddMessageResponse");
        string message = MessageTB.Text;
        
        try
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = MessageSqlDataSource.ConnectionString;
            connection.Open();

            String cmd = "INSERT INTO [Message] ([AuthorId], [IdPicture], [Description], [Date], [LastUpdate])"
                + "VALUES (@AuthorId, @IdPicture, @Description, @Date, @LastUpdate)";
            SqlCommand command = new SqlCommand(cmd, connection);

            
            command.Parameters.AddWithValue("AuthorId", author_id);
            command.Parameters.AddWithValue("IdPicture", sub_id);
            command.Parameters.AddWithValue("Description", message);
            command.Parameters.AddWithValue("Date", DateTime.Now);
            command.Parameters.AddWithValue("LastUpdate", DateTime.Now);

            try
            {
                command.ExecuteNonQuery();
                Response.Redirect("~/Subject.aspx?sub_id=" + sub_id);
            }
            catch (SqlException sqex)
            {
                AddMessageResponse.Text = sqex.Message;
            }

            connection.Close();
        }
        catch (Exception ex)
        {
            AddMessageResponse.Text = ex.Message;
        }
    }

    protected void MessageListView_ItemBound(object sender, ListViewItemEventArgs e)
    {   
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            LoginView QuoteLoginView = (LoginView)e.Item.FindControl("QuoteLoginView");
            Button EditMessageButton = (Button)e.Item.FindControl("EditMessageButton");
            Button DeleteMessageButton = (Button)e.Item.FindControl("DeleteMessageButton");
            Label SignatureLabel = (Label)e.Item.FindControl("MessageSignature");
            HiddenField ItemContentHF = (HiddenField)e.Item.FindControl("ItemContentHF");
            Control AuthorDiv = e.Item.FindControl("MessageAuthor");
                        
            var dataItem = e.Item.DataItem;
            string ItemId = Guid.Parse(DataBinder.Eval(dataItem, "Id").ToString()).ToString();
            string ItemUserName = DataBinder.Eval(dataItem, "UserName").ToString();
            string ItemContent = DataBinder.Eval(dataItem, "Description").ToString();

            bool ItemIsAuthor = DataBinder.Eval(dataItem, "Editable").ToString() == "Author";
            bool ItemIsModerator = false;
            try
            {
                string username = Membership.GetUser().UserName;
                ItemIsModerator = Roles.IsUserInRole(username, "Moderator");
            }
            catch (Exception ex) { }

            if (EditMessageButton != null)
            {
                try
                {
                    string EditDiv = AddMessageLoginView.FindControl("EditMessageDiv").ClientID.ToString();
                    string EditTB = AddMessageLoginView.FindControl("EditMessageTB").ClientID.ToString();
                    string EditID = AddMessageLoginView.FindControl("EditMessageID").ClientID.ToString();
                    string AddDiv = AddMessageLoginView.FindControl("AddMessageDiv").ClientID.ToString();

                    EditMessageButton.OnClientClick = "return ShowEdit('" + EditDiv + "','" + EditID + "','" + ItemId + "','" + EditTB + "','" + ItemContent + "','" + AddDiv + "')";
                }
                catch (Exception ex) { }
            }
            if (DeleteMessageButton != null)
                DeleteMessageButton.CommandArgument = ItemId;
            if (AuthorDiv != null)
                AuthorDiv.Visible = ItemIsAuthor || ItemIsModerator;
            if (SignatureLabel != null)
                SignatureLabel.Text = Profile.GetProfile(ItemUserName).Semnatura.ToString();
            if (ItemContentHF != null)
                ItemContentHF.Value = ItemContent;
            SetLoginViewActions(QuoteLoginView);
        }
    }

    protected void MessageListView_ItemCommand(object source, ListViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "DeleteMessage")
            DeleteMessage(source, e);
        if (e.CommandName.ToString() == "QuoteMessage")
            QuoteMessage(source, e);
    }

    protected void EditMessage(object source, EventArgs e)
    {
        HiddenField h = (HiddenField)AddMessageLoginView.FindControl("EditMessageID");
        TextBox t = (TextBox)AddMessageLoginView.FindControl("EditMessageTB");
        Literal EditMessageResponse = (Literal)AddMessageLoginView.FindControl("EditMessageResponse");
      

        if (t == null) { return; }

        string sub_id = Session["sub_id"].ToString();
        string m_id = Guid.Parse(h.Value.ToString()).ToString();
        string description = t.Text;

        try
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = MessageSqlDataSource.ConnectionString;
            connection.Open();

            String cmd = "UPDATE [Message] SET [Description] = @Description, [LastUpdate] = @LastUpdate WHERE [Id] = @Id";
            SqlCommand command = new SqlCommand(cmd, connection);
            command.Parameters.AddWithValue("Description", description);
            command.Parameters.AddWithValue("LastUpdate", DateTime.Now);
            command.Parameters.AddWithValue("Id", m_id);

            try
            {
                command.ExecuteNonQuery();
                Response.Redirect("~/Subject.aspx?sub_id="+sub_id);
            }
            catch (SqlException sqex)
            {
                EditMessageResponse.Text = sqex.Message;
            }

            connection.Close();
        }
        catch (Exception ex)
        {
            EditMessageResponse.Text = ex.Message;
        }
    }

    protected void DeleteMessage(object source, ListViewCommandEventArgs e)
    {
        Button b = (Button)e.CommandSource;
        Literal DeleteMessageResponse = (Literal)b.Parent.FindControl("DeleteMessageResponse");

        string sub_id = Session["sub_id"].ToString();
        string m_id = e.CommandArgument.ToString();

        try
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = MessageSqlDataSource.ConnectionString;
            connection.Open();

            String cmd = "DELETE FROM [Message] WHERE [Id] = @Id";
            SqlCommand command = new SqlCommand(cmd, connection);
            command.Parameters.AddWithValue("Id", m_id);

            try
            {
                command.ExecuteNonQuery();
                Response.Redirect("~/Subject.aspx?sub_id="+sub_id);
            }
            catch (SqlException sqex)
            {
                DeleteMessageResponse.Text = sqex.Message;
            }

            connection.Close();
        }
        catch (Exception ex)
        {
            DeleteMessageResponse.Text = ex.Message;
        }
    }

    protected void QuoteMessage(object source, ListViewCommandEventArgs e)
    {
        Button b = (Button)e.CommandSource;
        Literal QuoteMessageDescription = (Literal)b.Parent.FindControl("QuoteMessageDescription");
        TextBox MessageTB = (TextBox)AddMessageLoginView.FindControl("MessageTB");

        if (MessageTB == null || QuoteMessageDescription == null) { return; }
        MessageTB.Text += "[quote]" + QuoteMessageDescription.Text + "[/quote]";
    }

    protected void SearchMessage_Click(object sender, EventArgs e)
    {
        string sub_id = Session["sub_id"].ToString();
        string UserFilter = Server.UrlEncode(MessageUserTB.Text.ToLower());
        string DescriptionFilter = Server.UrlEncode(MessageDescriptionTB.Text.ToLower());
        string Order = Server.UrlEncode(MessageDateRBL.SelectedValue.ToString());

        Response.Redirect("~/Subject.aspx?sub_id=" + sub_id + "&autor=" + UserFilter + "&content=" + DescriptionFilter + "&order=" + Order);
    }

    protected void SearchMessage(string UserFilter, string DescriptionFilter, string Order)
    {
        string sub_id = Session["sub_id"].ToString();
        string author_id = Guid.Empty.ToString();
        try { author_id = Membership.GetUser().ProviderUserKey.ToString(); }
        catch (Exception ex) { }

        string cmd = "SELECT Message.Id as [Id], [Description], Message.Date as [Date],"
                        + " Message.LastUpdate as [LastUpdate], [UserName], [CategoryId], [Name] as [CategoryName], "
                        + " CASE WHEN Message.AuthorId = @AuthorId THEN 'Author' ELSE 'NotAuthor' END as [Editable]"
                        + " FROM [Message]"
                        + " INNER JOIN [aspnet_Users] on [UserId] = Message.AuthorId"
                        + " INNER JOIN [Pictures] on Pictures.PictureId = [IdPicture]"
                        + " INNER JOIN [Category] on Pictures.CategoryId = Category.Id"
                        + " WHERE [PictureId] = @SubId";

        bool Descending = (Order == "Descending");

        cmd += " AND LOWER([Description]) LIKE @DescriptionFilter";
        cmd += " AND LOWER([UserName]) LIKE @UserFilter";
        if (!Descending) cmd += " ORDER BY [Date]";
        else cmd += " ORDER BY [Date] DESC";
        
        MessageSqlDataSource.SelectCommand = cmd;
        MessageSqlDataSource.SelectParameters.Clear();
        MessageSqlDataSource.SelectParameters.Add("SubId", sub_id);
        MessageSqlDataSource.SelectParameters.Add("AuthorId", author_id);
        MessageSqlDataSource.SelectParameters.Add("DescriptionFilter", "%" + DescriptionFilter + "%");
        MessageSqlDataSource.SelectParameters.Add("UserFilter", "%" + UserFilter + "%");
        MessageSqlDataSource.DataBind();

    }

    protected void QuoteLoginView_ViewChanged(object source, EventArgs e)
    {
        SetLoginViewActions((LoginView)source);
    }

    protected void SetLoginViewActions(LoginView QuoteLoginView)
    {
        Literal QuoteMessageDescription = (Literal)QuoteLoginView.FindControl("QuoteMessageDescription");
        HiddenField ItemContentHF = (HiddenField)QuoteLoginView.Parent.FindControl("ItemContentHF");

        string ItemContent = ItemContentHF.Value.ToString();

        if (QuoteMessageDescription != null)
        {
            QuoteMessageDescription.Text = ItemContent;
            QuoteMessageDescription.Visible = false;
        }
    }
}