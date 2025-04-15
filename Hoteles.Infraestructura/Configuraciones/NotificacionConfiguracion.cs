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
    public class NotificacionConfiguracion : IEntityTypeConfiguration<Notificacion>
    {
        public void Configure(EntityTypeBuilder<Notificacion> builder)
        {
            builder.ToTable("Notificacion");

            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id).ValueGeneratedOnAdd();

            builder.Property(n => n.Titulo)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(n => n.Mensaje)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(n => n.FechaEnvio)
                   .IsRequired();

            builder.Property(n => n.Enviada)
                   .HasDefaultValue(false);

            builder.HasOne(n => n.Cliente)
                   .WithMany()
                   .HasForeignKey(n => n.ClienteId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(n => n.Reserva)
                   .WithMany()
                   .HasForeignKey(n => n.ReservaId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
