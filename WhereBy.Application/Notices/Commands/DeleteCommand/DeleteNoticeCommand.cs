using System;
using MediatR;

namespace WhereBuy.Application.Notices.Commands.DeleteCommand
{
    public class DeleteNoticeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
