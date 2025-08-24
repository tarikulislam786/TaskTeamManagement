using MediatR;
using Tms.Domain;
using System;

namespace Tms.Application.Commands.Tasks
{
    public record UpdateTaskCommand(
        Guid TaskId,
        string? Title = null,
        string? Description = null,
        TaskStatus? Status = null,
        Guid? AssignedToUserId = null,
        DateTime? DueDate = null
    ) : IRequest<bool>;
}
