using MediatR;
using WhereBuy.Application.Notices.Queries.GetNoteDetails;

namespace WhereBuy.Application.Notices.Commands.CreateNote
{
    public class CreateNoticeCommand : IRequest<NoticeDetailsVm>
    {
        public int ShopId { get; set; }
        public string Description { get; set; }
    }
}
