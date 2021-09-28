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
    public class BodegaTests
    {
        [TestMethod()]
        public void ConsultarStock_CodigoValido_RetornarStock()
        {
            //Requerimiento: El sistema debe permitir consultar stock de productos en bodega
            //Codigo de producto debe existir
            //El stock debe coincidir con el stock en la base de datos

            //Arrange
            Bodega bodega = new Bodega();
            int codigoProducto = 48;

            //Act
            int stock = bodega.ConsultarStock(codigoProducto);

            //Assert
            Assert.AreEqual(33, stock);
        }
    }
}