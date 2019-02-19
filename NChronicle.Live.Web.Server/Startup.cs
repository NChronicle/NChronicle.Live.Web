using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NChronicle.Core.Interfaces;
using NChronicle.Core.Model;

namespace NChronicle.Live.Web.Server
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            Core.NChronicle.ConfigureFrom("NChronicle.config");
            services.AddScoped<IChronicle>(_ => new Chronicle());

            services.AddResponseCompression();
            
            services.AddMvc().AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();

            app.UseBlazor<Client.Startup>();
            app.UseBlazorDebugging();
        }

    }
}
