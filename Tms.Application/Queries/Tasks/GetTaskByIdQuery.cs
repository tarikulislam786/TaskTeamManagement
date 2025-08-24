using MediatR;
using Tms.Application.DTOs;
using System;

namespace Tms.Application.Queries.Tasks
{
    public record GetTaskByIdQuery(Guid TaskId) : IRequest<TaskDto>;
}
