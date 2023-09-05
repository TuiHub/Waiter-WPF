using Wpf.Ui.Common.Interfaces;

namespace Waiter.Views.Pages
{
    /// <summary>
    /// Interaction logic for AppCategoryPage.xaml
    /// </summary>
    public partial class AppCategoryPage : INavigableView<ViewModels.AppCategoryViewModel>
    {
        public ViewModels.AppCategoryViewModel ViewModel
        {
            get;
        }

        public AppCategoryPage(ViewModels.AppCategoryViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }
    }
}