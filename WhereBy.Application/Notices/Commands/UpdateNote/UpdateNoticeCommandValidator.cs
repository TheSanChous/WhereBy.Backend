using System;
using FluentValidation;

namespace WhereBy.Application.Notices.Commands.UpdateNote
{
    public class UpdateNoticeCommandValidator : AbstractValidator<UpdateNoticeCommand>
    {
        public UpdateNoticeCommandValidator()
        {
            RuleFor(updateNoteCommand => updateNoteCommand.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(updateNoteCommand => updateNoteCommand.Description)
                .NotEmpty()
                .MaximumLength(250);
        }
    }
}
