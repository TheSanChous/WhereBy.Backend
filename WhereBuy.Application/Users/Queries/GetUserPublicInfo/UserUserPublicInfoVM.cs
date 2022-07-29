using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereBuy.Application.Common.Mappings;
using WhereBuy.Domain;

namespace WhereBuy.Application.Users.Queries.GetUserPublicInfo
{
    public class UserPublicInfoVM : IMapWith<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserPublicInfoVM>()
                .ForMember(user => user.Id,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(user => user.Name,
                    opt => opt.MapFrom(user => user.Name));
        }
    }
}
