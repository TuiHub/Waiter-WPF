using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
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
            else
            {
                ViewModel.SelectedApp = null;
            }
        }

        private void AppAddToMenuItem_SubmenuOpened(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewModel.OnAppAddToSubMenuOpen();
        }
        private void AppAddToMenuItem_SubmenuClosed(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewModel.OnAppAddToSubMenuClose();
        }
        private void AppRemoveFromMenuItem_SubmenuOpened(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewModel.OnAppRemoveFromSubMenuOpen();
        }
        private void AppRemoveFromMenuItem_SubmenuClosed(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewModel.OnAppRemoveFromSubMenuClose();
        }

        // https://stackoverflow.com/questions/592373/select-treeview-node-on-right-click-before-displaying-contextmenu
        private void TreeView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);

            if (treeViewItem != null)
            {
                treeViewItem.Focus();
                e.Handled = true;
            }
        }
        static TreeViewItem VisualUpwardSearch(DependencyObject source)
        {
            while (source != null && !(source is TreeViewItem))
                source = VisualTreeHelper.GetParent(source);

            return source as TreeViewItem;
        }

        //public List<Models.AppCategoryWithApps> TestAppCategoriesWithApps { get; } = new();
    }
}