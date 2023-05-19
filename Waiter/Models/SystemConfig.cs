using CommunityToolkit.Mvvm.ComponentModel;

namespace Waiter.Models
{
    public partial class SystemConfig : ObservableObject
    {
        [ObservableProperty]
        private string _serverURL = string.Empty;
        // relative to app assembly dir
        public string DataDirPath { get; set; } = string.Empty;
        // relative to DataDirPath
        public string SqliteDbPath { get; set; } = string.Empty;
    }
}
