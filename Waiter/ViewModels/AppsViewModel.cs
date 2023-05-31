using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TuiHub.ProcessTimeMonitorLibrary;
using TuiHub.Protos.Librarian.Sephirah.V1;
using TuiHub.Protos.Librarian.V1;
using TuiHub.SavedataManagerLibrary;
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
        private SavedataManager _savedataManager;
        public AppsViewModel(ProcessTimeMonitor processTimeMonitor, SavedataManager savedataManager)
        {
            _processTimeMonitor = processTimeMonitor;
            _savedataManager = savedataManager;
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
        [ObservableProperty]
        private IEnumerable<Core.Models.GameSave> _gameSaves = new List<Core.Models.GameSave>();
        [ObservableProperty]
        private Core.Models.GameSave? _selectedGameSave;
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

        async partial void OnSelectedAppPackageChanged(Core.Models.AppPackage? value)
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
            // TODO: add RunWithEnsureLoginAsync
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
                // create ZipArchive
                var tmpArchiveName = Guid.NewGuid().ToString() + ".zip";
                var tmpArchivePath = Path.Combine(GlobalContext.SystemConfig.GetRealCacheDirPath(), tmpArchiveName);
                using (var tmpArchiveFileStream = new FileStream(tmpArchivePath, FileMode.Create, FileAccess.ReadWrite))
                    await Task.Run(() => _savedataManager.Store(AppPackageSetting.AppBaseDir, tmpArchiveFileStream));
                var tmpArchiveFileInfo = new FileInfo(tmpArchivePath);
                var tmpArchiveSize = tmpArchiveFileInfo.Length;
                using SHA256 sha256 = SHA256.Create();
                using var tmpArchiveReadStream = File.OpenRead(tmpArchivePath);
                var tmpArchiveSha256 = await sha256.ComputeHashAsync(tmpArchiveReadStream);
                var tmpArchiveCreateTime = tmpArchiveFileInfo.CreationTime;
                MessageBox.Show($"Stored temp archive file as {tmpArchivePath}.\n" +
                                $"name = {tmpArchiveName}\n" +
                                $"size = {tmpArchiveSize}\n" +
                                $"sha256 = {BitConverter.ToString(tmpArchiveSha256).Replace("-", "")}\n" +
                                $"createTime = {tmpArchiveCreateTime:O}",
                                "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                // upload
                var uploadToken = await GlobalContext.LibrarianClientService.UploadGameSaveFile(client,
                                                                              AppPackageSetting.AppPackageId,
                                                                              new FileMetadata
                                                                              {
                                                                                  Name = tmpArchiveName,
                                                                                  SizeBytes = tmpArchiveSize,
                                                                                  Type = FileType.GeburaSave,
                                                                                  Sha256 = UnsafeByteOperations.UnsafeWrap(tmpArchiveSha256),
                                                                                  CreateTime = Timestamp.FromDateTime(tmpArchiveCreateTime.ToUniversalTime())
                                                                              });
                tmpArchiveReadStream.Position = 0;
                await GlobalContext.LibrarianClientService.SimpleUploadFile(client,
                                                                            uploadToken,
                                                                            tmpArchiveReadStream,
                                                                            GlobalContext.SystemConfig.FileTransferChunkBytes);
                MessageBox.Show($"Savedata file uploaded to server.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
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

        [RelayCommand]
        private async void OnRefreshGameSave()
        {
            if (SelectedAppPackage == null) return;
            try
            {
                await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                {
                    var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                    GameSaves = await GlobalContext.LibrarianClientService.GetAppPackageGameSaves(client, SelectedAppPackage.InternalId);
                },
                async () => { });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught exception {ex.GetType()}, message:\n{ex.Message}", "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        [RelayCommand]
        private void OnShowSelectedGameSave()
        {
            MessageBox.Show($"Selected GameSave = {SelectedGameSave?.ToString() ?? "null"}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        [RelayCommand]
        private async void OnDownloadAndRestoreGameSave()
        {
            if (SelectedGameSave == null) return;
            if (AppPackageSetting == null) return;
            try
            {
                string downloadToken = string.Empty;
                await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                {
                    var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                    downloadToken = await GlobalContext.LibrarianClientService.DownloadGameSaveFile(client, SelectedGameSave.InternalId);
                },
                async () => { });
                var cachedArchivePath = Path.Combine(GlobalContext.SystemConfig.CacheDirPath, SelectedGameSave.InternalId.ToString() + ".zip");
                if (File.Exists(cachedArchivePath))
                    File.Delete(cachedArchivePath);
                await using (var cachedArchiveWriteFileStream = File.OpenWrite(cachedArchivePath))
                    await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                    {
                        var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                        await GlobalContext.LibrarianClientService.SimpleDownloadFile(client, downloadToken, cachedArchiveWriteFileStream);
                    },
                    async () => { });
                MessageBox.Show($"Cached archive {cachedArchivePath} downloaded.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                var cachedArchiveFileInfo = new FileInfo(cachedArchivePath);
                var cachedArchiveSize = cachedArchiveFileInfo.Length;
                await using var cachedArchiveReadStream = File.OpenRead(cachedArchivePath);
                using SHA256 sha256 = SHA256.Create();
                var cachedArchiveSha256 = await sha256.ComputeHashAsync(cachedArchiveReadStream);
                MessageBox.Show($"Cached archive size = {cachedArchiveSize}\n" +
                                $"sha256 = {BitConverter.ToString(cachedArchiveSha256).Replace("-", "")}",
                                "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                cachedArchiveReadStream.Position = 0;
                MessageBox.Show($"Starting restore.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                await Task.Run(() => _savedataManager.Restore(cachedArchiveReadStream, AppPackageSetting.AppBaseDir));
                MessageBox.Show($"Restore complete.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
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
