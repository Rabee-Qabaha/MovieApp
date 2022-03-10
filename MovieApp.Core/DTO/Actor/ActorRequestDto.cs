using MovieApp.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Core.DTO
{
    public class ActorRequestDto
    {
        public string Name { get; set; }
        [StringLength(50)]
        public string Nationality { get; set; }
        public DateTime BOD { get; set; }
    }
}
