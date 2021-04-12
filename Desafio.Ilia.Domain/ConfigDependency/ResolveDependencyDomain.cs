using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace Desafio.Ilia.Domain.ConfigDependency
{
    public static class ResolveDependencyDomain
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services
                .RegisterAssemblyPublicNonGenericClasses(Assembly.GetExecutingAssembly())
                .Where(c => c.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Transient);
        }
    }
}
