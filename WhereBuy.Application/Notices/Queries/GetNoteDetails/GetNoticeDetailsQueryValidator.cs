using System;
using FluentValidation;

namespace WhereBuy.Application.Notices.Queries.GetNoteDetails
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
