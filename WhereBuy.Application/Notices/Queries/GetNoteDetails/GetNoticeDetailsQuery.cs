using MediatR;

namespace WhereBuy.Application.Notices.Queries.GetNoteDetails
{
    public class GetNoticeDetailsQuery : IRequest<NoticeDetailsVm>
    {
        public int Id { get; set; }
    }
}
