using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuenosAiresService.WCF
{
    public class DetalleCompras
    {
        public string Orden_compra { get; set; }
        public string Fecha { get; set; }
        public string Nombre { get; set; }
        public string Total { get; set; }
        public string Estado { get; set; }

    }
}