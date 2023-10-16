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
        public event EventHandler OnRequestClose;

        [ObservableProperty]
        private Core.Models.AppCategory? _appCategory;
        [ObservableProperty]
        private string _appCategoryName = "";

        public EditAppCategoryWindowViewModel() { }
        public EditAppCategoryWindowViewModel(Core.Models.AppCategory? appCategory = null)
        {
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
        private async void OnBtnClick()
        {
            try
            {
                // add
                if (AppCategory == null)
                {
                    await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                    {
                        var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GrpcChannel);
                        await LibrarianClientService.CreateAppCategoryAsync(client, new Core.Models.AppCategory { Name = AppCategoryName });
                    }, async () => { });
                }
                // edit
                else
                {
                    await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                    {
                        var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GrpcChannel);
                        await LibrarianClientService.UpdateAppCategoryAsync(client, new Core.Models.AppCategory
                        {
                            InternalId = AppCategory.InternalId,
                            Name = AppCategoryName
                        });
                    }, async () => { });
                }
                // close window
                OnRequestClose(this, new EventArgs());
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Caught exception {ex.GetType()}, message:\n{ex.Message}", "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
