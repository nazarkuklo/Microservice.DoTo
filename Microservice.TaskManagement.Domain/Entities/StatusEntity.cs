using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Domain.Entities
{
    public class StatusEntity : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<int?> TaskIds { get; set; }
        public List<TaskEntity> Tasks { get; set; }

    }
}
