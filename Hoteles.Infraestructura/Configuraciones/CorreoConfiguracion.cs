using Hoteles.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoteles.Infraestructura.Configuraciones
{
    public class CorreoConfiguracion : IEntityTypeConfiguration<Correo>
    {
        public void Configure(EntityTypeBuilder<Correo> builder)
        {
            builder.ToTable("Correos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Asunto)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c => c.Mensaje)
                   .IsRequired()
                   .HasMaxLength(1000);
        }
    }
}
