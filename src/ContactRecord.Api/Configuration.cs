using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactRecord.Api
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureService(IServiceCollection services, IConfiguration config, IWebHostEnvironment environment)
        {
            return services
                    .AddCustomServices()
                    .AddProblemDetails()
                    .AddControllers()
                    .Services;

        }

        public static IApplicationBuilder Configure(IApplicationBuilder app,
                                                    Func<IApplicationBuilder, IApplicationBuilder> configureHost)
        {
            return configureHost(app)
                .UseProblemDetails()
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();

                });
        }
    }
}
