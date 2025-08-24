using Tms.Domain.Entities;

public class Task
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public TaskStatus Status { get; set; } = TaskStatus.Todo;
    public Guid AssignedToUserId { get; set; }
    public User AssignedTo { get; set; } = null!;
    public Guid CreatedByUserId { get; set; }
    public User CreatedBy { get; set; } = null!;
    public Guid TeamId { get; set; }
    public Team Team { get; set; } = null!;
    public DateTime DueDate { get; set; }
}