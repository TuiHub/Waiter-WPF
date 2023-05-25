using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter.Models
{
    public partial class AppPackageSetting : ObservableObject
    {
        [ObservableProperty]
        private long _appPackageId;
        [ObservableProperty]
        private string _appPath = string.Empty;
        [ObservableProperty]
        private string _appBaseDir = string.Empty;
        [ObservableProperty]
        private string _appWorkDir = string.Empty;
        [ObservableProperty]
        private string _procMonName = string.Empty;
        [ObservableProperty]
        private string _procMonPath = string.Empty;
        public AppPackageSetting(long appPackageId, Db.AppPackageSetting? appPackageSetting)
        {
            AppPackageId = appPackageId;
            if (appPackageSetting != null)
            {
                AppPath = appPackageSetting.AppPath;
                AppBaseDir = appPackageSetting.AppBaseDir;
                AppWorkDir = appPackageSetting.AppWorkDir;
                ProcMonName = appPackageSetting.ProcMonName;
                ProcMonPath = appPackageSetting.ProcMonPath;
            }
        }
        public AppPackageSetting() { }
    }
}
