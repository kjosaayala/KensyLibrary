using Application.Base;
using Application.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserServices
{
    public interface ILectorService
    {
        Task<RequestResultDTO> AddLector(CreateLectorDTO model);
        Task<RequestResultDTO> UpdateLector(LectorDTO model);
        Task<RequestResultDTO> DisableLector(int id);
        Task<List<LectorDTO>> GetAllLectors();
        Task<LectorDTO> GetLectorById(int id);
    }
}
