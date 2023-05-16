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
        Task<IEnumerable<App>> GetPurchasedAppsRequestAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client);
    }
}
