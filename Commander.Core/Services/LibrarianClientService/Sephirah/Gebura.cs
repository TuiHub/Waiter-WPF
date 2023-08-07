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
            if (parentAppInternalId != null) request.AssignedAppIdFilter.Add(new InternalID { Id = (long)parentAppInternalId });
            if (appPackageSource != null) request.SourceFilter.Add((AppPackageSource)appPackageSource);
            var response = await client.ListAppPackagesAsync(request,
                                                             headers: JwtHelper.GetMetadataWithAccessToken());
            return response.AppPackages.Select(x => new Models.AppPackage(x));
        }
        public async Task<IEnumerable<Models.App>> SearchAppsAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client,
            int pageNum, int pageSize, string? name)
        {
            var request = new SearchAppsRequest
            {
                Paging = new PagingRequest
                {
                    PageNum = pageNum,
                    PageSize = pageSize
                }
            };
            if (string.IsNullOrEmpty(name) == false) request.Keywords = name;
            var response = await client.SearchAppsAsync(request,
                                                        headers: JwtHelper.GetMetadataWithAccessToken());
            return response.Apps.Select(x => new Models.App(x));
        }
        public async Task<Models.App> GetAppAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client, long internalId)
        {
            var request = new GetAppRequest
            {
                AppId = new InternalID { Id = internalId }
            };
            var response = await client.GetAppAsync(request,
                                                    headers: JwtHelper.GetMetadataWithAccessToken());
            return new Models.App(response.App);
        }
        public async Task UpdateAppAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client, Core.Models.App app)
        {
            var request = new UpdateAppRequest
            {
                App = app.ToProtoApp()
            };
            await client.UpdateAppAsync(request,
                                        headers: JwtHelper.GetMetadataWithAccessToken());
        }

        public async Task UpdateAppPackageAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client, Core.Models.AppPackage appPackage)
        {
            var request = new UpdateAppPackageRequest
            {
                AppPackage = appPackage.ToProtoAppPackage()
            };
            await client.UpdateAppPackageAsync(request,
                                               headers: JwtHelper.GetMetadataWithAccessToken());
        }
    }
}
