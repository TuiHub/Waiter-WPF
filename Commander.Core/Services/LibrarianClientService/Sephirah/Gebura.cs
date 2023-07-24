using Commander.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.Sephirah.V1;
using TuiHub.Protos.Librarian.V1;

namespace Commander.Core.Services
{
    public partial class LibrarianClientService
    {
        public async Task<IEnumerable<Models.App>> ListAppsAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client,
            int pageNum, int pageSize, long? internalId, AppType? appType, AppSource? appSource, string? name, bool containsDetails = false)
        {
            var request = new ListAppsRequest
            {
                Paging = new PagingRequest
                {
                    PageNum = pageNum,
                    PageSize = pageSize
                },
                ContainDetails = containsDetails
            };
            if (internalId != null) request.IdFilter.Add(new InternalID { Id = (long)internalId });
            if (appType != null) request.TypeFilter.Add((AppType)appType);
            if (appSource != null) request.SourceFilter.Add((AppSource)appSource);
            var response = await client.ListAppsAsync(request,
                                                      headers: JwtHelper.GetMetadataWithAccessToken());
            return response.Apps.Select(x => new Models.App(x));
        }
        public async Task<IEnumerable<Models.AppPackage>> ListAppPackagesAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client,
            int pageNum, int pageSize, AppPackageSource? appPackageSource, long? internalId, long? parentAppInternalId)
        {
            var request = new ListAppPackagesRequest
            {
                Paging = new PagingRequest
                {
                    PageNum = pageNum,
                    PageSize = pageSize
                }
            };
            if (internalId != null) request.IdFilter.Add(new InternalID { Id = (long)internalId });
            if (parentAppInternalId != null) request.IdFilter.Add(new InternalID { Id = (long)parentAppInternalId });
            if (appPackageSource != null) request.SourceFilter.Add((AppPackageSource)appPackageSource);
            var response = await client.ListAppPackagesAsync(request,
                                                             headers: JwtHelper.GetMetadataWithAccessToken());
            return response.AppPackages.Select(x => new Models.AppPackage(x));
        }
    }
}
