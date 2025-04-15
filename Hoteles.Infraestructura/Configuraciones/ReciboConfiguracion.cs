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
    public class ReciboConfiguracion : IEntityTypeConfiguration<Recibo>
    {
        public void Configure(EntityTypeBuilder<Recibo> builder)
        {
            builder.ToTable("Recibo");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.PagoId).IsRequired();

            builder.Property(r => r.NumeroRecibo).IsRequired().HasMaxLength(100);

            builder.Property(r => r.FechaEmision).IsRequired();

            builder.HasOne(r => r.Pago)

                   .WithOne(p => p.Recibo)

                   .HasForeignKey<Recibo>(r => r.PagoId);

        }
    }
}
