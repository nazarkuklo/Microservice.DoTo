using Microservice.TaskManagement.Application.Interfaces;
using Microservice.TaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.Commands.Task
{
    public record CreateTaskCommand : ICommand<CreateTaskCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AssignedToUserId { get; set; }
        public List<int?> Tags { get; set; }
        public int? Status { get; set; }
    }
}
