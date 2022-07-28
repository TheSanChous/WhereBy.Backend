using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WhereBy.Application.Common.Exceptions;
using WhereBy.Domain;
using WhereBuy.Common.Abstractions;
using WhereBuy.Common.Errors;

namespace WhereBy.Application.Notices.Queries.GetNoteDetails
{
    public class GetNoticeDetailsQueryHandler
        : IRequestHandler<GetNoticeDetailsQuery, NoticeDetailsVm>
    {
        private readonly IDatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public GetNoticeDetailsQueryHandler(IDatabaseContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<NoticeDetailsVm> Handle(GetNoticeDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notices
                .FirstOrDefaultAsync(note =>
                note.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw AppErrors.NotFound.Create(nameof(Notice), request.Id.ToString());
            }

            return _mapper.Map<NoticeDetailsVm>(entity);
        }
    }
}
