using MediatR;
using Microsoft.EntityFrameworkCore;
using Tms.Application.DTOs;
using Tms.Application.Queries.Tasks;

namespace Tms.Application.Handlers.Queries.Tasks
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, List<TaskDto>>
    {
        private readonly TmsDbContext _context;

        public GetTasksQueryHandler(TmsDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Tasks.AsQueryable();

            if (request.Status.HasValue)
                query = query.Where(t => t.Status == request.Status.Value);

            if (request.AssignedToUserId.HasValue)
                query = query.Where(t => t.AssignedToUserId == request.AssignedToUserId.Value);

            if (request.TeamId.HasValue)
                query = query.Where(t => t.TeamId == request.TeamId.Value);

            if (request.DueDate.HasValue)
                query = query.Where(t => t.DueDate.Date == request.DueDate.Value.Date);

            // Sorting by DueDate ascending
            query = query.OrderBy(t => t.DueDate);

            // Pagination
            var skip = (request.Page - 1) * request.PageSize;
            var tasks = await query
                .Skip(skip)
                .Take(request.PageSize)
                .Select(t => new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status,
                    AssignedToUserId = t.AssignedToUserId,
                    TeamId = t.TeamId,
                    DueDate = t.DueDate
                })
                .ToListAsync(cancellationToken);

            return tasks;
        }
    }
}
