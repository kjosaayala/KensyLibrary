using Application.Base;
using Application.EditorialServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EditorialServices
{
    public interface IEditorialService
    {
        Task<RequestResultDTO> CreateEditorial(CreateEditorialDTO model);
        Task<RequestResultDTO> UpdateEditorial(EditorialDTO model);
        Task<RequestResultDTO> DisableEditorial(int id);
        Task<List<EditorialDTO>> GetAllEditorials();
        Task<EditorialDTO> GetEditorialById(int id);
    }
}
