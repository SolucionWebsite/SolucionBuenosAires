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
    public partial class Carrito : System.Web.UI.Page
    {
        Venta venta = new Venta();
        BolsaCompra bolsa = new BolsaCompra();
        Usuario usuario = new Usuario();
        
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater1.DataSource = Productos();
                Repeater1.DataBind();
            }

            LblTotal.Text = SubTotal();
        }
        
       
        public List<BolsaCompra> Productos()
        {
            List<BolsaCompra> lista = bolsa.Listar(Context.User.Identity.GetUserName());

            List<BolsaCompra> listaNueva = new List<BolsaCompra>();

            foreach (var l in lista)
            {
                int precio = Int32.Parse(l.Total);
                
                string precio1 = precio.ToString("C", CultureInfo.CurrentCulture);

                string image = "/Productos/" + l.Imagen + ".jpeg";

                BolsaCompra nuevo = new BolsaCompra
                {
                    Codigo = l.Codigo,
                    Producto = l.Producto,
                    Cantidad = l.Cantidad,
                    Total = precio1,
                    Imagen = image
                    
                };
                listaNueva.Add(nuevo);
            }
             return listaNueva;
        }

        public string SubTotal()
        {
            List<BolsaCompra> lista = Productos();
            
            int total = 0;
            string precio = "";

            foreach (var p in lista)
            {
                string precio1 = p.Total.ToString();
                string precio2 = precio1.Replace(".", "");
                string precio3 = precio2.Trim(new Char[] { '$', ' ' });
                int precio4 = Int32.Parse(precio3);
                int precio5 = (precio4 / Int32.Parse(p.Cantidad));
                int sub_total = (Int32.Parse(p.Cantidad.ToString()) * precio5);
                total = total + sub_total;
            }
            if (lista == null || lista.Count == 0)
            {
                precio = "$0";
            }
            else
            {
                precio = total.ToString("C", CultureInfo.CurrentCulture);
            }
            return precio;
        }
        

        public void R1_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
        {
            List<BolsaCompra> lista = bolsa.Listar(Context.User.Identity.GetUserName());
            int posicion = Repeater1.Items[e.Item.ItemIndex].ItemIndex;

            TextBox t = (TextBox)Repeater1.Items[posicion].FindControl("TxtCantidad");
            string cantidad = t.Text;

            BolsaCompra elemento = lista.ElementAt(posicion);
            
            int codigo = Int32.Parse(elemento.Codigo.ToString());

            foreach (BolsaCompra p in lista)
            {
                if (p.Codigo == codigo.ToString())
                {
                    if (p.Cantidad != cantidad)
                    {
                        bolsa.Actualizar(Context.User.Identity.GetUserName(),codigo, Int32.Parse(cantidad));
                        SubTotal();
                        Response.Redirect(Request.RawUrl);
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Actualizar()", true);
                    }
                    else
                    {
                        if (bolsa.Eliminar(codigo, Context.User.Identity.GetUserName()))
                        {
                            lista.Remove(elemento);
                            SubTotal();
                            Response.Redirect(Request.RawUrl);
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Eliminar()", true);
                        }
                    }
                }
            }
        }

        public void BtnComprar_Click(object sender, EventArgs e)
        {
            string precio1 = LblTotal.Text;
            string precio2 = precio1.Replace(".", "");
            string precio3 = precio2.Trim(new Char[] { '$', ' ' });

            if (TxtCupon.Text == "")
            {
                Response.Redirect($"Compra/{precio3}");
            }
            else
            {
                List<Cupon> cupones = venta.ListaCupon(TxtCupon.Text);

                int codigo = 0;

                foreach (Cupon c in cupones)
                {
                    codigo = c.Codigo;
                }

                Response.Redirect($"Compra/{codigo}/{precio3}");
            }
        }

        public void BtnAplicarCupon_Click(object sender, EventArgs e)
        {
            List<Cupon> cupones = venta.ListaCupon(TxtCupon.Text);
            List<BolsaCompra> lista = Productos();

            decimal subtotal = 0;

            foreach (var p in lista)
            {
                string precio1 = p.Total.ToString();
                string precio2 = precio1.Replace(".", "");
                string precio3 = precio2.Trim(new Char[] { '$', ' ' });
                int precio4 = Int32.Parse(precio3);
                int precio5 = (precio4 / Int32.Parse(p.Cantidad));
                int sub_total = (Int32.Parse(p.Cantidad.ToString()) * precio5);
                subtotal = subtotal + sub_total;
            }

            if (cupones.Count == 0)
            {
                ValidadorCupon.IsValid = false;
                ValidadorCupon.ForeColor = Color.Red;
                ValidadorCupon.ErrorMessage = "El cupón no existe o caducó";
                TxtCupon.Text = "";
            }
            else
            {
                
                decimal descuento = 0;
                int total = 0;
                int porcentaje = 0;

                foreach (Cupon c in cupones)
                {
                    descuento = c.Descuento;
                }

                porcentaje = Convert.ToInt32(descuento * 100);
                total = Convert.ToInt32(subtotal-(subtotal*descuento));

                LblTotal.Text = total.ToString("C", CultureInfo.CurrentCulture); ;

                ValidadorCupon.IsValid = false;
                ValidadorCupon.ForeColor = Color.Green;
                ValidadorCupon.ErrorMessage = $"Se aplicó un {porcentaje}% de descuento";
            }
        }

        
    }
}
