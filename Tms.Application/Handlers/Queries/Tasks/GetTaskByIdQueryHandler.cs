using MediatR;
using Microsoft.EntityFrameworkCore;
using Tms.Application.DTOs;
using Tms.Application.Queries.Tasks;

namespace Tms.Application.Handlers.Queries.Tasks
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskDto>
    {
        private readonly TmsDbContext _context;

        public GetTaskByIdQueryHandler(TmsDbContext context)
        {
            _context = context;
        }

        public async Task<TaskDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == request.TaskId, cancellationToken);

            if (task == null)
                throw new KeyNotFoundException($"Task with Id {request.TaskId} not found.");

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                AssignedToUserId = task.AssignedToUserId,
                TeamId = task.TeamId,
                DueDate = task.DueDate
            };
        }
    }
}
