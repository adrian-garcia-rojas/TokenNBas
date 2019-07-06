using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokenNBas.Models.ServiciosC
{
    public class Respuesta
    {
        public int result { get; set; }
        public object data { get; set; }
        public string message { get; set; }

    }
}