using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using NChronicle.Live.Web.Client.Components;
using NChronicle.Live.Web.Client.Services;

namespace NChronicle.Live.Web.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IStyleSheetService>(new StyleSheetService());
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("body");
        }
    }
}
