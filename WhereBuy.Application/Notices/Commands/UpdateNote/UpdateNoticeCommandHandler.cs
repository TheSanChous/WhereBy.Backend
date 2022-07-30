using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using WhereBuy.Common.Abstractions;
using WhereBuy.Common.Errors;
using WhereBuy.Domain;

namespace WhereBuy.Application.Notices.Commands.UpdateNote
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
                throw AppErrors.NotFound.Create(nameof(Notice), request.Id.ToString());
            }

            entity.Description = request.Description;
            entity.Modified = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
