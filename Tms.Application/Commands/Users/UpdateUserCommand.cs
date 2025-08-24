using MediatR;
using Tms.Domain;
using System;

namespace Tms.Application.Commands.Users
{
    public record UpdateUserCommand(
        Guid UserId,
        string? FullName = null,
        string? Email = null,
        string? Password = null,
        Role? Role = null
    ) : IRequest<bool>;
}
