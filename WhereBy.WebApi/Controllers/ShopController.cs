using AutoMapper;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WhereBy.Application.Notices.Queries.GetNoteList;
using WhereBy.Application.Notices.Queries.GetNoteDetails;
using WhereBy.Application.Notices.Commands.CreateNote;
using WhereBy.Application.Notices.Commands.UpdateNote;
using WhereBy.Application.Notices.Commands.DeleteCommand;
using WhereBy.WebApi.Models;
using WhereBy.Application.Shops.Queries.GetShopList;
using WhereBy.Application.Shops.Commands.Create;

namespace WhereBy.WebApi.Controllers
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
