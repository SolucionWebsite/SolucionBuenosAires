using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuenosAiresService.WCF
{
    public class Historial
    {
        public string Orden_compra { get; set; }
        public string Fecha_compra { get; set; }
        public string Estado { get; set; }
        public string Fecha { get; set; }
    }
}