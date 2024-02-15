using Microsoft.EntityFrameworkCore;

namespace KOF.RouteMap.Application.Common.Interfaces;

public interface IApplicationDbScopedContext
{
    public DbSet<Domain.Entities.VisitPlan> VisitPlans { get; }

    //Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
