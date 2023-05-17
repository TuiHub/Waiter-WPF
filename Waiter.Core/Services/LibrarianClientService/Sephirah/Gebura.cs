using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.Sephirah.V1;
using Waiter.Core.Contracts.Services;
using Waiter.Core.Helpers;
using Waiter.Core.Models;

namespace Waiter.Core.Services
{
    public partial class LibrarianClientService : ILibrarianClientService
    {
        public async Task<IEnumerable<Models.App>> GetPurchasedAppsAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client)
        {
            var resp = await client.GetPurchasedAppsAsync(
                                        new GetPurchasedAppsRequest(),
                                        headers: JwtHelper.GetMetadataWithAccessToken());
            // https://stackoverflow.com/questions/65917317/why-am-i-not-allowed-to-return-an-iasyncenumerable-in-a-method-returning-an-iasy
            //return resp.Apps.Select(x => new Models.App());
            //foreach (var app in resp.Apps)
            //{
            //    yield return new Models.App(app);
            //}

            return resp.Apps.Select(x => new Models.App(x));
        }
    }
}
