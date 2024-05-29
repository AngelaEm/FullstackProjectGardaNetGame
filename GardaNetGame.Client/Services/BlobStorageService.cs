using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;

namespace GardaNetGame.Client.Services;



// Doesnt work locally.




public class BlobStorageService
{
    private readonly BlobContainerClient _containerClient;

    public BlobStorageService(BlobContainerClient containerClient)
    {
        _containerClient = containerClient;
    }


    public async Task UploadFromStreamAsync(string blobName, Stream content)
    {
        BlobClient blobClient = _containerClient.GetBlobClient(blobName);
        await blobClient.UploadAsync(content, overwrite: true);
    }

    public string GenerateBlobSasUrl(string blobName)
    {
        var blobClient = _containerClient.GetBlobClient(blobName);

        var sasBuilder = new BlobSasBuilder
        {
            BlobContainerName = _containerClient.Name,
            BlobName = blobName,
            Resource = "b", 
            StartsOn = DateTimeOffset.UtcNow,
            ExpiresOn = DateTimeOffset.UtcNow.AddHours(1), 
        };

        sasBuilder.SetPermissions(BlobSasPermissions.Read); 

       var sasToken = blobClient.GenerateSasUri(sasBuilder).ToString();
        return sasToken;
    }

    public List<string> GetBlobNames()
    {
        var blobNames = new List<string>();
        foreach (BlobItem blobItem in _containerClient.GetBlobs())
        {
            blobNames.Add(blobItem.Name);
        }

        return blobNames;
    }



}