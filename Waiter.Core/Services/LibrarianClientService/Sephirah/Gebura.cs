using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
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
        public async Task<IEnumerable<Models.AppPackage>> GetAppPackagesAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client, long appId)
        {
            var listAppReq = new ListAppPackagesRequest
            {
                Paging = new TuiHub.Protos.Librarian.V1.PagingRequest
                {
                    PageNum = 1,
                    PageSize = 1000
                },
                AssignedAppIdFilter =
                {
                    new InternalID { Id = appId }
                }
            };
            var resp = await client.ListAppPackagesAsync(
                                        listAppReq,
                                        headers: JwtHelper.GetMetadataWithAccessToken());
            return resp.AppPackages.Select(x => new Models.AppPackage(x));
        }

        public async Task AddAppPackageRunTime(LibrarianSephirahService.LibrarianSephirahServiceClient client, long appPackageId, DateTime startDT, TimeSpan duration)
        {
            var addAppPackageRunTimeReq = new AddAppPackageRunTimeRequest
            {
                AppPackageId = new InternalID { Id = appPackageId },
                TimeRange = new TimeRange
                {
                    StartTime = Timestamp.FromDateTime(startDT),
                    Duration = Duration.FromTimeSpan(duration)
                }
            };
            await client.AddAppPackageRunTimeAsync(addAppPackageRunTimeReq);
        }

        public async Task<TimeSpan> GetAppPackageRunTime(LibrarianSephirahService.LibrarianSephirahServiceClient client, long appPackageId)
        {
            var getAppPackageRunTimeReq = new GetAppPackageRunTimeRequest
            {
                AppPackageId = new InternalID { Id= appPackageId }
            };
            var resp = await client.GetAppPackageRunTimeAsync(getAppPackageRunTimeReq);
            return resp.Duration.ToTimeSpan();
        }
    }
}
