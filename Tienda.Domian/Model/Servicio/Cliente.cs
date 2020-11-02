using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.ValueObjects;
using Tienda.SharedKernel.ValueObjects.PhoneNumber;
using Tienda.SharedKernel.Core;

namespace Tienda.Servicio.Domain.Model.Servicio
{
    public class Cliente : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public PersonNameValue NombreCliente { get; private set; }
        public PhoneNumberValue Telefono { get; private set; }

        public OrdenServicio OrdenServicio { get; set; }
        public Cliente(string id, string nombreCliente,
           string telefono)
        {
            CheckRule(new NotNullRule<string>(id));
            CheckRule(new NotNullRule<string>(nombreCliente));
            CheckRule(new NotNullRule<string>(telefono));

            Id = new Guid(id);
            NombreCliente = nombreCliente;
            Telefono = telefono;
        }
        protected Cliente() { }
    }
}