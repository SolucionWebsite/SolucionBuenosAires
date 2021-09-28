using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuenosAiresService.WCF
{
    public class DetalleSolicitud
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public string Ciudad { get; set; }
        public string Region { get; set; }
        public string Modalidad { get; set; }
        public string Requerimiento { get; set; }
        public string Fecha { get; set; }
    }
}