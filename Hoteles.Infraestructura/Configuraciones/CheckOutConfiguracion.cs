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
    public class CheckOutConfiguracion : IEntityTypeConfiguration<CheckOut>
    {
        public void Configure(EntityTypeBuilder<CheckOut> builder)
        {
            builder.ToTable("CheckOut");

            builder.HasKey(co => co.Id);

            builder.Property(co => co.Id).ValueGeneratedOnAdd();

            builder.Property(co => co.ReservaId).IsRequired();

            builder.Property(co => co.FechaHoraSalida).IsRequired();

            builder.Property(co => co.TotalConsumos).IsRequired();

            builder.Property(co => co.RecepcionistaId).IsRequired();

            builder.HasOne(co => co.Reserva)
                   .WithOne(r => r.CheckOut)
                   .HasForeignKey<CheckOut>(co => co.ReservaId);
        }
    }
}
