using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WhereBuy.Application.Shops.Commands.Create;
using WhereBuy.Application.Shops.Queries.GetShopList;

namespace WhereBuy.WebApi.Controllers
{
    [Authorize]
    public class ShopController : BaseController
    {
        private readonly IMapper _mapper;

        public ShopController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ShopLookupDto[]>GetAll()
        {
            var query = new GetShopListQuery();
            var vm = await Mediator.Send(query);
            return vm.Shops.ToArray();
        }

        [HttpPost]
        public async Task<ShopLookupDto> Create([FromBody] CreateShopCommand createShop)
        {
            var shop = await Mediator.Send(createShop);
            return shop;
        }
    }
}
