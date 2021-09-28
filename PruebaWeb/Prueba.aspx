<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="PruebaWeb.Prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-top:30px;">
            Consulta Solicitudes por trabajador
            <asp:GridView ID="GrdSolicitudes" runat="server"></asp:GridView>

           
        </div>
        <div style="margin-top:30px;">   
             <br />
            Detalle compra 
            <asp:GridView ID="GrdCompra" runat="server"></asp:GridView>
            Pago 
            <asp:GridView ID="GrdPago" runat="server"></asp:GridView>
            Direccion 
            <asp:GridView ID="GrdDireccion" runat="server"></asp:GridView>
            Pedido 
            <asp:GridView ID="GrdPedido" runat="server"></asp:GridView>
        </div>
        <div style="margin-top:40px;">
            <asp:DropDownList ID="CmbPago" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="CmbProveedor" runat="server"></asp:DropDownList>
            <asp:ListBox ID="LstProducto" runat="server"></asp:ListBox>
            <br />
        </div>
        <asp:FileUpload ID="FileUpload1" runat="server" />

        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <input id="Text1" type="number" />
        <asp:TextBox ID="TextBox1" Type="number" runat="server"></asp:TextBox>

    </form>
</body>
</html>
