using Hoteles.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Infraestructura.Persistencia
{
    public class AppDbContext : DbContext
    {
        public DbSet<TipoHabitacion> TipoHabitaciones => Set<TipoHabitacion>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Habitacion> Habitaciones => Set<Habitacion>();
        public DbSet<Reserva> Reservas => Set<Reserva>();
        public DbSet<CheckIn> CheckIns => Set<CheckIn>();
        public DbSet<CheckOut> CheckOuts => Set<CheckOut>();
        public DbSet<Factura> Facturas => Set<Factura>();
        public DbSet<Pago> Pagos => Set<Pago>();
        public DbSet<PasarelaPago> PasarelasPago => Set<PasarelaPago>();
        public DbSet<Recibo> Recibos => Set<Recibo>();
        public DbSet<Comodidad> Comodidades => Set<Comodidad>();
        public DbSet<HabitacionComodidad> HabitacionComodidades => Set<HabitacionComodidad>();
        public DbSet<ImagenHabitacion> ImagenesHabitacion => Set<ImagenHabitacion>();
        public DbSet<Notificacion> Notificaciones => Set<Notificacion>();
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica todas las configuraciones desde la asamblea
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
