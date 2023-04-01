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
        Task<RequestResultDTO> Create(CreateBookRequestDTO model);
        Task<RequestResultDTO> Update(BookRequestDTO model);
        Task<RequestResultDTO> Disable(int id);
        Task<List<BookRequestDTO>> GetAll();
        Task<BookRequestDTO> GetById(int id);
    }
}
