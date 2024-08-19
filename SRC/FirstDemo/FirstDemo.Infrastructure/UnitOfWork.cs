using FirstDemo.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Infrastructure
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        //protected IAdoNetUtility AdoNetUtility { get; private set; }

        public UnitOfWork(DbContext dbContext) => _dbContext = dbContext;


        public void Dispose() => _dbContext?.Dispose();
        //public ValueTask DisposeAsync() => _dbContext.DisposeAsync();
        public void Save() => _dbContext?.SaveChanges();
        //public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
