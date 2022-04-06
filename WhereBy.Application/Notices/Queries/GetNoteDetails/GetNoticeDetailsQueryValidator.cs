using System;
using FluentValidation;

namespace WhereBy.Application.Notices.Queries.GetNoteDetails
{
    public class GetNoticeDetailsQueryValidator : AbstractValidator<GetNoticeDetailsQuery>
    {
        public GetNoticeDetailsQueryValidator()
        {
            RuleFor(note => note.Id)
                .NotEmpty()
                .NotNull()
                .Must(id => id > 0);
        }
    }
}
