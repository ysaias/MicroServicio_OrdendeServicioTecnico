using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Servicio.Domain.Model.Servicio;

namespace Tienda.Servicio.Infraesctructura.EntityConfiguration
{
    public class DetalleCitaEntityTypeConfiguration :
        IEntityTypeConfiguration<DetalleCita>
    {
        public void Configure(EntityTypeBuilder<DetalleCita> builder)
        {
            builder.HasKey(x => x.Id);
     
            builder.Property(x => x.Detalle)
                .IsRequired();


        }
    }
}
