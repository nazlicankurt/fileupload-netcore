using DocumentUploadAPI.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DocumentUploadAPI.Application.Interfaces
{
   public interface IDocumentService
    {
        void CreateFile(DocumentDto documents);
        Task<dynamic> GetFile();
    }
}
