using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PagoService.WCF;
using BuenosAiresService.WCF;
using System.Globalization;

namespace BuenosAiresWeb.GUI
{
    public partial class PagoOnline : System.Web.UI.Page
    {
        Pagos pagos = new Pagos();
        Venta venta = new Venta();

        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!IsPostBack)
            {
                LlenarComboboxPago();
            }

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] separado = url.Split('/');
            string total = separado[separado.Length - 4];

            LblTtotal.Text = Int32.Parse(total).ToString("C", CultureInfo.CurrentCulture);*/
        }

        public void LlenarComboboxPago()
        {
            CmbPago.DataSource = pagos.FormaPago();
            CmbPago.DataMember = "datos";
            CmbPago.DataTextField = "NOMBRE";
            CmbPago.DataValueField = "CODIGO_PAGO";
            CmbPago.DataBind();
            CmbPago.Items.Insert(0, new ListItem("Seleccionar método pago", "0"));
        }

        public void Pago(object sender, EventArgs e)
        {
            if (CmbPago.SelectedValue == "1" )
            {
                PanelCredito.Visible = true;
                PanelDebito.Visible = false;
            }
            else if (CmbPago.SelectedValue == "2")
            {
                PanelDebito.Visible = true;
                PanelCredito.Visible = false;
            }
        }
        
        public void TxtNumero_TextChanged(object sender, EventArgs e)
        {
           
        }

        public void BtnPagar2_Click(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] separado = url.Split('/');
            int usuario = Int32.Parse(separado[separado.Length - 3]);
            int total = Int32.Parse(separado[separado.Length - 4]);
            int entrega = Int32.Parse(separado[separado.Length - 2]);
            int recibo = Int32.Parse(separado[separado.Length - 1]);
            int n_tarjeta = Convert.ToInt32(TxtNumero.Text);
            string codigoCupon = "";

            Pagos pagoCredito = new Pagos
            {
                N_tarjeta = Convert.ToInt32(TxtNumero.Text),
                Fecha_vencimiento = TxtFecha.Text,
                Codigo_seguridad = Int32.Parse(TxtCodigo.Text),
                Total_pago = total,
                Usuario = usuario
            };

            if (pagos.PagoCredito(pagoCredito) == true)
            {
                try
                {
                    string cupon = separado[separado.Length - 5];
                    List<Cupon> cupones = venta.Cupones();

                    foreach (Cupon c in cupones)
                    {
                        if (c.Codigo == Int32.Parse(cupon))
                        {
                            codigoCupon = c.Nombre;
                        }
                    }
                }
                catch (Exception)
                {
                    codigoCupon = "No";
                }

                Venta ventaNueva = new Venta
                {
                    Cupon = codigoCupon,
                    Usuario = usuario,
                    Entrega = entrega,
                    Recibo = recibo
                };

                if (venta.Agregar(ventaNueva) == true)
                {
                   string orden = venta.UltimaCompra(usuario).ToString();

                    pagos.AsociarCompra(Int32.Parse(orden), usuario);
                    Response.Redirect($"http://localhost:52821/Comprobante/{orden}/{usuario}");

                }
            }

        }

        protected void BtnPagar1_Click(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] separado = url.Split('/');
            int usuario = Int32.Parse(separado[separado.Length - 3]);
            int total = Int32.Parse(separado[separado.Length - 4]);
            int entrega = Int32.Parse(separado[separado.Length - 2]);
            int recibo = Int32.Parse(separado[separado.Length - 1]);
            int n_tarjeta = Convert.ToInt32(TxtNumero.Text);
            string codigoCupon = "";

            Pagos pagoDebito = new Pagos
            {
                Banco = CmbBanco.SelectedItem.Text,
                Rut = TxtRut.Text,
                Clave = Int32.Parse(TxtClave.Text),
                C_1 = Int32.Parse(TxtCoo1.Text),
                C_2 = Int32.Parse(TxtCoo2.Text),
                C_3 = Int32.Parse(TxtCoo3.Text),
                Total_pago = total,
                Usuario = usuario
            };

            if (pagos.PagoDebito(pagoDebito) == true)
            {
                try
                {
                    string cupon = separado[separado.Length - 5];
                    List<Cupon> cupones = venta.Cupones();

                    foreach (Cupon c in cupones)
                    {
                        if (c.Codigo == Int32.Parse(cupon))
                        {
                            codigoCupon = c.Nombre;
                        }
                    }
                }
                catch (Exception)
                {
                    codigoCupon = "No";
                }

                Venta ventaNueva = new Venta
                {
                    Cupon = codigoCupon,
                    Usuario = usuario,
                    Entrega = entrega,
                    Recibo = recibo
                };

                if (venta.Agregar(ventaNueva) == true)
                {
                    string orden = venta.UltimaCompra(usuario).ToString();

                    pagos.AsociarCompra(Int32.Parse(orden), usuario);
                    Response.Redirect($"http://localhost:52821/Comprobante/{orden}/{usuario}");

                }
            }

        }
    }
}