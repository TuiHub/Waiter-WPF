using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.V1;

namespace Waiter.Core.Models
{
    public class App
    {
        public long InternalId { get; set; }
        public AppSource Source { get; set; }
        public string? SourceAppId { get; set; }
        public string? SourceUrl { get; set; }
        public string Name { get; set; } = null!;
        public AppType Type { get; set; }
        public string? ShortDescription { get; set; }
        public string? ImageUrl { get; set; }
        public AppDetails? AppDetails { get; set; }
        public App(TuiHub.Protos.Librarian.V1.App app)
        {
            InternalId = app.Id.Id;
            Source = app.Source;
            SourceAppId = string.IsNullOrEmpty(app.SourceAppId) ? null : app.SourceAppId;
            SourceUrl = string.IsNullOrEmpty(app.SourceUrl) ? null : app.SourceUrl;
            Name = app.Name;
            Type = app.Type;
            ShortDescription = string.IsNullOrEmpty(app.ShortDescription) ? null : app.ShortDescription;
            ImageUrl = string.IsNullOrEmpty(app.ImageUrl) ? null : app.ImageUrl;
            AppDetails = new AppDetails(app.Details);
        }
        public App() { }
    }
}
