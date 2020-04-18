using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mocks.infrastructure.Repositories.Base
{
    public class BaseBlobRepository
    {
        protected readonly CloudStorageAccount cloudStorageAccount;
        protected readonly CloudBlobClient cloudBlobClient;

        public BaseBlobRepository(string conn)
        {
            cloudStorageAccount = CloudStorageAccount.Parse(conn);
            cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
        }

        protected async Task SetMetadata(CloudBlockBlob blob, string key, string value)
        {
            blob.Metadata.Add(key, value);

            await blob.SetMetadataAsync();
        }

        protected async Task<string> GetMetadata(CloudBlockBlob blob, string key)
        {
            string response = "";
            await blob.FetchAttributesAsync();

            foreach (var metadataItem in blob.Metadata)
            {
                if (metadataItem.Key == key)
                {
                    response = metadataItem.Value;
                    break;
                }
            }

            return response;
        }
    }
}
