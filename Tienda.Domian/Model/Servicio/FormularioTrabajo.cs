using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Servicio.Domain.Model.Servicio
{
     public class FormularioTrabajo : Entity
    {
        public Guid Id { get; private set; }
        public Cita Cita { get; set; }
        public string Informe { get; private set; }
        public string MedidaAtencion { get; private set; }


        public FormularioTrabajo(string informe, string medidaAtencion, Cita cita)
        {
            CheckRule(new NotNullRule<string>(informe));
            CheckRule(new NotNullRule<string>(medidaAtencion));

            Id = Guid.NewGuid();
            Informe = informe;
            MedidaAtencion = medidaAtencion;
            Cita = cita;
        }

        protected FormularioTrabajo() { }
    }
}
