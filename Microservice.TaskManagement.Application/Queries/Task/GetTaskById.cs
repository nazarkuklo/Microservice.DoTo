using Microservice.TaskManagement.Application.Common.DTO.Responses;
using Microservice.TaskManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.Queries.Task
{
    public record GetTaskById : IQuery<TaskDto>
    {
        public int Id { get; set; }
    }
}
