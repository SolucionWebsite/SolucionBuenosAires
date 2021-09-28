<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCompra.aspx.cs" Inherits="BuenosAiresWeb.GUI.DetalleCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="container" >
        <br />
        <h5>Detalle de tu compra</h5>
        <div class="container" style="border:1px solid gainsboro">
            <br />
            <div class="container" style="margin:10px">

            <table>
                <tr>
                    <td><h6>Orden de compra N° </h6></td>
                    <td><h6><asp:Label ID="LblOrden" Text="" runat="server" /></h6></td>
                    <td style="text-align:right; width:65%;"><h6>Fecha y hora de compra : </h6></td>
                    <td><h6><asp:Label ID="LblFecha" Text="" runat="server" /></h6></td>
                </tr>
            </table>
            <h6></h6>
            <h6>Dirección Envío</h6>
            <div class="container">
                <div class="row"><asp:Label ID="LblNombre" Text="" runat="server" /></div>
                <div class="row"><asp:Label ID="LblDireccion" Text="Direccion" runat="server" /></div>
                <div class="row"><asp:Label ID="LblTelefono" Text="" runat="server" /></div>
            </div>
            <br />
            <h6>Información pago</h6>
            <div class="container">
                <div class="row"><asp:Label Text="OnlinePago.cl" runat="server" /></div>
                <div class="row"><asp:Label ID="LblPago" Text="" runat="server" /></div>
                <div class="row"><asp:Label ID="LblTotal" Text="" runat="server" /></div>
                <div class="row"><asp:Label Text="Pagado" runat="server" /></div>
                <div class="row"><asp:Label ID="LblRecibo" Text="" runat="server" /></div>
            </div>
            <br />
            <h6>Resumen productos</h6>

            <asp:GridView ID="GrdProductos" runat="server" class="table table-bordered" style="margin-top:20px;">

            </asp:GridView>
                <asp:Repeater  id="Repeater1" runat="server" EnableVIewState = "true">
                    <ItemTemplate>
                        <div class="row">
                                          <div class="card" style="width:100%; margin-top:10px; margin-left:15px; margin-right:30px;">
                                          <div class="row">
                                          <div class="col-2">
                                            <img src="<%# DataBinder.Eval(Container.DataItem, "Imagen")%>" style="width:120px; height:100px;">
                                            </div>
                                            <div class="col-4">
                                                <p style="font:bold 15px arial; margin-top:40px;"><%# DataBinder.Eval(Container.DataItem, "Producto") %></p>
                                                
                                            </div>
                                            <div class="col-2">
                                                <p style="font:16px arial; margin-top:40px;"><%# DataBinder.Eval(Container.DataItem, "Cantidad") %></p>
                                            </div>
                                            <div class="col-2">
                                                <p style="font:17px arial; margin-top:40px;"><%# DataBinder.Eval(Container.DataItem, "Precio") %></p>
                                                </div>
                                            <div class="col-2">
                                                <p style="font:17px arial; margin-top:40px;"><%# DataBinder.Eval(Container.DataItem, "Total") %></p>
                                            </div>
                                            </div>
                                            </div>
                                            </div>
                    </ItemTemplate>
                </asp:Repeater>
             <br />
                <table>
                    <tr>
                        <td>
                            <h6>Subtotal: </h6>
                        </td>
                        <td>
                                <asp:Label ID="LblSubtotal" Text="" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Cupon: </h6>
                        </td>
                        <td>
                                <asp:Label ID="LblCupon" Text="" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Descuento: </h6>
                        </td>
                        <td>
                                <asp:Label ID="LblDescuento" Text="" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Envío: </h6>
                        </td>
                        <td>
                                <asp:Label ID="LblEnvio" Text="" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h6>Total: </h6>
                        </td>
                        <td>
                                <asp:Label ID="LblTotal2" Text="" runat="server" />
                        </td>
                    </tr>
                </table>
                <br />
        </div>
            
            </div>
    </div>
</asp:Content>
