using Hoteles.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hoteles.Infraestructura.Configuraciones
{
    public class SmsConfiguracion : IEntityTypeConfiguration<Sms>
    {
        public void Configure(EntityTypeBuilder<Sms> builder)
        {
            builder.ToTable("Sms");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Numero)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(s => s.Mensaje)
                   .IsRequired()
                   .HasMaxLength(500);
        }
    }
}
