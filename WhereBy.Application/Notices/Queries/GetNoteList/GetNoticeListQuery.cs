using System;
using MediatR;

namespace WhereBuy.Application.Notices.Queries.GetNoteList
{
    public class GetNoticeListQuery : IRequest<NoticeListVm>
    {
    }
}
