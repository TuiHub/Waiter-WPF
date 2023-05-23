using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using TuiHub.Protos.Librarian.Sephirah.V1;
using Waiter.Core.Models;
using Waiter.Helpers;
using Waiter.Models.Db;
using Wpf.Ui.Common.Interfaces;

namespace Waiter.ViewModels
{
    public partial class AppsViewModel : ObservableObject, INavigationAware
    {
        [ObservableProperty]
        private IEnumerable<Core.Models.App> _apps = new List<Core.Models.App>();
        [ObservableProperty]
        private Core.Models.App? _selectedApp;
        [ObservableProperty]
        private IEnumerable<Core.Models.AppPackage> _appPackages = new List<Core.Models.AppPackage>();
        [ObservableProperty]
        private Core.Models.AppPackage? _selectedAppPackage;
        [ObservableProperty]
        private Models.Db.AppPackageSetting? _appPackageSetting;
        public async void OnNavigatedTo()
        {
            try
            {
                await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                {
                    var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                    Apps = await GlobalContext.LibrarianClientService.GetPurchasedAppsAsync(client);
                },
                async () => { });
            }
            catch (Exception e)
            {
                MessageBox.Show($"Caught exception {e.GetType()}, message:\n{e.Message}", "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        async partial void OnSelectedAppChanged(Core.Models.App? value)
        {
            if (value == null) return;
            try
            {
                await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                {
                    var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                    AppPackages = await GlobalContext.LibrarianClientService.GetAppPackagesAsync(client, value.InternalId);
                },
                async () => { });
            }
            catch (Exception e)
            {
                MessageBox.Show($"Caught exception {e.GetType()}, message:\n{e.Message}", "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        async partial void OnSelectedAppPackageChanged(AppPackage? value)
        {
            if (value == null) return;
            using var db = new ApplicationDbContext();
            var e = await db.AppPackageSettings.SingleOrDefaultAsync(x => x.AppPackageId == value.InternalId);
            e ??= new AppPackageSetting();
            AppPackageSetting = e;
        }

        [RelayCommand]
        private async void OnSaveAppPackageSetting()
        {
            if (AppPackageSetting == null) return;
            using var db = new ApplicationDbContext();
            var e = await db.AppPackageSettings.SingleOrDefaultAsync(x => x.AppPackageId == AppPackageSetting.AppPackageId);
            if (e == null)
            {
                db.AppPackageSettings.Add(AppPackageSetting);
            }
            else
            {
                e = AppPackageSetting;
            }
            await db.SaveChangesAsync();
        }

        public void OnNavigatedFrom()
        {
        }
    }
}
