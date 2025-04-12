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
        DbSet<Cliente> clientes => Set<Cliente>();
        DbSet<Empleado> empleados => Set<Empleado>();
        DbSet<TipoHabitacion> tipoHabitaciones => Set<TipoHabitacion>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
