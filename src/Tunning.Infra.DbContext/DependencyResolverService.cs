using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tunning.Infra.Core.Context;

namespace Tunning.Infra.DbContext
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IDataContext, DataContext>();

            services.AddDbContext<DataContext>(
                options => options.UseSqlServer("name=ConnectionStrings:Tunning", x => x.MigrationsAssembly("Tunning.Infra.DbMigrations")));
        }
    }
}
