using MediatR;
using Tms.Domain;
using Tms.Application.DTOs;
namespace Tms.Application.Queries.Tasks
{
    public record GetTasksQuery(
        TaskStatus? Status = null,
        Guid? AssignedToUserId = null,
        Guid? TeamId = null,
        DateTime? DueDate = null,
        int Page = 1,
        int PageSize = 10
    ) : IRequest<List<TaskDto>>;
}
