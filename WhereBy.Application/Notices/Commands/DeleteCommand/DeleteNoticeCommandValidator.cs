using System;
using FluentValidation;

namespace WhereBy.Application.Notices.Commands.DeleteCommand
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
