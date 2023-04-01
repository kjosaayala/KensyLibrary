using Application.Base;
using Application.BookServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookServices
{
    public interface IBookService
    {
        Task<RequestResultDTO> AddBook(CreateBookDTO model);
        Task<RequestResultDTO> UpdateBook(BookDTO model);
        Task<RequestResultDTO> DisableBook(int id);
        Task<List<BookDTO>> GetAllBooks();
        Task<List<BookDTO>> GetBooksByFilter (RequestBookFilterDTO filterModel);
        Task<BookDTO> GetBookById(int id);
    }
}
