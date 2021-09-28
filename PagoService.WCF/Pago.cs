using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagoService.WCF
{
    public class Pago
    {
        public string Medio_pago { get; set; }
        public string Orden_compra { get; set; }
    }
}