using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Domain.Entities
{
    public class TagEntity : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public List<TaskEntity> Task { get; set; }

    }
}
