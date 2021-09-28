<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="BuenosAiresWeb.GUI.Compra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .Pestaña {
            outline-color: gainsboro;
            border-top-right-radius: 5px;
            border-top-left-radius: 5px;
            border: 2px solid dodgerblue;
            border-bottom-color: white;
            background-color:white;
            
        }
        .Panel{
            outline-color: gainsboro;
            border: 2px solid dodgerblue;
            line-height: 30px;
            background-color:white;
            width:100%
        }
        .PanelInterior{
            margin:20px;
        }
        .TextBox{
            outline-color: dodgerblue;
            height:30px;
            border-radius:5px;
            border: 1px solid lightgrey;
            line-height:30px;
            text-indent:10px;
            width: 100%;
        
        }
    </style>
    <br />
    <div class="container">
        <div class="row">
            <div class="col">
                <asp:Button ID="Btn1" Text="Método de entrega" CssClass="Pestaña"  runat="server" />
               <asp:Panel ID="Panel1" runat="server" CssClass="Panel" >
                   <asp:Panel runat="server" CssClass="PanelInterior">
                       <div class="row">
                           <div class="col">
                               <asp:RadioButton ID="RbSucursal" GroupName="Grupo" Text="Sucursal" runat="server" AutoPostBack="True" />
                           </div>
                           <div class="col">
                               <asp:RadioButton ID="RbDomicilio" GroupName="Grupo" Text="Domicilio" runat="server" AutoPostBack="True" />
                           </div>
                       </div>
                       <asp:Panel ID="Panel12" runat="server" Visible="false" >
                           <h6>Dirección envío</h6>
                           <asp:Button ID="BtnDireccion" Text="Usar mi dirección" class="btn btn-primary btn-block btn-sm" runat="server" OnClick="BtnDireccion_Click" />
                           <asp:Label  ID="ValidacionDireccion" Text="" runat="server" />
                           <br />
                       <div class="row">
                           <div class="col-8">
                               <asp:TextBox ID="TxtDireccion" runat="server" CssClass="TextBox" placeholder="Ingresar dirección" />
                               <asp:RequiredFieldValidator ValidationGroup="Direccion" ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="TxtDireccion" Display="Dynamic"></asp:RequiredFieldValidator>
                           </div>
                           <div class="col-4">
                               <asp:TextBox ID="TxtNCasa" runat="server" CssClass="TextBox" placeholder="N° Casa" />
                               <asp:RequiredFieldValidator  ValidationGroup="Direccion"  ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="TxtNCasa" Display="Dynamic"></asp:RequiredFieldValidator>
                           </div>
                       </div>
                       <div class="row" style="margin-top:10px">
                           <div class="col-6">
                               <asp:TextBox ID="TxtAlias" runat="server" CssClass="TextBox" placeholder="Alias ej:Casa" />
                           </div>
                           <div class="col-6">
                               <asp:TextBox ID="TxtTelefono" runat="server" CssClass="TextBox" placeholder="Teléfono" />
                               <asp:RequiredFieldValidator ForeColor="Red" ValidationGroup="Direccion"  ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="TxtTelefono" Display="Dynamic"></asp:RequiredFieldValidator>
                           </div>
                       </div>
                       <div class="row"  style="margin-top:10px">
                           <div class="col">
                                <asp:DropDownList ID="CmbRegion" CssClass="TextBox" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="CargarCiudad"></asp:DropDownList>
                                <asp:RequiredFieldValidator  ValidationGroup="Direccion"  ID="RequiredFieldValidator4" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="CmbRegion" Display="Dynamic"></asp:RequiredFieldValidator>
                           </div>
                       </div>
                       <div class="row" style="margin-top:10px">
                           <div class="col">
                                <asp:DropDownList ID="CmbCiudad"  CssClass="TextBox" runat="server"  AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="CargarComuna"></asp:DropDownList>
                                <asp:RequiredFieldValidator  ValidationGroup="Direccion"  ID="RequiredFieldValidator5" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="CmbCiudad" Display="Dynamic"></asp:RequiredFieldValidator>
                           </div>
                       </div>
                       <div class="row" style="margin-top:10px">
                           <div class="col">
                                <asp:DropDownList ID="CmbComuna" CssClass="TextBox" runat="server"  AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="CargarPrecio"></asp:DropDownList>
                                <asp:RequiredFieldValidator  ValidationGroup="Direccion"  ID="RequiredFieldValidator6" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="CmbComuna" Display="Dynamic"></asp:RequiredFieldValidator>
                           </div>
                       </div>
                        </asp:Panel>
                       <asp:Panel ID="Panel13" runat="server" Visible="false">
                           <asp:DropDownList ID="CmbSucursal" runat="server" CssClass="TextBox">
                               <asp:ListItem Text="Av. Pajaritos 233 - Maipú" />
                           </asp:DropDownList>
                       </asp:Panel>
                       <br />
                       <div class="row">
                           <div class="col">
                               <h6>Valor envío: </h6>
                           </div>
                           <div class="col">
                               <asp:Label ID="LblPrecio" Text="" runat="server" />
                           </div>
                       </div>
                       <div class="row">
                           <div class="col">
                               <h6>Llega el día:</h6>
                           </div>
                           <div class="col">
                               <asp:Label ID="LblFecha" Text="" runat="server" />
                           </div>
                       </div>
                       <div class="row">
                           <asp:Button ID="BtnContinuar1" Text="Continuar"  ValidationGroup="Direccion"  runat="server" class="btn btn-primary btn-block" OnClick="BtnContinuar1_Click" />
                       </div>
                   </asp:Panel>
               </asp:Panel>
            </div>
            <div class="col">
                <asp:Button  ID="Btn2" Text="Resumen compra"  CssClass="Pestaña" runat="server" />
                <asp:Panel ID="Panel2" runat="server" CssClass="Panel" >
                    <asp:Panel ID="Panel21" runat="server" CssClass="PanelInterior" Visible="false">
                        <br />
                        <table>
                            <tr>
                                <td>
                                    <h5 style="text-align:right;" >Sub total compra:</h5>
                                </td>
                                <td>
                                    <asp:Label ID="LblSubTotal" Text="" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h6 style="text-align:right;" >Descuento cupón:</h6>
                                </td>
                                <td>
                                    <asp:Label ID="LblDescuento" Text="" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h6 style="text-align:right;">Valor envío:</h6>
                                </td>
                                <td>
                                    <asp:Label ID="LblEnvio" Text="" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h5 style="text-align:right;">Total a pagar:</h5>
                                </td>
                                <td>
                                    <asp:Label ID="LblTotal" Text="" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Button ID="BtnContinuar2" Text="Continuar" runat="server" class="btn btn-primary btn-block" OnClick="BtnContinuar2_Click" />
                        <br />
                    </asp:Panel>
                </asp:Panel>
            </div>
            <div class="col">
                <asp:Button  ID="Btn3" Text="Método de pago"  CssClass="Pestaña" runat="server" />
                <asp:Panel ID="Panel3" runat="server" CssClass="Panel" >
                    <asp:Panel ID="Panel31" runat="server" CssClass="PanelInterior" Visible="false">
                        <br />
                        <h6>Deseo recibir:</h6>
                        <asp:DropDownList ID="CmbComprobante" runat="server" CssClass="TextBox" AutoPostBack="True" OnSelectedIndexChanged="CargarPago">
                            <asp:ListItem Text="Selecciona un comprobante" />
                            <asp:ListItem Text="Boleta" />
                            <asp:ListItem Text="Factura" />
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Button ID="BtnContinuar3" Text="Pagar" runat="server" class="btn btn-success btn-block" OnClick="BtnContinuar3_Click"  />
                        <br />
                    </asp:Panel>
                </asp:Panel>
            </div>
        </div>

    </div>
    
</asp:Content>
