using FluentValidation;

namespace IntranetCorrespondencia.api.Handlers
{
    public class CreateTaskValidator : AbstractValidator<CreateTaskRequest>
    {
        public CreateTaskValidator()
        {
            RuleFor(r => r.Description).NotEmpty().NotNull();
        }
    }
}
