using MediatR;

namespace Tms.Application.Commands.Tasks
{
    public record CreateTaskCommand(string Title, string Description, Guid AssignedToUserId, Guid TeamId, DateTime DueDate)
    : IRequest<Guid>;
}
