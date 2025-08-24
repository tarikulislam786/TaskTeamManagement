using MediatR;
using Tms.Application.Commands.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tms.Application.Handlers.Commands.Tasks
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
    {
        private readonly TmsDbContext _context;

        public UpdateTaskCommandHandler(TmsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == request.TaskId, cancellationToken);
            if (task == null) return false;

            if (!string.IsNullOrEmpty(request.Title)) task.Title = request.Title;
            if (!string.IsNullOrEmpty(request.Description)) task.Description = request.Description;
            if (request.Status.HasValue) task.Status = request.Status.Value;
            if (request.AssignedToUserId.HasValue) task.AssignedToUserId = request.AssignedToUserId.Value;
            if (request.DueDate.HasValue) task.DueDate = request.DueDate.Value;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
