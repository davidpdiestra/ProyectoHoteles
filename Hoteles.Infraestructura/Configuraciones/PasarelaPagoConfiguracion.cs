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
    public class PasarelaPagoConfiguracion : IEntityTypeConfiguration<PasarelaPago>
    {
        public void Configure(EntityTypeBuilder<PasarelaPago> builder)
        {
            builder.ToTable("PasarelaPago");

            builder.HasKey(pp => pp.Id);

            builder.Property(pp => pp.Id).ValueGeneratedOnAdd();
            builder.Property(pp => pp.Nombre).IsRequired().HasMaxLength(100);
        }
    }
}
