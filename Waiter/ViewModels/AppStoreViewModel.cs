using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TuiHub.Protos.Librarian.Sephirah.V1;
using Waiter.Helpers;
using Wpf.Ui.Common.Interfaces;

namespace Waiter.ViewModels
{
    public partial class AppStoreViewModel : ObservableObject, INavigationAware
    {
        [ObservableProperty]
        private string _searchText = string.Empty;
        [ObservableProperty]
        private IList<Core.Models.App> _apps = new List<Core.Models.App>();

        public void OnNavigatedTo()
        {
        }

        public void OnNavigatedFrom()
        {
        }

        [RelayCommand]
        private async void OnSearchApps()
        {
            try
            {
                Apps.Clear();
                await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                {
                    var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                    Apps = (await GlobalContext.LibrarianClientService.SearchAppsAsync(client, SearchText)).ToList();
                },
                async () => { });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught exception {ex.GetType()}, message:\n{ex.Message}", "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        [RelayCommand]
        private async void OnPurchaseApp(Core.Models.App app)
        {
            try
            {
                var dialogResult = MessageBox.Show($"Are you sure to purchase app ({app.InternalId}), " +
                                                   $"Name = {app.Name}",
                                                   "Confirm?",
                                                   MessageBoxButton.YesNoCancel,
                                                   MessageBoxImage.Question);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                    {
                        var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                        await GlobalContext.LibrarianClientService.PurchaseAppAsync(client, app.InternalId);
                    }, async () => { });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught exception {ex.GetType()}, message:\n{ex.Message}", "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
