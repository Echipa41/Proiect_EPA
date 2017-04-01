<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pictures.aspx.cs" Inherits="Pictures" MasterPageFile="~/MPAll.master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

</asp:Content>


<asp:Content ID="Category" ContentPlaceHolderID="MainContent" Runat="Server">
          <asp:SqlDataSource ID="PicturesSqlDataSource" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                SelectCommand="SELECT * FROM [Pictures]">
          </asp:SqlDataSource>

           <asp:SqlDataSource ID="CurrentCategorySqlDataSource" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                SelectCommand="SELECT * FROM [Category]">
           </asp:SqlDataSource>
    
            <asp:SqlDataSource ID="CategorySqlDataSource" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
                SelectCommand="SELECT [Id], [Name] FROM [Category]">
            </asp:SqlDataSource>


             <!--  CATEGORIA CURENTA -->
    <h2>
        &nbsp;<asp:Repeater ID="CategoryRepeater" runat="server" DataSourceID="CurrentCategorySqlDataSource">
            <ItemTemplate>
                <div>
                    Categorie:  <%# MyDecoder.DecodeText(DataBinder.Eval(Container.DataItem, "Name").ToString()) %> 
                </div>    
            </ItemTemplate>    
        </asp:Repeater>
    </h2>

    <!-- SUBIETELE DIN CATEGORIA CURENTA -->
    <div style="width:55%;float:left">
      <asp:ListView ID="SubjectListView" runat="server" 
        DataSourceID="PicturesSqlDataSource">
        
        <ItemTemplate>
            <div>
                <div class="panel panel-info">
                
                    <div > 
                        <div >
                            <span> Autor: 
                                  
                                     <img alt="nu este" src="<%#DataBinder.Eval(Container.DataItem,"Poza") %>"  height="200px" /> 
                              

                            </span>

                        

                         </div>
                    </div>
                    
               
                </div>
             </div> 
        </ItemTemplate>
        
        
        
        </asp:ListView>
       

</asp:Content>
