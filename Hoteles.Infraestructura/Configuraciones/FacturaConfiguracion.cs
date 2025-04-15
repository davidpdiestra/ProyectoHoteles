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
    public class FacturaConfiguracion : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable("Factura");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id).ValueGeneratedOnAdd();

            builder.Property(f => f.CheckOutId).IsRequired();

            builder.Property(f => f.FechaEmision).IsRequired();

            builder.Property(f => f.MontoTotal).IsRequired();

            builder.Property(f => f.Detalle).HasMaxLength(500);

            builder.HasOne(f => f.CheckOut)
                   .WithOne(co => co.Factura)
                   .HasForeignKey<Factura>(f => f.CheckOutId);
        }
    }
}
