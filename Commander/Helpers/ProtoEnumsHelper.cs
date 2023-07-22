using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.V1;

namespace Commander.Helpers
{
    public static class ProtoEnumsHelper
    {
        public static AppType? StringToAppType(string? str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            return str switch
            {
                "Game" => AppType.Game,
                _ => AppType.Unspecified,
            };
        }

        public static string AppTypeToString(AppType? appType)
        {
            return appType switch
            {
                AppType.Unspecified => "Unspecified",
                AppType.Game => "Game",
                null => "null",
                _ => "Unknown",
            };
        }

        public static AppSource? StringToAppSource(string? str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            return str switch
            {
                "Internal" => AppSource.Internal,
                "Steam" => AppSource.Steam,
                _ => AppSource.Unspecified,
            };
        }

        public static string AppSourceToString(AppSource? appSource)
        {
            return appSource switch
            {
                AppSource.Unspecified => "Unspecified",
                AppSource.Internal => "Internal",
                AppSource.Steam => "Steam",
                null => "null",
                _ => "Unknown",
            };
        }
    }
}
