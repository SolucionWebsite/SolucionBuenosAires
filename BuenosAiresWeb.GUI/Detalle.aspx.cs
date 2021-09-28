using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuenosAiresService.WCF;
using Microsoft.AspNet.Identity;

namespace BuenosAiresWeb.GUI
{
    public partial class Detalle : System.Web.UI.Page
    {
        Producto producto = new Producto();
        BolsaCompra bolsa = new BolsaCompra();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDetalle();
        }

        public List<Producto> Lista()
        {
            List<Producto> recomendados = producto.Listar();
            return recomendados;
        }

        public void CargarDetalle()
        {
            string codigo = ExtraerCodigo();
            List<Producto> lista = producto.Listar();
           
            foreach (var p in lista)
            {
                if (p.Codigo == Int32.Parse(codigo))
                {
                    ImgProducto.ImageUrl = ConvertirImagen(p.Imagen);
                    LblNombre.Text = p.Nombre;
                    LblDescripcion.Text = p.Descripcion;
                    LblPrecio.Text = p.Precio.ToString("C", CultureInfo.CurrentCulture);
                }
            }
        }

        public string ExtraerCodigo()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] separado = url.Split('/');
            string codigo = separado[separado.Length - 1];

            return codigo;
        }

        public string ConvertirImagen(byte[] _image)
        {
            string imagen = null;

            string ruta = Server.MapPath("~/Productos/");
            ruta = Path.Combine(ruta, _image.Length.ToString() + ".jpeg");
            MemoryStream ms = new MemoryStream(_image);
            Bitmap SA = (Bitmap)System.Drawing.Image.FromStream(ms);
            SA.Save(ruta, System.Drawing.Imaging.ImageFormat.Jpeg);
            imagen = "Productos/" + _image.Length.ToString() + ".jpeg";
            return imagen;
        }

        public void BtnAgregar_Click(object sender, EventArgs e)
        {
            string usuario = Context.User.Identity.GetUserName();
            int cantidad = Int32.Parse(TxtCantidad.Text);
            string producto = ExtraerCodigo();

            if (usuario == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Login()", true);
            }
            else
            {
                List<BolsaCompra> lista = bolsa.Listar(usuario);

                bool existente = lista.Any(x => x.Codigo == producto && x.Usuario == usuario);

                if (existente == true)
                {
                    foreach (BolsaCompra c in lista)
                    {
                        if (c.Codigo == producto)
                        {
                            bolsa = c;

                            cantidad = Int32.Parse(c.Cantidad.ToString()) + 1;

                            bolsa.Actualizar(usuario, Int32.Parse(producto), cantidad);

                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Actualizar()", true);
                        }
                    }
                }
                else
                {
                    if (TxtCantidad.Text == "")
                    {
                        cantidad = 1;
                    }
                    else
                    {
                        cantidad = Int32.Parse(TxtCantidad.Text);
                    }
                    bolsa.Agregar(Int32.Parse(producto),cantidad,usuario);
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "AgregarCarrito()", true);
                }

            }
        }
    }
}