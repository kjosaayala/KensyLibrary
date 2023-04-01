using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookRequestServices.Dtos
{
    public class BookRequestDetailDTO
    {
        public int? Id { get; set; }

        public int BookRequestId { get; set; }
        public int BookId { get; set; }

        public string? Book { get; set; }
    }
}
