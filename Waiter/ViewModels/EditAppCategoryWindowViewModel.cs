using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using TuiHub.Protos.Librarian.Sephirah.V1;
using Waiter.Helpers;
using Waiter.Views.Windows;
using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Controls;
using static Waiter.GlobalContext;

namespace Waiter.ViewModels
{
    public partial class EditAppCategoryWindowViewModel : ObservableObject
    {
        public EditAppCategoryWindow? ParentWindow { get; set; }

        [ObservableProperty]
        private Core.Models.AppCategory? _appCategory;
        [ObservableProperty]
        private string _appCategoryName = "";

        public EditAppCategoryWindowViewModel() { }
        public EditAppCategoryWindowViewModel(Core.Models.AppCategory? appCategory = null, EditAppCategoryWindow? window = null)
        {
            ParentWindow = window;
            AppCategory = appCategory;

            AppCategoryName = AppCategory?.Name ?? "";
        }

        public string TitleStr
        {
            get => AppCategory == null ? "Add AppCategory" : $"Edit AppCategory ({AppCategory.InternalId.ToString()})";
        }
        public string ButtonStr
        {
            get => AppCategory == null ? "Add" : "Edit";
        }

        [RelayCommand]
        private void OnBtnClick()
        {

        }
    }
}
