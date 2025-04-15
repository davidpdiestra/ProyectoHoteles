using Hoteles.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoteles.Infraestructura.Configuraciones
{
    public class EstadoHabitacionConfiguracion : IEntityTypeConfiguration<EstadoHabitacion>
    {
        public void Configure(EntityTypeBuilder<EstadoHabitacion> builder)
        {
            builder.ToTable("EstadoHabitacion");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Estado)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.ultimaActualizacion)
                   .IsRequired();
        }
    }
}
