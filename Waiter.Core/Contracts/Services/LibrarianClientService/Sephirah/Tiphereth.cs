using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.Sephirah.V1;

namespace Waiter.Core.Contracts.Services
{
    public partial interface ILibrarianClientService
    {
        // username password login
        // TODO: don't use plain string
        Task<(string, string)> GetTokenAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client, string username, string password);
        // refreshToken reAuth, will not throw exception, null to indicate auth failed
        Task<(string?, string?)> GetTokenAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client);
    }
}
