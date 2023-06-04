using Microservice.TaskManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.Common.DTO.Responses
{
    public class PaginatedListDto<T> : IPaginatedListDto<T>
    {
        public PaginatedListDto(List<T> items, int count, int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalItems = count;
            Result.AddRange(items);
        }

        public PaginatedListDto()
        {
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        public List<T> Result { get; set; } = new();
    }
}
