using Hoteles.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Infraestructura.Configuraciones
{
    public class ClienteConfiguracion : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes"); // Nombre de la tabla

            builder.HasKey(c => c.Id); // Clave primaria

            builder.Property(c => c.Nombre)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c => c.Apellido)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c => c.Email)
                   .HasMaxLength(150);

            builder.Property(c => c.Telefono)
                   .HasMaxLength(20);

            builder.Property(c => c.FechaNacimiento)
              .IsRequired();

            builder.Property(c => c.Activo)
                   .HasDefaultValue(true); // Activo por defecto
        }
    }
}
