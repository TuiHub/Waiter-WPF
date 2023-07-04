using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.Sephirah.V1;
using Waiter.Core.Models;

namespace Waiter.Core.Contracts.Services
{
    public partial interface ILibrarianClientService
    {
        Task SimpleUploadFile(LibrarianSephirahService.LibrarianSephirahServiceClient client, string uploadToken, Stream stream,
            int chunkBytes, long? fileSizeBytes = null, IProgress<int>? progress = null);
        Task SimpleDownloadFile(LibrarianSephirahService.LibrarianSephirahServiceClient client, string downloadToken, Stream stream);
    }
}
