using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuenosAiresService.WCF
{
    public class Solicitud
    {
        public int Codigo { get; set; }
        public string Usuario { get; set; }
        public int Tipo_servicio { get; set; }
        public int Trabajador { get; set; }
        public DateTime Fecha { get; set; }
        public string Requerimiento { get; set; }
    }
}