using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuenosAiresService.WCF;

namespace BuenosAiresWeb.GUI
{
    public partial class Home : System.Web.UI.Page
    {
        Producto producto = new Producto();
        dynamic colecion = null;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public dynamic ListaNueva()
        {
            return this.colecion;
        }
        
        public void Buscar()
        {
            List<Producto> Lista = producto.Listar();
            List<Producto> nuevaLista = new List<Producto>();
            string variable = TxtBuscar.Text;

            if (variable != "" || TxtBuscar.Text != "")
            {
                foreach (var p in Lista)
                {
                    if (p.Nombre.ToUpper().Contains(variable.ToUpper()) || p.Descripcion.ToUpper().Contains(variable.ToUpper()))
                    {
                        nuevaLista.Add(p);
                    }
                }
                if (nuevaLista.Count == 0)
                {
                    colecion = nuevaLista;
                    LblResultado.Visible = true;
                    LblResultado.Text = "Lo sentimos! no se encontraron resultados :(";
                }
                else
                {
                    colecion = nuevaLista;
                }
            }
            else
            {
                colecion = Lista;
            }
        }

        public void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
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

        public string ConvertirPrecio(int _precio)
        {
            string precio = _precio.ToString();
            string num1 = precio.Substring((precio.Length - 3), 3);
            string num2 = precio.Substring(0, precio.Length - num1.Length);
            precio = "$" + num2 + "." + num1;
            return precio;
        }
    }
}