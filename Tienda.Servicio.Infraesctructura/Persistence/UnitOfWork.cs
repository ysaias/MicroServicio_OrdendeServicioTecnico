using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.Servicio.Domain.Persistence;

namespace Tienda.Servicio.Infraesctructura.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
            => _dbContext = dbContext;

        public Task Commit() => _dbContext.SaveChangesAsync();
    }
}
