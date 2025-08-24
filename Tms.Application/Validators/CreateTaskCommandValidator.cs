using Tms.Application.Commands.Tasks;
using FluentValidation;
public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.DueDate).GreaterThan(DateTime.UtcNow).WithMessage("DueDate must be in the future");
    }
}
