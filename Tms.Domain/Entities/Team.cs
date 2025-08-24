﻿public class Team
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<Task> Tasks { get; set; } = new List<Task>();
}