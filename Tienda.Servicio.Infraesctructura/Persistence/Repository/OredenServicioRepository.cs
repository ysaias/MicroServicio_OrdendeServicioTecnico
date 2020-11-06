using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Servicio.Domain.Model.Servicio;
using Tienda.Servicio.Domain.Persistence.Repository;

namespace Tienda.Servicio.Infraesctructura.Persistence.Repository
{
    public class OredenServicioRepository : IOrdenServicioRepository
    {
        private readonly ApplicationDbContext _context;

        public OredenServicioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CitaTecnico> GetCitaTecnicoById(Guid citaTecnicoId)
        {
            CitaTecnico obj = await _context.CitaTecnicos.Where(o => o.Id == citaTecnicoId).FirstOrDefaultAsync();
            return obj;
        }
        
        public async Task<Cita> GetCitaById(Guid citaId)
        {
            Cita obj = await _context.Citas.Where(o => o.Id == citaId).FirstOrDefaultAsync();
            return obj;
        }


        public async Task<OrdenServicio> GetOrdenServicioBiId(Guid ordenServicioId)
        {
            OrdenServicio obj = await _context.OrdenServicios.Where(o => o.Id == ordenServicioId).FirstOrDefaultAsync();
            return obj;
        }


        public async Task<OrdenServicio> GetOrdenServicioBiIdCita(Guid citaId)
        {

            Cita obj = await _context.Citas.Include(x => x.OrdenServicio).Where(o => o.Id == citaId).FirstOrDefaultAsync();
            OrdenServicio objOrden = await _context.OrdenServicios.Where(o => o.Id == obj.OrdenServicio.Id).FirstOrDefaultAsync();
            return objOrden;
        }



        public async Task  Insert(OrdenServicio ordenServicio)
        {

            await _context.OrdenServicios.AddAsync(ordenServicio);
            await _context.Clientes.AddAsync(ordenServicio.Cliente);
            

            foreach( var cita in ordenServicio.Citas)
            {
                await _context.Citas.AddAsync(cita);
            }
        }

        public async Task InsertCitaTecnico(CitaTecnico citaTecnico)
        {
            await _context.CitaTecnicos.AddAsync(citaTecnico);
        }

        public async Task InsertTecnico(Tecnico tecnico)
        {
            await _context.Tecnicos.AddAsync(tecnico);
        }

        public async Task InsertDetalleCita(DetalleCita detalleCita)
        {
            await _context.DetalleCitas.AddAsync(detalleCita);
        }

        public async Task<DetalleCita> GetDetalleCitaById(Guid detalleCitaId)
        {
            DetalleCita obj = await _context.DetalleCitas.Where(o => o.Id == detalleCitaId).FirstOrDefaultAsync();
            return obj;
        }

        public async Task InsertDetalleServicio(DetalleServicio detalleServicio)
        {
            await _context.DetalleServicios.AddAsync(detalleServicio);
        }

        //public async Task<List<Cita>> GetListaCitasByOrdenId(Guid ordenId)
        //{
            
        //    List<Cita> obj = await _context.Citas.Where(o => o.OrdenServicio.Id == ordenId).ToListAsync();
        //    return obj;
            
        //}

        public async Task<Cliente> GetClienteById(Guid clienteId)
        {
            Cliente obj = await _context.Clientes.Where(o => o.Id == clienteId).FirstOrDefaultAsync();
            return obj;
        }

        public List<Cita> GetListaCitasByOrdenId(Guid ordenId)
        {
            List<Cita> obj =  _context.Citas.Where(o => o.OrdenServicio.Id == ordenId).ToList();
            return obj;

        }
    }
}
