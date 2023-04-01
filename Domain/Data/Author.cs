using Domain.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    [Table("Authors", Schema = "data")]
    public class Author : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
