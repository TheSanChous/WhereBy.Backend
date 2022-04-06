using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WhereBy.Application.Interfaces;

namespace WhereBy.Application.Notices.Queries.GetNoteList
{
    public class GetNoticeListQueryHandler
        : IRequestHandler<GetNoticeListQuery, NoticeListVm>
    {
        private readonly IDatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public GetNoticeListQueryHandler(IDatabaseContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<NoticeListVm> Handle(GetNoticeListQuery request,
            CancellationToken cancellationToken)
        {
            var notesQuery = await _dbContext.Notices
                .ProjectTo<NoticeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new NoticeListVm { Notices = notesQuery };
        }
    }
}
