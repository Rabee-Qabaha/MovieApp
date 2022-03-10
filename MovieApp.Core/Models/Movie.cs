using MovieApp.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        public GenresEnum Genre { get; set; }
        public int ReleasedYear { get; set; }
        public string PosterUrl { get; set; }

        // RelationShip
        //public virtual ICollection<Actor> Actors { get; set; }
        public List<Movie_Actor> Movie_Actors { get; set; }

        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
    }
}
