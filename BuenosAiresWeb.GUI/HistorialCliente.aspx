<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistorialCliente.aspx.cs" Inherits="BuenosAiresWeb.GUI.HistorialCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h4>Mi historial</h4>
    <div class="container" style="border: 1px solid gainsboro;">
        <br />
        <h5>Mis pedidos</h5>
        <br />
        <div class="container" style="border: 1px solid gainsboro;" >
        <div class="row" style="margin-top:12px">
                    <div class="col-2"><p style="font:bold 15px arial;">Orden compra</p>
                    </div>
                    <div class="col-2"><p style="font:bold 15px arial;">Fecha y hora</p>
                                                </div>
                    <div class="col-3"><p style="font:bold 15px arial;">Cliente</p>
                                                </div>
                    <div class="col-2"><p style="font:bold 15px arial;">Total venta</p>
                                                </div>
                    <div class="col-2"><p style="font:bold 15px arial;">Estado</p>
                                                </div>
                </div>
         </div>
        <div class="container" style="border: 1px solid gainsboro;" >
        <asp:Repeater ID="Repeater1" OnItemCommand="R1_ItemCommand" runat="server" EnableVIewState = "true">
            <ItemTemplate>  
                <div class="row" style="height:30px; margin-top:12px">
                    <div class="col-2">
                        <asp:Label ID="LblOrden" Text='<%# DataBinder.Eval(Container.DataItem, "Orden_compra") %>' runat="server" />
                    </div>
                    <div class="col-2"><p style="font:15px arial;"><%# DataBinder.Eval(Container.DataItem, "Fecha") %></p>
                                                </div>
                    <div class="col-3"><p style="font:15px arial;"><%# DataBinder.Eval(Container.DataItem, "Nombre") %></p>
                                                </div>
                    <div class="col-2"><p style="font:15px arial;"><%# DataBinder.Eval(Container.DataItem, "Total") %></p>
                                                </div>
                    <div class="col-2"><p style="font:15px arial;"><%# DataBinder.Eval(Container.DataItem, "Estado") %></p>
                                                </div>
                    <div class="col-1"><asp:LinkButton ID="BtnDetalle" runat="server">Detalle</asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
            </div>
        <br />
        <br />
        <h5>Mis solicitudes</h5>
        <div class="container" style="border: 1px solid gainsboro; background-color:gainsboro;" >
        <div class="row" style="margin-top:13px">
                    <div class="col-1"><p style="font:bold 15px arial;">Solicitud</p>
                    </div>
                    <div class="col-3"><p style="font:bold 15px arial;">Cliente</p>
                                                </div>
                    <div class="col-3"><p style="font:bold 15px arial;">Contacto</p>
                                                </div>
                    <div class="col-2"><p style="font:bold 15px arial;">Servicio</p>
                                                </div>
                    <div class="col-2"><p style="font:bold 15px arial;">Fecha</p>
                                                </div>
                    <div class="col-1"><p style="font:bold 15px arial;"></p>
                                                </div>
                </div>
         </div>
        <div class="container" style="border: 1px solid gainsboro;" >
        <asp:Repeater ID="Repeater2" OnItemCommand="R1_ItemCommand"  runat="server" EnableVIewState = "true">
            <ItemTemplate>  
                <div class="row" style="height:70px; margin-top:13px">
                    <div class="col-1">
                        <asp:Label ID="LblId" Text='<%# DataBinder.Eval(Container.DataItem, "Id") %>' runat="server" />
                    </div>
                    <div class="col-3"><p style="font:15px arial;"><%# DataBinder.Eval(Container.DataItem, "Nombre") %></p>
                                                </div>
                    <div class="col-3"><p style="font:15px arial;"><%# DataBinder.Eval(Container.DataItem, "Email") %></p>
                                                </div>
                    <div class="col-2"><p style="font:15px arial;"><%# DataBinder.Eval(Container.DataItem, "Modalidad") %></p>
                                                </div>
                    <div class="col-2"><p style="font:15px arial;"><%# DataBinder.Eval(Container.DataItem, "Fecha") %></p>
                </div>
                    <div class="col-1"><asp:LinkButton ID="BtnDetalle" runat="server" style="margin-bottom:7px">Detalle</asp:LinkButton>
                    </div>
            </ItemTemplate>
        </asp:Repeater>

            </div>
    </div>
</asp:Content>
