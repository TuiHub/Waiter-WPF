using CommunityToolkit.Mvvm.ComponentModel;

namespace Waiter.Models
{
    public partial class SystemConfig : ObservableObject
    {
        [ObservableProperty]
        private string _serverURL = string.Empty;
    }
}
