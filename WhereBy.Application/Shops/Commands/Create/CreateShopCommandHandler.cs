using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhereBuy.Application.Common.Exceptions;
using WhereBuy.Application.Interfaces;
using WhereBuy.Application.Shops.Queries.GetShopList;
using WhereBuy.Domain;

namespace WhereBuy.Application.Shops.Commands.Create
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
                throw new BadRequestException("SHOP_ALREADY_EXIST");
            }

            var shop = mapper.Map<Shop>(request);

            await databaseContext.Shops.AddAsync(shop, cancellationToken);
            await databaseContext.SaveChangesAsync(cancellationToken);

            return mapper.Map<ShopLookupDto>(shop);
        }
    }
}
