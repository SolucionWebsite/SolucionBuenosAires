using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuenosAiresService.WCF;

namespace BuenosAiresWeb.GUI
{
    public partial class HistorialTrabajador : System.Web.UI.Page
    {
        Trabajador trabajador = new Trabajador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater1.DataSource = trabajador.Solicitudes(Codigo()).ToList();
                Repeater1.DataBind();
            }

            Nombre();
        }

        public void Nombre()
        {
            List<Trabajador> lista = trabajador.Registros();

            foreach (Trabajador t in lista)
            {
                if(t.Codigo == Codigo())
                {
                    LblEspecialista.Text = t.Nombres + " " + t.Apellidos;
                }
            }
        }

        public int Codigo()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] separado = url.Split('/');
            int codigo = Int32.Parse(separado[separado.Length - 1]);

            return codigo;
        }

        public void R1_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
        {
            
            int codigo = Codigo();

            int posicion = Repeater1.Items[e.Item.ItemIndex].ItemIndex;

            Label t = (Label)Repeater1.Items[posicion].FindControl("LblId");
            string id = t.Text;

            Response.Redirect($"http://localhost:52821/DetalleSolicitudes/{id}/{codigo}");

        }
    }
}