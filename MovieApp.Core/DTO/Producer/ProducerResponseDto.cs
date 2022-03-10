using MovieApp.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.DTO.Producer
{
    public class ProducerResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GenderEnum Gender { get; set; }
        public string Country { get; set; }
    }
}
