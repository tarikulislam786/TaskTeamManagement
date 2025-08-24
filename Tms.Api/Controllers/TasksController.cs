using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tms.Domain.Entities;
using Tms.Application.Commands.Tasks;
using Tms.Application.Queries.Tasks;

namespace Tms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>> GetTasks(
    [FromQuery] string? status,
    [FromQuery] Guid? assignedTo,
    [FromQuery] Guid? teamId,
    [FromQuery] DateTime? dueDate)
        {
            TaskStatus? taskStatus = null;

            if (!string.IsNullOrEmpty(status) &&
                Enum.TryParse<TaskStatus>(status, true, out var parsedStatus))
            {
                taskStatus = parsedStatus;
            }

            var query = new GetTasksQuery
            {
                Status = taskStatus,
                AssignedToUserId = assignedTo,
                TeamId = teamId,
                DueDate = dueDate
            };

            var tasks = await _mediator.Send(query);
            return Ok(tasks);
        }

        // GET: api/Tasks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskById(Guid id)
        {
            var task = await _mediator.Send(new GetTaskByIdQuery(id));
            if (task == null) return NotFound();
            return Ok(task);
        }

        // POST: api/Tasks
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<Guid>> CreateTask([FromBody] CreateTaskCommand command)
        {
            var taskId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTaskById), new { id = taskId }, taskId);
        }

        // PUT: api/Tasks/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Manager,Employee")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] UpdateTaskCommand command)
        {
            if (id != command.TaskId) return BadRequest("Id mismatch");

            var result = await _mediator.Send(command);
            if (!result) return NotFound();
            return NoContent();
        }

        // DELETE: api/Tasks/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var result = await _mediator.Send(new DeleteTaskCommand(id));
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
