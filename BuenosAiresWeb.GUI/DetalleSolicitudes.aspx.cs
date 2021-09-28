using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuenosAiresService.WCF;

namespace BuenosAiresWeb.GUI
{
    public partial class DetalleSolicitudes : System.Web.UI.Page
    {
        Trabajador trabajador = new Trabajador();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarSolicitud();
        }

        public void CargarSolicitud()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] separado = url.Split('/');
            int solicitud = Int32.Parse(separado[separado.Length - 2]);
            int codigo = Int32.Parse(separado[separado.Length - 1]);

            List<DetalleSolicitud> lista = trabajador.Solicitudes(codigo);

            foreach (DetalleSolicitud d in lista)
            {
                if (d.Id == solicitud.ToString())
                {
                    LblSolicitud.Text = d.Id;
                    LblCliente.Text = d.Nombre;
                    LblEmail.Text = d.Email;
                    LblTelefono.Text = d.Telefono;
                    LblDireccion.Text = d.Direccion + ", " + d.Comuna + ", " + d.Ciudad + ", Región " + d.Region;
                    LblModalidad.Text = d.Modalidad;
                    LblFecha.Text = d.Fecha;
                    LblRequerimiento.Text = d.Requerimiento;
                }
            }

        }
    }
}