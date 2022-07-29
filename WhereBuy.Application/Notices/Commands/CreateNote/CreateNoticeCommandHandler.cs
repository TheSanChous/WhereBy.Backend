using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using WhereBuy.Application.Notices.Queries.GetNoteDetails;
using WhereBuy.Common.Abstractions;
using WhereBuy.Common.Errors;
using WhereBuy.Domain;

namespace WhereBuy.Application.Notices.Commands.CreateNote
{
    public class CreateNoticeCommandHandler
        :IRequestHandler<CreateNoticeCommand, NoticeDetailsVm>
    {
        private readonly IDatabaseContext _dbContext;
        private readonly IMapper mapper;

        public CreateNoticeCommandHandler(IDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<NoticeDetailsVm> Handle(CreateNoticeCommand request,
            CancellationToken cancellationToken)
        {
            var shop = await _dbContext.Shops
                .FirstOrDefaultAsync(shop => shop.Id == request.ShopId, cancellationToken: cancellationToken);

            if (shop is null)
            {
                throw AppErrors.NotFound.Create(nameof(Shop), request.ShopId.ToString());
            }

            var notice = new Notice
            {
                Shop = shop,
                Description = request.Description,
                Created = DateTime.Now.ToString("yyyy-MM-dd"),
                Modified = DateTime.Now.ToString("yyyy-MM-dd"),
                Deleted = null
            };

            await _dbContext.Notices.AddAsync(notice, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return mapper.Map<NoticeDetailsVm>(notice);
        }
    }
}
