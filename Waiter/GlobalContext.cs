using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Core.Contracts.Services;
using Waiter.Core.Services;
using Waiter.Models;

namespace Waiter
{
    public static class GlobalContext
    {
        public static SystemConfig SystemConfig { get; set; } = new SystemConfig();
        public static UserConfig UserConfig { get; set; } = new UserConfig();
        public static GrpcChannel GrpcChannel { get; set; } = null!;
        public static ILibrarianClientService LibrarianClientService { get; } = new LibrarianClientService();
    }
}
