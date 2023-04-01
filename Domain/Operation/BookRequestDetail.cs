using Domain.Data;
using Domain.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operation
{
    [Table("BookRequestDetails", Schema = "operation")]
    public class BookRequestDetail : Entity
    {
        public int BookRequestId { get; set; }
        [ForeignKey("BookRequestId")]
        public virtual BookRequest BookRequest { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]

        public virtual Book Book { get; set; }
    }
}
