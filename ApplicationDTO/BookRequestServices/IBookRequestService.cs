using Application.Base;
using Application.BookRequestServices.Dtos;
using Application.GenreServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookRequestServices
{
    public interface IBookRequestService
    {
        Task<RequestResultDTO> GenerateBookRequest(CreateBookRequestDTO model);
        Task<RequestResultDTO> UpdateBookRequest(BookRequestDTO model);
        Task<RequestResultDTO> DisableBookRequest(int id);
        Task<List<BookRequestDTO>> GetAllBookRequests();
        Task<BookRequestDTO> GetBookRequestById(int id);
    }
}
