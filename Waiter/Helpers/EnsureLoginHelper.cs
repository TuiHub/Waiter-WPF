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
            var progressRingDialog = new ProgressRingWindow();
            progressRingDialog.Owner = App.Current.MainWindow;
            while (true)
            {
                try
                {
                    progressRingDialog.ViewModel.WorkText = "Loading...";
                    App.Current.MainWindow.IsEnabled = false;
                    progressRingDialog.Show();
                    await Work();
                }
                catch (RpcException ex) when (ex.Status.StatusCode == StatusCode.Unauthenticated)
                {
                    if (GlobalContext.UserConfig.IsLoggedIn == true)
                    {
                        // show progressRingDialog
                        progressRingDialog.ViewModel.WorkText = "Logging in using refresh token...";
                        // try refresh token
                        var client = new LibrarianSephirahService.LibrarianSephirahServiceClient(GlobalContext.GrpcChannel);
                        var (accessToken, refreshToken) = await GlobalContext.LibrarianClientService.GetTokenAsync(client);
                        
                        // refresh token auth succeed
                        if (accessToken != null && refreshToken != null)
                        {
                            await GlobalContextStateHelper.UpdateLoginState(accessToken, refreshToken);
                            await WorkCleanup();
                            continue;
                        }
                    }

                    // user not logged in or refresh token auth failed, show login dialog
                    var loginWindow = new LoginWindow();
                    loginWindow.Owner = App.Current.MainWindow;
                    loginWindow.ShowDialog();

                    // if closed by user, abort work
                    if (loginWindow.ViewModel.IsCodeClosed == false)
                    {
                        await WorkCleanup();
                        // close progressRingDialog
                        progressRingDialog.Close();
                        App.Current.MainWindow.IsEnabled = true;
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
                catch
                {
                    // close progressRingDialog
                    progressRingDialog.Close();
                    App.Current.MainWindow.IsEnabled = true;
                    throw;
                }
                // close progressRingDialog
                progressRingDialog.Close();
                App.Current.MainWindow.IsEnabled = true;
                break;
            }
        }
    }
}
