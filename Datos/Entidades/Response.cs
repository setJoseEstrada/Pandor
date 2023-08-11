using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Response
    {
        public int Exito { get; set; }
        public string? Mensaje { get; set; }
        public Data? Data { get; set; }
    }
}
