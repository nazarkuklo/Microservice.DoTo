using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Domain.Entities
{
    public class TaskEntity : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AssignedToUserId { get; set; }
        public List<TagEntity> Tags { get; set; }
        public StatusEntity Status { get; set; }

    }
}
