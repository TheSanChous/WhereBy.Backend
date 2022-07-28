using System.Collections.Generic;

namespace WhereBuy.Application.Shops.Queries.GetShopList
{
    public class ShopListVM
    {
        public IEnumerable<ShopLookupDto> Shops { get; set; }
    }
}
