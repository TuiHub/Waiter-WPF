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

            InitializeComponent();
        }
    }
}