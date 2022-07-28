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

namespace WhereBy.WebApi.Controllers
{
    public class NoticeController : BaseController
    {
        private readonly IMapper _mapper;

        public NoticeController(IMapper mapper) => _mapper = mapper;

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<NoticeListVm>> GetAll()
        {
            var query = new GetNoticeListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<NoticeDetailsVm>> Get(int id)
        {
            var query = new GetNoticeDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<NoticeDetailsVm>> Create([FromBody] CreateNoticeDto createNoteDto)
        {
            var command = _mapper.Map<CreateNoticeCommand>(createNoteDto);
            var note = await Mediator.Send(command);
            return Ok(note);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNoteDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateNoticeCommand>(updateNoteDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteNoticeCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
