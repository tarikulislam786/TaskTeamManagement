using System;

namespace Tms.Domain.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = "Todo";

        // FK to the user who created the task
        public Guid CreatedByUserId { get; set; }
        public ApplicationUser CreatedBy { get; set; }

        // FK to the user the task is assigned to
        public Guid AssignedToUserId { get; set; }
        public ApplicationUser AssignedTo { get; set; }

        public Guid? TeamId { get; set; }
        // Optional: Team navigation
    }
}
