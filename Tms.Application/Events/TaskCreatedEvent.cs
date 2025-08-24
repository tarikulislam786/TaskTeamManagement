using MediatR;
using System;

namespace Tms.Application.Events
{
    public record TaskCreatedEvent(
        Guid TaskId,
        string Title,
        Guid AssignedToUserId,
        Guid CreatedByUserId
    ) : INotification;
}
