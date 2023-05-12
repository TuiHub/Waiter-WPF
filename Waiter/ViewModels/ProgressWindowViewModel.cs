using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using Wpf.Ui.Common.Interfaces;

namespace Waiter.ViewModels
{
    public partial class ProgressWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _workText = "Working...";
    }
}
