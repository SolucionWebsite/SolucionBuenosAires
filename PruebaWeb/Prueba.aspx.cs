using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PagoService.WCF;
using BuenosAiresService.WCF;
using AMWOService.WCF;
using System.Data;
using System.IO;
using System.Drawing;

namespace PruebaWeb
{
    public partial class Prueba : System.Web.UI.Page
    {
        Pagos pagos = new Pagos();
        Proveedor proveedor = new Proveedor();
        Productos productos = new Productos();
        Producto producto = new Producto();
        Trabajador trabajador = new Trabajador();
        Venta venta = new Venta();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarComboboxPago();
                LlenarComboboxProveedor();
                ListaProducto();
                AgregarProductos();
                Solicitud();
                Compra();
            }
        }

        public void LlenarComboboxPago()
        {
            CmbPago.DataSource = pagos.FormaPago();
            CmbPago.DataMember = "datos";
            CmbPago.DataTextField = "NOMBRE";
            CmbPago.DataValueField = "CODIGO_PAGO";
            CmbPago.DataBind();
            CmbPago.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        public void LlenarComboboxProveedor()
        {
            CmbProveedor.DataSource = proveedor.Registros();
            CmbProveedor.DataMember = "datos";
            CmbProveedor.DataTextField = "nombre";
            CmbProveedor.DataValueField = "proveedor_id";
            CmbProveedor.DataBind();
            CmbProveedor.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }
        
        public void ListaProducto()
        {
            DataTable tabla = producto.Registros();

            LstProducto.DataSource = tabla;

            LstProducto.DataTextField = "nombre";
            LstProducto.DataValueField = "producto_id";
            LstProducto.DataBind();
        }
        public void AgregarProductos()
        {
            List<Productos> ListaANWO = productos.ListarProductos();
            List<Producto> ListaEmpresa = producto.Listar();

            foreach (Productos p in ListaANWO)
            {
                Producto pr = new Producto
                {
                    Codigo = p.Codigo,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio,
                    Proveedor = 2,
                    Imagen = p.Imagen
                    
                };
                if (ListaEmpresa.Exists(x => x.Nombre == pr.Nombre))
                {
                    producto.Actualizar(pr);
                }
                else
                {
                    producto.Agregar(pr);
                }
            }

          
        }

        public void Solicitud()
        {
            var lista = trabajador.Solicitudes(2).ToList();

            GrdSolicitudes.DataSource = lista.ToArray();
            GrdSolicitudes.DataBind();
        }

        public void Compra()
        {
            var lista = venta.DetalleVenta(1406435).ToList();

            GrdCompra.DataSource = lista.ToArray();
            GrdCompra.DataBind();

            var lista1 = pagos.DetallePago(1406435).ToList();

            GrdPago.DataSource = lista1.ToArray();
            GrdPago.DataBind();

            var lista2 = venta.DireccionEnvio(4).ToList();

            GrdDireccion.DataSource = lista2.ToArray();
            GrdDireccion.DataBind();

            var lista3 = venta.DetallePedido(1406435).ToList();

            GrdPedido.DataSource = lista3.ToArray();
            GrdPedido.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int codigo = Int32.Parse(TextBox1.Text);
            
            Byte[] image = null;
            image = FileUpload1.FileBytes;

            productos.ActualizarProducto(codigo,image);
            
            
        }
    }
}