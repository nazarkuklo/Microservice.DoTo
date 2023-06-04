using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.Interfaces
{

    public interface IPaginatedResponseDto<T> : IResponseDto<T>
    {
        int TotalCount { get; }
    }

    public interface IResponseDto<T>
    {
        T Result { get; }
    }
}
