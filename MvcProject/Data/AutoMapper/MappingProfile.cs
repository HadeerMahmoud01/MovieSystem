using AutoMapper;
using MvcProject.Data.Dto;
using MvcProject.Models;
namespace MvcProject.Data.AutoMapper

{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Actor, ActorDto>();
            CreateMap<ActorDto, Actor>();
        }
        
    }
}
