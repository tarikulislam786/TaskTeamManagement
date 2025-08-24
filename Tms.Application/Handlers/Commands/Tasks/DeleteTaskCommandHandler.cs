using MediatR;
using Tms.Application.Commands.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tms.Application.Handlers.Commands.Tasks
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly TmsDbContext _context;

        public DeleteTaskCommandHandler(TmsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == request.TaskId, cancellationToken);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
