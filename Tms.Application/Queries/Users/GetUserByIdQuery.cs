using MediatR;
using Tms.Domain.Entities;

namespace Tms.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<ApplicationUser?>
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
