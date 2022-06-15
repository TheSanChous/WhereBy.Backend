using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using WhereBuy.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WhereBuy.Application.Common.Exceptions;
using WhereBuy.Domain;

namespace WhereBuy.Application.Notices.Queries.GetNoteDetails
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
                throw new NotFoundException(nameof(Notice), request.Id);
            }

            return _mapper.Map<NoticeDetailsVm>(entity);
        }
    }
}
