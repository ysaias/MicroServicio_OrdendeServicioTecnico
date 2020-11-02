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
    public class FormularioRepository : IFormularioRepository
    {
        private readonly ApplicationDbContext _context;

        public FormularioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FormularioTrabajo> GetFormularioBiId(Guid formularioId)
        {
            FormularioTrabajo obj = await _context.FormularioTrabajos.Where(o => o.Id == formularioId).FirstOrDefaultAsync();
            return obj;
        }

        

        public async Task Insert(FormularioTrabajo formulario)
        {
            await _context.FormularioTrabajos.AddAsync(formulario);
        }


        public List<FormularioTrabajo> GetAll()
        {
            List<FormularioTrabajo> formularios = _context.FormularioTrabajos.ToList();
            return formularios;
        }

        public async Task formularioDelelete(Guid formularioId)
        {
            FormularioTrabajo obj = await GetFormularioBiId(formularioId);
            _context.FormularioTrabajos.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
}
