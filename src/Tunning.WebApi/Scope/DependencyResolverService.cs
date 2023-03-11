using Tunning.WebApi.Scope.Middlewares;

namespace Tunning.WebApi.Scope
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<ExceptionMiddleware>();

            FromProjects(services);
        }

        private static void FromProjects(IServiceCollection services)
        {
            Infra.DbContext.DependencyResolverService.Register(services);
        }
    }
}
