using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuenosAiresService.WCF
{
    public class Cupon
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Descuento { get; set; }
    }
}