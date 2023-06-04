using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Domain.Entities
{
    public class TagEntityTaskEntity
    {
       public int TagId { get; set; }
       public int TaskId { get; set; }
       public TaskEntity Task { get; set; }
       public TagEntity Tag { get; set; }
    }
}
