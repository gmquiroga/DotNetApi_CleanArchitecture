using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ContactRecord.Host
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private IWebHostEnvironment Environment { get; }


        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomApiVersioning();
            services.AddCustomSwaggerGen();
            services.AddEntityFrameworkCore(Configuration);

            Api.Configuration.ConfigureService(services, Configuration, Environment);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            Api.Configuration.Configure(app, host =>
            {
                return host
                    .UseDefaultFiles()
                    .UseStaticFiles()
                    .UseCustomSwagger(provider);
                ;
            });
        }
    }
}
