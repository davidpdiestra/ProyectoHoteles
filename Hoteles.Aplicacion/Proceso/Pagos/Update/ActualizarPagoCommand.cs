using MediatR;

namespace Hoteles.Aplicacion.Proceso.Pagos.Update
{
    public class ActualizarPagoCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public int PasarelaPagoId { get; set; }
        public float Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string EstadoTransaccion { get; set; }
    }
}
