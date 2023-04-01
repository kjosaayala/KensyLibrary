using Application.AuthorServices.Dtos;
using Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AuthorServices
{
    public interface IAuthorService
    {
        Task<RequestResultDTO> CreateAuthor(CreateAuthorDTO model);
        Task<RequestResultDTO> UpdateAuthor(UpdateAuthorDTO model);
        Task<RequestResultDTO> DisableAuthor(int id);
        Task<AuthorDTO> GetAuthorById(int id);
        Task<List<AuthorDTO>> GetAllAuthors();
    }
}
