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

namespace WhereBuy.WebApi.Controllers
{
    [Authorize]
    public class NoticeController : BaseController
    {
        private readonly IMapper _mapper;

        public NoticeController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<NoticeListVm> GetAll()
        {
            var query = new GetNoticeListQuery();
            var vm = await Mediator.Send(query);
            return vm;
        }

        [HttpGet("{id}")]
        public async Task<NoticeDetailsVm> Get(int id)
        {
            var query = new GetNoticeDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return vm;
        }

        [HttpPost]
        public async Task<NoticeDetailsVm> Create([FromBody] CreateNoticeDto createNoteDto)
        {
            var command = _mapper.Map<CreateNoticeCommand>(createNoteDto);
            var note = await Mediator.Send(command);
            return note;
        }

        [HttpPut]
        public async Task Update([FromBody] UpdateNoteDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateNoticeCommand>(updateNoteDto);
            await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var command = new DeleteNoticeCommand
            {
                Id = id
            };
            await Mediator.Send(command);
        }
    }
}
