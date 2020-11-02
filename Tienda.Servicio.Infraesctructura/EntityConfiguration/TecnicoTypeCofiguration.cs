using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Servicio.Domain.Model.Servicio;

namespace Tienda.Servicio.Infraesctructura.EntityConfiguration
{
    public class TecnicoTypeCofiguration :
        IEntityTypeConfiguration<Tecnico>
    {
        public void Configure(EntityTypeBuilder<Tecnico> builder)
        {
            builder.HasKey(x => x.Id)
               .HasName("tecnicoId");

            builder.Property(x => x.Codigo)
                 .HasColumnName("codigo")
                 .IsRequired();

            builder.OwnsOne(x => x.NombreTecnico)
                .Property(x => x.Value)
                .HasColumnName("nombreTecnico")
                .IsRequired();

            builder.OwnsOne(x => x.Telefono)
                .Property(x => x.Value)
                .HasColumnName("telefono")
                .IsRequired();

            builder.Ignore(x => x.CitaTecnico);

            /*
             * 
                public string Codigo { get; private set; }
                public PersonNameValue NombreTecnico { get; private set; }
                public PhoneNumberValue Telefono { get; private set; }

             */
        }
    }
}
