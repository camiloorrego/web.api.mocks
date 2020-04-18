using mocks.domain.Entities;
using mocks.domain.Interfaces;
using mocks.domain.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace mocks.domain.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService( IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<Document> DownLoad(string url)
        {
            return await _documentRepository.DownLoad(url);
        }

        public async Task<Document> Save(Document document)
        {
            return await _documentRepository.Save(document);
        }
    }
}
