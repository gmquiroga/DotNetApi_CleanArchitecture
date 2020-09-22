using ContactRecord.Application.Interfaces;
using ContactRecord.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IContactRecordService, ContactRecordService>();
            
            return services;
        }
    }
}
