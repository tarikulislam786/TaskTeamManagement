using MediatR;
using Tms.Application.Commands.Tasks;

namespace Tms.Application.Handlers.Commands.Tasks
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly TmsDbContext _context;
        public CreateTaskCommandHandler(TmsDbContext context) => _context = context;

        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new Task
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                AssignedToUserId = request.AssignedToUserId,
                TeamId = request.TeamId,
                DueDate = request.DueDate
            };
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync(cancellationToken);
            return task.Id;
        }
    }
}
