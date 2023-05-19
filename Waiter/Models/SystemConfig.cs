using CommunityToolkit.Mvvm.ComponentModel;

namespace Waiter.Models
{
    public partial class SystemConfig : ObservableObject
    {
        [ObservableProperty]
        private string _serverURL = string.Empty;
        // relative to Working Dir
        public string DataDirPath { get; set; } = string.Empty;
        // relative to DataDirPath
        public string SqliteDbPath { get; set; } = string.Empty;
    }
}
