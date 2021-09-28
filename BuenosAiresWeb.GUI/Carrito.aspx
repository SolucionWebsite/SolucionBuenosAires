<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="BuenosAiresWeb.GUI.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <script type="text/javascript"></script>
        <script src="js/sweetAlert.js" ></script>
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
        <script src="sweetalert2.all.min.js"></script>
    <script>
        function Eliminar(){
            const Toast = Swal.mixin({
              toast: true,
              position: 'top-end',
              showConfirmButton: false,
              timer: 3000,
              timerProgressBar: true,
              onOpen: (toast) => {
                toast.addEventListener('mouseenter', Swal.stopTimer)
                toast.addEventListener('mouseleave', Swal.resumeTimer)
              }
            })

            Toast.fire({
                icon: 'success',
                title: 'El producto se quito de tu bolsa de compras'
            });
        }
        function Actualizar(){
            const Toast = Swal.mixin({
              toast: true,
              position: 'top-end',
              showConfirmButton: false,
              timer: 3000,
              timerProgressBar: true,
              onOpen: (toast) => {
                toast.addEventListener('mouseenter', Swal.stopTimer)
                toast.addEventListener('mouseleave', Swal.resumeTimer)
              }
            })

            Toast.fire({
                icon: 'success',
                title: 'Se actualizó la bolsa de compras'
            });
        }
    </script>
    <div class="container"style="margin-top:25px;">
        <div class="row">
            <div class="col-fluid" style="width:70%">
                <div class="card" style="width:800px;">
                    <div class="row" style="margin:10px;">
                        <div class="col"><h5>Bolsa de compras</h5></div>
                        <%BuenosAiresWeb.GUI.Carrito carrito = new BuenosAiresWeb.GUI.Carrito();
                            var coleccion = carrito.Productos();
                            if (coleccion == null || coleccion.Count == 0)
                            {%>
                            <div class="row">
                                <div class="col">
                                <h6>No tienes productos en tu carrito.</h6>
                                </div>
                            </div>
                            <%}%>
                            <%else
                            {%>
                             <%int count = coleccion.Count; %>
                                <div class="col"><p style="font:bold 20px; margin-top:2px;">Productos (<%=count%>)</p></div>
                                    <asp:Repeater id="Repeater1" OnItemCommand="R1_ItemCommand" runat="server" EnableVIewState = "true">
                                      <ItemTemplate>
                                          <div class="row">
                                          <div class="card" style="width:777px; margin-top:10px; margin-left:15px;">
                                          <div class="row">
                                          <div class="col-2">
                                            <img src="<%# DataBinder.Eval(Container.DataItem, "Imagen")%>" style="width:120px; height:100px;">
                                            </div>
                                            <div class="col-4">
                                                <br />
                                                <a href="Detalle/<%# DataBinder.Eval(Container.DataItem, "Codigo")%>"><p style="font:bold 15px arial;"><%# DataBinder.Eval(Container.DataItem, "Producto") %></p></a>
                                                
                                                <p style="font:bold 15px arial; color:darkgray">000<%# DataBinder.Eval(Container.DataItem, "Codigo")%>S</p>
                                            </div>
                                            <div class="col-2">
                                                <p style="font:bold 19px Helvetica; margin-top:40px;"><%# DataBinder.Eval(Container.DataItem, "Total") %></p>
                                            </div>
                                            <div class="col-1">
                                                <asp:TextBox EnableVIewState = "true" type="Number" class="form-control" ID="TxtCantidad" text='<%# DataBinder.Eval(Container.DataItem, "Cantidad")%>' runat="server" style="height:40px; width:70px; margin-top:30px;"></asp:TextBox>
                                            </div>
                                            <div class="col-1">
                                                <asp:ImageButton ImageUrl="Icon/refresh.png" runat="server" style="margin-top:36px; margin-left:10px;"/>
                                            
                                            </div>
                                            <div class="col-2">
                                                <asp:Button Text="X" runat="server" style="margin-top:35px;" class="btn btn-sm btn-outline-danger" type="button" />
                                            </div>
                                            </div>
                                            </div>
                                            </div>

                                      </ItemTemplate>
                                   </asp:Repeater>
                            <%};%>
                         </div>
                </div>
            </div>

            <div class="col" style="width:300px">
                <div class="card" style="width:300px;">
                  <div class="card-header">
                      <h5>Resumen de tu pedido</h5>
                  </div>
                  <div class="card-body">
                      <div class="row">
                          <div class="col-fluid" style="width:180px; margin-left:15px;">
                              <h5 class="card-title">Sub total productos</h5>
                          </div>
                      </div>
                      <h4><asp:Label ID="LblTotal" Text="" runat="server" /></h4>
                      <br />
                      <h6 class="card-title">¿Tienes un cupón? </h6>
                      <div class="row">
                          <div class="col-7">
                              <asp:TextBox ID="TxtCupon" runat="server" Placeholder="Ingrésalo aquí" class="form-control" />  
                          </div>
                          <div class="col-3">
                              <asp:Button ID="BtnAplicarCupon" Text="Aplicar" class="btn btn-success" runat="server" OnClick="BtnAplicarCupon_Click" />
                          </div>
                      </div>
                        <asp:CustomValidator ID="ValidadorCupon" runat="server" ErrorMessage="" Display="Dynamic"></asp:CustomValidator>
                      <br />
                      <br />
                      <asp:Button Text="Ir a comprar" runat="server" class="btn btn-primary btn-m btn-block" ID="BtnComprar" OnClick="BtnComprar_Click" />
                  </div>
                </div>
            </div>
        </div>
       </div>
</asp:Content>
