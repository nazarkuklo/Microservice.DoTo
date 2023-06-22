using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.Interfaces
{
    public interface IPaginatedListDto<TEntity>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        public List<TEntity> Result { get; set; }
    }
}
