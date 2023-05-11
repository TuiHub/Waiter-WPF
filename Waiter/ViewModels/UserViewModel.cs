using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using Waiter.Controls;
using Waiter.Views.Windows;
using Wpf.Ui.Common.Interfaces;

namespace Waiter.ViewModels
{
    public partial class UserViewModel : ObservableObject, INavigationAware
    {
        [ObservableProperty]
        private long? _userInternalId;
        [ObservableProperty]
        private string _serverURL = string.Empty;
        [ObservableProperty]
        private string _dialogResultText = string.Empty;

        public void OnNavigatedTo()
        {
            if (string.IsNullOrEmpty(ServerURL))
                ServerURL = GlobalContext.SystemConfig.ServerURL;
        }

        public void OnNavigatedFrom()
        {
        }

        [RelayCommand]
        private void OnShowLoginDialog()
        {
            var loginWindow = new LoginWindow(new LoginWindowViewModel());
            loginWindow.Owner = App.Current.MainWindow;
            loginWindow.ShowDialog();
        }
    }
}
