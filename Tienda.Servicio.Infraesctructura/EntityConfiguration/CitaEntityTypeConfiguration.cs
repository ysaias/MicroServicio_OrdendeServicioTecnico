using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Servicio.Domain.Model.Servicio;

namespace Tienda.Servicio.Infraesctructura.EntityConfiguration
{
    public class CitaEntityTypeConfiguration
        : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Codigo)
                .HasColumnName("codigo")
                .IsRequired();

            builder.Property(x => x.Direccion)
                .HasColumnName("direccion")
                .IsRequired();

            builder.Ignore(x => x.CitaTecnico);
            builder.Ignore(x => x.DetalleCita);
            builder.Ignore(x => x.FormularioTrabajo);
        }
    }
}
