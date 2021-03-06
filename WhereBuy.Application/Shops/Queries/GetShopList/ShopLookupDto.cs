using AutoMapper;
using System;
using WhereBuy.Application.Common.Mappings;
using WhereBuy.Domain;

namespace WhereBuy.Application.Shops.Queries.GetShopList
{
    public class ShopLookupDto : IMapWith<Shop>
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Shop, ShopLookupDto>()
                .ForMember(dto => dto.Id, opt =>
                    opt.MapFrom(shop => shop.Id))
                .ForMember(dto => dto.Name, opt =>
                    opt.MapFrom(shop => shop.Name))
                .ForMember(dto => dto.Address, opt =>
                    opt.MapFrom(shop => shop.Address))
                .ForMember(dto => dto.Location, opt =>
                    opt.MapFrom(shop => shop.Location));
        }
    }
}
