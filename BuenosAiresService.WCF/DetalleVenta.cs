using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuenosAiresService.WCF
{
    public class DetalleVenta
    {
        public string Modalidad_entrega { get; set; }
        public string Tipo_comprobante { get; set; }
        public string Fecha { get; set; }
        public string Nombre { get; set; }
        public string Total { get; set; }
        public string Orden_compra { get; set; }
        public string Cupon { get; set; }
        public string Descuento { get; set; }
        public string Subtotal { get; set; }
    }

}