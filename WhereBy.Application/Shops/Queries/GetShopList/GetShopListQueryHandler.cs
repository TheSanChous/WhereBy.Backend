using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WhereBuy.Common.Abstractions;

namespace WhereBy.Application.Shops.Queries.GetShopList
{
    public class GetShopListQueryHandler : IRequestHandler<GetShopListQuery, ShopListVM>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IMapper mapper;

        public GetShopListQueryHandler(IDatabaseContext databaseContext,
             IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.mapper = mapper;
        }

        public async Task<ShopListVM> Handle(GetShopListQuery request, CancellationToken cancellationToken)
        {
            var shopList = await databaseContext.Shops
                .ProjectTo<ShopLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ShopListVM { Shops = shopList };
        }
    }
}
