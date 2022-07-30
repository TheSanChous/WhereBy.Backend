using AutoMapper;
using System;
using WhereBuy.Application.Common.Mappings;
using WhereBuy.Domain;

namespace WhereBuy.Application.Notices.Queries.GetNoteList
{
    public class NoticeLookupDto : IMapWith<Notice>
    {
        public int Id { get; set; }
        public Shop Shop { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Notice, NoticeLookupDto>()
                .ForMember(noteDto => noteDto.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Shop,
                    opt => opt.MapFrom(note => note.Shop))
                .ForMember(noteDto => noteDto.Description,
                    opt => opt.MapFrom(note => note.Description))
                .ForMember(noteDto => noteDto.CreatedAt,
                        opt => opt.MapFrom(note => note.Created));
        }
    }
}
