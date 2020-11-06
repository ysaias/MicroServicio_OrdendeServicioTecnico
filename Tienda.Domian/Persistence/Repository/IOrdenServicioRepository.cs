using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.Servicio.Domain.Model.Servicio;

namespace Tienda.Servicio.Domain.Persistence.Repository
{
    public interface IOrdenServicioRepository
    {
        Task Insert(OrdenServicio ordenServicio);
        Task<OrdenServicio> GetOrdenServicioBiId(Guid ordenServicioId);

        Task InsertCitaTecnico(CitaTecnico citaTecnico);
        Task<CitaTecnico> GetCitaTecnicoById(Guid citaTecnicoId);

        Task<Cita> GetCitaById(Guid citaId);

        Task InsertDetalleCita(DetalleCita detalleCita);
        Task<DetalleCita> GetDetalleCitaById(Guid detalleCitaId);
       

        Task InsertDetalleServicio(DetalleServicio detalleServicio);

        List<Cita> GetListaCitasByOrdenId(Guid ordenId);
        Task<Cliente> GetClienteById(Guid clienteId);

        Task<OrdenServicio> GetOrdenServicioBiIdCita(Guid citaId);

    }
}
