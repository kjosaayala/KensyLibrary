using Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookServices.Dtos
{
    public class RequestBookFilterDTO
    {
        public BookFilterType FilterKey { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int EditorialId { get; set; }
        public int LanguageId { get; set; }
        public string? BookName { get; set; }
    }
}
