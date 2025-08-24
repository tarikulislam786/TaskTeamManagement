using MediatR;
using Microsoft.EntityFrameworkCore;
using Tms.Application.Commands.Users;

namespace Tms.Application.Handlers.Commands.Users
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly TmsDbContext _context;

        public DeleteUserCommandHandler(TmsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
            if (user == null) return false;

            // Optional: Prevent deleting Admin itself
            if (user.Role == Role.Admin)
                throw new InvalidOperationException("Admin user cannot be deleted.");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
