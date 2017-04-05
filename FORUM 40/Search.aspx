<%@ Page Title="" Language="C#" MasterPageFile="~/MPAll.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

  <asp:SqlDataSource ID="SearchSqlDataSource" runat="server"
    ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
    SelectCommand=""></asp:SqlDataSource>

  <asp:SqlDataSource ID="CategorySqlDataSource" runat="server"
    ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
    SelectCommand="SELECT [Id], [Name] FROM [Category]"></asp:SqlDataSource>

  <div style="height: 500px">
    <span style="position: absolute; left: 15%; top: 170px">
      <asp:RadioButtonList ID="ElementRBL" runat="server">
        <asp:ListItem Value="Message" Selected="True"> Mesaj </asp:ListItem>
      </asp:RadioButtonList>
      <hr />
      <asp:RadioButtonList ID="DateRBL" runat="server">
        <asp:ListItem Value="Crescator" Selected="True"> Crescator dupa data </asp:ListItem>
        <asp:ListItem Value="Descrescator"> Descrescator dupa data </asp:ListItem>
      </asp:RadioButtonList>
      <hr />

      <b>Categorie:</b>
      <asp:DropDownList ID="CategoryDDL" runat="server" CssClass="select-dropdown-menu"
        DataSourceID="CategorySqlDataSource" DataTextField="Name" DataValueField="Id">
      </asp:DropDownList>

      <hr />

      <div>
        <asp:Button ID="SearchButton" runat="server" Text="Cauta"
          CssClass="btn btn-default" OnClick="SearchButton_Click" />
      </div>
    </span>
    <span style="position: absolute; left: 50%; top: 170px">
      <div>
        <h3>Autor: </h3>
        <asp:TextBox ID="AutorTB" runat="server"> </asp:TextBox>
      </div>

      <hr />

      <div>
        <h3>Continut: </h3>
        <asp:TextBox ID="ContentTB" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox>
      </div>
    </span>
  </div>


  <br />

  <div style="width: 55%; position: absolute; top: 500px">
    <asp:ListView ID="SearchListView" runat="server"
      DataSourceID="SearchSqlDataSource"
      OnPagePropertiesChanging="SearchListView_PagePropertiesChanging">

      <ItemTemplate>
        <div class="panel panel-info">
          <div class="panel-heading">
            <div class="panel-title">
              <span>Autor: 
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/UserProfile.aspx?UserName=" + DataBinder.Eval(Container.DataItem, "UserName")   %>'>
                                    <%# DataBinder.Eval(Container.DataItem, "UserName") %>    
                                </asp:HyperLink>
              </span>
              |<span> Data: <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "Date").ToString()).ToShortDateString()%> </span>
              |<span> Actualizat: <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "LastUpdate").ToString()).ToShortDateString()%> </span>
              |<span> Categorie: 
                                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/Category.aspx?cat_id=" + DataBinder.Eval(Container.DataItem, "CategoryId") %>'>
                                    <%# DataBinder.Eval(Container.DataItem, "CategoryName") %>    
                                </asp:HyperLink>
              </span>
              |<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Subject.aspx?sub_id=" + DataBinder.Eval(Container.DataItem, "IdPicture")   %>'>
                                Vezi pagina    
              </asp:HyperLink>
            </div>
          </div>

          <div class="panel-body">
            <%# MyDecoder.DecodeText(DataBinder.Eval(Container.DataItem, "Content").ToString())%>
          </div>
        </div>
      </ItemTemplate>

    </asp:ListView>


    <div class="pagination">
      <asp:DataPager ID="SearchDataPager" runat="server"
        PagedControlID="SearchListView" PageSize="5">
        <Fields>
          <asp:NumericPagerField />
        </Fields>
      </asp:DataPager>
    </div>
  </div>
</asp:Content>


