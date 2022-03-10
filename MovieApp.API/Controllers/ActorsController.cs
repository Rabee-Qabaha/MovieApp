using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.DTO;
using MovieApp.Core.Interfaces;
using MovieApp.Core.Models;

namespace MovieApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        protected readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        public ActorsController(IActorRepository baseRepository, IMapper mapper)
        {
            _actorRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var actors = await _actorRepository.GetAll();
            if (actors == null)
                return NotFound();

            var actordto = _mapper.Map<IEnumerable<ActorResponseDto>>(actors);
            return Ok(actordto);
        }
        [HttpGet("FindByName")]
        public async Task<IActionResult> FindByName(string name)
        {
            var result = await _actorRepository.Find(p => p.Name.Contains(name));
            if (result == null)
                return NotFound();

            var actordto = _mapper.Map<IEnumerable<ActorResponseDto>>(result);
            return Ok(actordto);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            var actor = await _actorRepository.GetById(Id);
            if (actor == null)
                return NotFound();

            var actordto = _mapper.Map<ActorResponseDto>(actor);
            return Ok(actordto);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ActorRequestDto dto)
        {
            var actor = _mapper.Map<Actor>(dto);
            var request = await _actorRepository.Add(actor);

            var response = _mapper.Map<ActorResponseDto>(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] ActorRequestDto dto)
        {
            var actor = await _actorRepository.GetById(id);
            if (actor == null)
                return BadRequest("There Is No Actor with this ID");

            var request = _mapper.Map(dto, actor);
            await _actorRepository.Update(request);

            var response = _mapper.Map<ActorResponseDto>(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _actorRepository.GetById(id);
            if (actor == null)
                return BadRequest("The ID Not Exiest");

            var request = _mapper.Map<Actor>(actor);
            await _actorRepository.Delete(request);

            var response = _mapper.Map<ActorResponseDto>(actor);
            return Ok(response);
        }
    }
}
