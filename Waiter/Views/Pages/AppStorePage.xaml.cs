using Wpf.Ui.Common.Interfaces;

namespace Waiter.Views.Pages
{
    /// <summary>
    /// Interaction logic for AppStore.xaml
    /// </summary>
    public partial class AppStorePage : INavigableView<ViewModels.AppStoreViewModel>
    {
        public ViewModels.AppStoreViewModel ViewModel
        {
            get;
        }

        public AppStorePage(ViewModels.AppStoreViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }
    }
}