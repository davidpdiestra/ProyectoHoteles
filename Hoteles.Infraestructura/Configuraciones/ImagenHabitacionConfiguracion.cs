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
    public class ImagenHabitacionConfiguracion : IEntityTypeConfiguration<ImagenHabitacion>
    {
        public void Configure(EntityTypeBuilder<ImagenHabitacion> builder)
        {
            builder.ToTable("ImagenHabitacion");

            builder.HasKey(ih => ih.Id);
            builder.Property(ih => ih.Id).ValueGeneratedOnAdd();
            builder.Property(ih => ih.Url).IsRequired().HasMaxLength(500);
            builder.Property(ih => ih.Descripcion).HasMaxLength(300);

            builder.HasOne(ih => ih.Habitacion)
                   .WithMany(h => h.Imagenes)
                   .HasForeignKey(ih => ih.HabitacionId);
        }
    }
}
