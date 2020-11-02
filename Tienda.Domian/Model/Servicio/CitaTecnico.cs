using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Servicio.Domain.Model.Servicio
{
    public class CitaTecnico : Entity
    {
        public Guid Id { get; private set; }
        public Tecnico  Tecnico { get; private set; }
        public Cita Cita { get; private set; }
        public string Codigo { get; private set; }
        public DateTime FechaHoraCita { get; private set; }

        public CitaTecnico(string codigo, DateTime fechaHora, Tecnico tecnico, Cita cita)
        {
            CheckRule(new NotNullRule<string>(codigo));


            Id = Guid.NewGuid();
            Codigo = codigo;
            FechaHoraCita = fechaHora;
            Tecnico = tecnico;
            Cita = cita;
           
        }
        protected CitaTecnico() { }
    }
}