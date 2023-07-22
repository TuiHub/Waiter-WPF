using Commander.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.Sephirah.V1;

namespace Commander.Core.Services
{
    public partial class LibrarianClientService
    {
        public async Task<(string, string)> GetTokenAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client, string username, string password)
        {
            var request = new GetTokenRequest
            {
                Username = username,
                Password = password
            };
            var response = await client.GetTokenAsync(request);
            return (response.AccessToken, response.RefreshToken);
        }

        public async Task<(string?, string?)> GetTokenAsync(LibrarianSephirahService.LibrarianSephirahServiceClient client)
        {
            try
            {
                var response = await client.RefreshTokenAsync(
                                                new RefreshTokenRequest(),
                                                headers: JwtHelper.GetMetadataWithRefreshToken());
                return (response.AccessToken, response.RefreshToken);
            }
            catch
            {
                return (null, null);
            }
        }
    }
}
