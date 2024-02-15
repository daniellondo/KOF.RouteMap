using KOF.RouteMap.Domain.Tenant;
using Microsoft.EntityFrameworkCore;

namespace KOF.RouteMap.Infrastructure.Persistence
{
    public class ApplicationDbScopedFactory(
    IDbContextFactory<ApplicationDbPooledContext> pooledFactory,
    ITenant tenant) : IDbContextFactory<ApplicationDbPooledContext>
    {
        private const int DefaultTenantId = -1;

        private readonly IDbContextFactory<ApplicationDbPooledContext> _pooledFactory = pooledFactory;
        private readonly int _tenantId = tenant?.TenantId ?? DefaultTenantId;

        public ApplicationDbPooledContext CreateDbContext()
        {
            var context = _pooledFactory.CreateDbContext();
            context.TenantId = _tenantId;
            return context;
        }
    }
}
