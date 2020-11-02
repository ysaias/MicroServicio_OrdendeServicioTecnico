using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Servicio.Domain.Model.Servicio;

namespace Tienda.Servicio.Infraesctructura.EntityConfiguration
{
    public class OrdenServicioEntityTypeConfiguration :
        IEntityTypeConfiguration<OrdenServicio>
    {
        public void Configure(EntityTypeBuilder<OrdenServicio> builder)
        {
            builder
                .HasKey(x => x.Id)
                .HasName("ordenServicioId");

            builder.Property(x => x.FechaRegistro)
                .IsRequired();

            builder.Property(x => x.Estado)
                .HasColumnName("estado")
                .IsRequired();

            builder.OwnsOne(x => x.Precio)
               .Property(x => x.Value)
               .HasColumnName("precio")
               .IsRequired();



            _ = builder.Ignore(x => x.Citas);

            //builder.Ignore(x => x.DetalleServicio);

            /*
             * 
              public EstadoOrdenServicio Estado { get; private set; }
              public PersonNameValue NombreCliente { get; private set; }
              public PhoneNumberValue Telefono { get; private set; }

             */
        }
    }
}
