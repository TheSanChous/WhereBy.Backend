using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WhereBy.Application.Common.Exceptions;
using WhereBy.Application.Shops.Queries.GetShopList;
using WhereBy.Domain;
using WhereBuy.Common.Abstractions;
using WhereBuy.Common.Errors;

namespace WhereBy.Application.Shops.Commands.Create
{
    public class CreateShopCommandHandler : IRequestHandler<CreateShopCommand, ShopLookupDto>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IMapper mapper;

        public CreateShopCommandHandler(IDatabaseContext databaseContext, IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.mapper = mapper;
        }

        public async Task<ShopLookupDto> Handle(CreateShopCommand request, CancellationToken cancellationToken)
        {
            var matches = await databaseContext.Shops
                .CountAsync(shop => shop.Name.ToLower() == request.Name.ToLower().Trim()
                    || shop.Address.ToLower() == request.Address.ToLower().Trim()
                    || shop.Location.Trim() == request.Location.ToLower().Trim(), cancellationToken);

            if (matches > 0)
            {
                throw AppErrors.EntityExists.Create(nameof(Shop));
            }

            var shop = mapper.Map<Shop>(request);

            await databaseContext.Shops.AddAsync(shop, cancellationToken);
            await databaseContext.SaveChangesAsync(cancellationToken);

            return mapper.Map<ShopLookupDto>(shop);
        }
    }
}
