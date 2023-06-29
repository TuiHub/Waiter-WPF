using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using Wpf.Ui.Common.Interfaces;

namespace Waiter.ViewModels
{
    public partial class ProgressBarWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _stateText = "Working...";
        // progressBar => pb
        [ObservableProperty]
        private bool _pbIsIndeterminate = true;
        [ObservableProperty]
        private int _pbValue = 0;
        [ObservableProperty]
        private bool _buttonEnable = false;
    }
}
