using HotChocolate.Data;
using HotChocolate.Types;
using KOF.RouteMap.Application.VisitPlan.GraphQLServices;

namespace KOF.RouteMap.Application.VisitPlan.GraphQLQueries
{

    public class VisitPlanQuery
    {
        /// <summary>
        /// Gets access to all the visit Plans
        /// </summary>
        // [Authorize]
        [UseOffsetPaging(MaxPageSize = 100, IncludeTotalCount = true)]
        //[UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Domain.Entities.VisitPlan> VisitPlan(VisitPlanGraphQLService visitPlanService) =>
                visitPlanService.VisitPlan();
    }
}
