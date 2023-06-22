using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.Common.DTO.Responses
{
    public class BaseDto<T>
    {
        public T Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CreatedUserId { get; set; }
        public int? ModifiedByUserId { get; set; }
    }
}
