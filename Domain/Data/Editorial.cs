using Domain.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    [Table("Editorials", Schema = "data")]
    public class Editorial : Entity
    {
        public string Name { get; set; }
    }
}
