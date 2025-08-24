using System.Collections.Generic;
using MediatR;
using Tms.Domain.Entities;  // ✅ Add this namespace

namespace Tms.Application.Users.Queries
{
    // The request to get all users
    public class GetUsersQuery : IRequest<List<ApplicationUser>>
    {
    }
}
