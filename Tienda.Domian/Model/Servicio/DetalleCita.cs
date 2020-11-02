using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Servicio.Domain.Model.Servicio
{
    public  class DetalleCita : Entity
    {
        public Guid Id { get; private set; }
        public string Detalle { get; private set; }
        public Cita Cita { get; private set; }


        public DetalleCita(string detalle, Cita cita)
        {
            CheckRule(new NotNullRule<string>(detalle));

            Id = Guid.NewGuid();
            Detalle = detalle;
            Cita = cita;
        }

        protected DetalleCita() { }
    }
}
