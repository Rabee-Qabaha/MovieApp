using MovieApp.Core.Enum;
using MovieApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.DTO.Movie
{
    public class MovieRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public GenresEnum Genre { get; set; }
        public int ReleasedYear { get; set; }
        public string PosterUrl { get; set; }

        //// RelationShip
        public List<int> ActorsId { get; set; }
        public int ProducerId { get; set; }
    }
}
