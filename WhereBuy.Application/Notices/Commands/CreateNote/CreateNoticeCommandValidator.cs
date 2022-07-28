using FluentValidation;

namespace WhereBuy.Application.Notices.Commands.CreateNote
{
    public class CreateNoticeCommandValidator : AbstractValidator<CreateNoticeCommand>
    {
        public CreateNoticeCommandValidator()
        {
            RuleFor(command => command.ShopId)
                .NotEmpty();
            
            RuleFor(command => command.Description)
                .NotEmpty()
                .MaximumLength(250);
        }
    }
}
