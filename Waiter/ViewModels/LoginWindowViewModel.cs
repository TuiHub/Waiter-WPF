using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Windows;
using Waiter.Views.Windows;
using Wpf.Ui.Common.Interfaces;

namespace Waiter.ViewModels
{
    public partial class LoginWindowViewModel : ObservableObject
    {
        public LoginWindowViewModel() { }
        public LoginWindowViewModel(Window? window)
        {
            Parent = window;
        }

        public Window? Parent { get; set; }

        [ObservableProperty]
        private string _username = string.Empty;
        [ObservableProperty]
        private string _password = string.Empty;

        [RelayCommand]
        private void OnBtnLoginClick(object sender)
        {
            var progressDialog = new ProgressWindow();
            progressDialog.ViewModel.WorkText = "testtesttesttesttesttesttesttesttesttest";
            progressDialog.Owner = Parent;
            progressDialog.ShowDialog();
        }
    }
}
