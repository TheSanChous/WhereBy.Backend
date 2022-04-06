using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WhereBy.Application.Interfaces;
using WhereBy.Application.Common.Exceptions;
using WhereBy.Domain;

namespace WhereBy.Application.Notices.Commands.UpdateNote
{
    public class UpdateNoticeCommandHandler
        : IRequestHandler<UpdateNoticeCommand>
    {
        private readonly IDatabaseContext _dbContext;

        public UpdateNoticeCommandHandler(IDatabaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateNoticeCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Notices.FirstOrDefaultAsync(note =>
                    note.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Notice), request.Id);
            }

            entity.Description = request.Description;
            entity.Modified = DateTime.Now.ToString("yyyy-MM-dd");

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
