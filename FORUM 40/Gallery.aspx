<%@ Page Title="Galerie" Language="C#" MasterPageFile="~/MPAll.master" AutoEventWireup="true"
    CodeFile="Gallery.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <asp:SqlDataSource ID="CategorySqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        SelectCommand="SELECT * FROM [Category]">
    </asp:SqlDataSource>

  

    <div style="width:100%;float:left; margin-top:70px">
        <!-- TOATE CATEGORIILE -->
        <div class="panel panel-default">
            <div class="panel-heading" style="font-family:Monotype Corsiva; color:#5bc0de; font-size:25px"> <b>Categorii</b> </div>
        
            <table class="table" style="background-image:url(Styles/images/bg.png); border-style:none">
                <thead> </thead>
                <tbody>
                    <asp:ListView ID="CategoryListView" runat="server" 
                    DataSourceID="CategorySqlDataSource" 
                    onitemcommand="CategoryListView_ItemCommand"
                    onItemDataBound="CategoryListView_ItemBound"> 
                   
                                
                    <ItemTemplate>
                        <tr>                        
                            <td style="width:50%"><h1 style="color:#4a4a4a;   text-align:center; margin-top:80px"> <%# MyDecoder.DecodeText(DataBinder.Eval(Container.DataItem, "Name").ToString())%> </h1> </td>
                            <td>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Category.aspx?cat_id=" + DataBinder.Eval(Container.DataItem, "Id") %>'>
                                   <img alt="nu este" src="<%#DataBinder.Eval(Container.DataItem,"Poza") %>"  height="200px" /> 
                                 </asp:HyperLink>
                            </td>              
                            
                            <td>
                                <asp:HiddenField ID="ItemId" runat="server" />
                                
                                <asp:HiddenField ID="ItemContent" runat="server" />

                                <asp:LoginView ID="CategoryLoginView" runat="server" OnViewChanged="CategoryLoginView_ChangedView">
                                    <RoleGroups>
                                        <asp:RoleGroup Roles="Admin">
                                            <ContentTemplate>
                                                <asp:Button ID="EditCategoryButton" runat="server" Text="Editeaza"
                                                    CommandName="EditCategory" CssClass="btn btn-info" />
                                                <asp:Button ID="DeleteCategoryButton" runat="server" Text="Sterge"
                                                    CommandName="DeleteCategory" CssClass="btn btn-info" />
                                                <asp:Literal ID="EditCategoryResponse" runat="server"> </asp:Literal>
                                                <asp:Literal ID="DeleteCategoryResponse" runat="server"> </asp:Literal>                           
                                                </ContentTemplate>
                                            </asp:RoleGroup>
                                        </RoleGroups>
                                </asp:LoginView>
                            </td>
                         </tr>
                    </ItemTemplate>
                </asp:ListView>
               </tbody>
            </table>
        </div>
    
        <!-- PAGINATIE -->
        <div class="pagination">
            <asp:DataPager ID="CategoryDataPager" runat="server" 
                PagedControlID="CategoryListView" PageSize="2">
                <Fields>
                        <asp:NumericPagerField />
                </Fields>
            </asp:DataPager>
        </div>                
    </div>
  
    <!-- ADAUGA CATEGORIE -->          
    <div >
        <asp:LoginView ID="AddCategoryLoginView" runat="server">
            <RoleGroups>
                <asp:RoleGroup Roles="Admin">
                    <ContentTemplate>
  
                    <div id="EditCategoryDiv" runat="server" style="display:none; margin-left:750px;">
                        <h3> Editeaza Categorie </h3>
                        <div>
                            <asp:HiddenField ID="EditCategoryID" runat="server" />
                            <asp:TextBox ID="EditCategoryTB" runat="server"></asp:TextBox>
                            <asp:Button ID="EditCategoryButton" runat="server" Text="Salveaza" 
                                onclick="EditCategory" ValidationGroup="EditCategoryVG" CssClass="btn btn-info" />
                            <asp:Button ID="CancelEdit" runat="server" Text="Renunta" CssClass="btn btn-info" />
                        </div>

                        <div>
                            <asp:RequiredFieldValidator ID="EditCategoryRFV" runat="server" 
                            ErrorMessage="Numele trebuie sa fie nevid!" ControlToValidate="EditCategoryTB"
                            ValidationGroup="EditCategoryVG"></asp:RequiredFieldValidator> 
                        </div>

                        <div>
                            <asp:Literal ID="EditCategoryResponse" runat="server"> </asp:Literal>                                    
                        </div>
                    </div>


                    <div id="AddCategoryDiv" runat="server" style="margin-left:50px;">
                        <h3> Adauga Categorie </h3>
                        
                        <div>
                            <asp:TextBox ID="NameTB" runat="server"></asp:TextBox>
                            <asp:FileUpload ID="PozaCat" runat="server"> </asp:FileUpload>
                        </div>

                        <hr />

                        <div>
                             <asp:Button ID="AddCategoryButton" runat="server" Text="Adauga categorie" 
                                onclick="AddCategory" ValidationGroup="AddCategoryVG" CssClass="btn btn-info" />
                        </div>
                             
                        <div>
                            <asp:RequiredFieldValidator ID="NameRFV" runat="server" 
                            ErrorMessage="Numele trebuie sa fie nevid!" ControlToValidate="NameTB" 
                            ValidationGroup="AddCategoryVG"></asp:RequiredFieldValidator>
                        </div>
                        <div>
                            <asp:Literal ID="AddCategoryResponse" runat="server"></asp:Literal>
                        </div>
                    </div>
                
                   </ContentTemplate>
                </asp:RoleGroup>
            </RoleGroups>
        
        </asp:LoginView>
    </div>


    
</asp:Content>
 