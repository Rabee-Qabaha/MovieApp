using MovieApp.Core.DTO.Movie;
using MovieApp.Core.Models;

namespace MovieApp.Core.Interfaces
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task AddNewMovie(MovieRequestDto movie);
        Task UpdateNewMovie(MovieRequestDto movie , int Id);
    }
}
