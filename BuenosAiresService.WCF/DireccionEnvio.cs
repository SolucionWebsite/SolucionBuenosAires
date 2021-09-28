using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuenosAiresService.WCF
{
    public class DireccionEnvio
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Rut { get; set; }
        public string Direccion { get; set; }
        public string Alias { get; set; }
        public string Telefono { get; set; }
        public string Comuna { get; set; }
        public string Ciudad { get; set; }
        public string Region { get; set; }
    }
}