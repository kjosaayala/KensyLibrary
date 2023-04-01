using Domain.Main;
using Domain.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    [Table("Lectors", Schema = "data")]
    public class Lector : Entity
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public virtual ICollection<BookRequest> BookRequests { get; set; }
    }
}
