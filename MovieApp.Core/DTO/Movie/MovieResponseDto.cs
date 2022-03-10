using MovieApp.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.DTO.Movie
{
    public class MovieResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public GenresEnum Genre { get; set; }
        public int ReleasedYear { get; set; }
        public string PosterUrl { get; set; }

        //public ProducerRequestDto Producer { get; set; }
    }
}
