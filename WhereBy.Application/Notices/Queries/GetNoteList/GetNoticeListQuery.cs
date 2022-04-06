using System;
using MediatR;

namespace WhereBy.Application.Notices.Queries.GetNoteList
{
    public class GetNoticeListQuery : IRequest<NoticeListVm>
    {
    }
}
