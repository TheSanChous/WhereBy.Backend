using System;
using MediatR;

namespace WhereBy.Application.Notices.Queries.GetNoteDetails
{
    public class GetNoticeDetailsQuery : IRequest<NoticeDetailsVm>
    {
        public int Id { get; set; }
    }
}
