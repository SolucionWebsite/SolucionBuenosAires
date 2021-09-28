<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Seguimiento.aspx.cs" Inherits="BuenosAiresWeb.GUI.Seguimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="container" style="border: 1px solid gainsboro; width:50%;">
    <br />
    <h3>Seguimiento</h3>
    <br />
    <h6>Ingresa N° de orden de compra</h6>
    <asp:TextBox ID="TxtOrden" class="form-control" runat="server" />
        <br />
        <asp:Button ID="BtnBuscar" class="btn btn-primary btn-md btn-block" Text="Buscar" runat="server" OnClick="BtnBuscar_Click" />
    <br />
    <asp:GridView ID="GrdSeguimiento" runat="server" class="table table-bordered" style="margin-top:20px;"></asp:GridView>
    </div>
</asp:Content>
