using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuenosAiresService.WCF;
using Microsoft.AspNet.Identity;

namespace BuenosAiresWeb.GUI
{
    public partial class HistorialCliente : System.Web.UI.Page
    {
        Venta venta = new Venta();
        Usuario usuario = new Usuario();
        Trabajador trabajador = new Trabajador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater1.DataSource = HistorialPedidos();
                Repeater1.DataBind();

                Repeater1.DataSource = trabajador.Solicitudes(4).ToList();
                Repeater1.DataBind();
            }
        }

        public List<DetalleCompras> HistorialPedidos()
        {
            string email = Context.User.Identity.GetUserName();
            int codigo = 0;

            List<Usuario> lista = usuario.Registros();

            foreach (Usuario u in lista)
            {
                if (u.Email == email)
                {
                    codigo = u.Codigo;
                }
            }

            List<DetalleCompras> lista1 = venta.DetalleCompra(codigo);

            List<DetalleCompras> listaNueva = new List<DetalleCompras>();

            foreach (var l in lista1)
            {
                string total = Int32.Parse(l.Total).ToString("C", CultureInfo.CurrentCulture);

                DetalleCompras nuevo = new DetalleCompras
                {
                    Orden_compra = l.Orden_compra,
                    Fecha = l.Fecha,
                    Nombre = l.Nombre,
                    Total = total,
                    Estado = l.Estado
                };

                listaNueva.Add(nuevo);
            }

            return listaNueva;
        }
        public void R1_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
        {
            string email = Context.User.Identity.GetUserName();
            int codigo = 0;

            List<Usuario> lista = usuario.Registros();

            foreach (Usuario u in lista)
            {
                if (u.Email == email)
                {
                    codigo = u.Codigo;
                }
            }

            int posicion = Repeater1.Items[e.Item.ItemIndex].ItemIndex;

            Label t = (Label)Repeater1.Items[posicion].FindControl("LblOrden");
            string orden = t.Text;

            Response.Redirect($"DetalleCompra/{orden}/{codigo}");

        }

    }
}