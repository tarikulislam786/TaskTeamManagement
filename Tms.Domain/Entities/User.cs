using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tms.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Role Role { get; set; }
        public ICollection<Task> TasksCreated { get; set; } = new List<Task>();
        public ICollection<Task> TasksAssigned { get; set; } = new List<Task>();
    }
}
