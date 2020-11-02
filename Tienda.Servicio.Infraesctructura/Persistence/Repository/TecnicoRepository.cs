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
    public class TecnicoRepository : ITecnicoRepository
    {
        private readonly ApplicationDbContext _context;

        public TecnicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Tecnico> GetAll()
        {
            List<Tecnico> tecnicos =  _context.Tecnicos.ToList();
            return tecnicos;
        }

        public async Task<Tecnico> GetTecnicoBiId(Guid tecnicoId)
        {
            Tecnico obj = await _context.Tecnicos.Where(o => o.Id == tecnicoId).FirstOrDefaultAsync();
            return obj;
        }

        
         public async Task Insert(Tecnico tecnico)
        {
            await _context.Tecnicos.AddAsync(tecnico);
        }

      

        public async Task tecnicoDelete(Guid tecnicoId)
        {
            Tecnico obj = await GetTecnicoBiId(tecnicoId);
            _context.Tecnicos.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
}
