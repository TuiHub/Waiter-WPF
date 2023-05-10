using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Common.Interfaces;

namespace Waiter.ViewModels
{
    public partial class UserViewModel : ObservableObject, INavigationAware
    {
        [ObservableProperty]
        private int _counter = 0;
        [ObservableProperty]
        private string _serverURL = string.Empty;

        public void OnNavigatedTo()
        {
            if (string.IsNullOrEmpty(ServerURL))
                ServerURL = GlobalContext.SystemConfig.ServerURL;
        }

        public void OnNavigatedFrom()
        {
        }
    }
}
