using Microservice.TaskManagement.Application.Common.DTO.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Persistence
{
    public static class PaginatedExtensions
    {
        public const int DefaultPageSize = 15;
        public const int DefaultCurrentPage = 1;

        public static async Task<PaginatedListDto<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int currentPage, int pageSize)
        {
            currentPage = currentPage > 0 ? currentPage : DefaultCurrentPage;
            pageSize = pageSize > 0 ? pageSize : DefaultPageSize;
            var count = await source.CountAsync();
            var items = await source.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedListDto<T>(items, count, currentPage, pageSize);
        }

    }
}
