using MediatR;
using Microsoft.EntityFrameworkCore;
using Tms.Application.Common.Interfaces;
using Tms.Domain.Entities;

namespace Tms.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ApplicationUser?>
    {
        private readonly ITmsDbContext _context;

        public GetUserByIdQueryHandler(ITmsDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
        }
    }
}
