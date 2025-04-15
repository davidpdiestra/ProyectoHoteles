using Hoteles.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Infraestructura.Configuraciones
{
    public class TipoHabitacionConfiguracion : IEntityTypeConfiguration<TipoHabitacion>
    {
        public void Configure(EntityTypeBuilder<TipoHabitacion> builder)
        {
            builder.ToTable("TipoHabitacion"); // Nombre de la tabla

            builder.HasKey(c => c.Id); // Clave primaria

            builder.Property(c => c.Descripcion)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.Property(c => c.Capacidad)
                   .IsRequired();

            builder.Property(c => c.Activo)
                   .HasDefaultValue(true);

            builder.HasMany(th => th.Habitaciones)
                   .WithOne(h => h.TipoHabitacion)
                   .HasForeignKey(h => h.TipoHabitacionId);
        }
    }
}
