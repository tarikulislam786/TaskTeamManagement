using MediatR;
using Microsoft.EntityFrameworkCore;
using Tms.Application.Common.Interfaces;
using Tms.Domain.Entities;

namespace Tms.Application.Users.Queries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<ApplicationUser>>
    {
        private readonly ITmsDbContext _context;

        public GetUsersQueryHandler(ITmsDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationUser>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            // Fetch all users from the database
            return await _context.Users.ToListAsync(cancellationToken);
        }
    }
}
