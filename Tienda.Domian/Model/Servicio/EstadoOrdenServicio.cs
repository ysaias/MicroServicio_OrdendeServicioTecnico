using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Servicio.Domain.Model.Servicio
{
    public enum EstadoOrdenServicio
    {
        Pendiente = 1,
        ListoParaServicio = 2,
        Finalizado = 3,
        Anulado = 4
    }
}
