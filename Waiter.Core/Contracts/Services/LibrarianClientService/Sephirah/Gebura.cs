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
        // get user purchased apps
        Task<IEnumerable<App>> GetPurchasedAppsAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client);
        // get packages for specific app
        Task<IEnumerable<AppPackage>> GetAppPackagesAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client, long appId);
        Task AddAppPackageRunTime(LibrarianSephirahService.LibrarianSephirahServiceClient client, long appPackageId, DateTime startDT, TimeSpan duration);
        Task<TimeSpan> GetAppPackageRunTime(LibrarianSephirahService.LibrarianSephirahServiceClient client, long appPackageId);
        // return UploadToken
        Task<string> UploadGameSaveFile(LibrarianSephirahService.LibrarianSephirahServiceClient client, long appPackageId, FileMetadata fileMetadata);
        Task SimpleUploadFile(LibrarianSephirahService.LibrarianSephirahServiceClient client, string uploadToken, Stream stream, int chunkBytes);
        Task<IEnumerable<GameSave>> GetAppPackageGameSaves(LibrarianSephirahService.LibrarianSephirahServiceClient client, long appPackageId);
    }
}
