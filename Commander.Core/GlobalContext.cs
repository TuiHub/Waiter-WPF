using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commander.Core
{
    public static class GlobalContext
    {
        public static string AccessToken { get; set; } = null!;
        public static string RefreshToken { get; set; } = null!;
    }
}
