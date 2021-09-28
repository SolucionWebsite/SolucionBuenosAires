<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="BuenosAiresWeb.GUI.Servicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="container" style="border:1px solid gainsboro; width:900px;" >
        <h4>Nuestros servicios</h4>
        <br />
        <div class="card-deck">
            <div class="card" style="width: 18rem;">
              <img src="Icon/asesoria.jpg" class="card-img-top" alt="...">
              <div class="card-body">
                <h5 class="card-title">Servicio de Asesoría en proyectos a edificios u oficinas</h5>
                <a href="/Solicitud/1" class="btn btn-primary btn-block">Solicitar servicio</a>
              </div>
            </div>
            <div class="card" style="width: 18rem;">
              <img src="Icon/instalacion.jpg" class="card-img-top" alt="...">
              <div class="card-body">
                <h5 class="card-title">Servicio de instalación</h5>
                <a href="/Solicitud/2" class="btn btn-primary btn-block">Solicitar servicio</a>
              </div>
            </div>
            <div class="card" style="width: 18rem;">
              <img src="Icon/mantencion.png" class="card-img-top" alt="...">
              <div class="card-body">
                <h5 class="card-title">Servicio de mantención preventiva y correctiva</h5>
                <a href="/Solicitud/3" class="btn btn-primary btn-block">Solicitar servicio</a>
              </div>
            </div>
        </div>
    </div>
</asp:Content>
