using Domain.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    [Table("Genres", Schema = "data")]
    public class Genre : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
