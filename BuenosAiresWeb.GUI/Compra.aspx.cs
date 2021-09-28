using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuenosAiresService.WCF;
using Microsoft.AspNet.Identity;

namespace BuenosAiresWeb.GUI
{
    public partial class Compra : System.Web.UI.Page
    {
        Localidad localidad = new Localidad();
        Venta venta = new Venta();
        Usuario usuario = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLocalidad();
                BtnContinuar1.Enabled = false;
                BtnContinuar2.Enabled = false;
                BtnContinuar3.Enabled = false;
                Btn2.Enabled = false;
                Btn2.BorderColor = Color.Gainsboro;
                Panel2.BorderColor = Color.Gainsboro;
                Btn3.Enabled = false;
                Btn3.BorderColor = Color.Gainsboro;
                Panel3.BorderColor = Color.Gainsboro;
            }

            MetodoDespacho();
        }

        public void MetodoDespacho()
        {
            if (RbDomicilio.Checked == true)
            {
                Panel12.Visible = true;
                Panel12.Enabled = true;

                Panel13.Visible = false;
                Panel13.Enabled = false;

                BtnContinuar1.Enabled = true;
                BtnContinuar2.Enabled = true;
                
            }
            else if (RbSucursal.Checked == true)
            {
                Panel12.Visible = false;
                Panel12.Enabled = false;

                Panel13.Visible = true;
                Panel13.Enabled = true;

                LblPrecio.Text = "$0";
                DateTime Hoy = DateTime.Today;
                LblFecha.Text = Hoy.AddDays(3).ToShortDateString();

                BtnContinuar1.Enabled = true;
                BtnContinuar2.Enabled = true;
            }

            
        }

        public void CargarPrecio(object sender, EventArgs e)
        {
            ValidacionDireccion.Text = "";
            ValidacionDireccion.ForeColor = Color.White;
            LblPrecio.Text = "$3.990";
            DateTime Hoy = DateTime.Today;
            LblFecha.Text = Hoy.AddDays(3).ToShortDateString();
        }

        public void CargarLocalidad()
        {
            CmbRegion.DataSource = localidad.Regiones();
            CmbRegion.DataMember = "datos";
            CmbRegion.DataTextField = "NOMBRE_REGION";
            CmbRegion.DataValueField = "COD_REGION";
            CmbRegion.DataBind();
            CmbRegion.Items.Insert(0, new ListItem("Seleccionar región", "0"));
            CmbCiudad.Items.Insert(0, new ListItem("Seleccionar ciudad", "0"));
            CmbComuna.Items.Insert(0, new ListItem("Seleccionar comuna", "0"));
        }

        public void CargarCiudad(object sender, EventArgs e)
        {
            int codigo = Int32.Parse(CmbRegion.SelectedValue);
            CmbCiudad.DataSource = localidad.Ciudades(codigo);
            CmbCiudad.DataMember = "datos";
            CmbCiudad.DataTextField = "NOMBRE_CIUDAD";
            CmbCiudad.DataValueField = "COD_CIUDAD";
            CmbCiudad.DataBind();

        }

        public void CargarComuna(object sender, EventArgs e)
        {
            int codigo = Int32.Parse(CmbCiudad.SelectedValue);
            CmbComuna.DataSource = localidad.Comunas(codigo);
            CmbComuna.DataMember = "datos";
            CmbComuna.DataTextField = "NOMBRE_COMUNA";
            CmbComuna.DataValueField = "COD_COMUNA";
            CmbComuna.DataBind();

        }

        public void BtnContinuar1_Click(object sender, EventArgs e)
        {
            Btn2.Enabled = true;
            Panel21.Visible = true;
            Btn2.BorderColor = Color.DodgerBlue;
            Panel2.BorderColor = Color.DodgerBlue;

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] separado = url.Split('/');
            string total = separado[separado.Length - 1];
            LblSubTotal.Text = Int32.Parse(total).ToString("C", CultureInfo.CurrentCulture);

            decimal descuento = 0;
            decimal rebaja = 0;

            try
            {
                string cupon = separado[separado.Length - 2];

                List<Cupon> cupones = venta.Cupones();

                foreach (Cupon c in cupones)
                {
                    if (c.Codigo == Int32.Parse(cupon))
                    {
                        descuento = c.Descuento;
                    }
                }
                rebaja = (Int32.Parse(total) * descuento);
                LblDescuento.Text = Convert.ToInt32(rebaja).ToString("C", CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                LblDescuento.Text = "$0";
            }
            
            
            LblEnvio.Text = LblPrecio.Text;

            if (RbDomicilio.Checked)
            {
                LblTotal.Text = ((Int32.Parse(total) - Convert.ToInt32(rebaja)) + 3990).ToString("C", CultureInfo.CurrentCulture);
            }
            else if (RbSucursal.Checked)
            {
                LblTotal.Text = ((Int32.Parse(total) - Convert.ToInt32(rebaja))).ToString("C", CultureInfo.CurrentCulture);
            }
            
        }

        public void BtnContinuar2_Click(object sender, EventArgs e)
        {
            Btn3.Enabled = true;
            Panel31.Visible = true;
            Btn3.BorderColor = Color.DodgerBlue;
            Panel3.BorderColor = Color.DodgerBlue;
        }

        public int CodigoUsuario()
        {
            List<Usuario> lista = usuario.Registros();
            int codigoUsuario = 0;

            foreach (Usuario u in lista)
            {
                if (u.Email == Context.User.Identity.GetUserName())
                {
                    codigoUsuario = u.Codigo;
                }
            }
            return codigoUsuario;
        }

        public void BtnContinuar3_Click(object sender, EventArgs e)
        {
            int codigoUsuario = CodigoUsuario();

            string precio1 = LblTotal.Text;
            string precio2 = precio1.Replace(".", "");
            string precio3 = precio2.Trim(new Char[] { '$', ' ' });

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] separado = url.Split('/');
            int codigoCupon = 0;
            int codigoEntrega = 0;
            int codigoRecibo = CmbComprobante.SelectedIndex;

            if (RbDomicilio.Checked)
            {
                codigoEntrega = 1;
            }
            else
            {
                codigoEntrega = 2;
            }

            try
            {
                string cupon = separado[separado.Length - 2];

                List<Cupon> cupones = venta.Cupones();

                foreach (Cupon c in cupones)
                {
                    if (c.Codigo == Int32.Parse(cupon))
                    {
                        codigoCupon = c.Codigo;
                    }
                }

                Response.Redirect($"http://localhost:52821/PagoOnline/{codigoCupon}/{precio3}/{codigoUsuario}/{codigoEntrega}/{codigoRecibo}", false);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                Response.Redirect($"http://localhost:52821/PagoOnline/{precio3}/{codigoUsuario}/{codigoEntrega}/{codigoRecibo}");
            }
            
        }

        public void CargarPago(object sender, EventArgs e)
        {
            BtnContinuar3.Enabled = true;
        }

        public void BtnDireccion_Click(object sender, EventArgs e)
        {
            List<DireccionEnvio> direccion = venta.DireccionEnvio(CodigoUsuario());

            if (direccion.Count == 0)
            {
                ValidacionDireccion.Text = "No se encontró dirección";
                ValidacionDireccion.ForeColor = Color.Red;
            }
            else
            {
                foreach (var d in direccion)
                {
                    string numero = new string(d.Direccion.ToCharArray().Where(c => Char.IsDigit(c)).ToArray());
                    
                    TxtDireccion.Text = d.Direccion.Substring(0, d.Direccion.Length - numero.Length);
                    TxtNCasa.Text = numero;
                    TxtAlias.Text = d.Alias;
                    TxtTelefono.Text = d.Telefono;
                    CmbRegion.SelectedItem.Text = d.Region;
                    CmbCiudad.SelectedItem.Text = d.Ciudad;
                    CmbComuna.SelectedItem.Text = d.Comuna;
                }
            }
        }
    }
}