using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mocks.domain.Entities;
using mocks.domain.Interfaces;

namespace mocks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }
    

        // GET: api/Documents/5
        [HttpGet]
        public async Task<IActionResult> Get(string url)
        {
            var doc = await _documentService.DownLoad(url);

            return File(doc.File, doc.Type, doc.Name);
        }

        // POST: api/Documents
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile document, string guid)
        {

            var doc = new Document()
            {
                File = document.OpenReadStream(),
                Name = document.FileName,
                Type = document.ContentType,
                Guid = guid
            };

            return Ok(await _documentService.Save(doc));
        }

        // PUT: api/Documents/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
