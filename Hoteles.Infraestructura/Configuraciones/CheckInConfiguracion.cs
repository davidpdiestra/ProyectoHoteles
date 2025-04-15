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
    public class CheckInConfiguracion : IEntityTypeConfiguration<CheckIn>
    {
        public void Configure(EntityTypeBuilder<CheckIn> builder)
        {
            builder.ToTable("CheckIn");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id).ValueGeneratedOnAdd();

            builder.Property(ci => ci.ReservaId).IsRequired();

            builder.Property(ci => ci.FechaHoraIngreso).IsRequired();

            builder.Property(ci => ci.RecepcionistaId).IsRequired();

            builder.HasOne(ci => ci.Reserva)
                   .WithOne(r => r.CheckIn)
                   .HasForeignKey<CheckIn>(ci => ci.ReservaId);
        }
    }
}
