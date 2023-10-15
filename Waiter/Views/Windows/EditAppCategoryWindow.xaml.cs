using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf.Ui.Controls;

namespace Waiter.Views.Windows
{
    /// <summary>
    /// EditAppCategoryWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EditAppCategoryWindow : UiWindow
    {
        public ViewModels.EditAppCategoryWindowViewModel ViewModel { get; }
        public EditAppCategoryWindow(Core.Models.AppCategory? appCategory)
        {
            ViewModel = new ViewModels.EditAppCategoryWindowViewModel(appCategory, this);

            this.DataContext = this;
            InitializeComponent();
        }
        public EditAppCategoryWindow(ViewModels.EditAppCategoryWindowViewModel viewModel)
        {
            ViewModel = viewModel;

            this.DataContext = this;
            InitializeComponent();
        }
    }
}
