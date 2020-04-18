using mocks.domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace mocks.domain.Interfaces
{
    public interface IDocumentService
    {
        Task<Document> Save(Document document);
        Task<Document> DownLoad(string url);
    }
}
