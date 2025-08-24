using MediatR;
using System;

namespace Tms.Application.Commands.Tasks
{
    public record DeleteTaskCommand(Guid TaskId) : IRequest<bool>;
}
