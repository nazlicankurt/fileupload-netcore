using DocumentUploadAPI.Domain.Interfaces;
using DocumentUploadAPI.Infrastructure.Context;
using DocumentUploadAPI.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using DocumentUploadAPI.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace DocumentUploadAPI.Infrastructure.UoW
{
    public class UnitOfWork<T> : IUnitOfWork
    {

        private DocumentContext _context;

        public DocumentContext Context
        {
            get
            {

                if (_context == null)
                {
                    _context = (DocumentContext)Activator.CreateInstance(typeof(T));
                }
                return _context;
            }
            set
            {

                _context = value;
            }
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(Context);
        }
    }
}
