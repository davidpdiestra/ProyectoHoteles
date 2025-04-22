using MediatR;

namespace Hoteles.Aplicacion.Proceso.Habitacion.Create
{
    public class CrearHabitacionCommand : IRequest<int>
    {
        public string Numero { get; set; }
        public int TipoHabitacionId { get; set; }
        public float Precio { get; set; }
        public bool Disponible { get; set; }
        public string Descripcion { get; set; }
    }
}
