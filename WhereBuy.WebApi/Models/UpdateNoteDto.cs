using AutoMapper;
using WhereBuy.Application.Common.Mappings;
using WhereBuy.Application.Notices.Commands.UpdateNote;

namespace WhereBuy.WebApi.Models
{
    public class UpdateNoteDto : IMapWith<UpdateNoticeCommand>
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDto, UpdateNoticeCommand>()
                .ForMember(noteCommand => noteCommand.Id,
                    opt => opt.MapFrom(noteDto => noteDto.Id))
                .ForMember(noteCommand => noteCommand.Description,
                    opt => opt.MapFrom(noteDto => noteDto.Description));
        }
    }
}
