using MvcProject.Data.Dto;
using MvcProject.Models;

namespace MvcProject.Services
{
    public interface IActorService
    {
        Task<IEnumerable<ActorDto>> GetAllActors();
         Task <ActorDto> GetActor(int id);

         Task AddActor(ActorDto  actor);

        Task<ActorDto> UpdateActor(ActorDto actor);
       Task DeleteActor(ActorDto  actorDto);


    }
}
