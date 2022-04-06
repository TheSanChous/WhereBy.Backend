using System;
using MediatR;

namespace WhereBy.Application.Notices.Commands.CreateNote
{
    public class CreateNoticeCommand : IRequest<int>
    {
        public int ShopId { get; set; }
        public string Description { get; set; }
    }
}
