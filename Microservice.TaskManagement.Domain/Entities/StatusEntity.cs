using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Domain.Entities
{
    public class StatusEntity : BaseEntity
    {
        public int? EntityId { get; set; }
        public TaskEntity Entity { get; set; }

    }
}
