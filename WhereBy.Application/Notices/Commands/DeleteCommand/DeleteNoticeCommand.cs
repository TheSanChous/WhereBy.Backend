using System;
using MediatR;

namespace WhereBy.Application.Notices.Commands.DeleteCommand
{
    public class DeleteNoticeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
