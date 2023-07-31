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
                "VNDB" => AppSource.Vndb,
                "Bangumi" => AppSource.Bangumi,
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
                AppSource.Vndb => "VNDB",
                AppSource.Bangumi => "Bangumi",
                null => "null",
                _ => "Unknown",
            };
        }

        public static AppPackageSource? StringToAppPackageSource(string? str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            return str switch
            {
                "Manual" => AppPackageSource.Manual,
                "Sentinel" => AppPackageSource.Sentinel,
                _ => AppPackageSource.Unspecified,
            };
        }

        public static string AppPackageSourceToString(AppPackageSource? appPackageSource)
        {
            return appPackageSource switch
            {
                AppPackageSource.Unspecified => "Unspecified",
                AppPackageSource.Manual => "Manual",
                AppPackageSource.Sentinel => "Sentinel",
                null => "null",
                _ => "Unknown",
            };
        }

        public static bool? StringToBool(string? str)
        {
            return str switch
            {
                "True" => true,
                "true" => true,
                "TRUE" => true,
                "False" => false,
                "false" => false,
                "FALSE" => false,
                _ => null
            };
        }

        public static string BoolToString(bool? b)
        {
            return b switch
            {
                true => "True",
                false => "False",
                _ => "null"
            };
        }
    }
}
