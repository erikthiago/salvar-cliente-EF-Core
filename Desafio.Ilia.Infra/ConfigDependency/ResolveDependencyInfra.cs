using Desafio.Ilia.Domain.Base.Interfaces;
using Desafio.Ilia.Infra.UOW;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace Desafio.Ilia.Infra.ConfigDependency
{
    public static class ResolveDependencyInfra
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services
                .RegisterAssemblyPublicNonGenericClasses(Assembly.GetExecutingAssembly())
                .Where(c => c.Name.EndsWith("Repository"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
