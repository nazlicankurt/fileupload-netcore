using DocumentUploadAPI.Application.Services;
using DocumentUploadAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace DocumentUploadAPI.Application.Services
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        IRepository<T> GetRepository<T>() where T : class;

    }


}

