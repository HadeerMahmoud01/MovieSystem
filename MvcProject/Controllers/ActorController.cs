using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcProject.Data;
using MvcProject.Data.Dto;
using MvcProject.Models;
using MvcProject.Services;

namespace MvcProject.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService _services;
        private readonly IMapper _mapper;

        public ActorController(IActorService services,IMapper mapper )
        {
           _services = services;
            _mapper = mapper;
        }
        public async Task <IActionResult> Index()
        {
            
            var actorList =await _services.GetAllActors();
           
            return View(actorList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(ActorDto actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);

            }
  
          await  _services.AddActor(actor);
            return RedirectToAction("Index");
        }
        public async Task <IActionResult> Details (int id)
        {
           
            var actorresult= await _services.GetActor(id);
            if(actorresult != null)
            {
                return View (actorresult);
            }
            return View();
        }
        public async Task <IActionResult> Edit( int id)
        {
            var actorresult=await _services.GetActor(id);
            if(actorresult != null) { 
            
               return View (actorresult);
            }
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Edit(ActorDto actorDto)
        {
            var actorresult=  await _services.GetActor(actorDto.Id);    
            if(actorresult != null)
            {
               var actorupdated= await _services.UpdateActor(actorDto);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result= await _services.GetActor(id);
            if(result != null)
            {
                return View(result);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ActorDto actorDto)
        {
            var result = await _services.GetActor(actorDto.Id);
            if(result != null) {

                await _services.DeleteActor(result);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
