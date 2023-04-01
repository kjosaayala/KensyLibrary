using Domain.Data;
using Domain.Enums;
using Domain.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operation
{
    [Table("BookRequests", Schema = "operation")]
    public class BookRequest : Entity
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public DateTime DateRequestOpen { get; set; }
        public DateTime? DateRequestClosed { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public virtual ICollection<BookRequestDetail> BookRequestDetails { get; set; }
    }
}
