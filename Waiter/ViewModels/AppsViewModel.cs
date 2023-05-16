using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections;
using System.Collections.Generic;
using TuiHub.Protos.Librarian.Sephirah.V1;
using Waiter.Core.Models;
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
            var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
            Apps = await GlobalContext.LibrarianClientService.GetPurchasedAppsRequestAsync(client);
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
