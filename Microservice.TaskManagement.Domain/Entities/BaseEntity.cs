using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Domain.Entities
{
    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CreatedUserId { get; set; }
        public int? ModifiedByUserId { get; set; }
    }
}
