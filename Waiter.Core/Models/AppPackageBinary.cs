using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter.Core.Models
{
    public class AppPackageBinary
    {
        // same as AppPackage Id
        public long InternalId { get; set; }
        public string Name { get; set; } = null!;
        public long SizeByte { get; set; }
        public string PublicUrl { get; set; } = null!;
        public byte[]? Sha256 { get; set; }
        public AppPackageBinary(long id, TuiHub.Protos.Librarian.V1.AppPackageBinary appPackageBinary)
        {
            InternalId = id;
            Name = appPackageBinary.Name;
            SizeByte = appPackageBinary.SizeByte;
            PublicUrl = appPackageBinary.PublicUrl;
            Sha256 = appPackageBinary.Sha256.ToArray();
        }
    }
}
