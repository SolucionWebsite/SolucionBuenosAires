<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleSolicitudes.aspx.cs" Inherits="BuenosAiresWeb.GUI.DetalleSolicitudes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="Container" style="border:1px solid gainsboro">
        <div class="container" style="margin:20px">
            <br />
            <h6>Solicitud <asp:Label ID="LblSolicitud" Text="" runat="server" /></h6>
            <br />
            <p>Cliente <asp:Label ID="LblCliente" Text="" runat="server" /></p>
            <p>Email <asp:Label ID="LblEmail" Text="" runat="server" /></p>
            <p>Teléfono <asp:Label ID="LblTelefono" Text="" runat="server" /></p>
            <p>Dirección <asp:Label ID="LblDireccion" Text="" runat="server" /></p>
            <p><asp:Label ID="LblModalidad" Text="" runat="server" /></p>
            <p>Fecha programada <asp:Label ID="LblFecha" Text="" runat="server" /></p>
            <p>Requerimiento: <asp:Label ID="LblRequerimiento" Text="" runat="server" /></p>
        </div>
        <br />
    </div>
</asp:Content>
