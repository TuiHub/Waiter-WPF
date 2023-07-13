using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter.Models
{
    public partial class AppCategoryWithApps : ObservableObject
    {
        [ObservableProperty]
        private Core.Models.AppCategory? _appCategory;
        [ObservableProperty]
        public List<Core.Models.App> _apps = new();
        public string AppCategoryName
        {
            get
            {
                return AppCategory?.Name ?? "null";
            }
        }
    }
}
