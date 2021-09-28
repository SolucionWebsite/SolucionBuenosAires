<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BuenosAiresWeb.GUI.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    </style>
    <nav class="navbar navbar-light" style="background-color: #e3f2fd; position:fixed; z-index: 100; width:1142px;">
        <div class="row" style="margin-top:10px">
            <div class="col" style="margin-left:350px;">
                <asp:TextBox ID="TxtBuscar" runat="server" class="form-control" style="width:400px;" placeholder="Buscar por nombre o marca" />
             </div>
            <div class="col-fluid">
                <asp:Button ID="BtnBuscar" Text="Buscar" runat="server" class="btn btn-outline-primary" OnClick="BtnBuscar_Click"/>
            </div>
        </div>
    </nav>

    <div id="carouselExampleControls" class="carousel slide"  style="height:450px" data-ride="carousel">
  <div class="carousel-inner">
    <div class="carousel-item active" style="height:450px">
      <img src="/Icon/aire.png" class="d-block w-100" alt="...">
    </div>
    <div class="carousel-item">
      <img src="/Icon/aire1.jpeg"  style="height:450px" class="d-block w-100" alt="...">
    </div>
    <div class="carousel-item">
      <img src="/Icon/aire2.jpg"  style="height:450px" class="d-block w-100" alt="...">

    </div>
  </div>
  <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>

    <div class="container-fluid" style=" margin-top:20px;">
        <div class="row">
        <div class="col" style="width:80%; margin:15px;">
            <div class="row" style="margin:5px">
                <div class="col-fluid" style="width:75%">
                    <asp:DropDownList ID="CmbCategoria" class="btn btn-light" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="0">Ordenar por</asp:ListItem>
                        <asp:ListItem Value="1">Últimos libros</asp:ListItem>
                        <asp:ListItem Value="2">Precio menor a mayor</asp:ListItem>
                        <asp:ListItem Value="3">Precio mayor a menor</asp:ListItem>   
                </asp:DropDownList>
                </div>
                <div class="col-fluid" style="width:20%">
                        <nav aria-label="Page navigation">
                          <ul class="pagination pagination-sm">
                            <li class="page-item"><a class="page-link" href="#">Anterior</a></li>
                            <li class="page-item"><a class="page-link" href="#">1</a></li>
                            <li class="page-item"><a class="page-link" href="#">2</a></li>
                            <li class="page-item"><a class="page-link" href="#">3</a></li>
                            <li class="page-item"><a class="page-link" href="#">Siguiente</a></li>
                          </ul>
                        </nav>
                </div>
                
            </div>
            <div class="row"> 
                <%BuenosAiresWeb.GUI.Home productos = new BuenosAiresWeb.GUI.Home();
                    Buscar();
                    dynamic colecion = ListaNueva();
                    List<BuenosAiresService.WCF.Producto> lista = colecion;%>
                <%if (ListaNueva().Count == 0)
                    {%>
                    <asp:Label ID="LblResultado" Text="" runat="server" style="font:18px;"/>
                <%} %>
                <%else
                    {   if (CmbCategoria.SelectedItem.Value == "1")
                        {
                            colecion = lista.OrderBy(x => x.Codigo);
                        }
                        else if (CmbCategoria.SelectedItem.Value == "2")
                        {
                            colecion = lista.OrderBy(x => x.Precio);
                        }
                        else if (CmbCategoria.SelectedItem.Value == "3")
                        {
                            colecion = lista.OrderByDescending(x => x.Precio);
                        }
                        %>
                <%foreach (var p in colecion) {%>
                <div class="col-fluid" style="width:260px; margin:5px; margin-left:10px">
                <div class="card" style="width:260px;">
                  <img src="<%=productos.ConvertirImagen(p.Imagen)%>" class="card-img-top" style="width:250px; height:230px;">
                  <div class="card-body">
                    <p style="font:bold 15px Helvetica"><%=p.Nombre %></p>
                    <p class="card-text" style="color:darkgreen; font:bold 16px arial"><%=productos.ConvertirPrecio(p.Precio)%> </p>
                    <a href="Detalle/<%=p.Codigo %>" class="btn btn-primary btn-sm btn-block">Ver producto</a>
                  </div>
                </div>
                </div>
                <%}%>
                <%}%>
            </div>
            
            </div>

      </div>
    </div>
</asp:Content>
