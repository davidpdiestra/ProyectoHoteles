using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Dominio.Entidades
{
    public class Notificacion
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaEnvio { get; set; }
        public bool Enviada { get; set; }
        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int? ReservaId { get; set; }
        public Reserva Reserva { get; set; }
    }
}
