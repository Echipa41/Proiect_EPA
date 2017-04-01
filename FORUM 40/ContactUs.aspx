<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" MasterPageFile="~/MPAll.master" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">



    <div style="font-family:Cambria; margin-top:20px">
        <fieldset >
            <legend style="font-size:xx-large;">Contact Us </legend>
           
    <div style="margin-top:20px; font-family:Century Gothic; font-size:larger">
        Contacteaza-ne, trimitandu-ne parerea ta completand scrisoarea de mai jos! 
        Feedback-ul tau este foarte important pentru noi!
    </div>

            <div style="margin-left:350px; margin-top:10px">
             <p style="font-family:Monotype Corsiva; font-size:x-large;"><b>Buna Roxana,  </b></p>
            </div>
                       
            <table style="margin-left:100px">
            
                <tr>
                    <td style="padding:20px">
                        <b>Numele meu este</b>
                    </td>
                    
                    <td>
                         <asp:TextBox ID="txtName" Width="500px" runat="server" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                        runat="server" ErrorMessage="Name is required"
                        ControlToValidate="txtName"
                        Text="*" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

           
                <tr>
                    <td style="padding:20px">
                        <b>si ma poti gasi la email-ul</b>
                    </td>

                    <td>
                         <asp:TextBox ID="txtEmail" Width="500px" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                        runat="server" ErrorMessage="Email is required"
                        ControlToValidate="txtEmail"
                        Display="Dynamic"
                        Text="*" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                       
                    </td>
                </tr>

                  <tr>
                    <td style="padding:20px">
                        <b>Iti trimit un mesaj cu subiectul</b>
                    </td>

                    <td>
                         <asp:TextBox ID="txtSubject" Width="500px" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                        runat="server" ErrorMessage="Subject is required"
                        ControlToValidate="txtSubject"
                        Text="*" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                  <tr>
                        <td style="vertical-align:top;padding:20px">
                            <b>in care iti scriu:</b>
                        </td>

                        <td style="vertical-align:top">
                             <asp:TextBox ID="txtComments" Width="500px" runat="server" MaxLength="10" 
                                 Rows="5" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td style="vertical-align:top">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                            runat="server" ErrorMessage="Comentariile sunt obligatorii"
                            ControlToValidate="txtComments"
                            Text="*" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                </tr>
                <tr>
                    <td colspan="3">
                       
                    </td>
                </tr>

                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label1" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
               
            </table>

            <div style="margin-left:323px; margin-top:10px">
                <asp:Button ID="Button1" runat="server" Text="Trimite" 
                    onclick="Button1_Click" class="btn btn-info"/>
                              
            </div>
            
              

         <div style="margin-left:350px; margin-top:30px">
            Sau, ma poti gasi si aici: 
            <a href="https://www.facebook.com/roxana.a.sirghie" target="_blank"><img src="Styles/images/facebook_logo.jpg"</a>
            <a href="https://twitter.com/s_roxana92" target="_blank"><img src="Styles/images/twitter.jpg"</a>

         </div>
        </fieldset>
        </div>


</asp:Content>
