using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereBy.Application.Common.Mappings;
using WhereBy.Application.Shops.Queries.GetShopList;
using WhereBy.Domain;

namespace WhereBy.Application.Shops.Commands.Create
{
    public class CreateShopCommand : IRequest<ShopLookupDto>, IMapWith<Shop>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateShopCommand, Shop>()
                .ForMember(shop => shop.Name, opt =>
                    opt.MapFrom(dto => dto.Name.Trim()))
                .ForMember(shop => shop.Address, opt =>
                    opt.MapFrom(dto => dto.Address.Trim()))
                .ForMember(shop => shop.Location, opt =>
                    opt.MapFrom(dto => dto.Location.Trim()));
        }
    }
}
