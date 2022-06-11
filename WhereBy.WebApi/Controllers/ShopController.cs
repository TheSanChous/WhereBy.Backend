using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WhereBy.Application.Shops.Commands.Create;
using WhereBy.Application.Shops.Queries.GetShopList;

namespace WhereBy.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class ShopController : BaseController
    {
        private readonly IMapper _mapper;

        public ShopController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of shops
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /shop
        /// </remarks>
        /// <returns>Returns shop list</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ShopListVM>> GetAll()
        {
            var query = new GetShopListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        ///// <summary>
        ///// Gets the shop by id
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        ///// GET /note/D34D349E-43B8-429E-BCA4-793C932FD580
        ///// </remarks>
        ///// <param name="id">Note id (guid)</param>
        ///// <returns>Returns NoteDetailsVm</returns>
        ///// <response code="200">Success</response>
        ///// <response code="401">If the user in unauthorized</response>
        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public async Task<ActionResult<NoticeDetailsVm>> Get(int id)
        //{
        //    var query = new GetNoticeDetailsQuery
        //    {
        //        Id = id
        //    };
        //    var vm = await Mediator.Send(query);
        //    return Ok(vm);
        //}

    /// <summary>
    /// Creates the shop
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /note
    /// {
    ///     name: "shop name",
    ///     address: "shop address",
    ///     location: "shop location",
    /// }
    /// </remarks>
    /// <returns>Returns shop (ShopLookupDto)</returns>
    /// <response code="201">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<ShopLookupDto>> Create([FromBody] CreateShopCommand createShop)
    {
        var shop = await Mediator.Send(createShop);
        return Ok(shop);
    }

    ///// <summary>
    ///// Updates the note
    ///// </summary>
    ///// <remarks>
    ///// Sample request:
    ///// PUT /note
    ///// {
    /////     title: "updated note title"
    ///// }
    ///// </remarks>
    ///// <param name="updateNoteDto">UpdateNoteDto object</param>
    ///// <returns>Returns NoContent</returns>
    ///// <response code="204">Success</response>
    ///// <response code="401">If the user is unauthorized</response>
    //[HttpPut]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    //public async Task<IActionResult> Update([FromBody] UpdateNoteDto updateNoteDto)
    //{
    //    var command = _mapper.Map<UpdateNoticeCommand>(updateNoteDto);
    //    await Mediator.Send(command);
    //    return NoContent();
    //}

    ///// <summary>
    ///// Deletes the note by id
    ///// </summary>
    ///// <remarks>
    ///// Sample request:
    ///// DELETE /note/88DEB432-062F-43DE-8DCD-8B6EF79073D3
    ///// </remarks>
    ///// <param name="id">Id of the note (guid)</param>
    ///// <returns>Returns NoContent</returns>
    ///// <response code="204">Success</response>
    ///// <response code="401">If the user is unauthorized</response>
    //[HttpDelete("{id}")]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    //public async Task<IActionResult> Delete(int id)
    //{
    //    var command = new DeleteNoticeCommand
    //    {
    //        Id = id
    //    };
    //    await Mediator.Send(command);
    //    return NoContent();
    //}
}
}
