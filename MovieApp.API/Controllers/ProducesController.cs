using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.DTO;
using MovieApp.Core.DTO.Producer;
using MovieApp.Core.Interfaces;
using MovieApp.Core.Models;

namespace MovieApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducesController : ControllerBase
    {
        private readonly IMapper _mapper;
        protected readonly IProducerRepository _baseRepository;

        public ProducesController(IProducerRepository baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ProducerResponseDto>> GetAll()
        {
            var result = await _baseRepository.GetAll();
            var response = _mapper.Map<IEnumerable<ProducerResponseDto>>(result);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("FindByName")]
        public async Task<IActionResult> FindByName(string name)
        {
            var result = await _baseRepository.Find(p => p.Name.Contains(name));
            var response = _mapper.Map<IEnumerable<ProducerResponseDto>>(result);
            if (result == null)
                return NotFound();

            return Ok(response);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await _baseRepository.GetById(Id);
            var response = _mapper.Map<ProducerResponseDto>(result);
            if (result == null)
                return NotFound();

            return Ok(response);

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProducerRequestDto dto)
        {
            var producer = _mapper.Map<Producer>(dto);
            var result = await _baseRepository.Add(producer);

            var response = _mapper.Map<ProducerResponseDto>(result);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] ProducerRequestDto dto)
        {
            var producer = await _baseRepository.GetById(id);

            if (producer == null)
                return BadRequest("The ID Not Exiest");

            producer = _mapper.Map<ProducerRequestDto, Producer>(dto, producer);

            await _baseRepository.Update(producer);

            var response = _mapper.Map<ProducerResponseDto>(producer);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var prod = await _baseRepository.GetById(id);
            if (prod == null)
                return BadRequest("The ID Not Exiest");

            var result = await _baseRepository.Delete(prod);

            var response = _mapper.Map<ProducerResponseDto>(result);

            return Ok(response);
        }
    }
}
