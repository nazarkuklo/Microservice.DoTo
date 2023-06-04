using Microservice.TaskManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.Common.DTO.Responses
{
    public class PaginatedResponseDto<T> : ResponseDto<T>, IPaginatedResponseDto<T>
    {
        public int TotalCount { get; }
        public PaginatedResponseDto(T result, int totalCount)
    : base(result)
        {
            if (totalCount < 0)
                throw new ArgumentException($"{nameof(totalCount)} should be greater than 0.");

            TotalCount = totalCount;
        }
    }
}
