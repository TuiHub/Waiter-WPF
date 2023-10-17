using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
using Waiter.Views.Windows;
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
        private IEnumerable<Core.Models.App> _apps;
        private IEnumerable<Core.Models.AppCategory> _appCategories;
        [ObservableProperty]
        private List<Models.AppCategoryWithApps> _appCategoriesWithApps = new();
        [ObservableProperty]
        private Core.Models.App? _selectedApp;
        [ObservableProperty]
        private Core.Models.AppDetails? _selectedAppDetails;
        [ObservableProperty]
        private IList<Core.Models.AppPackage> _appPackages = new List<Core.Models.AppPackage>();
        [ObservableProperty]
        private Core.Models.AppPackage? _selectedAppPackage;
        [ObservableProperty]
        private Models.AppPackageSetting? _appPackageSetting;
        [ObservableProperty]
        private TimeSpan _appPackageTotalRunTime;
        [ObservableProperty]
        private IList<Core.Models.GameSave> _gameSaves = new List<Core.Models.GameSave>();
        [ObservableProperty]
        private Core.Models.GameSave? _selectedGameSave;
        [ObservableProperty]
        private ObservableCollection<Core.Models.AppCategory> _selectedAppNonExistingAppCategories = new() { new Core.Models.AppCategory { Name = "null" } };
        [ObservableProperty]
        private ObservableCollection<Core.Models.AppCategory> _selectedAppExistingAppCategories = new() { new Core.Models.AppCategory { Name = "null" } };
        //[ObservableProperty]
        //private bool _btnStartAppEnabled = false;
        public async void OnNavigatedTo()
        {
            try
            {
                await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                {
                    var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                    _apps = await GlobalContext.LibrarianClientService.GetPurchasedAppsAsync(client);
                    _appCategories = await GlobalContext.LibrarianClientService.ListAppCategoriesAsync(client);
                },
                async () => { });
                // https://blog.lindexi.com/post/WPF-%E5%A4%9A%E7%BA%BF%E7%A8%8B%E4%B8%8B%E8%B7%A8%E7%BA%BF%E7%A8%8B%E5%A4%84%E7%90%86-ObservableCollection-%E6%95%B0%E6%8D%AE.html
                await Task.Run(() =>
                {
                    var rlist = new List<Models.AppCategoryWithApps>();
                    var groups = _apps.SelectMany(a => a.AppCategoryIds,
                                                  (a, c) => new
                                                  {
                                                      AppCategoryId = c,
                                                      App = a
                                                  })
                                      .GroupBy(x => x.AppCategoryId, x => x.App);
                    _appCategories.ToList().ForEach(x => rlist.Add(new Models.AppCategoryWithApps { AppCategory = x }));
                    foreach (var group in groups)
                    {
                        var appCategoryWithApps = rlist.Single(x => x.AppCategory?.InternalId == group.Key);
                        appCategoryWithApps.Apps.AddRange(group);
                    }
                    rlist.Add(new Models.AppCategoryWithApps { AppCategory = null });
                    _apps.Where(x => x.AppCategoryIds.Any() == false)
                         .ToList()
                         .ForEach(x => rlist.Last().Apps.Add(x));
                    AppCategoriesWithApps = rlist;
                });
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
                AppPackages.Clear();
                SelectedAppDetails = null;
                SelectedAppPackage = null;
                AppPackageSetting = null;
                AppPackageTotalRunTime = TimeSpan.Zero;
                GameSaves.Clear();
                SelectedGameSave = null;
                await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                {
                    var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                    // Get SelectedApp info
                    SelectedAppDetails = (await GlobalContext.LibrarianClientService.GetAppAsync(client, value.InternalId)).AppDetails;
                    AppPackages = (await GlobalContext.LibrarianClientService.GetAppPackagesAsync(client, value.InternalId)).ToList();
                    // default select if there is only one AppPackage
                    // TODO: this is a hack, should be removed
                    if (AppPackages.Count() == 1)
                    {
                        var _ = App.Current.Dispatcher.Invoke(async () =>
                        {
                            await Task.Delay(250);
                            SelectedAppPackage = AppPackages.First();
                        });
                    }
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
                    AppPackageTotalRunTime = await GlobalContext.LibrarianClientService.GetAppPackageRunTimesAsync(client, value.InternalId);
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
        private async void OnStartApp()
        {
            if (AppPackageSetting == null) return;
            // create progressBarDialog
            var progressBarDialog = new ProgressBarWindow();
            progressBarDialog.Owner = App.Current.MainWindow;
            try
            {
                progressBarDialog.Title = $"Starting App";
                progressBarDialog.Show();
                var nowDT = DateTime.Now;
                progressBarDialog.ViewModel.StateText = $"Starting {AppPackageSetting.AppPath}...";
                var process = Process.Start(new ProcessStartInfo
                {
                    FileName = AppPackageSetting.AppPath,
                    WorkingDirectory = AppPackageSetting.AppWorkDir
                });
                if (process == null)
                    throw new Exception($"Failed to start {AppPackageSetting.AppPath}.");
                progressBarDialog.Hide();
                DateTime startDT, endDT;
                int exitCode;
                if (bool.Parse(AppPackageSetting.UseProcListenMode) == false)
                    (startDT, endDT, exitCode) = await _processTimeMonitor.WaitForProcToExit(process);
                else
                    (startDT, endDT, exitCode) = await _processTimeMonitor.WaitForProcToExit(AppPackageSetting.ProcMonName, AppPackageSetting.ProcMonPath, nowDT);
                var runTime = endDT - startDT;
                //MessageBox.Show($"App exited with exit code {exitCode}.\nRun {runTime.TotalSeconds:0.00} secs\nstartDT: {startDT:O}\nendDT: {endDT:O}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                // report RunTime to server
                progressBarDialog.Title = $"Post Process";
                progressBarDialog.ViewModel.StateText = $"Reporting runtime...";
                progressBarDialog.Show();
                await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                {
                    var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                    await GlobalContext.LibrarianClientService.AddAppPackageRunTimeAsync(client, AppPackageSetting.AppPackageId, startDT, runTime);
                    //MessageBox.Show($"RunTime info reported to server.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    await CreateZipArchive(progressBarDialog, true, client);
                    progressBarDialog.Title = $"Finalizing";
                    progressBarDialog.ViewModel.StateText = $"Finalizing...";
                    progressBarDialog.ViewModel.PbIsIndeterminate = true;
                    //MessageBox.Show($"Savedata file uploaded to server.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }, async () => { }, false);
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show($"App start timeout.\nException: {ex.Message}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught exception {ex.GetType()}, message:\n{ex.Message}", "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                progressBarDialog.Close();
            }
        }
        [RelayCommand]
        private async void OnManualCreateGameSave()
        {
            var progressRingDialog = new ProgressRingWindow();
            progressRingDialog.Owner = App.Current.MainWindow;
            progressRingDialog.ViewModel.WorkText = "Loading...";
            App.Current.MainWindow.IsEnabled = false;
            progressRingDialog.Show();

            try
            {
                await CreateZipArchive();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught exception {ex.GetType()}, message:\n{ex.Message}", "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            progressRingDialog.Close();
            App.Current.MainWindow.IsEnabled = true;
        }
        private async Task CreateZipArchive(ProgressBarWindow? progressBarDialog = null, bool upload = false, LibrarianSephirahService.LibrarianSephirahServiceClient? client = null)
        {
            // create ZipArchive
            if (progressBarDialog != null) progressBarDialog.ViewModel.StateText = $"Creating game save file...";
            var tmpArchiveName = Guid.NewGuid().ToString() + ".zip";
            var tmpArchivePath = Path.Combine(GlobalContext.SystemConfig.GetRealCacheDirPath(), tmpArchiveName);
            using (var tmpArchiveFileStream = new FileStream(tmpArchivePath, FileMode.Create, FileAccess.ReadWrite))
                await Task.Run(() => _savedataManager.Store(AppPackageSetting!.AppBaseDir, tmpArchiveFileStream));
            var tmpArchiveFileInfo = new FileInfo(tmpArchivePath);
            var tmpArchiveSizeBytes = tmpArchiveFileInfo.Length;
            if (progressBarDialog != null) progressBarDialog.ViewModel.StateText = $"Calculating SHA256 diagram...";
            using SHA256 sha256 = SHA256.Create();
            using var tmpArchiveReadStream = File.OpenRead(tmpArchivePath);
            var tmpArchiveSha256 = await sha256.ComputeHashAsync(tmpArchiveReadStream);
            var tmpArchiveCreateTime = tmpArchiveFileInfo.CreationTime;
            if (upload == true)
            {
                // show MessageBox
                var dialogResult = MessageBox.Show($"Are you sure to upload?",
                                                   "Confirm?",
                                                   MessageBoxButton.YesNoCancel,
                                                   MessageBoxImage.Question);
                // upload
                if (dialogResult != MessageBoxResult.Yes)
                    upload = false;
            }
            if (upload == false)
            {
                MessageBox.Show($"Stored temp archive file as {tmpArchivePath}.\n" +
                                $"name = {tmpArchiveName}\n" +
                                $"size = {tmpArchiveSizeBytes}\n" +
                                $"sha256 = {BitConverter.ToString(tmpArchiveSha256).Replace("-", "")}\n" +
                                $"createTime = {tmpArchiveCreateTime:O}",
                                "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                progressBarDialog!.ViewModel.StateText = $"Uploading game save file({SizeBytesToHRStringHelper.SizeBytesToHRString(tmpArchiveSizeBytes)})...";
                var uploadToken = await GlobalContext.LibrarianClientService.UploadGameSaveFileAsync(client!,
                                                                              AppPackageSetting!.AppPackageId,
                                                                              new FileMetadata
                                                                              {
                                                                                  Name = tmpArchiveName,
                                                                                  SizeBytes = tmpArchiveSizeBytes,
                                                                                  Type = FileType.GeburaSave,
                                                                                  Sha256 = UnsafeByteOperations.UnsafeWrap(tmpArchiveSha256),
                                                                                  CreateTime = Timestamp.FromDateTime(tmpArchiveCreateTime.ToUniversalTime())
                                                                              });
                tmpArchiveReadStream.Position = 0;
                progressBarDialog!.ViewModel.PbIsIndeterminate = false;
                await GlobalContext.LibrarianClientService.SimpleUploadFile(client!,
                                                                            uploadToken,
                                                                            tmpArchiveReadStream,
                                                                            GlobalContext.SystemConfig.FileTransferChunkBytes,
                                                                            tmpArchiveSizeBytes,
                                                                            new Progress<int>(p => progressBarDialog!.ViewModel.PbValue = p));
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
                    GameSaves = (await GlobalContext.LibrarianClientService.GetAppPackageGameSavesAsync(client, SelectedAppPackage.InternalId)).ToList();
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
            // create progressBarDialog
            var progressBarDialog = new ProgressBarWindow();
            progressBarDialog.Owner = App.Current.MainWindow;
            try
            {
                progressBarDialog.Title = $"Restoring GameSave";
                progressBarDialog.Show();
                progressBarDialog.ViewModel.StateText = "Getting download token...";
                string downloadToken = string.Empty;
                await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                {
                    var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                    downloadToken = await GlobalContext.LibrarianClientService.DownloadGameSaveFileAsync(client, SelectedGameSave.InternalId);
                },
                async () => { }, false);
                progressBarDialog.ViewModel.StateText = "Gererating temp file name...";
                var cachedArchivePath = Path.Combine(GlobalContext.SystemConfig.CacheDirPath, SelectedGameSave.InternalId.ToString() + ".zip");
                if (File.Exists(cachedArchivePath))
                    File.Delete(cachedArchivePath);
                progressBarDialog.ViewModel.StateText = "Downloading game save file...";
                progressBarDialog.ViewModel.PbIsIndeterminate = false;
                await using (var cachedArchiveWriteFileStream = File.OpenWrite(cachedArchivePath))
                    await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                    {
                        var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                        await GlobalContext.LibrarianClientService.SimpleDownloadFile(client, downloadToken, cachedArchiveWriteFileStream,
                            SelectedGameSave.SizeBytes, new Progress<int>(p => progressBarDialog.ViewModel.PbValue = p));
                    },
                    async () => { }, false);
                //MessageBox.Show($"Cached archive {cachedArchivePath} downloaded.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                progressBarDialog.ViewModel.PbIsIndeterminate = true;
                progressBarDialog.ViewModel.StateText = "Calculating sha256...";
                var cachedArchiveFileInfo = new FileInfo(cachedArchivePath);
                var cachedArchiveSize = cachedArchiveFileInfo.Length;
                await using var cachedArchiveReadStream = File.OpenRead(cachedArchivePath);
                using SHA256 sha256 = SHA256.Create();
                var cachedArchiveSha256 = await sha256.ComputeHashAsync(cachedArchiveReadStream);
                //MessageBox.Show($"Cached archive size = {cachedArchiveSize}\n" +
                //                $"sha256 = {BitConverter.ToString(cachedArchiveSha256).Replace("-", "")}",
                //                "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                cachedArchiveReadStream.Position = 0;
                //MessageBox.Show($"Starting restore.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                progressBarDialog.ViewModel.StateText = "Restoring game save...";
                await Task.Run(() => _savedataManager.Restore(cachedArchiveReadStream, AppPackageSetting.AppBaseDir));
                progressBarDialog.ViewModel.StateText = "Finalizing...";
                MessageBox.Show($"Restore complete.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught exception {ex.GetType()}, message:\n{ex.Message}", "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                progressBarDialog.Close();
            }
        }
        [RelayCommand]
        private async void OnDeleteGameSave()
        {
            try
            {
                if (SelectedGameSave == null) return;
                var dialogResult = MessageBox.Show($"Are you sure to delete GameSave {SelectedGameSave.InternalId}?",
                                                   "Confirm?",
                                                   MessageBoxButton.YesNoCancel,
                                                   MessageBoxImage.Question);
                if (dialogResult != MessageBoxResult.Yes) return;
                await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                {
                    var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                    await GlobalContext.LibrarianClientService.RemoveGameSaveFileAsync(client, SelectedGameSave.InternalId);
                },
                async () => { });
                MessageBox.Show($"GameSave {SelectedGameSave.InternalId} deleted.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                OnRefreshGameSave();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught exception {ex.GetType()}, message:\n{ex.Message}", "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void OnNavigatedFrom()
        {
        }

        [RelayCommand]
        private void OnShowSelectedApp()
        {
            string appInfoStr;
            if (SelectedApp == null)
                appInfoStr = "null";
            else
                appInfoStr = $"InternalId = {SelectedApp.InternalId}, " +
                             $"Name = {SelectedApp.Name}";
            MessageBox.Show($"Selected GameSave = {appInfoStr}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        [RelayCommand]
        private async void OnAppAddToSubMenuClick(Core.Models.AppCategory? appCategory)
        {
            if (SelectedApp != null && appCategory != null)
            {
                try
                {
                    var appCategoryIds = new List<long>(SelectedApp.AppCategoryIds)
                    {
                        appCategory.InternalId
                    };
                    await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                    {
                        var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                        await GlobalContext.LibrarianClientService.UpdateAppAppCategoriesAsync(client, SelectedApp.InternalId, appCategoryIds);
                    },
                    async () => { });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Caught exception {ex.GetType()}, message:\n{ex.Message}", "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        [RelayCommand]
        private async void OnAppRemoveFromSubMenuClick(Core.Models.AppCategory? appCategory)
        {
            if (SelectedApp != null && appCategory != null)
            {
                try
                {
                    var appCategoryIds = new List<long>(SelectedApp.AppCategoryIds);
                    appCategoryIds.Remove(appCategory.InternalId);
                    await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                    {
                        var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                        await GlobalContext.LibrarianClientService.UpdateAppAppCategoriesAsync(client, SelectedApp.InternalId, appCategoryIds);
                    },
                    async () => { });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Caught exception {ex.GetType()}, message:\n{ex.Message}", "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }


        public void OnAppAddToSubMenuOpen()
        {
            if (SelectedApp == null) return;
            SelectedAppNonExistingAppCategories.Clear();
            //foreach (var appCategory in _appCategories)
            //{
            //    if (SelectedApp.AppCategoryIds.Contains(appCategory.InternalId) == false)
            //        SelectedAppNonExistingAppCategories.Add(appCategory);
            //}
            _appCategories.Where(x => SelectedApp.AppCategoryIds.Contains(x.InternalId) == false)
                          .ToList()
                          .ForEach(x => SelectedAppNonExistingAppCategories.Add(x));
            if (SelectedAppNonExistingAppCategories.Any() == false)
                SelectedAppNonExistingAppCategories.Add(new Core.Models.AppCategory { Name = "null" });
        }
        public void OnAppAddToSubMenuClose()
        {
            if (SelectedApp == null) return;
            SelectedAppNonExistingAppCategories.Clear();
            SelectedAppNonExistingAppCategories.Add(new Core.Models.AppCategory { Name = "Loading..." });
        }
        public void OnAppRemoveFromSubMenuOpen()
        {
            if (SelectedApp == null) return;
            SelectedAppExistingAppCategories.Clear();
            SelectedApp.AppCategoryIds.Select(x => _appCategories.Single(c => c.InternalId == x))
                                      .ToList()
                                      .ForEach(x => SelectedAppExistingAppCategories.Add(x));
            if (SelectedAppExistingAppCategories.Any() == false)
                SelectedAppExistingAppCategories.Add(new Core.Models.AppCategory { Name = "null" });
        }
        public void OnAppRemoveFromSubMenuClose()
        {
            if (SelectedApp == null) return;
            SelectedAppExistingAppCategories.Clear();
            SelectedAppExistingAppCategories.Add(new Core.Models.AppCategory { Name = "Loading..." });
        }
    }
}
