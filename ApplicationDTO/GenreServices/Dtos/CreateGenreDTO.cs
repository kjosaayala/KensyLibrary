using Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GenreServices.Dtos
{
    public class CreateGenreDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
