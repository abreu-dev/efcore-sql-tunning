using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;
using Tunning.Infra.Core.Context;
using Tunning.Infra.Core.Entities;
using EntityFrameworkCoreContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Tunning.Infra.DbContext
{
    public class DataContext : EntityFrameworkCoreContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public bool IsAvailable()
        {
            return Database.CanConnect();
        }

        public DbSet<TDataEntity> GetDbSet<TDataEntity>() where TDataEntity : DataEntity
        {
            return Set<TDataEntity>();
        }

        public EntityEntry<TDataEntity> GetDbEntry<TDataEntity>(TDataEntity data) where TDataEntity : DataEntity
        {
            return Entry(data);
        }

        public IQueryable<TDataEntity> Query<TDataEntity>() where TDataEntity : DataEntity
        {
            return Set<TDataEntity>().AsQueryable();
        }

        public void AddData<TDataEntity>(TDataEntity data) where TDataEntity : DataEntity
        {
            Add(data);
        }

        public void UpdateData<TDataEntity>(TDataEntity data) where TDataEntity : DataEntity
        {
            Update(data);
        }

        public void DeleteData<TDataEntity>(TDataEntity data) where TDataEntity : DataEntity
        {
            Remove(data);
        }

        public int CommitChanges()
        {
            return SaveChanges();
        }

        public void RollBackChanges()
        {
            Database.RollbackTransaction();
        }
    }
}
