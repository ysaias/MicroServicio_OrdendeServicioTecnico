using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Servicio.Domain.Model.Servicio;

namespace Tienda.Servicio.Infraesctructura.EntityConfiguration
{
    public class CitaTecnicoItemEntityTypeConfiguration
        : IEntityTypeConfiguration<CitaTecnico>
    {
        public void Configure(EntityTypeBuilder<CitaTecnico> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Codigo)
                .HasColumnName("codigo")
                .IsRequired();

            builder.Property(x => x.FechaHoraCita)
                .HasColumnName("fechaHora")
                .IsRequired();

        }
    }
}
