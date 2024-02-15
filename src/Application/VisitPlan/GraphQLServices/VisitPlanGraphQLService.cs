using KOF.RouteMap.Application.Common.Interfaces;

namespace KOF.RouteMap.Application.VisitPlan.GraphQLServices
{

    public class VisitPlanGraphQLService(IApplicationDbPooledContext dbContextFactory) : IAsyncDisposable
    {
        private readonly IApplicationDbPooledContext _dbContextFactory = dbContextFactory;

        public IQueryable<Domain.Entities.VisitPlan> VisitPlan() =>
                _dbContextFactory.VisitPlans.AsQueryable();

        public ValueTask DisposeAsync()
        {
            return _dbContextFactory.DisposeAsync();
        }
    }
}
