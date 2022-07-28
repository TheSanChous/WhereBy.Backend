using AutoMapper;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WhereBuy.Application.Notices.Queries.GetNoteList;
using WhereBuy.Application.Notices.Queries.GetNoteDetails;
using WhereBuy.Application.Notices.Commands.CreateNote;
using WhereBuy.Application.Notices.Commands.UpdateNote;
using WhereBuy.Application.Notices.Commands.DeleteCommand;
using WhereBuy.WebApi.Models;
using WhereBuy.Application.Shops.Queries.GetShopList;
using WhereBuy.Application.Shops.Commands.Create;

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
