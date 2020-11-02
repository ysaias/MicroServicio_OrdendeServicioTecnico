using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Servicio.Domain.Model.Servicio;
using Tienda.SharedKernel.Core;

namespace Tienda.Distribucion.Domain.Model.Servicio.Rules
{
    public class ChangeOrdenStatusRule : IBusinessRule
    {
        private readonly EstadoOrdenServicio oldStatus;
        private readonly EstadoOrdenServicio newStatus;

        public ChangeOrdenStatusRule(EstadoOrdenServicio oldStatus, EstadoOrdenServicio newStatus)
        {
            this.oldStatus = oldStatus;
            this.newStatus = newStatus;
        }

        public string Message => "No se puede cambiar del estado " + oldStatus.ToString() + 
            " al estado " + newStatus.ToString() ; 

        public bool IsBroken()
        {
            if(newStatus == EstadoOrdenServicio.ListoParaServicio && oldStatus != EstadoOrdenServicio.Pendiente)
                return false;

            if (newStatus == EstadoOrdenServicio.Anulado &&
                (oldStatus != EstadoOrdenServicio.Pendiente || oldStatus != EstadoOrdenServicio.ListoParaServicio))
                return false;

            if (newStatus == EstadoOrdenServicio.Pendiente && oldStatus != EstadoOrdenServicio.ListoParaServicio)
                return false;

            if (newStatus == EstadoOrdenServicio.Finalizado && oldStatus != EstadoOrdenServicio.ListoParaServicio)
                return false;

            return true;
        }
    }
}
