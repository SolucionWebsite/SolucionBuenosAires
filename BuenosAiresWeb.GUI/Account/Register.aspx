<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BuenosAiresWeb.GUI.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script type="text/javascript"></script>
        <script src="js/sweetAlert.js" ></script>
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
        <script src="sweetalert2.all.min.js"></script>
    <script>
        function Invalido() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Este email ya se encuentra vinculado a una cuenta',
                footer: '<a href>Recuperar mi contraseña</a>'
            });
        }
        function Valido() {
            Swal.fire({
                  title: 'Ya tienes tu cuenta!',
                  icon: 'success',
                  showCancelButton: true,
                  confirmButtonText: 'Entrar!',
                  reverseButtons: true
                }).then((result) => {
                  if (result.value) {
                    window.location.href = "/Carrito";
                  } 
            });
        }
    </script>
    <div class="container-lg" style="margin-top:2%; width:45%; border:solid; border-width:1px; border-color:gainsboro;"> 
        <p class="text-danger"><asp:Literal runat="server" ID="ErrorMessage" /></p>

    <div class="form-horizontal">
        <h4>Regístrate</h4>
        <hr />
        <table>
            <tr>
                <td style="width: 126px"><asp:Label runat="server" AssociatedControlID="TxtNombres" CssClass="col-md-2 control-label">Nombres</asp:Label></td>
                <td style="width: 386px"><asp:TextBox runat="server" ID="TxtNombres" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtNombres" CssClass="text-danger" ErrorMessage="El nombre es requerido." /></td>
            </tr>
            <tr>
                <td style="width: 126px"><asp:Label runat="server" AssociatedControlID="TxtApellidos" CssClass="col-md-2 control-label">Apellidos</asp:Label></td>
                <td style="width: 386px"><asp:TextBox runat="server" ID="TxtApellidos" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtApellidos" CssClass="text-danger" ErrorMessage="El apellido es requerido." /></td>
            </tr>
            <tr>
                <td style="width: 126px"><asp:Label runat="server" AssociatedControlID="TxtRut" CssClass="col-md-2 control-label">Rut</asp:Label></td>
                <td style="width: 386px"><asp:TextBox runat="server" ID="TxtRut" CssClass="form-control" placeholder="Ej: 11031031-k" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtRut" CssClass="text-danger" ErrorMessage="El rut es requerido." /></td>
            </tr>
            <tr>
                <td style="width: 126px"><asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label></td>
                <td style="width: 386px"><asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="El email es requerido." /></td>
            </tr>
            <tr>
                <td style="width: 126px"><asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Contraseña</asp:Label></td>
                <td style="width: 386px"><asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." /></td>
            </tr>
            <tr>
                <td style="width: 126px"></td>
                <td style="width: 386px"><asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" Placeholder="Confirmar contraseña"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" CssClass="text-danger" Display="Dynamic" ErrorMessage="La confirmación es requerida." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" CssClass="text-danger" Display="Dynamic" ErrorMessage="Las contraseñas no coinciden" /></td>
            </tr>
        </table>
        <table>
            <tr>
                    <td style="width: 100%"><small class="form-text text-muted">Tu clave debe contener una letra mayúscula, un número y un signo.</small></td>
                </tr>
        </table>
    </div>
        <asp:Button runat="server" OnClick="CreateUser_Click" Text="Registrarme" class="btn btn-primary btn-block" style="margin-top:10px" />
            
    </div>
</asp:Content>
