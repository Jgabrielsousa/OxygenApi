using Microsoft.EntityFrameworkCore;
using Oxygen.Data.Context;
using Oxygen.Domain.Entities.Base;
using Oxygen.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oxygen.Data.Repository.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase<T>
    {
        
        protected readonly OxygenDbContext _contexto;
        protected DbSet<T> DbSet;

        public RepositoryBase(OxygenDbContext contexto)
        {
            _contexto = contexto;
            DbSet = this._contexto.Set<T>();
        }

        public virtual T Add(T entidade)
        {
            DbSet.Add(entidade);
            _contexto.SaveChanges();
            return entidade;
        }

        public virtual void Remove(T entidade)
        {
            DbSet.Remove(entidade);
            _contexto.SaveChanges();
        }

        public virtual T Find(Guid id) => DbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);

        public virtual IEnumerable<T> GetAll() => DbSet.AsNoTracking().Select(c=>c);

        public virtual void Update(T entidade)
        {
            DbSet.Update(entidade);
            _contexto.SaveChanges();
        }

        public virtual void Dispose()
        { }
    }
}
