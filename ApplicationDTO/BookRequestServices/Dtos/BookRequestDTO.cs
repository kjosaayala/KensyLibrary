using Application.Base;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookRequestServices.Dtos
{
    public class BookRequestDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
        public DateTime DateRequestOpen { get; set; }
        public DateTime? DateRequestClosed { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public List<BookRequestDetailDTO> BookRequestDetails { get; set; }
    }
}
