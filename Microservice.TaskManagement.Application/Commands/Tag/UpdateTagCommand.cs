using Microservice.TaskManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.Commands.Tag
{
    public record UpdateTagCommand : ICommand<UpdateTagCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public int? ModifiedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public UpdateTagCommand()
        {
            UpdatedAt = DateTime.Now;
        }

    }
}
