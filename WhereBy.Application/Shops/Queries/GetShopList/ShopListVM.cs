using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereBy.Application.Shops.Queries.GetShopList
{
    public class ShopListVM
    {
        public IEnumerable<ShopLookupDto> Shops { get; set; }
    }
}
