using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MvcProject.Data;
using MvcProject.Data.Dto;
using MvcProject.Models;

namespace MvcProject.Services
{
    public class ActorServices : IActorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ActorServices(AppDbContext context, IMapper map)
        {
            _context = context;
            _mapper = map;
            
        }
        public async Task AddActor(ActorDto actor)
        {
            var actordto=_mapper.Map<Actor>(actor);
          await  _context.AddAsync(actordto);
            _context.SaveChanges();

        }

        public async Task DeleteActor(int id)
        {
          var result= await _context.Actor.FirstOrDefaultAsync(x => x.Id == id);
            if(result != null)
            {
                _context.Actor.Remove(result);
            }
        }

        public async Task<ActorDto> GetActor(int id)
        {

           var actorresult= await _context.Actor.FirstOrDefaultAsync(a => a.Id == id);
            var actordtoresult=_mapper.Map<ActorDto>(actorresult);
            return actordtoresult;

        }

        public async Task <IEnumerable<ActorDto>> GetAllActors()
        {
            var actorresult= await _context.Actor.ToListAsync();
            var actorresultdto=_mapper.Map<IEnumerable<ActorDto>>(actorresult);
            return actorresultdto;
        }

        public async Task<ActorDto> UpdateActor( ActorDto actor)
        {

            var existingActor = await _context.Actor.FirstOrDefaultAsync(a => a.Id == actor.Id);

            if (existingActor != null)
            {
              
                _mapper.Map(actor, existingActor);

                
                await _context.SaveChangesAsync();

               
            }
           
            return _mapper.Map<ActorDto>(existingActor);

        }
        public async Task DeleteActor(ActorDto actorDto)
        {
            var existingActor = await _context.Actor.FirstOrDefaultAsync(a => a.Id == actorDto.Id);
            _mapper.Map(actorDto, existingActor);
            _context.Remove(existingActor);
            await _context.SaveChangesAsync();
        }
    }
}
