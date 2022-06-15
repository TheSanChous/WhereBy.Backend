using System;
using MediatR;

namespace WhereBuy.Application.Notices.Commands.UpdateNote
{
    public class UpdateNoticeCommand : IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
