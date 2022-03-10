using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.DTO.Movie;
using MovieApp.Core.Interfaces;
using MovieApp.EF.Data;

namespace MovieApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        //private readonly AppDbContext _context;

        public MoviesController(IMovieRepository movieRepository, IMapper mapper, AppDbContext context)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            //_context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movie = await _movieRepository.GetAll();
            if (movie == null)
                return NotFound();

            var response = _mapper.Map<IEnumerable<MovieResponseDto>>(movie);
            return Ok(response);
        }
        [HttpGet("GetByTitle")]
        public async Task<IActionResult> FindByTitle(string title)
        {
            var movie = await _movieRepository.Find(m => m.Title.Contains(title));
            if (movie == null)
                return NotFound();

            var response = _mapper.Map<IEnumerable<MovieResponseDto>>(movie);
            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _movieRepository.GetById(id);
            if (movie == null)
                return NotFound();

            var response = _mapper.Map<MovieResponseDto>(movie);
            return Ok(response);
        }
        [HttpGet("GetByYear")]
        public async Task<IActionResult> GetByYear(int year)
        {
            var movie = await _movieRepository.Find(m => m.ReleasedYear == year);
            if (movie == null)
                return NotFound();

            var response = _mapper.Map<IEnumerable<MovieResponseDto>>(movie);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MovieRequestDto dto)
        {
            await _movieRepository.AddNewMovie(dto);
            return Ok(dto);
        }
        [HttpPut]
        public async Task<IActionResult> Put(MovieRequestDto dto, int Id)
        {
            await _movieRepository.UpdateNewMovie(dto,Id);
            return Ok(dto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieRepository.GetById(id);
            if (movie == null)
                return NotFound();

            await _movieRepository.Delete(movie);

            var response = _mapper.Map<MovieResponseDto>(movie);
            return Ok(response);
        }
    }
}
