using MediatR;
using System;

namespace Tms.Application.Commands.Users
{
    public record DeleteUserCommand(Guid UserId) : IRequest<bool>;
}
