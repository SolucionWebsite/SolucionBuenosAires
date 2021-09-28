<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistorialTrabajador.aspx.cs" Inherits="BuenosAiresWeb.GUI.HistorialTrabajador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="row">
        <div class="col">
            <h5>Especialista <asp:Label ID="LblEspecialista" Text="" runat="server" /></h5>
            </div>
    </div>
    
    <div class="container" style="border: 1px solid gainsboro;">
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
        <asp:Repeater ID="Repeater1" OnItemCommand="R1_ItemCommand"  runat="server" EnableVIewState = "true">
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
