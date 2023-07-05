using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.Sephirah.V1;
using TuiHub.Protos.Librarian.V1;
using Waiter.Core.Contracts.Services;
using Waiter.Core.Helpers;
using Waiter.Core.Models;

namespace Waiter.Core.Services
{
    public partial class LibrarianClientService : ILibrarianClientService
    {
        public async Task SimpleUploadFile(LibrarianSephirahService.LibrarianSephirahServiceClient client, string uploadToken,
            Stream stream, int chunkBytes, long? fileSizeBytes = null, IProgress<int>? progress = null)
        {
            var call = client.SimpleUploadFile(headers: JwtHelper.GetMetadataWithJwt(uploadToken));

            var readTask = Task.Run(async () =>
            {
                await foreach (var msg in call.ResponseStream.ReadAllAsync())
                {
                    Debug.WriteLine($"Core.ClientService.SimpleUploadFile: Read msg.Status = {msg.Status.ToString()}");
                    if (msg.Status == FileTransferStatus.Success)
                    {
                        break;
                    }
                    else if (msg.Status == FileTransferStatus.Failed)
                    {
                        throw new Exception("Server reported file transfer failed.");
                    }
                }
            });

            long uploadedBytes = 0;
            var buffer = new byte[chunkBytes];
            while (true)
            {
                var readBytes = await stream.ReadAsync(buffer);
                Debug.WriteLine($"Core.ClientService.SimpleUploadFile: readBytes = {readBytes}");
                if (readBytes == 0)
                {
                    break;
                }
                await call.RequestStream.WriteAsync(new SimpleUploadFileRequest
                {
                    Data = UnsafeByteOperations.UnsafeWrap(buffer.AsMemory(0, readBytes))
                });
                if (fileSizeBytes != null && progress != null)
                {
                    uploadedBytes += readBytes;
                    progress.Report((int)((double)uploadedBytes / (double)fileSizeBytes * 100.0));
                }
            }
            await call.RequestStream.CompleteAsync();
            await readTask;
        }

        public async Task SimpleDownloadFile(LibrarianSephirahService.LibrarianSephirahServiceClient client, string downloadToken, Stream stream,
            long? fileSizeBytes = null, IProgress<int>? progress = null)
        {
            var call = client.SimpleDownloadFile(new SimpleDownloadFileRequest(),
                                                 headers: JwtHelper.GetMetadataWithJwt(downloadToken));
            long downloadedBytes = 0;
            await foreach (var msg in call.ResponseStream.ReadAllAsync())
            {
                Debug.WriteLine($"Core.ClientService.SimpleDownloadFile: Read msg.Data.Length = {msg.Data.Length}");
                await stream.WriteAsync(msg.Data.Memory);
                if (fileSizeBytes != null && progress != null)
                {
                    downloadedBytes += msg.Data.Length;
                    progress.Report((int)((double)downloadedBytes / (double)fileSizeBytes * 100.0));
                }
            }
        }
    }
}
