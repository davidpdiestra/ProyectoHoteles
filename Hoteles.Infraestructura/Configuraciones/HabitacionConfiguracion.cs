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
    public class HabitacionConfiguracion : IEntityTypeConfiguration<Habitacion>
    {
        public void Configure(EntityTypeBuilder<Habitacion> builder)
        {
            builder.ToTable("Habitacion");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Id)

                   .ValueGeneratedOnAdd();

            builder.Property(h => h.Numero)

                   .IsRequired()

                   .HasMaxLength(50);

            builder.Property(h => h.TipoHabitacionId)

                   .IsRequired();

            builder.Property(h => h.Precio)

                   .IsRequired();

            builder.Property(h => h.Disponible)

                   .HasDefaultValue(true);

            builder.Property(h => h.Descripcion)

                   .HasMaxLength(500);

        }
    }
}
