using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Tienda.Distribucion.Domain.Model.Servicio.Rules;
using Tienda.SharedKernel.Core;
using Tienda.SharedKernel.ValueObjects;
using Tienda.SharedKernel.ValueObjects.PhoneNumber;
using Tienda.SharedKernel.ValueObjects.PrecioNumber;

namespace Tienda.Servicio.Domain.Model.Servicio
{
    public class OrdenServicio : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public DateTime FechaRegistro { get; private set; }
        public DateTime? FechaConsolidacion { get; private set; }
        public DateTime? FechaAnulacion { get; private set; }
        public DateTime? FechaFinalizacion { get; private set; }
        public EstadoOrdenServicio Estado { get; private set; }
        public PrecioNumberValue Precio { get; private set; }

        public Cliente Cliente { get; private set; }
        //public DetalleServicio DetalleServicio { get; private set; }

        private List<Cita> _citas;

       
        

        public OrdenServicio(
            string precio,
            Cliente cliente,     
            ICollection<Cita> citas)
        {
            Id = Guid.NewGuid();
            FechaRegistro = DateTime.Now;

            Precio = precio;
            Estado = EstadoOrdenServicio.Pendiente;
            Cliente = cliente;
           // detalleServicio.OrdenServicio = this;
           // DetalleServicio = detalleServicio;


            _citas = new List<Cita>();

            foreach (var cita in citas)
            {
                cita.OrdenServicio = this;
               
                _citas.Add(cita);
            }
        }

        protected OrdenServicio() { }

        public ImmutableList<Cita> Citas
        {
            get
            {
                return _citas.ToImmutableList<Cita>();
            }
        }

        public void ConsolidarOrdenServicio()
        {
            CheckRule(new ChangeOrdenStatusRule (Estado, EstadoOrdenServicio.ListoParaServicio));
            FechaConsolidacion = DateTime.Now;
            Estado = EstadoOrdenServicio.ListoParaServicio;
        }

        public void FinalizarServicio()
        {
            CheckRule(new ChangeOrdenStatusRule(Estado, EstadoOrdenServicio.Finalizado));
            FechaFinalizacion = DateTime.Now;
            Estado = EstadoOrdenServicio.Finalizado;
        }

        public void AnularServicio()
        {
            CheckRule(new ChangeOrdenStatusRule(Estado, EstadoOrdenServicio.Anulado));
            FechaAnulacion = DateTime.Now;
            Estado = EstadoOrdenServicio.Anulado;
        }
        


    }
}
