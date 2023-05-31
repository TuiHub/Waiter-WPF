using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.Sephirah.V1;

namespace Waiter.Core.Models
{
    public class GameSave
    {
        public long InternalId { get; set; }
        public string Name { get; set; } = string.Empty;
        public long SizeBytes { get; set; }
        public byte[] Sha256 { get; set; } = new byte[32];
        public DateTime CreateTime { get; set; }
        public bool IsPinned { get; set; }
    }
}
