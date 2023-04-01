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
        Task<RequestResultDTO> Create(CreateBookDTO model);
        Task<RequestResultDTO> Update(BookDTO model);
        Task<RequestResultDTO> Disable(int id);
        Task<List<BookDTO>> GetAll();
        Task<BookDTO> GetById(int id);
    }
}
