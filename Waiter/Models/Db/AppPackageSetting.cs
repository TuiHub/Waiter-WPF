using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter.Models.Db
{
    public class AppPackageSetting
    {
        public long Id { get; set; }
        public long AppPackageId { get; set; }
        [MaxLength(256)]
        public string AppPath { get; set; } = string.Empty;
        [MaxLength(256)]
        public string WorkDir { get; set; } = string.Empty;
        [MaxLength(256)]
        public string ProcMonName { get; set; } = string.Empty;
        [MaxLength(256)]
        public string ProcMonPath { get; set; } = string.Empty;
    }
}
