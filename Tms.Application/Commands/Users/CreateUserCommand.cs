using MediatR;
using Tms.Domain;

namespace Tms.Application.Commands.Users
{
    public record CreateUserCommand(
        string FullName,
        string Email,
        string Password,
        Role Role
    ) : IRequest<Guid>;
}
