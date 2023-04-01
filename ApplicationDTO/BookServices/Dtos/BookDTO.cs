using Application.AuthorServices.Dtos;
using Application.BookRequestServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookServices.Dtos
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InternationalStandardBookNumber { get; set; }
        public int Pages { get; set; }
        public int Inventory { get; set; }
        public int Available { get; set; }
        public int EditorialId { get; set; }
        public int EditionYear { get; set; }
        public int LanguageId { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public List<BookRequestDTO> BookRequests { get; set; }
    }
}
