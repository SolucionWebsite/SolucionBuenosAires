using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using BuenosAiresWeb.GUI.Models;
using BuenosAiresService.WCF;
using System.Collections.Generic;

namespace BuenosAiresWeb.GUI.Account
{
    public partial class Register : Page
    {
        Usuario usuario = new Usuario();

        public void CreateUser_Click(object sender, EventArgs e)
        {
            List<Usuario> lista = usuario.Registros();

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };

            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

                bool existente = lista.Any(x => x.Email == Email.Text);

                if (existente == true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Invalido()", true);
                }
                else
                {
                    Usuario registro = new Usuario
                    {
                        Nombres = TxtNombres.Text,
                        Apellidos = TxtApellidos.Text,
                        Rut = TxtRut.Text,
                        Email = Email.Text,
                        Contrasena = Password.Text
                    };
                    usuario.Agregar(registro);
                }
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Valido()", true);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
                }
            }
        }