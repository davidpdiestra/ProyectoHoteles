using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Dominio.Entidades
{
    public class Correo
    {
        public int Id { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
    }
}
