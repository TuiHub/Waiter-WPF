using CommunityToolkit.Mvvm.ComponentModel;
using System.IO;

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
        // relative to app assembly dir
        public string CacheDirPath { get; set; } = string.Empty;
        public int FileTransferChunkBytes { get; set; } = 32768;
        public string GetRealDataDirPath()
        {
            return Path.Combine(GlobalContext.AssemblyDir, DataDirPath);
        }
        public string GetRealSqliteDbPath()
        {
            return Path.Combine(GlobalContext.AssemblyDir, DataDirPath, SqliteDbPath);
        }
        public string GetRealCacheDirPath()
        {
            return Path.Combine(GlobalContext.AssemblyDir, CacheDirPath);
        }
    }
}
