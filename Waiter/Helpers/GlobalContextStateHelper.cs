using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter.Helpers
{
    public static class GlobalContextStateHelper
    {
        // set token to null to clear login state
        public static void UpdateLoginState(string? accessToken = null, string? refreshToken = null)
        {
            if (accessToken == null || refreshToken == null)
            {
                GlobalContext.UserConfig.IsLoggedIn = false;
                GlobalContext.UserConfig.AccessToken = string.Empty;
                GlobalContext.UserConfig.RefreshToken = string.Empty;
                Core.Services.GlobalContext.AccessToken = string.Empty;
                Core.Services.GlobalContext.RefreshToken = string.Empty;
            }
            else
            {
                GlobalContext.UserConfig.IsLoggedIn = true;
                GlobalContext.UserConfig.AccessToken = accessToken;
                GlobalContext.UserConfig.RefreshToken = refreshToken;
                Core.Services.GlobalContext.AccessToken = accessToken;
                Core.Services.GlobalContext.RefreshToken = refreshToken;
            }
        }
    }
}
