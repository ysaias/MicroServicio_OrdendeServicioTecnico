using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.Servicio.Domain.Model.Servicio;

namespace Tienda.Servicio.Domain.Persistence.Repository
{
    public interface ITecnicoRepository
    {
        Task Insert(Tecnico tecnico);
        Task<Tecnico> GetTecnicoBiId(Guid tecnicoId);

        List<Tecnico> GetAll();

        Task tecnicoDelete(Guid tecnicoId);

    }
}
