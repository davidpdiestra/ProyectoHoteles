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
    public class PagoConfiguracion : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            builder.ToTable("Pago");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.ReservaId).IsRequired();
            builder.Property(p => p.PasarelaPagoId).IsRequired();
            builder.Property(p => p.Monto).IsRequired();
            builder.Property(p => p.FechaPago).IsRequired();
            builder.Property(p => p.EstadoTransaccion).IsRequired().HasMaxLength(100);

            builder.HasOne(p => p.Reserva)
                   .WithMany(r => r.Pagos)
                   .HasForeignKey(p => p.ReservaId);

            builder.HasOne(p => p.PasarelaPago)
                   .WithMany(pp => pp.Pagos)
                   .HasForeignKey(p => p.PasarelaPagoId);
        }
    }
}
