using MediatR;

namespace Hoteles.Aplicacion.Proceso.Habitacion.Update
{
    public class ActualizarHabitacionCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int TipoHabitacionId { get; set; }
        public float Precio { get; set; }
        public bool Disponible { get; set; }
        public string Descripcion { get; set; }
    }
}
