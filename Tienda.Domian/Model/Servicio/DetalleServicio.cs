using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Servicio.Domain.Model.Servicio
{
    public class DetalleServicio : Entity
    {
        public Guid Id { get; private set; }

        
        public DateTime fechaDetalle { get; private set; }
        public string Detalle { get; private set; }
        public OrdenServicio OrdenServicio { get; private set; }
        public DetalleServicio(string detalle, OrdenServicio ordenServicio)
        {
            CheckRule(new NotNullRule<string>(detalle));

            Id = Guid.NewGuid();
            fechaDetalle = DateTime.Now;
            Detalle = detalle;
            OrdenServicio = ordenServicio;
        }

        protected DetalleServicio() { }
    }
}
