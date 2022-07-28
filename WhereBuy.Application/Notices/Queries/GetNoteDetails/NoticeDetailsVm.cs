using AutoMapper;
using WhereBuy.Application.Common.Mappings;
using WhereBuy.Domain;

namespace WhereBuy.Application.Notices.Queries.GetNoteDetails
{
    public class NoticeDetailsVm : IMapWith<Notice>
    {
        public int Id { get; set; }
        public Shop Shop { get; set; }
        public string Description { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }
        public string Deleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Notice, NoticeDetailsVm>()
                .ForMember(noteVm => noteVm.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteVm => noteVm.Shop,
                    opt => opt.MapFrom(note => note.Shop))
                .ForMember(noteVm => noteVm.Description,
                    opt => opt.MapFrom(note => note.Description))
                .ForMember(noteVm => noteVm.Created,
                    opt => opt.MapFrom(note => note.Created))
                .ForMember(noteVm => noteVm.Modified,
                    opt => opt.MapFrom(note => note.Modified))
                .ForMember(noteVm => noteVm.Deleted,
                    opt => opt.MapFrom(note => note.Deleted));
        }
    }
}
