<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BuenosAiresWeb.GUI.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container-lg" style="margin-top:3%; width:45%; border:solid; border-width:1px; border-color:gainsboro;">
                <br />
                <h4 style="color:black" >Inicia Sesión</h4>
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder> 
                <br />
                <asp:Label runat="server" style="font-size:20px" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="The email field is required." />
                 <br />
                <asp:Label runat="server" style="font-size:20px" AssociatedControlID="Password" CssClass="col-md-2 control-label">Contraseña</asp:Label>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                <br />
                <div class="checkbox">
                <asp:CheckBox runat="server" ID="RememberMe" />
                <asp:Label runat="server" AssociatedControlID="RememberMe">Recordarme</asp:Label>
                </div>
                <asp:Button runat="server" OnClick="LogIn" Text="Ingresar" class="btn btn-primary"  /><div class="modal-footer">
                <h4 style="color:black">¿Aún no tienes una cuenta?</h4>
                <a href="Register.aspx" style="font-size:20px;">Regístrate</a>
                </div>
            </div>

</asp:Content>
