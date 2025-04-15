using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Dominio.Entidades
{
    public class PasarelaPago
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Pago> Pagos { get; set; }
    }
}
