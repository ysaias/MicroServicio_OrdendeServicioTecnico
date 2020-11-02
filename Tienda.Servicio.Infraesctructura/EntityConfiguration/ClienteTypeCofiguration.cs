using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Servicio.Domain.Model.Servicio;

namespace Tienda.Servicio.Infraesctructura.EntityConfiguration
{
    public class ClienteTypeCofiguration :
        IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id).HasName("clienteId");


            builder.OwnsOne(x => x.NombreCliente)
                .Property(x => x.Value)
                .HasColumnName("nombreCliente")
                .IsRequired();

            builder.OwnsOne(x => x.Telefono)
                .Property(x => x.Value)
                .HasColumnName("telefono")
                .IsRequired();

            builder.Ignore(x => x.OrdenServicio);

            /*
             * 
                public ClienteIdValue Id { get; private set; }
                public PersonNameValue NombreCliente { get; private set; }
                public PhoneNumberValue Telefono { get; private set; }

             */
        }
    }
}
