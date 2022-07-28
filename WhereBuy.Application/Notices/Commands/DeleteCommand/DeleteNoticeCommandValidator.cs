using FluentValidation;

namespace WhereBuy.Application.Notices.Commands.DeleteCommand
{
    public class DeleteNoticeCommandValidator : AbstractValidator<DeleteNoticeCommand>
    {
        public DeleteNoticeCommandValidator()
        {
            RuleFor(deleteNoteCommand => deleteNoteCommand.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
