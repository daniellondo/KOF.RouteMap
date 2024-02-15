using KOF.RouteMap.Application.VisitPlan.Queries.GetVisitPlanWithPagination;

namespace GrpcService.Services.Common
{
    public class PaginatedData
    {
        public List<VisitPlanDto>? Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public float Progress { get; set; }
    }
}
