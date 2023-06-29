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
    public partial class ProgressRingWindow : UiWindow
    {
        public ViewModels.ProgressRingWindowViewModel ViewModel { get; }
        public ProgressRingWindow()
        {
            ViewModel = new ViewModels.ProgressRingWindowViewModel();

            this.DataContext = this;
            InitializeComponent();
        }
        public ProgressRingWindow(ViewModels.ProgressRingWindowViewModel viewModel)
        {
            ViewModel = viewModel;

            this.DataContext = this;
            InitializeComponent();
        }
    }
}
