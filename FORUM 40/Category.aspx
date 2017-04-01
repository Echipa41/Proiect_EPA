<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Category" MasterPageFile="~/MPAll.master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
    
    <asp:SqlDataSource ID="PicturesDataSource" runat="server"
     ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>"
     SelectCommand="SELECT * FROM [Pictures]">
     </asp:SqlDataSource>
           
                

    <!--  CATEGORIA CURENTA -->
    <h2>
        &nbsp;<asp:Repeater ID="CategoryRepeater" runat="server" DataSourceID="CurrentCategorySqlDataSource">
            <ItemTemplate>
                <div>
                   Subiectele din categoria:  <%# MyDecoder.DecodeText(DataBinder.Eval(Container.DataItem, "Name").ToString()) %> 
                </div>    
            </ItemTemplate>    
        </asp:Repeater>
    </h2>

    
     <asp:DataList ID="DataList1" RepeatColumns="3" RepeatDirection="Horizontal" runat="server"
        DataSourceID="PicturesDataSource" Style="margin-right: 21px" Width="387px" CellPadding="10">
        <ItemTemplate>
            <div style="padding: 30px 65px 30px 30px; margin-left:30px ">
                <a href="Subject.aspx?sub_id=<%#DataBinder.Eval(Container.DataItem,"PictureId") %>">
                    <img alt="<%#DataBinder.Eval(Container.DataItem,"nume") %>" src="<%#DataBinder.Eval(Container.DataItem,"Locatie") %>"
                        height="200px" />
                    <span class="portfoliohover">
                        <h3 class="porthover1">
                            <%#DataBinder.Eval(Container.DataItem,"Nume") %></h3>
                    </span></a><span class="portfoliohover">
                      <p>
                            Uploaded by
                            <%#DataBinder.Eval(Container.DataItem,"UserName") %></p>
                    </span>
              
           </div>
        </ItemTemplate>
    </asp:DataList>
    

 </asp:Content>



