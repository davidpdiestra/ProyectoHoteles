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
    public class HabitacionComodidadConfiguracion : IEntityTypeConfiguration<HabitacionComodidad>
    {
        public void Configure(EntityTypeBuilder<HabitacionComodidad> builder)
        {
            builder.ToTable("HabitacionComodidad");

            builder.HasKey(hc => new { hc.HabitacionId, hc.ComodidadId });

            builder.HasOne(hc => hc.Habitacion)
                   .WithMany(h => h.HabitacionComodidades)
                   .HasForeignKey(hc => hc.HabitacionId);

            builder.HasOne(hc => hc.Comodidad)
                   .WithMany(c => c.HabitacionComodidades)
                   .HasForeignKey(hc => hc.ComodidadId);
        }

    }
}
