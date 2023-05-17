using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using TuiHub.Protos.Librarian.Sephirah.V1;
using Waiter.Core.Models;
using Waiter.Helpers;
using Wpf.Ui.Common.Interfaces;

namespace Waiter.ViewModels
{
    public partial class AppsViewModel : ObservableObject, INavigationAware
    {
        [ObservableProperty]
        private int _counter = 0;
        [ObservableProperty]
        private IEnumerable<Core.Models.App> _apps = new List<Core.Models.App>();
        [ObservableProperty]
        private Core.Models.App? _selected;

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

        public void OnNavigatedFrom()
        {
        }

        [RelayCommand]
        private void OnCounterIncrement()
        {
            Counter++;
        }
    }
}
