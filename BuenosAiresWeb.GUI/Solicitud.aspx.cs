using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuenosAiresService.WCF;

namespace BuenosAiresWeb.GUI
{
    public partial class Solicitud : System.Web.UI.Page
    {
        Localidad localidad = new Localidad();
        Trabajador trabajador = new Trabajador();
        Usuario usuario = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLocalidad();
                CargarServicio();
            }
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

        public void CargarServicio()
        {
            CmbServicio.Items.Insert(0, new ListItem("Seleccionar servicio", "0"));
            CmbServicio.Items.Insert(1, new ListItem("Asesoría en proyectos a edificios u oficinas", "1"));
            CmbServicio.Items.Insert(2, new ListItem("Servicio de Instalación", "2"));
            CmbServicio.Items.Insert(2, new ListItem("Servicio de Mantención Preventiva y Correctiva", "3"));

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] separado = url.Split('/');
            string codigo = separado[separado.Length - 1];

            CmbServicio.SelectedValue = codigo;
            CmbServicio.Enabled = false;

            CmbTrabajador.Items.Insert(0, new ListItem("Seleccionar especialista", "0"));

            if (CmbServicio.SelectedValue == "1")
            {
                CargarTrabajador("Asesor");
            }
            if (CmbServicio.SelectedValue == "2")
            {
                CargarTrabajador("Instalador");
            }
            else
            {
                CargarTrabajador("Mantenedor");
            }

        }

        public void CargarTrabajador(string especialidad)
        {
            CmbTrabajador.DataSource = trabajador.Trabajadores(especialidad);
            CmbTrabajador.DataMember = "datos";
            CmbTrabajador.DataTextField = "NOMBRE";
            CmbTrabajador.DataValueField = "TRABAJADOR_ID";
            CmbTrabajador.DataBind();
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

        public void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (TxtRut.Text.Contains("-") == false || TxtRut.Text.Contains(".") == true)
            {
                RequiredFieldValidator3.IsValid = false;
                RequiredFieldValidator3.ErrorMessage = "Formato incorrecto";
            }
            else if (TxtEmail.Text.Contains("@") == false || TxtEmail.Text.Contains(".") == false)
            {
                RequiredFieldValidator4.IsValid = false;
                RequiredFieldValidator4.ErrorMessage = "Formato incorrecto";
            }
            else if (TxtTelefono.Text.Length > 8 && TxtTelefono.Text.Length < 8)
            {
                RequiredFieldValidator7.IsValid = false;
                RequiredFieldValidator7.ErrorMessage = "Formato incorrecto";
            }
            else
            {
                List<Usuario> lista = usuario.Registros();

                bool existente = lista.Any(x => x.Email == TxtEmail.Text);

                if (existente == true)
                {
                    AgregarSolicitud();
                }
                else
                {
                    Usuario usuario1 = new Usuario
                    {
                        Nombres = TxtNombres.Text,
                        Apellidos = TxtApellidos.Text,
                        Rut = TxtRut.Text,
                        Email = TxtEmail.Text
                    };
                    
                    if (usuario.Agregar(usuario1) == true)
                    {
                        usuario.AgregarDireccion((TxtDireccion.Text + " " + TxtNCasa.Text),
                                                  Int32.Parse(CmbComuna.SelectedValue),
                                                  Int32.Parse(TxtTelefono.Text),
                                                  " ", TxtEmail.Text);
                        AgregarSolicitud();
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Solicitud()", true);
                    }
                }
            }
        }

        public void AgregarSolicitud()
        {
            BuenosAiresService.WCF.Solicitud solicitud1 = new BuenosAiresService.WCF.Solicitud()
            {
                Usuario = TxtEmail.Text,
                Tipo_servicio = Int32.Parse(CmbServicio.SelectedValue),
                Trabajador = Int32.Parse(CmbTrabajador.SelectedValue),
                Fecha = Convert.ToDateTime(DtFecha.Text),
                Requerimiento = TxtRequerimiento.InnerText
            };

            usuario.AgregarSolicitud(solicitud1);
        }
    }
}