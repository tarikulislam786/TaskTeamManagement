using MediatR;
using Tms.Application.Commands.Users;
using Microsoft.EntityFrameworkCore;

namespace Tms.Application.Handlers.Commands.Users
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly TmsDbContext _context;

        public UpdateUserCommandHandler(TmsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
            if (user == null) return false;

            if (!string.IsNullOrEmpty(request.FullName)) user.FullName = request.FullName;
            if (!string.IsNullOrEmpty(request.Email)) user.Email = request.Email;
            if (!string.IsNullOrEmpty(request.Password)) user.Password = request.Password; // Ideally hash
            if (request.Role.HasValue) user.Role = request.Role.Value;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
