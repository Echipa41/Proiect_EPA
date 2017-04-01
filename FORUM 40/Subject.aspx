<%@ Page Title="" Language="C#" MasterPageFile="~/MPAll.master" AutoEventWireup="true" CodeFile="Subject.aspx.cs" Inherits="Subject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

</asp:Content>



<asp:Content ID="Subject" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:SqlDataSource ID="MessageSqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        SelectCommand="SELECT * FROM [Message]">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="CurrentSubjectSqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" 
        SelectCommand="SELECT * FROM [Subject]">
    </asp:SqlDataSource>
    

    <!-- SUBIECTUL CURENT -->
    <h1>
        &nbsp;<asp:Repeater ID="SubjectRepeater" runat="server" DataSourceID="CurrentSubjectSqlDataSource">
            <ItemTemplate>
                <div>
                    <span> <%# MyDecoder.DecodeText(DataBinder.Eval(Container.DataItem, "Nume").ToString())%> </span>
                </div>    
            </ItemTemplate>
        </asp:Repeater>
    </h1>

    <!-- MESAJELE DIN SUBIECTUL CURENT -->
    <div style="width:55%;float:left;">
        <asp:ListView ID="MessageListView" runat="server" 
            DataSourceID="MessageSqlDataSource"
            onitemcommand="MessageListView_ItemCommand"
            onItemDataBound="MessageListView_ItemBound">
            
            <ItemTemplate>
                <div> 
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="panel-title"> 
                                <span> Autor: 
                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/UserProfile.aspx?UserName=" + DataBinder.Eval(Container.DataItem, "UserName")   %>'>
                                        <%# DataBinder.Eval(Container.DataItem, "UserName") %>    
                                    </asp:HyperLink>
                                </span>
                                |<span> Data: <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "Date").ToString()).ToShortDateString() %> </span>
                                |<span> Actualizat: <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "LastUpdate").ToString()).ToShortDateString() %> </span>
                                |<span> Categorie: 
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Category.aspx?cat_id=" + DataBinder.Eval(Container.DataItem, "CategoryId") %>'>
                                        <%# DataBinder.Eval(Container.DataItem, "CategoryName") %>    
                                    </asp:HyperLink>
                                </span>
                                <span>
                                    <asp:HiddenField ID="ItemContentHF" runat="server" />
                                    <asp:LoginView ID="QuoteLoginView" runat="server" OnViewChanged="QuoteLoginView_ViewChanged">
                                        <LoggedInTemplate>
                                            <asp:Literal ID="QuoteMessageDescription" runat="server"> </asp:Literal>
                                            <asp:Button ID="QuoteMessageButton" runat="server" Text="Citeaza" 
                                            CommandName="QuoteMessage" CssClass="btn btn-default" />
                                        </LoggedInTemplate>
                                    </asp:LoginView>                     
                                </span>
                            </div>
                         </div>
                        
                        <div class="panel-body">     
                   
                            <div> 
                                 <asp:Literal ID="MessageDescription" runat="server" Text='<%# MyDecoder.DecodeText(DataBinder.Eval(Container.DataItem, "Description").ToString()) %>' > 
                                 </asp:Literal>
                            </div>

                            <div id="MessageAuthor" runat="server" style="float:right">
                                <div>
                                    <asp:Button ID="EditMessageButton" runat="server" Text="Editeaza" 
                                    CommandName="EditMessage" CssClass="btn btn-default" />
                                    <asp:Button ID="DeleteMessageButton" runat="server" Text="Sterge" 
                                    CommandName="DeleteMessage" CssClass="btn btn-default" />
                                </div>
                                <div>
                                    <asp:Literal ID="EditMessageResponse" runat="server"> </asp:Literal>
                                    <asp:Literal ID="DeleteMessageResponse" runat="server"> </asp:Literal>
                                </div>
                            </div>        
                
                            
                            <hr style="border-color:black" />
                            <asp:Label ID="MessageSignature" runat="server"></asp:Label>
                       
                        </div>
                    </div>
                </div> 
            </ItemTemplate>
        </asp:ListView>
    
        <div class="pagination">
            <asp:DataPager ID="MessageDataPager" runat="server" 
                PagedControlID="MessageListView" PageSize="4">
                <Fields>
                    <asp:NumericPagerField />
                </Fields>
            </asp:DataPager>
        </div>
    
    </div>
    
    <!-- FILTRU -->
    <div style="position:absolute; left:60%">
        <h1> Filtru </h1>
        <div>
            <div class="input-group">
                <span class="input-group-addon">
                    <asp:Label ID="MessageUserLabel" runat="server" Text="Utilizator"></asp:Label>
                </span>
                <asp:TextBox ID="MessageUserTB" runat="server"></asp:TextBox>
            </div>
            
            <br />

            <div class="input-group">
                <span class="input-group-addon">
                    <asp:Label ID="MessageDescriptionLabel" runat="server" Text="Continut"></asp:Label>
                </span>
                <asp:TextBox ID="MessageDescriptionTB" runat="server"></asp:TextBox>
            </div>

            <br />

            <div class="input-group">
                <asp:RadioButtonList ID="MessageDateRBL" runat="server">
                    <asp:ListItem Value="Ascending"> Crescator dupa data</asp:ListItem>
                    <asp:ListItem Value="Descending">Descrescator dupa data </asp:ListItem>
                </asp:RadioButtonList>
            </div>
            
            <asp:Button ID="Button2" runat="server" Text="Cauta" ValidationGroup="MessageFilterVG" 
                onclick="SearchMessage_Click" CssClass="btn btn-default" />
        </div>

        <br /> <br />

        <!-- ADAUGA MESAJ -->
        <asp:LoginView ID="AddMessageLoginView" runat="server">
            <LoggedInTemplate>

                <div id="EditMessageDiv" runat="server" style="display:none">
                    <h1> Editeaza comentariu </h1>
                    
                    <div>
                        <img src="Emoticons/bold.png" class="format-text" start-tag="[b]" end-tag="[/b]" />
                        <img src="Emoticons/italic.png" class="format-text" start-tag="[i]" end-tag="[/i]" />
                        <img src="Emoticons/underline.png" class="format-text" start-tag="[u]" end-tag="[/u]" />
                        
                        <img src="Emoticons/smile.png" class="emoticon" code=":D" />
                        <img src="Emoticons/happy.png" class="emoticon" code=":)" />
                        <img src="Emoticons/laugh.png" class="emoticon" code=":))" />
                        <img src="Emoticons/sad.png" class="emoticon" code=":(" />
                        <img src="Emoticons/cry.png" class="emoticon" code=":((" />
                        <img src="Emoticons/angry.png" class="emoticon" code="~X(" />

                        <asp:HiddenField ID="EditMessageID" runat="server" />
                        <asp:TextBox ID="EditMessageTB" runat="server" TextMode="MultiLine"  Rows="10" Columns="65"></asp:TextBox>
                    </div>
                    
                    <div>
                        <asp:RequiredFieldValidator ID="EditMessageRFV" runat="server" 
                            ErrorMessage="Comentariul trebuie sa fie nevid!" ControlToValidate="EditMessageTB"
                            ValidationGroup="EditMessageVG"></asp:RequiredFieldValidator>
                    </div>

                    <div>
                        <asp:Button ID="EditMessageButton" runat="server" Text="Salveaza" 
                            onclick="EditMessage" ValidationGroup="EditMessageVG" CssClass="btn btn-default" />
                        <asp:Button ID="CancelEdit" runat="server" Text="Renunta" CssClass="btn btn-default" />
                    </div>
                    
                    <div>
                        <asp:Literal ID="EditMessageResponse" runat="server"> </asp:Literal>                                    
                    </div>
                </div>

                <div id="AddMessageDiv" runat="server">
                    <h1> Adauga Comentariu </h1>
                    
                    <div>
                        <img src="Emoticons/bold.png" class="format-text" start-tag="[b]" end-tag="[/b]" />
                        <img src="Emoticons/italic.png" class="format-text" start-tag="[i]" end-tag="[/i]" />
                        <img src="Emoticons/underline.png" class="format-text" start-tag="[u]" end-tag="[/u]" />
                        
                        <img src="Emoticons/smile.png" class="emoticon" code=":D" />
                        <img src="Emoticons/happy.png" class="emoticon" code=":)" />
                        <img src="Emoticons/laugh.png" class="emoticon" code=":))" />
                        <img src="Emoticons/sad.png" class="emoticon" code=":(" />
                        <img src="Emoticons/cry.png" class="emoticon" code=":((" />
                        <img src="Emoticons/angry.png" class="emoticon" code="~X(" />

                        <asp:TextBox ID="MessageTB" runat="server" TextMode="MultiLine" Rows="10" Columns="65"></asp:TextBox>
                    </div>
               
                    <div>
                        <asp:RequiredFieldValidator ID="MessageRFV" runat="server" 
                        ErrorMessage="Comentariul trebuie sa fie nevid!" ControlToValidate="MessageTB"
                        ValidationGroup="AddMessageVG"> </asp:RequiredFieldValidator>
                    </div>
                    
                    <div>
                        <asp:Button ID="AddMessageButton" runat="server" Text="Adauga comentariu" 
                            onclick="AddMessage" ValidationGroup="AddMessageVG" CssClass="btn btn-default" />
                    </div>

                    <div>
                        <asp:Literal ID="AddMessageResponse" runat="server"></asp:Literal>
                    </div>
                </div>
            </LoggedInTemplate>
        </asp:LoginView>
    </div>
    
</asp:Content>

