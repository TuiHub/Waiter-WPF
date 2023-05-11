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
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : UiWindow
    {
        public ViewModels.LoginWindowViewModel ViewModel { get; }
        public LoginWindow(ViewModels.LoginWindowViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }
    }
}
