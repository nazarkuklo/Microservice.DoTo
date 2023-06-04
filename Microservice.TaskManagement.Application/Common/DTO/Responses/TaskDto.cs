using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.Common.DTO.Responses
{
    public class TaskDto : BaseDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AssignedToUserId { get; set; }
        public List<TaskTagDto> Tags { get; set; }
        public StatusDto Status { get; set; }
    }
}
