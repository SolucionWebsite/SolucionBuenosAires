using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuenosAiresService.WCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuenosAiresService.WCF.Tests
{
    [TestClass()]
    public class UsuarioTests
    {
        [TestMethod()]
        public void Agregar_DatosValidos_RegistrarCliente()
        {
            //Requerimiento el sistema debe permitir el registro del cliente
            //El rut debe ser en el formato xxxxxxxx-x

            //Arrange
            Usuario usuario = new Usuario();

            //Act
            Usuario nuevoRegistro = new Usuario
            {
                Nombres = "Marco Antonio",
                Apellidos = "Solis Iglesias",
                Rut = "12234456-5",
                Email = "marcoantonio@gmail.com",
                Contrasena = "Ma123."
            };

            bool agregar = usuario.Agregar(nuevoRegistro);

            //Assert
            Assert.IsTrue(agregar);
            
        }

        [TestMethod()]
        public void Eliminar_EmailValido_BorrarCuentaUsuario() 
        {
            //El email debe existir

            //Arrange
            Usuario usuario = new Usuario();

            //Act
            string email = "marcoantonio@gmail.com";
            bool eliminar = usuario.Eliminar(email);

            //Assert
            List<Usuario> usuarios = usuario.Registros();

            string emailUsuario = "";

            foreach (Usuario u in usuarios)
            {
                if (u.Email == email)
                    emailUsuario = u.Email;
                else
                    emailUsuario = null;
            }

            Assert.IsNull(emailUsuario);

        }

        [TestMethod()]
        public void Actualizar_DatosValidos_ActualizarInformacionUsuario()
        {
            //La cuenta de usuario debe existir

            //Arrange
            Usuario usuario = new Usuario();

            //Act
            string email = "Geraldjmatus@gmail.com";
            string contraseñaActual = "123";

            Usuario actualizarRegistro = new Usuario
            {
                Nombres = "Gerald Antonio",
                Apellidos = "Jelves Matus",
                Rut = "19484979-6",
                Email = "Geraldjmatus@gmail.com",
                Contrasena = "Gerald123."
            };

            usuario.Actualizar(actualizarRegistro);

            //Assert
            List<Usuario> usuarios = usuario.Registros();

            string contraseñaNueva = "";

            foreach (Usuario u in usuarios)
            { 
                if (u.Email == email)
                    contraseñaNueva = u.Contrasena;
            }

            Assert.AreNotEqual(contraseñaActual, contraseñaNueva);

        }
    }
}