using AutoMapper;
using ODataFlattening.DTOs;
using ODataFlattening.Models;

namespace ODataFlattening.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Child, ChildDTO>()
                .ReverseMap();
            CreateMap<Parent, ParentDTO>()
                .ForMember(parent => parent.Child, opt => opt.MapFrom(parent => parent.Children.OrderBy(child => child.Id).LastOrDefault()))
                .ReverseMap();
        }
    }
}
