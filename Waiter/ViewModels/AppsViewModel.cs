using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using TuiHub.ProcessTimeMonitorLibrary;
using TuiHub.Protos.Librarian.Sephirah.V1;
using Waiter.Core.Models;
using Waiter.Core.Services;
using Waiter.Helpers;
using Waiter.Models.Db;
using Wpf.Ui.Common.Interfaces;

namespace Waiter.ViewModels
{
    public partial class AppsViewModel : ObservableObject, INavigationAware
    {
        private ProcessTimeMonitor _processTimeMonitor;
        public AppsViewModel(ProcessTimeMonitor processTimeMonitor)
        {
            _processTimeMonitor = processTimeMonitor;
        }
        [ObservableProperty]
        private IEnumerable<Core.Models.App> _apps = new List<Core.Models.App>();
        [ObservableProperty]
        private Core.Models.App? _selectedApp;
        [ObservableProperty]
        private IEnumerable<Core.Models.AppPackage> _appPackages = new List<Core.Models.AppPackage>();
        [ObservableProperty]
        private Core.Models.AppPackage? _selectedAppPackage;
        [ObservableProperty]
        private Models.AppPackageSetting? _appPackageSetting;
        [ObservableProperty]
        private TimeSpan _appPackageTotalRunTime;
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
            catch (Exception ex)
            {
                MessageBox.Show($"Caught exception {ex.GetType()}, message:\n{ex.Message}", "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            catch (Exception ex)
            {
                MessageBox.Show($"Caught exception {ex.GetType()}, message:\n{ex.Message}", "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        async partial void OnSelectedAppPackageChanged(AppPackage? value)
        {
            if (value == null) return;
            try
            {
                using var db = new ApplicationDbContext();
                var e = await db.AppPackageSettings.SingleOrDefaultAsync(x => x.AppPackageId == value.InternalId);
                AppPackageSetting = new Models.AppPackageSetting(value.InternalId, e);
                await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                {
                    var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                    AppPackageTotalRunTime = await GlobalContext.LibrarianClientService.GetAppPackageRunTime(client, value.InternalId);
                },
                async () => { });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught exception {ex.GetType()}, message:\n{ex.Message}", "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        [RelayCommand]
        private async void OnSaveAppPackageSetting()
        {
            if (AppPackageSetting == null) return;
            using var db = new ApplicationDbContext();
            var e = await db.AppPackageSettings.SingleOrDefaultAsync(x => x.AppPackageId == AppPackageSetting.AppPackageId);
            if (e == null)
            {
                db.AppPackageSettings.Add(new Models.Db.AppPackageSetting(AppPackageSetting));
            }
            else
            {
                Models.Db.AppPackageSetting.UpdateFromViewModelAppPackageSetting(ref e, AppPackageSetting);
            }
            await db.SaveChangesAsync();
            MessageBox.Show("Save complete.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        [RelayCommand]
        private void OnSelectAppPath()
        {
            if (AppPackageSetting == null) return;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var appPath = openFileDialog.FileName;
                AppPackageSetting.AppPath = appPath;
                AppPackageSetting.AppBaseDir = Path.GetDirectoryName(appPath);
                AppPackageSetting.AppWorkDir = Path.GetDirectoryName(appPath);
                AppPackageSetting.ProcMonPath = appPath;
                AppPackageSetting.ProcMonName = Path.GetFileNameWithoutExtension(Path.GetFileName(appPath));
            }
        }

        [RelayCommand]
        private async void OnRunApp()
        {
            if (AppPackageSetting == null) return;
            MessageBox.Show("Starting app.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            try
            {
                var nowDT = DateTime.Now;
                Process.Start(new ProcessStartInfo
                {
                    FileName = AppPackageSetting.AppPath,
                    WorkingDirectory = AppPackageSetting.AppWorkDir
                });
                (var startDT, var endDT, var exitCode) = await _processTimeMonitor.WaitForProcToExit(AppPackageSetting.ProcMonName, AppPackageSetting.ProcMonPath, nowDT);
                var runTime = endDT - startDT;
                MessageBox.Show($"App exited with exit code {exitCode}.\nRun {runTime.TotalSeconds:0.00} secs\nstartDT: {startDT:O}\nendDT: {endDT:O}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                // report RunTime to server
                var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                await GlobalContext.LibrarianClientService.AddAppPackageRunTime(client, AppPackageSetting.AppPackageId, startDT, runTime);
                MessageBox.Show($"RunTime info reported to server.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show($"App start timeout.\nException: {ex.Message}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught exception {ex.GetType()}, message:\n{ex.Message}", "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void OnNavigatedFrom()
        {
        }
    }
}
