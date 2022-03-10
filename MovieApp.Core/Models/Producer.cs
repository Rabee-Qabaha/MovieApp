using MovieApp.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Models
{
    public class Producer
    {

        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public GenderEnum Gender { get; set; }
        public string  Country { get; set; }
    }
}
