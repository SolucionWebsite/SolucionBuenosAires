<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagoOnline.aspx.cs" Inherits="BuenosAiresWeb.GUI.PagoOnline" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="essss">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">

    <title>OnlinePago</title>
    <style>
        .TextBox{
            outline-color: darkorange;
            height:30px;
            border-radius:5px;
            border: 1px solid lightgrey;
            line-height:30px;
            text-indent:10px;
            width: 100%;
        
        }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <div class="container" style="width:60%; border:1px solid darkorange; align-content:center">
                <asp:Panel runat="server" style="margin:20px;" >
                    <h3>OnlinePago</h3>
                    <table>
                        <tr>
                            <td><h5>Estás comprando en </h5></td>
                            <td><h5 style="color:dodgerblue;">Buenos Aires</h5></td>
                        </tr>
                        <tr>
                            <td style="text-align:right;"><h5>Total a pagar: </h5></td>
                            <td>
                                <h5><asp:Label ID="LblTtotal" Text="" runat="server" /></h5></td>
                        </tr>
                    </table>
                    <br />
                    <div class="container" style="width:50%" >
                        <h5>Método de pago</h5>
                        <asp:DropDownList ID="CmbPago" runat="server" CssClass="TextBox" AutoPostBack="true" AppendDataBoundItems="true"  OnSelectedIndexChanged="Pago">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Panel ID="PanelDebito" runat="server" Visible="false">
                            <asp:DropDownList ID="CmbBanco" runat="server" CssClass="TextBox">
                            <asp:ListItem Text="Selecciona banco" />
                            <asp:ListItem Text="Banco Estado" />
                            <asp:ListItem Text="Banco BCI" />
                            <asp:ListItem Text="Banco Scotiabank" />
                        </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="CmbBanco" Display="Dynamic"></asp:RequiredFieldValidator>
                            
                            <br />
                            <br />
                            <asp:TextBox ID="TxtRut" MaxLength="10" CssClass="TextBox" placeholder="Ingrese su rut" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TxtRut" Display="Dynamic"></asp:RequiredFieldValidator>
                            <br />
                            <br />
                            <asp:TextBox ID="TxtClave" TextMode="Password" MaxLength="4" CssClass="TextBox" placeholder="Ingrese su clave" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TxtClave" Display="Dynamic"></asp:RequiredFieldValidator>
                            
                            <br />
                            <br />
                            <asp:Panel ID="PanelClave" runat="server">
                                <h6>Coordenadas</h6>
                                <div class="row">
                                    <div class="col"><asp:TextBox ID="TxtCoo1" CssClass="TextBox" placeholder="H1" MaxLength="2" runat="server" /></div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="*" ControlToValidate="TxtCoo1" Display="Dynamic"></asp:RequiredFieldValidator>
                           
                                    <div class="col"><asp:TextBox ID="TxtCoo2" CssClass="TextBox" placeholder="J8" MaxLength="2" runat="server" /></div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ErrorMessage="*" ControlToValidate="TxtCoo2" Display="Dynamic"></asp:RequiredFieldValidator>
                           
                                    <div class="col"><asp:TextBox ID="TxtCoo3" CssClass="TextBox" placeholder="J5" MaxLength="2" runat="server" /></div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server" ErrorMessage="*" ControlToValidate="TxtCoo3" Display="Dynamic"></asp:RequiredFieldValidator>
                           
                                </div>
                                <br />
                                <asp:Button ID="BtnPagar1" Text="Aceptar" runat="server" class="btn btn-success btn-block" OnClick="BtnPagar1_Click"/>
                            </asp:Panel>
                        </asp:Panel>
                        <asp:Panel ID="PanelCredito" runat="server" Visible="false">
                            <div class="row">
                                <div class="col">
                                     <asp:TextBox ID="TxtNumero" CssClass="TextBox" OnTextChanged="TxtNumero_TextChanged" MaxLength="10" placeholder="Ingrese su número de tarjeta" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TxtNumero" Display="Dynamic"></asp:RequiredFieldValidator>
                            
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col">
                                    <asp:TextBox ID="TxtFecha"  AutoCompleteType="None" CssClass="TextBox" MaxLength="5" placeholder="Fecha vencimiento" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="Red" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TxtFecha" Display="Dynamic"></asp:RequiredFieldValidator>
                            
                                </div>
                                <div class="col">
                                     <asp:TextBox ID="TxtCodigo" CssClass="TextBox" MaxLength="3" placeholder="Código seguridad" runat="server" AutoCompleteType="None" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ForeColor="Red" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TxtCodigo" Display="Dynamic"></asp:RequiredFieldValidator>
                            
                                </div>
                            </div>
                            <br />
                                <asp:Button ID="BtnPagar2" Text="Aceptar" runat="server" class="btn btn-success btn-block" OnClick="BtnPagar2_Click"/>
                        </asp:Panel>
                    </div>
                </asp:Panel>
            </div>
            
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
</body>
</html>
