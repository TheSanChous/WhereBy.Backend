using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WhereBuy.Application.Common.Exceptions;
using WhereBuy.Domain;
using WhereBuy.Common.Abstractions;
using System;
using WhereBuy.Common.Errors;

namespace WhereBuy.Application.Notices.Commands.DeleteCommand
{
    public class DeleteNoticeCommandHandler
        : IRequestHandler<DeleteNoticeCommand>
    {
        private readonly IDatabaseContext _dbContext;

        public DeleteNoticeCommandHandler(IDatabaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteNoticeCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notices
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw AppErrors.NotFound.Create(nameof(Notice), request.Id.ToString());
            }

            _dbContext.Notices.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
