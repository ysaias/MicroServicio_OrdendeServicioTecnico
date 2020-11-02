using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.Servicio.Domain.Model.Servicio;

namespace Tienda.Servicio.Domain.Persistence.Repository
{
    public interface IFormularioRepository
    {
        Task Insert(FormularioTrabajo formulario);
        Task<FormularioTrabajo> GetFormularioBiId(Guid formularioId);

        List<FormularioTrabajo> GetAll();

        Task formularioDelelete(Guid formularioId);
    }
}
