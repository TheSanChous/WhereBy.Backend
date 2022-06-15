using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereBuy.Application.Shops.Queries.GetShopList
{
    public class GetShopListQuery : IRequest<ShopListVM>
    {
    }
}
