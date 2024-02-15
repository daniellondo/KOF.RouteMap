using AutoMapper;
using AutoMapper.QueryableExtensions;
using KOF.RouteMap.Application.Common.Interfaces;
using KOF.RouteMap.Application.Common.Mappings;
using KOF.RouteMap.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KOF.RouteMap.Application.VisitPlan.Queries.GetVisitPlanWithPagination;

public class GetVisitPlanWithPaginationQuery : IRequest<PaginatedList<VisitPlanDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetVisitPlanWithPaginationQueryHandler : IRequestHandler<GetVisitPlanWithPaginationQuery, PaginatedList<VisitPlanDto>>
{
    private readonly IApplicationDbScopedContext _context;
    private readonly IMapper _mapper;

    public GetVisitPlanWithPaginationQueryHandler(IApplicationDbScopedContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<VisitPlanDto>> Handle(GetVisitPlanWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.VisitPlans.AsNoTracking()
            .OrderBy(x => x.Id)
            .ProjectTo<VisitPlanDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
