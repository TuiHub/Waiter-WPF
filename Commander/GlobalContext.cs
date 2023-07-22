using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commander
{
    public static class GlobalContext
    {
        public static string ServerAddress = Helpers.ConfigurationHelper.GetAppSetting("ServerAddress") ?? "https://theam.example.com";
        public static GrpcChannel GrpcChannel { get; set; } = GrpcChannel.ForAddress(ServerAddress);
        public static Core.Services.LibrarianClientService LibrarianClientService { get; } = new();
    }
}
