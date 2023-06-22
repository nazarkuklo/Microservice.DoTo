using Microservice.TaskManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.Commands.Status
{
    public record CreateStatusCommand : ICommand<CreateStatusCommand>
    {
        public int Id { get; set; }
        public int? TaskId { get; set; }
        public string Name { get; set; }
    }
}
