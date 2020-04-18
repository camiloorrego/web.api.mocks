using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage.Blob;
using mocks.domain.Entities;
using mocks.domain.Interfaces;
using mocks.domain.Settings;
using mocks.infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace mocks.infrastructure.Repositories
{
    public class DocumentRepository : BaseBlobRepository, IDocumentRepository
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly CloudBlobContainer _container;
        public DocumentRepository(IOptions<AppSettings> settings) : base(settings.Value.BlobConnectionString)
        {
            _settings = settings;
            _container = cloudBlobClient.GetContainerReference(_settings.Value.ContainerTemp);
            _container.CreateIfNotExistsAsync();
        }

        public async Task<Document> DownLoad(string url)
        {
            var response = new Document();


            var blockBlob = new CloudBlockBlob(new Uri(url), cloudStorageAccount.Credentials);

            if (await blockBlob.ExistsAsync())
            {
                response.File = await blockBlob.OpenReadAsync();
                response.Url = url;
                response.Name = await GetMetadata(blockBlob, "Name");
                response.Type = await GetMetadata(blockBlob, "Type");
            }

            return response;
        }

        public async Task<Document> Save(Document document)
        {
            var blockBlob = _container.GetBlockBlobReference(document.Guid);
            await blockBlob.UploadFromStreamAsync(document.File);
            await SetMetadata(blockBlob, "Name", document.Name);
            await SetMetadata(blockBlob, "Type", document.Type);

            document.Url = blockBlob.Uri.AbsoluteUri;
            document.File = null;

            return document;
        }
    }
}
