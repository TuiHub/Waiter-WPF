using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using Waiter.Controls;
using Wpf.Ui.Common.Interfaces;

namespace Waiter.ViewModels
{
    public partial class LoginWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _username = string.Empty;
        [ObservableProperty]
        private string _password = string.Empty;

        [RelayCommand]
        private async Task OnBtnLoginClick()
        {
            
        }
    }
}
