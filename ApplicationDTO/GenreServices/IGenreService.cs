using Application.Base;
using Application.GenreServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GenreServices
{
    public interface IGenreService
    {
        Task<RequestResultDTO> AddGenre(CreateGenreDTO model);
        Task<RequestResultDTO> UpdateGenre(GenreDTO model);
        Task<RequestResultDTO> DisableGenre(int id);
        Task<List<GenreDTO>> GetAllGenres();
        Task<GenreDTO> GetGenreById(int id);
    }
}
