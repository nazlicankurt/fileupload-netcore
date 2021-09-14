using DocumentUploadAPI.Application.Dto;
using DocumentUploadAPI.Application.Interfaces;
using DocumentUploadAPI.Domain.Interfaces;
using DocumentUploadAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
namespace DocumentUploadAPI.Application.Services
{

    public class DocumentService : IDocumentService
    {

        private IUnitOfWork uow;


        public void CreateFile([FromForm] DocumentDto documents)
        {
            if (documents == null)
            {

            }
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
              
                {
                    //documents.File.CopyToAsync(memoryStream);
                    
                    //uow.GetRepository<Document>().Add(new Document
                    //{
                    //    Name = documents.Name,
                    //    FileName = documents.File.FileName,
                    //    ContentType = documents.File.ContentType,
                    //    Length = documents.File.Length,
                    //    File = memoryStream.ToArray()
                    //});
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public Task<dynamic> GetFile()
        {
            throw new NotImplementedException();
        }


    }
}
