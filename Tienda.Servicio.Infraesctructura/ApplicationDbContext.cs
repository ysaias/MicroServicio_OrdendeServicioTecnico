using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Tienda.Servicio.Domain.Model.Servicio;
using Tienda.Servicio.Infraesctructura.EntityConfiguration;

namespace Tienda.Servicio.Infraesctructura
{
    public class ApplicationDbContext : DbContext
    {
       
        public DbSet<Cita> Citas { get; set; }
       /// public DbSet<List<Cita>> CitaList { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CitaTecnico> CitaTecnicos { get; set; }
        public DbSet<DetalleCita> DetalleCitas { get; set; }
        public DbSet<DetalleServicio> DetalleServicios { get; set; }
        public DbSet<FormularioTrabajo> FormularioTrabajos { get; set; }
        public DbSet<OrdenServicio> OrdenServicios { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClienteTypeCofiguration());
            modelBuilder.ApplyConfiguration(new CitaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CitaTecnicoItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DetalleCitaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DetalleServicioTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FormularioTrabajoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrdenServicioEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TecnicoTypeCofiguration());
            
        }
    }
}
