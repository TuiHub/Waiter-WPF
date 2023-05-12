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
    /// ProgressWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ProgressWindow : UiWindow
    {
        public ViewModels.ProgressWindowViewModel ViewModel { get; }
        public ProgressWindow()
        {
            ViewModel = new ViewModels.ProgressWindowViewModel();

            this.DataContext = this;
            InitializeComponent();
        }
        public ProgressWindow(ViewModels.ProgressWindowViewModel viewModel)
        {
            ViewModel = viewModel;

            this.DataContext = this;
            InitializeComponent();
        }
    }
}
