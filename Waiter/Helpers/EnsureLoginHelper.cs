using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TuiHub.Protos.Librarian.Sephirah.V1;
using Waiter.Core.Services;
using Waiter.Views.Pages;
using Waiter.Views.Windows;

namespace Waiter.Helpers
{
    public static class EnsureLoginHelper
    {
        public static async Task RunWithEnsureLoginAsync(Func<Task> Work, Func<Task> WorkCleanup)
        {
            while (true)
            {
                try
                {
                    await Work();
                }
                catch (RpcException e) when (e.Status.StatusCode == StatusCode.Unauthenticated)
                {
                    if (GlobalContext.UserConfig.IsLoggedIn == true)
                    {
                        // show progress
                        var progressDialog = new ProgressWindow();
                        progressDialog.Owner = App.Current.MainWindow;
                        progressDialog.ViewModel.WorkText = "Logging in using refresh token...";
                        progressDialog.Show();
                        App.Current.MainWindow.IsEnabled = false;
                        // try refresh token
                        var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                        var (accessToken, refreshToken) = await GlobalContext.LibrarianClientService.GetTokenAsync(client);
                        // close progressDialog
                        progressDialog.Close();
                        // refresh token auth succeed
                        if (accessToken != null && refreshToken != null)
                        {
                            await GlobalContextStateHelper.UpdateLoginState(accessToken, refreshToken);
                            await WorkCleanup();
                            App.Current.MainWindow.IsEnabled = true;
                            continue;
                        }
                        // enable MainWindow, for ShowDialog will block user from interacting with parent window
                        App.Current.MainWindow.IsEnabled = true;
                    }

                    // user not logged in or refresh token auth failed, show login dialog
                    var loginWindow = new LoginWindow();
                    loginWindow.Owner = App.Current.MainWindow;
                    loginWindow.ShowDialog();

                    // if closed by user, abort work
                    if (loginWindow.ViewModel.IsCodeClosed == false)
                    {
                        await WorkCleanup();
                        MessageBox.Show("User cancelled login.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    }
                    // login succeed, continue work
                    else
                    {
                        await WorkCleanup();
                        continue;
                    }
                }
                break;
            }
        }
    }
}
