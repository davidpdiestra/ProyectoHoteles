using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoteles.Infraestructura.Configuraciones
{
    public class ReservaConfiguracion : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("Reserva");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(r => r.ClienteId).IsRequired();

            builder.Property(r => r.HabitacionId).IsRequired();

            builder.Property(r => r.FechaInicio).IsRequired();

            builder.Property(r => r.FechaFin).IsRequired();

            builder.Property(r => r.Estado)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasOne(r => r.Cliente)
                   .WithMany(c => c.Reservas)
                   .HasForeignKey(r => r.ClienteId);

            builder.HasOne(r => r.Habitacion)
                   .WithMany(h => h.Reservas)
                   .HasForeignKey(r => r.HabitacionId);
        }
    }
}
