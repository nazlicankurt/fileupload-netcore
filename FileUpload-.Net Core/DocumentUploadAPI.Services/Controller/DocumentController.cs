using DocumentUploadAPI.Application.Dto;
using DocumentUploadAPI.Domain.Models;
using DocumentUploadAPI.Infrastructure.Context;
using DocumentUploadAPI.Infrastructure.UoW;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace DocumentUploadAPI.Services.Controller
{

    [ApiController]
    [Route("/api/v1/[controller]")]
    public class DocumentController : ControllerBase
    {

        [HttpGet(nameof(GetFiles))]
        public IActionResult GetFiles()
        {
            try
            {
                using (var uow = new UnitOfWork<DocumentContext>())
                {
                    var list = uow.GetRepository<Document>().GetAll().ToList();
                    return Ok(list);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost(nameof(AddNewDocument))]
        public IActionResult AddNewDocument([FromForm] DocumentDto documents)
        {
            if (documents == null)
            {

            }
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                using (var uow = new UnitOfWork<DocumentContext>())
                {
                    documents.File.CopyToAsync(memoryStream);
                    uow.GetRepository<Document>().Add(new Document
                    {
                        Name = documents.Name,
                        FileName = documents.File.FileName,
                        ContentType = documents.File.ContentType,
                        Length = documents.File.Length,
                        File = memoryStream.ToArray()
                    });
                    uow.Commit();
                }
                return Ok();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
           
            using (var uow = new UnitOfWork<DocumentContext>())
            {
               
                uow.GetRepository<Document>().Remove(id);
                uow.Commit();
                return Ok(id);
            }
      
        

        }
 
    }

}

