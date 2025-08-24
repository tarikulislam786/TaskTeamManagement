using Tms.Domain;

namespace Tms.Application.DTOs
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public TaskStatus Status { get; set; }
        public Guid AssignedToUserId { get; set; }
        public Guid TeamId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
