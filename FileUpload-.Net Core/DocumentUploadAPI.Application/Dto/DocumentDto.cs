using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentUploadAPI.Application.Dto
{
    public class DocumentDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("file")]
        public IFormFile File { get; set; }
    }
}
