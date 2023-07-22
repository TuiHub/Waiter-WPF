using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commander.Core.Helpers
{
    public static class JwtHelper
    {
        public static Metadata GetMetadataWithAccessToken()
        {
            return GetMetadataWithJwt(GlobalContext.AccessToken);
        }
        public static Metadata GetMetadataWithRefreshToken()
        {
            return GetMetadataWithJwt(GlobalContext.RefreshToken);
        }

        public static Metadata GetMetadataWithJwt(string token)
        {
            var metadata = new Grpc.Core.Metadata();
            metadata.Add("authorization", $"bearer {token}");
            return metadata;
        }
    }
}
