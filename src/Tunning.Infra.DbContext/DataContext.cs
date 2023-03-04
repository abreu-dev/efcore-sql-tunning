using Microsoft.EntityFrameworkCore;
using Tunning.Infra.Core.Context;
using EntityFrameworkCoreContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Tunning.Infra.DbContext
{
    public class DataContext : EntityFrameworkCoreContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public bool IsAvailable()
        {
            return Database.CanConnect();
        }
    }
}
