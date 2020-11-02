using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Servicio.Domain.Model.Servicio
{
    public class Cita : Entity
    {
        public Guid Id { get; private set; }

        public OrdenServicio OrdenServicio { get; set; }
        public string Codigo { get; private set; }
        public string Direccion { get; private set; }

        //Referencias para obtener el Id de esta CLASSE en las clases listadas  
        public CitaTecnico CitaTecnico { get; set; }
        public DetalleCita DetalleCita { get; set; }
        public FormularioTrabajo FormularioTrabajo { get; set; }


        public Cita(string codigo, string direccion)
        {
            CheckRule(new NotNullRule<string>(codigo)); 

            Id = Guid.NewGuid();
            Codigo = codigo;
            Direccion = direccion;
        }
        public Cita(Guid id, string codigo, string direccion)
        {
            CheckRule(new NotNullRule<string>(codigo)); 
            CheckRule(new NotNullRule<string>(direccion)); 

            Id = id;
            Codigo = codigo;
            Direccion = direccion;
            
        }

        protected Cita() { }
    }
}
