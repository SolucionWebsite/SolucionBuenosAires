using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuenosAiresService.WCF;
using PagoService.WCF;

namespace BuenosAiresWeb.GUI
{
    public partial class Comprobante : System.Web.UI.Page
    {
        Pagos pagos = new Pagos();
        Proveedor proveedor = new Proveedor();
        Producto producto = new Producto();
        Venta venta = new Venta();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater1.DataSource = Productos();
                Repeater1.DataBind();
            }

            Compra();
        }

        public List<DetallePedido> Productos()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] separado = url.Split('/');
            int orden = Int32.Parse(separado[separado.Length - 2]);
            
            List<DetallePedido> lista = venta.DetallePedido(orden);

            List<DetallePedido> listaNueva = new List<DetallePedido>();

            foreach (var l in lista)
            {
                string total = Int32.Parse(l.Total).ToString("C", CultureInfo.CurrentCulture);
                string precio = Int32.Parse(l.Precio).ToString("C", CultureInfo.CurrentCulture);
                string image = "/Productos/" + l.Imagen + ".jpeg";

                DetallePedido nuevo = new DetallePedido
                {
                    Imagen = image,
                    Producto = l.Producto,
                    Cantidad = l.Cantidad,
                    Precio = precio,
                    Total = total
                };

                listaNueva.Add(nuevo);
            }
            return listaNueva;
        }

        public void Compra()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] separado = url.Split('/');
            int usuario = Int32.Parse(separado[separado.Length - 1]);
            int orden = Int32.Parse(separado[separado.Length - 2]);

            List<DetalleVenta> lista = venta.DetalleVenta(usuario);

            bool sucursal = lista.Any(x => x.Modalidad_entrega == "Sucursal");
            bool domicilio = lista.Any(x => x.Modalidad_entrega == "Domicilio");

            if (sucursal == true)
            {
                foreach (DetalleVenta v in lista)
                {
                    LblOrden.Text = v.Orden_compra;
                    LblFecha.Text = v.Fecha;
                    LblNombre.Text = v.Nombre;
                    LblDireccion.Text = "Sucursal central Av. Pajaritos 233 - Maipú";
                    LblTotal.Text = Int32.Parse(v.Total).ToString("C", CultureInfo.CurrentCulture);
                    LblRecibo.Text = v.Tipo_comprobante;
                    LblSubtotal.Text = Int32.Parse(v.Subtotal).ToString("C", CultureInfo.CurrentCulture);
                    LblEnvio.Text = "$0";
                    LblTotal2.Text = Int32.Parse(v.Total).ToString("C", CultureInfo.CurrentCulture); 

                    if (v.Cupon != "No")
                        LblCupon.Text = v.Cupon;

                    try
                    {
                        LblDescuento.Text = Int32.Parse(v.Descuento).ToString("C", CultureInfo.CurrentCulture); 
                    }
                    catch (Exception)
                    {
                        LblDescuento.Text = "$0";
                    }
                }
            }
            else
            {
                List<DireccionEnvio> lista2 = venta.DireccionEnvio(usuario);
                string telefono = "";
                string direccion = "";

                foreach (DireccionEnvio d in lista2)
                {
                    telefono = d.Telefono;
                    direccion = d.Direccion + ", " + d.Comuna + ", " + d.Ciudad + ", Región " + d.Region;

                }

                foreach (DetalleVenta v in lista)
                {
                    LblOrden.Text = v.Orden_compra;
                    LblFecha.Text = v.Fecha;
                    LblNombre.Text = v.Nombre;
                    LblDireccion.Text = direccion;
                    LblTelefono.Text = telefono;
                    LblTotal.Text = Int32.Parse(v.Total).ToString("C", CultureInfo.CurrentCulture);
                    LblRecibo.Text = v.Tipo_comprobante;
                    LblSubtotal.Text = Int32.Parse(v.Subtotal).ToString("C", CultureInfo.CurrentCulture);
                    LblEnvio.Text = "$3.990";
                    LblTotal2.Text = Int32.Parse(v.Total).ToString("C", CultureInfo.CurrentCulture);

                    if (v.Cupon != "No")
                        LblCupon.Text = v.Cupon;
                        
                    try
                    {
                        LblDescuento.Text = Int32.Parse(v.Descuento).ToString("C", CultureInfo.CurrentCulture); ;
                    }
                    catch (Exception)
                    {
                        LblDescuento.Text = "$0";
                    }
                }
            }

            List<Pago> lista1 = pagos.DetallePago(orden).ToList();
            foreach (Pago p in lista1)
            {
                LblPago.Text = p.Medio_pago;
            }
        }
        
    }
}