using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.SharedKernel.ValueObjects;
using Tienda.SharedKernel.ValueObjects.PhoneNumber;

namespace Tienda.Servicio.Domain.Model.Servicio
{
    public class Tecnico : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }

        //El Tecnico debe tener un codigo de reconocimiento     
        public string Codigo { get; private set; }
        public PersonNameTecnicoValue NombreTecnico { get; private set; }
        public PhoneNumberTecnicoValue Telefono { get; private set; }

        public CitaTecnico CitaTecnico { get; set; }

     
        public Tecnico(string codigo, string nombreTecnico,
            string telefono)
        {
            CheckRule(new NotNullRule<string>(codigo));
            CheckRule(new NotNullRule<string>(nombreTecnico));
            CheckRule(new NotNullRule<string>(telefono));

            Id = Guid.NewGuid();
            Codigo = codigo;
            NombreTecnico = nombreTecnico;
            Telefono = telefono;
        }
            protected Tecnico() { }

        public static implicit operator Tecnico(CitaTecnico v)
        {
            throw new NotImplementedException();
        }
    }
}