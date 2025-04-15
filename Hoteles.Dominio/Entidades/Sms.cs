using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Dominio.Entidades
{
    public class Sms
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Mensaje { get; set; }
    }
}
