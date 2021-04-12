using Desafio.Ilia.Domain.ConfigDependency;
using Desafio.Ilia.Infra.ConfigDependency;
using Desafio.Ilia.Infra.Configs;
using Desafio.Ilia.Infra.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Desafio.Ilia.API.Utility
{
    public class DependencyResolver
    {
        private static readonly Func<IServiceProvider, EntityContext> repoFactoryEntity = (_) =>
        {
            return new EntityContext(new DBConfig());
        };

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(repoFactoryEntity);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            ResolveDependencyDomain.RegisterServices(services);
            ResolveDependencyInfra.RegisterServices(services);
        }
    }
}
