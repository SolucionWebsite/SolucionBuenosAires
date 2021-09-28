<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="BuenosAiresWeb.GUI.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript"></script>
        <script src="js/sweetAlert.js" ></script>
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
        <script src="sweetalert2.all.min.js"></script>
    <script>
        function AgregarCarrito() {
            Swal.fire({
                  title: 'Producto agregado!',
                  icon: 'success',
                  showCancelButton: true,
                  confirmButtonText: 'Ir al carrito!',
                  cancelButtonText: 'Seguir comprando',
                  reverseButtons: true
                }).then((result) => {
                  if (result.value) {
                    window.location.href = "/Carrito";
                  } else if (
                    result.dismiss === Swal.DismissReason.cancel
                  ) {
                      window.location.href = "/Home";
                  }
            });
        }
        function Login() {
            Swal.fire({
                  title: 'Quieres comprar?',
                  text: "Necesitas ingresar con tu cuenta",
                  icon: 'question',
                  showCancelButton: true,
                  confirmButtonText: 'Si, Entrar!',
                  cancelButtonText: 'No, quiero mirar',
                  reverseButtons: true
                }).then((result) => {
                  if (result.value) {
                    window.location.href = "/Account/Login";
                  } else if (
                    result.dismiss === Swal.DismissReason.cancel
                  ) {
                      window.location.href = "";
                  }
            });
        }
    </script>
    <div class="row">   
        <div class="col">
            <asp:Image ID="ImgProducto" runat="server" style="width:500px; height:400px; margin-top:30px"/>
        </div>
        <div class="col">
            <div class="container" style="border:1px solid gainsboro; margin-top:30px">
                <div class="row">
                    <asp:Label ID="LblNombre" runat="server" Text="" style="font:bold 23px arial; margin:10px" ></asp:Label>
                </div>
                <div class="row">
                    <asp:Label ID="LblDescripcion" runat="server" Text="" style="font:normal 18px arial; margin:5px; margin-left:10px"></asp:Label>
                </div>
                <div class="row">
                    <asp:Label ID="LblPrecio" runat="server" Text="" style="font:bold 25px arial; margin:30px;"></asp:Label><br />
                    <h4><span class="badge badge-primary" style="margin-top:30px; margin-left:3px;">Internet</span></h4>
                    
                </div>
                <div class="row">
                    <div class="col">
                        <asp:TextBox EnableVIewState = "true" type="Number" class="form-control" ID="TxtCantidad" text="1" runat="server" sstyle="height:35px; width:80px; margin-left:15px"></asp:TextBox>                      
                    </div>
                    </div>
                <div class="row">
                    <asp:Button ID="BtnAgregar" class="btn btn-primary btn-lg btn-block" runat="server" Text="Agregar al carrito" style="margin-top:70px" OnClick="BtnAgregar_Click"/>
                          
                </div>
            </div>
        </div>
    </div>
    <h5>Productos recomendados</h5>
    <div id="carouselExampleControls" class="carousel slide" data-ride="carousel" style="left: 0px; top: 0px">
      <div class="carousel-inner">
        <div class="carousel-item active" style="height:200px">
            <div class="row">
             <%BuenosAiresWeb.GUI.Detalle productos = new BuenosAiresWeb.GUI.Detalle();
                List<BuenosAiresService.WCF.Producto> lista = Lista();%>
                <%foreach (var p in lista) {%>
                <div class="col-fluid" style="width:210px; margin:5px; margin-left:15px">
                <div class="card" style="width:210px;">
                  <img src="/<%=productos.ConvertirImagen(p.Imagen)%>" class="card-img-top" style="width:200px; height:180px;">
                  <div class="card-body">
                    <p style="font:bold 15px arial"><%=p.Nombre %></p>
                  </div>
                </div>
                </div>
                <%}%>
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
        </div>
</asp:Content>
