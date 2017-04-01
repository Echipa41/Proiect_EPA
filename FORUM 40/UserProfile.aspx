<%@ Page Title="" Language="C#" MasterPageFile="~/MPAll.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    
    <style type="text/css">
        .picture 
        {
            float:left;
        }
    
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div style="width:300px">
        <asp:Label ID="UserNameLabel" runat="server"></asp:Label>
        <asp:Image ID="PozaImg" runat="server" Height="400px" Width="300px" CssClass="picture" />
    </div>

    <div style="position:absolute; left:610px">
        
        <div id="ProfileView" runat="server" class="ProfileView">
            <h4>
                <span class="label label-info"> Nume </span>
                &nbsp;
                <asp:Label ID="ProfileLastName" runat="server" CssClass="weel"></asp:Label>
            </h4>
            &nbsp;
            <h4>
                <span class="label label-info"> Prenume </span>
                &nbsp;
                <asp:Label ID="ProfileFirstName" runat="server"></asp:Label>
            </h4>
            &nbsp;            
            <h4>
                <span class="label label-info"> Data Nasterii </span>
                &nbsp;
                <asp:Label ID="ProfileDOB" runat="server"></asp:Label>
            </h4>
            &nbsp;
            <h4>
                <span class="label label-info"> Sex </span>
                &nbsp;
                <asp:Label ID="ProfileSex" runat="server"></asp:Label>
            </h4>
            &nbsp;
            <h4>
                <span class="label label-info"> Oras </span>
                &nbsp;
                <asp:Label ID="ProfileCity" runat="server"></asp:Label>
            </h4>
            &nbsp;
            <h4>
                <span class="label label-info"> Semnatura </span>
                &nbsp;
                <asp:Label ID="ProfileSignature" runat="server"></asp:Label>
            </h4>
            &nbsp;  &nbsp;

            <div>
                <asp:Button ID="EditProfileButton" runat="server" Text="Editeaza" 
                OnClick="ShowEditProfile" CssClass="btn btn-default" />
            </div>

        </div>
        


        <div id="EditView" runat="server">
            
            <div class="input-group">
                <span class="input-group-addon"> Nume: </span>
                <asp:TextBox ID="NumeTB" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NumeRFV" runat="server" 
                ErrorMessage="Completati numele!" ControlToValidate="NumeTB" 
                ValidationGroup="EditProfileVG"></asp:RequiredFieldValidator>
            </div>
        
            <br />

            <div class="input-group">
                <span class="input-group-addon"> Prenume: </span>
                <asp:TextBox ID="PrenumeTB" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PrenumeRFV" runat="server" 
                ErrorMessage="Completati prenumele!" ControlToValidate="PrenumeTB" 
                ValidationGroup="EditProfileVG"></asp:RequiredFieldValidator>
            </div>
            
            <br />

            <div class="input-group">
                <span class="input-group-addon"> Data nasterii: </span>
                <asp:TextBox ID="DataNasteriiTB" runat="server" ValidationGroup="EditProfileVG"></asp:TextBox> 
                <asp:CompareValidator ID="DataNasteriiCV" runat="server" 
                    ErrorMessage="Format invalid!" ControlToValidate="DataNasteriiTB" 
                    Operator="DataTypeCheck" Type="Date" Display="Dynamic"
                    ValidationGroup="EditProfileVG"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="DataNasteriiRFV" runat="server" 
                ErrorMessage="Completati data nasterii!" ControlToValidate="DataNasteriiTB" 
                ValidationGroup="EditProfileVG" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            
            <br />

            <div class="input-group">
                <span class="input-group-addon"> Sex: </span>
                <asp:RadioButtonList ID="SexRBL" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value='M'>M&nbsp;</asp:ListItem>
                    <asp:ListItem Value='F'>F&nbsp;</asp:ListItem>
                </asp:RadioButtonList>
             </div>
             <asp:RequiredFieldValidator ID="SexRFV" runat="server" 
                ErrorMessage="Completati sexul!" ControlToValidate="SexRBL" 
                ValidationGroup="EditProfileVG"></asp:RequiredFieldValidator>
            
            <br />

            <div class="input-group">
                <span class="input-group-addon"> Oras: </span>
                <asp:TextBox ID="OrasTB" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="OrasRFV" runat="server" 
                ErrorMessage="Completati orasul!" ControlToValidate="OrasTB" 
                ValidationGroup="EditProfileVG"></asp:RequiredFieldValidator>
            </div>
            
            <br />

            <div class="input-group">
                <span class="input-group-addon"> Semnatura: </span>
                <asp:TextBox ID="SemnaturaTB" runat="server"></asp:TextBox>
            </div>
            
            <br />

            <div>
                <span> Poza profil: </span>
                <asp:FileUpload ID="PozaFU" runat="server"> </asp:FileUpload>
            </div>

            <br />

            <asp:Button ID="SaveProfileButton" runat="server" Text="Salveaza Profil" 
            onclick="SaveProfileButton_Click" ValidationGroup="EditProfileVG" CssClass="btn btn-default" />

            <asp:Button ID="CancelSaveProfileButton" runat="server" Text="Renunta"
             OnClick="HideEditProfile" ValidationGroup="CancelEditProfileVG" CssClass="btn btn-default" />
        </div>
    </div>
</asp:Content>

