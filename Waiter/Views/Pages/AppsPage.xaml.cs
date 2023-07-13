using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Windows.Documents;
using Wpf.Ui.Common.Interfaces;

namespace Waiter.Views.Pages
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class AppsPage : INavigableView<ViewModels.AppsViewModel>
    {
        public ViewModels.AppsViewModel ViewModel
        {
            get;
        }

        public AppsPage(ViewModels.AppsViewModel viewModel)
        {
            ViewModel = viewModel;

            //TestAppCategoriesWithApps.Add(new Models.AppCategoryWithApps
            //{
            //    AppCategory = null,
            //    Apps = new List<Core.Models.App>
            //    {
            //        new Core.Models.App { Name = "Test1" },
            //        new Core.Models.App { Name = "Test2" },
            //        new Core.Models.App { Name = "Test3" },
            //    }
            //});

            InitializeComponent();
        }

        private void TreeView_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue != null && e.NewValue is Core.Models.App)
            {
                ViewModel.SelectedApp = e.NewValue as Core.Models.App;
            }
        }

        //public List<Models.AppCategoryWithApps> TestAppCategoriesWithApps { get; } = new();
    }
}