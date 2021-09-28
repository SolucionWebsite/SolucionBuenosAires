using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuenosAiresService.WCF;

namespace BuenosAiresWeb.GUI
{
    public partial class LoginTrabajador : System.Web.UI.Page
    {
        Trabajador trabajador = new Trabajador();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BtnIngresar_Click(object sender, EventArgs e)
        {
            int codigo = 0;

            List<Trabajador> lista = trabajador.Registros();

            bool existe =  lista.Any(x => x.Email == TxtEmail.Text);

            if (existe == true && TxtPassword.Text == "123")
            {
                foreach (Trabajador t in lista)
                {
                    if (t.Email == TxtEmail.Text)
                    {
                        codigo = t.Codigo;
                    }
                }

                Response.Redirect($"http://localhost:52821/HistorialTrabajador/{codigo}");
            }
            else
            {
                ValidadorEmail.IsValid = false;
                ValidadorEmail.ErrorMessage = "Email no registrado";

            }
           
        }
    }
}