using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.DTO
{
    public class ActorResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime BOD { get; set; }
    }
}
