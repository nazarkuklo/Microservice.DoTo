using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.Common.Options
{
    public record PaginationOptions
    {
        public const int DefaultPage = 1;
        public const int DefaultPageSize = 10;

        public int Page { get; set; } = DefaultPage;

        public int PageSize { get; set; } = DefaultPageSize;
    }
}
