using System;
using MicroServiceTemplate.Application.Interfaces.Repositories;
using MicroServiceTemplate.Persistence.Context;
using MicroServiceTemplate.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroServiceTemplate.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void LoadServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MicroServiceContext>();
        }
    }
}

