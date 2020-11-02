using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Servicio.Domain.Model.Servicio;

namespace Tienda.Servicio.Infraesctructura.EntityConfiguration
{
    public class DetalleServicioTypeConfiguration :
        IEntityTypeConfiguration<DetalleServicio>
    {
        public void Configure(EntityTypeBuilder<DetalleServicio> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Detalle)
            .IsRequired();

            builder.Property(x => x.fechaDetalle)
                .IsRequired();
        }
    }
}
