using Tunning.WebApi.Scope.Middlewares;

namespace Tunning.WebApi.Scope
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<ExceptionHandlingMiddleware>();

            FromProjects(services);
        }

        private static void FromProjects(IServiceCollection services)
        {
            Infra.DbContext.DependencyResolverService.Register(services);
        }
    }
}
