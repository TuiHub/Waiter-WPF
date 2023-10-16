using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TuiHub.Protos.Librarian.Sephirah.V1;
using Waiter.Helpers;
using Wpf.Ui.Common.Interfaces;

namespace Waiter.ViewModels
{
    public partial class AppCategoryViewModel : ObservableObject, INavigationAware
    {
        [ObservableProperty]
        private int _counter = 0;
        [ObservableProperty]
        private Core.Models.AppCategory? _selectedAppCategory;
        [ObservableProperty]
        private List<Core.Models.AppCategory> _appCategories = new();

        public async void OnNavigatedTo()
        {
            try
            {
                await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                {
                    var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                    AppCategories = (await GlobalContext.LibrarianClientService.ListAppCategoriesAsync(client)).ToList();
                },
                async () => { });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught exception {ex.GetType()}, message:\n{ex.Message}", "Runtime Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void OnNavigatedFrom()
        {
        }

        [RelayCommand]
        private void OnCounterIncrement()
        {
            Counter++;
        }

        [RelayCommand]
        private void OnShowSelectedAppCategory()
        {
            string appCategoryInfoStr = "";
            if (SelectedAppCategory == null)
                appCategoryInfoStr = "null";
            else
                appCategoryInfoStr = $"InternalId = {SelectedAppCategory.InternalId}, " +
                                     $"Name = {SelectedAppCategory.Name}";
            MessageBox.Show($"Selected AppCategory = {appCategoryInfoStr}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        [RelayCommand]
        private void OnAddAppCategory()
        {
            var editAppCategoryWindow = new Views.Windows.EditAppCategoryWindow(appCategory: null);
            editAppCategoryWindow.Owner = App.Current.MainWindow;
            editAppCategoryWindow.ShowDialog();
            OnNavigatedTo();
        }

        [RelayCommand]
        private void OnEditAppCategory()
        {
            var editAppCategoryWindow = new Views.Windows.EditAppCategoryWindow(SelectedAppCategory);
            editAppCategoryWindow.Owner = App.Current.MainWindow;
            editAppCategoryWindow.ShowDialog();
            OnNavigatedTo();
        }

        [RelayCommand]
        private async void OnDeleteAppCategory()
        {
            if (SelectedAppCategory == null)
                return;
            var dialogResult = MessageBox.Show($"Are you sure to delete AppCategory ({SelectedAppCategory.InternalId}), " +
                                                   $"Name = {SelectedAppCategory.Name}",
                                               "Confirm?",
                                               MessageBoxButton.YesNoCancel,
                                               MessageBoxImage.Question);
            if (dialogResult == MessageBoxResult.Yes)
            {
                await EnsureLoginHelper.RunWithEnsureLoginAsync(async () =>
                {
                    var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                    await GlobalContext.LibrarianClientService.RemoveAppCategoryAsync(client, SelectedAppCategory.InternalId);
                    OnNavigatedTo();
                }, async () => { });
            }
        }
    }
}
