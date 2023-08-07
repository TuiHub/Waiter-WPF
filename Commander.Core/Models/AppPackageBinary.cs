using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commander.Core.Models
{
    public class AppPackageBinary
    {
        public string Name { get; set; } = null!;
        public long SizeBytes { get; set; }
        public string PublicUrl { get; set; } = null!;
        public byte[]? Sha256 { get; set; }
        public AppPackageBinary(long id, TuiHub.Protos.Librarian.V1.AppPackageBinary? appPackageBinary)
        {
            if (appPackageBinary == null)
            {
                Name = string.Empty;
                SizeBytes = 0;
                PublicUrl = string.Empty;
                Sha256 = new byte[32];
            }
            else
            {
                Name = appPackageBinary.Name;
                SizeBytes = appPackageBinary.SizeBytes;
                PublicUrl = appPackageBinary.PublicUrl;
                Sha256 = appPackageBinary.Sha256.ToArray();
            }
        }

        public AppPackageBinary() { }

        public TuiHub.Protos.Librarian.V1.AppPackageBinary ToProtoAppPackageBinary()
        {
            return new TuiHub.Protos.Librarian.V1.AppPackageBinary
            {
                Name = Name,
                SizeBytes = SizeBytes,
                PublicUrl = PublicUrl,
                Sha256 = ByteString.CopyFrom(Sha256)
            };
        }
    }
}
