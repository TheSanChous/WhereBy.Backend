﻿using AutoMapper;
using WhereBy.Application.Common.Mappings;
using WhereBy.Application.Notices.Commands.CreateNote;
using System.ComponentModel.DataAnnotations;

namespace WhereBy.WebApi.Models
{
    public class CreateNoticeDto : IMapWith<CreateNoticeCommand>
    {
        [Required]
        public int Shop_id { get; set; }

        [Required]
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoticeDto, CreateNoticeCommand>()
                .ForMember(noteCommand => noteCommand.ShopId,
                    opt => opt.MapFrom(noteDto => noteDto.Shop_id))
                .ForMember(noteCommand => noteCommand.Description,
                    opt => opt.MapFrom(noteDto => noteDto.Description));
        }
    }
}