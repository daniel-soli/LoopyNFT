using AutoMapper;
using AutoMapper.QueryableExtensions;
using LoopyNFT.API.Common.Models;
using Microsoft.EntityFrameworkCore;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace LoopyNFT.API.Common.Mappings
{
    public static class MappingExtensions
    {
        public static async Task<PaginatedList<TDestination>> PaginatedList<TDestination>(this IQueryable<TDestination> queryable, int pageIndex, int pageSize)
            => await Models.PaginatedList<TDestination>.CreateAsync(queryable, pageIndex, pageSize);

        public static async Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration)
            => await queryable.ProjectTo<TDestination>(configuration).ToListAsync<TDestination>();
    }
}
