<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginTrabajador.aspx.cs" Inherits="BuenosAiresWeb.GUI.LoginTrabajador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-lg" style="margin-top:3%; width:30%; border:solid; border-width:1px; border-color:gainsboro;">
                <br />
                <h4 style="color:black" >Inicia Sesión</h4>
                <small>Debes iniciar sesión para ver tus solicitudes</small>
                <br />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder> 
                <br />
                <asp:Label runat="server" style="font-size:20px" >Email</asp:Label>
                <asp:TextBox runat="server" ID="TxtEmail" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator ID="ValidadorEmail" runat="server" ControlToValidate="TxtEmail" CssClass="text-danger" ErrorMessage="El email es requerido" />
                 <br />
                <asp:Label runat="server" style="font-size:20px">Contraseña</asp:Label>
                <asp:TextBox runat="server" ID="TxtPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="ValidadorClave" runat="server" ControlToValidate="TxtPassword" CssClass="text-danger" ErrorMessage="La contraseña es requerida" />
                <br />
                <div class="checkbox">
                <asp:CheckBox runat="server" ID="RememberMe" />
                <asp:Label runat="server" AssociatedControlID="RememberMe">Recordarme</asp:Label>
                </div>
                <asp:Button ID="BtnIngresar" runat="server" Text="Ingresar" class="btn btn-primary btn-block" OnClick="BtnIngresar_Click"  /><div class="modal-footer">
                </div>
            </div>
</asp:Content>
