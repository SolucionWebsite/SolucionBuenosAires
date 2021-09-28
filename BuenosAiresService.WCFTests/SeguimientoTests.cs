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
    public class SeguimientoTests
    {
        [TestMethod()]
        public void SolicitarSeguimiento_OrdenCompraExistente_RetornarSeguimiento()
        {
            //Requerimiento: El sistema debe permitir entregar una herramienta al cliente para monitorear sus compras.   
            //La orden de compra debe existir

            //Arrange
            Seguimiento seguimiento = new Seguimiento();
            int ordenCompra = 1606443;

            //Act
            List<Seguimiento> lista = seguimiento.SolicitarSeguimiento(ordenCompra);

            //Assert
            CollectionAssert.AllItemsAreNotNull(lista);

        }

        [TestMethod()]
        public void SolicitarSeguimiento_OrdenCompraInexistente_ArrojarExcepcion()
        {
            //La orden de compra debe ser érronea

            //Arrange
            Seguimiento seguimiento = new Seguimiento();
            int ordenCompra = 324151;

            //Act
            List<Seguimiento> lista = seguimiento.SolicitarSeguimiento(ordenCompra);

            //Assert
            StringAssert.Equals("No se encuentran registros", lista);
            
        }
    }
}