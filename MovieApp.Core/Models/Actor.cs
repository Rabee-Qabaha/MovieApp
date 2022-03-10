using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Nationality { get; set; }
        public DateTime BOD { get; set; }

        // RelationShip
        public List<Movie_Actor> Movie_Actors  { get; set; }
        //public virtual ICollection<Movie> Movies { get; set; }
    }
}
