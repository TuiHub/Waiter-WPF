using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
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
        private void OnSearchApps()
        {

        }
    }
}
