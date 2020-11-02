using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Servicio.Domain.Model.Servicio;

namespace Tienda.Servicio.Infraesctructura.EntityConfiguration
{
    class FormularioTrabajoTypeConfiguration :
        IEntityTypeConfiguration<FormularioTrabajo>
    {
        public void Configure(EntityTypeBuilder<FormularioTrabajo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Informe)
                .IsRequired();

            builder.Property(x => x.MedidaAtencion)
                .IsRequired();


            /*
             * 
                public Cita Cita { get; set; }
                public string Informe { get; private set; }
                public string MedidaAtencion { get; private set; }

             */
        }
    }
}
