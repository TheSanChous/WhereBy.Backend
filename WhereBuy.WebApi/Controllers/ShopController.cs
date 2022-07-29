using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<ShopListVM>> GetAll()
        {
            var query = new GetShopListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<ShopLookupDto>> Create([FromBody] CreateShopCommand createShop)
        {
            var shop = await Mediator.Send(createShop);
            return Ok(shop);
        }
    }
}
