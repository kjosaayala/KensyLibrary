using Domain.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    [Table("Languages", Schema = "data")]
    public class Language : Entity
    {
        public string Name { get; set; }
    }
}
