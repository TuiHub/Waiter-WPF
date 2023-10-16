using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
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

        public async Task<Models.App> GetAppAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client, long appId)
        {
            var getAppReq = new GetAppRequest
            {
                AppId= new InternalID { Id = appId }
            };
            var resp = await client.GetAppAsync(getAppReq,
                                                headers: JwtHelper.GetMetadataWithAccessToken());
            return new Models.App(resp.App);
        }

        // TODO: change Paging
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
                    StartTime = Timestamp.FromDateTime(startDT.ToUniversalTime()),
                    Duration = Duration.FromTimeSpan(duration)
                }
            };
            await client.AddAppPackageRunTimeAsync(addAppPackageRunTimeReq,
                                                   headers: JwtHelper.GetMetadataWithAccessToken());
        }

        public async Task<TimeSpan> GetAppPackageRunTime(LibrarianSephirahService.LibrarianSephirahServiceClient client, long appPackageId)
        {
            var getAppPackageRunTimeReq = new GetAppPackageRunTimeRequest
            {
                AppPackageId = new InternalID { Id= appPackageId }
            };
            var resp = await client.GetAppPackageRunTimeAsync(getAppPackageRunTimeReq,
                                                              headers: JwtHelper.GetMetadataWithAccessToken());
            return resp.Duration.ToTimeSpan();
        }

        public async Task<string> UploadGameSaveFile(LibrarianSephirahService.LibrarianSephirahServiceClient client, long appPackageId, FileMetadata fileMetadata)
        {
            var uploadGameSaveFileRequest = new UploadGameSaveFileRequest
            {
                AppPackageId= new InternalID { Id= appPackageId },
                FileMetadata = fileMetadata
            };
            var resp = await client.UploadGameSaveFileAsync(uploadGameSaveFileRequest,
                                                            headers: JwtHelper.GetMetadataWithAccessToken());
            return resp.UploadToken;
        }
        public async Task<string> DownloadGameSaveFile(LibrarianSephirahService.LibrarianSephirahServiceClient client, long fileMetadataId)
        {
            var downloadGameSaveFileRequest = new DownloadGameSaveFileRequest { Id = new InternalID { Id = fileMetadataId } };
            var resp = await client.DownloadGameSaveFileAsync(downloadGameSaveFileRequest,
                                                              headers: JwtHelper.GetMetadataWithAccessToken());
            return resp.DownloadToken;
        }

        // TODO: change Paging
        public async Task<IEnumerable<GameSave>> GetAppPackageGameSaves(LibrarianSephirahService.LibrarianSephirahServiceClient client, long appPackageId)
        {
            var listGameSaveFilesRequest = new ListGameSaveFilesRequest
            {
                Paging = new TuiHub.Protos.Librarian.V1.PagingRequest
                {
                    PageNum = 1,
                    PageSize = 1000
                },
                AppPackageId = new InternalID { Id = appPackageId }
            };
            var resp = await client.ListGameSaveFilesAsync(listGameSaveFilesRequest,
                                                           headers: JwtHelper.GetMetadataWithAccessToken());
            return resp.Results.Select(x => new GameSave(x));
        }

        public async Task RemoveGameSaveFileAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client, long gameSaveFileId)
        {
            var removeGameSaveFileRequest = new RemoveGameSaveFileRequest
            {
                Id = new InternalID { Id = gameSaveFileId }
            };
            await client.RemoveGameSaveFileAsync(removeGameSaveFileRequest,
                                                 headers: JwtHelper.GetMetadataWithAccessToken());
        }

        public async Task<IEnumerable<Models.AppCategory>> ListAppCategoriesAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client)
        {
            var ListAppCategoriesRequest = new ListAppCategoriesRequest();
            var resp = await client.ListAppCategoriesAsync(ListAppCategoriesRequest,
                                                           headers: JwtHelper.GetMetadataWithAccessToken());
            return resp.AppCategories.Select(x => new Models.AppCategory(x));
        }

        public async Task UpdateAppAppCategoriesAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client, long appId, IEnumerable<long> appCategoryIds)
        {
            var req = new UpdateAppAppCategoriesRequest
            {
                AppId = new InternalID { Id = appId }
            };
            req.AppCategoryIds.AddRange(appCategoryIds.Select(x => new InternalID { Id = x }));
            await client.UpdateAppAppCategoriesAsync(req,
                                                     headers: JwtHelper.GetMetadataWithAccessToken());
        }

        // TODO: change Paging
        public async Task<IEnumerable<Models.App>> SearchAppsAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client, string keyword)
        {
            var req = new SearchAppsRequest
            {
                Paging = new TuiHub.Protos.Librarian.V1.PagingRequest
                {
                    PageNum = 1,
                    PageSize = 1000
                },
                Keywords = keyword
            };
            var resp = await client.SearchAppsAsync(req,
                                                    headers: JwtHelper.GetMetadataWithAccessToken());
            return resp.Apps.Select(x => new Models.App(x));
        }

        public async Task CreateAppCategoryAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client, Models.AppCategory appCategory)
        {
            var req = new CreateAppCategoryRequest
            {
                AppCategory = new TuiHub.Protos.Librarian.V1.AppCategory
                {
                    Name = appCategory.Name
                }
            };
            await client.CreateAppCategoryAsync(req,
                                                headers: JwtHelper.GetMetadataWithAccessToken());
        }

        public async Task UpdateAppCategoryAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client, Models.AppCategory appCategory)
        {
            var req = new UpdateAppCategoryRequest
            {
                AppCategory = new TuiHub.Protos.Librarian.V1.AppCategory
                {
                    Id = new InternalID { Id = appCategory.InternalId },
                    Name = appCategory.Name
                }
            };
            await client.UpdateAppCategoryAsync(req,
                                                headers: JwtHelper.GetMetadataWithAccessToken());
        }

        public async Task RemoveAppCategoryAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client, long appCategoryId)
        {
            var req = new RemoveAppCategoryRequest
            {
                Id = new InternalID { Id = appCategoryId }
            };
            await client.RemoveAppCategoryAsync(req,
                                                headers: JwtHelper.GetMetadataWithAccessToken());
        }

        public async Task PurchaseAppAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client, long appId)
        {
            var req = new PurchaseAppRequest
            {
                AppId = new InternalID { Id = appId }
            };
            await client.PurchaseAppAsync(req,
                                          headers: JwtHelper.GetMetadataWithAccessToken());
        }
    }
}
