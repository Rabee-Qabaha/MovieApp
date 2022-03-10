using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.Core.DTO.Movie;
using MovieApp.Core.Interfaces;
using MovieApp.Core.Models;
using MovieApp.EF.Data;
using System.Linq.Expressions;

namespace MovieApp.EF.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        protected readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MovieRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Movie>> GetAll(string[] includes = null)
        {
            IQueryable<Movie> query = _context.Set<Movie>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.ToListAsync();
        }

        public async Task<Movie> GetById(int id)
        {
            return await _context.Set<Movie>().FindAsync(id);
        }

        public async Task<IEnumerable<Movie>> Find(Expression<Func<Movie, bool>> match, string[] includes = null)
        {
            IQueryable<Movie> query = _context.Set<Movie>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.Where(match).ToListAsync();
        }

        public Task<Movie> Add(Movie entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Movie> Delete(Movie entity)
        {
            var delete = _context.Movies.Remove(entity);
            await _context.SaveChangesAsync();

            return delete.Entity;
        }

        public Task<Movie> Update(Movie entity)
        {
            throw new NotImplementedException();
        }

        public async Task AddNewMovie(MovieRequestDto dto)
        {

            var movie = _mapper.Map<Movie>(dto);
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();


            foreach (var ActorId in dto.ActorsId)
            {
                var movie_actor = new Movie_Actor();
                movie_actor.MovieId = movie.Id;
                movie_actor.ActorId = ActorId;

                await _context.movie_Actors.AddAsync(movie_actor);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNewMovie(MovieRequestDto dto, int Id)
        {
            var dbmovie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == Id);

            if (dbmovie != null)
            {
                var movie = _mapper.Map<MovieRequestDto, Movie>(dto,dbmovie);
                await _context.SaveChangesAsync();
            }

            var actors = await _context.movie_Actors.Where(a => a.MovieId == Id).ToListAsync();
            _context.movie_Actors.RemoveRange(actors);
            await _context.SaveChangesAsync();

            foreach (var ActorId in dto.ActorsId)
            {
                var movie_actor = new Movie_Actor();
                movie_actor.MovieId = dbmovie.Id;
                movie_actor.ActorId = ActorId;

                await _context.movie_Actors.AddAsync(movie_actor);
            }
            await _context.SaveChangesAsync();

        }
    }
}
