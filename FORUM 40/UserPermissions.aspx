<%@ Page Title="" Language="C#" MasterPageFile="~/MPAll.master" AutoEventWireup="true" CodeFile="UserPermissions.aspx.cs" Inherits="UserPermissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:SqlDataSource ID="UsersSqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        SelectCommand=
        "SELECT aspnet_Users.UserId as [UserId], [UserName], [RoleName] FROM [aspnet_UsersInRoles]
         INNER JOIN aspnet_Users on aspnet_Users.UserId = aspnet_UsersInRoles.UserId
         INNER JOIN aspnet_Roles on aspnet_Roles.RoleId = aspnet_UsersInRoles.RoleId">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="RolesSqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        SelectCommand="SELECT [RoleId], [RoleName] FROM [vw_aspnet_Roles]">
    </asp:SqlDataSource>

    <div style="width:60%; margin-top:70px; margin-left:180px">
        <div class="panel panel-default">
            <div class="panel-heading"> <b>Membri</b> </div>
        
            <table class="table">
                <thead> </thead>
            
                <tbody>
            
                    <asp:ListView ID="UsersRoleListView" runat="server" 
                    DataSourceID="UsersSqlDataSource"
                    onitemcommand="UserRoleListView_ItemCommand"
                    onItemDataBound="UsersRoleListView_ItemBound">

                    <ItemTemplate>
                        <tr>
                            <td> 
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/UserProfile.aspx?UserName=" + DataBinder.Eval(Container.DataItem, "UserName")   %>'>
                                    <%# DataBinder.Eval(Container.DataItem, "UserName") %>    
                                </asp:HyperLink>
                            </td>
                            <td> <%# DataBinder.Eval(Container.DataItem, "RoleName") %> </td>
                
                            <asp:HiddenField ID="ItemUserNameHF" runat="server" />
                            <asp:LoginView ID="UsersRoleLoginView" runat="server" OnViewChanged="UsersRoleLoginView_ViewChanged">
                                <RoleGroups>
                                    <asp:RoleGroup Roles="Admin">
                                        <ContentTemplate>
                                            <td>
                                                <asp:DropDownList ID="RolesDropDownList" runat="server" CssClass="select-dropdown-menu"
                                                DataSourceID="RolesSqlDataSource" DataTextField="RoleName" DataValueField="RoleName"  >
                                                </asp:DropDownList>   
                                            </td>
                                            <td>
                                                <asp:Button ID="EditUserRoleButton" runat="server" Text="Salveaza"
                                                CommandName="EditUserRole" CssClass="btn btn-warning" />
                                                <asp:Literal ID="EditUserRoleResponse" runat="server"></asp:Literal>
                                            </td>
                                        </ContentTemplate>    
                                    </asp:RoleGroup>
                                </RoleGroups>

                            </asp:LoginView>
                         </tr>    
                    </ItemTemplate>
                </asp:ListView>

             </tbody>     
          </table>
        </div>
        <!-- PAGINATIE -->
        <div class="pagination">
            <asp:DataPager ID="UsersDataPager" runat="server" 
                PagedControlID="UsersRoleListView" PageSize="5">
                <Fields>
                        <asp:NumericPagerField />
                </Fields>
            </asp:DataPager>
        </div>
    </div>
    

</asp:Content>

