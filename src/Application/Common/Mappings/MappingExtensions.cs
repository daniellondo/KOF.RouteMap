using KOF.RouteMap.Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Google.Protobuf.Collections;

namespace KOF.RouteMap.Application.Common.Mappings;

public static class MappingExtensions
{
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
        => PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize);

    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration)
        => queryable.ProjectTo<TDestination>(configuration).ToListAsync();

    public static async Task<RepeatedField<TDestination>> ProjectToRepeatedFieldAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration)
    {
        var items = await queryable
            .ProjectTo<TDestination>(configuration).ToListAsync();
        var repeatedField = new RepeatedField<TDestination>();
        repeatedField.AddRange(items);
        return repeatedField;
    }

}
