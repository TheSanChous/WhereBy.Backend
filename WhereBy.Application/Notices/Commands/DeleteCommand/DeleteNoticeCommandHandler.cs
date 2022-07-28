using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WhereBy.Abstractions;
using WhereBy.Application.Common.Exceptions;
using WhereBy.Domain;

namespace WhereBy.Application.Notices.Commands.DeleteCommand
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
                throw new NotFoundException(nameof(Notice), request.Id);
            }

            _dbContext.Notices.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
