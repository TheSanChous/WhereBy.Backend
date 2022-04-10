using System;
using MediatR;
using WhereBy.Application.Notices.Queries.GetNoteDetails;

namespace WhereBy.Application.Notices.Commands.CreateNote
{
    public class CreateNoticeCommand : IRequest<NoticeDetailsVm>
    {
        public int ShopId { get; set; }
        public string Description { get; set; }
    }
}
