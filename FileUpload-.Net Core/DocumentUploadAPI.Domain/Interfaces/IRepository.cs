using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentUploadAPI.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        void Update(TEntity obj);
        void Remove(int id);
        IQueryable<TEntity> GetAll();
    }
}
